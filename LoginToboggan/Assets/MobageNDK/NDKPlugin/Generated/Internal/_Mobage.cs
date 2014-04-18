using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class Mobage {
		static Mobage() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCMobage_getMobageVendorIdCallbackPingBack(IntPtr token);

	void Mobage_getMobageVendorIdCallbackPing(string token) {
		//print(string.Format("Mobage_getMobageVendorIdCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCMobage_getMobageVendorIdCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCMobage_getSDKVersionCallbackPingBack(IntPtr token);

	void Mobage_getSDKVersionCallbackPing(string token) {
		//print(string.Format("Mobage_getSDKVersionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCMobage_getSDKVersionCallbackPingBack(token_c);
	}

	[DllImport("NDKPlugin")]
	private static extern void MBMobageUIVisibleNotificationPingBack(IntPtr token);

	void MobageProxies_MBMobageUIVisibleNotificationPing(string token) {
		//print(string.Format("Mobage_CallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBMobageUIVisibleNotificationPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
	
	public partial class Convert {
		public static bool IsServerEnvironment(int intFlag){return (!((intFlag < 0) || (intFlag > 1))); }
		public static int toC(ServerEnvironment enumValue){return (int)enumValue;}
		public static ServerEnvironment toCS_ServerEnvironment(int enumValue){return (ServerEnvironment)enumValue;}
	}
#endregion
	

#region Native Method Imports
	public partial class Mobage {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCMobageUIVisibleNotification_registerObserver(IntPtr context, MobageUIVisibleNotification.MobageUIVisibleNotification_dispatcherDelegate cb);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCMobageUIVisibleNotification_deregisterObserver(IntPtr context);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainMobageUIVisibleNotification(IntPtr /*MobageUIVisibleNotification*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseMobageUIVisibleNotification(IntPtr /*MobageUIVisibleNotification*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCMobage_initializeMobageWithStandardParameters(Int32 input_serverEnvironment, IntPtr input_appId, IntPtr input_appVersion, IntPtr input_consumerKey, IntPtr input_consumerSecret, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCMobage_getMobageVendorId(getMobageVendorId_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCMobage_getSDKVersion(getSDKVersion_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class Mobage {
		private delegate void getMobageVendorId_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_mvid, IntPtr context);
		[MonoPInvokeCallback (typeof (getMobageVendorId_onCompleteCallbackDispatcherDelegate))]
		private static void getMobageVendorId_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_mvid, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			String mvid = null;
			if (input_mvid != IntPtr.Zero){
				mvid = Convert.toCS_String(input_mvid);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getMobageVendorId callback about to invoke!");
				try {
					getMobageVendorId_onCompleteCallback del = (getMobageVendorId_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  mvid );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getMobageVendorId finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getSDKVersion_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_sdkVersion, IntPtr context);
		[MonoPInvokeCallback (typeof (getSDKVersion_onCompleteCallbackDispatcherDelegate))]
		private static void getSDKVersion_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_sdkVersion, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			String sdkVersion = null;
			if (input_sdkVersion != IntPtr.Zero){
				sdkVersion = Convert.toCS_String(input_sdkVersion);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getSDKVersion callback about to invoke!");
				try {
					getSDKVersion_onCompleteCallback del = (getSDKVersion_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  sdkVersion );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getSDKVersion finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		

		public partial class MobageUIVisibleNotification {
			
			[StructLayout (LayoutKind.Sequential)]
			private struct CMobageUIVisibleNotification {
				public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
				public IntPtr thisObj; // ALSO VERY INTERNAL
						
			public short visible;
				//End of Marshal struct
			}
			// Factories!
			public static MobageUIVisibleNotification Factory(IntPtr cobj){
				CMobageUIVisibleNotification tmp = (CMobageUIVisibleNotification)Marshal.PtrToStructure(cobj, typeof(CMobageUIVisibleNotification));
				MobageUIVisibleNotification result = Factory(ref tmp);
				return result;
			}
			private static MobageUIVisibleNotification Factory(ref CMobageUIVisibleNotification cobj) {
				MobageUIVisibleNotification tmp = new MobageUIVisibleNotification();
				
				tmp.visible = Convert.toCS_Bool(cobj.visible);
				
				return tmp;
			}
			
			~MobageUIVisibleNotification(){
				
			}
			
			public delegate void MobageUIVisibleNotification_dispatcherDelegate(IntPtr context, IntPtr notification);
			[MonoPInvokeCallback (typeof (MobageUIVisibleNotification_dispatcherDelegate))]
			public static void MobageUIVisibleNotification_dispatcher(IntPtr context, IntPtr cobj) {
				MobageUIVisibleNotification notification = Convert.toCS_MobageUIVisibleNotification(cobj);
				try {
					MobageUIVisibleNotificationDelegate del = (MobageUIVisibleNotificationDelegate)MobageUIVisible_observers[context.ToInt32()];
					del(notification);
				} catch ( Exception e) {
					MobageLogger.exceptionLog(e);
				}
			}
		}
	}
#endregion
	
#region Static Methods
	public partial class Mobage {
		public static void _initializeMobageWithStandardParameters(ServerEnvironment serverEnvironment, String appId, String appVersion, String consumerKey, String consumerSecret)
		{
			int cbId = (cbUidGenerator++);
			Int32 out_serverEnvironment = (int)serverEnvironment;

			IntPtr out_appId = (IntPtr)Convert.toC(appId);

			IntPtr out_appVersion = (IntPtr)Convert.toC(appVersion);

			IntPtr out_consumerKey = (IntPtr)Convert.toC(consumerKey);

			IntPtr out_consumerSecret = (IntPtr)Convert.toC(consumerSecret);

			MBCMobage_initializeMobageWithStandardParameters(out_serverEnvironment, out_appId, out_appVersion, out_consumerKey, out_consumerSecret, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_appId);
			Marshal.FreeHGlobal(out_appVersion);
			Marshal.FreeHGlobal(out_consumerKey);
			Marshal.FreeHGlobal(out_consumerSecret);
		}
		public static void _getMobageVendorId(getMobageVendorId_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCMobage_getMobageVendorId(getMobageVendorId_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _getSDKVersion(getSDKVersion_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCMobage_getSDKVersion(getSDKVersion_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class Mobage {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414


#pragma warning disable 0414
		private static Dictionary<int, Object> MobageUIVisible_observers = new Dictionary<int, Object>();
		private static Dictionary<Object,int> MobageUIVisible_reverseObservers = new Dictionary<Object,int>();
		private static int MobageUIVisibleObserverUIDGenerator = 0;
#pragma warning restore 0414
		private static void MobageUIVisibleNotificationDelegate_add(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = MobageUIVisibleObserverUIDGenerator++;
				MobageUIVisible_observers.Add(identifier, val);
				MobageUIVisible_reverseObservers.Add(val, identifier);
				MBCMobageUIVisibleNotification_registerObserver(new IntPtr(identifier), MobageUIVisibleNotification.MobageUIVisibleNotification_dispatcher);
		}
		private static void MobageUIVisibleNotificationDelegte_remove(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = MobageUIVisible_reverseObservers[val];
				MBCMobageUIVisibleNotification_deregisterObserver(new IntPtr(identifier));
				MobageUIVisible_reverseObservers.Remove(val);
				MobageUIVisible_observers.Remove(identifier);
		}
	}
#endregion
	
	public partial class Convert {

		public static Mobage.MobageUIVisibleNotification toCS_MobageUIVisibleNotification(IntPtr obj){
			return Mobage.MobageUIVisibleNotification.Factory(obj);
		}

	}
	
}


#endif	// !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
