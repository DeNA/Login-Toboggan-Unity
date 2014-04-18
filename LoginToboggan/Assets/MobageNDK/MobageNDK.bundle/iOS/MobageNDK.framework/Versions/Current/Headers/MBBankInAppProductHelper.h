//
//  MBBankInAppProductHelper.h
//  NGMobageUS
//
//  Created by Eric So on 11/13/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>
#import "MBMobage+Internal.h"

/**
 * INTERNAL FILE!!!!
 */
@interface MBBankInAppProductHelper : NSObject <SKProductsRequestDelegate>

@property (nonatomic, strong) SKProductsRequest *productsRequest;
@property (nonatomic, strong) void (^callback)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray * products);
@property (nonatomic, strong) NSSet * identifiers;
@property (nonatomic, retain) dispatch_queue_t queue;

- (id)initWithProductIdentifiers:(NSSet *)productIdentifiers;
- (void)requestProductsWithCallbackQueue:(dispatch_queue_t)cbQueue
							  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray * products)) completeCb;

@end