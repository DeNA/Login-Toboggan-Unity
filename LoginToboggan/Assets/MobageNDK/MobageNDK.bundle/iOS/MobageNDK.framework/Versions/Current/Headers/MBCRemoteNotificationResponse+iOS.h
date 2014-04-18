//
//  MBCRemoteNotificationResponse+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREMOTENOTIFICATIONRESPONSE_IOS_H_
#define MBCREMOTENOTIFICATIONRESPONSE_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCRemoteNotificationResponse.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeRemoteNotificationResponse(from) (__bridge NSObject<MBRemoteNotificationResponse>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(RemoteNotificationResponse);
	#define MBCCToNativeRemoteNotificationResponseArray(from) _MBCCToNativeRemoteNotificationResponseArray(from)
	
	#define MBCCopyRemoteNotificationResponseIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructRemoteNotificationResponse((__bridge void*)[((type*)objc) property])
	#define MBCCopyRemoteNotificationResponseArrayIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructRemoteNotificationResponse_Array((__bridge void*)[((type*)objc) property])
	
	#define MBCCopyRemoteNotificationResponseIntoStructPtr(structPtr, objc, property) MBCCopyRemoteNotificationResponseIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	#define MBCCopyRemoteNotificationResponseArrayIntoStructPtr(structPtr, objc, property) MBCCopyRemoteNotificationResponseArrayIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	
	#define MBCCToCRemoteNotificationResponse(from,deepCopy) MBCCopyConstructRemoteNotificationResponse(from,deepCopy)
	#define MBCCToCRemoteNotificationResponseArray(from,deepCopy) MBCCopyConstructRemoteNotificationResponse_Array(from,deepCopy)
	
	MBCRemoteNotificationResponse_Array * _MBCHeapAllocateRemoteNotificationResponse_Array(void);
	#define _MBCDestroyPropertyRemoteNotificationResponse(structPtr,property) MBCReleaseRemoteNotificationResponse(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyRemoteNotificationResponseArray(structPtr,property) MBCReleaseRemoteNotificationResponse_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyRemoteNotificationResponse(void * voidPtr);
	void _MBCInternalDestroyRemoteNotificationResponse_Array(void * voidPtr);
	
	
	


#ifdef __cplusplus
}
#endif

#endif
