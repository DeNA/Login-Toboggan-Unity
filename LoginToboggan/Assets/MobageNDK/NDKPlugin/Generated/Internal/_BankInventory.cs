using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class BankInventory {
		static BankInventory() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCBankInventory_getItemForIdCallbackPingBack(IntPtr token);

	void BankInventory_getItemForIdCallbackPing(string token) {
		//print(string.Format("BankInventory_getItemForIdCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankInventory_getItemForIdCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankInventory_getItemsForIdsCallbackPingBack(IntPtr token);

	void BankInventory_getItemsForIdsCallbackPing(string token) {
		//print(string.Format("BankInventory_getItemsForIdsCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankInventory_getItemsForIdsCallbackPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class BankInventory {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankInventory_getItemForId(IntPtr input_itemId, getItemForId_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankInventory_getItemsForIds(IntPtr input_itemIds, getItemsForIds_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class BankInventory {
		private delegate void getItemForId_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_itemData, IntPtr context);
		[MonoPInvokeCallback (typeof (getItemForId_onCompleteCallbackDispatcherDelegate))]
		private static void getItemForId_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_itemData, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			ItemData itemData = null;
			if (input_itemData != IntPtr.Zero){
				itemData = Convert.toCS_ItemData(input_itemData);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getItemForId callback about to invoke!");
				try {
					getItemForId_onCompleteCallback del = (getItemForId_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  itemData );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getItemForId finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getItemsForIds_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_items, IntPtr context);
		[MonoPInvokeCallback (typeof (getItemsForIds_onCompleteCallbackDispatcherDelegate))]
		private static void getItemsForIds_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_items, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<ItemData> items = null;
			if (input_items != IntPtr.Zero){
				items = Convert.toCS_ItemData_Array(input_items);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getItemsForIds callback about to invoke!");
				try {
					getItemsForIds_onCompleteCallback del = (getItemsForIds_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  items );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getItemsForIds finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion
	
#region Static Methods
	public partial class BankInventory {
		public static void _getItemForId(String itemId, getItemForId_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_itemId = (IntPtr)Convert.toC(itemId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankInventory_getItemForId(out_itemId, getItemForId_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_itemId);
		}
		public static void _getItemsForIds(List<String> itemIds, getItemsForIds_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_itemIds = (IntPtr)Convert.toC(itemIds);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankInventory_getItemsForIds(out_itemIds, getItemsForIds_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_itemIds);
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class BankInventory {
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
