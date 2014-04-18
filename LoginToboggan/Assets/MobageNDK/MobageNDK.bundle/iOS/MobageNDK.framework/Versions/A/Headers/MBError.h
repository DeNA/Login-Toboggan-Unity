//
//  MBError.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/11/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBModelSerialization.h"

/**
 * @file MBError.h
 * Get details about an error.
 * @since 1.5
 */

extern NSString *const kMBMobageAPIErrorDomain;

typedef enum{
	/**
	 * The Mobage server is not currently available.
	 * @since 2.5.1
	 */
	MBErrorServerDown = 109,
	/**
	 * The app must be upgraded to support the current version of Mobage.
	 * @since 2.5.1
	 */
	MBErrorUpgradeRequired = 110,
	/**
	 * The user has been banned from Mobage.
	 * @since 2.5.1
	 */
	MBErrorUserBanned = 111,
	/**
	 * The user has not agreed to the Mobage terms of service.
	 * @since 2.5.1
	 */
	MBErrorAgreementNeeded = 112,
	/*
	 *
	 * The request data was invalid.
	 * @since 2.5.1
	 */
	MBErrorTypeBadRequest = 400,
	/**
	 * An authentication error occurred.
	 * @since 2.5.1
	 */
	MBErrorUnauthorized = 401,
	/**
	 * Access was forbidden for reasons other than an authentication error.
     * <p>
     * You will receive this error if the current Mobage user has a guest account, and you call a
     * method that does not support guest accounts. For more information about guest accounts, see
     * the <a href="https://developer.mobage.com/en/resources/guest_accounts_native">guest accounts
     * overview</a> on the Mobage Developer Portal.
	 * @since 2.5.1
	 */
	MBErrorPermissionDenied = 403,
	/**
	 * The specified data was not found.
	 * @since 2.5.1
	 */
	MBErrorRecordNotFound = 404,
	
	
	/*** standard Mobage API errors. ***/
	/**
	 * A server error occurred.
	 * @since 2.5.1
	 */
	MBErrorServerError = 10001,
	/**
	 * The device cannot connect to the network.
	 * @since 2.5.1
	 */
	MBErrorNetworkUnavailable = 10002,
	/*
	 *
	 * The request was missing required information.
	 * @since 2.5.1
	 */
	MBErrorTypeMissingData = 10003,
	/*
	 *
	 * The request contained invalid data.
	 * @since 2.5.1
	 */
	MBErrorTypeInvalidData = 10004,
	/*
	 *
	 * An unknown error occurred.
	 * @since 2.5.1
	 */
	MBErrorTypeUnknownError = 10005,
	/*
	 *
	 * A message from the server could not be parsed.
	 * @since 2.5.1
	 */
	MBErrorTypeParseError = 10006,
	/*
	 *
	 * There is no authorization token available for the user.
	 * @since 2.5.1
	 */
	MBErrorTypeNoAuthToken = 10007,
	/*
	 *
	 * Missing OAuth consumer key when initializing Mobage.
	 * @since 2.5.1
	 */
	MBErrorTypeNoConsumerKey = 10008,
	/*
	 *
	 * Mobage is not initialized.
	 * @since 2.5.1
	 */
	MBErrorTypeMobageNotInitialized = 10009,
	/*
	 *
	 * The server returned an unexpected response.
	 * @since 2.5.1
	 */
	MBErrorTypeServerUnexpectedResponse = 10010,
	/*
	 *
	 * No active campaigns are available.
	 * @since 2.5.1
	 */
	MBErrorTypeNoActiveCampaigns = 10011,
	
	
	/*** Common API Errors  ***/
	/**
	 * The user's session is invalid.
	 * @since 2.5.1
	 */
	MBErrorCommonInvalidSessionError = 20001,
	/**
	 * The method was called without a required parameter.
	 * @since 2.5.1
	 */
	MBErrorCommonMethodMissingArgumentError = 20002,
	/**
	 * The method was called with an invalid parameter value.
	 * @since 2.5.1
	 */
	MBErrorCommonMethodInvalidArgumentError = 20003,
	/**
	 * The method has not been implemented.
	 * @since 2.5.1
	 */
	MBErrorCommonMethodNotImplementedError = 20004,
	/**
	 * The current Mobage server does not support this method.
	 * @since 2.5.1
	 */
	MBErrorCommonMethodNotSupportedError = 20005,

	
	
	/*** Analytics Errors ***/
	/**
	 * An invalid response was received from the analytics server.
	 * @since 2.5.1
	 */
	MBErrorAnalyticsServerErrorInvalidResponse = 30001,
	/**
	 * The analytics server rejected the request.
	 * @since 2.5.1
	 */
	MBErrorAnalyticsServerErrorEventRejected = 30002,
	/**
	 * The analytics event size exceeded the maximum size.
	 * @since 2.5.1
	 */
	MBErrorAnalyticsServerErrorEventSizeTooLarge = 30003,
	/**
	 * The analytics event property size exceeded the maximum size.
	 * @since 2.5.1
	 */
	MBErrorAnalyticsServerErrorEventPropertySizeTooLarge = 30004,
	/**
	 * The analytics event contained an invalid array.
	 * @since 2.5.1
	 */
	MBErrorAnalyticsServerErrorEventContainsInvalidArray = 30005,
	
	
	
	
	/*** Bank Errors ***/
	/**
	 * The transaction is not in the correct state for the requested method.
	 * @since 2.5.1
	 */
	MBErrorBankInvalidStateTransition = 40001,
	/**
	 * The bank transaction is no longer active.
	 * @since 2.5.1
	 */
    MBErrorBankDeadTransaction = 40002,
    /**
	 * The bank inventory item could not be retrieved.
	 * @since 2.5.1
	 */
	MBErrorBankGetItemFail = 40003,
	/**
	 * The bank purchase failed.
	 * @since 2.5.1
	 */
	MBErrorBankPurchaseFail = 40004,
	/**
	 * The user's account could not be credited. Confirm that the user has an internet 
	 * connection. Then, call <code>MBBankPurchase::getUnfinishedItemTransactions</code>
	 * to retrieve transactions that were interrupted and could not be completed. 
	 * Make sure there’s an internet connection.
	 * @since 2.5.1
	 */
	MBErrorBankCreditFail = 40005,
	/**
	 * The bank transaction is already open.
	 * @since 2.5.1
	 */
	MBErrorBankTransactionAlreadyOpen = 40006,
	/**
	 * A failure occurred while processing the bank transaction.
	 * @since 2.5.1
	 */
	MBErrorBankProcessFail = 40007,
	/**
	 * The bank credentials are invalid.
     * @since 2.5.1
     */
    MBErrorBankInvalidCredentials = 40008,
    /**
     * An unknown Bank error occurred.
     * @since 2.5.1
     */
    MBErrorBankUnknown = 40009,
    /**
     * The user canceled the request.
     * @since 2.5.1
     */
    MBErrorBankPaymentCancelled = 40010,
    /**
     * A request parameter was not recognized by the App Store.
     * @since 2.5.1
     */
    MBErrorBankPaymentInvalid = 40011,
    /**
     * The user is not allowed to authorize payments.
     * @since 2.5.1
     */
    MBErrorBankPaymentNotAllowed = 40012,
    /**
     * The invoice ID for the transaction is missing.
     * @since 2.5.1
     */
	MBErrorBankInvoiceIDMissing = 40013,
	/**
     * The transaction data is not available.
     * @since 2.5.1
     */
	MBErrorBankTransactionDataMissing = 40014,

	
	/*** Other Errors ***/
	/**
     * The cache disk failed.
     * @since 2.5.1
     */
	MBErrorCacheDiskFailed = 50001,
	/**
     * The configuration is invalid.
     * @since 2.5.1
     */
	MBErrorInvalidConfiguration = 50002,
	/**
     * The Mobage UI is already showing.
     * @since 2.5.1
     */
	MBErrorUIAlreadyShowing = 60001,
	/**
     * The user canceled the request.
     * @since 2.5.1
     */
	MBErrorUserCancelled = 60002,
	
	
	
	/*** Login Errors ***/
	/**
     * The login process was canceled.
     * @since 2.5.1
     */
	MBErrorLoginRegLoginCancelled = 70001,
	/**
     * The requested nickname is already taken.
     * @since 2.5.1
     */
	MBErrorLoginRegNameTaken = 70002,
	/**
     * The registration process was canceled.
     * @since 2.5.1
     */
	MBErrorLoginRegRegistrationCancelled = 70003,
	/**
     * The Facebook session is invalid.
     * @since 2.5.1
     */
	MBErrorFacebookInvalidSession = 70004,
	/**
     * A Facebook-related error occurred.
     * @since 2.5.1
     */
	MBErrorFacebookError = 70005,
	/**
     * The Facebook login process was canceled.
     * @since 2.5.1
     */
	MBErrorFacebookCancel = 70006,
	/**
     * The login process is already under way.
     * @since 2.5.1
     */
	MBErrorLoginAlreadyInFlight = 70007,
	/**
     * The Facebook account is already linked to the game.
     * @since 2.5.1
     */
	MBErrorFacebookAlreadyLinked = 70008,
	/**
     * A Facebook operation is already in progress.
     * @since 2.5.1
     */
	MBErrorFacebookOperationInProgress = 70009,
	/**
     * The app is not allowed to access the user’s Facebook account.
     * @since 2.5.1
     */
	MBErrorFacebookAppBlocked = 70010,
	
	/**
     * A different user is already logged in.
     * @since 2.5.1
     */
	MBErrorLoggedInWithDifferentUser = 80001,
	/**
     * The app could not be opened in the market.
     * @since 2.5.1
     */
	MBErrorGameNotOpenedInMarket = 80002,
	/**
     * Too many failed attempts to log in.
     * @since 2.5.1
     */
	MBErrorTooManyFailedLoginAttempts = 90001,
	
	/*** Webview Errors ***/
	/**
     * Did not receive a pingback.
     * @since 2.5.1
     */
	MBErrorNoPingBackFromDocument = 100001,
	/**
     * The requested URL is not valid.
     * @since 2.5.1
     */
	MBErrorInvalidURLResponse = 100002,
	/**
     * A console error occurred while loading.
     * @since 2.5.1
     */
	MBErrorConsoleErrorOnLoad = 100003,
	/**
     * Unable to load the Mobage Bank or Community.
     * @since 2.5.1
     */
	MBErrorUnableToLoadExpierience = 100004,
	/**
     * A problem occurred while loading Mobage webviews.
     * @since 2.5.1
     */
	MBErrorReceivedErrorDuringLoad = 100005,
	/**
     * The Mobage sitemap is malformed, because one of the .json files might not have loaded properly.
     * @since 2.5.1
     */
	MBErrorMalformedSitemap = 10006,
	/**
     * Could not download the Mobage sitemap.
     * @since 2.5.1
     */
	MBErrorUnableToDownloadSitemap = 10007,
	
	
	
} MBErrorEnum;

@class MBError;

@protocol MBError <MBSerializableItem>
+ (MBError *)makeErrorFromString:(NSString *)msg withDomain:(NSString *)domain andCode:(int)code;
+ (MBError *)makeError:(NSError *)err;
+ (MBError *)makeBankError:(NSError *)err;
+ (MBError *)makeErrorFromNSError:(NSError*)error;
+ (MBError *)makeNewErrorFromNSError:(NSError*)error andCode:(int) code;
+ (MBError *)makeMBErrorEnum:(MBErrorEnum)error message:(NSString *) msg;
+ (MBError *)makeErrorFromCode:(int)code;
+ (MBError *)makeErrorFromString:(NSString *)msg addToDictionary:(BOOL)add andCode:(int) code;
+ (MBError*)sharedInstance;
+ (void) initializeMBError;
@property (nonatomic, readonly, strong) NSString * domain;
@property (nonatomic, readonly, strong) NSString * description;
@property (nonatomic, readonly, strong) NSString * localizedDescription;
@property (nonatomic, readonly, assign) NSInteger code;
@end

@interface MBError : NSError <MBError>
@property (nonatomic, strong) NSMutableDictionary * mbErrorDictionary;
@end

#include "MBCError.h"

// deprecated 1.5 errors
typedef enum {
    /*
     * The Mobage server is not currently available.
     * @since 1.5
     */
    kMBMobageApierrorServerDown = 109,
    /*
     * The app must be upgraded to support the current version of Mobage.
     * @since 1.5
     */
    kMBMobageApierrorUpgradeRequired = 110,
    /*
     * The user has been banned from Mobage.
     * @since 1.5
     */
    kMBMobageApierrorUserBanned = 111,
    /*
     * The user has not agreed to the Mobage terms of service.
     * @since 1.5
     */
	kMBMobageApierrorAgreementNeeded = 112,
    /*
     * The request data was invalid.
     * @since 1.5
     */
    kMBMobageApierrorBadRequest = 400,
    /*
     * The specified data was not found.
     * @since 1.5
     */
    kMBMobageApierrorRecordNotFound = 404,
    /*
     * An authentication error occurred.
     * @since 1.5
     */
    kMBMobageApierrorUnauthorized = 401,
    /*
     * Access was forbidden for reasons other than an authentication error.
     * @since 1.5
     */
    kMBMobageApierrorPermissionDenied = 403,
    /*
     * A server error occurred.
     * @since 1.5
     */
	kMBServerError = 10001,
    /*
     * The device cannot connect to the network.
     * @since 1.5
     */
	kMBNetworkUnavailable,
    /*
     * The request was missing required information.
     * @since 1.5
     */
	kMBMissingData,
    /*
     * The request contained invalid data.
     * @since 1.5
     */
	kMBInvalidData,
    /*
     * An unknown error occurred.
     * @since 1.5
     */
	kMBUnknownError,
    /*
     * A message from the server could not be parsed.
     * @since 1.5
     */
	kMBParseError,
    /*
     * There is no authorization token available for the user.
     * @since 1.5
     */
	kMBNoAuthToken,
    /*
     * The user's session is invalid.
     * @since 1.5
     */
    kMBCommonApiInvalidSession = 20001,
    /*
     * The method was called without a required parameter.
     * @since 1.5
     */
    kMBCommonApimethodMissingArgument,
    /*
     * The method was called with an invalid parameter value.
     * @since 1.5
     */
    kMBCommonApimethodInvalidArgument,
    /*
     * The method has not been implemented.
     * @since 1.5
     */
    kMBCommonApimethodNotImplemented,
    /*
     * The current Mobage server does not support this method.
     * @since 1.5
     */
    kMBCommonApimethodNotSupported,
    /*
     * An invalid response was received from the analytics server.
     * @since 1.5
     */
    kMBAnalyticsInvalidResponse = 30001,
    /*
     * The analytics server rejected the request.
     * @since 1.5
     */
    kMBAnalyticsServerRejectedEvent = 30002,
    /*
     * The analytics event size exceeded the maximum size.
     * @since 1.5
     */
    kMBAnalyticsServerEventSizeTooLarge = 30003,
    /*
     * The analytics event property size exceeded the maximum size.
     * @since 1.5
     */
    kMBAnalyticsServerEventPropertySizeTooLarge  = 30004,
    /*
     * The analytics event contained an invalid array.
     * @since 1.5
     */
    kMBAnalyticsServerEventContainsArray = 30005,
    /*
     * The Bank request could not be completed, because the transaction is not in the correct state
     * for the requested method.
     * @since 1.5
     */
    kMBBankErrorInvalidStateTransition = 40001
} LegacyMBMobageAPIErrorType;

/**
 * Enumeration of standard Mobage API errors.
 * @since 2.0
 */
typedef enum {
	/**
	 * A server error occurred.
	 * @since 2.0
	 */
	MBStandardErrorServerError = 10001,
	/**
	 * The device cannot connect to the network.
	 * @since 2.0
	 */
	MBStandardErrorNetworkUnavailable = 10002,
	/**
	 * The request was missing required information.
	 * @since 2.0
	 */
	MBStandardErrorMissingData = 10003,
	/**
	 * The request contained invalid data.
	 * @since 2.0
	 */
	MBStandardErrorInvalidData = 10004,
	/**
	 * An unknown error occurred.
	 * @since 2.0
	 */
	MBStandardErrorUnknownError = 10005,
	/**
	 * A message from the server could not be parsed.
	 * @since 2.0
	 */
	MBStandardErrorParseError = 10006,
	/**
	 * There is no authorization token available for the user.
	 * @since 2.0
	 */
	MBStandardErrorNoAuthToken = 10007
} MBStandardError;
#define IsMBStandardError(error) (!((error < 10001) || (error > 10007)))

/**
 * Enumeration of Mobage errors that relate to HTTP errors.
 * @since 2.0
 */
typedef enum {
	/**
	 * The Mobage server is not currently available.
	 * @since 2.0
	 */
	MBHTTPErrorServerDown = 109,
	/**
	 * The app must be upgraded to support the current version of Mobage.
	 * @since 2.0
	 */
	MBHTTPErrorUpgradeRequired = 110,
	/**
	 * The user has been banned from Mobage.
	 * @since 2.0
	 */
	MBHTTPErrorUserBanned = 111,
	/**
	 * The user has not agreed to the Mobage terms of service.
	 * @since 2.0
	 */
	MBHTTPErrorAgreementNeeded = 112,
	/**
	 * The request data was invalid.
	 * @since 2.0
	 */
	MBHTTPErrorBadRequest = 400,
	/**
	 * The specified data was not found.
	 * @since 2.0
	 */
	MBHTTPErrorRecordNotFound = 404,
	/**
	 * An authentication error occurred.
	 * @since 2.0
	 */
	MBHTTPErrorUnauthorized = 401,
	/**
	 * Access was forbidden for reasons other than an authentication error.
     * <p>
     * You will receive this error if the current Mobage user has a guest account, and you call a
     * method that does not support guest accounts. For more information about guest accounts, see
     * the <a href="https://developer.mobage.com/en/resources/guest_accounts_native">guest accounts
     * overview</a> on the Mobage Developer Portal.
	 * @since 2.0
	 */
	MBHTTPErrorPermissionDenied = 403,
	/**
	 * An internal server error occurred.
     * @since 2.0
	 */
	MBHTTPErrorFirstInternalServerError = 500,
	/**
	 * An unknown error occurred.
     * @since 2.0
	 */
	MBHTTPErrorLastHTTPError = 599
} MBHTTPError;
#define IsMBHTTPError(error) (!((error < 109) || (error > 599)))

/**
 * Enumeration of errors for Mobage's common APIs, which are supported in all regions.
 * @since 2.0
 */
typedef enum {
	/**
	 * The user's session is invalid.
	 * @since 2.0
	 */
	MBCommonAPIInvalidSessionError = 20001,
	/**
	 * The method was called without a required parameter.
	 * @since 2.0
	 */
	MBCommonAPIMethodMissingArgumentError = 20002,
	/**
	 * The method was called with an invalid parameter value.
	 * @since 2.0
	 */
	MBCommonAPIMethodInvalidArgumentError = 20003,
	/**
	 * The method has not been implemented.
	 * @since 2.0
	 */
	MBCommonAPIMethodNotImplementedError = 20004,
	/**
	 * The current Mobage server does not support this method.
	 * @since 2.0
	 */
	MBCommonAPIMethodNotSupportedError = 20005
} MBCommonAPIError;
#define IsMBCommonAPIError(error) (!((error < 20001) || (error > 20005)))

/**
 * Enumeration of Mobage analytics errors.
 * @since 2.0
 */
typedef enum {
	/**
	 * An invalid response was received from the analytics server.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorInvalidResponse = 30001,
	/**
	 * The analytics server rejected the request.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorEventRejected = 30002,
	/**
	 * The analytics event size exceeded the maximum size.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorEventSizeTooLarge = 30003,
	/**
	 * The analytics event property size exceeded the maximum size.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorEventPropertySizeTooLarge = 30004,
	/**
	 * The analytics event contained an invalid array.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorEventContainsInvalidArray = 30005
} MBAnalyticsServerError;
#define IsMBAnalyticsServerError(error) (!((error < 30001) || (error > 30005)))

/**
 * Enumeration of Mobage Bank errors.
 * @since 2.0
 */
typedef enum {
	/**
	 * The transaction is not in the correct state for the requested method.
	 * @since 2.0
	 */
	MBBankErrorInvalidStateTransition = 40001,
	/**
	 * The bank transaction is no longer active.
	 * @since 2.5.1
	 */
	MBBankErrorBankDeadTransaction = 40002,
	/**
	 * The bank inventory item could not be retrieved.
	 * @since 2.5.1
	 */
	MBBankErrorBankGetItemFail = 40003,
	/**
	 * The bank purchase failed.
	 * @since 2.5.1
	 */
	MBBankErrorBankPurchaseFail = 40004,
	/**
	 * The user's account could not be credited. Confirm that the user has an internet 
	 * connection. Then, call <code>MBBankPurchase::getUnfinishedItemTransactions</code>
	 * to retrieve transactions that were interrupted and could not be completed. 
	 * Make sure there’s an internet connection.
	 * @since 2.5.1
	 */
	MBBankErrorBankCreditFail = 40005,
	/**
	 * The bank transaction is already open.
	 * @since 2.5.1
	 */
	MBBankErrorBankTransactionAlreadyOpen = 40006,
	/**
	 * A failure occurred while processing the bank transaction.
	 * @since 2.5.1
	 */
	MBBankErrorBankProcessFail = 40007,
    /**
     * The client is not allowed to perform the requested action.
     * @since 2.5.1
     */
    MBBankErrorInvalidCredentials = 40008,
    /**
     * An unknown Bank error occurred.
     * @since 2.5.1
     */
    MBBankErrorUnknown = 40009,
    /**
     * The user canceled the request.
     * @since 2.5.1
     */
    MBBankErrorPaymentCancelled = 40010,
    /**
     * A request parameter was not recognized by the App Store.
     * @since 2.5.1
     */
    MBBankErrorPaymentInvalid = 40011,
    /**
     * The user is not allowed to authorize payments.
     * @since 2.5.1
     */
    MBBankErrorPaymentNotAllowed = 40012
} MBBankError;
#define IsMBBankError(error) (!((error < 40001) || (error > 40012)))

/**
 * Enumeration of standard Mobage API errors.
 * @since 2.0
 */
typedef enum {
	/**
	 * Auth failed without error, assumed cancelled
	 * @since 2.3
	 */
	MBFacebookErrorUserCancelledAuth = 17000,
	/**
	 * Auth failed because we didn't have required permissions, and user did not accept our request to add them.
	 * @since 2.3
	 */
	MBFacebookErrorUserDeniedRequiredPermissions = 17001,
	/**
	 * The Facebook App ID isn't configured, Facebook auth is disabled.
	 * @since 2.3
	 */
    MBFacebookErrorMissingFacebookAppID = 17002,
	/**
	 * There isn't a URLScheme to handle Facebook's url-based IPC, Facebook auth is disabled.
	 * @since 2.3
	 */
    MBFacebookErrorMissingFacebookURLScheme = 17003,
	/**
	 * No Facebook Session available for this API call.
	 * @since 2.3
	 */
    MBFacebookErrorAPICallRequiresValidSession = 17004,
	/**
	 * Facebook didn't give us an access token.
	 * @since 2.3
	 */
    MBFacebookErrorFacebookDidntSupplyToken = 17005
    
} MBFacebookErrorType;
#define IsMBFacebookError(error) (!((error < 17000) || (error > 17005)))

// added to 2.0 for legacy support only
typedef enum {
	/*
	 *
	 * The Mobage server is not currently available.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeServerDown = 109,
	/*
	 *
	 * The app must be upgraded to support the current version of Mobage.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeUpgradeRequired = 110,
	/*
	 *
	 * The user has been banned from Mobage.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeUserBanned = 111,
	/*
	 *
	 * The user has not agreed to the Mobage terms of service.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAgreementNeeded = 112,
	/*
	 *
	 * The request data was invalid.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeBadRequest = 400,
	/*
	 *
	 * The specified data was not found.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeRecordNotFound = 404,
	/*
	 *
	 * An authentication error occurred.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeUnauthorized = 401,
	/*
	 *
	 * Access was forbidden for reasons other than an authentication error.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypePermissionDenied = 403,
	/*
	 *
	 * A server error occurred.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeServerError = 10001,
	/*
	 *
	 * The device cannot connect to the network.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeNetworkUnavailable = 10002,
	/*
	 *
	 * The request was missing required information.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeMissingData = 10003,
	/*
	 *
	 * The request contained invalid data.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeInvalidData = 10004,
	/*
	 *
	 * An unknown error occurred.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeUnknownError = 10005,
	/*
	 *
	 * A message from the server could not be parsed.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeParseError = 10006,
	/*
	 *
	 * There is no authorization token available for the user.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeNoAuthToken = 10007,
	/*
	 *
	 * The user's session is invalid.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIInvalidSessionError = 20001,
	/*
	 *
	 * The method was called without a required parameter.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIMethodMissingArgumentError = 20002,
	/*
	 *
	 * The method was called with an invalid parameter value.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIMethodInvalidArgumentError = 20003,
	/*
	 *
	 * The method has not been implemented.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIMethodNotImplementedError = 20004,
	/*
	 *
	 * The current Mobage server does not support this method.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIMethodNotSupportedError = 20005,
	/*
	 *
	 * An invalid response was received from the analytics server.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerInvalidResponse = 30001,
	/*
	 *
	 * The analytics server rejected the request.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerEventRejected = 30002,
	/*
	 *
	 * The analytics event size exceeded the maximum size.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerEventSizeTooLarge = 30003,
	/*
	 *
	 * The analytics event property size exceeded the maximum size.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerEventPropertySizeTooLarge = 30004,
	/*
	 *
	 * The analytics event contained an invalid array.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerEventContainsInvalidArray = 30005,
	/*
	 *
	 * The Bank request could not be completed, because the transaction is not in the correct state
	 * for the requested method.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeBankErrorInvalidStateTransition = 40001
} MBMobageAPIErrorType;
#define IsMBMobageAPIErrorType(error) (!((error < 109) || (error > 40001)))


#warning TODO: get rid of error conversion after 2.0 unless we have a darn good reason!
#define MBErrorConvertIfNecessary(err) \
((err && ![kMBMobageAPIErrorDomain isEqualToString:err.domain]) ? \
[MBError makeErrorFromString:[err localizedDescription] withDomain:kMBMobageAPIErrorDomain andCode: [err code] ?: MBMobageAPIErrorTypeUnknownError] :\
err)
