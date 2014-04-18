//
//  GameLeaderboard.h
//  mobage-ndk
//
//  Created by Toliver Chris on 7/4/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_GameLeaderboard_h
#define mobage_ndk_GameLeaderboard_h

#import "RegionSpecifics.h"

#import "MBGameLeaderboard.h"

#if MB_WW
#import "MB_WW_GameLeaderboard.h"
#define RegionSpecificGameLeaderboard MB_WW_GameLeaderboard

#elif MB_JP || MB_KR
#import "MB_JP_GameLeaderboard.h"
#define RegionSpecificGameLeaderboard MB_JP_GameLeaderboard

#elif MB_CN
#import "MB_CN_GameLeaderboard.h"
#define RegionSpecificGameLeaderboard MB_CN_GameLeaderboard
#else
// Invalid Configuration
#endif

@interface MBGameLeaderboard : RegionSpecificGameLeaderboard
@end
#undef RegionSpecificGameLeaderboard


#endif
