//
//  MBErrorEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBGameOpsEvent.h"

/**
 * @file MBErrorEvent.h
 * Creates events that describe app errors.
 * @since 1.5
 */

/**
 * Stores information about an event that describes an app error. Call
 * <code>MBEventReporter::report:</code> to report the event to the analytics server.
 * @since 1.5
 */
@interface MBErrorEvent : MBGameOpsEvent

/**
 * Create an event that describes an app error.
 * @param message An error identifier, or a description of the error.
 * @return The new analytics event.
 * @since 1.5
 */
- (id) initWithMessage: (NSString*) message;

@end
