using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;
using Faceblaster.UI;

namespace Faceblaster.Helper
{
	public class FacebookHelper
	{
		/**
		 * perform a graph request for /me, and attempt to extract key/value pairs that Mobage login / guest upgrade calls want:
		 * id, birthday, first_name, last_name
		 */
		public static void LogDetailsForCurrentUser()
		{
			if (!FB.IsLoggedIn)
			{
				Debug.LogError("FacebookHelper::GetCurrentUser error: user is not logged in to Facebook");
				return;
			}
			
			FB.API("/me", Facebook.HttpMethod.GET, (FBResult resultGraph) =>
			{
				Debug.Log("Facebook details for current user: " + resultGraph.Text);
			});
		}
	}
}
