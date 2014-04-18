//
//  SocialService.cs
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
	 * <summary> Display components of the Mobage user interface.</summary>
	 * <remarks>
	 * The following components are available:
	 * <ul>
	 * <li>The Balance Button, which displays the user's balance of app-specific purchased
	 * currency.</li>
	 * <li>The Bank, which lets a user check their balance of app-specific purchased currency or
	 * buy additional currency.</li>
	 * <li>The Login Dialog, which lets the user log into Mobage.</li>
	 * <li>The Community Button, which lets the user open the Mobage Community user interface.</li>
	 * <li>The Mobage Community user interface.</li>
	 * <li>The User Profile screen, which shows a user's Mobage profile.</li>
	 * </ul>
	 * </remarks>
	 */
	public partial class SocialService {}
	#region Enums / Bitfields
		/**
		 * Enumeration of constants for placing Mobage UI elements on the display.
		 */
		public enum Gravity {
			/**
					 *
		 * Place object in the top-left of the display.
			 */
			TopLeft = 0, 
			/**
					 * Place object in the top-right of the display.
			 */
			TopRight = 1, 
			/**
					 * Place object in the bottom-left of the display.
			 */
			BottomLeft = 2, 
			/**
					 * Place object in the bottom-right of the display.
			 */
			BottomRight = 3, 
		};

	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields

	 * Enumeration of constants for placing Mobage UI elements on the display.

	public enum Gravity {

				 *
		 * Place object in the top-left of the display.

		TopLeft = 0, 

				 * Place object in the top-right of the display.

		TopRight = 1, 

				 * Place object in the bottom-left of the display.

		BottomLeft = 2, 

				 * Place object in the bottom-right of the display.

		BottomRight = 3, 
	};
	
#endregion
*/
	
#region Notifications!
	public partial class SocialService {

		/**
		 * <summary> Notification that the user's balance of MobaCoin (on Android) or app-specific purchased currency (on iOS) has changed.</summary>
		 * <remarks>
		 * This notification is sent when the user buys currency, or when your app closes a Bank
		 * transaction by calling <c>BankDebit::closeTransaction</c>.
		 * <p>
		 * If your app displays a custom version of the Balance Button, use this notification to
		 * determine when to update the images in the Balance Button.
		 * <p>
		 * <strong>Important</strong>: If your app server is responsible for closing Bank transactions,
		 * your app will not receive this notification when a transaction is closed.
		 * </remarks>
		 * 
		 */
		public partial class BalanceUpdateNotification {
			// Properties!
		}

	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class SocialService {
#if MB_JP
		/**
		 * <summary> Callback for retrieving the user's input from the Friend Picker.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.DismissableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="pickedFriends" cref="F:System.Collections.Generic.List<Mobage.User>">A list of friends that were chosen, or <c>null</c> if the user did not choose any friends.</param>
		 * <param name="invitedFriends" cref="F:System.Collections.Generic.List<Mobage.User>">A list of friends that were invited to try the current app, or <c>null</c> if no friends were invited.</param>
		 */
		public delegate void openFriendPicker_onCompleteCallback(DismissableAPIStatus status, Error error, List<User> pickedFriends, List<User> invitedFriends);
#endif //MB_JP
#if MB_JP
		public delegate void openDocument_onCompleteCallback(DismissableAPIStatus status, Error Error);
#endif //MB_JP
#if MB_KO
		public delegate void openDocument_onCompleteCallback(DismissableAPIStatus status, Error Error);
#endif //MB_KO
#if MB_JP
		public delegate void openDiaryWriter_onCompleteCallback(DismissableAPIStatus status, Error Error, bool isWrote);
#endif //MB_JP
#if MB_KO
		public delegate void openDiaryWriter_onCompleteCallback(DismissableAPIStatus status, Error Error, bool isWrote);
#endif //MB_KO
#if MB_JP
		public delegate void openMinimailSender_onCompleteCallback(DismissableAPIStatus status, Error Error, bool isSent);
#endif //MB_JP
#if MB_KO
		public delegate void openMinimailSender_onCompleteCallback(DismissableAPIStatus status, Error Error, bool isSent);
#endif //MB_KO
		/**
		 * <summary> Callback for logging the user into Mobage.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void executeLogin_onCompleteCallback(CancelableAPIStatus status, Error error);

		/**
		 * <summary> Called after the request is completed.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void executeLoginWithParams_onCompleteCallback(CancelableAPIStatus status, Error error);

		/**
		 * <summary> Callback for logging the user out of Mobage.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void executeLogout_onCompleteCallback(SimpleAPIStatus status, Error error);

		/**
		 * <summary> Callback for retrieving the Balance Button.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void showBalanceButton_onCompleteCallback(SimpleAPIStatus status, Error error);

		public delegate void getCurrentBalance_onCompleteCallback(SimpleAPIStatus status, Error error, String currencyName, String currencyIconUrl, Int32 balance);

		/**
		 * <summary> Callback for retrieving images for a customized Balance Button.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="imageWidth" cref="F:System.Int32">The final width, in pixels, of the image showing the user's balance.</param>
		 * <param name="currencyName" cref="F:System.String">The name of the app's purchased currency.</param>
		 * <param name="currencyIconUrl" cref="F:System.String">The URL of the icon for the app's purchased currency.</param>
		 * <param name="balanceImageUrl" cref="F:System.String">A <c>data:</c> URL containing a Base64-encoded image that shows the user's current balance of purchased currency. The text is rendered in white using the default system font.</param>
		 */
		public delegate void getCurrentBalanceDetails_onCompleteCallback(SimpleAPIStatus status, Error error, Int32 imageWidth, String currencyName, String currencyIconUrl, String balanceImageUrl);

		public delegate void showPromotions_onCompleteCallback(DismissableAPIStatus status, Error error);

		public delegate void checkFacebookStatus_onCompleteCallback(SimpleAPIStatus status, Error error, String userId, String facebookId, String accessToken);

		public delegate void getFacebookId_onCompleteCallback(SimpleAPIStatus status, Error error, String userId, String facebookId);

		public delegate void getASCItems_onCompleteCallback(SimpleAPIStatus status, Error error, List<ItemData> items);

		public delegate void purchaseASCItem_onCompleteCallback(CancelableAPIStatus status, Error error);

		public delegate void giftASC_onCompleteCallback(SimpleAPIStatus status, Error error, Int32 amount);


		
		public static event BalanceUpdateNotificationDelegate BalanceUpdate {
			add {
				BalanceUpdateNotificationDelegate_add(value);
			}
			remove {
				BalanceUpdateNotificationDelegte_remove(value);
			}
		}
		public delegate void BalanceUpdateNotificationDelegate(BalanceUpdateNotification notification);
	}
#endregion

#region Static Methods
	public partial class SocialService {
#if MB_JP
		/**
		 * <summary> * !!!! Remove from WW !!!!</summary>
		 * <remarks>
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
		 * </remarks>
		 * <param name="maxFriendsToSelect" cref="F:System.Int32">The maximum number of friends that the user may select. Use the value <c>0</c> to allow the user to select an unlimited number of friends.</param>
		 * <param name="onComplete" cref="F:Mobage.OpenFriendPickerOnCompleteCallback">
		 * Callback for retrieving the user's input from the Friend Picker.</param>
		 * 
		 */
		public static void openFriendPicker(Int32 maxFriendsToSelect, openFriendPicker_onCompleteCallback onComplete)
		{
			_openFriendPicker(maxFriendsToSelect, onComplete);
		}
#endif // MB_JP
#if MB_JP
		/**
		 * <summary></summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="path" cref="F:System.String"></param>
		 * <param name="onComplete" cref="F:Mobage.OpenDocumentOnCompleteCallback">
</param>
		 * 
		 */
		public static void openDocument(String path, openDocument_onCompleteCallback onComplete)
		{
			_openDocument(path, onComplete);
		}
#endif // MB_JP
#if MB_KO
		public static void openDocument(String path, openDocument_onCompleteCallback onComplete)
		{
			_openDocument(path, onComplete);
		}
#endif // MB_KO
#if MB_JP
		/**
		 * <summary></summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="subject" cref="F:System.String"></param>
		 * <param name="body" cref="F:System.String"></param>
		 * <param name="imageUrl" cref="F:System.String"></param>
		 * <param name="onComplete" cref="F:Mobage.OpenDiaryWriterOnCompleteCallback">
</param>
		 * 
		 */
		public static void openDiaryWriter(String subject, String body, String imageUrl, openDiaryWriter_onCompleteCallback onComplete)
		{
			_openDiaryWriter(subject, body, imageUrl, onComplete);
		}
#endif // MB_JP
#if MB_KO
		public static void openDiaryWriter(String subject, String body, String imageUrl, openDiaryWriter_onCompleteCallback onComplete)
		{
			_openDiaryWriter(subject, body, imageUrl, onComplete);
		}
#endif // MB_KO
#if MB_JP
		/**
		 * <summary></summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="userId" cref="F:System.String"></param>
		 * <param name="subject" cref="F:System.String"></param>
		 * <param name="body" cref="F:System.String"></param>
		 * <param name="onComplete" cref="F:Mobage.OpenMinimailSenderOnCompleteCallback">
</param>
		 * 
		 */
		public static void openMinimailSender(String userId, String subject, String body, openMinimailSender_onCompleteCallback onComplete)
		{
			_openMinimailSender(userId, subject, body, onComplete);
		}
#endif // MB_JP
#if MB_KO
		public static void openMinimailSender(String userId, String subject, String body, openMinimailSender_onCompleteCallback onComplete)
		{
			_openMinimailSender(userId, subject, body, onComplete);
		}
#endif // MB_KO
		/**
		 * <summary> Log the user into Mobage, displaying the Login Dialog if necessary.</summary>
		 * <remarks>
		 * <p>
		 * In version 2.2 and later, this method does not allow users to dismiss the Login Dialog. To
		 * include a cancel button on the Login Dialog, use the method
		 * <c>SocialService::executeLoginWithParams</c>.
		 * <p>
		 * <strong>Important</strong>: If you log out the current user by calling
		 * <c>SocialService::executeLogout</c>, you must not attempt to log the user into Mobage until
		 * the logout dialog is no longer visible. Your app can listen for a <c>MobageUIVisible</c>
		 * notification to determine when the dialog is no longer visible.
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.ExecuteLoginOnCompleteCallback">
		 * Callback for logging the user into Mobage.</param>
		 * 
		 */
		public static void executeLogin(executeLogin_onCompleteCallback onComplete)
		{
			_executeLogin(onComplete);
		}
		/**
		 * <summary> Log the user into Mobage using the specified key-value pairs as configuration parameters, and displaying the Login Dialog if necessary.</summary>
		 * <remarks>
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
		 * </remarks>
		 * <param name="keys" cref="F:System.Collections.Generic.List<System.String>">Keys for configuring the login process. The only supported key is <c>LOGIN_OPTIONALITY</c>.</param>
		 * <param name="values" cref="F:System.Collections.Generic.List<System.String>">Values associated with the keys. The key <c>LOGIN_OPTIONALITY</c> accepts the following values:<ul><li><c>mandatory</c>: Require the user to log into Mobage immediately. Do not show a cancel button on the Login Dialog.</li><li><c>optional</c>: Allow the user to defer the login process by pressing a cancel button on the Login Dialog.</li></param>
		 * <param name="onComplete" cref="F:Mobage.ExecuteLoginWithParamsOnCompleteCallback">
		 * Called after the request is completed.</param>
		 * 
		 */
		public static void executeLoginWithParams(List<String> keys, List<String> values, executeLoginWithParams_onCompleteCallback onComplete)
		{
			_executeLoginWithParams(keys, values, onComplete);
		}
		/**
		 * <summary> Log the user out of Mobage, and clear the current session.</summary>
		 * <remarks>
		 * <strong>Note</strong>: If the current user has a guest account, calling this method has no
		 * effect.
		 * <p>
		 * <strong>Important</strong>: After calling this method, do not call
		 * <c>SocialService::executeLogin</c> or <c>SocialService::executeLoginWithParams</c> until the
		 * logout dialog is no longer visible. Your app can listen for a <c>MobageUIVisible</c>
		 * notification to determine when the dialog is no longer visible.
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.ExecuteLogoutOnCompleteCallback">
		 * Callback for logging the user out of Mobage.</param>
		 * 
		 */
		public static void executeLogout(executeLogout_onCompleteCallback onComplete)
		{
			_executeLogout(onComplete);
		}
		/**
		 * <summary> Open the User Profile screen for the specified Mobage user.</summary>
		 * <remarks>
		 * Opening the current user's profile allows the user to edit the profile.
		 * <p>
		 * This method displays the Mobage user interface. To optimize performance, pause the app or
		 * reduce the app's frame rate before calling this method.
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The user whose profile will be displayed.</param>
		 * 
		 */
		public static void openUserProfile(User user)
		{
			_openUserProfile(user);
		}
		/**
		 * <summary> Display the Mobage user interface.</summary>
		 * <remarks>
		 * Your app must call this method when the user taps the Community Button.
		 * <p>
		 * This method displays the Mobage user interface. To optimize performance, pause the app or
		 * reduce the app's frame rate before calling this method.
		 * </remarks>
		 * 
		 */
		public static void showCommunityUI()
		{
			_showCommunityUI();
		}
		/**
		 * <summary> Display the Community Button, which lets the user open the Mobage user interface.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="gravity" cref="F:Mobage.Gravity">Button placement.</param>
		 * <param name="theme" cref="F:System.String">Button color scheme. Choices are:<ul><li><c>basic</c>&mdash;Blue %Mobage logo on a white background.</li><li><c>blue</c>&mdash;White %Mobage logo on a blue background.</li><li><c>dark</c>&mdash;White %Mobage logo on a black background.</li><li><c>gray</c>&mdash;Black %Mobage logo on a light gray background.</li></ul></param>
		 * 
		 */
		public static void showCommunityButton(Gravity gravity, String theme)
		{
			_showCommunityButton(gravity, theme);
		}
		/**
		 * <summary> Hide the Community Button.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * 
		 */
		public static void hideCommunityButton()
		{
			_hideCommunityButton();
		}
		/**
		 * <summary> Open the Bank, which lets a user check their balance of purchased currency or buy additional currency.</summary>
		 * <remarks>
		 * <p>
		 * This method displays the Mobage user interface. To optimize performance, pause the app or
		 * reduce the frame rate before calling this method.
		 * </remarks>
		 * 
		 */
		public static void openBankDialog()
		{
			_openBankDialog();
		}
		/**
		 * <summary> Display the Balance Button for the Mobage Bank, which displays the user's current balance of purchased currency and opens the Bank.</summary>
		 * <remarks>
		 * The Balance Button's minimum height is the largest of the following values:
		 * <ul>
		 * <li>50 pixels.</li>
		 * <li>In landscape mode, 10% of the screen's height.</li>
		 * <li>In portrait mode, 6% of the screen's height.</li>
		 * </ul>
		 * The Balance Button's width must be at least three times its height. For example, if the
		 * Balance Button's minimum height is 50 pixels, its minimum width is 150 pixels.
		 * </remarks>
		 * <param name="x" cref="F:System.Int32">The X coordinate at which to place the Balance Button's upper left corner.</param>
		 * <param name="y" cref="F:System.Int32">The Y coordinate at which to place the Balance Button's upper left corner.</param>
		 * <param name="width" cref="F:System.Int32">The width of the Balance Button.</param>
		 * <param name="height" cref="F:System.Int32">The height of the Balance Button.</param>
		 * <param name="onComplete" cref="F:Mobage.ShowBalanceButtonOnCompleteCallback">
		 * Callback for retrieving the Balance Button.</param>
		 * 
		 */
		public static void showBalanceButton(Int32 x, Int32 y, Int32 width, Int32 height, showBalanceButton_onCompleteCallback onComplete)
		{
			_showBalanceButton(x, y, width, height, onComplete);
		}
		public static void getCurrentBalance(getCurrentBalance_onCompleteCallback onComplete)
		{
			_getCurrentBalance(onComplete);
		}
		/**
		 * <summary> Hide the Balance Button for the Mobage Bank.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * 
		 */
		public static void hideBalanceButton()
		{
			_hideBalanceButton();
		}
		/**
		 * <summary> Retrieve images that your app can combine into a customized Balance Button, which displays the user's balance of MobaCoin (on Android) or app-specific purchased currency (on iOS).</summary>
		 * <remarks>
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
		 * </remarks>
		 * <param name="imageHeight" cref="F:System.Int32">The height, in pixels, to use for the image showing the user's balance.</param>
		 * <param name="onComplete" cref="F:Mobage.GetCurrentBalanceDetailsOnCompleteCallback">
		 * Callback for retrieving images for a customized Balance Button.</param>
		 * 
		 */
		public static void getCurrentBalanceDetails(Int32 imageHeight, getCurrentBalanceDetails_onCompleteCallback onComplete)
		{
			_getCurrentBalanceDetails(imageHeight, onComplete);
		}
		public static void showPromotions(List<String> keys, List<String> values, showPromotions_onCompleteCallback onComplete)
		{
			_showPromotions(keys, values, onComplete);
		}
		public static void checkFacebookStatus(checkFacebookStatus_onCompleteCallback onComplete)
		{
			_checkFacebookStatus(onComplete);
		}
		public static void getFacebookId(getFacebookId_onCompleteCallback onComplete)
		{
			_getFacebookId(onComplete);
		}
		public static void getASCItems(getASCItems_onCompleteCallback onComplete)
		{
			_getASCItems(onComplete);
		}
		public static void purchaseASCItem(ItemData item, purchaseASCItem_onCompleteCallback onComplete)
		{
			_purchaseASCItem(item, onComplete);
		}
		public static void giftASC(String giftCode, giftASC_onCompleteCallback onComplete)
		{
			_giftASC(giftCode, onComplete);
		}
	}
#endregion


}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
