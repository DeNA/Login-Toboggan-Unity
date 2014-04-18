//
//  MBCUser+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCUSER_IOS_H_
#define MBCUSER_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeUser(from) (__bridge NSObject<MBUser>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(User);
	#define MBCCToNativeUserArray(from) _MBCCToNativeUserArray(from)
	
	#define MBCCopyUserIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructUser((__bridge void*)[((type*)objc) property])
	#define MBCCopyUserArrayIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructUser_Array((__bridge void*)[((type*)objc) property])
	
	#define MBCCopyUserIntoStructPtr(structPtr, objc, property) MBCCopyUserIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	#define MBCCopyUserArrayIntoStructPtr(structPtr, objc, property) MBCCopyUserArrayIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	
	#define MBCCToCUser(from,deepCopy) MBCCopyConstructUser(from,deepCopy)
	#define MBCCToCUserArray(from,deepCopy) MBCCopyConstructUser_Array(from,deepCopy)
	
	MBCUser_Array * _MBCHeapAllocateUser_Array(void);
	#define _MBCDestroyPropertyUser(structPtr,property) MBCReleaseUser(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyUserArray(structPtr,property) MBCReleaseUser_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyUser(void * voidPtr);
	void _MBCInternalDestroyUser_Array(void * voidPtr);
	
	
	


#ifdef __cplusplus
}
#endif

#endif
