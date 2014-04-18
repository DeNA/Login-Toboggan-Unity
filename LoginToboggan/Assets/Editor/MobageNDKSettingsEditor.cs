using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using UnityEditor.Callbacks;

[CustomEditor(typeof(MobageSettings))]
public class MobageNDKSettingsEditor : Editor
{

	private static string workingPath = null;
	#if UNITY_EDITOR_OSX
	bool showKeyStoreSettings = true; // Enable this once I get jarsigner working
	#else
	bool showKeyStoreSettings = false;
	#endif
	bool showAndroidUtils = (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android);
	bool showIOSSettings = (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iPhone);

	// Android Labels
	GUIContent packageNameLabel = new GUIContent("Package Name", "Mobage Android Package Name can be found at http://developer.mobage.com");
	GUIContent keyStorePathLabel = new GUIContent("Key Store Path", "Key Store Path use to resign android builds");
	GUIContent keyStoreAliasLabel = new GUIContent("Key Store Alias", "Key Store alias used to resign android builds");
	GUIContent keyStorePassLabel = new GUIContent("Key Store Password", "Key Store Password used to resign android builds");
	GUIContent androidAdTrackingLabel = new GUIContent("Use Ad Tracking", "Mark to use Ad Tracking for Android");
	GUIContent androidAdTrackingFileLabel = new GUIContent("AdTracking config file", "Android resources file containing all the AdTracking configurations");
//	GUIContent androidMainActivityLabel = new GUIContent("Android Main Activity", "Android Main Activity to install and start signed android package");
	GUIContent androidAdTrackingJarsLabel = new GUIContent("Ad Tracking Jars Folder", "Folder location where all Ad Tracking jars should be copied to");
	// iOS Labels
	GUIContent bundleIDLabel = new GUIContent("Bundle ID", "Mobage iOS Bundle ID can be found at http://developer.mobage.com");
	GUIContent appIDLabel = new GUIContent("App ID", "Mobage App ID can be found at http://developer.mobage.com");
	GUIContent iosAdTrackingLabel = new GUIContent("Use Ad Tracking", "Mark to use Ad Tracking for iOS");
	//GUIContent plistExtrasLabel = new GUIContent("pList Extras", "Extra pList settings you want added to the Info.plist");
	GUIContent iosAdTrackingFrameworkFileLabel = new GUIContent("Ad Tracking Framework", "Location of Ad Tracking framework");
	GUIContent iosAdTrackingConfigFileLabel = new GUIContent("Ad Tracking Config", "Location of Ad Tracking config file");
	GUIContent iosConfigFolderLabel = new GUIContent("Config Folder", "Location of Settings.bundle and MobageNDK.entitlements");

	// Facebook Labels
	GUIContent facebookAppIDLabel = new GUIContent("Facebook App ID", "Facebook App ID Taken from Facebook Unity plugin if installed can you found at https://developers.facebook.com");
	GUIContent facebookDisplayNameLabel = new GUIContent("Facebook Display Name", "Facebook Display Name for iOS settings");
		
	GUIContent sdkVersionLabel = new GUIContent("SDK Version", "This is the Mobage NDK Unity version. ");

	private static MobageSettings instance;
	
	public override void OnInspectorGUI()
	{
		instance = (MobageSettings)target;

		FBParamsInitGUI();
		AndroidUtilGUI();
		IOSUtilGUI();
		AboutGUI();
	}
	
	private void AppIdGUI()
	{
		EditorGUILayout.HelpBox("1) Add the Facebook App Id(s) associated with this game", MessageType.None);
/*
 * if (MobageSettings.AppIds.Length == 0 || MobageSettings.AppIds[MobageSettings.SelectedAppIndex] == "0")
		{
			EditorGUILayout.HelpBox("Invalid App Id", MessageType.Error);
		}

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField(appNameLabel);
		EditorGUILayout.LabelField(appIdLabel);
		EditorGUILayout.EndHorizontal();
		for (int i = 0; i < MobageSettings.AppIds.Length; ++i)
		{
			EditorGUILayout.BeginHorizontal();
			MobageSettings.SetAppLabel(i, EditorGUILayout.TextField(MobageSettings.AppLabels[i]));
			GUI.changed = false;
			MobageSettings.SetAppId(i, EditorGUILayout.TextField(MobageSettings.AppIds[i]));
			EditorGUILayout.EndHorizontal();
		}

		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Add Another App Id"))
		{
			var appLabels = new List<string>(MobageSettings.AppLabels);
			appLabels.Add("New App");
			MobageSettings.AppLabels = appLabels.ToArray();
			
			var appIds = new List<string>(MobageSettings.AppIds);
			appIds.Add("0");
			MobageSettings.AppIds = appIds.ToArray();
		}
		if (MobageSettings.AppLabels.Length > 1)
		{
			if (GUILayout.Button("Remove Last App Id"))
			{
				var appLabels = new List<string>(MobageSettings.AppLabels);
				appLabels.RemoveAt(appLabels.Count - 1);
				MobageSettings.AppLabels = appLabels.ToArray();
				
				var appIds = new List<string>(MobageSettings.AppIds);
				appIds.RemoveAt(appIds.Count - 1);
				MobageSettings.AppIds = appIds.ToArray();
			}
		}

		EditorGUILayout.EndHorizontal();
		EditorGUILayout.Space();
		if (MobageSettings.AppIds.Length > 1)
		{
			EditorGUILayout.HelpBox("2) Select Facebook App Id to be compiled with this game", MessageType.None);
			GUI.changed = false;
			MobageSettings.SetAppIndex(EditorGUILayout.Popup("Selected App Id", MobageSettings.SelectedAppIndex, MobageSettings.AppLabels));
			if (GUI.changed)
				ManifestMod.GenerateManifest();
			EditorGUILayout.Space();
		}
		else
		{
			MobageSettings.SetAppIndex(0);
		}
		*/
	}
	
	private void FBParamsInitGUI()
	{
		EditorGUILayout.HelpBox("Facebook Settings", MessageType.None);
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField(facebookAppIDLabel, GUILayout.Width(135), GUILayout.Height(16));
		MobageSettings.FacebookAppID = EditorGUILayout.TextField(MobageSettings.FacebookAppID);
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField(facebookDisplayNameLabel, GUILayout.Width(135), GUILayout.Height(16));
		MobageSettings.FacebookDisplayName = EditorGUILayout.TextField(MobageSettings.FacebookDisplayName);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
		//System.Type fbType = System.Type.GetType("Facebook.FBSettings");
		try {
			System.Type fbType = System.Type.GetType("FBSettings, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
			if (fbType != null)
			{
				if (GUILayout.Button("Read Facebook Unity App ID"))
				{
					MethodInfo method = fbType.GetMethod("get_AppId");
					if (method != null)
					{
						var value = method.Invoke (null,null);
						if (value != null)
						{
							MobageSettings.FacebookAppID = (string)value;
						}
						else
						{
							UnityEngine.Debug.LogError("Facebook App ID Not Set in Facebook Unity Plugin");
						}
					} 
					else {
						UnityEngine.Debug.LogError("Facebook class cannot get AppId");
					}
				}
				if ("180566588646375".Equals(MobageSettings.FacebookAppID))
				{
					if (GUILayout.Button("Set Facebook Custom URL Scheme iOS"))
					{
						
						MethodInfo method = fbType.GetMethod("set_IosURLSuffix");
						if (method != null)
						{
							string urlScheme = MobageSettings.AppID;
							urlScheme = urlScheme.Replace("-","");
							urlScheme = urlScheme.ToLower();
							object[] parameters = {urlScheme};
							method.Invoke(null,parameters);
						}
					}
				}
			}
		} catch
		{
			UnityEngine.Debug.Log("No Unity Facebook Plugin installed cannot read App ID");
		}
	}
	
	private void IOSUtilGUI()
	{
		showIOSSettings = EditorGUILayout.Foldout(showIOSSettings, "iOS Build Settings");
		if (showIOSSettings)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(bundleIDLabel, GUILayout.Width(135), GUILayout.Height(16));
			MobageSettings.BundleID = EditorGUILayout.TextField(MobageSettings.BundleID);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(appIDLabel, GUILayout.Width(135), GUILayout.Height(16));
			MobageSettings.AppID = EditorGUILayout.TextField(MobageSettings.AppID);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(iosConfigFolderLabel, GUILayout.Width(135), GUILayout.Height(16));
			if (GUILayout.Button ("Browse"))
			{
				MobageSettings.IosConfigDirectory = EditorUtility.OpenFolderPanel("Browse for iOS config folder", MobageSettings.IosConfigDirectory != null ? Path.Combine (Application.dataPath,MobageSettings.IosConfigDirectory): Application.dataPath, "");
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.HelpBox(MobageSettings.IosConfigDirectory, MessageType.Info);

			EditorGUILayout.HelpBox("iOS Ad Tracking Settings", MessageType.None);
			EditorGUILayout.BeginHorizontal();
			MobageSettings.IosAdTracking = EditorGUILayout.Toggle(iosAdTrackingLabel,MobageSettings.IosAdTracking);
			EditorGUILayout.EndHorizontal();

			if (MobageSettings.IosAdTracking)
			{
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(iosAdTrackingFrameworkFileLabel,GUILayout.Width(135), GUILayout.Height(16));
				if (GUILayout.Button("Browse"))
				{
					MobageSettings.IosAdTrackingFrameworkFile = EditorUtility.OpenFilePanel("Browse for iOS Ad Tracking Config File", MobageSettings.IosAdTrackingFrameworkFile != null? Path.Combine (Application.dataPath,MobageSettings.IosAdTrackingFrameworkFile):Application.dataPath,"framework");
				}
				EditorGUILayout.EndHorizontal();

				if (MobageSettings.IosAdTrackingFrameworkFile != null)
				{
					EditorGUILayout.HelpBox(MobageSettings.IosAdTrackingFrameworkFile, MessageType.Info);
				}
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(iosAdTrackingConfigFileLabel,GUILayout.Width(135), GUILayout.Height(16));
				if (GUILayout.Button("Browse"))
				{
					MobageSettings.IosAdTrackingConfigFile = EditorUtility.OpenFilePanel("Browse for iOS Ad Tracking Framework", MobageSettings.IosAdTrackingConfigFile != null? Path.Combine (Application.dataPath,MobageSettings.IosAdTrackingConfigFile):Application.dataPath,"plist");
				}
				EditorGUILayout.EndHorizontal();

				if (MobageSettings.IosAdTrackingConfigFile != null)
				{
					EditorGUILayout.HelpBox(MobageSettings.IosAdTrackingConfigFile, MessageType.Info);
				}

			}
			
		}
		EditorGUILayout.Space();
	}

	public static void generateAndroidManifest() 
	{
		string plugins = Path.Combine (Application.dataPath,"Plugins");
		string android = Path.Combine(plugins,"Android");
		string manifest = Path.Combine (android,"AndroidManifest.xml");
		string res = Path.Combine (android,"res");
		string values = Path.Combine (res, "values");
		string mobagexml = Path.Combine(values,"mobage.xml");
		XMLParser manifestParser = new XMLParser(manifest);
		manifestParser.replaceAttributeValue("package","postprocessor.replaces.this", false, manifestParser.getRootNode());
		XmlNode receiverNode = manifestParser.findNode("receiver","android:name","com.mobage.global.android.c2dm.C2DMBaseReceiver",false,manifestParser.getRootNode());
		if (receiverNode != null)
		{
			XmlNode categoryNode = manifestParser.findNode ("category", "android:name", "*", false, receiverNode);
			manifestParser.replaceAttributeValue("android:name","postprocessor.replaces.this", true, categoryNode);
		}
		XmlNode permissionNode = manifestParser.findNode ("permission","android:name", "permission.C2D_MESSAGE", true, manifestParser.getRootNode());
		if (permissionNode != null)
		{
			manifestParser.replaceAttributeValue("android:name","postprocessor.replaces.this.permission.C2D_MESSAGE", true, permissionNode);
		}
		permissionNode = manifestParser.findNode ("uses-permission","android:name", "permission.C2D_MESSAGE", true, permissionNode.NextSibling);
		if (permissionNode == null)
		{
			permissionNode = manifestParser.findNode ("uses-permission","android:name", "permission.C2D_MESSAGE", true, manifestParser.getRootNode());
		}
		if (permissionNode != null)
		{
			manifestParser.replaceAttributeValue("android:name","postprocessor.replaces.this.permission.C2D_MESSAGE", true, permissionNode);
		}
		manifestParser.replaceString("postprocessor.replaces.this", MobageSettings.PackageName);
		manifestParser.saveXML();
		XMLParser resParser = new XMLParser(mobagexml);
		resParser.replaceElementValueforAttribute("name","facebookApplicationId",MobageSettings.FacebookAppID,false,resParser.getRootNode());
		resParser.saveXML();
		UnityEngine.Debug.Log ("AndroidManifest.xml updated");
	}
	
	private void AndroidUtilGUI()
	{
		showAndroidUtils = EditorGUILayout.Foldout(showAndroidUtils, "Android Build Settings");
		if (showAndroidUtils)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(packageNameLabel, GUILayout.Width(135), GUILayout.Height(16));
			MobageSettings.PackageName = EditorGUILayout.TextField(MobageSettings.PackageName);
			EditorGUILayout.EndHorizontal();

			/* Remove AndroidMainActivity subbing since not certain how to replace all values in MainActivity with the time constraint
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField (androidMainActivityLabel, GUILayout.Width (135), GUILayout.Height(16));
			MobageSettings.AndroidMainActivity = EditorGUILayout.TextField(MobageSettings.AndroidMainActivity);
			EditorGUILayout.EndHorizontal();
			*/
			if (GUILayout.Button ("Regenerate AndroidManifest file"))
			{
				generateAndroidManifest();
			}

			EditorGUILayout.HelpBox("Android Ad Tracking Settings", MessageType.None);
			EditorGUILayout.BeginHorizontal();
			MobageSettings.AndroidAdTracking = EditorGUILayout.Toggle(androidAdTrackingLabel, MobageSettings.AndroidAdTracking);
			EditorGUILayout.EndHorizontal();
			if (MobageSettings.AndroidAdTracking)
			{
				string plugins = Path.Combine(Application.dataPath,"Plugins");
				string android = Path.Combine (plugins, "Android");
				EditorGUILayout.HelpBox ("Please place all AdTracking jars into: " + android,MessageType.Error);
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(androidAdTrackingJarsLabel, GUILayout.Width(135), GUILayout.Height(16));
				if (GUILayout.Button ("Show"))
				{
					OpenInFileBrowser.Open (android);
				}
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(androidAdTrackingFileLabel,GUILayout.Width(135), GUILayout.Height(16));
				if (GUILayout.Button ("Browse"))
				{
					MobageSettings.AndroidAdTrackingFile = EditorUtility.OpenFilePanel("Browse for Android Ad Tracking Config File", MobageSettings.AndroidAdTrackingFile != null? Path.Combine (Application.dataPath,MobageSettings.AndroidAdTrackingFile):Application.dataPath,"xml");
				}
				EditorGUILayout.EndHorizontal();

				if (MobageSettings.AndroidAdTrackingFile != null)
				{
					EditorGUILayout.HelpBox(MobageSettings.AndroidAdTrackingFile, MessageType.Info);
				}
			}

			if (showKeyStoreSettings)
			{
				EditorGUILayout.HelpBox ("Android Key Store Build Settings", MessageType.None);

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(keyStoreAliasLabel, GUILayout.Width(135), GUILayout.Height(16));
				MobageSettings.KeyStoreAlias = EditorGUILayout.TextField(MobageSettings.KeyStoreAlias);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(keyStorePassLabel, GUILayout.Width(135), GUILayout.Height(16));
				MobageSettings.KeyStorePass = EditorGUILayout.PasswordField(MobageSettings.KeyStorePass, GUILayout.Width(180), GUILayout.Height(16));
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(keyStorePathLabel,GUILayout.Width(135), GUILayout.Height(16));
				if (GUILayout.Button("Browse"))
				{
					MobageSettings.KeyStorePath= EditorUtility.OpenFilePanel("Browse for Android Keystore", MobageSettings.KeyStorePath != null? Path.Combine (Application.dataPath,MobageSettings.KeyStorePath):Application.dataPath,"keystore");
				}
				EditorGUILayout.EndHorizontal();
				
				if (MobageSettings.KeyStorePath != null)
				{
					EditorGUILayout.HelpBox(MobageSettings.KeyStorePath,MessageType.Info);
				}
			}

//			EditorGUILayout.HelpBox("Copy and Paste these into your \"Native Android App\" Settings on developers.facebook.com/apps", MessageType.None);
//			SelectableLabelField(packageNameLabel, PlayerSettings.bundleIdentifier);
//			SelectableLabelField(classNameLabel, ManifestMod.ActivityName);
//			SelectableLabelField(debugAndroidKeyLabel, FacebookAndroidUtil.DebugKeyHash);
			
		}
		EditorGUILayout.Space();
	}
	
	private void AboutGUI()
	{
//		var versionAttribute = FBBuildVersionAttribute.GetVersionAttributeOfType(typeof(IFacebook));
		EditorGUILayout.HelpBox("About the Mobage SDK", MessageType.None);
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField(sdkVersionLabel, GUILayout.Width(135), GUILayout.Height(16));
		EditorGUILayout.SelectableLabel(MobageSettings.Version);
		EditorGUILayout.EndHorizontal();

//		SelectableLabelField(buildVersion, versionAttribute.ToString());
		EditorGUILayout.Space();
	}

	public delegate void runProcessDelegate(string result, int status);

	private static void runProcess(string filename, string arguments, runProcessDelegate onComplete)
	{
		UnityEngine.Debug.Log(filename + " " + arguments);
		var proc = new Process();
		proc.StartInfo.FileName = filename;
		proc.StartInfo.Arguments = arguments;
		proc.StartInfo.UseShellExecute = false;
		proc.StartInfo.CreateNoWindow = true;
		proc.StartInfo.RedirectStandardOutput = true;
		proc.StartInfo.WorkingDirectory = workingPath;
		proc.StartInfo.RedirectStandardOutput = true;
		proc.StartInfo.RedirectStandardError = true;
		int timeout = 10000;

		StringBuilder output = new StringBuilder();
		StringBuilder error = new StringBuilder();
		
		using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
		using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
		{
			proc.OutputDataReceived += (sender, e) => {
				if (e.Data == null)
				{
					outputWaitHandle.Set();
				}
				else
				{
					output.AppendLine(e.Data);
				}
			};
			proc.ErrorDataReceived += (sender, e) =>
			{
				if (e.Data == null)
				{
					errorWaitHandle.Set();
				}
				else
				{
					error.AppendLine(e.Data);
				}
			};
			
			proc.Start();
			
			proc.BeginOutputReadLine();
			proc.BeginErrorReadLine();
			
			if (proc.WaitForExit(timeout) &&
			    outputWaitHandle.WaitOne(timeout) &&
			    errorWaitHandle.WaitOne(timeout))
			{
				// Process completed. Check process.ExitCode here.

				UnityEngine.Debug.LogWarning ("Process Error: " + error.ToString());
				UnityEngine.Debug.Log("Process Output: " + output.ToString());
				onComplete(output.ToString(), proc.ExitCode);
			}
			else
			{
				// Timed out.
				UnityEngine.Debug.LogError ("Process timed out");
				onComplete(output.ToString(), 1);
			}
		}

	}
		
	private static void adbInstall(string path) 
	{
		instance.GetInstanceID();
		string script = @"-c ""adb devices""";
		runProcess("bash", script, (adbResult, adbStatus) => {
			if (adbStatus == 0 && adbResult != null )
			{
				Match match = Regex.Match(adbResult,"\bdevice\b");
				if (match.Success)
				{
					script = @"install -r ""{0}""";
					runProcess("adb", string.Format(script,path), (installResult, installStatus) => {
						if (installStatus == 0)
						{
							runProcess ("adb", string.Format("shell am start -n {0}/{1}",MobageSettings.PackageName,MobageSettings.AndroidMainActivity), 
							            (startResult, startStatus) => {
								if (startStatus > 0)
								{
									UnityEngine.Debug.LogWarning("Cannot start: " + MobageSettings.PackageName + ":" + MobageSettings.AndroidMainActivity);
								}
							});
						} 
						else {
							UnityEngine.Debug.LogWarning("Cannot install apk: " + path);
						}
						
					});
					
				}
			}
		});
	}

	// Should be PostProcessBuild(200) but facebook doesn't process the pbxproj correctly
	[PostProcessBuild]
	public static void OnPostProcessBuild(BuildTarget target, string path)
	{
		string mobageNDK = Path.Combine (Application.dataPath,"MobageNDK");
		string mobageNDKBundle = Path.Combine(mobageNDK, "MobageNDK.bundle");

		if (target == BuildTarget.iPhone)
		{
			workingPath = path;
			string outputNDKFramework = Path.Combine(path,"MobageNDK.framework");
			FileUtil.DeleteFileOrDirectory(outputNDKFramework);
			string ios = Path.Combine (mobageNDKBundle, "iOS");
			string mobageNDKFramework = Path.Combine(ios,"MobageNDK.framework");
			FileUtil.CopyFileOrDirectory(mobageNDKFramework,outputNDKFramework);
			if (MobageSettings.IosConfigDirectory != null)
			{
				string iosConfigDir = Path.Combine (Application.dataPath,MobageSettings.IosConfigDirectory);
				string entitlements = Path.Combine(iosConfigDir,"MobageNDK.entitlements");
				XMLParser iosEntitlements = new XMLParser(entitlements);
				iosEntitlements.replaceString("postprocessor.replaces.this",MobageSettings.BundleID);
				string resources = Path.Combine (path,"Resources");
				if (!Directory.Exists(resources))
				{
					Directory.CreateDirectory(resources);
				}
				string outputEntitlements = Path.Combine(resources,"MobageNDK.entitlements");
				if (File.Exists(outputEntitlements))
				{
					File.Delete(outputEntitlements);
				}
				iosEntitlements.saveXMLToFile(outputEntitlements);
				System.IO.StreamReader reader = new System.IO.StreamReader(outputEntitlements);
				string mobageEntitlements = reader.ReadToEnd();
				reader.Close();
				
				mobageEntitlements = mobageEntitlements.Replace("[]>",">");

				System.IO.StreamWriter writer = new System.IO.StreamWriter(outputEntitlements, false);
				writer.Write(mobageEntitlements);
				writer.Close();
				string settings = Path.Combine(iosConfigDir,"Settings.bundle");
				string outputSettings = Path.Combine (resources,"Settings.bundle");
				if (Directory.Exists(outputSettings))
				{
					Directory.Delete(outputSettings,true);
				}
				FileUtil.CopyFileOrDirectory(settings,outputSettings);
			}
			else {
				UnityEngine.Debug.LogWarning("No MobageNDK config set can't copy MobageNDK.entitlements or Settings.bundle");
			}

			if (MobageSettings.IosAdTracking)
			{
				string iosAdTrackingFramework = Path.Combine(path,"MobageAdTracking.framework");
				FileUtil.DeleteFileOrDirectory(iosAdTrackingFramework);
				if (MobageSettings.IosAdTrackingFrameworkFile != null)
				{
					FileUtil.CopyFileOrDirectory(Path.Combine(Application.dataPath,MobageSettings.IosAdTrackingFrameworkFile),iosAdTrackingFramework);
				}
				else {
					UnityEngine.Debug.LogError ("Unable to Located MobageAdTracking.framework but Use Ad Tracking framework is enabled");
				}
				string iosAdTrackingConfig = Path.Combine(path,"MBAdTracking.plist");
				FileUtil.DeleteFileOrDirectory(iosAdTrackingConfig);
				if (MobageSettings.IosAdTrackingConfigFile != null)
				{
					FileUtil.CopyFileOrDirectory(Path.Combine(Application.dataPath,MobageSettings.IosAdTrackingConfigFile),iosAdTrackingConfig);
				}
				else {
					UnityEngine.Debug.LogError ("Unable to Located MBAdTracking.plist but Use Ad Tracking framework is enabled");
				}
			}

			string facebookJSON= @"""useFacebookFramework"":false, ""FacebookAppID"":""{0}"",""FacebookDisplayName"":""{1}""";

			string fbJson = "";
			var arguments = @"'{0}' -p '{1}' -v {2} --bundleID {3} -a {4} {5} {6} {7}";

			string tools = Path.Combine (mobageNDKBundle,"Tools");
			string iosTools = Path.Combine(tools, "ios");
			string python = Path.Combine (iosTools, "mobage_patchxcodeproj.py");

			string xcodeproj = Path.Combine (path, "Unity-iPhone.xcodeproj");
			string dwarf = "";

			string installTracking = "";
			if (MobageSettings.DWARF)
			{
				dwarf = "-d";
			}

			if (MobageSettings.IosAdTracking)
			{
				installTracking = "-t";
			}

			//Should put back once facebook fixes there postprocessing shiet
			System.Type fbType = System.Type.GetType("FBSettings, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
			if (fbType == null)
			{
				fbJson = "-f '{" + string.Format (facebookJSON, MobageSettings.FacebookAppID, MobageSettings.FacebookDisplayName) + "}'";
			} 

			string script = string.Format(arguments,python,xcodeproj,Application.unityVersion, MobageSettings.BundleID, MobageSettings.AppID,fbJson,installTracking, dwarf);

			runProcess("python", script, (result, status) => {
				if (status == 0)
				{
					UnityEngine.Debug.Log ("iOS postprocessing successful");
				}
				else {
					UnityEngine.Debug.LogError("iOS postprocessing failed!" + result);
				}
			});
		}
		if (target == BuildTarget.Android)
		{
			string dir = Path.GetDirectoryName(path);
			string filename = Path.GetFileName(path);
			workingPath = dir;
			string output;
			string signed;
			string unsigned;
			if (filename != null)
			{

				string outputFile = filename.Replace(".apk","-orig.apk");  
				string signedFile = filename.Replace (".apk", "-signed.apk");
				string unsignedFile = filename.Replace (".apk", "-unsigned.apk");
				output = Path.Combine (dir,outputFile);
				signed = Path.Combine (dir,signedFile);
				unsigned = Path.Combine (dir,unsignedFile);
				FileUtil.DeleteFileOrDirectory(output);
				FileUtil.DeleteFileOrDirectory(signed);
				FileUtil.DeleteFileOrDirectory(unsigned);
				FileUtil.CopyFileOrDirectory(path,unsigned);
				FileUtil.MoveFileOrDirectory(path,output);

			} else {
				UnityEngine.Debug.LogError("PostProcess[MobageNDK] failed Unable to get FileName of Path");
				return;
			}
			if (Application.platform == RuntimePlatform.OSXEditor)
			{
				if (MobageSettings.KeyStorePath != null)
				{

					var delete = @"-d ""{0}"" META-INF*";
					runProcess("zip", string.Format(delete,unsigned), (AssetDeleteResult, deleteStatus) => {
						if (deleteStatus == 0)
						{
							var script = @"-c ""echo {5} | jarsigner -sigalg MD5withRSA -digestalg SHA1 -keystore '{0}' -keypass '{1}' -signedjar '{2}' '{3}' '{4}' """;
							var arguments =  string.Format(script,Path.Combine(Application.dataPath,MobageSettings.KeyStorePath),MobageSettings.KeyStorePass,signed,unsigned,MobageSettings.KeyStoreAlias,MobageSettings.KeyStorePass);
							var filenameCmd = "bash";
							runProcess(filenameCmd,arguments, (result, status) => {
								if (status == 0)
								{
									FileUtil.DeleteFileOrDirectory(unsigned);
									script = @"-verify -certs ""{0}"" ";
									arguments = string.Format(script,signed);
									runProcess ("jarsigner", arguments, (signerResult, signerStatus) => {
										if (signerStatus == 0)
										{
											script = @"-c ""zipalign -v 4 '{0}' '{1}'""";
											arguments = string.Format(script,signed,path);

											runProcess ("bash", arguments, (zipAlignResult, zipAlignStatus) => {
												if (zipAlignStatus == 0)
												{
													// Disable any adb install at this time
													//adbInstall(path);
													FileUtil.DeleteFileOrDirectory(signed);
												} 
												else {
													script = @"-c ""'{0}' -v 4 '{1}' '{2}'""";
													string tools = Path.Combine(mobageNDKBundle,"Tools");
													string android = Path.Combine (tools, "android");
													string zipalign = Path.Combine (android,"zipalign");
													arguments = string.Format (script,zipalign,signed,path);
													runProcess ("bash", arguments, (zipAlignResult2, zipAlignStatus2) => {
														if (zipAlignStatus2 == 0)
														{
															// Disable any adb install at this time
															// adbInstall(path);
															FileUtil.DeleteFileOrDirectory(signed);
														} 
														else {
															UnityEngine.Debug.LogWarning("Could not zipalign apk");
														}
													});
												}

											});
										}
										else {
											UnityEngine.Debug.LogWarning("Could not resign apk");
										}
									});
								}
							});
						}
						else {
							UnityEngine.Debug.LogWarning("Could not delete META-INF from apk");
						}
					});
				} 
				else {
					UnityEngine.Debug.LogWarning("Key Store Path Not set Not resigning");
				}
			}
		}
	}


}