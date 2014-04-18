//
//  ItemData.h
//  mobage-ndk
//
//  Created by Kinkoi Lo on 5/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_itemdata_h
#define mobage_ndk_itemdata_h


#import "MBItemData.h"
#if MB_WW
#import "MB_WW_ItemData.h"
#define RegionSpecificItemData MB_WW_ItemData
#elif MB_JP || MB_KR
#import "MB_JP_ItemData.h"
#define RegionSpecificItemData MB_JP_ItemData
#elif MB_CN
#import "MB_CN_ItemData.h"
#define RegionSpecificItemData MB_CN_ItemData
#else
#error "Unknown or No Region Specified."
#endif

@interface MBItemData : RegionSpecificItemData
@end
#undef RegionSpecificItemData


#endif
