//
//  Profanity.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_Profanity_h
#define mobage_ndk_Profanity_h

#include "RegionSpecifics.h"

#import "MBProfanity.h"

#if MB_WW
#import "MB_WW_Profanity.h"
#define RegionSpecificProfanity MB_WW_Profanity
#elif MB_JP || MB_KR
#import "MB_JP_Profanity.h"
#define RegionSpecificProfanity MB_JP_Profanity
#elif MB_CN
#import "MB_CN_Profanity.h"
#define RegionSpecificProfanity MB_CN_Profanity
#else
#error "Unknown or No Region Specified."
#endif

@interface MBProfanity : RegionSpecificProfanity
@end
#undef RegionSpecificProfanity

#endif
