//
//  MBRemoteNotificationResponse.h
//  mobage-ndk
//
//  Created by Toliver Chris on 7/23/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBRemoteNotificationPayload.h"
#import "MBDataModel.h"

/**
 * @file MBRemoteNotificationResponse.h
 * Model for the response to a client's request to send a remote notification.
 * @since 2.0
 */

/**
 * Response to a client's request to send a remote notification.
 * @since 2.0
 */
@protocol MBRemoteNotificationResponse <MBDataModel>

@property (nonatomic, readonly, strong) NSString * responseId;

/**
 * The remote notification's payload.
 * @since 2.0
 */
@property (atomic, readonly, strong) NSObject<MBRemoteNotificationPayload> *payload;

/**
 * The UTC date and time when the Mobage server received the request, using the format
 * <code>YYYY-MM-DDThh:mm:ssZ</code>.
 * @since 2.0
 */
@property (atomic, readonly, strong) NSDate                      *publishedTimestamp;

@end
