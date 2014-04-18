#!/bin/sh
#
# mobage_postprocess.py
# Copyright 2012, DeNA Co., Ltd. All rights reserved
#
# Execute with Working Directory set to the root of your Unity project.
# first argument: the path to the Root of the Output folder
# second argument: Install tracking argument
# third argument: Unity version

BASEPATH=$( cd "$( dirname "$0" )" && pwd )

TPWD="${PWD}"
plistExtrasJSON=""

while [[ $1 == -* ]]; do
    case "$1" in
		-i|--installpath) if (($# > 1)); then
				INSTALLPATH=$2; shift 2
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;
		-t|--installtracking) INSTALLTRACKING=$1; shift;;
		-f|--facebook) if (($# > 1)); then
				FACEBOOKJSON=$2; shift 2
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;		
		-b) if (($# > 1)); then
				BUNDLEID=$2; shift 2
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;
		-a|--appID) if (($# > 1)); then
						APPID=$2; shift 2				
					else
						echo "$1 requires an argument" 1>&2
						exit 1
					fi ;;
		-u|--unityversion) if (($# > 1)); then
				UNITYVERSION=$2; shift 2
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;
		-e) if (($# > 1)); then
				plistExtrasJSON=$2; shift 2	
				if [ ! -z ${plistExtrasJSON} ]; then
					plistExtrasJSON="-e  ${plistExtrasJSON}"
				fi			
			else
				echo "$1 requires an argument" 1>&2
				exit 1
			fi ;;
		--) shift; break;;
		-*) echo "invalid option: $1" 1>&2; exit 1;;
    esac
done

if [[ -z "${INSTALLPATH}" || -z ${UNITYVERSION} ]]; then
	echo "Usage: -i|--installpath installpath -u|--unityversion version [-t|--installtracking]"
	exit 1
fi

echo "Install Path: '${INSTALLPATH}'"
# cd to MobageNDK folder ('config' parent)
echo ${BASEPATH}
cd "${BASEPATH}/../"
rm -rf "${INSTALLPATH}/MobageNDK.framework"
MOBAGENDKPATH="${BASEPATH}/../../../../../MobageNDK"
cp -R "${BASEPATH}/../../iOS/MobageNDK.framework" "${INSTALLPATH}"

if [ -d "${INSTALLPATH}/Resources/" ]; then
	echo ${INSTALLPATH}/Resources exists
else
	mkdir "${INSTALLPATH}/Resources"
fi

if [ -f "${INSTALLPATH}/Resources/MobageNDK.entitlements" ]; then
	rm -rf "${INSTALLPATH}/Resources/MobageNDK.entitlements"
fi

cp -R "${MOBAGENDKPATH}/iOS/Settings.bundle" "${INSTALLPATH}/Resources"
cp -R "${MOBAGENDKPATH}/iOS/MobageNDK.entitlements" "${INSTALLPATH}/Resources"
sed -i old "s/postprocessor.replaces.this/${BUNDLEID}/g" "${INSTALLPATH}/Resources/MobageNDK.entitlements"
rm -rf "${INSTALLPATH}/Resources/*old"

if [ ! -z ${FACEBOOKJSON} ]; then
	echo "Copy Facebook"
#	Removed since facebookSDK is no longer required for NDK
#   if [ -d "${BASEPATH}/../../iOS/FacebookSDK.framework" ]; then
#		echo "Facebook Framework found"
#		rm -rf ${INSTALLPATH}/FacebookSDK.framework
#		cp -R "${BASEPATH}/../../iOS/FacebookSDK.framework" ${INSTALLPATH}
#		echo "Facebook Framework copied"
#	else
#		echo "Facebook Framework required but file missing please place into MobageNDK/iOS"
#		exit 1
#	fi
fi

if [ ! -z ${INSTALLTRACKING} ]; then
	echo "Copying ad library"
	if [ -d "${MOBAGENDKPATH}/iOS/MobageAdTracking.framework" ]; then
		rm -rf "${INSTALLPATH}/MobageAdTracking.framework"
		cp -R "${MOBAGENDKPATH}/iOS/MobageAdTracking.framework" "${INSTALLPATH}"
		cp "${MOBAGENDKPATH}/config/ios/MBAdTracking.plist" "${INSTALLPATH}"
	else
		if [ -d  "${MOBAGENDKPATH}/iOS/MobageInstallTracking.framework" ]; then
			rm -rf "${INSTALLPATH}/MobageInstallTracking.framework"
			cp -R "${MOBAGENDKPATH}/iOS/MobageInstallTracking.framework" "${INSTALLPATH}"
			cp "${MOBAGENDKPATH}/config/ios/MBInstallTracking.plist" "${INSTALLPATH}"
		else
			echo "Couldn't find ad tracking library, but ad tracking was selected"
			exit 1
		fi
	fi
fi

# cd back just in case
cd ${TPWD}

echo "Updating project"
echo "${BASEPATH}/mobage_patchxcodeproj.py -p ${INSTALLPATH}/Unity-iPhone.xcodeproj -v ${UNITYVERSION} --bundleID ${BUNDLEID} -a ${APPID} -f ${FACEBOOKJSON} ${plistExtrasJSON} ${INSTALLTRACKING}"
if [ ! -z ${FACEBOOKJSON} ]; then
	python "${BASEPATH}/mobage_patchxcodeproj.py" -p "${INSTALLPATH}/Unity-iPhone.xcodeproj" -v ${UNITYVERSION} --bundleID ${BUNDLEID} -a ${APPID} -f ${FACEBOOKJSON} ${plistExtrasJSON} ${INSTALLTRACKING}
else
	python "${BASEPATH}/mobage_patchxcodeproj.py" -p "${INSTALLPATH}/Unity-iPhone.xcodeproj" -v ${UNITYVERSION} --bundleID ${BUNDLEID} -a ${APPID} ${plistExtrasJSON} ${INSTALLTRACKING}		
fi


echo "Changing package name"
exit $?
#"${BASEPATH}/../node" "${BASEPATH}/updateResources.js" "${INSTALLPATH}"