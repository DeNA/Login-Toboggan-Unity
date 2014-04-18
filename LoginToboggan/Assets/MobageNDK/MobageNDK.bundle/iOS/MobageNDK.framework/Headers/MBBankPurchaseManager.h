//
//  MBBankPurchaseManager.h
//  mobage-ndk
//
//  Created by Eric So on 11/18/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BillingItem.h"
#import "MBError.h"
#import "Transaction.h"
#import "MBInterfaceEnums.h"
#import "MBBankInAppPayment.h"
#import <StoreKit/StoreKit.h>

/**
 * INTERNAL FILE!!!!
 */

@interface MBBankPurchaseManager : NSObject

+ (MBBankPurchaseManager *) shareInstance;

-(void)fetchItemFromCache:(NSString *)itemId withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBItemData> * product)) completeCb;

-(void)performItemRequest:(NSString *)itemId withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, SKProduct *product)) completeCb;

-(void)performItemsRequest:(NSSet *)itemIds withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *products)) completeCb;

- (void)purchaseProductForCash :(NSString *)sku quantity:(NSInteger) quantity transaction: (NSObject<MBTransaction>*) transaction itemData: (SKProduct*) itemData onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> *  transaction))completeCb;

+(void)successPurchaseDialogCreditWithCallbackQueue:(BOOL)credit withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> *error)) completeCb;


+(void) failedDeliverySupportDialogWithCallbackQueue: (NSObject<MBTransaction>*)transaction withCallbackQueue:(dispatch_queue_t) cbQueue onComplete: ( void (^)( MBSimpleAPIStatus status, NSObject<MBError> * error, NSObject<MBTransaction> * transaction))completeCb;

+(void) failedDeliverySupportDialog:(NSObject<MBTransaction>*)transaction;

@end