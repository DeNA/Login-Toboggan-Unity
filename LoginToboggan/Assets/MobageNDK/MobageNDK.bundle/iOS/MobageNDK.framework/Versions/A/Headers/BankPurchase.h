//
//  BankPurchase.h
//  mobage-ndk
//
//  Created by Eric So on 11/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_BankPurchase_h
#define mobage_ndk_BankPurchase_h

#include "RegionSpecifics.h"

#import "MBBankPurchase.h"

#if MB_WW
#import "MB_WW_BankPurchase.h"
#define RegionSpecificBankPurchase MB_WW_BankPurchase
#elif MB_JP || MB_KR
#import "MB_JP_BankPurchase.h"
#define RegionSpecificBankPurchase MB_JP_BankPurchase
#elif MB_CN
#import "MB_CN_BankPurchase.h"
#define RegionSpecificBankPurchase MB_CN_BankPurchase
#else
// Invalid config
#endif

@interface MBBankPurchase : RegionSpecificBankPurchase
@end

#undef RegionSpecificBankPurchase

#endif

