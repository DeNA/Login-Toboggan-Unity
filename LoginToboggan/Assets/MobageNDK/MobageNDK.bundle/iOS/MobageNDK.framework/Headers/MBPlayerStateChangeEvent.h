//
//  MBPlayerStateChangeEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBPlayerEvent.h"

/**
 * @file MBPlayerStateChangeEvent.h
 * Creates events that describe changes in a user's state.
 * @since 1.5
 */

/**
 * Stores information about an event that describes changes in a user's state. For
 * example, your app can generate an <code>MBPlayerStateChangeEvent</code> when the user gains or
 * loses a life, or when the user advances to a new level. Your app should also generate an
 * <code>MBPlayerStateChangeEvent</code> when a user purchases or spends virtual currency.
 * <p>
 * Call <code>MBEventReporter::report:</code> to report the event to the analytics server.
 * @since 1.5
 */
@interface MBPlayerStateChangeEvent : MBPlayerEvent

/**
 * Create an event that describes changes in a user's state.
 * @param eventId The event ID.
 * @param change Information about the change that has occurred in the user's state. Include only
 *      properties that have changed in a way that you want to track. In addition, report the change
 *      in the property's value, not the new value of the property. For example, if the user spent
 *      100 units of currency, use the value <code>-100</code>. Each value must be an
 *      <code>NSString</code>.
 * @param playerState Information about the user's current state, such as the user's level and
 *      number of lives remaining, or <code>nil</code> to omit this information. Each value must
 *      be an <code>NSString</code>. <strong>Note</strong>: Do not use this method to report events
 *      that primarily affect the user's state. Also, do not include information that is unique to
 *      the user, such as a user ID or nickname.
 * @return The new analytics event.
 * @since 1.5
 */
- (id) initWithId: (NSString*) eventId change: (NSDictionary*) change state: (NSDictionary*) playerState;

@end
