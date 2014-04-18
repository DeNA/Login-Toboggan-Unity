//
//  User.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_User_h
#define mobage_ndk_User_h

#include "RegionSpecifics.h"

#import "MBUser.h"

#if MB_WW
#import "MB_WW_User.h"
#define RegionSpecificUser MB_WW_User
#elif MB_JP || MB_KR
#import "MB_JP_User.h"
#define RegionSpecificUser MB_JP_User
#elif MB_CN
#import "MB_CN_User.h"
#define RegionSpecificUser MB_CN_User
#else
// Invalid Configuration
#endif

@interface MBUser : RegionSpecificUser
@end

#undef RegionSpecificUser

#include "MBCUser.h"
#endif
