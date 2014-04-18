//
//  MBCRemoteNotificationResponse.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREMOTENOTIFICATIONRESPONSE_H_
#define MBCREMOTENOTIFICATIONRESPONSE_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCRemoteNotificationPayload.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * uid);
		MBC_Common_IsActive(const char * responseId);
		MBC_Common_IsActive(MBCRemoteNotificationPayload * payload);
		MBC_JP_IsActive(const char * published);
	}  MBCRemoteNotificationResponse;
	
	MBCArrayForType(RemoteNotificationResponse,MBCRemoteNotificationResponse *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(RemoteNotificationResponse);
	MBCRetainPrototype(RemoteNotificationResponse_Array);
	MBCReleasePrototype(RemoteNotificationResponse);
	MBCReleasePrototype(RemoteNotificationResponse_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCRemoteNotificationResponse * MBCConstructRemoteNotificationResponse(void * __CAPI_NATIVEREF);
	MBCRemoteNotificationResponse_Array * MBCConstructRemoteNotificationResponse_Array(void * __CAPI_NATIVEREF);
	
	MBCRemoteNotificationResponse * MBCCopyConstructRemoteNotificationResponse(MBCRemoteNotificationResponse * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCRemoteNotificationResponse_Array * MBCCopyConstructRemoteNotificationResponse_Array(MBCRemoteNotificationResponse_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructRemoteNotificationResponse(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructRemoteNotificationResponse_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
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

#endif /* MBCREMOTENOTIFICATIONRESPONSE_H_ */

