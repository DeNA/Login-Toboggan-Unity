//
//  MBBankUtil.h
//  mobage-ndk
//
//  Created by Eric So on 11/15/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>

@interface MBBankUtil : NSObject

+ (NSString *) getOriginPriceInString:(SKProduct *) product;
+ (NSString *) getOriginPriceInStringWithoutSpecialCharacters:(SKProduct *) product;
+ (NSString *) getOriginCurrencyName:(SKProduct *) product;
+ (NSString *) bankReachabilityForInternetConnection;

@end
