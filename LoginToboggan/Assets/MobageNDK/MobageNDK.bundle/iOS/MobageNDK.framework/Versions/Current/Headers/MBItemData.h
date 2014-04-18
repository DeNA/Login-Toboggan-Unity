//
//  MBItemData.h
//  mobage-ndk
//
//  Created by Andy Block on 3/15/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBDataModel.h"
#import "MBError.h"
#import "MBInterfaceEnums.h"

/**
 * @file MBItemData.h
 * Model for information about a virtual item.
 * @since 1.5
 */

/**
 * Stores information about a virtual item for your app. Before you create a Bank transaction, you
 * must call <code>MBBankInventory::getItemForId:withCallbackQueue:onComplete:</code> to retrieve an
 * <code>MBItemData</code> object for the item. If the user is buying the item with app-specific
 * purchased currency, you must then add the virtual item to an <code>MBBillingItem</code> object.
 * <p>
 * <strong>Note</strong>: This class provides a representation of a virtual item that you have
 * already set up for your app. You must use the <a href="https://developer.mobage.com/">Mobage
 * Developer Portal</a> to set up a virtual item.
 * <p>
 * To get information about a virtual item that can be purchased for cash (supported in Native SDK
 * 2.2 and later), you must obtain an <code>MBItemData</code> object for the item, then cast the
 * object to the type <code>MB_WW_ItemData</code>:
 * <pre>
 * [MBBankInventory getItemForId:itemId
 *             withCallbackQueue:dispatch_get_main_queue()
 *                    onComplete:^( MBSimpleAPIStatus status, MBError* error, MBItemData* itemData ) {
 *
 *     MB_WW_ItemData *item = (MB_WW_ItemData *)itemData;
 *     // ...
 * }];
 * </pre>
 * <strong>Important</strong>: Do not import <code>MB_WW_ItemData.h</code> into your app directly.
 * This header file is imported automatically.
 * @since 1.5
 */
@protocol MBItemData <MBDataModel>
/**
 * The item's unique ID.
 * @since 1.5
 */
@property (nonatomic, retain) NSString* itemId;
/**
 * The item's name.
 * @since 1.5
 */
@property (nonatomic, retain) NSString* name;
/**
 * A description of the item. <strong>Note</strong>: In version 2.1 and earlier, this property was
 * named <code>description</code>.
 * @since 2.2
 */
@property (nonatomic, retain) NSString* longDescription;
/**
 * The URL for an image of the item.
 * @since 1.5
 */
@property (nonatomic, retain) NSString* imageUrl;

/**
 * The item's price, represented in app-specific purchased currency. If the item can be purchased
 * for cash, this property contains the value <code>0</code>.
 * @since 1.5
 */
@property (nonatomic) int price;

// deprecated since 2.2
+ (id) item;

@end

typedef NSObject<MBItemData> MBItemDataProtocol;
