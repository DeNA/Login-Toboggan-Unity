//
//  MBCSocialService.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCSOCIALSERVICE_H_
#define MBCSOCIALSERVICE_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCItemData.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields
/**
 * Enumeration of constants for placing Mobage UI elements on the display.
 * @region Common
 */
typedef enum {
	/**
	 *
	 * Place object in the top-left of the display.
	 */
	MBCGravityTopLeft = 0, 
	/**
	 * Place object in the top-right of the display.
	 */
	MBCGravityTopRight = 1, 
	/**
	 * Place object in the bottom-left of the display.
	 */
	MBCGravityBottomLeft = 2, 
	/**
	 * Place object in the bottom-right of the display.
	 */
	MBCGravityBottomRight = 3
} MBCGravity;
#define IsMBCGravity(intFlag) (!((intFlag < 0) || (intFlag > 3)))

	#pragma mark - Notifications
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
	} MBCBalanceUpdateNotification;
	
	MBCBalanceUpdateNotification * MBCConstructBalanceUpdateNotification(void * __CAPI_NATIVEREF);
	void MBCFillStructBalanceUpdateNotification(void * structObj, void * __CAPI_NATIVEREF);
	
	MBCRetainPrototype(BalanceUpdateNotification);
	MBCReleasePrototype(BalanceUpdateNotification);
	
	/**
	 * MBCBalanceUpdateNotificationObserverCallback
	 * @description 	 * Notification that the user's balance of MobaCoin (on Android) or app-specific purchased currency (on iOS) has changed.
	 * This notification is sent when the user buys currency, or when your app closes a Bank
	 * transaction by calling <c>BankDebit::closeTransaction</c>.
	 * <p>
	 * If your app displays a custom version of the Balance Button, use this notification to
	 * determine when to update the images in the Balance Button.
	 * <p>
	 * <strong>Important</strong>: If your app server is responsible for closing Bank transactions,
	 * your app will not receive this notification when a transaction is closed.
	 */
	typedef void (*MBCBalanceUpdateNotificationObserverCallback)(
		void * context,
		/*AUTORELEASED*/MBCBalanceUpdateNotification * notification
	);

	void MBCBalanceUpdateNotification_registerObserver(void * context, MBCBalanceUpdateNotificationObserverCallback callback);
	void MBCBalanceUpdateNotification_deregisterObserver(void * context);
	
	#pragma mark - Method Callbacks!
#if MB_JP
	/**
	 * MBCSocialService_openFriendPickerCallback
	 * @description 	 * Callback for retrieving the user's input from the Friend Picker.
	 * @cb-param MBCDismissableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * pickedFriends A list of friends that were chosen, or <c>null</c> if the user did not choose any friends.			AUTORELEASED
	 * @cb-param MBCUser_Array * invitedFriends A list of friends that were invited to try the current app, or <c>null</c> if no friends were invited.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_openFriendPickerCallback)(
				MBCDismissableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser_Array * pickedFriends,
				/*AUTORELEASED*/ MBCUser_Array * invitedFriends,
				
				void * context
																);
#endif // MB_JP
#if MB_JP
	/**
	 * MBCSocialService_openDocumentCallback
	 * @description 
	 * @cb-param MBCDismissableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 */
	typedef void (*MBCSocialService_openDocumentCallback)(
				MBCDismissableAPIStatus status,
				/*AUTORELEASED*/ MBCError * Error,
				
				void * context
																);
#endif // MB_JP
#if MB_KO
	/**
	 * MBCSocialService_openDocumentCallback
	 * @description 
	 * @cb-param MBCDismissableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 */
	typedef void (*MBCSocialService_openDocumentCallback)(
				MBCDismissableAPIStatus status,
				/*AUTORELEASED*/ MBCError * Error,
				
				void * context
																);
#endif // MB_KO
#if MB_JP
	/**
	 * MBCSocialService_openDiaryWriterCallback
	 * @description 
	 * @cb-param MBCDismissableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 * @cb-param bool isWrote 			
	 */
	typedef void (*MBCSocialService_openDiaryWriterCallback)(
				MBCDismissableAPIStatus status,
				/*AUTORELEASED*/ MBCError * Error,
				bool isWrote,
				
				void * context
																);
#endif // MB_JP
#if MB_KO
	/**
	 * MBCSocialService_openDiaryWriterCallback
	 * @description 
	 * @cb-param MBCDismissableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 * @cb-param bool isWrote 			
	 */
	typedef void (*MBCSocialService_openDiaryWriterCallback)(
				MBCDismissableAPIStatus status,
				/*AUTORELEASED*/ MBCError * Error,
				bool isWrote,
				
				void * context
																);
#endif // MB_KO
#if MB_JP
	/**
	 * MBCSocialService_openMinimailSenderCallback
	 * @description 
	 * @cb-param MBCDismissableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 * @cb-param bool isSent 			
	 */
	typedef void (*MBCSocialService_openMinimailSenderCallback)(
				MBCDismissableAPIStatus status,
				/*AUTORELEASED*/ MBCError * Error,
				bool isSent,
				
				void * context
																);
#endif // MB_JP
#if MB_KO
	/**
	 * MBCSocialService_openMinimailSenderCallback
	 * @description 
	 * @cb-param MBCDismissableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 * @cb-param bool isSent 			
	 */
	typedef void (*MBCSocialService_openMinimailSenderCallback)(
				MBCDismissableAPIStatus status,
				/*AUTORELEASED*/ MBCError * Error,
				bool isSent,
				
				void * context
																);
#endif // MB_KO
	/**
	 * MBCSocialService_executeLoginCallback
	 * @description 	 * Callback for logging the user into Mobage.
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_executeLoginCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_executeLoginWithParamsCallback
	 * @description 	 * Called after the request is completed.
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_executeLoginWithParamsCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_executeLogoutCallback
	 * @description 	 * Callback for logging the user out of Mobage.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_executeLogoutCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_showBalanceButtonCallback
	 * @description 	 * Callback for retrieving the Balance Button.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_showBalanceButtonCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_getCurrentBalanceCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param const char * currencyName The name of the app's purchased currency.			AUTORELEASED
	 * @cb-param const char * currencyIconUrl The URL of the icon for the app's purchased currency.			AUTORELEASED
	 * @cb-param int32_t balance 			
	 */
	typedef void (*MBCSocialService_getCurrentBalanceCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ const char * currencyName,
				/*AUTORELEASED*/ const char * currencyIconUrl,
				int32_t balance,
				
				void * context
																);
	/**
	 * MBCSocialService_getCurrentBalanceDetailsCallback
	 * @description 	 * Callback for retrieving images for a customized Balance Button.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param int32_t imageWidth The final width, in pixels, of the image showing the user's balance.			
	 * @cb-param const char * currencyName The name of the app's purchased currency.			AUTORELEASED
	 * @cb-param const char * currencyIconUrl The URL of the icon for the app's purchased currency.			AUTORELEASED
	 * @cb-param const char * balanceImageUrl A <c>data:</c> URL containing a Base64-encoded image that shows the user's current balance of purchased currency. The text is rendered in white using the default system font.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_getCurrentBalanceDetailsCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				int32_t imageWidth,
				/*AUTORELEASED*/ const char * currencyName,
				/*AUTORELEASED*/ const char * currencyIconUrl,
				/*AUTORELEASED*/ const char * balanceImageUrl,
				
				void * context
																);
	/**
	 * MBCSocialService_showPromotionsCallback
	 * @description 
	 * @cb-param MBCDismissableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_showPromotionsCallback)(
				MBCDismissableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_checkFacebookStatusCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param const char * userId 			AUTORELEASED
	 * @cb-param const char * facebookId 			AUTORELEASED
	 * @cb-param const char * accessToken 			AUTORELEASED
	 */
	typedef void (*MBCSocialService_checkFacebookStatusCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ const char * userId,
				/*AUTORELEASED*/ const char * facebookId,
				/*AUTORELEASED*/ const char * accessToken,
				
				void * context
																);
	/**
	 * MBCSocialService_getFacebookIdCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param const char * userId 			AUTORELEASED
	 * @cb-param const char * facebookId 			AUTORELEASED
	 */
	typedef void (*MBCSocialService_getFacebookIdCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ const char * userId,
				/*AUTORELEASED*/ const char * facebookId,
				
				void * context
																);
	/**
	 * MBCSocialService_getASCItemsCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param MBCItemData_Array * items 			AUTORELEASED
	 */
	typedef void (*MBCSocialService_getASCItemsCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCItemData_Array * items,
				
				void * context
																);
	/**
	 * MBCSocialService_purchaseASCItemCallback
	 * @description 
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_purchaseASCItemCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_giftASCCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param int32_t amount 			
	 */
	typedef void (*MBCSocialService_giftASCCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				int32_t amount,
				
				void * context
																);
	
	#pragma mark - Static Methods
#if MB_JP
	/**
	 * MBCSocialService_openFriendPicker
	 * @function
	 * @public
	 * @description 	 * !!!! Remove from WW !!!!
	 *
	 * Open the Friend Picker, which enables the user to choose a list of their friends, with a maximum number of friends that you specify.
	 * The user can select from their entire list of Mobage friends, or they can select only from
	 * friends who have used the current app. The selected users are passed to the callback. If any
	 * of the selected friends are not using the current app, they will be invited to do so, and the
	 * selected friends are passed to the callback.
	 * <p>
	 * This method displays the Mobage user interface. To optimize performance, pause the app or
	 * reduce the app's frame rate before calling this method.
	 * @deprecated This method will be removed in a future version.
	 *
	 * @param int32_t  maxFriendsToSelect The maximum number of friends that the user may select. Use the value <c>0</c> to allow the user to select an unlimited number of friends.			
	 * @cb OpenFriendPickerOnCompleteCallback  onComplete 
		 * Callback for retrieving the user's input from the Friend Picker.			
	 * @cb-param MBCDismissableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * pickedFriends A list of friends that were chosen, or <c>null</c> if the user did not choose any friends.			AUTORELEASED
	 * @cb-param MBCUser_Array * invitedFriends A list of friends that were invited to try the current app, or <c>null</c> if no friends were invited.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_openFriendPicker(
										int32_t  maxFriendsToSelect,
										MBCSocialService_openFriendPickerCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_JP
#if MB_JP
	/**
	 * MBCSocialService_openDocument
	 * @function
	 * @public
	 * @description 	 Open the Terms and Conditions screen
	 *
	 * @param const char *  path Open the Terms and Conditions screen			AUTORELEASED
	 * @cb OpenDocumentOnCompleteCallback  onComplete Open the Terms and Conditions screen			
	 * @cb-param MBCDismissableAPIStatus status Open the Terms and Conditions screen			
	 * @cb-param MBCError * Error Open the Terms and Conditions screen			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_openDocument(
										const char *  path,
										MBCSocialService_openDocumentCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_JP
#if MB_KO
	/**
	 * MBCSocialService_openDocument
	 * @function
	 * @public
	 * @description 
	 *
	 * @param const char *  path 			AUTORELEASED
	 * @cb OpenDocumentOnCompleteCallback  onComplete 			
	 * @cb-param MBCDismissableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_openDocument(
										const char *  path,
										MBCSocialService_openDocumentCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_KO
#if MB_JP
	/**
	 * MBCSocialService_openDiaryWriter
	 * @function
	 * @public
	 * @description 	 Open the Diary screen
	 *
	 * @param const char *  subject Open the Diary screen			AUTORELEASED
	 * @param const char *  body Open the Diary screen			AUTORELEASED
	 * @param const char *  imageUrl Open the Diary screen			AUTORELEASED
	 * @cb OpenDiaryWriterOnCompleteCallback  onComplete Open the Diary screen			
	 * @cb-param MBCDismissableAPIStatus status Open the Diary screen			
	 * @cb-param MBCError * Error Open the Diary screen			AUTORELEASED
	 * @cb-param bool isWrote Open the Diary screen			
	 * <br/>
	 * 
	 */
	void MBCSocialService_openDiaryWriter(
										const char *  subject,
										const char *  body,
										const char *  imageUrl,
										MBCSocialService_openDiaryWriterCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_JP
#if MB_KO
	/**
	 * MBCSocialService_openDiaryWriter
	 * @function
	 * @public
	 * @description 
	 *
	 * @param const char *  subject 			AUTORELEASED
	 * @param const char *  body 			AUTORELEASED
	 * @param const char *  imageUrl 			AUTORELEASED
	 * @cb OpenDiaryWriterOnCompleteCallback  onComplete 			
	 * @cb-param MBCDismissableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 * @cb-param bool isWrote 			
	 * <br/>
	 * 
	 */
	void MBCSocialService_openDiaryWriter(
										const char *  subject,
										const char *  body,
										const char *  imageUrl,
										MBCSocialService_openDiaryWriterCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_KO
#if MB_JP
	/**
	 * MBCSocialService_openMinimailSender
	 * @function
	 * @public
	 * @description 	 Open the Minimail screen
	 *
	 * @param const char *  userId Open the Minimail screen			AUTORELEASED
	 * @param const char *  subject Open the Minimail screen			AUTORELEASED
	 * @param const char *  body Open the Minimail screen			AUTORELEASED
	 * @cb OpenMinimailSenderOnCompleteCallback  onComplete Open the Minimail screen			
	 * @cb-param MBCDismissableAPIStatus status Open the Minimail screen			
	 * @cb-param MBCError * Error Open the Minimail screen			AUTORELEASED
	 * @cb-param bool isSent Open the Minimail screen			
	 * <br/>
	 * 
	 */
	void MBCSocialService_openMinimailSender(
										const char *  userId,
										const char *  subject,
										const char *  body,
										MBCSocialService_openMinimailSenderCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_JP
#if MB_KO
	/**
	 * MBCSocialService_openMinimailSender
	 * @function
	 * @public
	 * @description 
	 *
	 * @param const char *  userId 			AUTORELEASED
	 * @param const char *  subject 			AUTORELEASED
	 * @param const char *  body 			AUTORELEASED
	 * @cb OpenMinimailSenderOnCompleteCallback  onComplete 			
	 * @cb-param MBCDismissableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 * @cb-param bool isSent 			
	 * <br/>
	 * 
	 */
	void MBCSocialService_openMinimailSender(
										const char *  userId,
										const char *  subject,
										const char *  body,
										MBCSocialService_openMinimailSenderCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_KO
	/**
	 * MBCSocialService_executeLogin
	 * @function
	 * @public
	 * @description 	 * Log the user into Mobage, displaying the Login Dialog if necessary.
	 * <p>
	 * In version 2.2 and later, this method does not allow users to dismiss the Login Dialog. To
	 * include a cancel button on the Login Dialog, use the method
	 * <c>SocialService::executeLoginWithParams</c>.
	 * <p>
	 * <strong>Important</strong>: If you log out the current user by calling
	 * <c>SocialService::executeLogout</c>, you must not attempt to log the user into Mobage until
	 * the logout dialog is no longer visible. Your app can listen for a <c>MobageUIVisible</c>
	 * notification to determine when the dialog is no longer visible.
	 *
	 * @cb ExecuteLoginOnCompleteCallback  onComplete 
		 * Callback for logging the user into Mobage.			
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_executeLogin(
										MBCSocialService_executeLoginCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_executeLoginWithParams
	 * @function
	 * @public
	 * @description 	 * Log the user into Mobage using the specified key-value pairs as configuration parameters, and displaying the Login Dialog if necessary.
	 * <p>
	 * When you call this method and set the <c>LOGIN_OPTIONALITY</c> key to <c>optional</c>, the
	 * Login Dialog will include a cancel button. You may only include a cancel button on the Login
	 * Dialog if the user has not completed the app's tutorial or initial level. After that time,
	 * you must require the user to log into Mobage.
	 * <p>
	 * <strong>Important</strong>: If you log out the current user by calling
	 * <c>SocialService::executeLogout</c>, you must not attempt to log the user into Mobage until
	 * the logout dialog is no longer visible. Your app can listen for a <c>MobageUIVisible</c>
	 * notification to determine when the dialog is no longer visible.
	 *
	 * @param MBCString_Array *  keys Keys for configuring the login process. The only supported key is <c>LOGIN_OPTIONALITY</c>.			AUTORELEASED
	 * @param MBCString_Array *  values Values associated with the keys. The key <c>LOGIN_OPTIONALITY</c> accepts the following values:<ul><li><c>mandatory</c>: Require the user to log into Mobage immediately. Do not show a cancel button on the Login Dialog.</li><li><c>optional</c>: Allow the user to defer the login process by pressing a cancel button on the Login Dialog.</li>			AUTORELEASED
	 * @cb ExecuteLoginWithParamsOnCompleteCallback  onComplete 
		 * Called after the request is completed.			
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_executeLoginWithParams(
										MBCString_Array *  keys,
										MBCString_Array *  values,
										MBCSocialService_executeLoginWithParamsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_executeLogout
	 * @function
	 * @public
	 * @description 	 * Log the user out of Mobage, and clear the current session.
	 * <strong>Note</strong>: If the current user has a guest account, calling this method has no
	 * effect.
	 * <p>
	 * <strong>Important</strong>: After calling this method, do not call
	 * <c>SocialService::executeLogin</c> or <c>SocialService::executeLoginWithParams</c> until the
	 * logout dialog is no longer visible. Your app can listen for a <c>MobageUIVisible</c>
	 * notification to determine when the dialog is no longer visible.
	 *
	 * @cb ExecuteLogoutOnCompleteCallback  onComplete 
		 * Callback for logging the user out of Mobage.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_executeLogout(
										MBCSocialService_executeLogoutCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_openUserProfile
	 * @function
	 * @public
	 * @description 	 * Open the User Profile screen for the specified Mobage user.
	 * Opening the current user's profile allows the user to edit the profile.
	 * <p>
	 * This method displays the Mobage user interface. To optimize performance, pause the app or
	 * reduce the app's frame rate before calling this method.
	 *
	 * @param MBCUser *  user The user whose profile will be displayed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_openUserProfile(
										MBCUser *  user,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_showCommunityUI
	 * @function
	 * @public
	 * @description 	 * Display the Mobage user interface.
	 * Your app must call this method when the user taps the Community Button.
	 * <p>
	 * This method displays the Mobage user interface. To optimize performance, pause the app or
	 * reduce the app's frame rate before calling this method.
	 *
	 * <br/>
	 * 
	 */
	void MBCSocialService_showCommunityUI(
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_showCommunityButton
	 * @function
	 * @public
	 * @description 	 * Display the Community Button, which lets the user open the Mobage user interface.
	 *
	 * @param MBCGravity  gravity Button placement.			
	 * @param const char *  theme Button color scheme. Choices are:<ul><li><c>basic</c>&mdash;Blue %Mobage logo on a white background.</li><li><c>blue</c>&mdash;White %Mobage logo on a blue background.</li><li><c>dark</c>&mdash;White %Mobage logo on a black background.</li><li><c>gray</c>&mdash;Black %Mobage logo on a light gray background.</li></ul>			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_showCommunityButton(
										MBCGravity  gravity,
										const char *  theme,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_hideCommunityButton
	 * @function
	 * @public
	 * @description 	 * Hide the Community Button.
	 *
	 * <br/>
	 * 
	 */
	void MBCSocialService_hideCommunityButton(
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_openBankDialog
	 * @function
	 * @public
	 * @description 	 * Open the Bank, which lets a user check their balance of purchased currency or buy additional currency.
	 * <p>
	 * This method displays the Mobage user interface. To optimize performance, pause the app or
	 * reduce the frame rate before calling this method.
	 *
	 * <br/>
	 * 
	 */
	void MBCSocialService_openBankDialog(
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_showBalanceButton
	 * @function
	 * @public
	 * @description 	 * Display the Balance Button for the Mobage Bank, which displays the user's current balance of purchased currency and opens the Bank.
	 * The Balance Button's minimum height is the largest of the following values:
	 * <ul>
	 * <li>50 pixels.</li>
	 * <li>In landscape mode, 10% of the screen's height.</li>
	 * <li>In portrait mode, 6% of the screen's height.</li>
	 * </ul>
	 * The Balance Button's width must be at least three times its height. For example, if the
	 * Balance Button's minimum height is 50 pixels, its minimum width is 150 pixels.
	 *
	 * @param int32_t  x The X coordinate at which to place the Balance Button's upper left corner.			
	 * @param int32_t  y The Y coordinate at which to place the Balance Button's upper left corner.			
	 * @param int32_t  width The width of the Balance Button.			
	 * @param int32_t  height The height of the Balance Button.			
	 * @cb ShowBalanceButtonOnCompleteCallback  onComplete 
		 * Callback for retrieving the Balance Button.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_showBalanceButton(
										int32_t  x,
										int32_t  y,
										int32_t  width,
										int32_t  height,
										MBCSocialService_showBalanceButtonCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_getCurrentBalance
	 * @function
	 * @public
	 * @description 
	 *
	 * @cb GetCurrentBalanceOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param const char * currencyName The name of the app's purchased currency.			AUTORELEASED
	 * @cb-param const char * currencyIconUrl The URL of the icon for the app's purchased currency.			AUTORELEASED
	 * @cb-param int32_t balance 			
	 * <br/>
	 * 
	 */
	void MBCSocialService_getCurrentBalance(
										MBCSocialService_getCurrentBalanceCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_hideBalanceButton
	 * @function
	 * @public
	 * @description 	 * Hide the Balance Button for the Mobage Bank.
	 *
	 * <br/>
	 * 
	 */
	void MBCSocialService_hideBalanceButton(
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_getCurrentBalanceDetails
	 * @function
	 * @public
	 * @description 	 * Retrieve images that your app can combine into a customized Balance Button, which displays the user's balance of MobaCoin (on Android) or app-specific purchased currency (on iOS).
	 * Using this method enables you to tailor the Balance Button's appearance so it fits gracefully
	 * into your app.
	 * <p>
	 * <strong>Note</strong>: The app must hide the custom Balance Button when it receives a
	 * <c>UserLogoutNotification</c>.
	 * <p>
	 * The callback for this method receives the following information:
	 * <ul>
	 * <li>An image, provided as a <c>data:</c> URL, showing the user's balance. The image is
	 * rendered in white using the default system font. You can specify the image's height in
	 * pixels; the callback receives the width of the rendered image.</li>
	 * <li>The URL for an icon depicting the purchased currency.</li>
	 * <li>The name of the purchased currency.</li>
	 * </ul>
	 * When the user taps the custom Balance Button, your app must call the method
	 * <c>SocialService::openBankDialog</c>, which displays the Bank screen.
	 * <p>
	 * Your app must update the custom Balance Button when the user's balance changes. To determine
	 * when the balance has changed, add an observer to the <c>BalanceUpdateNotification</c> that
	 * updates your app's custom Balance Button.
	 * <p>
	 * <strong>Important</strong>: If your app server is responsible for closing Bank transactions,
	 * you will not receive a <c>BalanceUpdateNotification</c> when a transaction is closed.
	 * Instead, your app server must notify the app that it should update the images in the Balance
	 * Button.
	 * <p>
	 * If you do not want to display a custom Balance Button, call
	 * <c>SocialService::showBalanceButton</c> to display Mobage's standard Balance Button.
	 * <p>
	 * As noted above, the callback receives the balance image as a <c>data:</c> URL. The following
	 * example shows how the callback can convert the URL to a usable image.
	 * @code
	 * // balanceImage is the data: URL passed to the callback
	 * byte[] decodedBytes =
	 *     System.Convert.FromBase64String(balanceImage.Substring(dataString.IndexOf("base64") + 7));
	 * Texture2D tex = new Texture2D(1, 1); // Size will be updated by LoadImage
	 * tex.LoadImage(decodedBytes);
	 * @endcode
	 *
	 * @param int32_t  imageHeight The height, in pixels, to use for the image showing the user's balance.			
	 * @cb GetCurrentBalanceDetailsOnCompleteCallback  onComplete 
		 * Callback for retrieving images for a customized Balance Button.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param int32_t imageWidth The final width, in pixels, of the image showing the user's balance.			
	 * @cb-param const char * currencyName The name of the app's purchased currency.			AUTORELEASED
	 * @cb-param const char * currencyIconUrl The URL of the icon for the app's purchased currency.			AUTORELEASED
	 * @cb-param const char * balanceImageUrl A <c>data:</c> URL containing a Base64-encoded image that shows the user's current balance of purchased currency. The text is rendered in white using the default system font.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_getCurrentBalanceDetails(
										int32_t  imageHeight,
										MBCSocialService_getCurrentBalanceDetailsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_showPromotions
	 * @function
	 * @public
	 * @description 
	 *
	 * @param MBCString_Array *  keys Please see a document for new login flow			AUTORELEASED
	 * @param MBCString_Array *  values Please see a document for new login flow			AUTORELEASED
	 * @cb ShowPromotionsOnCompleteCallback  onComplete 			
	 * @cb-param MBCDismissableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_showPromotions(
										MBCString_Array *  keys,
										MBCString_Array *  values,
										MBCSocialService_showPromotionsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_checkFacebookStatus
	 * @function
	 * @public
	 * @description 
	 *
	 * @cb CheckFacebookStatusOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param const char * userId 			AUTORELEASED
	 * @cb-param const char * facebookId 			AUTORELEASED
	 * @cb-param const char * accessToken 			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_checkFacebookStatus(
										MBCSocialService_checkFacebookStatusCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_getFacebookId
	 * @function
	 * @public
	 * @description 
	 *
	 * @cb GetFacebookIdOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param const char * userId 			AUTORELEASED
	 * @cb-param const char * facebookId 			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_getFacebookId(
										MBCSocialService_getFacebookIdCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_getASCItems
	 * @function
	 * @public
	 * @description 
	 *
	 * @cb GetASCItemsOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param MBCItemData_Array * items 			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_getASCItems(
										MBCSocialService_getASCItemsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_purchaseASCItem
	 * @function
	 * @public
	 * @description 
	 *
	 * @param MBCItemData *  item 			AUTORELEASED
	 * @cb PurchaseASCItemOnCompleteCallback  onComplete 			
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCSocialService_purchaseASCItem(
										MBCItemData *  item,
										MBCSocialService_purchaseASCItemCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_giftASC
	 * @function
	 * @public
	 * @description 
	 *
	 * @param const char *  giftCode 			AUTORELEASED
	 * @cb GiftASCOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param int32_t amount 			
	 * <br/>
	 * 
	 */
	void MBCSocialService_giftASC(
										const char *  giftCode,
										MBCSocialService_giftASCCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCSOCIALSERVICE_H_ */

