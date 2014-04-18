//
//  MB_WW_People.h
//  NGMobageUS
//
//  Created by Henrik Johansson on 3/11/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBPeople.h"
#import "MBError.h"
#import "MBInterfaceEnums.h"

@protocol MB_WW_People <MBPeople>

+ (void)sendFriendInviteToUserIfPossible:(NSString*) gamerTag
                       withCallbackQueue:(dispatch_queue_t) queue
                              onComplete:(void(^)(MBSimpleAPIStatus, NSObject<MBError> *)) callback;

@end

@interface MB_WW_People : NSObject <MB_WW_People>

@end
