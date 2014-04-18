//
//  People.cs
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
	 * <summary> Retrieve information about Mobage users, including their personal information and their friends.</summary>
	 * <remarks>
	 * A user's network of friends is sometimes referred to as the user's "social graph."
	 * <p>
	 * <strong>Note</strong>: The user must log into Mobage before your app uses the <c>People</c>
	 * APIs.
	 * </remarks>
	 */
	public partial class People {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class People {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class People {
		/**
		 * <summary> Callback for retrieving information about the current user.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="currentUser" cref="F:Mobage.User">Information about the current user, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getCurrentUser_onCompleteCallback(SimpleAPIStatus status, Error error, User currentUser);

		/**
		 * <summary> Callback for retrieving information about a specified user.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="user" cref="F:Mobage.User">Information about the specified user, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getUserForId_onCompleteCallback(SimpleAPIStatus status, Error error, User user);

		/**
		 * <summary> Callback for retrieving information about multiple users.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="users" cref="F:System.Collections.Generic.List<Mobage.User>">An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getUsersForIds_onCompleteCallback(SimpleAPIStatus status, Error error, List<User> users);

#if MB_JP
		/**
		 * <summary> Callback for retrieving information about a user's friends.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="users" cref="F:System.Collections.Generic.List<Mobage.User>">An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.</param>
		 * <param name="startOffset" cref="F:System.Int32">The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="totalPossibleResultCount" cref="F:System.Int32">The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getFriendsForUser_onCompleteCallback(SimpleAPIStatus status, Error error, List<User> users, Int32 startOffset, Int32 totalPossibleResultCount);
#endif //MB_JP
#if MB_JP
		/**
		 * <summary> Callback for retrieving information about a user's friends who have used the current app.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="users" cref="F:System.Collections.Generic.List<Mobage.User>">An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.</param>
		 * <param name="startOffset" cref="F:System.Int32">The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="totalPossibleResultCount" cref="F:System.Int32">The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getFriendsWithGameForUser_onCompleteCallback(SimpleAPIStatus status, Error error, List<User> users, Int32 startOffset, Int32 totalPossibleResultCount);
#endif //MB_JP
	}
#endregion

#region Static Methods
	public partial class People {
		/**
		 * <summary> Retrieve information about the current user.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.GetCurrentUserOnCompleteCallback">
		 * Callback for retrieving information about the current user.</param>
		 * 
		 */
		public static void getCurrentUser(getCurrentUser_onCompleteCallback onComplete)
		{
			_getCurrentUser(onComplete);
		}
		/**
		 * <summary> Retrieve information about a specified user.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="userId" cref="F:System.String">The user ID of the user to retrieve.</param>
		 * <param name="onComplete" cref="F:Mobage.GetUserForIdOnCompleteCallback">
		 * Callback for retrieving information about a specified user.</param>
		 * 
		 */
		public static void getUserForId(String userId, getUserForId_onCompleteCallback onComplete)
		{
			_getUserForId(userId, onComplete);
		}
		/**
		 * <summary> Retrieve information about a maximum of 100 users.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="userIds" cref="F:System.Collections.Generic.List<System.String>">The user IDs of the users to retrieve. Must contain between 1 and 100 user IDs.</param>
		 * <param name="onComplete" cref="F:Mobage.GetUsersForIdsOnCompleteCallback">
		 * Callback for retrieving information about multiple users.</param>
		 * 
		 */
		public static void getUsersForIds(List<String> userIds, getUsersForIds_onCompleteCallback onComplete)
		{
			_getUsersForIds(userIds, onComplete);
		}
#if MB_JP
		/**
		 * <summary> Retrieve information about a user's friends.</summary>
		 * <remarks>
		 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the number
		 * of results that this method retrieves, as well as the start index for the search results.
		 * <p>
		 * <strong>Important</strong>: In version 2.3 and later, both Android and iOS use the start
		 * index <c>1</c> for the first search result. In previous versions, Android used <c>1</c>,
		 * while iOS used <c>0</c>.
		 * @deprecated This method will be removed in a future version.
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The user whose friends will be retrieved.</param>
		 * <param name="howMany" cref="F:System.Int32">The number of results to retrieve. The default value is <c>50</c>.</param>
		 * <param name="offset" cref="F:System.Int32">The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetFriendsForUserOnCompleteCallback">
		 * Callback for retrieving information about a user's friends.</param>
		 * 
		 */
		public static void getFriendsForUser(User user, Int32 howMany, Int32 offset, getFriendsForUser_onCompleteCallback onComplete)
		{
			_getFriendsForUser(user, howMany, offset, onComplete);
		}
#endif // MB_JP
#if MB_JP
		/**
		 * <summary> Retrieve information about a user's friends who have used the current app.</summary>
		 * <remarks>
		 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the
		 * number of results that this method retrieves, as well as the start index for the search
		 * results.
		 * <p>
		 * <strong>Important</strong>: In version 2.3 and later, both Android and iOS use the start
		 * index <c>1</c> for the first search result. In previous versions, Android used <c>1</c>,
		 * while iOS used <c>0</c>.
		 * @deprecated This method will be removed in a future version.
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The user whose friends have used the current app.</param>
		 * <param name="howMany" cref="F:System.Int32">The number of results to retrieve. The default value is <c>50</c>.</param>
		 * <param name="offset" cref="F:System.Int32">The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetFriendsWithGameForUserOnCompleteCallback">
		 * Callback for retrieving information about a user's friends who have used the current app.</param>
		 * 
		 */
		public static void getFriendsWithGameForUser(User user, Int32 howMany, Int32 offset, getFriendsWithGameForUser_onCompleteCallback onComplete)
		{
			_getFriendsWithGameForUser(user, howMany, offset, onComplete);
		}
#endif // MB_JP
	}
#endregion


}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
