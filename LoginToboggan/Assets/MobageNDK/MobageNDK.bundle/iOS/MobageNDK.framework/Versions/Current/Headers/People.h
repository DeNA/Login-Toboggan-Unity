//
//  People.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/11/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_People_h
#define mobage_ndk_People_h

#include "RegionSpecifics.h"

#import "MBPeople.h"

#if MB_WW
#import "MB_WW_People.h"
#define RegionSpecificPeople MB_WW_People
#elif MB_JP || MB_KR
#import "MB_JP_People.h"
#define RegionSpecificPeople MB_JP_People
#elif MB_CN
#import "MB_CN_People.h"
#define RegionSpecificPeople MB_CN_People
#else
#error "Unknown or No Region Specified."
#endif

@interface MBPeople : RegionSpecificPeople
@end
#undef RegionSpecificPeople

#endif
