//
//  Blacklist.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/14/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_Blacklist_h
#define mobage_ndk_Blacklist_h

#include "RegionSpecifics.h"

#import "MBBlacklist.h"

#if MB_WW
#import "MB_WW_Blacklist.h"
#define RegionSpecificBlacklist MB_WW_Blacklist
#elif MB_JP || MB_KR
#import "MB_JP_Blacklist.h"
#define RegionSpecificBlacklist MB_JP_Blacklist
#elif MB_CN
#import "MB_CN_Blacklist.h"
#define RegionSpecificBlacklist MB_CN_Blacklist
#else
#error "Unknown or No Region Specified."
#endif

@interface MBBlacklist : RegionSpecificBlacklist
@end
#undef RegionSpecificBlacklist

#endif
