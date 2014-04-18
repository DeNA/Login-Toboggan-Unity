//
//  MB_WW_RemoteNotification+Internal.h
//  NGMobageUS
//
//  Created by Eric So on 5/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MB_WW_RemoteNotification.h"

@protocol MB_WW_RemoteNotificationInternal <MB_WW_RemoteNotification>

+ (void)registerForRemoteNotification:(NSData *)deviceToken;

@end

@interface MB_WW_RemoteNotification () <MB_WW_RemoteNotificationInternal>

@end
