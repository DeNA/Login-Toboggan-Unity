//
//  MBFunnelEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBAnalyticsEvent.h"

/**
 * The Funnel Stage Event tracks player progress through funnels and player level progression.
 * A funnel measures the number of stages that the application's target audience progresses through before exiting that area of the application.
 * Reporting this event using {@link EventReport.reportEvent} will alert the analytics platform that a user has generated a funnel stage event.
 * This information is used to plot how many users complete certain stages in the game.
 * @since 1.0
 */
@interface MBFunnelEvent : MBAnalyticsEvent

/**
 * @param funnelName Identifier for the funnel.
 * @param funnelStage Funnel stage number within funnelName
 * @param funnelStageName Name of the funnelStage
 */
- (id) initWithName: (NSString*) funnelName payload: (NSDictionary*) payload playerState: (NSDictionary*) playerState;

@end
