using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class Appdata {
		static Appdata() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCAppdata_deleteEntriesForKeysCallbackPingBack(IntPtr token);

	void Appdata_deleteEntriesForKeysCallbackPing(string token) {
		//print(string.Format("Appdata_deleteEntriesForKeysCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCAppdata_deleteEntriesForKeysCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCAppdata_getEntriesForKeysCallbackPingBack(IntPtr token);

	void Appdata_getEntriesForKeysCallbackPing(string token) {
		//print(string.Format("Appdata_getEntriesForKeysCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCAppdata_getEntriesForKeysCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCAppdata_updateEntriesCallbackPingBack(IntPtr token);

	void Appdata_updateEntriesCallbackPing(string token) {
		//print(string.Format("Appdata_updateEntriesCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCAppdata_updateEntriesCallbackPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Appdata {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAppdata_deleteEntriesForKeys(IntPtr input_theKeys, deleteEntriesForKeys_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAppdata_getEntriesForKeys(IntPtr input_theKeys, getEntriesForKeys_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAppdata_updateEntries(IntPtr input_theKeys, IntPtr input_theValues, updateEntries_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class Appdata {
		private delegate void deleteEntriesForKeys_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_deletedKeys, IntPtr context);
		[MonoPInvokeCallback (typeof (deleteEntriesForKeys_onCompleteCallbackDispatcherDelegate))]
		private static void deleteEntriesForKeys_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_deletedKeys, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<String> deletedKeys = null;
			if (input_deletedKeys != IntPtr.Zero){
				deletedKeys = Convert.toCS_String_Array(input_deletedKeys);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("deleteEntriesForKeys callback about to invoke!");
				try {
					deleteEntriesForKeys_onCompleteCallback del = (deleteEntriesForKeys_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  deletedKeys );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("deleteEntriesForKeys finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getEntriesForKeys_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_keys, IntPtr input_values, IntPtr context);
		[MonoPInvokeCallback (typeof (getEntriesForKeys_onCompleteCallbackDispatcherDelegate))]
		private static void getEntriesForKeys_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_keys, IntPtr input_values, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<String> keys = null;
			if (input_keys != IntPtr.Zero){
				keys = Convert.toCS_String_Array(input_keys);
			}
			List<String> values = null;
			if (input_values != IntPtr.Zero){
				values = Convert.toCS_String_Array(input_values);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getEntriesForKeys callback about to invoke!");
				try {
					getEntriesForKeys_onCompleteCallback del = (getEntriesForKeys_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  keys,  values );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getEntriesForKeys finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void updateEntries_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_updatedKeys, IntPtr context);
		[MonoPInvokeCallback (typeof (updateEntries_onCompleteCallbackDispatcherDelegate))]
		private static void updateEntries_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_updatedKeys, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<String> updatedKeys = null;
			if (input_updatedKeys != IntPtr.Zero){
				updatedKeys = Convert.toCS_String_Array(input_updatedKeys);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("updateEntries callback about to invoke!");
				try {
					updateEntries_onCompleteCallback del = (updateEntries_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  updatedKeys );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("updateEntries finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion
	
#region Static Methods
	public partial class Appdata {
		public static void _deleteEntriesForKeys(List<String> theKeys, deleteEntriesForKeys_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_theKeys = (IntPtr)Convert.toC(theKeys);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAppdata_deleteEntriesForKeys(out_theKeys, deleteEntriesForKeys_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_theKeys);
		}
		public static void _getEntriesForKeys(List<String> theKeys, getEntriesForKeys_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_theKeys = (IntPtr)Convert.toC(theKeys);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAppdata_getEntriesForKeys(out_theKeys, getEntriesForKeys_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_theKeys);
		}
		public static void _updateEntries(List<String> theKeys, List<String> theValues, updateEntries_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_theKeys = (IntPtr)Convert.toC(theKeys);

			IntPtr out_theValues = (IntPtr)Convert.toC(theValues);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAppdata_updateEntries(out_theKeys, out_theValues, updateEntries_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_theKeys);
			Marshal.FreeHGlobal(out_theValues);
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class Appdata {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414

	}
#endregion
	
	public partial class Convert {
	// Has None!
	}
	
}


#endif	// !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
