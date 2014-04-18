//
//  MBCBillingItem.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCBILLINGITEM_H_
#define MBCBILLINGITEM_H_

#include "MBCStandardTypes.h"
#include "MBCItemData.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(MBCItemData * item);
		MBC_Common_IsActive(int32_t quantity);
	}  MBCBillingItem;
	
	MBCArrayForType(BillingItem,MBCBillingItem *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(BillingItem);
	MBCRetainPrototype(BillingItem_Array);
	MBCReleasePrototype(BillingItem);
	MBCReleasePrototype(BillingItem_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCBillingItem * MBCConstructBillingItem(void * __CAPI_NATIVEREF);
	MBCBillingItem_Array * MBCConstructBillingItem_Array(void * __CAPI_NATIVEREF);
	
	MBCBillingItem * MBCCopyConstructBillingItem(MBCBillingItem * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCBillingItem_Array * MBCCopyConstructBillingItem_Array(MBCBillingItem_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructBillingItem(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructBillingItem_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
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

#endif /* MBCBILLINGITEM_H_ */

