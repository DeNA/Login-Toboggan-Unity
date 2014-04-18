//
//  MBCBankPurchase.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCBANKPURCHASE_H_
#define MBCBANKPURCHASE_H_

#include "MBCStandardTypes.h"
#include "MBCBillingItem.h"
#include "MBCError.h"
#include "MBCItemData.h"
#include "MBCTransaction.h"

#ifdef __cplusplus
extern "C" {
#endif

#if MB_WW // whole interface/model is region-specific
#pragma mark Enums / Bitfields

	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCBankPurchase_createTransactionCallback
	 * @description 	 * Callback for creating a transaction.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankPurchase_createTransactionCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankPurchase_closeTransactionCallback
	 * @description 	 * Callback for closing a transaction.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankPurchase_closeTransactionCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankPurchase_continueTransactionCallback
	 * @description 	 * Callback for approving a transaction.
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankPurchase_continueTransactionCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankPurchase_cancelTransactionCallback
	 * @description 	 * Callback for canceling a transaction.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankPurchase_cancelTransactionCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankPurchase_getTransactionCallback
	 * @description 	 * Callback for retrieving information about a transaction.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankPurchase_getTransactionCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankPurchase_getUnfinishedItemTransactionsCallback
	 * @description 	 * Callback for retrieving unfinished transactions.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction_Array * transactions Array of unfinished transactions.			AUTORELEASED
	 */
	typedef void (*MBCBankPurchase_getUnfinishedItemTransactionsCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction_Array * transactions,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCBankPurchase_createTransaction
	 * @function
	 * @public
	 * @description 	 * Create a new transaction.
	 * When your app calls this method, the app's inventory is checked to make sure the requested
	 * item exists and can be purchased with cash. A new transaction is then created, with its state
	 * set to <c>Mobage::TransactionState:New</c>.
	 *
	 * @param MBCItemData *  itemToPurchase The item to purchase. Must be an item that can be purchased for cash.			AUTORELEASED
	 * @param int32_t  quantity The quantity of the item to purchase.			
	 * @param const char *  comment A comment on the transaction. On the Mobage West platform, this comment is not currently displayed to users.			AUTORELEASED
	 * @cb CreateTransactionOnCompleteCallback  onComplete 
		 * Callback for creating a transaction.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankPurchase_createTransaction(
										MBCItemData *  itemToPurchase,
										int32_t  quantity,
										const char *  comment,
										MBCBankPurchase_createTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankPurchase_closeTransaction
	 * @function
	 * @public
	 * @description 	 * Close the transaction after delivering the virtual item.
	 * If this method succeeds, the transaction's state is set to
	 * <c>BankPurchase::closeTransaction</c>, and a confirmation dialog informs the user that the
	 * virtual item has been delivered.
	 * <p>
	 * <strong>Note</strong>: Before you call this method, you must use the transaction ID to
	 * retrieve an updated <c>Transaction</c> object. Call <c>BankPurchase::getTransaction</c> to
	 * retrieve the object.
	 *
	 * @param MBCTransaction *  transaction The transaction to be closed.			AUTORELEASED
	 * @param const char *  invoiceId Mobage's invoice ID for the transaction. Your app server receives this ID when it opens the transaction.			AUTORELEASED
	 * @cb CloseTransactionOnCompleteCallback  onComplete 
		 * Callback for closing a transaction.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankPurchase_closeTransaction(
										MBCTransaction *  transaction,
										const char *  invoiceId,
										MBCBankPurchase_closeTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankPurchase_continueTransaction
	 * @function
	 * @public
	 * @description 	 * Prompt the user to approve a transaction.
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
	 *
	 * @param MBCTransaction *  transaction The transaction to be approved.			AUTORELEASED
	 * @cb ContinueTransactionOnCompleteCallback  onComplete 
		 * Callback for approving a transaction.			
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankPurchase_continueTransaction(
										MBCTransaction *  transaction,
										MBCBankPurchase_continueTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankPurchase_cancelTransaction
	 * @function
	 * @public
	 * @description 	 * Mark the transaction as canceled, setting its state to <c>Mobage::TransactionState:Canceled</c>.
	 * <p>
	 * <strong>Important</strong>: In version 2.3 and later, this method returns an error unless the
	 * transaction's state is <c>Mobage::TransactionState:New</c>. All other unfinished transactions
	 * must be completed by calling
	 * <c>BankPurchase::getUnfinishedItemTransactions</c>, then processing each of the
	 * unfinished transactions.
	 *
	 * @param MBCTransaction *  transaction The transaction to cancel.			AUTORELEASED
	 * @cb CancelTransactionOnCompleteCallback  onComplete 
		 * Callback for canceling a transaction.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankPurchase_cancelTransaction(
										MBCTransaction *  transaction,
										MBCBankPurchase_cancelTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankPurchase_getTransaction
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a transaction.
	 *
	 * @param const char *  transactionId The transaction's unique ID.			AUTORELEASED
	 * @cb GetTransactionOnCompleteCallback  onComplete 
		 * Callback for retrieving information about a transaction.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankPurchase_getTransaction(
										const char *  transactionId,
										MBCBankPurchase_getTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankPurchase_getUnfinishedItemTransactions
	 * @function
	 * @public
	 * @description 	 * Retrieve transactions that were interrupted and could not be completed (for example, because the user switched to a different app, and the device forced your app to shut down).
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
	 *
	 * @cb GetUnfinishedItemTransactionsOnCompleteCallback  onComplete 
		 * Callback for retrieving unfinished transactions.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction_Array * transactions Array of unfinished transactions.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankPurchase_getUnfinishedItemTransactions(
										MBCBankPurchase_getUnfinishedItemTransactionsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );

#endif // MB_WW -- whole interface/model is region-specific

#ifdef __cplusplus
}
#endif

#endif /* MBCBANKPURCHASE_H_ */

