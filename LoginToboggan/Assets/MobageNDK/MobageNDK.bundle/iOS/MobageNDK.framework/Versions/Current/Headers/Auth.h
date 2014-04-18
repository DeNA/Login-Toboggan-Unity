//
//  Auth.h
//  mobage-ndk
//
//  Created by Manabu Sato on 3/17/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_Auth_h
#define mobage_ndk_Auth_h

#include "RegionSpecifics.h"

#import "MBAuth.h"

#if MB_WW
#import "MB_WW_Auth.h"
#import "MB_WW_Auth+Internal.h"
#define RegionSpecificAuth MB_WW_Auth
#elif MB_JP || MB_KR
#import "MB_JP_Auth.h"
#import "MB_JP_Auth+Internal.h"
#define RegionSpecificAuth MB_JP_Auth
#elif MB_CN
#import "MB_CN_Auth.h"
#define RegionSpecificAuth MB_CN_Auth
#else
#error "Unknown or No Region Specified."
#endif

@interface MBAuth : RegionSpecificAuth
@end
#undef RegionSpecificAuth

#endif
