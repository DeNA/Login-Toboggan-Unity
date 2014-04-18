//
//  MBGameEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBGameBaseEvent.h"

/**
 * @file MBAnalyticsEvent.h
 * Creates custom, app-specific analytics events.
 * @since 1.5
 */

/** 
 * Stores information about a custom, app-specific analytics event. Use this class to
 * report events that do not fit into any other category. Call
 * <code>MBEventReporter::report:</code> to report the event to the analytics server.
 * @since 1.5
 */
@interface MBGameEvent : MBGameBaseEvent

/**
 * Create a custom, app-specific analytics event. 
 * @param eventId The ID for the type of event that is being reported.
 * @param payload Additional information about the event, or <code>nil</code> if there is no
 *      additional information to provide. Each value must be an <code>NSString</code>.
 * @param playerState Information about the user's current state, such as the user's level and
 *      number of lives remaining, or <code>nil</code> to omit this information. Each value must
 *      be an <code>NSString</code>. <strong>Note</strong>: Do not use this method to report events
 *      that primarily affect the user's state. Also, do not include information that is unique to
 *      the user, such as a user ID or nickname.
 * @return The custom analytics event.
 * @since 1.5
 */
- (id) initWithId: (NSString*) eventId payload: (NSDictionary*) payload playerState:(NSDictionary*) playerState;

@end
