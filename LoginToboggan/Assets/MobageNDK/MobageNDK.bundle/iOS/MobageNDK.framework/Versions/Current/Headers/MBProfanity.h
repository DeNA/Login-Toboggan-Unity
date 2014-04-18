//
//  MBProfanity.h
//  mobage-ndk
//
//  Created by ngmoco on 3/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"

/**
 * @file MBProfanity.h
 * Checks strings for profanity.
 * @since 1.5
 */

/**
 * Determine whether a string contains words that are clearly profane or offensive. On
 * the US/worldwide platform, this class checks for English-language profanity.
 * <p>
 * The list of profane and offensive words may be updated at any time.
 * @since 1.5
 */
@protocol MBProfanity <NSObject>

/**
 * Check a text string to determine whether it contains words that are clearly profane or
 * offensive.
 * @param text The string to check for profanity.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>textIsValid</code>: Set to <code>YES</code> if the string is valid, or <code>NO</code>
 * if the string contains profane or offensive words.</li>
 * </ul>
 *		Called if the string is successfully checked for profanity. The <code>textIsValid</code>
 *			parameter is set to <code>YES</code> if the string is valid, or <code>NO</code> if the
 *			string contains profane or offensive words.
 *		Called if an error occurs while checking a string for profanity. The <code>error</code>
 *			parameter contains information about the error.
 * @since 2.0
 */
+ (void)checkProfanity:(NSString *)text 
	 withCallbackQueue:(dispatch_queue_t)cbQueue
            onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error, BOOL textIsValid))completeCb;

#pragma mark - Deprecated
+(void)checkProfanity:(NSString *)text 
	withCallbackQueue:(dispatch_queue_t)cbQueue
            onSuccess:(void (^)(BOOL textIsValid))successCb
              onError:(void (^)(MBError *error))errorCb							__attribute__((deprecated)) /*Deprecated in 1.9*/;

@end

