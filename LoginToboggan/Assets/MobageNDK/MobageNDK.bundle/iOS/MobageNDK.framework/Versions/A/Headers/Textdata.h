//
//  Textdata.h
//  mobage-ndk
//

#ifndef mobage_ndk_Textdata_h
#define mobage_ndk_Textdata_h

#if MB_WW
//#import "MB_WW_Textdata.h"
//#define RegionSpecificTextdata MB_WW_Textdata
#elif MB_JP || MB_KR
#import "MB_JP_Textdata.h"
#define RegionSpecificTextdata MB_JP_Textdata

@interface MBTextdata : RegionSpecificTextdata
@end

#undef RegionSpecificTextdata

#include "MBCTextdata.h"

#elif MB_CN
//#import "MB_CN_Textdata.h"
//#define RegionSpecificTextdata MB_CN_Textdata
#else
// Invalid Configuration
#endif

#endif
