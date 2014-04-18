//
//  Reward.h
//  MobageNDK
//
//  Created by Frederic Barthelemy on 8/8/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef MobageNDK_Reward_h
#define MobageNDK_Reward_h

#include "RegionSpecifics.h"

#import "MBReward.h"

#if MB_WW
#import "MB_WW_Reward.h"
#define RegionSpecificReward MB_WW_Reward
@interface MBReward : RegionSpecificReward
@end

#elif MB_JP || MB_KR
//#import "MB_JP_Reward.h"
//#define RegionSpecificReward MB_JP_Reward
#elif MB_CN
//#import "MB_CN_Reward.h"
//#define RegionSpecificReward MB_CN_Reward
#else
#error "Unknown or No Region Specified."
#endif

#undef RegionSpecificReward

#endif

