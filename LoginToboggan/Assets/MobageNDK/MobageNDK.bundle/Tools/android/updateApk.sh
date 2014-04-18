#!/bin/sh
# This script changes the apk's package name, insterts ad library information and recompiles/signs it.
# The final apk filename will be '<original name minus extension>-final.apk'

# 1 will remove intermediate build files on successful build.
# 0 will leave them
REMOVEBUILDFILES=1

BASEPATH=$( cd "$( dirname "$0" )" && pwd )

while [[ $1 == -* ]]; do
    case "$1" in
		-i|--installpath) if (($# > 1)); then
				INSTALLPATH=$2; shift 2
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;
		-n|--packagename) if (($# > 1)); then
				PACKAGENAME=$2; shift 2
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;
		-s|--keystorepath) if (($# > 1)); then
				KEYSTOREPATH=$2; shift 2
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;
		-a|--keystorealias) if (($# > 1)); then
				KEYSTOREALIAS=$2; shift 2
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;
		-p|--keystorepass) if (($# > 1)); then
				KEYSTOREPASS=$2; shift 2
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;
		--) shift; break;;
		-*) echo "invalid option: $1" 1>&2; exit 1;;
    esac
done

if [[ -z ${INSTALLPATH} || -z ${PACKAGENAME} || -z ${KEYSTOREPATH} || -z ${KEYSTOREALIAS} || -z ${KEYSTOREPASS} ]]; then
	echo "Usage: -i|--installpath installpath -n|--packagename name -s|--keystorepath path -a|--keystorealias alias -p|--keystorepass pass"
	exit 1
fi

DECOMPILEPATH="${INSTALLPATH%.*}"
UNSIGNEDPATH="${DECOMPILEPATH}-unsigned.apk"
SIGNEDPATH="${DECOMPILEPATH}-unaligned.apk"
ALIGNEDPATH="${DECOMPILEPATH}-aligned.apk"
FINALPATH="${DECOMPILEPATH}.apk"
PATH=$PATH:"${BASEPATH}";
export PATH;

echo "Script path: ${BASEPATH}"
# decompile
echo "Decompiling ${INSTALLPATH}..."
java -jar "${BASEPATH}/apktool.jar" d -s -f "${INSTALLPATH}" "${DECOMPILEPATH}"
if [ ${?} -eq 1 ]; then
	echo "Couldn't decompile file '${INSTALLPATH}'"
	exit 1;
fi
cp "${INSTALLPATH}" "${DECOMPILEPATH}-orig.apk"

# change package name
echo "Changing package name to ${PACKAGENAME}"
mv "${DECOMPILEPATH}/AndroidManifest.xml" "${DECOMPILEPATH}/AndroidManifest-bak.xml"
sed "s/postprocessor.replaces.this/${PACKAGENAME}/g" "${DECOMPILEPATH}/AndroidManifest-bak.xml" > "${DECOMPILEPATH}/AndroidManifest.xml"
rm -rf "${DECOMPILEPATH}/AndroidManifest-bak.xml"

# extract main activity
MAINACTIVITY=$(sed -n "s/.*\(com.*UnityPlayerProxyActivity\).*/\1/p" "${DECOMPILEPATH}/AndroidManifest.xml")
echo "Got main activity: ${MAINACTIVITY}"

PACKAGESED=$(sed -i old "s/\(package=\"\)[a-zA-Z0-9_.]*\"/\1${PACKAGENAME}\"/g" "${DECOMPILEPATH}/AndroidManifest.xml") 
rm -rf *old
# insert strings.xml
echo "Updating resources"
"${BASEPATH}/../node" "${BASEPATH}/updateResourcesjs" "${DECOMPILEPATH}" || exit 1

# repackage
echo "Compiling"
java -jar "${BASEPATH}/apktool.jar" b "${DECOMPILEPATH}" "${UNSIGNEDPATH}"
if [ ${?} -eq 1 ]; then
	echo "Couldn't compile to file '${UNSIGNEDPATH}'"
	exit 1;
fi

# copy original dest file, unzip modified copy, add file from modified copy to original copy
# need to cd to dir to make zip command work properly
TMPWD=${PWD}
cd "${INSTALLPATH%/*}"
cp "${INSTALLPATH}" "${DECOMPILEPATH}-new.apk"
rm "${INSTALLPATH}"
unzip "${UNSIGNEDPATH}" -d "${DECOMPILEPATH}-modified"
zip -j "${DECOMPILEPATH}-new.apk" "$(basename ${DECOMPILEPATH}-modified)/resources.arsc" "$(basename ${DECOMPILEPATH}-modified)/AndroidManifest.xml"
#cleanup tmp files - UNSIGNEDPATH will be overwritten
rm -rf "${DECOMPILEPATH}-modified"
rm -rf "${UNSIGNEDPATH}"
cd "${TMPWD}"

#open test package - see if strings were inserted
#java -jar "${BASEPATH}/apktool.jar" d -s -f "${DECOMPILEPATH}-new.apk" "${DECOMPILEPATH}-new"
#java -jar "${BASEPATH}/apktool.jar" d -s -f "${UNSIGNEDPATH}" "${UNSIGNEDPATH}-decomp"

# UNSIGNEDPATH is now the original INSTALLPATH with modified AndroidManifest.xml and resources.arsc
mv "${DECOMPILEPATH}-new.apk" "${UNSIGNEDPATH}"

# sign apk and verify
echo "Signing. Entering password is not required if it was added to config.json"
zip -d "${UNSIGNEDPATH}" META-INF*
eval KEYSTOREPATH="${KEYSTOREPATH}"
echo "${KEYSTOREPASS}" | jarsigner -sigalg MD5withRSA -digestalg SHA1 -keystore "${KEYSTOREPATH}" -keypass "${KEYSTOREPASS}" -signedjar "${SIGNEDPATH}" "${UNSIGNEDPATH}" "${KEYSTOREALIAS}"
if [ ${?} -eq 1 ]; then
	echo "Couldn't sign file '${UNSIGNEDPATH}'"
	exit 1;
fi
jarsigner -verify -certs "${SIGNEDPATH}"
if [ ${?} -eq 1 ]; then
	echo "Couldn't verify signed file '${SIGNEDPATH}'"
	exit 1;
fi

# zipalign
echo "Aligning"
"${BASEPATH}/zipalign" -v 4 "${SIGNEDPATH}" "${ALIGNEDPATH}"
if [ ${?} -eq 1 ]; then
	echo "Couldn't align file '${SIGNEDPATH}"
	exit 1;
fi

echo "Cleanup"
# overwrite unsigned, unaligned file
mv -f "${ALIGNEDPATH}" "${FINALPATH}"
if [ ${REMOVEBUILDFILES} -eq 1 ]; then
	rm -rf "${DECOMPILEPATH}"
	rm -rf "${UNSIGNEDPATH}"
	rm -rf "${SIGNEDPATH}"
fi

echo "Success!"
adb devices | grep "\bdevice\b"
if [ $? -eq 0 ]; then
	echo "Pushing to device..."
	adb install -r "${FINALPATH}"
	adb shell am start -n ${PACKAGENAME}/${MAINACTIVITY}
else
	echo "No devices found"
fi
