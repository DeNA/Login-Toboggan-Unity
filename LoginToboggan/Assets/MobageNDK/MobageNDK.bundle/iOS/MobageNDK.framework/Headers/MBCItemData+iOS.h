//
//  MBCItemData+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCITEMDATA_IOS_H_
#define MBCITEMDATA_IOS_H_

#import "MBInterfaceEnums.h"
#include "MBCUtils+iOS.h"
#include "MBCItemData.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeItemData(from) (__bridge NSObject<MBItemData>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(ItemData);
	#define MBCCToNativeItemDataArray(from) _MBCCToNativeItemDataArray(from)
	
	#define MBCCopyItemDataIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructItemData((__bridge void*)[((type*)objc) property])
	#define MBCCopyItemDataArrayIntoStructPtrTyped(type, structPtr, objc, property) (structPtr)->property = MBCConstructItemData_Array((__bridge void*)[((type*)objc) property])
	
	#define MBCCopyItemDataIntoStructPtr(structPtr, objc, property) MBCCopyItemDataIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	#define MBCCopyItemDataArrayIntoStructPtr(structPtr, objc, property) MBCCopyItemDataArrayIntoStructPtrTyped(MBC_OBJC_CLASSNAME, structPtr, objc, property)
	
	#define MBCCToCItemData(from,deepCopy) MBCCopyConstructItemData(from,deepCopy)
	#define MBCCToCItemDataArray(from,deepCopy) MBCCopyConstructItemData_Array(from,deepCopy)
	
	MBCItemData_Array * _MBCHeapAllocateItemData_Array(void);
	#define _MBCDestroyPropertyItemData(structPtr,property) MBCReleaseItemData(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyItemDataArray(structPtr,property) MBCReleaseItemData_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyItemData(void * voidPtr);
	void _MBCInternalDestroyItemData_Array(void * voidPtr);
	
	
	


#ifdef __cplusplus
}
#endif

#endif
