//
//  BankDebit.h
//  mobage-ndk
//
//  Created by Eric So on 7/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_BankDebit_h
#define mobage_ndk_BankDebit_h

#include "RegionSpecifics.h"

#import "MBBankDebit.h"

#if MB_WW
#import "MB_WW_BankDebit.h"
#import "MB_WW_BankDebit+Internal.h"
#define RegionSpecificBankDebit MB_WW_BankDebit
#elif MB_JP || MB_KR
#import "MB_JP_BankDebit.h"
#define RegionSpecificBankDebit MB_JP_BankDebit
#elif MB_CN
#import "MB_CN_BankDebit.h"
#define RegionSpecificBankDebit MB_CN_BankDebit
#else
// Invalid config
#endif

@interface MBBankDebit : RegionSpecificBankDebit
@end

#undef RegionSpecificBankDebit

#endif
