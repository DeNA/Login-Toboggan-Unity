//
//  RewardCampaignCode.h
//  mobage-ndk
//
//  Created by Thomas Chao on 7/6/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_RewardCampaignCode_h
#define mobage_ndk_RewardCampaignCode_h

#include "RegionSpecifics.h"

#import "MBRewardCampaignCode.h"

#if MB_WW
#import "MB_WW_RewardCampaignCode.h"
#define RegionSpecificRewardCode MB_WW_RewardCampaignCode

@interface MBRewardCampaignCode : RegionSpecificRewardCode
@end

#elif MB_JP || MB_KR
// #import "MB_JP_RewardCampaignCode.h"
// #define RegionSpecificRewardCode MB_JP_RewardCampaignCode
#elif MB_CN
// #import "MB_CN_RewardCampaignCode.h"
// #define RegionSpecificRewardCode MB_CN_RewardCampaignCode
#else
#error "Unknown or No Region Specified."
#endif

#undef RegionSpecificRewardCode

#endif
