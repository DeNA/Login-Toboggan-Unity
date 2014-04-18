//
//  GameLeaderboard.cs
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
	 * <summary> Information about a Mobage leaderboard, which stores high scores for the app.</summary>
	 * <remarks>
	 * An app can perform any of the following actions on a leaderboard:
	 * <ul>
	 * <li>Delete the current user's top score</li>
	 * <li>Retrieve information about leaderboards</li>
	 * <li>Submit a top score for the current user</li>
	 * <li>Retrieve a leaderboard's top score</li>
	 * <li>Retrieve a list of top scores for the current user's friends</li>
	 * <li>Retrieve a list of top scores for all users</li>
	 * </ul>
	 * The Mobage West platform supports two kinds of time-limited leaderboards:
	 * <ul>
	 * <li><strong>Timed leaderboards</strong>, which reset all scores on a fixed schedule (for
	 * example, daily). After a timed leaderboard has closed, you cannot retrieve its scores.</li>
	 * <li><strong>Windowed leaderboards</strong>, which are used once for a fixed period of
	 * time (for example, during a special event). After a windowed leaderboard has closed,
	 * you can retrieve its scores for 3 days.</li>
	 * </ul>
	 * If your app uses timed or windowed leaderboards, the error code
	 * <c>Mobage::HTTPError:PermissionDenied</c> is returned if:
	 * <ul>
	 * <li>You try to retrieve scores from a timed or windowed leaderboard before the leaderboard has
	 * been opened.</li>
	 * <li>You try to update or delete scores on a windowed leaderboard after the leaderboard has been
	 * closed.</li>
	 * </ul>
	 * Before using this class, you must use the <a href="https://developer.mobage.com/">Mobage
	 * Developer Portal</a> to create at least one leaderboard for your app. For more information,
	 * see the <a href="https://developer.mobage.com/en/resources/app_setup_native">App Setup
	 * documentation</a> on the Developer Portal.
	 * </remarks>
	 */
	public partial class GameLeaderboard {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
	public partial class GameLeaderboard {
		// Properties!
		/**
		 * The unique ID for the leaderboard.
		 */
		[NonSerialized]
		public String uid;
		/**
		 * The app ID associated with the leaderboard.
		 */
		[NonSerialized]
		public String appId;
		/**
		 * The leaderboard's title.
		 */
		[NonSerialized]
		public String title;
		/**
		 * The rules that the leaderboard uses to format a score for display. Contains one of the following values:<ul><li><c>day_hour</c>: Formatted as <c>DD HH.zzz</c>. The score represents the number of seconds.</li><li><c>day_minute</c>: Formatted as <c>DD HH:MM.zzz</c>. The score represents the number of seconds.</li><li><c>day_second</c>: Formatted as <c>DD HH:MM:SS.zzz</c>. The score represents the number of seconds.</li><li><c>decimal</c>: Formatted as a signed double.</li><li><c>hour_minute</c>: Formatted as <c>HH:MM.zzz</c>. The score represents the number of seconds.</li><li><c>hour_second</c>: Formatted as <c>HH:MM:SS.zzz</c>. The score represents the number of seconds.</li><li><c>hours</c>: Formatted as <c>HH.zzz</c>. The score represents the number of seconds.</li><li><c>integer</c>: Formatted as a signed 32-bit integer.</li><li><c>minute_second</c>: Formatted as <c>MM:SS.zzz</c>. The score represents the number of seconds.</li><li><c>minutes</c>: Formatted as <c>MM.zzz</c>. The score represents the number of seconds.</li><li><c>seconds</c>: Formatted as <c>SS.zzz</c>. The score represents the number of seconds.</li></ul>
		 */
		[NonSerialized]
		public String scoreFormat;
		/**
		 * The number of decimal places that the leaderboard uses when it reformats a score for display.
		 */
		[NonSerialized]
		public Int32 scorePrecision;
		/**
		 * The URL of the leaderboard icon.
		 */
		[NonSerialized]
		public String iconUrl;
		/**
		 * Indicates whether a user's top score can be replaced by a new, lower score.
		 */
		[NonSerialized]
		public bool allowLowerScore;
		/**
		 * Indicates whether the leaderboard treats lower scores as more desirable.
		 */
		[NonSerialized]
		public bool reverse;
		/**
		 * Indicates whether the leaderboard has been archived and can no longer be updated.<ul><li>If <c>true</c>, the leaderboard has been closed and can no longer be updated. Only timed and windowed leaderboards can be closed.</li><li>If <c>false</c>, the leaderboard can be updated.</li></ul>
		 */
		[NonSerialized]
		public bool archived;
		/**
		 * The default score for users that have not recorded a top score.
		 */
		[NonSerialized]
		public double defaultScore;
		/**
		 * The date and time when the leaderboard was created. Uses the format <c>YYYY-MM-DDThh:mm:ss</c>.
		 */
		[NonSerialized]
		public String published;
		/**
		 * The date and time when the leaderboard was updated. Uses the format <c>YYYY-MM-DDThh:mm:ss</c>.
		 */
		[NonSerialized]
		public String updated;
		
	}

#region Notifications!
	public partial class GameLeaderboard {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class GameLeaderboard {
		/**
		 * <summary> Callback for retrieving information about a leaderboard.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">Information about the leaderboard, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getLeaderboardForId_onCompleteCallback(SimpleAPIStatus status, Error error, GameLeaderboard leaderboard);

		/**
		 * <summary> Callback for retrieving information about multiple leaderboards.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="leaderboards" cref="F:System.Collections.Generic.List<Mobage.GameLeaderboard>">An array of <c>GameLeaderboard</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getLeaderboardsForIds_onCompleteCallback(SimpleAPIStatus status, Error error, List<GameLeaderboard> leaderboards);

		/**
		 * <summary> Callback for retrieving information about all of the current app's leaderboards.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="leaderboards" cref="F:System.Collections.Generic.List<Mobage.GameLeaderboard>">An array of <c>GameLeaderboard</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getAllLeaderboards_onCompleteCallback(SimpleAPIStatus status, Error error, List<GameLeaderboard> leaderboards);

		/**
		 * <summary> Callback for retrieving a leaderboard's top scores.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="scores" cref="F:System.Collections.Generic.List<Mobage.Score>">An array of <c>Score</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getScoresForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error, List<Score> scores);

#if MB_JP
		/**
		 * <summary> Callback for retrieving a leaderboard's top scores for the current user's friends.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="scores" cref="F:System.Collections.Generic.List<Mobage.Score>">An array of <c>Score</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getFriendsScoresForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error, List<Score> scores);
#endif //MB_JP
		/**
		 * <summary> Callback for retrieving a user's top score on a leaderboard.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="score" cref="F:Mobage.Score">Information about the user's score, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getScoreForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error, Score score);

		/**
		 * <summary> Callback for updating the current user's top score.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="score" cref="F:Mobage.Score">Information about the user's score, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void updateCurrentUserScoreForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error, Score score);

		/**
		 * <summary> Callback for deleting the current user's top score.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void deleteCurrentUserScoreForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error);

	}
#endregion

#region Static Methods
	public partial class GameLeaderboard {
		/**
		 * <summary> Retrieve information about a leaderboard.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="leaderboardId" cref="F:System.String">The leaderboard IDs of the leaderboards to retrieve.</param>
		 * <param name="onComplete" cref="F:Mobage.GetLeaderboardForIdOnCompleteCallback">
		 * Callback for retrieving information about a leaderboard.</param>
		 * 
		 */
		public static void getLeaderboardForId(String leaderboardId, getLeaderboardForId_onCompleteCallback onComplete)
		{
			_getLeaderboardForId(leaderboardId, onComplete);
		}
		/**
		 * <summary> Retrieve information about multiple leaderboards.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="leaderboardIds" cref="F:System.Collections.Generic.List<System.String>">The leaderboard IDs of the leaderboards to retrieve.</param>
		 * <param name="onComplete" cref="F:Mobage.GetLeaderboardsForIdsOnCompleteCallback">
		 * Callback for retrieving information about multiple leaderboards.</param>
		 * 
		 */
		public static void getLeaderboardsForIds(List<String> leaderboardIds, getLeaderboardsForIds_onCompleteCallback onComplete)
		{
			_getLeaderboardsForIds(leaderboardIds, onComplete);
		}
		/**
		 * <summary> Retrieve information about all of the current app's leaderboards.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.GetAllLeaderboardsOnCompleteCallback">
		 * Callback for retrieving information about all of the current app's leaderboards.</param>
		 * 
		 */
		public static void getAllLeaderboards(getAllLeaderboards_onCompleteCallback onComplete)
		{
			_getAllLeaderboards(onComplete);
		}
		/**
		 * <summary> Retrieve information about a leaderboard's top scores, starting with the highest score.</summary>
		 * <remarks>
		 * You can use the <c>count</c> and <c>startIndex</c> parameters to control the
		 * number of results that this method retrieves, as well as the start index for the search
		 * results.
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose scores will be retrieved.</param>
		 * <param name="count" cref="F:System.Int32">The number of results to retrieve. The default value is <c>50</c>.</param>
		 * <param name="startIndex" cref="F:System.Int32">The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetScoresForLeaderboardOnCompleteCallback">
		 * Callback for retrieving a leaderboard's top scores.</param>
		 * 
		 */
		public static void getScoresForLeaderboard(GameLeaderboard leaderboard, Int32 count, Int32 startIndex, getScoresForLeaderboard_onCompleteCallback onComplete)
		{
			_getScoresForLeaderboard(leaderboard, count, startIndex, onComplete);
		}
#if MB_JP
		/**
		 * <summary> Retrieve information about a leaderboard's scores that were earned by the current user's friends, starting with the highest score.</summary>
		 * <remarks>
		 * You can use the <c>count</c> and <c>startIndex</c> parameters to control the
		 * number of results that this method retrieves, as well as the start index for the search
		 * results.
		 * @deprecated This method will be removed in a future version.
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose scores will be retrieved.</param>
		 * <param name="count" cref="F:System.Int32">The number of results to retrieve. The default value is <c>50</c>.</param>
		 * <param name="startIndex" cref="F:System.Int32">The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetFriendsScoresForLeaderboardOnCompleteCallback">
		 * Callback for retrieving a leaderboard's top scores for the current user's friends.</param>
		 * 
		 */
		public static void getFriendsScoresForLeaderboard(GameLeaderboard leaderboard, Int32 count, Int32 startIndex, getFriendsScoresForLeaderboard_onCompleteCallback onComplete)
		{
			_getFriendsScoresForLeaderboard(leaderboard, count, startIndex, onComplete);
		}
#endif // MB_JP
		/**
		 * <summary> Retrieve information about a user's top score on a leaderboard.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose score will be retrieved.</param>
		 * <param name="user" cref="F:Mobage.User">The user whose top score will be retrieved.</param>
		 * <param name="onComplete" cref="F:Mobage.GetScoreForLeaderboardOnCompleteCallback">
		 * Callback for retrieving a user's top score on a leaderboard.</param>
		 * 
		 */
		public static void getScoreForLeaderboard(GameLeaderboard leaderboard, User user, getScoreForLeaderboard_onCompleteCallback onComplete)
		{
			_getScoreForLeaderboard(leaderboard, user, onComplete);
		}
		/**
		 * <summary> Update the current user's top score on a leaderboard.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose score for the current user will be updated.</param>
		 * <param name="value" cref="F:System.double">The current user's score.</param>
		 * <param name="onComplete" cref="F:Mobage.UpdateCurrentUserScoreForLeaderboardOnCompleteCallback">
		 * Callback for updating the current user's top score.</param>
		 * 
		 */
		public static void updateCurrentUserScoreForLeaderboard(GameLeaderboard leaderboard, double value, updateCurrentUserScoreForLeaderboard_onCompleteCallback onComplete)
		{
			_updateCurrentUserScoreForLeaderboard(leaderboard, value, onComplete);
		}
		/**
		 * <summary> Delete the current user's top score from a leaderboard.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose score for the current user will be deleted.</param>
		 * <param name="onComplete" cref="F:Mobage.DeleteCurrentUserScoreForLeaderboardOnCompleteCallback">
		 * Callback for deleting the current user's top score.</param>
		 * 
		 */
		public static void deleteCurrentUserScoreForLeaderboard(GameLeaderboard leaderboard, deleteCurrentUserScoreForLeaderboard_onCompleteCallback onComplete)
		{
			_deleteCurrentUserScoreForLeaderboard(leaderboard, onComplete);
		}
	}
#endregion

#region Instance Methods
	public partial class GameLeaderboard {
	}
#endregion

}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
