//
//  MB_WW_BankInventory.h
//  NGMobageUS
//
//  Created by Kinkoi Lo on 5/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBBankInventory.h"

@protocol MB_WW_BankInventory <MBBankInventory>
+ (void) getASCItems:(dispatch_queue_t)cbQueue
          onComplete:( void (^)(MBSimpleAPIStatus status,
                                NSObject<MBError>* error,
                                NSArray* items) )completeCb;
@end


@interface MB_WW_BankInventory : NSObject <MB_WW_BankInventory>
@end
