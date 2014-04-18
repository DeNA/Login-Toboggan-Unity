//
//  TextdataEntry.h
//  mobage-ndk
//

#ifndef mobage_ndk_TextdataEntry_h
#define mobage_ndk_TextdataEntry_h

#if MB_WW
//#import "MB_WW_TextdataEntry.h"
//#define RegionSpecificTextdataEntry MB_WW_TextdataEntry
#elif MB_JP || MB_KR
#import "MB_JP_TextdataEntry.h"
#define RegionSpecificTextdataEntry MB_JP_TextdataEntry

@interface MBTextdataEntry : RegionSpecificTextdataEntry
@end

#undef RegionSpecificTextdataEntry

#include "MBCTextdataEntry.h"

#elif MB_CN
//#import "MB_CN_TextdataEntry.h"
//#define RegionSpecificTextdataEntry MB_CN_TextdataEntry
#else
// Invalid Configuration
#endif

#endif
