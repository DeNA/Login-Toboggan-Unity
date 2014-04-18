//
//  MBCRemoteNotification.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREMOTENOTIFICATION_H_
#define MBCREMOTENOTIFICATION_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCRemoteNotificationResponse.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCRemoteNotification_sendToUserCallback
	 * @description 	 * Callback for sending a remote notification.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCRemoteNotificationResponse * response Information about the Mobage server's response, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCRemoteNotification_sendToUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCRemoteNotificationResponse * response,
				
				void * context
																);
	/**
	 * MBCRemoteNotification_getRemoteNotificationsEnabledCallback
	 * @description 	 * Callback for checking whether the current user can receive remote notifications for the current app.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param bool canBeNotified Set to <c>true</c> if notifications are enabled or <c>false</c> if notifications are disabled.			
	 */
	typedef void (*MBCRemoteNotification_getRemoteNotificationsEnabledCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				bool canBeNotified,
				
				void * context
																);
	/**
	 * MBCRemoteNotification_setRemoteNotificationsEnabledCallback
	 * @description 	 * Callback for setting whether the current user can receive remote notifications for the current app.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCRemoteNotification_setRemoteNotificationsEnabledCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCRemoteNotification_sendToUser
	 * @function
	 * @public
	 * @description 	 * Send a remote notification to another Mobage user.
	 * <p>
	 * The remote notification is queued on the Mobage server and may not be sent immediately. The
	 * maximum size of the notification's content is 256 bytes. If the content exceeds the maximum
	 * size, this method returns the error <c>Mobage::HTTPError:BadRequest</c>.
	 * <p>
	 * The notification can include app-specific key/value pairs that trigger a special behavior in
	 * your app, such as displaying a message to the user on launch. These key/value pairs are
	 * stored in the <c>extraKeys</c> and <c>extraValues</c> properties.
	 * <p>
	 * <strong>Note</strong>: Some parameters are used only on Android or iOS, but not both. The
	 * Mobage server automatically discards any parameters that are not supported by the target
	 * user's device. Discarded parameters do not count towards the 256-byte limit.
	 * <p>
	 * If the current user has a guest account, this method returns the error
	 * <c>Mobage::HTTPError:PermissionDenied</c>.
	 *
	 * @param MBCUser *  user The notification's recipient.			AUTORELEASED
	 * @param const char *  message The notification message.			AUTORELEASED
	 * @param int32_t  badge The numeric badge to display on the app's icon. Used only on iOS.			
	 * @param const char *  sound The alert sound to play. This property must contain the name of a sound file in the application bundle, or <c>default</c> to play the default alert sound. The sound file must be in a format that is supported for system sounds. Used only on iOS.			AUTORELEASED
	 * @param const char *  collapseKey An identifier that causes newer notifications with the same identifier to be discarded. For example, if a user receives four notifications with the same identifier, only the newest notification will be displayed on the user's device. Used only on Android.			AUTORELEASED
	 * @param const char *  style The layout style for the notification in the device's notification tray. Set to <c>normal</c> to display a standard-size icon or <c>largeIcon</c> to display a large icon. Used only on Android.			AUTORELEASED
	 * @param const char *  iconUrl The URL for the icon to display in the device's notification bar. This value is ignored unless you also use the <c>style</c> parameter to specify the layout style. Used only on Android.			AUTORELEASED
	 * @param MBCString_Array *  extraKeys The app-specific keys to include in the payload. Each key must be represented as a string. The following key names are reserved and cannot be used:<ul><li><c>badge</c></li><li><c>collapseKey</c></li><li><c>extras</c></li><li><c>iconUrl</c></li><li><c>message</c></li><li><c>sound</c></li><li><c>style</c></li></ul>			AUTORELEASED
	 * @param MBCString_Array *  extraValues The app-specific values to include in the payload. Each value must be represented as a string.			AUTORELEASED
	 * @cb SendToUserOnCompleteCallback  onComplete 
		 * Callback for sending a remote notification.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCRemoteNotificationResponse * response Information about the Mobage server's response, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCRemoteNotification_sendToUser(
										MBCUser *  user,
										const char *  message,
										int32_t  badge,
										const char *  sound,
										const char *  collapseKey,
										const char *  style,
										const char *  iconUrl,
										MBCString_Array *  extraKeys,
										MBCString_Array *  extraValues,
										MBCRemoteNotification_sendToUserCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCRemoteNotification_getRemoteNotificationsEnabled
	 * @function
	 * @public
	 * @description 	 * Check whether the current user can receive remote notifications for the current app.
	 *
	 * @cb GetRemoteNotificationsEnabledOnCompleteCallback  onComplete 
		 * Callback for checking whether the current user can receive remote notifications for the current app.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param bool canBeNotified Set to <c>true</c> if notifications are enabled or <c>false</c> if notifications are disabled.			
	 * <br/>
	 * 
	 */
	void MBCRemoteNotification_getRemoteNotificationsEnabled(
										MBCRemoteNotification_getRemoteNotificationsEnabledCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCRemoteNotification_setRemoteNotificationsEnabled
	 * @function
	 * @public
	 * @description 	 * Set whether the current user can receive remote notifications for the current app.
	 * Enabling remote notifications fails when the user has disabled them for your app at the OS level or when the
	 * device does not support them.
	 * <p>
	 * Check the <c>status</c> parameter in the <c>onComplete</c> callback to see whether your request to enable
	 * remote notifications succeeded or failed.
	 *
	 * @param bool  enabled Set to <c>true</c> to enable notifications or <c>false</c> to disable notifications.			
	 * @cb SetRemoteNotificationsEnabledOnCompleteCallback  onComplete 
		 * Callback for setting whether the current user can receive remote notifications for the current app.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCRemoteNotification_setRemoteNotificationsEnabled(
										bool  enabled,
										MBCRemoteNotification_setRemoteNotificationsEnabledCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCREMOTENOTIFICATION_H_ */

