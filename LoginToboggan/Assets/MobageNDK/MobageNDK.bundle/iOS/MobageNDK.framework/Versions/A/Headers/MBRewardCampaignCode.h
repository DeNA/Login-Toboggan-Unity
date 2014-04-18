//
//  MBRewardCampaignCode.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 7/13/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBDataModel.h"

@protocol MBRewardCampaignCode <MBDataModel>

@property (nonatomic, readonly, retain) NSString * code;
@property (nonatomic, readonly, retain) NSString * channel;
@property (nonatomic, readonly, retain) NSString * marketingCopy;
@property (nonatomic, readonly, retain) NSString * iconUrl;
@property (nonatomic, readonly, assign) NSInteger redemptions;

@end
