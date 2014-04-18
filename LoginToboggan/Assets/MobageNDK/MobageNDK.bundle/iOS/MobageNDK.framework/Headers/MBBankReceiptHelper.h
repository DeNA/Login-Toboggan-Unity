//
//  MBBankReceiptHelper.h
//  mobage-ndk
//
//  Created by Eric So on 11/27/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <StoreKit/StoreKit.h>
#import "Transaction.h"
#import "MB_G_BlocksUtilities.h"
#import "MBInterfaceEnums.h"

/**
 * INTERNAL FILE!!!!
 */
@interface MBBankReceiptHelper : NSObject

+ (void)removeTransactionFromCache:(NSString*) transactionId;
+ (void)cacheFailedTransaction:(NSMutableDictionary *)transactionPostBody;
+ (void)retryOrphanedTxns:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSMutableArray<MBTransaction>* transactions)) completeCb;

+(void) sendReceiptToServer:(SKPaymentTransaction *)iTunesTransaction
				transaction:(MBTransaction *)transaction
				originPrice:(NSString *)originPrice
		 originCurrencyName:(NSString *)originCurrencyName
		  withCallbackQueue:(dispatch_queue_t)cbQueue
				 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, MBTransaction *transaction)) completeCb;


@end