//
//  BankDebit.cs
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

	/**
	 * <summary> Interface for purchasing virtual items using MobaCoin (on Android) or an app-specific purchased currency (on iOS).</summary>
	 * <remarks>
	 * To complete a purchase, your app typically follows these steps:
	 * <ol>
	 * <li>Call <c>BankInventory::getItemForId</c> to retrieve an <c>ItemData</c> object for the item
	 * the user is going to purchase.</li>
	 * <li>Call <c>BankDebit::createTransactionForItem</c>, which creates a transaction and presents a
	 * purchase screen to the user. If the user authorizes the transaction, the transaction's state
	 * changes from <c>new</c> to <c>authorized</c>.</li>
	 * <li>Call <c>BankDebit::openTransaction</c>, which changes the transaction's state to <c>open</c>
	 * and places the user's funds into escrow.</li>
	 * <li>If the user's funds are successfully placed into escrow, deliver the virtual item to the
	 * user.</li>
	 * <li>Call <c>BankDebit::closeTransaction</c> to to move the user's funds from escrow to your
	 * account and change the transaction's state to <c>closed</c>.</li>
	 * </ol>
	 * <strong>Important</strong>: Your app must wait for the callback from each method and verify that
	 * the request succeeded before proceeding to the next step.
	 * <p>
	 * In Unity SDK 2.2 and later, iOS apps can also sell virtual items that can be purchased with cash.
	 * Use <c>BankPurchase</c> for cash purchases.
	 * </remarks>
	 */
	public partial class BankDebit {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class BankDebit {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class BankDebit {
		/**
		 * <summary> Callback for creating a transaction.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void createTransactionForItem_onCompleteCallback(CancelableAPIStatus status, Error error, Transaction transaction);

		/**
		 * <summary> Callback for placing the user's funds for a transaction in escrow.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void openTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);

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
		 * <summary> Callback for continuing to process a transaction created by an app server.</summary>
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

		public delegate void authorizeTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);

	}
#endregion

#region Static Methods
	public partial class BankDebit {
		/**
		 * <summary> Create a new transaction.</summary>
		 * <remarks>
		 * When your app calls this method, the following steps occur:
		 * <ol>
		 * <li>The app's inventory is checked to make sure the requested item exists, and a new
		 * transaction is created, with its state set to <c>new</c>.</li>
		 * <li>Mobage presents a screen that prompts the user to confirm the transaction.</li>
		 * <li>If the user decides not to proceed with the transaction, the transaction is automatically
		 * canceled. Otherwise, the transaction's state is set to <c>authorized</c>.</li>
		 * </ol>
		 * </remarks>
		 * <param name="itemToPurchase" cref="F:Mobage.ItemData">The item that the user is purchasing.</param>
		 * <param name="quantity" cref="F:System.Int32">The quantity of the item to purchase.</param>
		 * <param name="comment" cref="F:System.String">A comment on the transaction. On the US/worldwide platform, this comment is not currently displayed to users.</param>
		 * <param name="onComplete" cref="F:Mobage.CreateTransactionForItemOnCompleteCallback">
		 * Callback for creating a transaction.</param>
		 * 
		 */
		public static void createTransactionForItem(ItemData itemToPurchase, Int32 quantity, String comment, createTransactionForItem_onCompleteCallback onComplete)
		{
			_createTransactionForItem(itemToPurchase, quantity, comment, onComplete);
		}
		/**
		 * <summary> Place the user's funds into escrow prior to delivering the virtual item.</summary>
		 * <remarks>
		 * If this method succeeds, the transaction's state is set to <c>open</c>, and the virtual
		 * item should be delivered to the user.
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction for which funds will be placed in escrow.</param>
		 * <param name="onComplete" cref="F:Mobage.OpenTransactionOnCompleteCallback">
		 * Callback for placing the user's funds for a transaction in escrow.</param>
		 * 
		 */
		public static void openTransaction(Transaction transaction, openTransaction_onCompleteCallback onComplete)
		{
			_openTransaction(transaction, onComplete);
		}
		/**
		 * <summary> Close the transaction after delivering the virtual item.</summary>
		 * <remarks>
		 * If this method succeeds, the transaction's state is set to <c>closed</c>, and the
		 * user's funds are captured to your account.
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction to be closed.</param>
		 * <param name="onComplete" cref="F:Mobage.CloseTransactionOnCompleteCallback">
		 * Callback for closing a transaction.</param>
		 * 
		 */
		public static void closeTransaction(Transaction transaction, closeTransaction_onCompleteCallback onComplete)
		{
			_closeTransaction(transaction, onComplete);
		}
		/**
		 * <summary> Continue processing a transaction created by an app server using the <a href="https://developer.mobage.com/en/resources/rest_api">Mobage REST API</a>.</summary>
		 * <remarks>
		 * When you call this method, a confirmation dialog is presented to the user. If the user
		 * approves the transaction, the transaction's state is set to <c>authorized</c>.
		 * <p>
		 * If the user has insufficient funds for the transaction, the transaction's state is set to
		 * <c>canceled</c>.
		 * <p>
		 * <strong>Note</strong>: Before you call this method, you must use the transaction ID to
		 * retrieve a <c>Transaction</c> object. Call <c>BankDebit::getTransaction</c> to retrieve the
		 * object.
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction to continue processing.</param>
		 * <param name="onComplete" cref="F:Mobage.ContinueTransactionOnCompleteCallback">
		 * Callback for continuing to process a transaction created by an app server.</param>
		 * 
		 */
		public static void continueTransaction(Transaction transaction, continueTransaction_onCompleteCallback onComplete)
		{
			_continueTransaction(transaction, onComplete);
		}
		/**
		 * <summary> Mark the transaction as canceled, setting its state to <c>canceled</c> and releasing funds from escrow if applicable.</summary>
		 * <remarks>
		 * Call this method if any of the following occur:
		 * <ul>
		 * <li>The user cancels the transaction.</li>
		 * <li>The user does not have sufficient funds for the transaction.</li>
		 * <li>The virtual item cannot be delivered.</li>
		 * <li>An error occurs that prevents the transaction from being processed.</li>
		 * </ul>
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
		public static void authorizeTransaction(Transaction transaction, authorizeTransaction_onCompleteCallback onComplete)
		{
			_authorizeTransaction(transaction, onComplete);
		}
	}
#endregion


}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
