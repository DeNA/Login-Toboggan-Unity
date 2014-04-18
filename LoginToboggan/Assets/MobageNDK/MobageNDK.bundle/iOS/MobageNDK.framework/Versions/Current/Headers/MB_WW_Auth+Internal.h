//
//  MB_WW_Auth+Internal.h
//  NGMobageUS
//
//  Created by Maxwell Robinson on 6/22/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MB_WW_Auth.h"
#import "MB_G_MobageSession.h"

@protocol MB_WW_AuthInternal <MB_WW_Auth>

+ (void)deleteGuestCredentialsWithCallbackQueue:(dispatch_queue_t)callbackQueue
                                     onComplete:(void(^)(MBSimpleAPIStatus status, NSObject<MBError>* error))callback;

+ (void)getNumberOfDeviceAssociatedUsersWithCallbackQueue:(dispatch_queue_t)callbackQueue
                                               onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSDictionary* deviceAccounts))onComplete;
@end

@interface MB_WW_Auth () <MB_WW_AuthInternal>

@end

