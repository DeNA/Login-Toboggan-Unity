//
//  Score.h
//  mobage-ndk
//
//  Created by Toliver Chris on 7/4/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_Score_h
#define mobage_ndk_Score_h

#import "MBScore.h"
#import "RegionSpecifics.h"

#if MB_WW
#import "MB_WW_Score.h"
#define RegionSpecificScore MB_WW_Score

#elif MB_JP || MB_KR
#import "MB_JP_Score.h"
#define RegionSpecificScore MB_JP_Score

#elif MB_CN
#import "MB_CN_Score.h"
#define RegionSpecificScore MB_CN_Score
#else
// Invalid Configuration
#endif

@interface MBScore : RegionSpecificScore
@end
#undef RegionSpecificScore

#endif

