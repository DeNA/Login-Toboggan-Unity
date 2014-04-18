while getopts D:I:S:P:O:U: option
do
        case "${option}"
        in
                D) eval WORKSPACE=${OPTARG};;
				I) eval INSTALL_DIR=${OPTARG};;
				S) eval SDK_DIR=${OPTARG};;
				P) eval PACKAGE_DIR=${OPTARG}
				   CREATEPACKAGE=true;;
				U) eval UNITY_APP=${OPTARG};;
				O) ONLYPACKAGE=true;;
        esac
done

echo "$WORKSPACE $INSTALL_DIR $SDK_DIR"

if [ ! -n "$WORKSPACE" ]; then
	cat installFacebook.README
	echo "WORKSPACE $WORKSPACE not found"
	exit 1
fi

if [ ! -n "$INSTALL_DIR" ]; then
	cat installFacebook.README
	echo "Install Directory $INSTALL_DIR not found"	
	exit 1
fi	

if [ ! -n "$SDK_DIR" ]; then
	cat installFacebook.README
	echo "SDK Directory $SDK_DIR not found"
	exit 1
fi

if [ ! -d "$SDK_DIR" ]; then
	cat installFacebook.README
	echo "SDK Directory $SDK_DIR not found"
	exit 1
fi	

if [ -d $WORKSPACE ]; then
	if [ -d $INSTALL_DIR ]; then
		echo "cp files to cp -r $WORKSPACE/res/ $INSTALL_DIR/Assets/Plugins/Android/res/facebook/"
		if [ -d "$INSTALL_DIR/Assets/Plugins/Android/res/facebook/" ]; then
			rm -rf $INSTALL_DIR/Assets/Plugins/Android/res/facebook/
		fi
		if [ ! -d "$INSTALL_DIR/Assets/Plugins/Android/res/" ]; then
			echo "mkdir $INSTALL_DIR/Assets/Plugins/Android/res"
			mkdir $INSTALL_DIR/Assets/Plugins/Android/res/
		fi
				
		if [ ! -d $INSTALL_DIR/MobageNDK/Android/ ]; then
			mkdir $INSTALL_DIR/MobageNDK/Android/
		fi
		if [ -d $INSTALL_DIR/MobageNDK/Android/ ]; then
			if [ -d $INSTALL_DIR/MobageNDK/Android/mobageFacebook ]; then
				rm -rf $INSTALL_DIR/MobageNDK/Android/mobageFacebook
			fi
			mkdir $INSTALL_DIR/MobageNDK/Android/mobageFacebook
			cp -r $WORKSPACE/ $INSTALL_DIR/MobageNDK/Android/mobageFacebook/
			cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/src ; find . -name "*.java" | while read filename; do if grep -q "com.facebook.android.R" ${filename}; then sed -i old s/com.facebook.android.R/com.facebook.MobageFacebookResources/g ${filename} 
			sed -i old 's/\([ (,]\)R\./\1MobageFacebookResources\./g' ${filename}; 
			sed -i old 's/\(MobageFacebookResources\.[a-z]*\)\./\1("/g' ${filename}; 
			sed -i old 's/\(MobageFacebookResources\.[a-z]*("[a-z_]*\)/\1")/g' ${filename}; 
			sed -i old 's/\(obtainStyledAttributes([a-z]*,\)\([ ]*\)\(MobageFacebookResources\.[a-z]*("[a-z_]*")\)/\1\2MobageFacebookResources\.convertToArray(\3)/g' ${filename};
			echo "/** This file has been modified by DeNA Co., Ltd. */\n" > ${filename}_copyright
			cat ${filename} >> ${filename}_copyright
			mv ${filename}_copyright ${filename}
			rm ${filename}old
			fi done 
			find . -name "WebDialog.java" | while read filename; do 
			sed -i old 's/\([ (,]\)R\./\1MobageFacebookResources\./g' ${filename}; 
			sed -i old 's/\(MobageFacebookResources\.[a-z]*\)\./\1("/g' ${filename}; 
			sed -i old 's/\(MobageFacebookResources\.[a-z]*("[a-z_]*\)/\1")/g' ${filename}; 
			sed -i old 's/\(obtainStyledAttributes([a-z]*,\)\([ ]*\)\(MobageFacebookResources\.[a-z]*("[a-z_]*")\)/\1\2MobageFacebookResources\.convertToArray(\3)/g' ${filename};
			echo "/** This file has been modified by DeNA Co., Ltd. */\n" > ${filename}_copyright
			cat ${filename} >> ${filename}_copyright
			mv ${filename}_copyright ${filename}
			rm ${filename}old
			done
			mkdir $INSTALL_DIR/MobageNDK/Android/mobageFacebook/src/com/facebook
			cp -r $INSTALL_DIR/MobageNDK/Tools/android/MobageFacebookResources.java $INSTALL_DIR/MobageNDK/Android/mobageFacebook/src/com/facebook
			
			cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/values ; ls *.xml| xargs -I {} mv {} facebook_{}
			cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/ ; find . -name "values*" -type d | while read dir; do cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/${dir}; ls strings.xml | xargs -I {} mv {} facebook_{}; done
			echo "$INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/ $INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/"
			
			cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook ; ant -Dsdk.dir=$SDK_DIR clean release 
			cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/bin ; mv classes.jar facebook.jar
			
			if [ ! $ONLYPACKAGE ]; then
				if [ -f $INSTALL_DIR/Assets/Plugins/Android/facebook.jar ]; then
					rm $INSTALL_DIR/Assets/Plugins/Android/facebook.jar
				fi
				cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/bin ; cp -r facebook.jar $INSTALL_DIR/Assets/Plugins/Android
				cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/libs/ ; cp -r *.jar $INSTALL_DIR/Assets/Plugins/Android
				echo "cp -iR $INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/drawable* $INSTALL_DIR/Assets/Plugins/Android/res/"
				cp -fR $INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/drawable* $INSTALL_DIR/Assets/Plugins/Android/res/
				echo "cp -iR $INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/layout* $INSTALL_DIR/Assets/Plugins/Android/res/"
				cp -fR $INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/layout* $INSTALL_DIR/Assets/Plugins/Android/res/
				cp -fR $INSTALL_DIR/MobageNDK/Android/mobageFacebook/res/values* $INSTALL_DIR/Assets/Plugins/Android/res/
			fi
			if [ $CREATEPACKAGE ]; then
				echo "CREATE PACKAGE $CREATEPACKAGE"
				if [ -d "$PACKAGE_DIR/" ]; then
					rm $PACKAGE_DIR
				fi
				mkdir $PACKAGE_DIR
				if [ ! -d "$PACKAGE_DIR/Assets/" ]; then
					mkdir $PACKAGE_DIR/Assets
				fi
				if [ ! -d "$PACKAGE_DIR/Assets/Plugins" ]; then
					mkdir $PACKAGE_DIR/Assets/Plugins
				fi
				if [ ! -d "$PACKAGE_DIR/Assets/Plugins/Android" ]; then
					mkdir $PACKAGE_DIR/Assets/Plugins/Android
				fi
				if [ ! -d "$PACKAGE_DIR/Assets/Plugins/Android/res/" ]; then
					mkdir $PACKAGE_DIR/Assets/Plugins/Android/res/
				fi
				cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/bin ; cp -r facebook.jar $PACKAGE_DIR/Assets/Plugins/Android
				cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/libs/ ; cp -r *.jar $PACKAGE_DIR/Assets/Plugins/Android
				cd $INSTALL_DIR/MobageNDK/Android/mobageFacebook/ ; cp -R res/ $PACKAGE_DIR/Assets/Plugins/Android/res
				if [ -x ${UNITY_APP} ]; then
					${UNITY_APP} -projectPath ${PACKAGE_DIR} -batchmode -quit -exportPackage Assets/Plugins/Android ${PACKAGE_DIR}/mobage-ndk-facebook.unitypackage
					rm -rf ${PACKAGE_DIR}/Library
					rm -rf ${PACKAGE_DIR}/ProjectSettings 
				fi
			fi
			
		else
			echo "MobageNDK not found in your root project please install this first"
			exit 1
		fi

		
	else
		cat installFacebook.README
		echo "(Install_DIR) Unity project location"	
	fi
else
	cat installFacebook.README
	echo "Facebook Directory not found please pass in the right parameters -D Facebook project directory"
	
fi