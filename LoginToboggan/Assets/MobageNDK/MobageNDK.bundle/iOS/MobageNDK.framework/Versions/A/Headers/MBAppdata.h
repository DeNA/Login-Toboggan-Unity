//
//  MBAppdata.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 2/24/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#import "MBDataModel.h"
#import "MBError.h"
#import "MBInterfaceEnums.h"

/**
 * @file MBAppdata.h
 * Access app-specific data on the Mobage server.
 * @since 1.5
 */

/**
 * Create, update, retrieve, and delete app-specific data on the Mobage server. Data is
 * stored as key/value pairs that are tied to the current user and are limited as follows:
 * <ul>
 * <li>An app can store a maximum of 30 key/value pairs for each user.</li>
 * <li>The maximum key length is 32 bytes.</li>
 * <li>The maximum value length is 1,024 bytes.</li>
 * </ul>
 * Use the methods in this protocol to store app data that is tied to a specific user and should be
 * available whenever the user is logged into Mobage.
 * @since 1.5
 */
@protocol MBAppdata <MBDataModel>

//Class methods operate on instances or collections of instances.

/**
 * Delete one or more key/value pairs.
 * @param theKeys The keys to delete. Each key name must be an <code>NSString</code>.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>deletedKeys</code>: A list of keys that were deleted, with each key represented as an
 * <code>NSString</code>, or <code>nil</code> if the request did not succeed. <strong>Note</strong>:
 * The keys may not be in the same order as the list of keys in the request.</li>
 * </ul>
 * @since 2.0
 */
+ (void)deleteEntriesForKeys:(NSArray *)theKeys 
		   withCallbackQueue:(dispatch_queue_t)cbQueue
				  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *deletedKeys))completeCb;

/**
 * Retrieve one or more key/value pairs.
 * @param theKeys The keys to retrieve. Each key name must be an <code>NSString</code>.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>theKeys</code>: The keys that were retrieved, with each key represented as an
 * <code>NSString</code>, or <code>nil</code> if the request did not succeed. <strong>Note</strong>:
 * The keys may not be in the same order as the list of keys in the request.</li>
 * <li><code>theValues</code>: The values that were retrieved, with each value represented as an
 * <code>NSString</code>, or <code>nil</code> if the request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void)getEntriesForKeys:(NSArray *)theKeys
		withCallbackQueue:(dispatch_queue_t)cbQueue
			   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *theKeys, NSArray * theValues))completeCb;

/**
 * Create or update one or more key/value pairs.
 * @param theKeys The keys to create or update. Each key name must be an <code>NSString</code>.
 * @param theValues The values for each key. Each value must be an <code>NSString</code>.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>result</code>: The keys that were created or updated, with each key represented as an
 * <code>NSString</code>, or <code>nil</code> if the request did not succeed. <strong>Note</strong>:
 * The keys may not be in the same order as the list of keys in the request.</li>
 * </ul>
 * @since 2.0
 */
+ (void)updateEntriesWithKeys:(NSArray *)theKeys
					andValues:(NSArray *)theValues
			withCallbackQueue:(dispatch_queue_t)cbQueue
				   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *result))completeCb;

#pragma mark - Deprecated
@optional

@property (atomic, readwrite, retain) NSString		* key						/* Private in 2.0*/;
@property (atomic, readwrite, copy) NSString		* data						/* Private in 2.0*/;

+ (void)deleteEntries:(NSArray *)theKeys 
	withCallbackQueue:(dispatch_queue_t)cbQueue
			onSuccess:(void (^)(NSArray *result))successCB
			  onError:(void (^)(MBError *error))errorCB							__attribute__((deprecated)) /*Deprecated in 2.0*/;

+ (void)getEntries:(NSArray *)theKeys
 withCallbackQueue:(dispatch_queue_t)cbQueue
		 onSuccess:(void (^)(NSMutableDictionary *result))successCB
		   onError:(void (^)(MBError *error))errorCB							__attribute__((deprecated)) /*Deprecated in 2.0*/;

+ (void)updateEntries:(NSMutableDictionary *)theEntries
	withCallbackQueue:(dispatch_queue_t)cbQueue
			onSuccess:(void (^)(NSArray *result))successCB
			  onError:(void (^)(MBError *error))errorCB							__attribute__((deprecated)) /*Deprecated in 2.0*/;

@end

