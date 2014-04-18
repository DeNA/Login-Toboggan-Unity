//
//  MBBankPurchase.h
//  mobage-ndk
//
//  Created by Eric So on 11/12/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

//
// Bank.MBBankPurchase
//
#import "BillingItem.h"
#import "MBError.h"
#import "Transaction.h"
#import "MBInterfaceEnums.h"
#import <StoreKit/StoreKit.h>

/**
 * @file MBBankPurchase.h
 * Purchase virtual items using cash.
 * @since 2.2
 */

/**
 * Interface for purchasing virtual items using cash. The user must sign into an App Store account
 * to approve the purchase.
 * <p>
 * To complete a purchase for cash, your app typically follows these steps:
 * <ol>
 * <li>Call <code>MBBankInventory::getItemForId:withCallbackQueue:onComplete:</code> to retrieve an
 * <code>MBItemData</code> object for the item the user is going to purchase.</li>
 * <li>Call
 * <code>MBBankPurchase::createTransaction:quantity:comment:withCallbackQueue:onComplete:</code>,
 * which creates a transaction and sets its state to <code>kMBTransactionStateNew</code>.</li>
 * <li>Call <code>MBBankPurchase::continueTransaction:withCallbackQueue:onComplete:</code>, which
 * presents a confirmation dialog to the user. If the user authorizes the purchase, then Apple
 * charges the user's account, and the transaction's state changes to
 * <code>kMBTransactionStateAuthorized</code>.</li>
 * <li>
 * <p>Notify your app server that it must use the Mobage REST API to open the transaction. When the
 * app server opens the transaction, the transaction's state changes to
 * <code>kMBTransactionStateOpen</code>. In addition, the app server receives the invoice ID for
 * the transaction; you must send this ID to Mobage when closing the transaction.
 * <strong>Important</strong>: Do not share the invoice ID with the user.</p>
 * <p><strong>Note</strong>: When a user is purchasing a virtual item for cash, your app server must
 * open the transaction. Opening the transaction from the client is not supported.</p>
 * </li>
 * <li>Wait for your app server to deliver the virtual item to the user. After the app server
 * delivers the item, it must send the invoice ID to the client and notify the client that the
 * transaction is ready to close.</li>
 * <li>Call <code>MBBankPurchase::closeTransaction:invoiceId:withCallbackQueue:onComplete:</code> to
 * finalize the transaction and change its state to <code>kMBTransactionStateClosed</code>. A
 * confirmation dialog informs the user that the virtual item has been delivered. You must close the
 * transaction so that the user's funds will be transferred to your account.</li>
 * </ol>
 * <strong>Important</strong>: Your app must wait for the callback from each method and verify that
 * the request succeeded before proceeding to the next step.
 * <p>
 * In some cases, your app may be interrupted while it is in the middle of processing a cash
 * purchase (for example, if the user switches to a different app, and the device forces your app to
 * shut down). The Native SDK maintains an on-device cache of these unfinished transactions. When
 * your app starts, it must check for unfinished cash transactions by calling
 * <code>MBBankPurchase::getUnfinishedItemTransactionsWithCallbackQueue:onComplete:</code>. Your
 * app can then process these transactions appropriately based on their current state.
 * <p>
 * <strong>Warning</strong>: If your app does not check for unfinished transactions,
 * users may be charged for items that were never delivered.
 * @since 2.2
 */
@protocol MBBankPurchase  <NSObject>

/**
 * Create a new transaction. When your app calls this method, the app's inventory is checked to make
 * sure the requested item exists and can be purchased with cash. A new transaction is then created,
 * with its state set to <code>kMBTransactionStateNew</code>.
 * @param itemToPurchase The item to purchase. Must be an item that can be purchased for cash.
 * @param quantity The quantity of the item to purchase.
 * @param comment A comment on the transaction. On the Mobage West platform, this comment is not
 *      currently displayed to users.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>transaction</code>: Information about the transaction, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.2
 */
+(void)createTransaction:(NSObject<MBItemData> *)itemToPurchase
					   quantity:(NSInteger)quantity
						comment:(NSString *)comment
			  withCallbackQueue:(dispatch_queue_t)cbQueue
					 onComplete:(void (^)( MBSimpleAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> * transaction))completeCb;

/**
 * Close the transaction after delivering the virtual item. If this method succeeds, the
 * transaction's state is set to <code>kMBTransactionStateClosed</code>.
 * @param transaction The transaction to be closed.
 * @param invoiceId The Mobage invoice ID for the transaction. Your app server receives this ID when it
 *      opens the transaction.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>transaction</code>: Information about the transaction, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.2
 */
+ (void)closeTransaction:(NSObject<MBTransaction> *)transaction
			   invoiceId:(NSString *)invoiceId
       withCallbackQueue:(dispatch_queue_t)cbQueue
			  onComplete:( void (^)( MBSimpleAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> *  transaction ) )completeCb;


/**
 * Prompt the user to approve a transaction. Call this method after creating the transaction.
 * <p>
 * When you call this method, a confirmation dialog is presented to the user. If the user approves
 * the transaction, Apple charges the user for the purchase, and the transaction's state is set to 
 * <code>kMBTransactionStateAuthorized</code>. Your app server can then use the Mobage REST API to
 * open the transaction.
 * <p>
 * <strong>Important</strong>: If an error occurs after the transaction is authorized, you should
 * cancel the transaction from the client if possible. See the <a href="#">overview</a> for more
 * information.
 * <p>
 * If the user does not approve the transaction, the transaction's state is set to
 * <code>kMBTransactionStateCanceled</code>.
 * <p>
 * <strong>Note</strong>: If your app server created the transaction, you must use the transaction
 * ID to retrieve an <code>MBTransaction</code> object before you call this method. Call
 * <code>MBBankPurchase::getTransaction:withCallbackQueue:onComplete:</code> to retrieve the object.
 * @param transaction The transaction to be approved.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>transaction</code>: Information about the transaction, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.2
 */
+(void)continueTransaction:(NSObject<MBTransaction> *)transaction
		 withCallbackQueue:(dispatch_queue_t)cbQueue
				onComplete:( void (^)( MBCancelableAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> *  transaction ) )completeCb;


/**
 * Mark the transaction as canceled, setting its state to <code>kMBTransactionStateCanceled</code>.
 * <p>
 * <strong>Important</strong>: In version 2.3 and later, this method returns an error unless the
 * transaction's state is <code>kMBTransactionStateNew</code>. All other unfinished transactions
 * must be completed by calling
 * <code>MBBankPurchase::getUnfinishedItemTransactionsWithCallbackQueue:onComplete:</code>, then
  processing each of the unfinished transactions.
 * @param transaction The transaction to cancel.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>transaction</code>: Information about the transaction, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.2
 */
+(void)cancelTransaction:(NSObject<MBTransaction> *)transaction
       withCallbackQueue:(dispatch_queue_t)cbQueue
			  onComplete:( void (^)( MBSimpleAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> *  transaction ) )completeCb;

/**
 * Retrieve information about a transaction.
 * @param transactionId The transaction's unique ID.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>transaction</code>: Information about the transaction, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.2
 */
+(void)getTransaction:(NSString*)transactionId
    withCallbackQueue:(dispatch_queue_t)cbQueue
		   onComplete:( void (^)( MBSimpleAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> *  transaction ) )completeCb;


/**
 * Retrieve transactions that were interrupted and could not be completed (for example, because the
 * user switched to a different app, and the device forced your app to shut down). The Native SDK
 * maintains an on-device cache of these unfinished transactions. When your app starts, it must
 * check for unfinished transactions and process them appropriately based on their current state.
 * <p>
 * <strong>Warning</strong>: If your app does not check for unfinished transactions,
 * users may be charged for items that were never delivered.
 * <p>
 * The following example shows how to use this method to process unfinished transactions.
 * @code
 * // Check for unfinished cash purchases.
 * [MBBankPurchase getUnfinishedItemTransactionsWithCallbackQueue:dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0)
 *                                                     onComplete:(^( MBSimpleAPIStatus status, NSObject<MBError> *error, 
 *                                                                NSMutableArray<MBTransaction>* transactions ){
 *
 *     for (MBTransaction *transaction in transactions) {
 *         NSString *invoiceId;
 *         if (transaction.state == MBTransactionStateOpen) {
 *             // Retrieve the invoice ID from your app server. The app server
 *             // gets the invoice ID when it opens the transaction.
 *         } else {
 *             // Use your app server to open the transaction.
 *         }
 *
 *         // Deliver the item to the user.
 *
 *         // After delivering the item, close the transaction.
 *         [MBBankPurchase closeTransaction:transaction
 *                                invoiceId:invoiceId
 *                        withCallbackQueue:dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0)
 *                               onComplete:^( MBSimpleAPIStatus status, NSObject<MBError>* error,
 *                                          NSObject<MBTransaction>* transaction ){
 *
 *             if (status == MBSimpleAPIStatusSuccess) {
 *                 // Display a success message.
 *             } else {
 *                 // Display an error message.
 *             }
 *         }];
 *     }
 * })];
 * @endcode
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>transactions</code>: Information about the unfinished transactions, or <code>nil</code>
 * if the request did not succeed.</li>
 * </ul>
 * @since 2.2.1
 */
+(void)getUnfinishedItemTransactionsWithCallbackQueue:(dispatch_queue_t)cbQueue
						 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSMutableArray<MBTransaction>* transactions))completeCb;

@end
