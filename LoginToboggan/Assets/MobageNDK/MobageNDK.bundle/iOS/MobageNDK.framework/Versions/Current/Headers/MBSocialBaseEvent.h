//
//  MBSocialBaseEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBAnalyticsEvent.h"

/**
 * @file MBSocialBaseEvent.h
 * Support class for analytics events.
 * @since 1.5
 */

/**
 * Base class for events that describe interactions between users.
 * @since 1.5
 */
@interface MBSocialBaseEvent : MBAnalyticsEvent

- (id) initWithId: (NSString*) eventId friendId: (NSString*) friendId payload: (NSDictionary*) payload;

@end
