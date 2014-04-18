//
//  BankInventory.h
//  mobage-ndk
//
//  Created by Eric So on 7/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_BankInventory_h
#define mobage_ndk_BankInventory_h

#include "RegionSpecifics.h"

#import "MBBankInventory.h"
#if MB_WW
#import "MB_WW_BankInventory.h"
#import "MB_WW_BankInventory+Internal.h"
#define RegionSpecificBankInventory MB_WW_BankInventory
#elif MB_JP || MB_KR
#import "MB_JP_BankInventory.h"
#define RegionSpecificBankInventory MB_JP_BankInventory
#elif MB_CN
#import "MB_CN_BankInventory.h"
#define RegionSpecificBankInventory MB_CN_BankInventory
#else
#error "Unknown or No Region Specified."
#endif

@interface MBBankInventory : RegionSpecificBankInventory
@end
#undef RegionSpecificBankInventory

#endif
