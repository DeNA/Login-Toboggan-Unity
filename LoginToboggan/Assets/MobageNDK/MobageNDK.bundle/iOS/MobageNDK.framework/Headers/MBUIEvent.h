//
//  MBUIEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBAnalyticsEvent.h"

/**
 * @name MBUIEvent.h
 * Support class for analytics events.
 * @since 1.5
 */

/**
 * Base class for an event that describes in-app navigation.
 * @since 1.5
 */
@interface MBUIEvent : MBAnalyticsEvent

- (id) initWithId: (NSString*) eventId payload: (NSDictionary*) payload;

@end
