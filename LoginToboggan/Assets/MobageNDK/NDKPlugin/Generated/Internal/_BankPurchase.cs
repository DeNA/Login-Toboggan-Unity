using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class BankPurchase {
		static BankPurchase() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCBankPurchase_createTransactionCallbackPingBack(IntPtr token);

	void BankPurchase_createTransactionCallbackPing(string token) {
		//print(string.Format("BankPurchase_createTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankPurchase_createTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankPurchase_closeTransactionCallbackPingBack(IntPtr token);

	void BankPurchase_closeTransactionCallbackPing(string token) {
		//print(string.Format("BankPurchase_closeTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankPurchase_closeTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankPurchase_continueTransactionCallbackPingBack(IntPtr token);

	void BankPurchase_continueTransactionCallbackPing(string token) {
		//print(string.Format("BankPurchase_continueTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankPurchase_continueTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankPurchase_cancelTransactionCallbackPingBack(IntPtr token);

	void BankPurchase_cancelTransactionCallbackPing(string token) {
		//print(string.Format("BankPurchase_cancelTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankPurchase_cancelTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankPurchase_getTransactionCallbackPingBack(IntPtr token);

	void BankPurchase_getTransactionCallbackPing(string token) {
		//print(string.Format("BankPurchase_getTransactionCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankPurchase_getTransactionCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCBankPurchase_getUnfinishedItemTransactionsCallbackPingBack(IntPtr token);

	void BankPurchase_getUnfinishedItemTransactionsCallbackPing(string token) {
		//print(string.Format("BankPurchase_getUnfinishedItemTransactionsCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCBankPurchase_getUnfinishedItemTransactionsCallbackPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
#if MB_WW // whole interface/model is region-specific
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class BankPurchase {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankPurchase_createTransaction(IntPtr input_itemToPurchase, Int32 input_quantity, IntPtr input_comment, createTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankPurchase_closeTransaction(IntPtr input_transaction, IntPtr input_invoiceId, closeTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankPurchase_continueTransaction(IntPtr input_transaction, continueTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankPurchase_cancelTransaction(IntPtr input_transaction, cancelTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankPurchase_getTransaction(IntPtr input_transactionId, getTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankPurchase_getUnfinishedItemTransactions(getUnfinishedItemTransactions_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class BankPurchase {
		private delegate void createTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (createTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void createTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
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
				MobageLogger.log("createTransaction callback about to invoke!");
				try {
					createTransaction_onCompleteCallback del = (createTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("createTransaction finished invoking!");
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
		
		private delegate void getUnfinishedItemTransactions_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transactions, IntPtr context);
		[MonoPInvokeCallback (typeof (getUnfinishedItemTransactions_onCompleteCallbackDispatcherDelegate))]
		private static void getUnfinishedItemTransactions_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transactions, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<Transaction> transactions = null;
			if (input_transactions != IntPtr.Zero){
				transactions = Convert.toCS_Transaction_Array(input_transactions);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getUnfinishedItemTransactions callback about to invoke!");
				try {
					getUnfinishedItemTransactions_onCompleteCallback del = (getUnfinishedItemTransactions_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transactions );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getUnfinishedItemTransactions finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion
	
#region Static Methods
	public partial class BankPurchase {
		public static void _createTransaction(ItemData itemToPurchase, Int32 quantity, String comment, createTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_itemToPurchase = (IntPtr)Convert.toC(itemToPurchase);

			Int32 out_quantity = quantity;

			IntPtr out_comment = (IntPtr)Convert.toC(comment);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankPurchase_createTransaction(out_itemToPurchase, out_quantity, out_comment, createTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			ItemData.MBCReleaseItemData(out_itemToPurchase);
			Marshal.FreeHGlobal(out_comment);
		}
		public static void _closeTransaction(Transaction transaction, String invoiceId, closeTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			IntPtr out_invoiceId = (IntPtr)Convert.toC(invoiceId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankPurchase_closeTransaction(out_transaction, out_invoiceId, closeTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
			Marshal.FreeHGlobal(out_invoiceId);
		}
		public static void _continueTransaction(Transaction transaction, continueTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankPurchase_continueTransaction(out_transaction, continueTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		public static void _cancelTransaction(Transaction transaction, cancelTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankPurchase_cancelTransaction(out_transaction, cancelTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		public static void _getTransaction(String transactionId, getTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transactionId = (IntPtr)Convert.toC(transactionId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankPurchase_getTransaction(out_transactionId, getTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_transactionId);
		}
		public static void _getUnfinishedItemTransactions(getUnfinishedItemTransactions_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankPurchase_getUnfinishedItemTransactions(getUnfinishedItemTransactions_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class BankPurchase {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414

	}
#endregion
	
	public partial class Convert {
	// Has None!
	}
	
#endif // MB_WW -- whole interface/model is region-specific
}


#endif	// !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
