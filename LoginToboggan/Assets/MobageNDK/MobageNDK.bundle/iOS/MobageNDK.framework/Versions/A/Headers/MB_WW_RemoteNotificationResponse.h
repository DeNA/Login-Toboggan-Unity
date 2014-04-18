//
//  MB_WW_RemoteNotificationResponse.h
//  NGMobageUS
//
//  Created by Toliver Chris on 7/24/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MB_WW_DataModel.h"
#import "MBRemoteNotificationPayload.h"
#import "MBRemoteNotificationResponse.h"


@protocol MB_WW_RemoteNotificationResponse <MBRemoteNotificationResponse>
@property (atomic, readwrite, strong) NSObject<MBRemoteNotificationPayload> *payload;
@property (atomic, readwrite, strong) NSDate                      *publishedTimestamp;
@end

@interface MB_WW_RemoteNotificationResponse : MB_WW_DataModel<MB_WW_RemoteNotificationResponse>
+(NSDate *)getPublishedTimestamp:(NSString *) publishedString;
@end
