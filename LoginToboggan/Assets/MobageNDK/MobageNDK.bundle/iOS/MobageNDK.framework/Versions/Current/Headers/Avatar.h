//
//  Avatar.h
//  mobage-ndk
//

#ifndef mobage_ndk_Avatar_h
#define mobage_ndk_Avatar_h

#if MB_WW
//#import "MB_WW_Avatar.h"
//#define RegionSpecificAvatar MB_WW_Avatar
#elif MB_JP || MB_KR
#import "MB_JP_Avatar.h"
#define RegionSpecificAvatar MB_JP_Avatar

@interface MBAvatar : RegionSpecificAvatar
@end

#undef RegionSpecificAvatar

#include "MBCAvatar.h"

#elif MB_CN
//#import "MB_CN_Avatar.h"
//#define RegionSpecificAvatar MB_CN_Avatar
#else
// Invalid Configuration
#endif

#endif
