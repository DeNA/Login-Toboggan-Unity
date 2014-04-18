//
//  MBBillingItem.h
//  mobage-ndk
//
//  Created by Andy Block on 3/15/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBDataModel.h"
#import "MBInterfaceEnums.h"
#import "ItemData.h"

/**
 * @file MBBillingItem.h
 * Model for information about a billing item for a transaction.
 * @since 1.5
 */

/**
 * Stores information about a billing item for a transaction. You must create an
 * <code>MBBillingItem</code> object before you create a new Bank transaction.
 * @since 1.5
 */
@protocol MBBillingItem <MBDataModel>
/**
 * Information about the the virtual item that will be purchased. Call
 * <code>MBBankInventory::getItemForId:withCallbackQueue:onComplete:</code> to retrieve an
 * <code>MBItemData</code> object for the virtual item.
 * @since 1.5
 */
@property (nonatomic, retain) NSObject<MBItemData>* item;
/**
 * The quantity of the virtual item being purchased.
 * @since 1.5
 */
@property (nonatomic, assign) int quantity;

/**
 * Create a billing item for a purchase.
 * @since 1.5
 */
+ (id) billingItem;

@end

typedef NSObject<MBBillingItem> MBBillingItemProtocol;
