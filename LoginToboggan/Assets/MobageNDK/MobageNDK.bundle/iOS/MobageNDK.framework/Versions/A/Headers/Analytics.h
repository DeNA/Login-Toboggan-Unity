//
//  Analytics.h
//  mobage-ndk
//
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_Analytics_h
#define mobage_ndk_Analytics_h

#include "RegionSpecifics.h"

#import "MBAnalytics.h"

#if MB_WW
@interface MBAnalytics : NSObject<MBAnalytics>
@end
#elif MB_JP || MB_KR
//#import "MB_JP_Analytics.h"
//#define RegionSpecificAnalytics MB_JP_Analytics
//@interface MBAnalytics : RegionSpecificAnalytics
//@end
#elif MB_CN
//#import "MB_CN_Analytics.h"
//#define RegionSpecificAnalytics MB_CN_Analytics
//@interface MBAnalytics : RegionSpecificAnalytics
//@end
#else
#error "Unknown or No Region Specified."
#endif

#undef RegionSpecificAnalytics

#endif
