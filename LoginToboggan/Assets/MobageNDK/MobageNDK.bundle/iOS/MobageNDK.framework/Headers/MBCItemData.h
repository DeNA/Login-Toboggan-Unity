//
//  MBCItemData.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCITEMDATA_H_
#define MBCITEMDATA_H_

#include "MBCStandardTypes.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * itemId);
		MBC_Common_IsActive(const char * name);
		MBC_Common_IsActive(int32_t price);
		MBC_Common_IsActive(const char * longDescription);
		MBC_Common_IsActive(const char * imageUrl);
		MBC_WW_IsActive(const char * originPriceLabel);
		MBC_WW_IsActive(const char * originCurrencyLabel);
		MBC_WW_IsActive(bool itemForCash);
		MBC_WW_IsActive(double originPrice);
		MBC_WW_IsActive(const char * currency);
	}  MBCItemData;
	
	MBCArrayForType(ItemData,MBCItemData *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(ItemData);
	MBCRetainPrototype(ItemData_Array);
	MBCReleasePrototype(ItemData);
	MBCReleasePrototype(ItemData_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCItemData * MBCConstructItemData(void * __CAPI_NATIVEREF);
	MBCItemData_Array * MBCConstructItemData_Array(void * __CAPI_NATIVEREF);
	
	MBCItemData * MBCCopyConstructItemData(MBCItemData * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCItemData_Array * MBCCopyConstructItemData_Array(MBCItemData_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructItemData(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructItemData_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	
	#pragma mark - Static Methods
	// None!
	#pragma mark - Instance Methods
	// None!


#ifdef __cplusplus
}
#endif

#endif /* MBCITEMDATA_H_ */

