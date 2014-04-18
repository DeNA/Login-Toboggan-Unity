//
//  Reward.h
//  mobage-ndk
//
//  Created by Thomas Chao on 7/6/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_RewardCampaign_h
#define mobage_ndk_RewardCampaign_h

#include "RegionSpecifics.h"

#import "MBRewardCampaign.h"

#if MB_WW
#import "MB_WW_RewardCampaign.h"
#define RegionSpecificReward MB_WW_RewardCampaign

@interface MBRewardCampaign : RegionSpecificReward
@end

#elif MB_JP || MB_KR
//#import "MB_JP_RewardCampaign.h"
//#define RegionSpecificReward MB_JP_RewardCampaign
#elif MB_CN
//#import "MB_CN_RewardCampaign.h"
//#define RegionSpecificReward MB_CN_RewardCampaign
#else
#error "Unknown or No Region Specified."
#endif

#undef RegionSpecificReward

#endif
