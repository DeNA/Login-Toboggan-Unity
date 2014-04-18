//
//  MBCError.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCERROR_H_
#define MBCERROR_H_

#include "MBCStandardTypes.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields
/**
 * Enumeration of standard Mobage API errors.
 * @region Common
 */
typedef enum {
	/**
	 *
	 * A server error occurred.
	 */
	MBCStandardErrorServerError = 10001, 
	/**
	 *
	 * The device cannot connect to the network.
	 */
	MBCStandardErrorNetworkUnavailable = 10002, 
	/**
	 *
	 * The request was missing required information.
	 */
	MBCStandardErrorMissingData = 10003, 
	/**
	 *
	 * The request contained invalid data.
	 */
	MBCStandardErrorInvalidData = 10004, 
	/**
	 *
	 * An unknown error occurred.
	 */
	MBCStandardErrorUnknownError = 10005, 
	/**
	 *
	 * A message from the server could not be parsed.
	 */
	MBCStandardErrorParseError = 10006, 
	/**
	 *
	 * There is no authorization token available for the user.
	 */
	MBCStandardErrorNoAuthToken = 10007
} MBCStandardError;
#define IsMBCStandardError(intFlag) (!((intFlag < 10001) || (intFlag > 10007)))
/**
 * Enumeration of Mobage errors that relate to HTTP errors.
 * @region Common
 */
typedef enum {
	/**
	 *
	 * The Mobage server is not currently available.
	 */
	MBCHTTPErrorServerDown = 109, 
	/**
	 *
	 * The app must be upgraded to support the current version of Mobage.
	 */
	MBCHTTPErrorUpgradeRequired = 110, 
	/**
	 *
	 * The user has been banned from Mobage.
	 */
	MBCHTTPErrorUserBanned = 111, 
	/**
	 *
	 * The user has not agreed to the Mobage terms of service.
	 */
	MBCHTTPErrorAgreementNeeded = 112, 
	/**
	 *
	 * The request data was invalid.
	 */
	MBCHTTPErrorBadRequest = 400, 
	/**
	 *
	 * The specified data was not found.
	 */
	MBCHTTPErrorRecordNotFound = 404, 
	/**
	 *
	 * An authentication error occurred.
	 */
	MBCHTTPErrorUnauthorized = 401, 
	/**
	 *
	 * Access was forbidden for reasons other than an authentication error.
	 */
	MBCHTTPErrorPermissionDenied = 403, 
	/**
	 *
	 * An internal server error occurred.
	 */
	MBCHTTPErrorFirstInternalServerError = 500, 
	/**
	 *
	 * An unknown error occurred.
	 */
	MBCHTTPErrorLastHTTPError = 599
} MBCHTTPError;
#define IsMBCHTTPError(intFlag) (!((intFlag < 109) || (intFlag > 599)))
/**
 * Enumeration of errors for Mobage's common APIs, which are supported in all regions.
 * @region Common
 */
typedef enum {
	/**
	 *
	 * The user's session is invalid.
	 */
	MBCCommonAPIInvalidSessionError = 20001, 
	/**
	 *
	 * The method was called without a required parameter.
	 */
	MBCCommonAPIMethodMissingArgumentError = 20002, 
	/**
	 *
	 * The method was called with an invalid parameter value.
	 */
	MBCCommonAPIMethodInvalidArgumentError = 20003, 
	/**
	 *
	 * The method has not been implemented.
	 */
	MBCCommonAPIMethodNotImplementedError = 20004, 
	/**
	 *
	 * The current Mobage server does not support this method.
	 */
	MBCCommonAPIMethodNotSupportedError = 20005
} MBCCommonAPIError;
#define IsMBCCommonAPIError(intFlag) (!((intFlag < 20001) || (intFlag > 20005)))
/**
 * Enumeration of Mobage analytics errors.
 * @region Common
 */
typedef enum {
	/**
	 *
	 * An invalid response was received from the analytics server.
	 */
	MBCAnalyticsServerErrorInvalidResponse = 30001, 
	/**
	 *
	 * The analytics server rejected the request.
	 */
	MBCAnalyticsServerErrorEventRejected = 30002, 
	/**
	 *
	 * The analytics event size exceeded the maximum size.
	 */
	MBCAnalyticsServerErrorEventSizeTooLarge = 30003, 
	/**
	 *
	 * The analytics event property size exceeded the maximum size.
	 */
	MBCAnalyticsServerErrorEventPropertySizeTooLarge = 30004, 
	/**
	 *
	 * The analytics event contained an invalid array.
	 */
	MBCAnalyticsServerErrorEventContainsInvalidArray = 30005
} MBCAnalyticsServerError;
#define IsMBCAnalyticsServerError(intFlag) (!((intFlag < 30001) || (intFlag > 30005)))
/**
 * Enumeration of Mobage Bank errors.
 * @region Common
 */
typedef enum {
	/**
	 *
	 * The Bank request could not be completed, because the transaction is not in the correct  state for the requested method.
	 */
	MBCBankErrorInvalidStateTransition = 40001, 
	/**

	 */
	MBCBankErrorDeadTransaction = 40002, 
	/**

	 */
	MBCBankErrorGetItemFail = 40003, 
	/**

	 */
	MBCBankErrorPurchaseFail = 40004, 
	/**

	 */
	MBCBankErrorCreditFail = 40005, 
	/**

	 */
	MBCBankErrorTransactionAlreadyOpen = 40006, 
	/**

	 */
	MBCBankErrorProcessFail = 40007, 
	/**

	 */
	MBCBankErrorInvalidCredentials = 40008, 
	/**

	 */
	MBCBankErrorUnkownError = 40009, 
	/**

	 */
	MBCBankErrorPaymentCancelled = 40010, 
	/**

	 */
	MBCBankErrorPaymentInvalid = 40011, 
	/**

	 */
	MBCBankErrorPaymentNotAllowed = 40012
} MBCBankError;
#define IsMBCBankError(intFlag) (!((intFlag < 40001) || (intFlag > 40012)))
/**

 * @region Common
 */
typedef enum {
	/**
	 The Mobage server is not currently available.
	 */
	MBCErrorEnumServerDown = 109, 
	/**
	 The app must be upgraded to support the current version of Mobage.
	 */
	MBCErrorEnumUpgradeRequired = 110, 
	/**
	 The user has been banned from Mobage.
	 */
	MBCErrorEnumUserBanned = 111, 
	/**
	 The user has not agreed to the Mobage terms of service.
	 */
	MBCErrorEnumAgreementNeeded = 112, 
	/**
	 The request data was invalid.
	 */
	MBCErrorEnumBadRequest = 400, 
	/**
	 An authentication error occurred.
	 */
	MBCErrorEnumUnauthorized = 401, 
	/**
	 Access was forbidden for reasons other than an authentication error.
	 */
	MBCErrorEnumPermissionDenied = 403, 
	/**
	 The specified data was not found.
	 */
	MBCErrorEnumRecordNotFound = 404, 
	/**
	 A server error occurred.
	 */
	MBCErrorEnumServerError = 10001, 
	/**
	 The device cannot connect to the network.
	 */
	MBCErrorEnumNetworkUnavailable = 10002, 
	/**
	 The request was missing required information.
	 */
	MBCErrorEnumMissingData = 10003, 
	/**
	 The request contained invalid data.
	 */
	MBCErrorEnumInvalidData = 10004, 
	/**
	 An unknown error occurred.
	 */
	MBCErrorEnumUnknownError = 10005, 
	/**
	 A message from the server could not be parsed.
	 */
	MBCErrorEnumParseError = 10006, 
	/**
	 There is no authorization token available for the user.
	 */
	MBCErrorEnumNoAuthToken = 10007, 
	/**

	 */
	MBCErrorEnumNoConsumerKey = 10008, 
	/**

	 */
	MBCErrorEnumMobageNotInitialized = 10009, 
	/**

	 */
	MBCErrorEnumServerUnexpectedResponse = 10010, 
	/**

	 */
	MBCErrorEnumNoActiveCampaigns = 10011, 
	/**
	 The user's session is invalid.
	 */
	MBCErrorEnumCommonAPIInvalidSessionError = 20001, 
	/**
	 The method was called without a required parameter.
	 */
	MBCErrorEnumCommonAPIMethodMissingArgumentError = 20002, 
	/**
	 The method was called with an invalid parameter value.
	 */
	MBCErrorEnumCommonAPIMethodInvalidArgumentError = 20003, 
	/**
	 The method has not been implemented.
	 */
	MBCErrorEnumCommonAPIMethodNotImplementedError = 20004, 
	/**
	 The current Mobage server does not support this method.
	 */
	MBCErrorEnumCommonAPIMethodNotSupportedError = 20005, 
	/**
	 An invalid response was received from the analytics server.
	 */
	MBCErrorEnumAnalyticsServerInvalidResponse = 30001, 
	/**
	 The analytics server rejected the request.
	 */
	MBCErrorEnumAnalyticsServerEventRejected = 30002, 
	/**
	 The analytics event size exceeded the maximum size.
	 */
	MBCErrorEnumAnalyticsServerEventSizeTooLarge = 30003, 
	/**
	 The analytics event property size exceeded the maximum size.
	 */
	MBCErrorEnumAnalyticsServerEventPropertySizeTooLarge = 30004, 
	/**
	 The analytics event contained an invalid array.
	 */
	MBCErrorEnumAnalyticsServerEventContainsInvalidArray = 30005, 
	/**
	 The Bank request could not be completed, because the transaction is not in the correct state for the requested method.
	 */
	MBCErrorEnumBankErrorInvalidStateTransition = 40001, 
	/**

	 */
	MBCErrorEnumBankErrorDeadTransaction = 40002, 
	/**

	 */
	MBCErrorEnumBankErrorGetItemFail = 40003, 
	/**

	 */
	MBCErrorEnumBankErrorPurchaseFail = 40004, 
	/**

	 */
	MBCErrorEnumBankErrorCreditFail = 40005, 
	/**

	 */
	MBCErrorEnumBankErrorTransactionAlreadyOpen = 40006, 
	/**

	 */
	MBCErrorEnumBankErrorProcessFail = 40007, 
	/**

	 */
	MBCErrorEnumBankErrorInvalidCredentials = 40008, 
	/**

	 */
	MBCErrorEnumBankErrorUnknown = 40009, 
	/**

	 */
	MBCErrorEnumBankErrorPaymentCancelled = 40010, 
	/**

	 */
	MBCErrorEnumBankErrorPaymentInvalid = 40011, 
	/**

	 */
	MBCErrorEnumBankErrorPaymentNotAllowed = 40012, 
	/**

	 */
	MBCErrorEnumBankErrorInvoiceIDMissing = 40013, 
	/**

	 */
	MBCErrorEnumBankErrorTransactionDataMissing = 40014, 
	/**

	 */
	MBCErrorEnumCacheDiskFailed = 50001, 
	/**

	 */
	MBCErrorEnumInvalidConfiguration = 50002, 
	/**

	 */
	MBCErrorEnumUIAlreadyShowing = 60001, 
	/**

	 */
	MBCErrorEnumUserCancelled = 60002, 
	/**

	 */
	MBCErrorEnumLoginErrorRegLoginCancelled = 70001, 
	/**

	 */
	MBCErrorEnumLoginErrorRegNameTaken = 70002, 
	/**

	 */
	MBCErrorEnumLoginErrorRegistrationCancelled = 70003, 
	/**

	 */
	MBCErrorEnumLoginErrorFacebookInvalidSession = 70004, 
	/**

	 */
	MBCErrorEnumLoginErrorFacebookError = 70005, 
	/**

	 */
	MBCErrorEnumLoginErrorFacebookCancel = 70006, 
	/**

	 */
	MBCErrorEnumLoginErrorLoginALreadyInFlight = 70007, 
	/**

	 */
	MBCErrorEnumLoginErrorFacebookAlreadyLinked = 70008, 
	/**

	 */
	MBCErrorEnumLoginErrorFacebookOperationInProgress = 70009, 
	/**

	 */
	MBCErrorEnumLoginErrorFacebookAppBlocked = 70010, 
	/**

	 */
	MBCErrorEnumLoggedInWithDifferentUser = 80001, 
	/**

	 */
	MBCErrorEnumGameNotOpenedInMarket = 80002, 
	/**

	 */
	MBCErrorEnumTooManyFailedLoginAttempts = 90001, 
	/**
	 No ping back was received from the document in the web view (Android).
	 */
	MBCErrorEnumNoPingBackFromDocument = 100001, 
	/**
	 URL gave an invalid response when pinged (non-2xx).
	 */
	MBCErrorEnumInvalidURLResponse = 100002, 
	/**
	 Console error was logged while loading web view.
	 */
	MBCErrorEnumConsoleErrorDuringLoad = 100003, 
	/**
	 Unable to load experience.
	 */
	MBCErrorEnumUnableToLoadExperience = 100004, 
	/**
	 Received error while loading document.
	 */
	MBCErrorEnumReceivedErrorDuringLoad = 100005, 
	/**

	 */
	MBCErrorEnumMalformedSitemap = 10006, 
	/**

	 */
	MBCErrorEnumUnableToDownloadSitemap = 10007
} MBCErrorEnum;
#define IsMBCErrorEnum(intFlag) (!((intFlag < 109) || (intFlag > 100005)))
/**

 * @region Common
 */
typedef enum {
	/**
	 The Mobage server is not currently available.
	 */
	MBCMobageAPIErrorTypeServerDown = 109, 
	/**
	 The app must be upgraded to support the current version of Mobage.
	 */
	MBCMobageAPIErrorTypeUpgradeRequired = 110, 
	/**
	 The user has been banned from Mobage.
	 */
	MBCMobageAPIErrorTypeUserBanned = 111, 
	/**
	 The user has not agreed to the Mobage terms of service.
	 */
	MBCMobageAPIErrorTypeAgreementNeeded = 112, 
	/**
	 The request data was invalid.
	 */
	MBCMobageAPIErrorTypeBadRequest = 400, 
	/**
	 An authentication error occurred.
	 */
	MBCMobageAPIErrorTypeUnauthorized = 401, 
	/**
	 Access was forbidden for reasons other than an authentication error.
	 */
	MBCMobageAPIErrorTypePermissionDenied = 403, 
	/**
	 The specified data was not found.
	 */
	MBCMobageAPIErrorTypeRecordNotFound = 404, 
	/**
	 A server error occurred.
	 */
	MBCMobageAPIErrorTypeServerError = 10001, 
	/**
	 The device cannot connect to the network.
	 */
	MBCMobageAPIErrorTypeNetworkUnavailable = 10002, 
	/**
	 The request was missing required information.
	 */
	MBCMobageAPIErrorTypeMissingData = 10003, 
	/**
	 The request contained invalid data.
	 */
	MBCMobageAPIErrorTypeInvalidData = 10004, 
	/**
	 An unknown error occurred.
	 */
	MBCMobageAPIErrorTypeUnknownError = 10005, 
	/**
	 A message from the server could not be parsed.
	 */
	MBCMobageAPIErrorTypeParseError = 10006, 
	/**
	 There is no authorization token available for the user.
	 */
	MBCMobageAPIErrorTypeNoAuthToken = 10007, 
	/**
	 The user's session is invalid.
	 */
	MBCMobageAPIErrorTypeCommonAPIInvalidSessionError = 20001, 
	/**
	 The method was called without a required parameter.
	 */
	MBCMobageAPIErrorTypeCommonAPIMethodMissingArgumentError = 20002, 
	/**
	 The method was called with an invalid parameter value.
	 */
	MBCMobageAPIErrorTypeCommonAPIMethodInvalidArgumentError = 20003, 
	/**
	 The method has not been implemented.
	 */
	MBCMobageAPIErrorTypeCommonAPIMethodNotImplementedError = 20004, 
	/**
	 The current Mobage server does not support this method.
	 */
	MBCMobageAPIErrorTypeCommonAPIMethodNotSupportedError = 20005, 
	/**
	 An invalid response was received from the analytics server.
	 */
	MBCMobageAPIErrorTypeAnalyticsServerInvalidResponse = 30001, 
	/**
	 The analytics server rejected the request.
	 */
	MBCMobageAPIErrorTypeAnalyticsServerEventRejected = 30002, 
	/**
	 The analytics event size exceeded the maximum size.
	 */
	MBCMobageAPIErrorTypeAnalyticsServerEventSizeTooLarge = 30003, 
	/**
	 The analytics event property size exceeded the maximum size.
	 */
	MBCMobageAPIErrorTypeAnalyticsServerEventPropertySizeTooLarge = 30004, 
	/**
	 The analytics event contained an invalid array.
	 */
	MBCMobageAPIErrorTypeAnalyticsServerEventContainsInvalidArray = 30005, 
	/**
	 The Bank request could not be completed, because the transaction is not in the correct state for the requested method.
	 */
	MBCMobageAPIErrorTypeBankErrorInvalidStateTransition = 40001, 
	/**
	 No ping back was received from the document in the web view (Android).
	 */
	MBCMobageAPIErrorTypeNoPingBackFromDocument = 100001, 
	/**
	 URL gave an invalid response when pinged (non-2xx).
	 */
	MBCMobageAPIErrorTypeInvalidURLResponse = 100002, 
	/**
	 Console error was logged while loading web view.
	 */
	MBCMobageAPIErrorTypeConsoleErrorDuringLoad = 100003, 
	/**
	 Unable to load experience.
	 */
	MBCMobageAPIErrorTypeUnableToLoadExperience = 100004, 
	/**
	 Received error while loading document.
	 */
	MBCMobageAPIErrorTypeReceivedErrorDuringLoad = 100005
} MBCMobageAPIErrorType;
#define IsMBCMobageAPIErrorType(intFlag) (!((intFlag < 109) || (intFlag > 100005)))

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * domain);
		MBC_Common_IsActive(int32_t code);
		MBC_Common_IsActive(const char * localizedDescription);
		MBC_Common_IsActive(const char * description);
	}  MBCError;
	
	MBCArrayForType(Error,MBCError *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(Error);
	MBCRetainPrototype(Error_Array);
	MBCReleasePrototype(Error);
	MBCReleasePrototype(Error_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCError * MBCConstructError(void * __CAPI_NATIVEREF);
	MBCError_Array * MBCConstructError_Array(void * __CAPI_NATIVEREF);
	
	MBCError * MBCCopyConstructError(MBCError * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCError_Array * MBCCopyConstructError_Array(MBCError_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructError(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructError_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
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

#endif /* MBCERROR_H_ */

