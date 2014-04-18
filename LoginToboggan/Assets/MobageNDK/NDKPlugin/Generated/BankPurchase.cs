//
//  BankPurchase.cs
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
// Mobage don't support Unity Editor right now. (add "-define:HAS_MOBAGE_DESKTOP_SHIM" to /Assets/smcs.rsp to override)


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Mobage {
#if MB_WW // whole interface/model is region-specific

	/**
	 * <summary> Processes transactions for virtual items that are purchased with cash.</summary>
	 * <remarks>
	 * The user must sign into an App Store account to approve the purchase.
	 * <p>
	 * <strong>Important</strong>: This class is available only on iOS. On Android, the methods in this
	 * class always return an error.
	 * <p>
	 * To complete a purchase for cash, your app typically follows these steps:
	 * <ol>
	 * <li>Call <c>BankPurchase::createTransaction</c>, which creates a transaction and sets its state
	 * to <c>Mobage::TransactionState:New</c>.</li>
	 * <li>Call <c>BankPurchase::continueTransaction</c>, which presents a confirmation dialog to the
	 * user. If the user approves the purchase, then Apple charges the user's account, and the
	 * transaction's state changes to <c>Mobage::TransactionState:Authorized</c>.</li>
	 * <li>
	 * <p>Notify your app server that it must use the Mobage REST API to open the transaction. When the
	 * app server opens the transaction, the transaction's state changes to
	 * <c>Mobage::TransactionState:Open</c>. In addition, the app server receives the invoice ID for
	 * the transaction; you must send this ID to Mobage when closing the transaction.
	 * <strong>Important</strong>: Do not share the invoice ID with the user.</p>
	 * <p><strong>Note</strong>: When a user is purchasing a virtual item for cash, your app server must
	 * open the transaction. Opening the transaction from the client is not supported.</p>
	 * </li>
	 * <li>Wait for your app server to deliver the virtual item to the user. After the app server
	 * delivers the item, it must send the invoice ID to the client and notify the client that the
	 * transaction is ready to close.</li>
	 * <li>Call <c>BankPurchase::getTransaction</c> to obtain an updated <c>Transaction</c> object.</li>
	 * <li>Using the updated <c>Transaction</c> object, call <c>BankPurchase::closeTransaction</c> to
	 * finalize the transaction and change its state to <c>Mobage::TransactionState:Closed</c>. A
	 * confirmation dialog informs the user that the virtual item has been delivered.</li>
	 * </ol>
	 * <strong>Important</strong>: Your app must wait for the callback from each method and verify that
	 * the request succeeded before proceeding to the next step.
	 * <p>
	 * In some cases, your app may be interrupted while it is in the middle of processing a cash
	 * purchase (for example, if the user switches to a different app, and the device forces your app to
	 * shut down). The Unity SDK maintains an on-device cache of these unfinished transactions. When
	 * your app starts, it must check for unfinished cash transactions by calling
	 * <c>BankPurchase::getUnfinishedItemTransactions</c>. Your app can then process these transactions
	 * appropriately based on their current state.
	 * <p>
	 * <strong>Warning</strong>: If your app does not check for unfinished transactions,
	 * users may be charged for items that were never delivered.
	 * </remarks>
	 */
	public partial class BankPurchase {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class BankPurchase {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class BankPurchase {
		/**
		 * <summary> Callback for creating a transaction.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void createTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);

		/**
		 * <summary> Callback for closing a transaction.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void closeTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);

		/**
		 * <summary> Callback for approving a transaction.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void continueTransaction_onCompleteCallback(CancelableAPIStatus status, Error error, Transaction transaction);

		/**
		 * <summary> Callback for canceling a transaction.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void cancelTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);

		/**
		 * <summary> Callback for retrieving information about a transaction.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);

		/**
		 * <summary> Callback for retrieving unfinished transactions.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transactions" cref="F:System.Collections.Generic.List<Mobage.Transaction>">Array of unfinished transactions.</param>
		 */
		public delegate void getUnfinishedItemTransactions_onCompleteCallback(SimpleAPIStatus status, Error error, List<Transaction> transactions);

	}
#endregion

#region Static Methods
	public partial class BankPurchase {
		/**
		 * <summary> Create a new transaction.</summary>
		 * <remarks>
		 * When your app calls this method, the app's inventory is checked to make sure the requested
		 * item exists and can be purchased with cash. A new transaction is then created, with its state
		 * set to <c>Mobage::TransactionState:New</c>.
		 * </remarks>
		 * <param name="itemToPurchase" cref="F:Mobage.ItemData">The item to purchase. Must be an item that can be purchased for cash.</param>
		 * <param name="quantity" cref="F:System.Int32">The quantity of the item to purchase.</param>
		 * <param name="comment" cref="F:System.String">A comment on the transaction. On the Mobage West platform, this comment is not currently displayed to users.</param>
		 * <param name="onComplete" cref="F:Mobage.CreateTransactionOnCompleteCallback">
		 * Callback for creating a transaction.</param>
		 * 
		 */
		public static void createTransaction(ItemData itemToPurchase, Int32 quantity, String comment, createTransaction_onCompleteCallback onComplete)
		{
			_createTransaction(itemToPurchase, quantity, comment, onComplete);
		}
		/**
		 * <summary> Close the transaction after delivering the virtual item.</summary>
		 * <remarks>
		 * If this method succeeds, the transaction's state is set to
		 * <c>BankPurchase::closeTransaction</c>, and a confirmation dialog informs the user that the
		 * virtual item has been delivered.
		 * <p>
		 * <strong>Note</strong>: Before you call this method, you must use the transaction ID to
		 * retrieve an updated <c>Transaction</c> object. Call <c>BankPurchase::getTransaction</c> to
		 * retrieve the object.
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction to be closed.</param>
		 * <param name="invoiceId" cref="F:System.String">Mobage's invoice ID for the transaction. Your app server receives this ID when it opens the transaction.</param>
		 * <param name="onComplete" cref="F:Mobage.CloseTransactionOnCompleteCallback">
		 * Callback for closing a transaction.</param>
		 * 
		 */
		public static void closeTransaction(Transaction transaction, String invoiceId, closeTransaction_onCompleteCallback onComplete)
		{
			_closeTransaction(transaction, invoiceId, onComplete);
		}
		/**
		 * <summary> Prompt the user to approve a transaction.</summary>
		 * <remarks>
		 * Call this method after creating the transaction.
		 * <p>
		 * When you call this method, a confirmation dialog is presented to the user. If the user
		 * approves the transaction, Apple charges the user for the purchase, and the transaction's
		 * state is set to <c>Mobage::TransactionState:Authorized</c>. Your app server can then use the
		 * Mobage REST API to open the transaction.
		 * <p>
		 * <strong>Important</strong>: If an error occurs after the transaction is authorized, you
		 * should cancel the transaction from the client if possible. See the <a href="#">overview</a>
		 * for more information.
		 * <p>
		 * If the user does not approve the transaction, the transaction's state is set to
		 * <c>Mobage::TransactionState:Canceled</c>.
		 * <p>
		 * <strong>Note</strong>: If your app server created the transaction, you must use the
		 * transaction ID to retrieve a <c>Transaction</c> object before you call this method. Call
		 * <c>BankPurchase::getTransaction</c> to retrieve the object.
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction to be approved.</param>
		 * <param name="onComplete" cref="F:Mobage.ContinueTransactionOnCompleteCallback">
		 * Callback for approving a transaction.</param>
		 * 
		 */
		public static void continueTransaction(Transaction transaction, continueTransaction_onCompleteCallback onComplete)
		{
			_continueTransaction(transaction, onComplete);
		}
		/**
		 * <summary> Mark the transaction as canceled, setting its state to <c>Mobage::TransactionState:Canceled</c>.</summary>
		 * <remarks>
		 * <p>
		 * <strong>Important</strong>: In version 2.3 and later, this method returns an error unless the
		 * transaction's state is <c>Mobage::TransactionState:New</c>. All other unfinished transactions
		 * must be completed by calling
		 * <c>BankPurchase::getUnfinishedItemTransactions</c>, then processing each of the
		 * unfinished transactions.
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction to cancel.</param>
		 * <param name="onComplete" cref="F:Mobage.CancelTransactionOnCompleteCallback">
		 * Callback for canceling a transaction.</param>
		 * 
		 */
		public static void cancelTransaction(Transaction transaction, cancelTransaction_onCompleteCallback onComplete)
		{
			_cancelTransaction(transaction, onComplete);
		}
		/**
		 * <summary> Retrieve information about a transaction.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="transactionId" cref="F:System.String">The transaction's unique ID.</param>
		 * <param name="onComplete" cref="F:Mobage.GetTransactionOnCompleteCallback">
		 * Callback for retrieving information about a transaction.</param>
		 * 
		 */
		public static void getTransaction(String transactionId, getTransaction_onCompleteCallback onComplete)
		{
			_getTransaction(transactionId, onComplete);
		}
		/**
		 * <summary> Retrieve transactions that were interrupted and could not be completed (for example, because the user switched to a different app, and the device forced your app to shut down).</summary>
		 * <remarks>
		 * The Native SDK maintains an on-device cache of these unfinished transactions. When your app
		 * starts, it must check for unfinished transactions and process them appropriately based on
		 * their current state.
		 * <p>
		 * <strong>Warning</strong>: If your app does not check for unfinished transactions,
		 * users may be charged for items that were never delivered.
		 * <p>
		 * The following example shows how to use this method to process unfinished transactions.
		 * @code
		 * // Check for unfinished cash purchases.
		 * Mobage.BankPurchase.getUnfinishedItemTransactions(delegate(Mobage.SimpleAPIStatus status,
		 *     Mobage.Error error, List<Mobage.Transaction>transactions) {
		 *     foreach(Mobage.Transaction transaction in transactions) {
		 *         string invoiceID = "";
		 *         if (transaction.state == Mobage.TransactionState.Open) {
		 *             // Retrieve the invoice ID from your app server. The app server
		 *             // gets the invoice ID when it opens the transaction.
		 *         } else {
		 *             // Use your app server to open the transaction.
		 *         }
		 *
		 *         // Deliver the item to the user.
		 *
		 *         // After delivering the item, close the transaction.
		 *         Mobage.BankPurchase.closeTransaction(transaction, invoiceID,
		 *             delegate(Mobage.SimpleAPIStatus closeStatus, Mobage.Error closeError,
		 *             Mobage.Transaction closeTransaction) {
		 *             switch(closeStatus) {
		 *                 case Mobage.SimpleAPIStatus.SimpleAPIStatusError:
		 *                     // Display an error message.
		 *                     break;
		 *                 case Mobage.SimpleAPIStatus.SimpleAPIStatusSuccess:
		 *                     // Display a success message.
		 *                     break;
		 *             }
		 *         });
		 *     }
		 * });
		 * @endcode
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.GetUnfinishedItemTransactionsOnCompleteCallback">
		 * Callback for retrieving unfinished transactions.</param>
		 * 
		 */
		public static void getUnfinishedItemTransactions(getUnfinishedItemTransactions_onCompleteCallback onComplete)
		{
			_getUnfinishedItemTransactions(onComplete);
		}
	}
#endregion


#endif // MB_WW -- whole interface/model is region-specific
}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
