//
//  MBPlayerEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBAnalyticsEvent.h"

/**
 * @file MBPlayerEvent.h
 * Support class for analytics events.
 * @since 1.5
 */

/**
 * Base class for an event that describes a change in the user's state.
 * @since 1.5
 */
@interface MBPlayerEvent : MBAnalyticsEvent

- (id) initWithId: (NSString*) eventId class: (NSString*) eventClass change:(NSDictionary*) change state: (NSDictionary*) playerState;

@end
