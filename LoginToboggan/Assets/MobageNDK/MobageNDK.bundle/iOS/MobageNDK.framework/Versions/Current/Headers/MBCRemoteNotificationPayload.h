//
//  MBCRemoteNotificationPayload.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREMOTENOTIFICATIONPAYLOAD_H_
#define MBCREMOTENOTIFICATIONPAYLOAD_H_

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
		
		MBC_Common_IsActive(const char * message);
		MBC_Common_IsActive(int32_t badge);
		MBC_Common_IsActive(const char * sound);
		MBC_Common_IsActive(const char * collapseKey);
		MBC_Common_IsActive(const char * style);
		MBC_Common_IsActive(const char * iconUrl);
		MBC_Common_IsActive(MBCString_Array * extraKeys);
		MBC_Common_IsActive(MBCString_Array * extraValues);
	}  MBCRemoteNotificationPayload;
	
	MBCArrayForType(RemoteNotificationPayload,MBCRemoteNotificationPayload *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(RemoteNotificationPayload);
	MBCRetainPrototype(RemoteNotificationPayload_Array);
	MBCReleasePrototype(RemoteNotificationPayload);
	MBCReleasePrototype(RemoteNotificationPayload_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCRemoteNotificationPayload * MBCConstructRemoteNotificationPayload(void * __CAPI_NATIVEREF);
	MBCRemoteNotificationPayload_Array * MBCConstructRemoteNotificationPayload_Array(void * __CAPI_NATIVEREF);
	
	MBCRemoteNotificationPayload * MBCCopyConstructRemoteNotificationPayload(MBCRemoteNotificationPayload * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCRemoteNotificationPayload_Array * MBCCopyConstructRemoteNotificationPayload_Array(MBCRemoteNotificationPayload_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructRemoteNotificationPayload(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructRemoteNotificationPayload_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
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

#endif /* MBCREMOTENOTIFICATIONPAYLOAD_H_ */

