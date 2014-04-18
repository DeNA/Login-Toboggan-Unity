//
// Bank.Debit
//
#import "BillingItem.h"
#import "MBError.h"
#import "Transaction.h"
#import "MBInterfaceEnums.h"

/**
 * @file MBBankDebit.h
 * Purchase virtual items using an app-specific purchased currency.
 * @since 1.5
 */

/**
 * Interface for purchasing virtual items using an app-specific purchased currency. To complete a
 * purchase, your app typically follows these steps:
 * <ol>
 * <li>Call <code>MBBankInventory::getItemForId:withCallbackQueue:onComplete:</code> to retrieve an
 * <code>MBItemData</code> object for the item the user is going to purchase.</li>
 * <li>Create an <code>MBBillingItem</code> object, and add the <code>MBItemData</code> object to
 * the <code>MBBillingItem</code>.</li>
 * <li>Call
 * <code>MBBankDebit::createTransactionForItem:quantity:comment:withCallbackQueue:onComplete:</code>, 
 * which creates a transaction and presents a purchase screen to the user. If the user authorizes
 * the purchase, the transaction's state changes from <code>kMBTransactionStateNew</code> to
 * <code>kMBTransactionStateAuthorized</code>.</li>
 * <li>Call <code>MBBankDebit::openTransaction:withCallbackQueue:onComplete:</code>, which
 * changes the transaction's state to <code>kMBTransactionStateOpen</code> and places the 
 * user's funds into escrow.</li>
 * <li>If the user's funds are successfully placed into escrow, deliver the virtual item to the
 * user.</li>
 * <li>Call <code>MBBankDebit::closeTransaction:withCallbackQueue:onComplete:</code> to
 * move the user's funds from escrow to your account and change the transaction's state to
 * <code>kMBTransactionStateClosed</code>.</li>
 * </ol>
 * <strong>Important</strong>: Your app must wait for the callback from each method and verify that
 * the request succeeded before proceeding to the next step.
 * <p>
 * In Native SDK 2.2 and later, users can also purchase virtual items with cash. Use
 * <code>MBBankPurchase</code> for cash purchases.
 * @since 1.5
 */
@protocol MBBankDebit  <NSObject>

/**
 * Create a new transaction. When your app calls this method, the following steps occur:
 * <ol>
 * <li>The app's inventory is checked to make sure the requested item exists, and a new transaction
 * is created, with its state set to <code>kMBTransactionStateNew</code>.</li>
 * <li>Mobage presents a screen that prompts the user to confirm the transaction.</li>
 * <li>If the user decides not to proceed with the transaction, the transaction is automatically
 * canceled. Otherwise, the transaction's state is set to
 * <code>kMBTransactionStateAuthorized</code>.</li>
 * </ol>
 * @param itemToPurchase The item data for the transaction.
 * @param quantity The quantity of the item data.
 * @param comment A comment on the transaction. On the US/worldwide platform, this comment is not
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
 * @since 2.0
 */
+(void)createTransactionForItem:(NSObject<MBItemData> *)itemToPurchase
					   quantity:(NSInteger)quantity
						comment:(NSString *)comment
			  withCallbackQueue:(dispatch_queue_t)cbQueue 
					 onComplete:( void (^)( MBCancelableAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> * transaction))completeCb;

/**
 * Place the user's funds into escrow prior to delivering the virtual item. If this method succeeds,
 * the transaction's state is set to <code>kMBTransactionStateOpen</code>, and the virtual item
 * should be delivered to the user.
 * @param transaction The transaction for which funds will be placed in escrow.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>transaction</code>: Information about the transaction, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)openTransaction:(NSObject<MBTransaction> *)transaction
     withCallbackQueue:(dispatch_queue_t)cbQueue 
			onComplete:( void (^)( MBSimpleAPIStatus status, NSObject<MBError> * error,NSObject<MBTransaction> *  transaction ) )completeCb;


/**
 * Close the transaction after delivering the virtual item. If this method succeeds, the
 * transaction's state is set to <code>kMBTransactionStateClosed</code>, and the user's funds are
 * captured to your account.
 * @param transaction The transaction to be closed.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>transaction</code>: Information about the transaction, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void)closeTransaction:(NSObject<MBTransaction> *)transaction
       withCallbackQueue:(dispatch_queue_t)cbQueue 
			  onComplete:( void (^)( MBSimpleAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> *  transaction ) )completeCb;



/**
 * Continue processing a transaction created by an app server using the
 * <a href="https://developer.mobage.com/en/resources/rest_api">Mobage REST API</a>. When you call
 * this method, a confirmation dialog is presented to the user. If the user approves the
 * transaction, the transaction's state is set to <code>kMBTransactionStateAuthorized</code>.
 * <p>
 * If the user has insufficient funds for the transaction, the transaction's state is set to
 * <code>kMBTransactionStateCanceled</code>.
 * <p>
 * <strong>Note</strong>: Before you call this method, you must use the transaction ID to retrieve
 * an <code>MBTransaction</code> object. Call
 * <code>MBBankDebit::getTransaction:withCallbackQueue:onComplete:</code> to retrieve the object.
 * @param transaction The transaction to continue processing.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>transaction</code>: Information about the transaction, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)continueTransaction:(NSObject<MBTransaction> *)transaction
         withCallbackQueue:(dispatch_queue_t)cbQueue 
				onComplete:( void (^)( MBCancelableAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> *  transaction ) )completeCb;



/**
 * Mark the transaction as canceled, setting its state to <code>kMBTransactionStateCanceled</code>
 * and releasing funds from escrow if applicable. Call this method if any of the following occur:
 * <ul>
 * <li>The user cancels the transaction.</li>
 * <li>The user does not have sufficient funds for the transaction.</li>
 * <li>The virtual item cannot be delivered.</li>
 * <li>An error occurs that prevents the transaction from being processed.</li>
 * </ul>
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
 * @since 2.0
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
 * @since 2.0
 */
+(void)getTransaction:(NSString*)transactionId
    withCallbackQueue:(dispatch_queue_t)cbQueue 
		   onComplete:( void (^)( MBSimpleAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> *  transaction ) )completeCb; 

// NOT CURRENTLY SUPPORTED
// Retrieves the user's transactions where the state is <code>new</code>, <code>authorized</code> or
// <code>open</code>.
// @param successCB Retrieves the transaction details.
// @param errorCB The callback interface that handles errors.
+(void)getPendingTransactionsWithCallbackQueue:(dispatch_queue_t)cbQueue 
                                     onSuccess:( void (^)( NSArray * transactions ) )successCB 
                                       onError:( void (^)( MBError* error ) )errorCB;

/** 
 * TODO
 * @since 2.5.7
 */
+(void) authorizeTransaction: (NSObject<MBTransaction> *) authTransaction
		   withCallbackQueue: (dispatch_queue_t) cbQueue
				  onComplete: (void (^) (MBSimpleAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction>* transaction)) completeCb;

#pragma mark - Deprecated
/**
 * Enumeration for reasons why a transaction was canceled.
 * @since 1.5
 */
// deprecated since 2.0
typedef enum {
    /**
     * The user canceled the transaction.
     * @since 1.5
     */
    kMBCancelReasonUserCanceled,
    /**
     * The user had insufficient funds for the transaction.
     * @since 1.5
     */
    kMBCancelReasonInsufficientFunds
} MBCancelReason;

// deprecated since 2.0
+(void)getTransaction:(NSString*)transactionId
    withCallbackQueue:(dispatch_queue_t)cbQueue 
			onSuccess:( void (^)( MBTransaction* transaction ) )successCB 
			  onError:( void (^)( MBError* error ) )errorCB;

// deprecated since 2.0
+(void)cancelTransaction:(NSString*)transactionId
       withCallbackQueue:(dispatch_queue_t)cbQueue 
			   onSuccess:( void (^)( MBTransaction* transaction ) )successCB 
				 onError:( void (^)( MBError* error ) )errorCB;

// deprecated since 2.0
+(void)continueTransaction:(NSString*)transactionId
         withCallbackQueue:(dispatch_queue_t)cbQueue 
				 onSuccess:( void (^)( MBTransaction* transaction ) )successCB 
				  onCancel:( void (^)() )cancelCB 
				   onError:( void (^)( NSString* transactionId, MBError* error ) )errorCB;

// deprecated since 2.0
+(void)closeTransaction:(NSString*)transactionId
	  withCallbackQueue:(dispatch_queue_t)cbQueue 
              onSuccess:( void (^)( MBTransaction* transaction ) )successCB 
                onError:( void (^)( MBError* error ) )errorCB;

// deprecated since 2.0
+(void)openTransaction:(NSString*)transactionId
     withCallbackQueue:(dispatch_queue_t)cbQueue 
             onSuccess:( void (^)( MBTransaction* transaction ) )successCB 
               onError:( void (^)( MBError* error ) )errorCB;

// deprecated since 2.0
+(void)createTransaction:(MBBillingItem *)billingItem
				 comment:(NSString *)comment
       withCallbackQueue:(dispatch_queue_t)cbQueue 
			   onSuccess:( void (^)( MBTransaction* transaction ) )successCB 
				onCancel:( void (^)() )cancelCB 
				 onError:( void (^)( NSString* transactionId, MBError* error ) )errorCB;
@end
