
// ngswe
#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)

using UnityEngine;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

//The structLayout attribute isn't strictly necessary since Sequential is default,
//but I've included it here as a reminder.


/* http://docs.xamarin.com/ios/about/limitations#Reverse_Callbacks
 * In standard Mono it is possible to pass C# delegate instances to unmanaged code in lieu of a function pointer. 
 * The runtime would typically transform those function pointers into a small thunk that allows unmanaged code 
 * to call back into managed code. 
 * In Mono these bridges are implemented by the Just-in-Time compiler. When using the ahead-of-time compiler required 
 * by the iPhone there are two important limitations at this point: 
 * 1. You must flag all of your callback methods with the MonoPInvokeCallbackAttribute
 * 2. The methods have to be static methods, there is no support for instance methods.
 * However, this attribute does not exist in the Mono version that Unity uses, so we roll our own.
 * http://answers.unity3d.com/questions/191234/unity-ios-function-pointers.html
 * This will tell the AOT compiler that this method needs to be callable from native code, and thus avoid JIT.
 * */
public class MonoPInvokeCallbackAttribute : System.Attribute
{
	#pragma warning disable 414
    private Type type;
	#pragma warning restore 414
    public MonoPInvokeCallbackAttribute( Type t ) { type = t; }
}

public interface Reporter {
	void Say(string what);
}
public partial class NDKPlugin : MonoBehaviour  {
	
	public static NDKPlugin instance;
	public static Reporter reporter;
	
	//We use this entry point for when the NDK calls back with it's result data.
	//This is the delegate signature. Each API will have it's designated entry point.
	//From that entrypoint we create a typed return value and invoke the callback supplied
	//by the developer.
	public delegate void unityCallbackDelegate(IntPtr resultData);
	
	public static void EnsureInstantiated() {} // Actually just ensures the static constructor runs.
	static void report(string what) {
		if(reporter != null) {
			reporter.Say (what);
		} else {
			Debug.Log (what);
		}
	}
	static NDKPlugin() {
		if (instance == null) {
			report("Instantiate called");
			if (NDK_Init()) {
				var obj = new GameObject("NDKPlugin");
				instance = obj.AddComponent<NDKPlugin>();
				DontDestroyOnLoad(obj);
#if UNITY_IPHONE
				report("Initializing delayed callbacks!");
				Mobage.Mobage.setDelayedCallback(true);
				instance.StartCoroutine(instance.HandleCallbacks(0));
#endif
			} else {
				report("NDK_Init failed");
			}
		}
	}
#if UNITY_IPHONE
	IEnumerator HandleCallbacks(int skipFrames) {
		int count = 0;
		while(true) {
			count++;
			if(count > skipFrames) {
				Mobage.Mobage.invokeAllCallbacks();
				count = 0;
			}
		
			yield return 0;
		}
	}
#endif
	
	[System.Diagnostics.Conditional("UNITY_IPHONE"),
		System.Diagnostics.Conditional("UNITY_ANDROID"),
		System.Diagnostics.Conditional("UNITY_EDITOR")]
	public static void Destroy() {
		if (instance != null) {
			instance.Dispose();
			UnityEngine.Object.Destroy(instance);
			instance = null;
		}
	}
	

	#if UNITY_ANDROID
		[DllImport("NDKPlugin")]
		private static extern bool NDK_Init();
	#else
	private static bool NDK_Init() {
	return true;
	}
	#endif
	
	bool _disposed;

	void OnDestroy() {
		Dispose();
	}

	void Dispose() {
		if (!_disposed) {
			_disposed = true;
		}
	}
	

}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
