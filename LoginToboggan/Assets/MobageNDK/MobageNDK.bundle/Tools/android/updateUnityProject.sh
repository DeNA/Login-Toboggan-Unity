while getopts P:F:R option
	do
	        case "${option}"
	        in
	                P) WORKSPACE=${OPTARG};;
					F) FRAMEWORK_DIR=${OPTARG};;	
	        esac
	done

	
if [ -d "$WORKSPACE" ]; then
	if [ -d "$FRAMEWORK_DIR" ]; then
		if [ -d "$FRAMEWORK_DIR/Unity" ]; then
			cp -ir "$FRAMEWORK_DIR/Unity/" "$WORKSPACE/"
		else
			echo "Please point to the root directory of framework."
			echo "Framework Name"
			echo "-${Region} <-- Full Path to this location"
			echo "--Unity (This is where all the Unity files are copied into your project)"
			echo "--Documentation"
			echo "--MobageResources"
			echo "--..."
		fi
	else
		echo "FRAMEWORK_DIRECTORY not Found"
		echo "Usage sh updateUnityProject.sh -P ${Unity Project location} -F ${New Framework Location}"	
	fi
else
	echo "Usage sh updateUnityProject.sh -P ${Unity Project location} -F ${New Framework Location}"	
fi