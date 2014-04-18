//
//  MBBankIAPPayment.h
//  mobage-ndk
//
//  Created by Hang Wang on 11/18/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>
#import "MBError.h"
#import "MBInterfaceEnums.h"
#import "MBTransaction.h"
#import "MBProgressDialog.h"

typedef void (^MBBankPaymentBlock)(MBCancelableAPIStatus status, NSObject<MBError> *error, NSObject<MBTransaction> *transaction);

/**
 * INTERNAL FILE!!!!
 */
@interface MBBankInAppPayment : NSObject
@property (nonatomic, copy) NSString *currencyName;
@property (nonatomic, strong) NSObject<MBTransaction> *transaction;
@property (nonatomic, copy) MBBankPaymentBlock callback;
@property (nonatomic, retain) dispatch_queue_t queue;
@property (nonatomic, strong) NSMutableArray *cart;
// This is the property to be cached after sending payment request to iTunes Store
@property (atomic, strong) SKMutablePayment *skPayment;
// This is the identifier of iTunes Store response to a transaction.
@property (atomic, strong) MBProgressDialog* progressDialog;

@property (atomic, copy) NSString *transactionIdentifier;

- (void) cancelTxn;
- (void) finishTransaction:(SKPaymentTransaction *)transaction OriginPrice:(NSString *)originPrice OriginCurrencyName:(NSString *)originCurrencyName;
- (id)initWithCallback:(NSObject<MBTransaction>*)transaction willCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(MBBankPaymentBlock)completeCb;
- (void) purchaseProduct :(SKProduct*)product quantity:(NSInteger) quantity;
- (void) completeTransaction: (SKPaymentTransaction *)transaction;
- (void) failedTransaction: (SKPaymentTransaction *)transaction;
- (void) restoreTransaction: (SKPaymentTransaction *)transaction;
- (void) purchasingTransaction: (SKPaymentTransaction *)transaction;



@end