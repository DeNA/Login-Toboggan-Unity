//
//  MBNotification.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 12/1/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBModelSerialization.h"

/**
 * @file MBNotification.h
 * Interface for Mobage notifications.
 * <p>
 * MBNotification is a subclass of <code>NSNotification.</code> The <code>NSNotification</code>
 * class is an iOS class that  encapsulates data broadcast to other objects. For more
 * information about <code>NSNotification</code>, see
 * <a href="https://developer.apple.com/library/mac/#documentation/Cocoa/Reference/Foundation/Classes/NSNotification_Class/Reference/Reference.html">NSNotification Class Reference</a>
 * <p>
 * You can register to receive MBNotification events using the following
 * <code>NSNotificationCenter</code> methods:
 * <ul>
 *    <li><code>– addObserverForName:object:queue:usingBlock:</code></li>
 *    <li><code>– addObserver:selector:name:object:</code></li>
 * </ul>
 * The <code>NSNotificationCenter</code> class forwards notifications to registered observers.
 * Every iOS application has an instance of <code>NSNotificationCenter</code>. For more
 * information about <code>NSNotificationCenter</code>, see
 * <a href="https://developer.apple.com/library/mac/#documentation/Cocoa/Reference/Foundation/Classes/NSNotificationCenter_Class/Reference/Reference.html">NSNotification Center Class Reference</a>
 * <p>
 * You can register to receive the following Mobage notifications:
 * <ul>
 *    <li>MBUserSessionReestablishedNotification</li>
 *    <li>MBUserLoginNotification</li>
 *    <li>MBUserLogoutNotification</li>
 *    <li>MBUserGradeUpgradeNotification</li>
 *    <li>MBMobageUIVisibleNotification</li>
 *    <li>MBBalanceUpdateNotification</li>
 * </ul>
 * <strong>Sample Code</strong>
 * <p>
 * The following code snippet shows how to listen for a <code>MBMobageUIVisibleNotification</code>
 * notification:
 * \code
 * - (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
 * {
 *    //...
 *    // Get a pointer to NSNotificationCenter.
 *    NSNotificationCenter *nc = [NSNotificationCenter defaultCenter];
 *    // Add this object as an observer and specify the selector to run when
 *    // MBMobageUIVisibleNotification fires.
 *    [nc addObserver:self
 *       selector:@selector(onMBMobageUIVisibleNotification:)
 *       name:@"MBMobageUIVisibleNotification"
 *       object:nil];
 *    //...
 * }
 *
 * // The notification selector. This is the method that is run when the notification is received.
 * - (void) onMBMobageUIVisibleNotification:(NSNotification*)notification
 * {
 *    // Cast notification to MBMobageUIVisibleNotification.
 *    MBMobageUIVisibleNotification *visibleNotification = (MBMobageUIVisibleNotification*)notification;
 *    NSLog(@"MBMobageUIVisibleNotification notification received");
 *    //...
 * }
 * \endcode
 * @since 2.2
 */

/**
 * Interface for Mobage notifications.
 * @since 2.2
 */
@interface MBNotification : NSNotification <MBSerializableModel, MBSerializableItem>
+ (instancetype)notification;	// All of Mobage Notifications use this factory!
+ (instancetype)notificationFromDictionary:(NSDictionary*)context; //

+ (void)postEmptyNotification;	// Convenience for notifications that have no payloads (All subclasses override this to send the right type)
- (void)post;					// Convenience to quickly post a notification.
@end

#define MBNotificationPackingImplementations(notificationName)\
- (NSDictionary*)packForEnvironment:(MBModelSerializationEnvironment)env {\
	NSMutableDictionary* output = [NSMutableDictionary dictionary];\
	NSDictionary * source = notificationName ## _aliases.toDisk;	\
	for (BOOL (^packer)(id obj, NSMutableDictionary* output) in [source allValues]) {\
		packer(self,output);\
	}\
	\
	return output;\
}\
+ (MBModelUnpackerBlock) unpackerForKey:(NSString*)key {\
	return ((MBModelUnpackerBlock)notificationName ## _aliases.toModel[key]);\
}

/*
 * Serves to help provide storage for C and JS API observers of notifications
 *	- Automatically observes on instantiation
 *	- Automatically stops observing on destruction
 */
@interface MBNotificationObserverHelper : NSObject
@property (nonatomic, readwrite, strong) NSString * shortName;
@property (nonatomic, readwrite, assign) void * context;		// CAPI context
@property (nonatomic, readwrite, strong) NSString * identifier;	// JSAPI identifier
@property (nonatomic, readwrite, copy) void (^onNotificationBlock)(MBNotification* note);


+ (instancetype)observerForNotificationShortName:(NSString*)notificationName
										 context:(void*)context
							 onNotificationBlock:(void (^)(MBNotification* note))block;
+ (instancetype)observerForNotificationShortName:(NSString*)notificationName
									  identifier:(NSString*)identifier
							 onNotificationBlock:(void (^)(MBNotification* note))block;
@end
