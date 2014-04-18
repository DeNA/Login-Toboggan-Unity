using System.Diagnostics;
using System.IO;
using UnityEngine;

public static class OpenInFileBrowser
{	
	public static void OpenInMacFileBrowser(string path)
	{
		System.Diagnostics.Process.Start("open", path);

	}
	
	public static void OpenInWinFileBrowser(string path)
	{
		System.Diagnostics.Process.Start("explorer.exe",  path);
	}
	
	public static void Open(string path)
	{
		if (Application.platform == RuntimePlatform.OSXEditor)
		{
			OpenInMacFileBrowser(path);
		}
		else {
			OpenInWinFileBrowser(path);
		}
	}
}