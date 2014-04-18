//
//  MBSocialService.h
//  mobage-ndk
//
//  Created by ngmoco on 3/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"
#import <UIKit/UIKit.h>
#import "MBBalanceButton.h"
#import "MBItemData.h"
@protocol MBUser;

/**
  * Enumeration of constants for placing Mobage UI elements on the display.
  * @since 2.5
  */
typedef enum MB_GRAVITY {
	/**
	  * Place object in the top-left of the display.
	  * @since 2.5
	  */
	kMBGravityTopLeft,
	/**
	  * Place object in the top-right of the display.
	  * @since 2.5
	  */
	kMBGravityTopRight,
	/**
	  * Place object in the bottom-left of the display.
	  * @since 2.5
	  */
	kMBGravityBottomLeft,
	/**
	  * Place object in the bottom-right of the display.
	  * @since 2.5
	  */
	kMBGravityBottomRight
} MBGravity;

/**
 * @file MBSocialService.h
 * Provides access to the Mobage user interface.
 * @since 1.5
 */

/**
 * Display components of the Mobage user interface. The following components are
 * available:
 * <ul>
 * <li>The Balance Button, which displays the user's balance of app-specific purchased
 * currency.</li>
 * <li>The Bank, which enables a user to check their balance of app-specific purchased currency or
 * buy additional currency.</li>
 * <li>The Login Dialog, which enables the user to log into Mobage.</li>
 * <li>The Mobage Community user interface.</li>
 * <li>The User Profile screen, which shows a user's Mobage profile.</li>
 * </ul>
 * @since 1.5
 */
@protocol MBSocialService <NSObject>

/**
 * Open the User Profile screen for the specified Mobage user. Opening the current user's profile
 * allows the user to edit the profile.
 * <p>
 * This method displays the Mobage user interface. To optimize performance, pause the app or reduce
 * the app's frame rate before calling this method.
 * @param user The user whose profile will be displayed.
 * @since 2.0
 */
+ (void)openUserProfile:(NSObject<MBUser>*)user;

// Removed from API docs in SDK 2.5
+ (void)openFriendPicker:(NSInteger) maxFriendsToSelect
	   withCallbackQueue:(dispatch_queue_t)cbQueue
			  onComplete:(void (^)(MBDismissableAPIStatus status, NSObject<MBError> *error, NSArray* pickedFriends, NSArray* invitedFriends))completeCb;

/**
 * Open the Bank, which enables a user to check their balance of app-specific purchased currency or
 * buy additional currency.
 * <p>
 * This method displays the Mobage user interface. To optimize performance, pause the app or reduce
 * the app's frame rate before calling this method.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0
 */
+ (void)openBankDialogWithCallbackQueue:(dispatch_queue_t)cbQueue 
							 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error))completeCb;

/**
 * Log the user into Mobage, displaying the Login Dialog if necessary.
 * <p>
 * In version 2.2 and later, this method does not allow users to dismiss the Login Dialog. To
 * include a cancel button on the Login Dialog, use the method
 * <code>MBSocialService::executeLoginWithKeys:values:withCallbackQueue:onComplete:</code>.
 * <p>
 * <strong>Important</strong>: If you log out the current user by calling
 * <code>MBSocialService::executeLogoutWithCallbackQueue:onComplete:</code>, you must not attempt to
 * log the user into Mobage until the logout dialog is no longer visible. Your app can listen for an
 * <code>MBMobageUIVisibleNotification</code> to determine when the dialog is no longer visible.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0
 */
+ (void)executeLoginWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> *error))completeCb;

/**
 * Log the user into Mobage using the specified key-value pairs as configuration parameters, and
 * displaying the Login Dialog if necessary.
 * <p>
 * When you call this method and set the <code>LOGIN_OPTIONALITY</code> key to
 * <code>optional</code>, the Login Dialog will include a cancel button. You may only include a
 * cancel button on the Login Dialog if the user has not completed the app's tutorial or initial
 * level. After that time, you must require the user to log into Mobage.
 * <p>
 * <strong>Important</strong>: If you log out the current user by calling
 * <code>MBSocialService::executeLogoutWithCallbackQueue:onComplete:</code>, you must not attempt to
 * log the user into Mobage until the logout dialog is no longer visible. Your app can listen for an
 * <code>MBMobageUIVisibleNotification</code> to determine when the dialog is no longer visible.
 * @param keys Keys for configuring the login process. The only supported key is
 *      <code>LOGIN_OPTIONALITY</code>.
 * @param values Values associated with the keys. The key <code>LOGIN_OPTIONALITY</code> accepts the
 *      following values:
 * <ul>
 * <li><code>mandatory</code>: Require the user to log into Mobage immediately. Do not show a cancel
 * button on the Login Dialog.</li>
 * <li><code>optional</code>: Allow the user to defer the login process by pressing a cancel button
 * on the Login Dialog.</li>
 * </ul>
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0.1
 */
+ (void)executeLoginWithKeys:(NSArray*)keys values:(NSArray*)values withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> *error))completeCb;

/**
 * Log the user out of Mobage, and clear the current session.
 * <strong>Note</strong>: If the current user has a guest account, calling this method has no
 * effect.
 * <p>
 * <strong>Important</strong>: After calling this method, do not call
 * <code>MBSocialService::executeLoginWithCallbackQueue:onComplete:</code> or
 * <code>MBSocialService::executeLoginWithKeys:values:withCallbackQueue:onComplete:</code> until the
 * logout dialog is no longer visible. Your app can listen for an
 * <code>MBMobageUIVisibleNotification</code> to determine when the dialog is no longer visible.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0
 */
+ (void)executeLogoutWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;

/**
 * Retrieve the Balance Button for the Mobage Bank, which displays the user's current balance of the
 * app-specific purchased currency and opens the Bank. After retrieving the Balance Button, you can
 * add the Button to a <code>UIView</code> for your app.
 * <p>
 * Mobage sends an <code>MBBalanceUpdateNotification</code> when the user's balance is updated.
 * <p>
 * <strong>Note</strong>: To create a customized Balance Button for your app, call
 * <code>MBSocialService::getCurrentBalanceDetailsWithImageHeight:withCallbackQueue:onComplete:</code> or
 * <code>MBSocialService::getCurrentBalanceDetailsWithImageHeight:color:withCallbackQueue:onComplete:</code>.
 * <p>
 * The Balance Button's minimum height is the largest of the following values:
 * <ul>
 * <li>50 pixels.</li>
 * <li>In landscape mode, 10% of the screen's height.</li>
 * <li>In portrait mode, 6% of the screen's height.</li>
 * </ul>
 * The Balance Button's width must be at least three times its height. For example, if the Balance
 * Button's minimum height is 50 pixels, its minimum width is 150 pixels.
 * @param rect The frame for the button.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>button</code>: The Balance Button, or <code>nil</code> if the Balance Button could not
 * be retrieved.</li>
 * </ul>
 * @since 2.0
 */
+ (MBBalanceButton*)getBalanceButton:(CGRect)rect
	   withCallbackQueue:(dispatch_queue_t)cbQueue
			  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error, MBBalanceButton *button))completeCb;


/**
 * Show the Balance Button, which displays the user's current balance of app-specifc currency and
 * opens the Bank when tapped.
 * <p>
 * The Balance Button's minimum height is the largest of the following values:
 * <ul>
 * <li>50 pixels.</li>
 * <li>In landscape mode, 10% of the screen's height.</li>
 * <li>In portrait mode, 6% of the screen's height.</li>
 * </ul>
 * The Balance Button's width must be at least three times its height. For example, if the Balance
 * Button's minimum height is 50 pixels, its minimum width is 150 pixels.
 * @param x Position on the x-axis of the top-left corner of the Balance Button.
 * @param y Position on the y-axis of the top-left corner of the Balance Button.
 * @param width Width, in pixels, of the Balance Button.
 * @param height Height, in pixels, of the Balance Button.
 * @param onComplete Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was no
 * error.</li>
 * </ul>
 * @since 2.5
 */
+ (void)showBalanceButton:(int)x
						y:(int)y
					width:(int)width
				   height:(int)height
		withCallbackQueue:(dispatch_queue_t)cbQueue
			   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error))completeCb;

/**
 * Hide the Balance Button.
 * @since 2.5
 */
+ (void)hideBalanceButton;

/**
 * Retrieve images that your app can combine into a customized Balance Button, which displays the
 * user's balance of app-specific purchased currency. Using this method enables you to tailor the
 * Balance Button's appearance so it fits gracefully into your app.
 * <p>
 * <strong>Note</strong>: The app must hide the custom Balance Button when it receives an
 * <code>MBUserLogoutNotification</code>.
 * <p>
 * The callback for this method receives the following information:
 * <ul>
 * <li>An image, provided as a <code>data:</code> URL, showing the user's balance of app-specific
 * purchased currency. The image's text is rendered in white using the default system font. You can
 * specify the image's height in pixels; the callback receives the width of the rendered image.</li>
 * <li>The URL for an icon depicting the app-specific purchased currency.</li>
 * <li>The name of the app-specific purchased currency.</li>
 * </ul>
 * When the user taps the custom Balance Button, your app must call the method
 * <code>MBSocialService::openBankDialogWithCallbackQueue:onComplete:</code>, which displays the
 * Bank screen.
 * <p>
 * Your app must update the custom Balance Button when the user's currency balance changes. To
 * determine when the balance has changed, add an observer to the
 * <code>MBBalanceUpdateNotification</code> that updates your app's custom Balance Button.
 * <p>
 * <strong>Important</strong>: If your app server is responsible for closing Bank transactions,
 * you will not receive a <code>MBBalanceUpdateNotification</code> when a transaction is closed.
 * Instead, your app server must notify the app that it should update the images in the Balance
 * Button.
 * <p>
 * As noted above, the callback receives the balance image as a <code>data:</code> URL. The
 * following example shows how to convert the URL to a usable image.
 * @code
 * // Assumes a UIImageView balanceButton, as well as a balanceHeight NSInteger
 * customBalanceButton = [[UIImageView alloc] initWithFrame:CGRectMake(0, 0, 270, balanceHeight)];
 *
 * [MBSocialService getCurrentBalanceDetailsWithImageHeight: balanceHeight
 *                                        withCallbackQueue: dispatch_get_main_queue()
 *                                               onComplete: ^ (MBSimpleAPIStatus status, NSObject<MBError> *error,
 *                                                   NSInteger imageWidth, NSString * currencyName,
 *                                                   NSString * currencyIconUrl, NSString * currentBalanceImageUrl) {
 *                                                   if (status == MBSimpleAPIStatusSuccess) {
 *                                                       customBalanceButton.frame = CGRectIntegral(
 *                                                           CGRectMake(0, self.view.frame.size.height-balanceHeight,
 *                                                               imageWidth, balanceHeight)
 *                                                       );
 *                                                       customBalanceButton.backgroundColor = [UIColor blueColor];
 *
 *                                                       UIImageView * tImage = [[UIImageView alloc] initWithImage:
 *                                                           [UIImage imageWithData:[NSData dataWithContentsOfURL:
 *                                                           [NSURL URLWithString:currentBalanceImageUrl]]]];
 *                                                       tImage.frame = CGRectSetPos(customBalanceButton.frame,0,0);
 *
 *                                                       customBalanceButton.layer.mask = tImage.layer;
 *                                               }
 * }];
 * @endcode
 * @param imageHeight The height, in pixels, to use for the image showing the user's balance of
 * app-specific purchased currency.
 * @param callbackQueue The dispatch queue for the callback.
 * @param onComplete Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>imageWidth</code>: The final width, in pixels, of the image showing the user's balance.
 * </li>
 * <li><code>currencyName</code>: The name of the app-specific purchased currency.</li>
 * <li><code>currencyIconUrl</code>: The URL of the icon for the app-specific purchased currency.
 * </li>
 * <li><code>currentBalanceImageUrl</code>: A <code>data:</code> URL containing a Base64-encoded
 * image that shows the user's current balance of virtual currency.</li>
 * </ul>
 * @see getCurrentBalanceDetailsWithImageHeight:color:withCallbackQueue:onComplete:
 * @since 2.3
 */
+ (void)getCurrentBalanceDetailsWithImageHeight:(NSInteger)imageHeight
							  withCallbackQueue:(dispatch_queue_t)callbackQueue
									 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *err, NSInteger imageWidth, NSString *currencyName, NSString *currencyIconUrl, NSString *currentBalanceImageUrl))onComplete;
/**
 * Retrieve images that your app can combine into a customized Balance Button, which displays the
 * user's MobaCoin balance.
 * <p>
 * This method is identical to
 * <code>MBSocialService::getCurrentBalanceDetailsWithImageHeight:withCallbackQueue:onComplete:</code>,
 * except that it allows you to specify the color of the image's text.
 * @param imageHeight The height, in pixels, to use for the image showing the user's balance of
 * app-specific purchased currency.
 * @param color The color to use for the image's text.
 * @param callbackQueue The dispatch queue for the callback.
 * @param onComplete Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>imageWidth</code>: The final width, in pixels, of the image showing the user's balance.
 * </li>
 * <li><code>currencyName</code>: The name of the app-specific purchased currency.</li>
 * <li><code>currencyIconUrl</code>: The URL of the icon for the app-specific purchased currency.
 * </li>
 * <li><code>currentBalanceImageUrl</code>: A <code>data:</code> URL containing a Base64-encoded
 * image that shows the user's current balance of virtual currency.</li>
 * </ul>
 * @see getCurrentBalanceDetailsWithImageHeight:withCallbackQueue:onComplete:
 * @since 2.3
 */
+ (void)getCurrentBalanceDetailsWithImageHeight:(NSInteger)imageHeight
										  color:(UIColor*)color
							  withCallbackQueue:(dispatch_queue_t)callbackQueue
									 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * err, NSInteger imageWidth, NSString *currencyName, NSString *currencyIconUrl, NSString *currentBalanceImageUrl))onComplete;

/**
 TODO
 */

+ (void) getCurrentBalanceWithCallbackQueue:(dispatch_queue_t)callbackQueue
                                 onComplete:(void (^)(MBSimpleAPIStatus status,
                                                      NSObject<MBError> *error,
                                                      NSString *currencyName,
                                                      NSString *currencyIconURL,
                                                      NSInteger balance))completeCb;

/**
 * TODO
 */

+ (void) getASCItemsWithCallbackQueue:(dispatch_queue_t)cbQueue
                           onComplete:( void (^)(MBSimpleAPIStatus status,
                                                 NSObject<MBError>* error,
                                                 NSArray* items) )completeCb;
/**
 * TODO
 */

+ (void) giftASC:(NSString *) giftCode
withCallbackQueue: (dispatch_queue_t) cbQueue
	  onComplete: (void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSInteger amount)) completeCb;

/**
 * TODO
 */

+ (void) purchaseASCItem:(NSObject<MBItemData> *)item
   withCallbackQueue:(dispatch_queue_t)cbQueue
          onComplete:( void (^)(MBCancelableAPIStatus status,
                                NSObject<MBError>* error) )completeCb;

/**
 * Display the Mobage user interface. Your app must call this method when the user taps the
 * Community Button.
 * <p>
 * This method displays the Mobage user interface. To optimize performance, pause the app or reduce
 * the app's frame rate before calling this method.
 * @since 2.0
 */
+ (void)showCommunityUI;

/**
 * Open the Bank, which enables a user to check their balance of app-specific purchased currency or
 * buy additional currency.
 * <p>
 * This method displays the Mobage user interface. To optimize performance, pause the app or reduce
 * the app's frame rate before calling this method.
 * @since 2.5
 */
+ (void)openBankDialog;

/**
 * Display the Community Button, which lets the user open the Mobage user interface.
 * @param aGravity Button placement.
 * @param theme Button color scheme. Choices are:
 *              <ul>
 *                <li><code>basic</code>&mdash;Blue Mobage logo on a white background.</li>
 *                <li><code>blue</code>&mdash;White Mobage logo on a blue background.</li>
 *                <li><code>dark</code>&mdash;White Mobage logo on a black background.</li>
 *                <li><code>gray</code>&mdash;Black Mobage logo on a light gray background.</li>
 *              </ul>
 * @since 2.5
 */
+ (void) showCommunityButton:(MBGravity)aGravity
				   withTheme:(NSString*)theme;
/**
 * Hide the Community Button.
 * @since 2.5
 */
+ (void) hideCommunityButton;

+ (void)showPromotionsWithKeys:(NSArray*)keys values:(NSArray*)values withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void(^)(MBDismissableAPIStatus status, NSObject<MBError>* error))onComplete;

+ (void)checkFacebookStatusWithCallbackQueue: (dispatch_queue_t) cbQueue
				 onComplete: (void(^)(MBSimpleAPIStatus status, NSObject<MBError> * error, NSString * userId, NSString *facebookId, NSString *accessToken)) onComplete;

+ (void)getFacebookIdWithCallbackQueue: (dispatch_queue_t) cbQueue
							onComplete: (void(^)(MBSimpleAPIStatus status, NSObject<MBError> * error, NSString * userId, NSString * facebookId)) onComplete;

@end
