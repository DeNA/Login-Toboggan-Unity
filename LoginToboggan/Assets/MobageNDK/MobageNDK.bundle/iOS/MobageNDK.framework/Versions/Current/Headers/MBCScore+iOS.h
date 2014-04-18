//
//  MBCScore+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCSCORE_IOS_H_
#define MBCSCORE_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCScore.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeScore(from) (__bridge NSObject<MBScore>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(Score);
	#define MBCCToNativeScoreArray(from) _MBCCToNativeScoreArray(from)
	
	#define MBCCopyScoreIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructScore((__bridge void*)[((type*)objc) property])
	#define MBCCopyScoreArrayIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructScore_Array((__bridge void*)[((type*)objc) property])
	
	#define MBCCopyScoreIntoStructPtr(structPtr, objc, property) MBCCopyScoreIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	#define MBCCopyScoreArrayIntoStructPtr(structPtr, objc, property) MBCCopyScoreArrayIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	
	#define MBCCToCScore(from,deepCopy) MBCCopyConstructScore(from,deepCopy)
	#define MBCCToCScoreArray(from,deepCopy) MBCCopyConstructScore_Array(from,deepCopy)
	
	MBCScore_Array * _MBCHeapAllocateScore_Array(void);
	#define _MBCDestroyPropertyScore(structPtr,property) MBCReleaseScore(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyScoreArray(structPtr,property) MBCReleaseScore_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyScore(void * voidPtr);
	void _MBCInternalDestroyScore_Array(void * voidPtr);
	
	
	


#ifdef __cplusplus
}
#endif

#endif
