using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Faceblaster.UI;

namespace Faceblaster.Helper
{
	public class MobageHelper
	{
		private static MobageHelper _instance;

		private bool loggedIn;

		private Mobage.User currentUser;

		/**
		 * Since this is a singleton, the constructor is private.
		 */
		private MobageHelper()
		{
			loggedIn = false;
		}

		/**
		 * Initializer. Calls Mobage's init method and adds a bunch of notification listeners.
		 */
		public void Start()
		{
			InitializeMobage();
			InitializeNotificationListeners();
		}

		/**
		 * Singleton accessor. Nothing happens when the singleton is first created -- use Start() for initialization.
		 */
		public static MobageHelper Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new MobageHelper();
				}

				return _instance;
			}
		}

		
		/**
		 * Login using Facebook
		 */
		public void LogIntoMobageWithFacebook()
		{
			ExecuteMobageLogin("facebook", FacebookLoginCallback);
		}

		/**
		 * The UI has a button called "Skip" on the login view that calls this.
		 */
		public void LoginAsGuest()
		{
			ExecuteMobageLogin("guest", GenericLoginCallback);
		}

		/**
		 * Log in with Mobage username/password.
		 */
		public void LoginWithMobage()
		{
			ExecuteMobageLogin("mobage", GenericLoginCallback);
		}

		// DRY login helper method
		private void ExecuteMobageLogin(string loginType, Mobage.SocialService.executeLoginWithParams_onCompleteCallback callback)
		{
			List<string> keys = new List<string>();
			List<string> values = new List<string>();

			keys.Add("LOGIN_TYPE");
			values.Add(loginType);

			Mobage.SocialService.executeLoginWithParams(keys, values, callback);
		}

		/**
		 * Attempt to re-establish a previous Mobage session. While it is working, a transparent webview
		 * will lay over the game UI and prevent touch events from reaching game code.
		 */
		public void ReestablishSession()
		{
			ExecuteMobageLogin("establish_session", delegate(Mobage.CancelableAPIStatus status, Mobage.Error error)
			{
				switch (status)
				{
				case Mobage.CancelableAPIStatus.CancelableAPIStatusError:
					// in this case, there actually was an error, and you should either retry or
					// show an error dialog -- do not show a login view!
					UIController.SetDebugText("Reestablish Mobage session failed with code " + error.code + "! " + error.localizedDescription);
					break;
				case Mobage.CancelableAPIStatus.CancelableAPIStatusCancel:
					// in this case, Cancel means that the call to the server did not fail with an error,
					// but the user's session could not be reestablished (it's likely that nobody has logged into this app yet)
					UIController.SetDebugText("Unable to reestablish Mobage session; please log in.");
					loggedIn = false;
					// in a real game, you'd show your login view now, or enable the login buttons
					break;
				case Mobage.CancelableAPIStatus.CancelableAPIStatusSuccess:
					CollectUserInfo(()=>
					{
						UIController.SetDebugText("Mobage session reestablished.");
						loggedIn = true;
					});
					break;
				}
			});
		}

		/**
		 * Retrieve and store data about the current user.
		 */
		private void CollectUserInfo(System.Action callback)
		{
			Mobage.People.getCurrentUser(delegate(Mobage.SimpleAPIStatus status, Mobage.Error error, Mobage.User currentUser)
			{
				this.currentUser = currentUser;
				callback.Invoke();
			});
		}

		/**
		 * Getter property for current user data
		 */
		public Mobage.User CurrentUser
		{
			get
			{
				return currentUser;
			}
		}

		public void UpgradeGuestUserWithFacebook()
		{
			List<string> keys = new List<string>();
			List<string> values = new List<string>();

			keys.Add("UPGRADE_TYPE");
			values.Add("facebook");

			Mobage.Auth.executeUserUpgradeWithParams(keys, values, delegate(Mobage.CancelableAPIStatus status, Mobage.Error error) {
				switch (status)
				{
				case Mobage.CancelableAPIStatus.CancelableAPIStatusError:
					UIController.SetDebugText("User upgrade failed with code " + error.code + "! " + error.localizedDescription);
					break;
				case Mobage.CancelableAPIStatus.CancelableAPIStatusCancel:
					UIController.SetDebugText("User upgrade canceled by user! ");
					break;
				case Mobage.CancelableAPIStatus.CancelableAPIStatusSuccess:
					UIController.SetDebugText("User upgrade succeeded!");
					break;
				}
			});
		}


		/**
		 * Callback method reused in a number of login scenarios -- just logs messages and updates the UI
		 */
		private void GenericLoginCallback(Mobage.CancelableAPIStatus status, Mobage.Error error)
		{
			switch (status)
			{
			case Mobage.CancelableAPIStatus.CancelableAPIStatusError:
				UIController.SetDebugText("Mobage Login failed with code " + error.code + "! " + error.localizedDescription);
				break;
			case Mobage.CancelableAPIStatus.CancelableAPIStatusCancel:
				UIController.SetDebugText("Mobage Login: Canceled by user!");
				loggedIn = false;
				break;
			case Mobage.CancelableAPIStatus.CancelableAPIStatusSuccess:
				CollectUserInfo(()=>
				{
					UIController.SetDebugText("Mobage Login: The user is now logged in.");
					loggedIn = true;
				});
				break;
			}
		}

		/**
		 * Callback for FB login that passes the token to FacebookHelper so you can do stuff with the FB SDK
		 * DRY FAIL!
		 */
		private void FacebookLoginCallback(Mobage.CancelableAPIStatus status, Mobage.Error error)
		{
			switch (status)
			{
			case Mobage.CancelableAPIStatus.CancelableAPIStatusError:
				UIController.SetDebugText("Mobage Login failed with code " + error.code + "! " + error.localizedDescription);
				break;
			case Mobage.CancelableAPIStatus.CancelableAPIStatusCancel:
				UIController.SetDebugText("Mobage Login: Canceled by user!");
				loggedIn = false;
				break;
			case Mobage.CancelableAPIStatus.CancelableAPIStatusSuccess:
				CollectUserInfo(()=>
				{
					UIController.SetDebugText("Mobage Login: The user is now logged in.");
					loggedIn = true;
					CheckFacebookStatus();
				});
				break;
			}
		}

		private void CheckFacebookStatus()
		{
			Mobage.SocialService.checkFacebookStatus(
				delegate(Mobage.SimpleAPIStatus status, Mobage.Error error, string userId, string facebookId, string accessToken)
				{
					switch (status)
					{
					case Mobage.SimpleAPIStatus.SimpleAPIStatusError:
						UIController.SetDebugText("Error checking facebook status: " + error.description);
						break;
					case Mobage.SimpleAPIStatus.SimpleAPIStatusSuccess:
						UIController.SetDebugText(
							"Success checking facebook status. User ID: " + userId + " Facebook ID: " + facebookId + " Access Token: " + accessToken);

						// at this point, facebook is good to go. As an example:
						FacebookHelper.LogDetailsForCurrentUser();
						break;
					}
				});
		}

		public void LogFacebookUserId()
		{
			Mobage.SocialService.getFacebookId(delegate(Mobage.SimpleAPIStatus status, Mobage.Error error, string userId, string facebookId) {
				switch (status)
				{
				case Mobage.SimpleAPIStatus.SimpleAPIStatusError:
					Debug.Log ("Error getting Facebook User:" + error.localizedDescription);
					break;
				case Mobage.SimpleAPIStatus.SimpleAPIStatusSuccess:
					Debug.Log ("Get Facebook User successful. User ID: " + userId + " FacebookID: " + facebookId);
					break;
				}
			});
		}

		/**
		 * wraps initializeMobageWithStandardParameters
		 */
		private void InitializeMobage()
		{
			 // specify Sandbox or Production
			#if UNITY_ANDROID
			Mobage.Mobage.initializeMobageWithStandardParameters(
				Mobage.ServerEnvironment.Sandbox,
				"LoginToboggan-Android",                          // app key (e.g. "My-App-iOS")
				"1.0",                                          // version string (e.g. "1.3.4") - distinguishes versions for analytics
				"g3qZAEZPY9Ac5bIZNdnNA",                        // OAuth consumer key
				"GpBsi3Df8kSYwvaUEAjQ3eLV29YCye8g1zD2Nnzo");    // OAuth secret
			#elif UNITY_IOS
			Mobage.Mobage.initializeMobageWithStandardParameters(
				Mobage.ServerEnvironment.Sandbox,
				"LoginToboggan-iOS",                              // app key (e.g. "My-App-iOS")
				"1.0",                                          // version string (e.g. "1.3.4") - distinguishes versions for analytics
				"sECbc5NZXlWCWm9smwIYQ",                        // OAuth consumer key
				"T22imOnMtjQN6EQWBxEqpLCBaHlyTsQqLmhUXicLU");  // OAuth secret
			#endif
		}

		/**
		 * Adds a number of anonymous delegate methods that print out information about Mobage notifications.
		 * Only used for reference in this sample code.
		 */
		private void InitializeNotificationListeners()
		{
			Mobage.Auth.UserLogin += delegate(Mobage.Auth.UserLoginNotification notification)
			{
				Debug.Log("UserLogin notification delegate called");
			};

			Mobage.Auth.UserLogout += delegate(Mobage.Auth.UserLogoutNotification notification)
			{
				Debug.Log("UserLogout notification delegate called");
			};

			Mobage.Auth.UserSessionReestablished += delegate(Mobage.Auth.UserSessionReestablishedNotification notification)
			{
				Debug.Log("UserSessionReestablished notification delegate called");
			};

			Mobage.Auth.UserGradeUpgrade += delegate(Mobage.Auth.UserGradeUpgradeNotification notification)
			{
				Debug.Log("UserGradeUpgrade notification delegate called");
				Debug.Log("Current grade: " + notification.currentGrade);
				Debug.Log("Current nickname: " + notification.currentNickname);
				Debug.Log("Previous grade: " + notification.previousGrade);
				Debug.Log("Previous nickname: " + notification.previousNickname);
			};

			Mobage.Mobage.MobageUIVisible += delegate(Mobage.Mobage.MobageUIVisibleNotification notification)
			{
				Debug.Log("MobageUIVisible notification delegate called");
				Debug.Log("Visible: " + notification.visible);
				// when visible is true, it is a good time to pause your game and/or release some resources
				// things like image pickers and camera views can be quite resource-heavy (read: crashes!)
				// starting in 2.5.5, Mobage will no longer show loading spinners; it will be the game's
				// responsibility to observe this notiiaction and show loading indicators.
			};

			Mobage.SocialService.BalanceUpdate += delegate(Mobage.SocialService.BalanceUpdateNotification notification)
			{
				Debug.Log("BalanceUpdate notification delegate called");
			};
		}

		/**
		 * Log out of Mobage, and Facebook, if a FB session is present.
		 */
		public void Logout()
		{
			Mobage.SocialService.executeLogout(delegate(Mobage.SimpleAPIStatus status, Mobage.Error error)
			{
				switch (status)
				{
				case Mobage.SimpleAPIStatus.SimpleAPIStatusError:
					UIController.SetDebugText("Logout failed with code " + error.code + "! " + error.localizedDescription);
					break;
				case Mobage.SimpleAPIStatus.SimpleAPIStatusSuccess:
					UIController.SetDebugText("Logged out successfully.");
					loggedIn = false;
					break;
				}
			});
		}

		/**
		 *  Public getter for private variable loggedIn
		 */
		public bool LoggedIn
		{
			get
			{
				return loggedIn;
			}
		}
	}

}
