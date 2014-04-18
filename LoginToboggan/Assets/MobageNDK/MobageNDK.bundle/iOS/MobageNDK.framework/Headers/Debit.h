//
//  Debit.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 3/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_Debit_h
#define mobage_ndk_Debit_h

#include "RegionSpecifics.h"

#import "MBBankDebit.h"


#if MB_WW
#import "MB_WW_BankDebit.h"
#define RegionSpecificDebit MB_WW_BankDebit
#elif MB_JP || MB_KR
#import "MB_JP_BankDebit.h"
#define RegionSpecificDebit MB_JP_BankDebit
#elif MB_CN
#import "MB_CN_BankDebit.h"
#define RegionSpecificDebit MB_CN_BankDebit
#else
#error "Unknown or No Region Specified."
#endif

@interface MBBankDebit : RegionSpecificDebit
@end
#undef RegionSpecificDebit



#import "MBBankInventory.h"

#if MB_WW
#import "MB_WW_BankInventory.h"
#define RegionSpecificInventory MB_WW_BankInventory
#elif MB_JP || MB_KR
#import "MB_JP_BankInventory.h"
#define RegionSpecificInventory MB_JP_BankInventory
#elif MB_CN
#import "MB_CN_BankInventory.h"
#define RegionSpecificInventory MB_CN_BankInventory
#else
#error "Unknown or No Region Specified."
#endif

@interface MBBankInventory : RegionSpecificInventory
@end
#undef RegionSpecificInventory


#import "MBBankPurchase.h"

#if MB_WW
#import "MB_WW_BankPurchase.h"
#define RegionSpecificPurchase MB_WW_BankPurchase
#elif MB_JP || MB_KR
#import "MB_JP_BankPurchase.h"
#define RegionSpecificPurchase MB_JP_BankPurchase
#elif MB_CN
#import "MB_CN_BankPurchase.h"
#define RegionSpecificPurchase MB_CN_BankPurchase
#else
#error "Unknown or No Region Specified."
#endif

@interface MBBankPurchase : RegionSpecificPurchase
@end
#undef RegionSpecificPurchase


#endif
