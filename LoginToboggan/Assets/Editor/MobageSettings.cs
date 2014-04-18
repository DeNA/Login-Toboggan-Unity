//
// MobageSettings.cs
// Copyright 2012, DeNA Co., Ltd. All rights reserved
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[InitializeOnLoad]
#endif

public class MobageSettings : ScriptableObject
{
	enum Platform { Unknown = 0, iOSDevice, iOSSimulator, AndroidDevice, AndroidEmulator };

	const string mobageSettingsAssetName = "MobageSettings";
	const string mobageSettingsPath = "MobageNDK/Resources";
	const string mobageSettingsAssetExtension = ".asset";

	//Facebook Settings
	[SerializeField]
	private string facebookAppID;
	[SerializeField]
	private string facebookDisplayName;

	//Android Settings
	[SerializeField]
	private string packageName;
	[SerializeField]
	private string keyStorePath;
	[SerializeField]
	private string keyStoreAlias;
	[SerializeField]
	private string keyStorePass;
	[SerializeField]
	private bool androidAdTracking;
	[SerializeField]
	private string androidAdTrackingFile;
	[SerializeField]
	private string androidMainActivity;

	//iOS Settings
	[SerializeField]
	private string bundleID;
	[SerializeField]
	private string appID;
	//private List<string> plistExtras = new List<string>();
	[SerializeField]
	private bool iosAdTracking;
	[SerializeField]
	private string iosConfigDirectory;
	[SerializeField]
	private string iosAdTrackingConfigFile;
	[SerializeField]
	private string iosAdTrackingFrameworkFile;


	[SerializeField]
	private string version; 

	private static MobageSettings instance;

#if UNITY_EDITOR	
	static MobageSettings()
	{
		instance = Instance;
		// Run Initialially to handle situation that it's not a changedPlatform but launched from this platform
		OnChangedPlatform();
		EditorUserBuildSettings.activeBuildTargetChanged += OnChangedPlatform;
	}
#endif

	static void OnChangedPlatform() 
	{
		if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iPhone)
		{
			PlayerSettings.bundleIdentifier = BundleID;
		}
		else {
			PlayerSettings.bundleIdentifier = PackageName;
		}
	}

	static MobageSettings Instance
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load(mobageSettingsAssetName) as MobageSettings;
				if (instance == null)
				{
					// If not found, autocreate the asset object.
					instance = CreateInstance<MobageSettings>();
					#if UNITY_EDITOR
					string properPath = Path.Combine(Application.dataPath, mobageSettingsPath);
					if (!Directory.Exists(properPath))
					{
						AssetDatabase.CreateFolder("Assets/MobageNDK", "Resources");
					}
					
					string fullPath = Path.Combine(Path.Combine("Assets", mobageSettingsPath),
					                               mobageSettingsAssetName + mobageSettingsAssetExtension
					                               );
					AssetDatabase.CreateAsset(instance, fullPath);
					#endif
				}
				instance.version = null;
			}
			return instance;
		}
	}

	[MenuItem ("Mobage/MobageNDK Build Settings", false, 0)]
	public static void showNDKSettings() 
	{
		Selection.activeObject = Instance;
	}
	
	[MenuItem ("Mobage/Documentation", false, 100)]
	public static void showDocumentation()
	{
		Application.OpenURL ("https://developer.mobage.com/en/resources?set_sdk=native");
	}

	public static bool DWARF
	{
		get {
			return true;
		}
	}

	public static string FacebookAppID
	{
		get { 
			string fbAppId = "180566588646375";
			if (Instance.facebookAppID != null && Instance.facebookAppID.Length > 0)
			{
				fbAppId = Instance.facebookAppID;
			}
			else {
				Instance.facebookAppID = fbAppId;
			}
			return Instance.facebookAppID;

		}
		set {
			Instance.facebookAppID = value;
			DirtyEditor();
		}
	}

	public static string FacebookDisplayName
	{
		get {
			if (Instance.facebookDisplayName != null && Instance.facebookDisplayName.Length > 0)
			{
			}
			else {
				Instance.facebookDisplayName = "Mobage";
			}
			return Instance.facebookDisplayName; 
		}
		set { 
			Instance.facebookDisplayName = value;
			DirtyEditor();
		}
	}

	public static string PackageName
	{
		get { 
			if (Instance.packageName != null && Instance.packageName.Length > 0)
			{
			}
			else
			{
				Instance.packageName = PlayerSettings.bundleIdentifier;
			}
			return Instance.packageName;
		}
		set {
			Instance.packageName = value;
			if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.iPhone)
			{
				PlayerSettings.bundleIdentifier = value;
			}
			DirtyEditor();
		}

	}

private static string relativePath(string path)
    {
        string projectAssets = Application.dataPath;
        int position = 0;
        string result = "";
        bool found = false;
        int lastFolder = 0;
        if (path != null && path.Length > 0)
        {
            for (int lp = 0; lp < projectAssets.Length; lp++)
            {
                if (lp >= path.Length)
                {
                    position = lp;
                    found = true;
                    break;
                }
                if (Path.VolumeSeparatorChar.Equals(path[lp]))
                {
                    lastFolder = lp;
                }
                if (projectAssets[lp] != path[lp])
                {
                    position = lastFolder;
                    found = true;
                    break;

                }
            }
            if (!found)
            {
                position = projectAssets.Length;
                if ((projectAssets.Length < path.Length) && (path.Length <= position + 1))
                {
                    position++;
                }
            }
            else {
                string substring = projectAssets.Substring(position);
                if (Path.VolumeSeparatorChar.Equals(substring[0]))
                {
                    substring = substring.Substring (1);
                }
                string [] directories = substring.Split(Path.VolumeSeparatorChar);
                for (int loop = 0; loop < directories.Length; loop++)
                {
                    result = Path.Combine (result,"..");
                }
            }
            string remainingPath = path.Substring(position);
            if (remainingPath != null && remainingPath[0] == Path.VolumeSeparatorChar)
            {
                remainingPath = remainingPath.Substring(1);
            }
            result = Path.Combine (result,remainingPath);
        }
        return result;
    }

	public static string KeyStorePath
	{
		get {
			if (Instance.keyStorePath != null && Instance.keyStorePath.Length > 0)
			{
			}
			else {
				Instance.keyStorePath = null;
			}
			return Instance.keyStorePath; 
		}
		set { 
			Instance.keyStorePath = relativePath(value); 
			DirtyEditor();
		}
	}

	public static string KeyStoreAlias
	{
		get { return Instance.keyStoreAlias; }
		set {
			Instance.keyStoreAlias = value;
			DirtyEditor();
		}
	}

	public static string KeyStorePass
	{
		get { return Instance.keyStorePass; }
		set {
			Instance.keyStorePass = value;
			DirtyEditor();
		}
	}

	public static bool AndroidAdTracking
	{
		get { return Instance.androidAdTracking; }
		set {
			if (Instance.androidAdTracking != value)
			{
				Instance.androidAdTracking = value;
				string plugins = Path.Combine(Application.dataPath,"Plugins");
				string android = Path.Combine(plugins,"Android");
				string res = Path.Combine(android,"res");
				string values = Path.Combine(res,"values");
				string fullPath = Path.Combine(values,"mobage-ads.xml");

				if (value == false)
				{
					FileUtil.DeleteFileOrDirectory(fullPath);
				} 
				else 
				{
					if (Instance.androidAdTrackingFile != null && Instance.androidAdTrackingFile.Length > 0)
					{
						FileUtil.CopyFileOrDirectory(Path.Combine (Application.dataPath,Instance.androidAdTrackingFile),fullPath);
					}
				}
			}

			DirtyEditor();
		}
	}

	public static string AndroidAdTrackingFile
	{
		get { 
			if (Instance.androidAdTrackingFile != null && Instance.androidAdTrackingFile.Length > 0)
			{
			}
			else {
				Instance.androidAdTrackingFile = null;
			}
			return Instance.androidAdTrackingFile;
		}
		set {
			Instance.androidAdTrackingFile = relativePath(value);
			string plugins = Path.Combine(Application.dataPath,"Plugins");
			string android = Path.Combine(plugins,"Android");
			string res = Path.Combine(android,"res");
			string values = Path.Combine(res,"values");
			string fullPath = Path.Combine(values,"mobage-ads.xml");
			if (Instance.androidAdTrackingFile != null && Instance.androidAdTrackingFile.Length > 0)
			{
				FileUtil.CopyFileOrDirectory(Path.Combine(Application.dataPath,Instance.androidAdTrackingFile),fullPath);
			}
			DirtyEditor();
		}
	}

	public static string AndroidMainActivity
	{
		get { 
			if (Instance.androidMainActivity != null && Instance.androidMainActivity.Length > 0)
			{
			}
			else {
				Instance.androidMainActivity = "com.test.android.MBUnityPlayerProxyActivity";
			}
			return Instance.androidMainActivity;
		}
		set {
			Instance.androidMainActivity = value;
			DirtyEditor();
		}
	}

	public static string BundleID
	{
		get {
			if (Instance.bundleID != null && Instance.bundleID.Length > 0)
			{
			}
			else {
				Instance.bundleID = PlayerSettings.bundleIdentifier;
			}
			return Instance.bundleID;
		}
		set {
			Instance.bundleID = value;
			if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iPhone)
			{
				PlayerSettings.bundleIdentifier = value;
			}
			DirtyEditor();
		}
	}

	public static string AppID
	{
		get { return Instance.appID; }
		set {
			Instance.appID = value;
			DirtyEditor();
		}
	}

	public static bool IosAdTracking
	{
		get { return Instance.iosAdTracking; }
		set {
			Instance.iosAdTracking = value;
			DirtyEditor();
		}
	}

	public static string IosAdTrackingFrameworkFile
	{
		get {
			if (Instance.iosAdTrackingFrameworkFile != null && Instance.iosAdTrackingFrameworkFile.Length > 0)
			{
			}
			else {
				Instance.iosAdTrackingFrameworkFile = null;
			}
			return Instance.iosAdTrackingFrameworkFile;
		}
		set {
			Instance.iosAdTrackingFrameworkFile = relativePath(value);
			DirtyEditor();
		}
	}

	public static string IosAdTrackingConfigFile
	{
		get {
			if (Instance.iosAdTrackingConfigFile != null && Instance.iosAdTrackingConfigFile.Length > 0)
			{
			}
			else {
				Instance.iosAdTrackingConfigFile = null;
			}
			return Instance.iosAdTrackingConfigFile;
		}
		set {
			Instance.iosAdTrackingConfigFile = relativePath(value);
			DirtyEditor();
		}
	}

	public static string IosConfigDirectory
	{
		get { 
			if (Instance.iosConfigDirectory != null && Instance.iosConfigDirectory.Length > 0)
			{
			}
			else {
				string mobagendk = Path.Combine("..","MobageNDK");
				string ios = Path.Combine(mobagendk,"iOS");
				Instance.iosConfigDirectory = ios;
			}
			return Instance.iosConfigDirectory;
		}

		set {
			Instance.iosConfigDirectory = relativePath(value);
			DirtyEditor();
		}
	}

	public static string Version  
	{
		get {
			if (Instance.version == null)
			{
				if (Application.platform == RuntimePlatform.WindowsEditor)
				{
					string plugins = Path.Combine(Application.dataPath,"Plugins");
					string android = Path.Combine(plugins,"Android");
					string res = Path.Combine(android,"res");
					string values = Path.Combine(res,"values");
					string fullPath = Path.Combine(values,"mobage.xml");
					XMLParser parser = new XMLParser(fullPath);

					Instance.version = parser.getElementValueForAttribute("name","mobage_sdkVersion", parser.getRootNode());

				} 
				else {
					var proc = new Process();
					string mobageNDK = Path.Combine (Application.dataPath,"MobageNDK");
					string mobageNDKBundle = Path.Combine(mobageNDK, "MobageNDK.bundle");
					string ios = Path.Combine (mobageNDKBundle, "iOS");
					string ndkResources = Path.Combine(ios, "NDKResources.bundle");
					string plist = Path.Combine(ndkResources,"Info.plist");
					var script = @"""/usr/libexec/PlistBuddy -c 'Print :MobageNDKVersion' '{0}'""";
					proc.StartInfo.FileName = "bash";
					proc.StartInfo.Arguments = "-c " + string.Format(script,plist);
					proc.StartInfo.UseShellExecute = false;
					proc.StartInfo.CreateNoWindow = true;
					proc.StartInfo.RedirectStandardOutput = true;
					proc.Start();
					StringBuilder versionPlist = new StringBuilder();

					while (!proc.HasExited)
					{
						versionPlist.Append(proc.StandardOutput.ReadToEnd());
					}
					if (proc.ExitCode == 0)
					{
						Instance.version = versionPlist.ToString();
					}
					else 
					{
						UnityEngine.Debug.LogError("PList Buddy failed" + versionPlist.ToString());
					}
				}
			}
		return Instance.version;
		}

	}

	private static void DirtyEditor()
	{
		#if UNITY_EDITOR
		EditorUtility.SetDirty(Instance);
		#endif
	}

}