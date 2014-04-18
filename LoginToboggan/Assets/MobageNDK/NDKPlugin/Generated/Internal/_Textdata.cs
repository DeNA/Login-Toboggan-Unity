using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class Textdata {
		static Textdata() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCTextdata_createEntryForGroupNameCallbackPingBack(IntPtr token);

	void Textdata_createEntryForGroupNameCallbackPing(string token) {
		//print(string.Format("Textdata_createEntryForGroupNameCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCTextdata_createEntryForGroupNameCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCTextdata_getEntriesForGroupNameCallbackPingBack(IntPtr token);

	void Textdata_getEntriesForGroupNameCallbackPing(string token) {
		//print(string.Format("Textdata_getEntriesForGroupNameCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCTextdata_getEntriesForGroupNameCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCTextdata_updateEntryForGroupNameCallbackPingBack(IntPtr token);

	void Textdata_updateEntryForGroupNameCallbackPing(string token) {
		//print(string.Format("Textdata_updateEntryForGroupNameCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCTextdata_updateEntryForGroupNameCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCTextdata_deleteEntryForGroupNameCallbackPingBack(IntPtr token);

	void Textdata_deleteEntryForGroupNameCallbackPing(string token) {
		//print(string.Format("Textdata_deleteEntryForGroupNameCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCTextdata_deleteEntryForGroupNameCallbackPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
#if MB_JP // whole interface/model is region-specific
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Textdata {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCTextdata_createEntryForGroupName(IntPtr input_groupName, IntPtr input_entry, createEntryForGroupName_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCTextdata_getEntriesForGroupName(IntPtr input_groupName, IntPtr input_entryIds, getEntriesForGroupName_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCTextdata_updateEntryForGroupName(IntPtr input_groupName, IntPtr input_entryId, IntPtr input_entry, updateEntryForGroupName_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCTextdata_deleteEntryForGroupName(IntPtr input_groupName, IntPtr input_entryId, deleteEntryForGroupName_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class Textdata {
		private delegate void createEntryForGroupName_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_entry, IntPtr context);
		[MonoPInvokeCallback (typeof (createEntryForGroupName_onCompleteCallbackDispatcherDelegate))]
		private static void createEntryForGroupName_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_entry, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			TextdataEntry entry = null;
			if (input_entry != IntPtr.Zero){
				entry = Convert.toCS_TextdataEntry(input_entry);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("createEntryForGroupName callback about to invoke!");
				try {
					createEntryForGroupName_onCompleteCallback del = (createEntryForGroupName_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  entry );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("createEntryForGroupName finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getEntriesForGroupName_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_entries, IntPtr context);
		[MonoPInvokeCallback (typeof (getEntriesForGroupName_onCompleteCallbackDispatcherDelegate))]
		private static void getEntriesForGroupName_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_entries, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<TextdataEntry> entries = null;
			if (input_entries != IntPtr.Zero){
				entries = Convert.toCS_TextdataEntry_Array(input_entries);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getEntriesForGroupName callback about to invoke!");
				try {
					getEntriesForGroupName_onCompleteCallback del = (getEntriesForGroupName_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  entries );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getEntriesForGroupName finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void updateEntryForGroupName_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (updateEntryForGroupName_onCompleteCallbackDispatcherDelegate))]
		private static void updateEntryForGroupName_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("updateEntryForGroupName callback about to invoke!");
				try {
					updateEntryForGroupName_onCompleteCallback del = (updateEntryForGroupName_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("updateEntryForGroupName finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void deleteEntryForGroupName_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (deleteEntryForGroupName_onCompleteCallbackDispatcherDelegate))]
		private static void deleteEntryForGroupName_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("deleteEntryForGroupName callback about to invoke!");
				try {
					deleteEntryForGroupName_onCompleteCallback del = (deleteEntryForGroupName_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("deleteEntryForGroupName finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion
	
#region Static Methods
	public partial class Textdata {
		public static void _createEntryForGroupName(String groupName, TextdataEntry entry, createEntryForGroupName_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_groupName = (IntPtr)Convert.toC(groupName);

			IntPtr out_entry = (IntPtr)Convert.toC(entry);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCTextdata_createEntryForGroupName(out_groupName, out_entry, createEntryForGroupName_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_groupName);
			TextdataEntry.MBCReleaseTextdataEntry(out_entry);
		}
		public static void _getEntriesForGroupName(String groupName, List<String> entryIds, getEntriesForGroupName_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_groupName = (IntPtr)Convert.toC(groupName);

			IntPtr out_entryIds = (IntPtr)Convert.toC(entryIds);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCTextdata_getEntriesForGroupName(out_groupName, out_entryIds, getEntriesForGroupName_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_groupName);
			Marshal.FreeHGlobal(out_entryIds);
		}
		public static void _updateEntryForGroupName(String groupName, String entryId, TextdataEntry entry, updateEntryForGroupName_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_groupName = (IntPtr)Convert.toC(groupName);

			IntPtr out_entryId = (IntPtr)Convert.toC(entryId);

			IntPtr out_entry = (IntPtr)Convert.toC(entry);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCTextdata_updateEntryForGroupName(out_groupName, out_entryId, out_entry, updateEntryForGroupName_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_groupName);
			Marshal.FreeHGlobal(out_entryId);
			TextdataEntry.MBCReleaseTextdataEntry(out_entry);
		}
		public static void _deleteEntryForGroupName(String groupName, String entryId, deleteEntryForGroupName_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_groupName = (IntPtr)Convert.toC(groupName);

			IntPtr out_entryId = (IntPtr)Convert.toC(entryId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCTextdata_deleteEntryForGroupName(out_groupName, out_entryId, deleteEntryForGroupName_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_groupName);
			Marshal.FreeHGlobal(out_entryId);
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class Textdata {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414

	}
#endregion
	
	public partial class Convert {
	// Has None!
	}
	
#endif // MB_JP -- whole interface/model is region-specific
}


#endif	// !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
