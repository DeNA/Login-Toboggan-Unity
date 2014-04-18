//
//  MBCBillingItem+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCBILLINGITEM_IOS_H_
#define MBCBILLINGITEM_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCBillingItem.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeBillingItem(from) (__bridge NSObject<MBBillingItem>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(BillingItem);
	#define MBCCToNativeBillingItemArray(from) _MBCCToNativeBillingItemArray(from)
	
	#define MBCCopyBillingItemIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructBillingItem((__bridge void*)[((type*)objc) property])
	#define MBCCopyBillingItemArrayIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructBillingItem_Array((__bridge void*)[((type*)objc) property])
	
	#define MBCCopyBillingItemIntoStructPtr(structPtr, objc, property) MBCCopyBillingItemIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	#define MBCCopyBillingItemArrayIntoStructPtr(structPtr, objc, property) MBCCopyBillingItemArrayIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	
	#define MBCCToCBillingItem(from,deepCopy) MBCCopyConstructBillingItem(from,deepCopy)
	#define MBCCToCBillingItemArray(from,deepCopy) MBCCopyConstructBillingItem_Array(from,deepCopy)
	
	MBCBillingItem_Array * _MBCHeapAllocateBillingItem_Array(void);
	#define _MBCDestroyPropertyBillingItem(structPtr,property) MBCReleaseBillingItem(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyBillingItemArray(structPtr,property) MBCReleaseBillingItem_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyBillingItem(void * voidPtr);
	void _MBCInternalDestroyBillingItem_Array(void * voidPtr);
	
	
	


#ifdef __cplusplus
}
#endif

#endif
