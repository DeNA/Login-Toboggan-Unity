//
//  MBCString.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCSTRING_H_
#define MBCSTRING_H_

#include "MBCStandardTypes.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * c_str);
	}  MBCString;
	
	MBCArrayForType(String,MBCString *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(String);
	MBCRetainPrototype(String_Array);
	MBCReleasePrototype(String);
	MBCReleasePrototype(String_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCString * MBCConstructString(void * __CAPI_NATIVEREF);
	MBCString_Array * MBCConstructString_Array(void * __CAPI_NATIVEREF);
	
	MBCString * MBCCopyConstructString(MBCString * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCString_Array * MBCCopyConstructString_Array(MBCString_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructString(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructString_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
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

#endif /* MBCSTRING_H_ */

