//
//  MBRemoteNotification.h
//  mobage-ndk
//
//  Created by Eric So on 4/27/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"
#import "MBRemoteNotificationPayload.h"
#import "MBRemoteNotificationResponse.h"

@protocol MBUser;

/**
 * @file MBRemoteNotification.h
 * Sends remote notifications to other Mobage users.
 * @since 2.0
 */

/**
 * Enables an app to send remote notifications, also known as push notifications, to
 * another Mobage user. For example, you could send a remote notification to user A saying
 * that user B had visited their kingdom.
 * <p>
 * To test remote notifications in the sandbox environment, contact
 * <a href="mailto:submissions@mobage.com">submissions@mobage.com</a> and ask to have remote
 * notifications enabled for your app. You will be asked to provide additional information from the
 * iOS Dev Center.
 * <p>
 * Examples of legitimate uses of this class include:
 * <ul>
 * <li>Inviting a user to the current app.</li>
 * <li>Sending notifications announcing asynchronous app events.</li>
 * <li>Announcing a user-initiated invitation or challenge.</li>
 * <li>Promoting app features that a user has not yet explicitly engaged.</li>
 * </ul>
 * Examples of notifications that do not comply with Mobage platform policies include:
 * <ul>
 * <li>An excessive number of notifications sent by a single app. Your account may be
 * throttled or suspended if your app sends an excessive number of notifications.</li>
 * <li>Notifications promoting other apps.</li>
 * <li>Notifications generated on behalf of a user that are not explicitly approved by the
 * user.</li>
 * </ul>
 * As you develop your app, keep the following limitations in mind:
 * <ul>
 * <li>Remote notifications may take a long time to arrive, and there is no guarantee that
 * users will receive them.</li>
 * <li>If a user dismisses the remote notification, rather than tapping on it, the payload
 * will not be delivered to the app.</li>
 * <li>If an app sends multiple remote notifications, the user may receive only the most
 * recent notification.</li>
 * </ul>
 * <strong>Important</strong>: Do not use remote notifications to provide features that
 * require reliable messaging, such as delivery of a virtual item.
 * @since 2.0
 */
@protocol MBRemoteNotification <NSObject>

#pragma mark - Submit Notifications
// not public
+ (void) sendToUserId:(NSString*) recipientId
			  payload:(NSObject<MBRemoteNotificationPayload>*)payload
    withCallbackQueue:(dispatch_queue_t)cbQueue
		   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBRemoteNotificationResponse> *response))completeCb;

// not public
+(void)sendToUserId:(NSString*)recipientId
            message:(NSString*)message
              badge:(NSInteger)badge
              sound:(NSString*)sound
        collapseKey:(NSString*)collapseKey
              style:(NSString*)style
            iconUrl:(NSString*)iconUrl
         extraKeys:(NSArray*)extraKeys
       extraValues:(NSArray*)extraValues
  withCallbackQueue:(dispatch_queue_t)cbQueue
         onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBRemoteNotificationResponse> *response))completeCb;
 

/**
 * Send a remote notification to another Mobage user. The remote notification is queued on the
 * Mobage server and may not be sent immediately.
 * <p>
 * If the notification's payload exceeds the maximum size, this method will return the error
 * <code>MBHTTPErrorBadRequest</code>.
 * <p>
 * If the current user has a guest account, this method will return the error
 * <code>MBHTTPErrorPermissionDenied</code>.
 * @param recipient The notification's recipient.
 * @param payload Details about the notification.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>response</code>: Information about the Mobage server's response, or <code>nil</code> if
 * the request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) sendToUser:(NSObject<MBUser>*) recipient
			payload:(NSObject<MBRemoteNotificationPayload>*)payload
  withCallbackQueue:(dispatch_queue_t)cbQueue
		 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBRemoteNotificationResponse> *response))completeCb;

// not public
+(void)sendToUser:(NSObject<MBUser>*)recipient
            message:(NSString*)message
              badge:(NSInteger)badge
              sound:(NSString*)sound
        collapseKey:(NSString*)collapseKey
              style:(NSString*)style
            iconUrl:(NSString*)iconUrl
         extraKeys:(NSArray*)extraKeys
       extraValues:(NSArray*)extraValues
  withCallbackQueue:(dispatch_queue_t)cbQueue
         onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBRemoteNotificationResponse> *response))completeCb;

#pragma mark - Check/Set notification state
/**
 * Check whether the current user can receive remote notifications for the current app.
 * This method only checks if remote notifications are enabled on the Mobage servers. Use the
 * iOS API to determine whether remote notifications are enabled on the device.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>enabled</code>: Set to <code>YES</code> if notifications are enabled or <code>NO</code>
 * if notifications are disabled.</li>
 * </ul>
 * @since 2.0
 */
+ (void) getRemoteNotificationsEnabledWithCallbackQueue:(dispatch_queue_t)cbQueue
											 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, BOOL enabled))completeCb;
/**
 * Set whether the current user can receive remote notifications for the current app.
 * This method only enables remote notifications on the Mobage servers. You are
 * responsible for enabling remote notifications on the device.
 * <p>
 * Check the <code>status</code> parameter in the <code>onComplete</code> callback to
 * see whether your request to enable remote notifications succeeded or failed.
 * @param enabled Set to <code>YES</code> to enable notifications or <code>NO</code> to disable
 * notifications.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0
 */
+ (void) setRemoteNotificationsEnabled:(BOOL) enabled
					 withCallbackQueue:(dispatch_queue_t)cbQueue
							onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;

@end
