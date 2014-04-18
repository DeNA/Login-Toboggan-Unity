using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class BankDebit {
		static BankDebit() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCBankDebit_createTransactionForItemCallbackPingBack(IntPtr token);

	void BankDebit_createTransactionForItemCallbackPing(string token) {
		//print(string.Format("BankDebit_createTransactionForItemCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankDebit_createTransactionForItemCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankDebit_openTransactionCallbackPingBack(IntPtr token);

	void BankDebit_openTransactionCallbackPing(string token) {
		//print(string.Format("BankDebit_openTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankDebit_openTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankDebit_closeTransactionCallbackPingBack(IntPtr token);

	void BankDebit_closeTransactionCallbackPing(string token) {
		//print(string.Format("BankDebit_closeTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankDebit_closeTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankDebit_continueTransactionCallbackPingBack(IntPtr token);

	void BankDebit_continueTransactionCallbackPing(string token) {
		//print(string.Format("BankDebit_continueTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankDebit_continueTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankDebit_cancelTransactionCallbackPingBack(IntPtr token);

	void BankDebit_cancelTransactionCallbackPing(string token) {
		//print(string.Format("BankDebit_cancelTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankDebit_cancelTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankDebit_getTransactionCallbackPingBack(IntPtr token);

	void BankDebit_getTransactionCallbackPing(string token) {
		//print(string.Format("BankDebit_getTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankDebit_getTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankDebit_authorizeTransactionCallbackPingBack(IntPtr token);

	void BankDebit_authorizeTransactionCallbackPing(string token) {
		//print(string.Format("BankDebit_authorizeTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankDebit_authorizeTransactionCallbackPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class BankDebit {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_createTransactionForItem(IntPtr input_itemToPurchase, Int32 input_quantity, IntPtr input_comment, createTransactionForItem_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_openTransaction(IntPtr input_transaction, openTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_closeTransaction(IntPtr input_transaction, closeTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_continueTransaction(IntPtr input_transaction, continueTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_cancelTransaction(IntPtr input_transaction, cancelTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_getTransaction(IntPtr input_transactionId, getTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_authorizeTransaction(IntPtr input_transaction, authorizeTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class BankDebit {
		private delegate void createTransactionForItem_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (createTransactionForItem_onCompleteCallbackDispatcherDelegate))]
		private static void createTransactionForItem_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("createTransactionForItem callback about to invoke!");
				try {
					createTransactionForItem_onCompleteCallback del = (createTransactionForItem_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("createTransactionForItem finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void openTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (openTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void openTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openTransaction callback about to invoke!");
				try {
					openTransaction_onCompleteCallback del = (openTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void closeTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (closeTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void closeTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("closeTransaction callback about to invoke!");
				try {
					closeTransaction_onCompleteCallback del = (closeTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("closeTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void continueTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (continueTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void continueTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("continueTransaction callback about to invoke!");
				try {
					continueTransaction_onCompleteCallback del = (continueTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("continueTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void cancelTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (cancelTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void cancelTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("cancelTransaction callback about to invoke!");
				try {
					cancelTransaction_onCompleteCallback del = (cancelTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("cancelTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (getTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void getTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getTransaction callback about to invoke!");
				try {
					getTransaction_onCompleteCallback del = (getTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void authorizeTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (authorizeTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void authorizeTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("authorizeTransaction callback about to invoke!");
				try {
					authorizeTransaction_onCompleteCallback del = (authorizeTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("authorizeTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion
	
#region Static Methods
	public partial class BankDebit {
		public static void _createTransactionForItem(ItemData itemToPurchase, Int32 quantity, String comment, createTransactionForItem_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_itemToPurchase = (IntPtr)Convert.toC(itemToPurchase);

			Int32 out_quantity = quantity;

			IntPtr out_comment = (IntPtr)Convert.toC(comment);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_createTransactionForItem(out_itemToPurchase, out_quantity, out_comment, createTransactionForItem_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			ItemData.MBCReleaseItemData(out_itemToPurchase);
			Marshal.FreeHGlobal(out_comment);
		}
		public static void _openTransaction(Transaction transaction, openTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_openTransaction(out_transaction, openTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		public static void _closeTransaction(Transaction transaction, closeTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_closeTransaction(out_transaction, closeTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		public static void _continueTransaction(Transaction transaction, continueTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_continueTransaction(out_transaction, continueTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		public static void _cancelTransaction(Transaction transaction, cancelTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_cancelTransaction(out_transaction, cancelTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		public static void _getTransaction(String transactionId, getTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transactionId = (IntPtr)Convert.toC(transactionId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_getTransaction(out_transactionId, getTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_transactionId);
		}
		public static void _authorizeTransaction(Transaction transaction, authorizeTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_authorizeTransaction(out_transaction, authorizeTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class BankDebit {
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
