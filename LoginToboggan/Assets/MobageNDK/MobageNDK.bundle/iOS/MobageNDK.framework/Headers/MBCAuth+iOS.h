//
//  MBCAuth+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCAUTH_IOS_H_
#define MBCAUTH_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCAuth.h"

#ifdef __cplusplus
extern "C" {
#endif

	
	void _MBCInternalDestroyUserSessionReestablishedNotification(void * voidPtr);
	void _MBCInternalDestroyUserLoginNotification(void * voidPtr);
	void _MBCInternalDestroyUserLogoutNotification(void * voidPtr);
	void _MBCInternalDestroyUserGradeUpgradeNotification(void * voidPtr);
	
	


#ifdef __cplusplus
}
#endif

#endif
