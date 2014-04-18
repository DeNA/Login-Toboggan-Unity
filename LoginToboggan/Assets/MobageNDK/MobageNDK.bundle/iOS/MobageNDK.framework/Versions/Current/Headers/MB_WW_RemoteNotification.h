//
//  MB_WW_Notification.h
//  NGMobageUS
//
//  Created by Eric So on 5/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBRemoteNotification.h"
#import "MBRemoteNotification+Internal.h"

@protocol MB_WW_RemoteNotification <MBRemoteNotification,MBRemoteNotificationInternal>

@end

@interface MB_WW_RemoteNotification: NSObject<MB_WW_RemoteNotification>

@end
