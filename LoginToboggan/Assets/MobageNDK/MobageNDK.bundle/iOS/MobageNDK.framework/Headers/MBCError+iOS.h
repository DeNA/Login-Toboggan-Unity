//
//  MBCError+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCERROR_IOS_H_
#define MBCERROR_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCError.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeError(from) (__bridge NSObject<MBError>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(Error);
	#define MBCCToNativeErrorArray(from) _MBCCToNativeErrorArray(from)
	
	#define MBCCopyErrorIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructError((__bridge void*)[((type*)objc) property])
	#define MBCCopyErrorArrayIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructError_Array((__bridge void*)[((type*)objc) property])
	
	#define MBCCopyErrorIntoStructPtr(structPtr, objc, property) MBCCopyErrorIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	#define MBCCopyErrorArrayIntoStructPtr(structPtr, objc, property) MBCCopyErrorArrayIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	
	#define MBCCToCError(from,deepCopy) MBCCopyConstructError(from,deepCopy)
	#define MBCCToCErrorArray(from,deepCopy) MBCCopyConstructError_Array(from,deepCopy)
	
	MBCError_Array * _MBCHeapAllocateError_Array(void);
	#define _MBCDestroyPropertyError(structPtr,property) MBCReleaseError(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyErrorArray(structPtr,property) MBCReleaseError_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyError(void * voidPtr);
	void _MBCInternalDestroyError_Array(void * voidPtr);
	
	
	
	#define MBCCToNativeStandardError(status) ((MBStandardError)status)
	#define MBCNativeToCStandardError(status) ((MBCStandardError)status)
	
	#define MBCCopyStandardErrorIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCStandardError(from,deepCopy) from
	#define _MBCDestroyPropertyStandardError(from,property)
	#define MBCCToNativeHTTPError(status) ((MBHTTPError)status)
	#define MBCNativeToCHTTPError(status) ((MBCHTTPError)status)
	
	#define MBCCopyHTTPErrorIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCHTTPError(from,deepCopy) from
	#define _MBCDestroyPropertyHTTPError(from,property)
	#define MBCCToNativeCommonAPIError(status) ((MBCommonAPIError)status)
	#define MBCNativeToCCommonAPIError(status) ((MBCCommonAPIError)status)
	
	#define MBCCopyCommonAPIErrorIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCCommonAPIError(from,deepCopy) from
	#define _MBCDestroyPropertyCommonAPIError(from,property)
	#define MBCCToNativeAnalyticsServerError(status) ((MBAnalyticsServerError)status)
	#define MBCNativeToCAnalyticsServerError(status) ((MBCAnalyticsServerError)status)
	
	#define MBCCopyAnalyticsServerErrorIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCAnalyticsServerError(from,deepCopy) from
	#define _MBCDestroyPropertyAnalyticsServerError(from,property)
	#define MBCCToNativeBankError(status) ((MBBankError)status)
	#define MBCNativeToCBankError(status) ((MBCBankError)status)
	
	#define MBCCopyBankErrorIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCBankError(from,deepCopy) from
	#define _MBCDestroyPropertyBankError(from,property)
	#define MBCCToNativeErrorEnum(status) ((MBErrorEnum)status)
	#define MBCNativeToCErrorEnum(status) ((MBCErrorEnum)status)
	
	#define MBCCopyErrorEnumIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCErrorEnum(from,deepCopy) from
	#define _MBCDestroyPropertyErrorEnum(from,property)
	#define MBCCToNativeMobageAPIErrorType(status) ((MBMobageAPIErrorType)status)
	#define MBCNativeToCMobageAPIErrorType(status) ((MBCMobageAPIErrorType)status)
	
	#define MBCCopyMobageAPIErrorTypeIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCMobageAPIErrorType(from,deepCopy) from
	#define _MBCDestroyPropertyMobageAPIErrorType(from,property)


#ifdef __cplusplus
}
#endif

#endif
