//
// Bank.Inventory
//
#import "MBError.h"
#import "ItemData.h"
#import "MBInterfaceEnums.h"

/**
 * @file MBBankInventory.h
 * Retrieve information about virtual items.
 * @since 1.5
 */

/**
 * Provides access to information about virtual items. Use the
 * <a href="https://developer.mobage.com/">Mobage Developer Portal</a> to set up the virtual items
 * for your app.
 * @since 1.5
 */
@protocol MBBankInventory <NSObject>

/**
 * Retrieve information about a virtual item.
 * @param itemId The item's unique ID.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>itemData</code>: Information about the virtual item, or <code>nil</code> if the request
 * did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getItemForId:(NSString *)itemId
withCallbackQueue:(dispatch_queue_t)cbQueue 
	 onComplete:( void (^)( MBSimpleAPIStatus status, MBError* error, MBItemData* itemData ) )completeCb;


/**
 * Retrieve information about the virtual items with the specified item IDs.
 * @param itemIds An array of strings containing the IDs of virtual items.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>items</code>: An array of <code>MBItemData</code> objects with information about the
 * virtual items, or <code>nil</code> if the request did not succeed.</li>
 * </ul>
 * @since 2.3
 */
+(void)getItemsForIds:(NSArray *)itemIds withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:( void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSArray* items))completeCb;


#pragma mark - Deprecated
+(void)getItem:(NSString *)itemId
withCallbackQueue:(dispatch_queue_t)cbQueue 
	 onSuccess:( void (^)( MBItemData* itemData ) )successCB 
	   onError:( void (^)( MBError* error ) )errorCB;

@end

