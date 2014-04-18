//
//  MBCRemoteNotificationPayload+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREMOTENOTIFICATIONPAYLOAD_IOS_H_
#define MBCREMOTENOTIFICATIONPAYLOAD_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCRemoteNotificationPayload.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeRemoteNotificationPayload(from) (__bridge NSObject<MBRemoteNotificationPayload>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(RemoteNotificationPayload);
	#define MBCCToNativeRemoteNotificationPayloadArray(from) _MBCCToNativeRemoteNotificationPayloadArray(from)
	
	#define MBCCopyRemoteNotificationPayloadIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructRemoteNotificationPayload((__bridge void*)[((type*)objc) property])
	#define MBCCopyRemoteNotificationPayloadArrayIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructRemoteNotificationPayload_Array((__bridge void*)[((type*)objc) property])
	
	#define MBCCopyRemoteNotificationPayloadIntoStructPtr(structPtr, objc, property) MBCCopyRemoteNotificationPayloadIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	#define MBCCopyRemoteNotificationPayloadArrayIntoStructPtr(structPtr, objc, property) MBCCopyRemoteNotificationPayloadArrayIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	
	#define MBCCToCRemoteNotificationPayload(from,deepCopy) MBCCopyConstructRemoteNotificationPayload(from,deepCopy)
	#define MBCCToCRemoteNotificationPayloadArray(from,deepCopy) MBCCopyConstructRemoteNotificationPayload_Array(from,deepCopy)
	
	MBCRemoteNotificationPayload_Array * _MBCHeapAllocateRemoteNotificationPayload_Array(void);
	#define _MBCDestroyPropertyRemoteNotificationPayload(structPtr,property) MBCReleaseRemoteNotificationPayload(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyRemoteNotificationPayloadArray(structPtr,property) MBCReleaseRemoteNotificationPayload_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyRemoteNotificationPayload(void * voidPtr);
	void _MBCInternalDestroyRemoteNotificationPayload_Array(void * voidPtr);
	
	
	


#ifdef __cplusplus
}
#endif

#endif
