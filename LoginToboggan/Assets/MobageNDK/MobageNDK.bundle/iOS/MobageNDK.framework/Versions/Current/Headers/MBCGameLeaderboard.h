//
//  MBCGameLeaderboard.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCGAMELEADERBOARD_H_
#define MBCGAMELEADERBOARD_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCScore.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * uid);
		MBC_Common_IsActive(const char * appId);
		MBC_Common_IsActive(const char * title);
		MBC_Common_IsActive(const char * scoreFormat);
		MBC_Common_IsActive(int32_t scorePrecision);
		MBC_Common_IsActive(const char * iconUrl);
		MBC_Common_IsActive(bool allowLowerScore);
		MBC_Common_IsActive(bool reverse);
		MBC_Common_IsActive(bool archived);
		MBC_Common_IsActive(double defaultScore);
		MBC_Common_IsActive(const char * published);
		MBC_Common_IsActive(const char * updated);
	}  MBCGameLeaderboard;
	
	MBCArrayForType(GameLeaderboard,MBCGameLeaderboard *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(GameLeaderboard);
	MBCRetainPrototype(GameLeaderboard_Array);
	MBCReleasePrototype(GameLeaderboard);
	MBCReleasePrototype(GameLeaderboard_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCGameLeaderboard * MBCConstructGameLeaderboard(void * __CAPI_NATIVEREF);
	MBCGameLeaderboard_Array * MBCConstructGameLeaderboard_Array(void * __CAPI_NATIVEREF);
	
	MBCGameLeaderboard * MBCCopyConstructGameLeaderboard(MBCGameLeaderboard * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCGameLeaderboard_Array * MBCCopyConstructGameLeaderboard_Array(MBCGameLeaderboard_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructGameLeaderboard(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructGameLeaderboard_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCGameLeaderboard_getLeaderboardForIdCallback
	 * @description 	 * Callback for retrieving information about a leaderboard.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCGameLeaderboard * leaderboard Information about the leaderboard, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCGameLeaderboard_getLeaderboardForIdCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCGameLeaderboard * leaderboard,
				
				void * context
																);
	/**
	 * MBCGameLeaderboard_getLeaderboardsForIdsCallback
	 * @description 	 * Callback for retrieving information about multiple leaderboards.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCGameLeaderboard_Array * leaderboards An array of <c>GameLeaderboard</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCGameLeaderboard_getLeaderboardsForIdsCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCGameLeaderboard_Array * leaderboards,
				
				void * context
																);
	/**
	 * MBCGameLeaderboard_getAllLeaderboardsCallback
	 * @description 	 * Callback for retrieving information about all of the current app's leaderboards.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCGameLeaderboard_Array * leaderboards An array of <c>GameLeaderboard</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCGameLeaderboard_getAllLeaderboardsCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCGameLeaderboard_Array * leaderboards,
				
				void * context
																);
	/**
	 * MBCGameLeaderboard_getScoresForLeaderboardCallback
	 * @description 	 * Callback for retrieving a leaderboard's top scores.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCScore_Array * scores An array of <c>Score</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCGameLeaderboard_getScoresForLeaderboardCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCScore_Array * scores,
				
				void * context
																);
#if MB_JP
	/**
	 * MBCGameLeaderboard_getFriendsScoresForLeaderboardCallback
	 * @description 	 * Callback for retrieving a leaderboard's top scores for the current user's friends.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCScore_Array * scores An array of <c>Score</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCGameLeaderboard_getFriendsScoresForLeaderboardCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCScore_Array * scores,
				
				void * context
																);
#endif // MB_JP
	/**
	 * MBCGameLeaderboard_getScoreForLeaderboardCallback
	 * @description 	 * Callback for retrieving a user's top score on a leaderboard.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCScore * score Information about the user's score, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCGameLeaderboard_getScoreForLeaderboardCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCScore * score,
				
				void * context
																);
	/**
	 * MBCGameLeaderboard_updateCurrentUserScoreForLeaderboardCallback
	 * @description 	 * Callback for updating the current user's top score.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCScore * score Information about the user's score, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCGameLeaderboard_updateCurrentUserScoreForLeaderboardCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCScore * score,
				
				void * context
																);
	/**
	 * MBCGameLeaderboard_deleteCurrentUserScoreForLeaderboardCallback
	 * @description 	 * Callback for deleting the current user's top score.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCGameLeaderboard_deleteCurrentUserScoreForLeaderboardCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCGameLeaderboard_getLeaderboardForId
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a leaderboard.
	 *
	 * @param const char *  leaderboardId The leaderboard IDs of the leaderboards to retrieve.			AUTORELEASED
	 * @cb GetLeaderboardForIdOnCompleteCallback  onComplete 
		 * Callback for retrieving information about a leaderboard.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCGameLeaderboard * leaderboard Information about the leaderboard, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCGameLeaderboard_getLeaderboardForId(
										const char *  leaderboardId,
										MBCGameLeaderboard_getLeaderboardForIdCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCGameLeaderboard_getLeaderboardsForIds
	 * @function
	 * @public
	 * @description 	 * Retrieve information about multiple leaderboards.
	 *
	 * @param MBCString_Array *  leaderboardIds The leaderboard IDs of the leaderboards to retrieve.			AUTORELEASED
	 * @cb GetLeaderboardsForIdsOnCompleteCallback  onComplete 
		 * Callback for retrieving information about multiple leaderboards.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCGameLeaderboard_Array * leaderboards An array of <c>GameLeaderboard</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCGameLeaderboard_getLeaderboardsForIds(
										MBCString_Array *  leaderboardIds,
										MBCGameLeaderboard_getLeaderboardsForIdsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCGameLeaderboard_getAllLeaderboards
	 * @function
	 * @public
	 * @description 	 * Retrieve information about all of the current app's leaderboards.
	 *
	 * @cb GetAllLeaderboardsOnCompleteCallback  onComplete 
		 * Callback for retrieving information about all of the current app's leaderboards.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCGameLeaderboard_Array * leaderboards An array of <c>GameLeaderboard</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCGameLeaderboard_getAllLeaderboards(
										MBCGameLeaderboard_getAllLeaderboardsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCGameLeaderboard_getScoresForLeaderboard
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a leaderboard's top scores, starting with the highest score.
	 * You can use the <c>count</c> and <c>startIndex</c> parameters to control the
	 * number of results that this method retrieves, as well as the start index for the search
	 * results.
	 *
	 * @param MBCGameLeaderboard *  leaderboard The leaderboard whose scores will be retrieved.			AUTORELEASED
	 * @param int32_t  count The number of results to retrieve. The default value is <c>50</c>.			
	 * @param int32_t  startIndex The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb GetScoresForLeaderboardOnCompleteCallback  onComplete 
		 * Callback for retrieving a leaderboard's top scores.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCScore_Array * scores An array of <c>Score</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCGameLeaderboard_getScoresForLeaderboard(
										MBCGameLeaderboard *  leaderboard,
										int32_t  count,
										int32_t  startIndex,
										MBCGameLeaderboard_getScoresForLeaderboardCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#if MB_JP
	/**
	 * MBCGameLeaderboard_getFriendsScoresForLeaderboard
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a leaderboard's scores that were earned by the current user's friends, starting with the highest score.
	 * You can use the <c>count</c> and <c>startIndex</c> parameters to control the
	 * number of results that this method retrieves, as well as the start index for the search
	 * results.
	 * @deprecated This method will be removed in a future version.
	 *
	 * @param MBCGameLeaderboard *  leaderboard The leaderboard whose scores will be retrieved.			AUTORELEASED
	 * @param int32_t  count The number of results to retrieve. The default value is <c>50</c>.			
	 * @param int32_t  startIndex The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb GetFriendsScoresForLeaderboardOnCompleteCallback  onComplete 
		 * Callback for retrieving a leaderboard's top scores for the current user's friends.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCScore_Array * scores An array of <c>Score</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCGameLeaderboard_getFriendsScoresForLeaderboard(
										MBCGameLeaderboard *  leaderboard,
										int32_t  count,
										int32_t  startIndex,
										MBCGameLeaderboard_getFriendsScoresForLeaderboardCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_JP
	/**
	 * MBCGameLeaderboard_getScoreForLeaderboard
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a user's top score on a leaderboard.
	 *
	 * @param MBCGameLeaderboard *  leaderboard The leaderboard whose score will be retrieved.			AUTORELEASED
	 * @param MBCUser *  user The user whose top score will be retrieved.			AUTORELEASED
	 * @cb GetScoreForLeaderboardOnCompleteCallback  onComplete 
		 * Callback for retrieving a user's top score on a leaderboard.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCScore * score Information about the user's score, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCGameLeaderboard_getScoreForLeaderboard(
										MBCGameLeaderboard *  leaderboard,
										MBCUser *  user,
										MBCGameLeaderboard_getScoreForLeaderboardCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCGameLeaderboard_updateCurrentUserScoreForLeaderboard
	 * @function
	 * @public
	 * @description 	 * Update the current user's top score on a leaderboard.
	 *
	 * @param MBCGameLeaderboard *  leaderboard The leaderboard whose score for the current user will be updated.			AUTORELEASED
	 * @param double  value The current user's score.			
	 * @cb UpdateCurrentUserScoreForLeaderboardOnCompleteCallback  onComplete 
		 * Callback for updating the current user's top score.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCScore * score Information about the user's score, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCGameLeaderboard_updateCurrentUserScoreForLeaderboard(
										MBCGameLeaderboard *  leaderboard,
										double  value,
										MBCGameLeaderboard_updateCurrentUserScoreForLeaderboardCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCGameLeaderboard_deleteCurrentUserScoreForLeaderboard
	 * @function
	 * @public
	 * @description 	 * Delete the current user's top score from a leaderboard.
	 *
	 * @param MBCGameLeaderboard *  leaderboard The leaderboard whose score for the current user will be deleted.			AUTORELEASED
	 * @cb DeleteCurrentUserScoreForLeaderboardOnCompleteCallback  onComplete 
		 * Callback for deleting the current user's top score.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCGameLeaderboard_deleteCurrentUserScoreForLeaderboard(
										MBCGameLeaderboard *  leaderboard,
										MBCGameLeaderboard_deleteCurrentUserScoreForLeaderboardCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	#pragma mark - Instance Methods
	// None!


#ifdef __cplusplus
}
#endif

#endif /* MBCGAMELEADERBOARD_H_ */

