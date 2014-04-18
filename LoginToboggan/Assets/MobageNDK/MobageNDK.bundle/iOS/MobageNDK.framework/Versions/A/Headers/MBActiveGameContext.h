//
//  MBActiveGameContext.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_MBActiveGameContext_h
#define mobage_ndk_MBActiveGameContext_h

/**
 * @file MBActiveGameContext.h
 * Get information about the current app.
 * @since 1.5
 */

/**
 * Stores information about the current app.
 * @since 1.5
 */
@protocol MBActiveGameContext <NSObject>

/**
 * The app ID that was used to initialize the Mobage service.
 * @since 1.5
 * @see MBMobage::initializeWithServerEnvironment:andWithAppId:andWithAppVersion:andWithConsumerKey:andWithConsumerSecret:
 */
@property (nonatomic, readonly, strong) NSString * appId;
/**
 * The app version that was used to initialize the Mobage service.
 * @since 1.5
 * @see MBMobage::initializeWithServerEnvironment:andWithAppId:andWithAppVersion:andWithConsumerKey:andWithConsumerSecret:
 */
@property (nonatomic, readonly, strong) NSString * appVersion;

@end


#endif
