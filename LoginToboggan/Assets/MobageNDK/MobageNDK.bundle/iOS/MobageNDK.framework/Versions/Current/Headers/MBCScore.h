//
//  MBCScore.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCSCORE_H_
#define MBCSCORE_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * uid);
		MBC_Common_IsActive(const char * userId);
		MBC_Common_IsActive(double scoreValue);
		MBC_Common_IsActive(const char * displayValue);
		MBC_Common_IsActive(int32_t rank);
	}  MBCScore;
	
	MBCArrayForType(Score,MBCScore *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(Score);
	MBCRetainPrototype(Score_Array);
	MBCReleasePrototype(Score);
	MBCReleasePrototype(Score_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCScore * MBCConstructScore(void * __CAPI_NATIVEREF);
	MBCScore_Array * MBCConstructScore_Array(void * __CAPI_NATIVEREF);
	
	MBCScore * MBCCopyConstructScore(MBCScore * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCScore_Array * MBCCopyConstructScore_Array(MBCScore_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructScore(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructScore_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
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

#endif /* MBCSCORE_H_ */

