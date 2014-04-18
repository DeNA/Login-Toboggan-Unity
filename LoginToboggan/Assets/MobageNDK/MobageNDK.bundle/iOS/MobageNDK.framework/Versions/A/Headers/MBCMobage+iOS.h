//
//  MBCMobage+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCMOBAGE_IOS_H_
#define MBCMOBAGE_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCMobage.h"

#ifdef __cplusplus
extern "C" {
#endif

	
	void _MBCInternalDestroyMobageUIVisibleNotification(void * voidPtr);
	
	
	#define MBCCToNativeServerEnvironment(status) ((MBServerEnvironment)status)
	#define MBCNativeToCServerEnvironment(status) ((MBCServerEnvironment)status)
	
	#define MBCCopyServerEnvironmentIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCServerEnvironment(from,deepCopy) from
	#define _MBCDestroyPropertyServerEnvironment(from,property)


#ifdef __cplusplus
}
#endif

#endif
