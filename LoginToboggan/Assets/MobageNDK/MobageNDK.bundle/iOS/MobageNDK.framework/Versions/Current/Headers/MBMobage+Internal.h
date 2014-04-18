//
//  MBMobage+Internal.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_MBMobage_Internal_h
#define mobage_ndk_MBMobage_Internal_h

#import "MBMobage.h"
#import "MB_G_MobageSession.h"

@class MB_G_EventReporterSession;

@protocol MBMobageInternal <MBMobage, MB_G_SessionEstablishmentInfo>

@property (atomic, readwrite, strong) MB_G_EventReporterSession* analyticsSession;
@property (atomic, readonly, strong) NSObject<MB_G_SessionEstablishmentInfo>* sessionEstablishmentInfo;

@property (atomic, readwrite, assign) MBServerStage serverStage;
@property (atomic, readwrite, assign) MBServerEnvironment serverEnvironment;

@property (atomic, readwrite, assign) BOOL allowOptionalReg;

/**
 * for internal use only.
 */
+ (void) initializeMobageWithServerEnvironment: (MBServerEnvironment)serverEnvironment 
                                   serverStage: (MBServerStage)serverStage
                                         appId: (NSString*) appId
                                    appVersion: (NSString*) appVersion
                                   consumerKey: (NSString*) consumerKey
                                consumerSecret: (NSString*) consumerSecret;

- (void) initializeMobageSession;

/**
 * Deal with a push payload
 * @since 2.0
 */
- (void)handlePushPayload:(NSDictionary*)payload;

/**
 * Register for remote notification to Mobage remote notification server
 * @since 2.0
 */
- (void)registerForRemoteNotification;

#pragma mark Lifecycle Events!
/**
 * Report an app pause event to the analytics service.
 * Called by NGAppPatch whenever it is paused.
 * @since 2.0
 */
-(void)_onPause;
/**
 * Report an app resume event to the analytics service.
 * Called by NGAppPatch whenever it is resumed.
 * @since 2.0
 */
-(void)_onResume;
/**
 *Report an app stop event to the analytics service.
 * Called by NGAppPatch whenever it is stopped.
 * @since 2.0
 */
-(void)_onStop;

/**
 * _onApplicationDidBecomeActive
 * Called by NGAppPatch via applicationDidBecomeActive
 * @since 2.3
 */
-(void)_onApplicationDidBecomeActive;


/**
 * Retrieve the Native SDK's version number, in the format
 * <code>Major.Minor.Hotfix.Patch</code> (for example, <code>2.0.1.0</code>).
 * @return The Native SDK's version number.
 * @since 1.5
 */

@end

@interface MBMobage () <MBMobageInternal> 
{
	BOOL initialized;
}
@end

#endif
