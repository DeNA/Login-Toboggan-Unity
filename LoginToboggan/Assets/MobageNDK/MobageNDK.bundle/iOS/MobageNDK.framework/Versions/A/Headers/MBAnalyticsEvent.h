//
//  MBAnalyticsEvent.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * @file MBAnalyticsEvent.h
 * Support class for analytics events.
 * @since 1.5
 */

// AnalyticsEvent protocol. Objects implementing this protocol can be send to the analytics server via MBEventReporter
@protocol MBAnalyticsEvent <NSObject>

@property (atomic, readonly, strong) NSDictionary* payload;

@end


/**
 * Base class for analytics events.
 * @since 1.5
 */
@interface MBAnalyticsEvent : NSObject<MBAnalyticsEvent>

@property (atomic, readonly, strong) NSMutableDictionary* envelope;

// Initializes an analytics event. 
// @param eventId - sets the evid value of an analytics event.
// @param eventClass - set the evcl value of an analytics event.
// @param sourceType - signals where the event came from ( "GC" for game client, "PC" for platform client, "GS" for game server and "PS" for platform server.
// @param payload - custom payload. should not contain array. and should be a flat dictionary. can be NIL.
- (id) initWithId: (NSString*) eventId class:(NSString*) eventClass sourceType:(NSString*) sourceType payload:(NSDictionary*) payload;

@end
