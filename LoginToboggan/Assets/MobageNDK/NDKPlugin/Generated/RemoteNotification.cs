//
//  RemoteNotification.cs
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
// Mobage don't support Unity Editor right now. (add "-define:HAS_MOBAGE_DESKTOP_SHIM" to /Assets/smcs.rsp to override)


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Mobage {

	/**
	 * <summary> Enables an app to send remote notifications, also known as push notifications, to another Mobage user.</summary>
	 * <remarks>
	 * For example, you could send a remote notification to user A saying that user B had visited their
	 * kingdom.
	 * <p>
	 * To test remote notifications in the sandbox environment, contact
	 * <a href="mailto:submissions@mobage.com">submissions@mobage.com</a> and ask to have remote
	 * notifications enabled for your app. For iOS apps, you will be asked to provide additional
	 * information from the iOS Dev Center.
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
	 * <li>Remote notifications may take a long time to arrive, and there is no guarantee that users
	 * will receive them.</li>
	 * <li>If a user dismisses the remote notification, rather than tapping on it, the payload will not
	 * be delivered to the app.</li>
	 * <li>If an app sends multiple remote notifications, the user may receive only the most recent
	 * notification.</li>
	 * </ul>
	 * <strong>Important</strong>: Do not use remote notifications to provide features that require
	 * reliable messaging, such as delivery of a virtual item.
	 * </remarks>
	 */
	public partial class RemoteNotification {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class RemoteNotification {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class RemoteNotification {
		/**
		 * <summary> Callback for sending a remote notification.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="response" cref="F:Mobage.RemoteNotificationResponse">Information about the Mobage server's response, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void sendToUser_onCompleteCallback(SimpleAPIStatus status, Error error, RemoteNotificationResponse response);

		/**
		 * <summary> Callback for checking whether the current user can receive remote notifications for the current app.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="canBeNotified" cref="F:System.bool">Set to <c>true</c> if notifications are enabled or <c>false</c> if notifications are disabled.</param>
		 */
		public delegate void getRemoteNotificationsEnabled_onCompleteCallback(SimpleAPIStatus status, Error error, bool canBeNotified);

		/**
		 * <summary> Callback for setting whether the current user can receive remote notifications for the current app.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void setRemoteNotificationsEnabled_onCompleteCallback(SimpleAPIStatus status, Error error);

	}
#endregion

#region Static Methods
	public partial class RemoteNotification {
		/**
		 * <summary> Send a remote notification to another Mobage user.</summary>
		 * <remarks>
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
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The notification's recipient.</param>
		 * <param name="message" cref="F:System.String">The notification message.</param>
		 * <param name="badge" cref="F:System.Int32">The numeric badge to display on the app's icon. Used only on iOS.</param>
		 * <param name="sound" cref="F:System.String">The alert sound to play. This property must contain the name of a sound file in the application bundle, or <c>default</c> to play the default alert sound. The sound file must be in a format that is supported for system sounds. Used only on iOS.</param>
		 * <param name="collapseKey" cref="F:System.String">An identifier that causes newer notifications with the same identifier to be discarded. For example, if a user receives four notifications with the same identifier, only the newest notification will be displayed on the user's device. Used only on Android.</param>
		 * <param name="style" cref="F:System.String">The layout style for the notification in the device's notification tray. Set to <c>normal</c> to display a standard-size icon or <c>largeIcon</c> to display a large icon. Used only on Android.</param>
		 * <param name="iconUrl" cref="F:System.String">The URL for the icon to display in the device's notification bar. This value is ignored unless you also use the <c>style</c> parameter to specify the layout style. Used only on Android.</param>
		 * <param name="extraKeys" cref="F:System.Collections.Generic.List<System.String>">The app-specific keys to include in the payload. Each key must be represented as a string. The following key names are reserved and cannot be used:<ul><li><c>badge</c></li><li><c>collapseKey</c></li><li><c>extras</c></li><li><c>iconUrl</c></li><li><c>message</c></li><li><c>sound</c></li><li><c>style</c></li></ul></param>
		 * <param name="extraValues" cref="F:System.Collections.Generic.List<System.String>">The app-specific values to include in the payload. Each value must be represented as a string.</param>
		 * <param name="onComplete" cref="F:Mobage.SendToUserOnCompleteCallback">
		 * Callback for sending a remote notification.</param>
		 * 
		 */
		public static void sendToUser(User user, String message, Int32 badge, String sound, String collapseKey, String style, String iconUrl, List<String> extraKeys, List<String> extraValues, sendToUser_onCompleteCallback onComplete)
		{
			_sendToUser(user, message, badge, sound, collapseKey, style, iconUrl, extraKeys, extraValues, onComplete);
		}
		/**
		 * <summary> Check whether the current user can receive remote notifications for the current app.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.GetRemoteNotificationsEnabledOnCompleteCallback">
		 * Callback for checking whether the current user can receive remote notifications for the current app.</param>
		 * 
		 */
		public static void getRemoteNotificationsEnabled(getRemoteNotificationsEnabled_onCompleteCallback onComplete)
		{
			_getRemoteNotificationsEnabled(onComplete);
		}
		/**
		 * <summary> Set whether the current user can receive remote notifications for the current app.</summary>
		 * <remarks>
		 * Enabling remote notifications fails when the user has disabled them for your app at the OS level or when the
		 * device does not support them.
		 * <p>
		 * Check the <c>status</c> parameter in the <c>onComplete</c> callback to see whether your request to enable
		 * remote notifications succeeded or failed.
		 * </remarks>
		 * <param name="enabled" cref="F:System.bool">Set to <c>true</c> to enable notifications or <c>false</c> to disable notifications.</param>
		 * <param name="onComplete" cref="F:Mobage.SetRemoteNotificationsEnabledOnCompleteCallback">
		 * Callback for setting whether the current user can receive remote notifications for the current app.</param>
		 * 
		 */
		public static void setRemoteNotificationsEnabled(bool enabled, setRemoteNotificationsEnabled_onCompleteCallback onComplete)
		{
			_setRemoteNotificationsEnabled(enabled, onComplete);
		}
	}
#endregion


}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
