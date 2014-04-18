//
//  MBCPeople.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCPEOPLE_H_
#define MBCPEOPLE_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCPeople_getCurrentUserCallback
	 * @description 	 * Callback for retrieving information about the current user.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser * currentUser Information about the current user, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCPeople_getCurrentUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser * currentUser,
				
				void * context
																);
	/**
	 * MBCPeople_getUserForIdCallback
	 * @description 	 * Callback for retrieving information about a specified user.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser * user Information about the specified user, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCPeople_getUserForIdCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser * user,
				
				void * context
																);
	/**
	 * MBCPeople_getUsersForIdsCallback
	 * @description 	 * Callback for retrieving information about multiple users.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCPeople_getUsersForIdsCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser_Array * users,
				
				void * context
																);
#if MB_JP
	/**
	 * MBCPeople_getFriendsForUserCallback
	 * @description 	 * Callback for retrieving information about a user's friends.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 */
	typedef void (*MBCPeople_getFriendsForUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser_Array * users,
				int32_t startOffset,
				int32_t totalPossibleResultCount,
				
				void * context
																);
#endif // MB_JP
#if MB_JP
	/**
	 * MBCPeople_getFriendsWithGameForUserCallback
	 * @description 	 * Callback for retrieving information about a user's friends who have used the current app.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 */
	typedef void (*MBCPeople_getFriendsWithGameForUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser_Array * users,
				int32_t startOffset,
				int32_t totalPossibleResultCount,
				
				void * context
																);
#endif // MB_JP
	
	#pragma mark - Static Methods
	/**
	 * MBCPeople_getCurrentUser
	 * @function
	 * @public
	 * @description 	 * Retrieve information about the current user.
	 *
	 * @cb GetCurrentUserOnCompleteCallback  onComplete 
		 * Callback for retrieving information about the current user.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser * currentUser Information about the current user, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCPeople_getCurrentUser(
										MBCPeople_getCurrentUserCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCPeople_getUserForId
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a specified user.
	 *
	 * @param const char *  userId The user ID of the user to retrieve.			AUTORELEASED
	 * @cb GetUserForIdOnCompleteCallback  onComplete 
		 * Callback for retrieving information about a specified user.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser * user Information about the specified user, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCPeople_getUserForId(
										const char *  userId,
										MBCPeople_getUserForIdCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCPeople_getUsersForIds
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a maximum of 100 users.
	 *
	 * @param MBCString_Array *  userIds The user IDs of the users to retrieve. Must contain between 1 and 100 user IDs.			AUTORELEASED
	 * @cb GetUsersForIdsOnCompleteCallback  onComplete 
		 * Callback for retrieving information about multiple users.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCPeople_getUsersForIds(
										MBCString_Array *  userIds,
										MBCPeople_getUsersForIdsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#if MB_JP
	/**
	 * MBCPeople_getFriendsForUser
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a user's friends.
	 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the number
	 * of results that this method retrieves, as well as the start index for the search results.
	 * <p>
	 * <strong>Important</strong>: In version 2.3 and later, both Android and iOS use the start
	 * index <c>1</c> for the first search result. In previous versions, Android used <c>1</c>,
	 * while iOS used <c>0</c>.
	 * @deprecated This method will be removed in a future version.
	 *
	 * @param MBCUser *  user The user whose friends will be retrieved.			AUTORELEASED
	 * @param int32_t  howMany The number of results to retrieve. The default value is <c>50</c>.			
	 * @param int32_t  offset The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb GetFriendsForUserOnCompleteCallback  onComplete 
		 * Callback for retrieving information about a user's friends.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 * <br/>
	 * 
	 */
	void MBCPeople_getFriendsForUser(
										MBCUser *  user,
										int32_t  howMany,
										int32_t  offset,
										MBCPeople_getFriendsForUserCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_JP
#if MB_JP
	/**
	 * MBCPeople_getFriendsWithGameForUser
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a user's friends who have used the current app.
	 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the
	 * number of results that this method retrieves, as well as the start index for the search
	 * results.
	 * <p>
	 * <strong>Important</strong>: In version 2.3 and later, both Android and iOS use the start
	 * index <c>1</c> for the first search result. In previous versions, Android used <c>1</c>,
	 * while iOS used <c>0</c>.
	 * @deprecated This method will be removed in a future version.
	 *
	 * @param MBCUser *  user The user whose friends have used the current app.			AUTORELEASED
	 * @param int32_t  howMany The number of results to retrieve. The default value is <c>50</c>.			
	 * @param int32_t  offset The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb GetFriendsWithGameForUserOnCompleteCallback  onComplete 
		 * Callback for retrieving information about a user's friends who have used the current app.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 * <br/>
	 * 
	 */
	void MBCPeople_getFriendsWithGameForUser(
										MBCUser *  user,
										int32_t  howMany,
										int32_t  offset,
										MBCPeople_getFriendsWithGameForUserCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_JP


#ifdef __cplusplus
}
#endif

#endif /* MBCPEOPLE_H_ */

