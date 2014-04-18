//
//  AvatarData.h
//  mobage-ndk
//

#ifndef mobage_ndk_AvatarData_h
#define mobage_ndk_AvatarData_h

#if MB_WW
//#import "MB_WW_AvatarData.h"
//#define RegionSpecificAvatarData MB_WW_AvatarData
#elif MB_JP || MB_KR
#import "MB_JP_AvatarData.h"
#define RegionSpecificAvatarData MB_JP_AvatarData

@interface MBAvatarData : RegionSpecificAvatarData
@end

#undef RegionSpecificAvatarData

#include "MBCAvatarData.h"

#elif MB_CN
//#import "MB_CN_AvatarData.h"
//#define RegionSpecificAvatarData MB_CN_AvatarData
#else
// Invalid Configuration
#endif

#endif
