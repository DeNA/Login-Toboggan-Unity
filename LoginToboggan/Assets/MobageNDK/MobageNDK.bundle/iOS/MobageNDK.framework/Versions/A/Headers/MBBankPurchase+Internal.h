//
//  MBBankPurchase+Internal.h
//  mobage-ndk
//
//  Created by Eric So on 11/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Transaction.h"
#import "MBInterfaceEnums.h"
#import <StoreKit/StoreKit.h>


@protocol MBBankPurchaseInternal

+(void)purchaseFromItunesStore:(NSString*)itemId
                      quantity:(NSInteger)quantity
                   transaction:(NSObject<MBTransaction> *) transaction
                      itemData:(SKProduct *) itemData
                    oncomplete:(void (^)( MBCancelableAPIStatus status, NSObject<MBError>* error, NSObject<MBTransaction> *transaction) )completeCb;

+(void)getItemFromItunesStore:(NSString *) itemId
			withCallbackQueue:(dispatch_queue_t)cbQueue
				   onComplete:( void (^)( MBSimpleAPIStatus status, NSObject<MBError> * error, SKProduct*  product ) )completeCb;

@end

typedef NSObject<MBBankPurchaseInternal> MBBankPurchaseInternal;