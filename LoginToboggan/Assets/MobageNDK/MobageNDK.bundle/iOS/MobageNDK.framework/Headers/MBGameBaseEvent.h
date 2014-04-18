//
//  MBGameBaseEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBAnalyticsEvent.h"

/**
 * @file MBGameBaseEvent.h
 * Support class for analytics events.
 * @since 1.5
 */

/**
 * Base class for an app's custom analytics events.
 * @since 1.5
 */
@interface MBGameBaseEvent : MBAnalyticsEvent

- (id) initWithId: (NSString*) eventId payload: (NSDictionary*) payload playerState:(NSDictionary*) playerState;

@end
