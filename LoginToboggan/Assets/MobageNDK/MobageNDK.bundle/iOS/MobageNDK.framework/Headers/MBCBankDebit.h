//
//  MBCBankDebit.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCBANKDEBIT_H_
#define MBCBANKDEBIT_H_

#include "MBCStandardTypes.h"
#include "MBCBillingItem.h"
#include "MBCError.h"
#include "MBCItemData.h"
#include "MBCTransaction.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCBankDebit_createTransactionForItemCallback
	 * @description 	 * Callback for creating a transaction.
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankDebit_createTransactionForItemCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankDebit_openTransactionCallback
	 * @description 	 * Callback for placing the user's funds for a transaction in escrow.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankDebit_openTransactionCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankDebit_closeTransactionCallback
	 * @description 	 * Callback for closing a transaction.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankDebit_closeTransactionCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankDebit_continueTransactionCallback
	 * @description 	 * Callback for continuing to process a transaction created by an app server.
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankDebit_continueTransactionCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankDebit_cancelTransactionCallback
	 * @description 	 * Callback for canceling a transaction.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankDebit_cancelTransactionCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankDebit_getTransactionCallback
	 * @description 	 * Callback for retrieving information about a transaction.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankDebit_getTransactionCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	/**
	 * MBCBankDebit_authorizeTransactionCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param MBCTransaction * transaction 			AUTORELEASED
	 */
	typedef void (*MBCBankDebit_authorizeTransactionCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCTransaction * transaction,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCBankDebit_createTransactionForItem
	 * @function
	 * @public
	 * @description 	 * Create a new transaction.
	 * When your app calls this method, the following steps occur:
	 * <ol>
	 * <li>The app's inventory is checked to make sure the requested item exists, and a new
	 * transaction is created, with its state set to <c>new</c>.</li>
	 * <li>Mobage presents a screen that prompts the user to confirm the transaction.</li>
	 * <li>If the user decides not to proceed with the transaction, the transaction is automatically
	 * canceled. Otherwise, the transaction's state is set to <c>authorized</c>.</li>
	 * </ol>
	 *
	 * @param MBCItemData *  itemToPurchase The item that the user is purchasing.			AUTORELEASED
	 * @param int32_t  quantity The quantity of the item to purchase.			
	 * @param const char *  comment A comment on the transaction. On the US/worldwide platform, this comment is not currently displayed to users.			AUTORELEASED
	 * @cb CreateTransactionForItemOnCompleteCallback  onComplete 
		 * Callback for creating a transaction.			
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankDebit_createTransactionForItem(
										MBCItemData *  itemToPurchase,
										int32_t  quantity,
										const char *  comment,
										MBCBankDebit_createTransactionForItemCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankDebit_openTransaction
	 * @function
	 * @public
	 * @description 	 * Place the user's funds into escrow prior to delivering the virtual item.
	 * If this method succeeds, the transaction's state is set to <c>open</c>, and the virtual
	 * item should be delivered to the user.
	 *
	 * @param MBCTransaction *  transaction The transaction for which funds will be placed in escrow.			AUTORELEASED
	 * @cb OpenTransactionOnCompleteCallback  onComplete 
		 * Callback for placing the user's funds for a transaction in escrow.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankDebit_openTransaction(
										MBCTransaction *  transaction,
										MBCBankDebit_openTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankDebit_closeTransaction
	 * @function
	 * @public
	 * @description 	 * Close the transaction after delivering the virtual item.
	 * If this method succeeds, the transaction's state is set to <c>closed</c>, and the
	 * user's funds are captured to your account.
	 *
	 * @param MBCTransaction *  transaction The transaction to be closed.			AUTORELEASED
	 * @cb CloseTransactionOnCompleteCallback  onComplete 
		 * Callback for closing a transaction.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankDebit_closeTransaction(
										MBCTransaction *  transaction,
										MBCBankDebit_closeTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankDebit_continueTransaction
	 * @function
	 * @public
	 * @description 	 * Continue processing a transaction created by an app server using the <a href="https://developer.mobage.com/en/resources/rest_api">Mobage REST API</a>.
	 * When you call this method, a confirmation dialog is presented to the user. If the user
	 * approves the transaction, the transaction's state is set to <c>authorized</c>.
	 * <p>
	 * If the user has insufficient funds for the transaction, the transaction's state is set to
	 * <c>canceled</c>.
	 * <p>
	 * <strong>Note</strong>: Before you call this method, you must use the transaction ID to
	 * retrieve a <c>Transaction</c> object. Call <c>BankDebit::getTransaction</c> to retrieve the
	 * object.
	 *
	 * @param MBCTransaction *  transaction The transaction to continue processing.			AUTORELEASED
	 * @cb ContinueTransactionOnCompleteCallback  onComplete 
		 * Callback for continuing to process a transaction created by an app server.			
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCTransaction * transaction Information about the transaction, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankDebit_continueTransaction(
										MBCTransaction *  transaction,
										MBCBankDebit_continueTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankDebit_cancelTransaction
	 * @function
	 * @public
	 * @description 	 * Mark the transaction as canceled, setting its state to <c>canceled</c> and releasing funds from escrow if applicable.
	 * Call this method if any of the following occur:
	 * <ul>
	 * <li>The user cancels the transaction.</li>
	 * <li>The user does not have sufficient funds for the transaction.</li>
	 * <li>The virtual item cannot be delivered.</li>
	 * <li>An error occurs that prevents the transaction from being processed.</li>
	 * </ul>
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
	void MBCBankDebit_cancelTransaction(
										MBCTransaction *  transaction,
										MBCBankDebit_cancelTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankDebit_getTransaction
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
	void MBCBankDebit_getTransaction(
										const char *  transactionId,
										MBCBankDebit_getTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankDebit_authorizeTransaction
	 * @function
	 * @public
	 * @description 
	 *
	 * @param MBCTransaction *  transaction 			AUTORELEASED
	 * @cb AuthorizeTransactionOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param MBCTransaction * transaction 			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankDebit_authorizeTransaction(
										MBCTransaction *  transaction,
										MBCBankDebit_authorizeTransactionCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCBANKDEBIT_H_ */

