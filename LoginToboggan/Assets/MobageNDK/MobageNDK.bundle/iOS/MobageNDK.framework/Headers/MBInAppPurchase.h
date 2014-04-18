//
//  MBInAppPurchase.h
//  mobage-ndk
//
//  Created by Kinkoi Lo on 3/13/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>
#import "MBBankInAppPayment.h"

@protocol MBInAppPurchaseDelegate <NSObject>

- (void) finishTxn: (SKPaymentTransaction *)transaction OriginPrice:(NSString *)originPrice OriginCurrencyName:(NSString *)originCurrencyName;
//- (void) retryTxn:(NSDictionary *)txnPostBody; 
- (void) cancelTxn;
- (void) productSetInfo: (NSDictionary *) skuSetInfo;

@end

@protocol MBInAppPurchaseDialogDelegate <NSObject>

- (void) hideDialog;

@end

/**
 * INTERNAL FILE!!!!
 */
@interface MBInAppPurchase : NSObject <SKRequestDelegate, SKPaymentTransactionObserver, MBInAppPurchaseDialogDelegate>
{
}

@property (nonatomic, assign) id<MBInAppPurchaseDelegate> delegate;
@property (nonatomic, copy) NSString *storvisitid;
@property (nonatomic, copy) NSString *currencyName;

// The is a cache object which is used to keep the MBTransaction object for the response from iTunes account for MBBankInAppPayment
@property(atomic, strong) NSMutableArray *inAppPaymentArray;

+ (MBInAppPurchase *) share;
- (void) purchaseProduct:(NSString *)productId amt: (NSString *) price itemamt: (NSString *) value cur: (int) currency;
- (void) getProductSetInfo:(NSSet* ) identifiers;
- (void) getCachedProductSetInfoWith:(SKProductsRequest*)request response:(SKProductsResponse*)response;
- (void) setStorvisitid: (NSString *) uid;

- (void) completeTransaction: (SKPaymentTransaction *)transaction;
- (void) failedTransaction: (SKPaymentTransaction *)transaction;
- (void) restoreTransaction: (SKPaymentTransaction *)transaction;
- (void) purchasingTransaction: (SKPaymentTransaction *)transaction;
- (NSString *) readTransactionReceipt: (NSData *) receipt;

// To handle the failed transaction in cache
+ (void)retryOrphanedTxns;
+ (void)removeFailedTransaction:(NSMutableDictionary *)transactionPostBody;
+ (void)cacheFailedTransaction:(NSMutableDictionary *)transactionPostBody;

// To handle the temp cache of the payment object for MBBankInAppPayment
- (void)removeInAppPaymentCacheObject:(MBBankInAppPayment *)inAppPayment;

- (void)handleIAPResponseForRequest:(SKProductsRequest*)request response:(SKProductsResponse*)response;
@end