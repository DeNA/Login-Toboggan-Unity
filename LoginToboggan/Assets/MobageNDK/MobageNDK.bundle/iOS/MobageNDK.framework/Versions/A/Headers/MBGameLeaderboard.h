//
//  MBGameLeaderboard.h
//  mobage-ndk
//
//  Created by Chris Toliver on 6/13/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//


#import <Foundation/Foundation.h>
#import "MBDataModel.h"
#import "MBScore.h"
#import "MBInterfaceEnums.h"
#import "MBError.h"
#import "MBUser.h"

/**
 * @file MBGameLeaderboard.h
 * Model for information about a Mobage leaderboard.
 * @since 2.0
 */

/**
 * Information about a Mobage leaderboard, which stores high scores for the app. An app can
 * perform any of the following actions on a leaderboard:
 * <ul>
 * <li>Delete the current user's top score</li>
 * <li>Retrieve information about leaderboards</li>
 * <li>Submit a top score for the current user</li>
 * <li>Retrieve a leaderboard's top score</li>
 * <li>Retrieve a list of top scores for all users</li>
 * </ul>
 * The Mobage West platform supports two kinds of time-limited leaderboards:
 * <ul>
 * <li><strong>Timed leaderboards</strong>, which reset all scores on a fixed schedule (for
 * example, daily). After a timed leaderboard has closed, you cannot retrieve its scores.
 * <li><strong>Windowed leaderboards</strong>, which are used once for a fixed period of time
 * (for example, during a special event). After a windowed leaderboard has closed, you can
 * retrieve its scores for 3 days.</li>
 * </ul>
 * If your app uses timed or windowed leaderboards, the error code
 * <code>MBHTTPErrorPermissionDenied</code> is returned if:
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
 * @since 2.0
 */
@protocol MBGameLeaderboard <MBDataModel>
/**
 * The app ID associated with the leaderboard.
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *appId;

/**
 * The leaderboard's title.
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *title;

/**
 * The rules that the leaderboard uses to format a score for display. Contains one of the following
 * values:
 * <ul>
 * <li><code>day_hour</code>: Formatted as <code>DD HH.zzz</code>. The score represents the
 * number of seconds.</li>
 * <li><code>day_minute</code>: Formatted as <code>DD HH:MM.zzz</code>. The score represents
 * the number of seconds.</li>
 * <li><code>day_second</code>: Formatted as <code>DD HH:MM:SS.zzz</code>. The score represents
 * the number of seconds.</li>
 * <li><code>decimal</code>: Formatted as a signed double.</li>
 * <li><code>hour_minute</code>: Formatted as <code>HH:MM.zzz</code>. The score represents the
 * number of seconds.</li>
 * <li><code>hour_second</code>: Formatted as <code>HH:MM:SS.zzz</code>. The score represents
 * the number of seconds.</li>
 * <li><code>hours</code>: Formatted as <code>HH.zzz</code>. The score represents the number
 * of seconds.</li>
 * <li><code>integer</code>: Formatted as a signed 32-bit integer.</li>
 * <li><code>minute_second</code>: Formatted as <code>MM:SS.zzz</code>. The score represents the
 * number of seconds.</li>
 * <li><code>minutes</code>: Formatted as <code>MM.zzz</code>. The score represents the number
 * of seconds.</li>
 * <li><code>seconds</code>: Formatted as <code>SS.zzz</code>. The score represents the number
 * of seconds.</li>
 * </ul>
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *scoreFormat;

/**
 * The number of decimal places that the leaderboard uses when it reformats a score for display.
 * @since 2.0
 */
@property (nonatomic, readonly, assign) NSInteger scorePrecision;

/**
 * The URL of the leaderboard icon.
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *iconUrl;

/**
 * Indicates whether a user's top score can be replaced by a new, lower score.
 * @since 2.0
 */
@property (nonatomic, readonly, assign) BOOL allowLowerScore;

/**
 * Indicates whether the leaderboard treats lower scores as more desirable.
 * @since 2.0
 */
@property (nonatomic, readonly, assign) BOOL reverse;

/**
 * Indicates whether the leaderboard has been archived and can no longer be updated.
 * <ul>
 * <li>If <c>true</c>, the leaderboard has been closed and can no longer be updated. Only timed and windowed leaderboards can be closed.</li>
 * <li>If <c>false</c>, the leaderboard can be updated.</li>
 * </ul>
 * @since 2.0
 */
@property (nonatomic, readonly, assign) BOOL archived;

/**
 * The default score for users that have not recorded a top score.
 * @since 2.0
 */
@property (nonatomic, readonly, assign) double defaultScore;

/**
 * The date and time when the leaderboard was created. Uses the format
 * <code>YYYY-MM-DDThh:mm:ss</code>.
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *published;

/**
 * The date and time when the leaderboard was updated. Uses the format
 * <code>YYYY-MM-DDThh:mm:ss</code>.
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *updated;

/**
 * Retrieve information about a leaderboard.
 * @param leaderboardId The leaderboard ID of the leaderboard to retrieve.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>leaderboard</code>: Information about the leaderboard, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getLeaderboardForId:(NSString*)leaderboardId
         withCallbackQueue:(dispatch_queue_t)cbQueue
                onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBGameLeaderboard> *leaderboard))completeCb;

/**
 * Retrieve information about multiple leaderboards.
 * @param leaderboardIds The leaderboard IDs of the leaderboards to retrieve.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>leaderboards</code>: An array of <code>MBGameLeaderboard</code> objects, or
 * <code>nil</code> if the request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getLeaderboardsForIds:(NSArray*)leaderboardIds 
           withCallbackQueue:(dispatch_queue_t)cbQueue
                  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *leaderboards))completeCb;


/**
 * Retrieve information about all of the current app's leaderboards.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>leaderboards</code>: An array of <code>MBGameLeaderboard</code> objects, or
 * <code>nil</code> if the request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getAllLeaderboardsWithCallbackQueue:(dispatch_queue_t)cbQueue 
                                onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *leaderboards))completeCb;

// not public
+(void)getScoresForLeaderboardId:(NSString*)leaderboardId
                           count:(NSInteger)count
                      startIndex:(NSInteger)startIndex
               withCallbackQueue:(dispatch_queue_t)cbQueue
                      onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *scores))completeCb;

/**
 * Retrieve information about a leaderboard's top scores, starting with the highest score. You can
 * use the <code>count</code> and <code>startIndex</code> parameters to control the number of
 * results that this method retrieves, as well as the start index for the search results.
 * @param leaderboard The leaderboard whose scores will be retrieved.
 * @param count The number of results to retrieve. The default value is <code>50</code>.
 * @param startIndex The start index for the search results. The default value is <code>1</code>.
 *      <strong>Important</strong>: The index's numbering begins at <code>1</code>, <em>not</em>
 *      <code>0</code>.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>scores</code>: An array of <code>MBScore</code> objects, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getScoresForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
                         count:(NSInteger)count
                    startIndex:(NSInteger)startIndex
             withCallbackQueue:(dispatch_queue_t)cbQueue
                    onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *scores))completeCb;

// not public
+(void)getFriendsScoresForLeaderboardId:(NSString*)leaderboardId
                                  count:(NSInteger)count
                             startIndex:(NSInteger)startIndex
                      withCallbackQueue:(dispatch_queue_t)cbQueue
                             onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *scores))completeCb;

// removed in SDK 2.5
+(void)getFriendsScoresForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
                                count:(NSInteger)count
                           startIndex:(NSInteger)startIndex
                    withCallbackQueue:(dispatch_queue_t)cbQueue
                           onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *scores))completeCb;

// not public
+(void)getScoreForLeaderboardId:(NSString*)leaderboardId
        forUserId:(NSString*)userId
       withCallbackQueue:(dispatch_queue_t)cbQueue
              onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBScore> *score))completeCb;

/**
 * Retrieve information about a user's top score on a leaderboard.
 * @param leaderboard The leaderboard whose score will be retrieved.
 * @param user The user whose top score will be retrieved.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>score</code>: Information about the user's score, or <code>nil</code> if the request
 * did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getScoreForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
        forUser:(NSObject<MBUser>*)user
     withCallbackQueue:(dispatch_queue_t)cbQueue
            onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBScore> *score))completeCb;


// not public
+(void)updateCurrentUserScoreForLeaderboardId:(NSString*)leaderboardId
                                        value:(double)value
                            withCallbackQueue:(dispatch_queue_t)cbQueue
                                   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBScore> *score))completeCb;

/**
 * Update the current user's top score on a leaderboard.
 * @param leaderboard The leaderboard whose score for the current user will be updated.
 * @param value The current user's score.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>score</code>: Information about the user's score, or <code>nil</code> if the request
 * did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)updateCurrentUserScoreForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
                                      value:(double)value
                          withCallbackQueue:(dispatch_queue_t)cbQueue
                                 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBScore> *score))completeCb;

// not public
+(void)deleteCurrentUserScoreForLeaderboardId:(NSString*)leaderboardId
                            withCallbackQueue:(dispatch_queue_t)cbQueue
                                   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;

/**
 * Delete the current user's top score from a leaderboard.
 * @param leaderboard The leaderboard whose score for the current user will be deleted.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0
 */
+(void)deleteCurrentUserScoreForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
                          withCallbackQueue:(dispatch_queue_t)cbQueue
                                 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;


@end

