//
//  MBCSocialService+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCSOCIALSERVICE_IOS_H_
#define MBCSOCIALSERVICE_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCSocialService.h"

#ifdef __cplusplus
extern "C" {
#endif

	
	void _MBCInternalDestroyBalanceUpdateNotification(void * voidPtr);
	
	
	#define MBCCToNativeGravity(status) ((MBGravity)status)
	#define MBCNativeToCGravity(status) ((MBCGravity)status)
	
	#define MBCCopyGravityIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCGravity(from,deepCopy) from
	#define _MBCDestroyPropertyGravity(from,property)


#ifdef __cplusplus
}
#endif

#endif
