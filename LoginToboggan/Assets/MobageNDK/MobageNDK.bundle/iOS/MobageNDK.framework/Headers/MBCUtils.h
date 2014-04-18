//
//  MBCUtils.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCUTILS_H_
#define MBCUTILS_H_

#include <stdint.h>

#ifdef __cplusplus
extern "C" {
#endif
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		// Has other properties, do not pass by value or ELSE!
	}  DANGEROUS_CAPIOBJECT;
	
	#define MBCArrayForType(typeName,ctype)\
	typedef struct {\
		volatile int32_t __CAPI_REFCOUNT; \
		void * __CAPI_NATIVEREF; \
		\
		int length;\
		ctype * elements;\
	} MBC ## typeName ## _Array
	
	typedef void (*MBCFinalDestructorFunctionPointer)(void*);
	
	#pragma mark - Retain/Release
	void MBCRetainCObject(DANGEROUS_CAPIOBJECT *);
	bool MBCReleaseCObject(DANGEROUS_CAPIOBJECT *,MBCFinalDestructorFunctionPointer); //Returns true on destroy!
	
	#define MBCRetainPrototype(type) void MBCRetain ## type(MBC ## type *)
	#define MBCRetainBody(type) void MBCRetain ## type(MBC ## type *obj){ return MBCRetainCObject((DANGEROUS_CAPIOBJECT *)obj); }
	#define MBCReleasePrototype(type) bool MBCRelease ## type(MBC ## type *)
	#define MBCReleaseBody(type) bool MBCRelease ## type(MBC ## type *obj){ return MBCReleaseCObject((DANGEROUS_CAPIOBJECT *)obj, &_MBCInternalDestroy ## type); }
	
	
	#pragma mark - Region Preprocessor Helpers
	#if MB_WW
		#define MBC_WW_IsActive(thing) thing
	#elif !MB_WW
		#define MBC_WW_IsActive(thing)
	#endif
	#if MB_JP
		#define MBC_JP_IsActive(thing) thing
	#elif !MB_JP
		#define MBC_JP_IsActive(thing)
	#endif
	#if MB_KO
		#define MBC_KO_IsActive(thing) thing
	#elif !MB_KO
		#define MBC_KO_IsActive(thing)
	#endif
	#if MB_CN
		#define MBC_CN_IsActive(thing) thing
	#elif !MB_CN
		#define MBC_CN_IsActive(thing)
	#endif
	#define MBC_Common_IsActive(thing) thing
#ifdef __cplusplus
}
#endif

#endif
