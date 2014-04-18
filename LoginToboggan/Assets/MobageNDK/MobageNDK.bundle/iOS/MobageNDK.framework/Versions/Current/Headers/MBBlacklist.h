//
//  MBBlacklist.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/13/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBPagingAPIResult.h"
#import "MBPagingAPIOptions.h"
#import "MBError.h"

@protocol MBUser;


/**
 * Retrieves and searches a user's blacklist, which lists the Mobage users that a user
 * has blocked.
 * @since 1.5
 */
@protocol MBBlacklist <NSObject>

/**
 * Retrieve a user's entire blacklist. You can use the <code>howMany</code> and
 * <code>startOffset</code> parameters to control the number of results that this method retrieves,
 * as well as the start index for the search results.
 * <p>
 * <strong>Important</strong>: In version 2.3 and later, the start index for the search results is
 * <code>1</code>. Previous versions used a start index of <code>0</code>.
 * @param user The user whose blacklist will be retrieved.
 * @param howMany The number of results to retrieve. The default value is <code>50</code>.
 * @param startOffset The start index for the search results. The default value is <code>1</code>.
 *      <strong>Important</strong>: The index's numbering begins at <code>1</code>, <em>not</em>
 *      <code>0</code>.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>blacklistedUsers</code>: An array of <code>MBUser</code> objects representing
 * blacklisted users.</li>
 * <li><code>startOffset</code>: The starting index for this group of items within the entire list,
 * or <code>nil</code> if the request did not succeed. <strong>Important</strong>: The index's
 * numbering begins at <code>1</code>, <em>not</em> <code>0</code>.</li>
 * <li><code>totalPossibleResults</code>: The total number of items that can be retrieved, or
 * <code>nil</code> if the request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void)fetchBlacklistOfUser:(NSObject<MBUser>*)user
					 howMany:(NSInteger)howMany
				 startOffset:(NSInteger)startOffset
		   withCallbackQueue:(dispatch_queue_t)cbQueue
				  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSArray * blacklistedUsers, NSInteger startOffset, NSInteger totalPossibleResults))completeCb;
/**
 * Check whether a user's blacklist contains a specified user.
 * @param user The user whose blacklist will be checked.
 * @param targetUser The user to search for in the blacklist.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>isBlacklisted</code>: Set to <code>YES</code> if the target user is on the user's
 * blacklist or <code>NO</code> if the target user is not on the blacklist.</li>
 * </ul>
 * @since 2.0
 */
+ (void)checkBlacklistOfUser:(NSObject<MBUser>*)user
					 forUser:(NSObject<MBUser>*)targetUser
		   withCallbackQueue:(dispatch_queue_t)cbQueue
				  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, BOOL isBlacklisted))completeCb;
// not public
+ (void) checkBlacklistOfUserId:(NSString *)userId 
					  forUserId:(NSString *)targetUserId
						options:(MBPagingAPIOptions *)options
			  withCallbackQueue:(dispatch_queue_t)cbQueue
					 onComplete:(void (^)(MBError * error, NSArray *listedUserIds, MBPagingAPIResult *result))completeCb;

#pragma mark - Deprecated
@optional
+ (void) checkBlackList:(NSString *)userId
			  againstId:(NSString *)targetUserId
                    opt:(MBPagingAPIOptions *)option
	  withCallbackQueue:(dispatch_queue_t)cbQueue
              onSuccess:(void (^)(NSArray *listedUserIds, MBPagingAPIResult *result))successCB
                onError:(void (^)(MBError *error))errorCB										__attribute__((deprecated)) /*Deprecated in 1.9*/;

@end

