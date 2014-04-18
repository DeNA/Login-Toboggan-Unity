using UnityEngine;
using System.Collections;
using Faceblaster.Helper;

namespace Faceblaster.UI
{
	public class UIController : MonoBehaviour
	{
		public enum UserGrade
		{
			NonUser = 0,
			Guest = 1,
			MobageUser = 2,
			VerfiedUser = 3
		}


		private static string debugText = "";

		private static readonly int BUTTON_FONT_SIZE = 20;
		private static readonly int LABEL_FONT_SIZE = 15;
		private  RectOffset BUTTON_PADDING;
		private static readonly int BUTTON_MARGIN = 10;

		void Awake()
		{
			BUTTON_PADDING = new RectOffset(15, 15, 15, 15);
		}

		void OnGUI()
		{
			GUI.skin.button.fontSize = BUTTON_FONT_SIZE;
			GUI.skin.button.padding = BUTTON_PADDING;
			
			GUI.skin.label.fontSize = LABEL_FONT_SIZE;

			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

				GUILayout.FlexibleSpace();
					GUILayout.BeginVertical();

						GUILayout.FlexibleSpace();
							GUILayout.BeginHorizontal();

								GUILayout.FlexibleSpace();
									GUILayout.BeginVertical();

										if (!MobageHelper.Instance.LoggedIn)
										{
											if (GUILayout.Button("Log in to Mobage via Facebook"))
											{
												OnFacebookLoginButtonClick();
											}
											GUILayout.Space(BUTTON_MARGIN);
											if (GUILayout.Button("Log in to Mobage"))
											{
												OnMobageLoginButtonClick();
											}
											GUILayout.Space(BUTTON_MARGIN);
											if (GUILayout.Button("Skip (Log in as Guest)"))
											{
												OnSkipLoginButtonClick();
											}
																					
										}
										else
										{	
											if (MobageHelper.Instance.CurrentUser.grade == (int)UserGrade.Guest)
											{
												if (GUILayout.Button("Upgrade Mobage Guest to Facebook"))
												{
													OnUpgradeGuestToFacebookButtonClick();
												}
												GUILayout.Space(BUTTON_MARGIN);
											}
											GUILayout.Space(BUTTON_MARGIN);
											GUILayout.Space(BUTTON_MARGIN);
											if (GUILayout.Button("Log out"))
											{
												OnLogoutButtonClick();
											}
											GUILayout.Space (BUTTON_MARGIN);
											GUILayout.Space (BUTTON_MARGIN);
											if (GUILayout.Button("Show Community UI (for debugging)"))
											{
												// this is for debugging -- you can destroy the connection between your
												// facebook and mobage account by tapping your gamertag.
												Mobage.SocialService.showCommunityUI();
											}
										}
			
			

									GUILayout.EndVertical();
								GUILayout.FlexibleSpace();

							GUILayout.EndHorizontal();
							GUILayout.Space(50);
							GUILayout.BeginHorizontal();

								GUILayout.FlexibleSpace();
									GUILayout.BeginVertical();

										GUILayout.Label(debugText);

									GUILayout.EndVertical();
								GUILayout.FlexibleSpace();

							GUILayout.EndHorizontal();
						GUILayout.FlexibleSpace();

					GUILayout.EndVertical();
				GUILayout.FlexibleSpace();

			GUILayout.EndArea();
		}

		public void OnFacebookLoginButtonClick()
		{
			MobageHelper.Instance.LogIntoMobageWithFacebook();
		}

		public void OnMobageLoginButtonClick()
		{
			SetDebugText("Logging into Mobage...");
			MobageHelper.Instance.LoginWithMobage();
		}

		public void OnSkipLoginButtonClick()
		{
			SetDebugText("Logging in as guest...");
			MobageHelper.Instance.LoginAsGuest();
		}

		public void OnUpgradeGuestToFacebookButtonClick()
		{
			SetDebugText("Upgrading user...");
			MobageHelper.Instance.UpgradeGuestUserWithFacebook();
		}

		public void OnLogoutButtonClick()
		{
			SetDebugText("Logging out...");
			MobageHelper.Instance.Logout();
		}

		public static void SetDebugText(string value)
		{
			Debug.Log("setting debug text: " + value);
			debugText = value;
		}
	}
}
