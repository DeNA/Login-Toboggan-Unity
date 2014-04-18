//
//  MBSocialEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBSocialBaseEvent.h"

/**
 * @file MBSocialEvent.h
 * Creates events that describe interactions between users.
 * @since 1.5
 */

/**
 * Stores information about an event that describes an interaction between users. Call
 * <code>MBEventReporter::report:</code> to report the event to the analytics server.
 * @since 1.5
 */
@interface MBSocialEvent : MBSocialBaseEvent
/**
 * Create a new event that describes an interaction between the current user and another
 * Mobage user.
 * @param eventId The ID for the type of interaction that is being reported.
 * @param friendId The numeric ID of the other Mobage user.
 * @param payload Additional information about the event, or <code>nil</code> if there is no
 *      additional information to provide. Each value must be an <code>NSString</code>.
 * @return The new analytics event.
 * @since 1.5
 */
- (id) initWithId: (NSString*) eventId friendId: (NSString*) friendId payload: (NSDictionary*) payload;

@end
