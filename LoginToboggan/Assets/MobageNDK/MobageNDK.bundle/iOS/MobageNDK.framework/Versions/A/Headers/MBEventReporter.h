//
//  MBEventReporter.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#import "MBAnalyticsEvent.h"

/**
 * @file MBEventReporter.h
 * Send analytics events to Mobage.
 */

/**
 * Reporter for Mobage analytics events.
 * @since 1.5
 */
@protocol MBEventReporter <NSObject>

/**
 * Report an analytics event to the Mobage server.
 * @param event The analytics event to report.
 * @since 1.5
 */
- (void)report:(id<MBAnalyticsEvent>) event;
@end

