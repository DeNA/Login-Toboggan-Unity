//
//  BalanceButton.h
//  mobage-ndk
//
//  Created by Eric So on 7/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_BalanceButton_h
#define mobage_ndk_BalanceButton_h

#include "RegionSpecifics.h"

#import "MBBalanceButton.h"

#if MB_WW
#import "MB_WW_BalanceButton.h"
#define RegionSpecificBalanceButton MB_WW_BalanceButton
#elif MB_JP || MB_KR
#import "MB_JP_BalanceButton.h"
#define RegionSpecificBalanceButton MB_JP_BalanceButton
#elif MB_CN
#import "MB_CN_BalanceButton.h"
#define RegionSpecificBalanceButton MB_CN_BalanceButton
#else
#error "Unknown or No Region Specified."
#endif

@interface MBBalanceButton : RegionSpecificBalanceButton

@end

#undef RegionSpecificBalanceButton

#endif