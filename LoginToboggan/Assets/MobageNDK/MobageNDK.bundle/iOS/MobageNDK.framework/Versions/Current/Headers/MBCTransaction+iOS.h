//
//  MBCTransaction+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCTRANSACTION_IOS_H_
#define MBCTRANSACTION_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCTransaction.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeTransaction(from) (__bridge NSObject<MBTransaction>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(Transaction);
	#define MBCCToNativeTransactionArray(from) _MBCCToNativeTransactionArray(from)
	
	#define MBCCopyTransactionIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructTransaction((__bridge void*)[((type*)objc) property])
	#define MBCCopyTransactionArrayIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructTransaction_Array((__bridge void*)[((type*)objc) property])
	
	#define MBCCopyTransactionIntoStructPtr(structPtr, objc, property) MBCCopyTransactionIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	#define MBCCopyTransactionArrayIntoStructPtr(structPtr, objc, property) MBCCopyTransactionArrayIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	
	#define MBCCToCTransaction(from,deepCopy) MBCCopyConstructTransaction(from,deepCopy)
	#define MBCCToCTransactionArray(from,deepCopy) MBCCopyConstructTransaction_Array(from,deepCopy)
	
	MBCTransaction_Array * _MBCHeapAllocateTransaction_Array(void);
	#define _MBCDestroyPropertyTransaction(structPtr,property) MBCReleaseTransaction(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyTransactionArray(structPtr,property) MBCReleaseTransaction_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyTransaction(void * voidPtr);
	void _MBCInternalDestroyTransaction_Array(void * voidPtr);
	
	
	
	#define MBCCToNativeTransactionState(status) ((MBTransactionState)status)
	#define MBCNativeToCTransactionState(status) ((MBCTransactionState)status)
	
	#define MBCCopyTransactionStateIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCTransactionState(from,deepCopy) from
	#define _MBCDestroyPropertyTransactionState(from,property)


#ifdef __cplusplus
}
#endif

#endif
