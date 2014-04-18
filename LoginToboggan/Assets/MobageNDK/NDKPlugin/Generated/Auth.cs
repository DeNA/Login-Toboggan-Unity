//
//  Auth.cs
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
	 * <summary> Retrieve a verification code for an OAuth temporary credential, and upgrade Mobage guest accounts to registered accounts.</summary>
	 * <remarks>
	 * This class supports the Mobage REST API, which your app server can use to integrate with Mobage's
	 * Bank and Social features. For more information about the Mobage REST API, see the
	 * <a href="https://developer.mobage.com/en/resources/rest_api_native">Mobage REST API Reference</a>
	 * on the <a href="https://developer.mobage.com/">Mobage Developer Portal</a>.
	 * </remarks>
	 */
	public partial class Auth {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class Auth {

		/**
		 * <summary> Notification that the user's Mobage session has been reestablished.</summary>
		 * <remarks>
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
		 * </remarks>
		 * 
		 */
		public partial class UserSessionReestablishedNotification {
			// Properties!
		}

		/**
		 * <summary> Notification that the user has logged into Mobage.</summary>
		 * <remarks>
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
		 * </remarks>
		 * 
		 */
		public partial class UserLoginNotification {
			// Properties!
		}

		/**
		 * <summary> Notification that the user has logged out of Mobage.</summary>
		 * <remarks>
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
		 * </remarks>
		 * 
		 */
		public partial class UserLogoutNotification {
			// Properties!
		}

		/**
		 * <summary> Notification that the user's Mobage account has been upgraded.</summary>
		 * <remarks>
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
		 * </remarks>
		 * 
		 */
		public partial class UserGradeUpgradeNotification {
			// Properties!
			/**
			 * The user's previous nickname.
			 */
			public String previousNickname;
			/**
			 * The previous type of the user's Mobage account. Contains one of the following values: <ul><li><c>0</c>: Not logged into Mobage.</li><li><c>1</c>: Guest account.</li><li><c>2</c>: Registered account.</li><li><c>3</c>: Verified account. Reserved for future use.</li></ul>
			 */
			public Int32 previousGrade;
			/**
			 * The user's current nickname.
			 */
			public String currentNickname;
			/**
			 * The current type of the user's Mobage account. Contains one of the following values: <ul><li><c>0</c>: Not logged into Mobage.</li><li><c>1</c>: Guest account.</li><li><c>2</c>: Registered account.</li><li><c>3</c>: Verified account. Reserved for future use.</li></ul>
			 */
			public Int32 currentGrade;
		}

	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class Auth {
		/**
		 * <summary> Callback for retrieving a verification code for an OAuth temporary credential.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="verifier" cref="F:System.String">The verification code, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void authorizeToken_onCompleteCallback(SimpleAPIStatus status, Error error, String verifier);

		/**
		 * <summary> Callback for upgrading the current user to a registered account.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Information about the result of the request. <strong>Note</strong>: If the user chooses to close the upgrade dialog, or if the user taps the "Start Over" button to log in as an existing Mobage user, the callback will indicate that the request was canceled.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void executeUserUpgrade_onCompleteCallback(CancelableAPIStatus status, Error error);

		/**
		 * <summary> Callback for upgrading</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Please see a document for new login flow.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void executeUserUpgradeWithParams_onCompleteCallback(CancelableAPIStatus status, Error error);


		
		public static event UserSessionReestablishedNotificationDelegate UserSessionReestablished {
			add {
				UserSessionReestablishedNotificationDelegate_add(value);
			}
			remove {
				UserSessionReestablishedNotificationDelegte_remove(value);
			}
		}
		public delegate void UserSessionReestablishedNotificationDelegate(UserSessionReestablishedNotification notification);

		
		public static event UserLoginNotificationDelegate UserLogin {
			add {
				UserLoginNotificationDelegate_add(value);
			}
			remove {
				UserLoginNotificationDelegte_remove(value);
			}
		}
		public delegate void UserLoginNotificationDelegate(UserLoginNotification notification);

		
		public static event UserLogoutNotificationDelegate UserLogout {
			add {
				UserLogoutNotificationDelegate_add(value);
			}
			remove {
				UserLogoutNotificationDelegte_remove(value);
			}
		}
		public delegate void UserLogoutNotificationDelegate(UserLogoutNotification notification);

		
		public static event UserGradeUpgradeNotificationDelegate UserGradeUpgrade {
			add {
				UserGradeUpgradeNotificationDelegate_add(value);
			}
			remove {
				UserGradeUpgradeNotificationDelegte_remove(value);
			}
		}
		public delegate void UserGradeUpgradeNotificationDelegate(UserGradeUpgradeNotification notification);
	}
#endregion

#region Static Methods
	public partial class Auth {
		/**
		 * <summary> Generate a verification code for an OAuth temporary credential.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="token" cref="F:System.String">The OAuth temporary credential to verify.</param>
		 * <param name="onComplete" cref="F:Mobage.AuthorizeTokenOnCompleteCallback">
		 * Callback for retrieving a verification code for an OAuth temporary credential.</param>
		 * 
		 */
		public static void authorizeToken(String token, authorizeToken_onCompleteCallback onComplete)
		{
			_authorizeToken(token, onComplete);
		}
		/**
		 * <summary> Open the Account Upgrade screen, which prompts the current user to upgrade from a Mobage guest account to a registered account.</summary>
		 * <remarks>
		 * Call this method if the current user has a guest account, and your app needs to use a Mobage
		 * API that is not supported for guest accounts.
		 * <p>
		 * To check whether the current user has a guest account, your app can call
		 * <c>People::getCurrentUser</c>, which retrieves a <c>User</c> object, and then check the
		 * object's <c>grade</c> property.
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.ExecuteUserUpgradeOnCompleteCallback">
		 * Callback for upgrading the current user to a registered account.</param>
		 * 
		 */
		public static void executeUserUpgrade(executeUserUpgrade_onCompleteCallback onComplete)
		{
			_executeUserUpgrade(onComplete);
		}
		/**
		 * <summary> From 2.5.3</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="keys" cref="F:System.Collections.Generic.List<System.String>">Please see a document for new login flow.</param>
		 * <param name="values" cref="F:System.Collections.Generic.List<System.String>">Please see a document for new login flow.</param>
		 * <param name="onComplete" cref="F:Mobage.ExecuteUserUpgradeWithParamsOnCompleteCallback">
		 * Callback for upgrading</param>
		 * 
		 */
		public static void executeUserUpgradeWithParams(List<String> keys, List<String> values, executeUserUpgradeWithParams_onCompleteCallback onComplete)
		{
			_executeUserUpgradeWithParams(keys, values, onComplete);
		}
	}
#endregion


}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
