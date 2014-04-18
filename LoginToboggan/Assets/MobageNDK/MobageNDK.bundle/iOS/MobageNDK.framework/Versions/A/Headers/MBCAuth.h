//
//  MBCAuth.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCAUTH_H_
#define MBCAUTH_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark - Notifications
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
	} MBCUserSessionReestablishedNotification;
	
	MBCUserSessionReestablishedNotification * MBCConstructUserSessionReestablishedNotification(void * __CAPI_NATIVEREF);
	void MBCFillStructUserSessionReestablishedNotification(void * structObj, void * __CAPI_NATIVEREF);
	
	MBCRetainPrototype(UserSessionReestablishedNotification);
	MBCReleasePrototype(UserSessionReestablishedNotification);
	
	/**
	 * MBCUserSessionReestablishedNotificationObserverCallback
	 * @description 	 * Notification that the user's Mobage session has been reestablished.
	 * This notification is posted when:
	 * <ul>
	 * <li>The app is relaunched, and the user's Mobage session is still valid.</li>
	 * <li>The user's Mobage session expired and was reestablished automatically.</li>
	 * <li>The app calls <c>SocialService::executeLogin</c> when the user is already logged in.</li>
	 * </ul>
	 * Add each delegate to a notification only once. If your app adds the delegate more than once,
	 * the Unity SDK's behavior is not defined.
	 * <p>
	 * <strong>Sample Code</strong>
	 * <p>
	 * The following code snippet shows how to listen for a <c>UserSessionReestablished</c>
	 * notification:
	 * <p>
	 * <code>
	 * Mobage.Auth.UserSessionReestablished += delegate(Mobage.Auth.UserSessionReestablishedNotification notification) {
	 *    print("UserSessionReestablished delegate called");
	 * };
	 * </code>
	 */
	typedef void (*MBCUserSessionReestablishedNotificationObserverCallback)(
		void * context,
		/*AUTORELEASED*/MBCUserSessionReestablishedNotification * notification
	);

	void MBCUserSessionReestablishedNotification_registerObserver(void * context, MBCUserSessionReestablishedNotificationObserverCallback callback);
	void MBCUserSessionReestablishedNotification_deregisterObserver(void * context);
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
	} MBCUserLoginNotification;
	
	MBCUserLoginNotification * MBCConstructUserLoginNotification(void * __CAPI_NATIVEREF);
	void MBCFillStructUserLoginNotification(void * structObj, void * __CAPI_NATIVEREF);
	
	MBCRetainPrototype(UserLoginNotification);
	MBCReleasePrototype(UserLoginNotification);
	
	/**
	 * MBCUserLoginNotificationObserverCallback
	 * @description 	 * Notification that the user has logged into Mobage.
	 * This notification is posted after a user:
	 * <ul>
	 * <li>Logs in with a Mobage username and password.</li>
	 * <li>Logs in with a Facebook account.</li>
	 * <li>Creates a new Mobage account.</li>
	 * <li>Signs in as a guest, which creates a new guest account for the user.</li>
	 * </ul>
	 * If the user is already logged in, or if Mobage is able to reestablish the session without
	 * showing the login dialog, your app will receive a <c>UserSessionReestablished</c>
	 * notification rather than a <c>UserLogin</c> notification.
	 * <p>
	 * Add each delegate to a notification only once. If your app adds the delegate more than once,
	 * the Unity SDK's behavior is not defined.
	 * <p>
	 * <strong>Sample Code</strong>
	 * <p>
	 * The following code snippet shows how to listen for a <c>UserLogin</c> notification:
	 * <p>
	 * <code>
	 * Mobage.Auth.UserLogin += delegate(Mobage.Auth.UserLoginNotification notification) {
	 *    print("UserLogin delegate called");
	 * };
	 * </code>
	 */
	typedef void (*MBCUserLoginNotificationObserverCallback)(
		void * context,
		/*AUTORELEASED*/MBCUserLoginNotification * notification
	);

	void MBCUserLoginNotification_registerObserver(void * context, MBCUserLoginNotificationObserverCallback callback);
	void MBCUserLoginNotification_deregisterObserver(void * context);
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
	} MBCUserLogoutNotification;
	
	MBCUserLogoutNotification * MBCConstructUserLogoutNotification(void * __CAPI_NATIVEREF);
	void MBCFillStructUserLogoutNotification(void * structObj, void * __CAPI_NATIVEREF);
	
	MBCRetainPrototype(UserLogoutNotification);
	MBCReleasePrototype(UserLogoutNotification);
	
	/**
	 * MBCUserLogoutNotificationObserverCallback
	 * @description 	 * Notification that the user has logged out of Mobage.
	 * This notification is posted when:
	 * <ul>
	 * <li>The app calls <c>SocialService::executeLogout</c> to end the user's session.
	 * <strong>Note</strong>: If the user has a guest account, you will not receive this
	 * notification.</li>
	 * <li>A user with a guest account taps the "Start Over" button to log in with a Mobage account.
	 * </li>
	 * </ul>
	 * If the Mobage UI is open when the user logs out, your app will not receive a
	 * <c>UserLogout</c> notification until after the Mobage UI has been hidden. This feature
	 * ensures that when your app receives a <c>UserLogout</c> notification, it is always safe to
	 * immediately log the user back into Mobage.
	 * <p>
	 * Add each delegate to a notification only once. If your app adds the delegate more than once,
	 * the Unity SDK's behavior is not defined.
	 * <p>
	 * <strong>Sample Code</strong>
	 * <p>
	 * The following code snippet shows how to listen for a <c>UserLogout</c> notification:
	 * <p>
	 * <code>
	 * Mobage.Auth.UserLogout += delegate(Mobage.Auth.UserLogoutNotification notification) {
	 *    print("UserLogout delegate called");
	 * };
	 * </code>
	 */
	typedef void (*MBCUserLogoutNotificationObserverCallback)(
		void * context,
		/*AUTORELEASED*/MBCUserLogoutNotification * notification
	);

	void MBCUserLogoutNotification_registerObserver(void * context, MBCUserLogoutNotificationObserverCallback callback);
	void MBCUserLogoutNotification_deregisterObserver(void * context);
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * previousNickname);
		MBC_Common_IsActive(int32_t previousGrade);
		MBC_Common_IsActive(const char * currentNickname);
		MBC_Common_IsActive(int32_t currentGrade);
	} MBCUserGradeUpgradeNotification;
	
	MBCUserGradeUpgradeNotification * MBCConstructUserGradeUpgradeNotification(void * __CAPI_NATIVEREF);
	void MBCFillStructUserGradeUpgradeNotification(void * structObj, void * __CAPI_NATIVEREF);
	
	MBCRetainPrototype(UserGradeUpgradeNotification);
	MBCReleasePrototype(UserGradeUpgradeNotification);
	
	/**
	 * MBCUserGradeUpgradeNotificationObserverCallback
	 * @description 	 * Notification that the user's Mobage account has been upgraded.
	 * This notification is posted when a user upgrades from a guest account to a registered
	 * account.
	 * <p>
	 * When a user upgrades their account, the user's nickname is changed. If you display the user's
	 * nickname in your app, you can update the user's nickname when you receive this notification.
	 * <p>
	 * <strong>Important</strong>: For security reasons, if you need to update the user's nickname
	 * on your app server, you must not send the nickname directly to the app server. Instead, the
	 * app must notify the app server that the user's nickname has changed. The app server can then
	 * use the REST API to obtain the new nickname.
	 * <p>
	 * Add each delegate to a notification only once. If your app adds the delegate more than once,
	 * the NDK's behavior is not defined.
	 * <p>
	 * <strong>Sample Code</strong>
	 * <p>
	 * The following code snippet shows how to listen for a <c>UserGradeUpgrade</c> notification:
	 * <p>
	 * <code>
	 * Mobage.Auth.UserGradeUpgrade += delegate(Mobage.Auth.UserGradeUpgradeNotification notification) {
	 *    print("UserGradeUpgrade delegate called");
	 * };
	 * </code>
	 */
	typedef void (*MBCUserGradeUpgradeNotificationObserverCallback)(
		void * context,
		/*AUTORELEASED*/MBCUserGradeUpgradeNotification * notification
	);

	void MBCUserGradeUpgradeNotification_registerObserver(void * context, MBCUserGradeUpgradeNotificationObserverCallback callback);
	void MBCUserGradeUpgradeNotification_deregisterObserver(void * context);
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCAuth_authorizeTokenCallback
	 * @description 	 * Callback for retrieving a verification code for an OAuth temporary credential.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param const char * verifier The verification code, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCAuth_authorizeTokenCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ const char * verifier,
				
				void * context
																);
	/**
	 * MBCAuth_executeUserUpgradeCallback
	 * @description 	 * Callback for upgrading the current user to a registered account.
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request. <strong>Note</strong>: If the user chooses to close the upgrade dialog, or if the user taps the "Start Over" button to log in as an existing Mobage user, the callback will indicate that the request was canceled.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCAuth_executeUserUpgradeCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCAuth_executeUserUpgradeWithParamsCallback
	 * @description 	 * Callback for upgrading
	 * @cb-param MBCCancelableAPIStatus status Please see a document for new login flow.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCAuth_executeUserUpgradeWithParamsCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCAuth_authorizeToken
	 * @function
	 * @public
	 * @description 	 * Generate a verification code for an OAuth temporary credential.
	 *
	 * @param const char *  token The OAuth temporary credential to verify.			AUTORELEASED
	 * @cb AuthorizeTokenOnCompleteCallback  onComplete 
		 * Callback for retrieving a verification code for an OAuth temporary credential.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param const char * verifier The verification code, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCAuth_authorizeToken(
										const char *  token,
										MBCAuth_authorizeTokenCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCAuth_executeUserUpgrade
	 * @function
	 * @public
	 * @description 	 * Open the Account Upgrade screen, which prompts the current user to upgrade from a Mobage guest account to a registered account.
	 * Call this method if the current user has a guest account, and your app needs to use a Mobage
	 * API that is not supported for guest accounts.
	 * <p>
	 * To check whether the current user has a guest account, your app can call
	 * <c>People::getCurrentUser</c>, which retrieves a <c>User</c> object, and then check the
	 * object's <c>grade</c> property.
	 *
	 * @cb ExecuteUserUpgradeOnCompleteCallback  onComplete 
		 * Callback for upgrading the current user to a registered account.			
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request. <strong>Note</strong>: If the user chooses to close the upgrade dialog, or if the user taps the "Start Over" button to log in as an existing Mobage user, the callback will indicate that the request was canceled.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCAuth_executeUserUpgrade(
										MBCAuth_executeUserUpgradeCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCAuth_executeUserUpgradeWithParams
	 * @function
	 * @public
	 * @description 	 * From 2.5.3
	 *
	 * @param MBCString_Array *  keys Please see a document for new login flow.			AUTORELEASED
	 * @param MBCString_Array *  values Please see a document for new login flow.			AUTORELEASED
	 * @cb ExecuteUserUpgradeWithParamsOnCompleteCallback  onComplete 
		 * Callback for upgrading			
	 * @cb-param MBCCancelableAPIStatus status Please see a document for new login flow.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCAuth_executeUserUpgradeWithParams(
										MBCString_Array *  keys,
										MBCString_Array *  values,
										MBCAuth_executeUserUpgradeWithParamsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCAUTH_H_ */

