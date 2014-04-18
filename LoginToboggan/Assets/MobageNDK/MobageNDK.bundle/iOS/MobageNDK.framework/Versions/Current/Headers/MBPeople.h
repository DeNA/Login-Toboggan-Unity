//
//  MBPeople.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/11/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "User.h"
#import "MBError.h"
#import "MBPagingAPIResult.h"
#import "MBPagingAPIOptions.h"

/**
 * @file MBPeople.h
 * Provides access to user information.
 * @since 1.5
 */

/**
 * Provides access to information about Mobage users, including their personal 
 * information.
 * @since 1.5
 */
@protocol MBPeople <NSObject>

/**
 * Retrieve information about a specified user.
 * @param userId The user ID of the user to retrieve.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>user</code>: Information about the specified user, or <code>nil</code> if the request
 * did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) getUserForId:(NSString *)userId
	withCallbackQueue:(dispatch_queue_t)cbQueue 
		   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSObject<MBUser> *user))completeCb;

/**
 * Retrieve information about a maximum of 100 users.
 * @param userIds The user IDs of the users to retrieve. Each user ID must be an
 *      <code>NSString</code>. Must contain between 1 and 100 user IDs.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>users</code>: An array of <code>MBUser</code> objects, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) getUsersForIds:(NSArray *)userIds 
	  withCallbackQueue:(dispatch_queue_t)cbQueue 
			 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *users))completeCb;

/**
 * Retrieve information about the current user.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>user</code>: Information about the current user, or <code>nil</code> if the request did
 * not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) getCurrentUserWithCallbackQueue:(dispatch_queue_t)cbQueue 
							  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBUser> *user))completeCb;

// This method removed from API docs in SDK 2.5
+ (void) getFriendsForUser:(NSObject<MBUser>*)user
				   howMany:(NSInteger)howMany
			   startOffset:(NSInteger)startOffset
		 withCallbackQueue:(dispatch_queue_t)cbQueue 
				onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *users, NSInteger startOffset, NSInteger totalPossibleResultCount))completeCb;

// This method removed from API docs in SDK 2.5
+ (void) getFriendsWithGameForUser:(NSObject<MBUser> *)user
						   howMany:(NSInteger)howMany
					   startOffset:(NSInteger)startOffset
				   withCallbackQueue:(dispatch_queue_t)cbQueue 
						  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error,NSArray *users, NSInteger startOffset, NSInteger totalPossibleResultCount))completeCb;

#pragma mark - Deprecated
@optional
+ (void) getUser:(NSString *)userId
withCallbackQueue:(dispatch_queue_t)cbQueue 
       onSuccess:(void (^)(MBUser *user))successCB
         onError:(void (^)(MBError *error))errorCB								__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void) getUsers:(NSArray *)userIds 
withCallbackQueue:(dispatch_queue_t)cbQueue 
        onSuccess:(void (^)(NSArray *users))successCB
          onError:(void (^)(MBError *error))errorCB								__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void) getCurrentUser:(dispatch_queue_t)cbQueue 
              onSuccess:(void (^)(MBUser *user))successCB
                onError:(void (^)(MBError *error))errorCB						__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void) getFriends:(NSString *)userId 
                opt:(MBPagingAPIOptions *)option
  withCallbackQueue:(dispatch_queue_t)cbQueue 
          onSuccess:(void (^)(NSArray *users, MBPagingAPIResult *result))successCB
            onError:(void (^)(MBError *error))errorCB							__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void) getFriendsWithGame:(NSString *)userId 
                        opt:(MBPagingAPIOptions *)option
          withCallbackQueue:(dispatch_queue_t)cbQueue 
                  onSuccess:(void (^)(NSArray *users, MBPagingAPIResult *result))successCB
                    onError:(void (^)(MBError *error))errorCB					__attribute__((deprecated)) /*Deprecated in 1.9*/;
@end

