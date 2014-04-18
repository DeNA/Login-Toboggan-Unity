//
//  MBReward.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 8/8/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"

@protocol MBUser;

@protocol MBReward <NSObject>

/**
 *
 * Redeems a specified award.  If the reward has not been claimed by this user, then the user will be successfully
 * awarded the appropriate item based upon the developer portal configuration for this reward.
 * @param code, the string code of the reward
 * @param cbQueue The dispatch queue for the callback.
 * @cb onComplete
 * @cb-param status
 * @cb-param error
 * @cb-param User inviter 
 * @cb-param Integer redemptions
 * @cb-param String payload
 */
+ (void) redeemRewardCode:(NSString *)code
        withCallbackQueue:(dispatch_queue_t)cbQueue 
               onComplete:(void (^)(MBSimpleAPIStatus status,
									NSObject<MBError> *error,
									NSObject<MBUser> *inviter,
									NSInteger redemptions,
									NSString * payload))completeCb;

@end
