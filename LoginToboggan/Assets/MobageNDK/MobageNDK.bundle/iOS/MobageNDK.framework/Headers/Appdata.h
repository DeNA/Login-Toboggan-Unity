//
//  Appdata.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/3/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_Appdata_h
#define mobage_ndk_Appdata_h

#include "RegionSpecifics.h"

#import "MBAppdata.h"

#if MB_WW
#import "MB_WW_Appdata.h"
#define RegionSpecificAppdata MB_WW_Appdata
#elif MB_JP || MB_KR
#import "MB_JP_Appdata.h"
#define RegionSpecificAppdata MB_JP_Appdata
#elif MB_CN
#import "MB_CN_Appdata.h"
#define RegionSpecificAppdata MB_CN_Appdata
#else
#error "Unknown or No Region Specified."
#endif

@interface MBAppdata : RegionSpecificAppdata
@end
#undef RegionSpecificAppdata

#endif
