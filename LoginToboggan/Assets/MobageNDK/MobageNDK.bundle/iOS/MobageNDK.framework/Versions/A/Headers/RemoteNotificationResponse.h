//
//  RemoteNotificationResponse.h
//  mobage-ndk
//
//  Created by Toliver Chris on 7/23/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_RemoteNotificationResponse_h
#define mobage_ndk_RemoteNotificationResponse_h

#import "MBRemoteNotificationResponse.h"

#if MB_WW
#import "MB_WW_RemoteNotificationResponse.h"
#define RegionSpecificRemoteNotificationResponse MB_WW_RemoteNotificationResponse

#elif MB_JP || MB_KR
#import "MB_JP_RemoteNotificationResponse.h"
#define RegionSpecificRemoteNotificationResponse MB_JP_RemoteNotificationResponse
#elif MB_CN
#import "MB_CN_RemoteNotificationResponse.h"
#define RegionSpecificRemoteNotificationResponse MB_CN_RemoteNotificationResponse
#else
#error "Invalid Configuration"
#endif

@interface MBRemoteNotificationResponse : RegionSpecificRemoteNotificationResponse
@end

#if defined(RegionSpecificRemoteNotificationResponse)
#undef RegionSpecificRemoteNotificationResponse
#endif

#endif
