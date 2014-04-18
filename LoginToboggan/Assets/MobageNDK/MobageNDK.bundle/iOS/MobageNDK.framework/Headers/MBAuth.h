//
//  MBAuth.h
//  mobage-ndk
//
//  Created by Manabu Sato on 3/17/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"

/**
 * @file MBAuth.h
 * Enables app servers to obtain OAuth credentials for the Mobage REST API, and allows apps to
 * upgrade Mobage guest accounts to registered accounts.
 * @since 1.5
 */

/**
 * Retrieve a verification code for an OAuth temporary credential, and upgrade Mobage guest accounts
 * to registered accounts.
 * <p>
 * This class supports the Mobage REST API, which your app server can use to integrate with Mobage's
 * Bank and Social features. For more information about the Mobage REST API, see the
 * <a href="https://developer.mobage.com/en/resources/rest_api">Mobage REST API Reference</a> on the
 * <a href="https://developer.mobage.com/">Mobage Developer Portal</a>.
 * @since 1.5
 */
@protocol MBAuth <NSObject>

/**
 * Generate a verification code for an OAuth temporary credential.
 * @param token The OAuth temporary credential to verify.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>verifier</code>: The verification code, or <code>nil</code> if the request did not
 * succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) authorizeToken: (NSString*) token
	  withCallbackQueue: (dispatch_queue_t)cbQueue
			 onComplete: (void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSString* verifier))completeCb;

/**
 * Open the Account Upgrade screen, which prompts the current user to upgrade from a Mobage guest
 * account to a registered account. Call this method if the current user has a guest account, and
 * your app needs to use a Mobage API that is not supported for guest accounts.
 * <p>
 * To check whether the current user has a guest account, your app can call
 * <code>MBPeople::getCurrentUserWithCallbackQueue:onComplete:</code>, which retrieves a
 * <code>MBUser</code> object, and then check the object's <code>grade</code> property.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request. <strong>Note</strong>: If
 * the user chooses to close the upgrade dialog, or if the user taps the "Start Over" button to log
 * in as an existing Mobage user, the callback will indicate that the request was canceled.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.2
 */
+ (void) executeUserUpgradeWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError>* error))completeCb;

+ (void) executeUserUpgradeWithKeys:(NSArray*)keys values:(NSArray*)values withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError>* error))completeCb;

#pragma mark - Deprecated
@optional
+ (void) authorizeToken : (NSString*) token
			   onSuccess: (void (^)( NSString* verifier))successCB
				 onError: (void (^)( MBError* error))errorCB					__attribute__((deprecated)) /*Deprecated in 1.9*/;

@end
