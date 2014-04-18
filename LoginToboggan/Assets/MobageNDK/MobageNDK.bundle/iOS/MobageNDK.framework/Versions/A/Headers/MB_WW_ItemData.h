//
//  MB_WW_ItemData.h
//  NGMobageUS
//
//  Created by Kinkoi Lo on 5/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBItemData.h"
#import "MB_WW_DataModel.h"

/**
 * @file MB_WW_ItemData.h
 * Model for information about a virtual item that can be purchased with cash or virtual
 * currency.
 * @since 2.2
 */

/**
 * Stores information about a virtual item that can be purchased with cash. Use the
 * <a href="https://developer.mobage.com/">Mobage Developer Portal</a> to set up your
 * app's virtual items.
 * <p>
 * If an item can be purchased for cash, the Mobage SDK retrieves the values for
 * <code>originPrice</code>, <code>originPriceLabel</code>, and <code>originCurrencyLabel</code>
 * from the App Store using the StoreKit framework.
 * <p>
 * If you want to retrieve an item for cash with <code>[MBBankInventory getItemForId]</code> or
 * <code>[MBBankInventory getItemForIds]</code>, you must set up the virtual item on both the
 * Mobage Developer Portal and iTunes Connect. Otherwise, the values returned for
 * <code>originPrice</code>, <code>originPriceLabel</code>, and <code>originCurrencyLabel</code>
 * are <code>0</code>, <code>nil</code>, and <code>nil</code> respectively.
 * <p>
 * <strong>Note</strong>: You only need to set up your virtual items on iTunes Connect when you
 * want to test your app. When you submit your app for publishing, Mobage will register your virtual
 * items on iTunes Connect for you, using your entries on the Mobage Developer Portal as a reference.
 * <p>
 * When setting up your app on the Apple Developer portal, and then subsequently on iTunes Connect,
 * do not use the Mobage bundle ID.
 * <p>
 * To obtain an <code>MB_WW_ItemData</code> object, you must cast an <code>MBItemData</code> object
 * to <code>MB_WW_ItemData</code>:
 * <pre>
 * [MBBankInventory getItemForId:itemId
 *             withCallbackQueue:dispatch_get_main_queue()
 *                    onComplete:^( MBSimpleAPIStatus status, MBError* error, MBItemData* itemData ) {
 *
 *     MB_WW_ItemData *item = (MB_WW_ItemData *)itemData;
 *     // ...
 * }];
 * </pre>
 * If the object's <code>itemForCash</code> property is set to <code>NO</code>, the item cannot be
 * purchased with cash.
 * <p>
 * <strong>Important</strong>: Do not import <code>MB_WW_ItemData.h</code> into your app directly.
 * This header file is imported automatically.
 * @since 2.2
 */
@protocol MB_WW_ItemData <MBItemData>

/**
 * Set to <code>YES</code> if the item can be purchased with cash or <code>NO</code> if the item can
 * be purchased with virtual currency.
 * @since 2.2
 */
@property (nonatomic, readonly) BOOL itemForCash;
/**
 * The item's cash price in the user's local currency, or <code>nil</code> if the item cannot be
 * purchased with cash.
 * <p>
 * The user's local currency is identified based on the user's Apple ID settings.
 * @since 2.2
 */
@property (nonatomic, readonly, assign) double originPrice;
/**
 * The item's cash price in the user's local currency, formatted based on the user's locale, or
 * <code>nil</code> if the item cannot be purchased for cash.
 * @since 2.2
 */
@property (nonatomic, readonly, strong) NSString* originPriceLabel;
/**
 * The symbol for the user's local currency, or <code>nil</code> if the item cannot be purchased for
 * cash.
 * @since 2.2
 */
@property (nonatomic, readonly, strong) NSString* originCurrencyLabel;
/*
 * Properties needed for ASC Item
 * @since 2.5.6
 */
@property (nonatomic, copy) NSString* currency;
@end

@interface MB_WW_ItemData : MB_WW_DataModel<MB_WW_ItemData>
@end
