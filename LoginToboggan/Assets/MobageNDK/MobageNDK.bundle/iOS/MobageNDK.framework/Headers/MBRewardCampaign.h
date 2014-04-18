//
//  MBRewardCampaign.h
//  mobage-ndk
//
//  Created by Thomas Chao on 7/6/2012.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"
#import "MBDataModel.h"

@protocol MBRewardCampaignCode, MBUser;
/**
 * @file MBRewardCampaign.h
 * Returns lists of rewards that are configured by the game teams, along with the copy and viral channels need to get those rewards.
 */

@protocol MBRewardCampaign <MBDataModel>

@property (nonatomic, readonly, assign) NSInteger redemptions;

@property (nonatomic, readonly, assign) NSInteger startsAt; // UTC DateTime
@property (nonatomic, readonly, assign) NSInteger endsAt; // UTC DateTime
@property (nonatomic, readonly, assign) NSInteger expiresAt; // UTC DateTime

@property (nonatomic, readonly, retain) NSString * payload; // Arbitrary payload set in dev portal
@property (nonatomic, readonly, retain) NSArray * codes; // NSObject<MBRewardCampaignCode>*

/**
 * Returns the current user's available rewards.  Rewards are defined as the redeemable and verifiable incentives
 * for the promotion of the game or Mobage Service.
 * @param cbQueue The dispatch queue for the callback.
 * @cb onComplete
 * @cb-param status
 * @cb-param error
 * @cb-param array of campaigns
 */
+ (void) getActiveCampaignsWithCallbackQueue:(dispatch_queue_t)cbQueue 
                                  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *activeCampaigns))completeCb;


@end
