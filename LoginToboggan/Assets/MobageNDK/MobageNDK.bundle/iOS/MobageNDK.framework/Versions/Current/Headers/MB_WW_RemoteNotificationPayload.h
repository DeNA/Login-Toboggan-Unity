//
//  MB_WW_RemoteNotificationPayload.h
//  NGMobageUS
//
//  Created by Toliver Chris on 7/24/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MB_WW_DataModel.h"
#import "MBRemoteNotificationPayload.h"

@protocol MB_WW_RemoteNotificationPayload <MBRemoteNotificationPayload>
@property (atomic, readwrite, assign) NSInteger badge;
@property (atomic, readwrite, strong) NSString *message;
@property (atomic, readwrite, strong) NSString *sound;
@property (atomic, readwrite, strong) NSString *collapseKey;
@property (atomic, readwrite, strong) NSString *style;
@property (atomic, readwrite, strong) NSString *iconUrl;
@property (atomic, readwrite, strong) NSArray *extraKeys;
@property (atomic, readwrite, strong) NSArray *extraValues;
@end

@interface MB_WW_RemoteNotificationPayload : MB_WW_DataModel<MB_WW_RemoteNotificationPayload>
@end
