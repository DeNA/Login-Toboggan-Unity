//
//  MBNavigationEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBUIEvent.h"

/**
 * @file MBNavigationEvent.h
 * Creates analytics events for in-app navigation.
 * @since 1.5
 */

/**
 * Stores information about an in-app navigation event. Generate these events when a 
 * user navigates between screens in an app. You can use this information to plot how users move
 * through the app, how long they spend on a screen, and what screen they navigate to next.
 * <p>
 * Call <code>MBEventReporter::report:</code> to report the event to the analytics server.
 * @since 1.5
 */
@interface MBNavigationEvent : MBUIEvent

/**
 * Create an in-app navigation event, which describes how a user has navigated between
 * the app's screens.
 * @param fromScreen The originating screen for the event.
 * @param toScreen The destination screen for the event.
 * @param btnId The ID of the button that triggered the navigation.
 * @return The navigation event.
 * @since 1.5
 */
- (id) initWithFromScreen:(NSString*) fromScreen toScreen: (NSString*) toScreen buttonId: (NSString*) btnId;

@end
