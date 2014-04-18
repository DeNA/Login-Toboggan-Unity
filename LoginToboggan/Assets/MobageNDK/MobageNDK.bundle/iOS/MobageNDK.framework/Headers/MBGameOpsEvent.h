//
//  MBGameOpsEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBAnalyticsEvent.h"

/**
 * @file MBGameOpsEvent.h
 * Support class for analytics events.
 * @since 1.5
 */

/**
 * Base class for events that describe an app error.
 * @since 1.5
 */
@interface MBGameOpsEvent : MBAnalyticsEvent

- (id) initWithId: (NSString*) eventId payload: (NSDictionary*) payload;

@end
