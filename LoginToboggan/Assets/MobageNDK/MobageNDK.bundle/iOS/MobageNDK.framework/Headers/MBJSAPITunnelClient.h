//
//  MBJSAPITunnelClient.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 5/30/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol MBJSAPITunnelClient <NSObject>

- (void)sendMessage:(NSString*)msg;		// All messages incoming to JS pass through this

// Container that permits JS to register/deregister for NSNotifications from Mobage
@property (nonatomic, readwrite, strong) NSMutableDictionary * notificationObservers;

@optional // Not for NGCore
// UI Controlling API
- (void)presentExperienceNamed:(NSString*)experienceName options:(NSDictionary*)options;
- (void)presentExperienceNamed:(NSString*)experienceName options:(NSDictionary*)options withTabNamed:(NSString*)tabName options:(NSDictionary*)tabOptions;
- (void)presentTabNamed:(NSString*)tabName withOptions:(NSDictionary*)options;
- (void)removeTab;
- (void)popExperience;
- (void)dismissWindow;
- (void)dismissAndReturnArrayToNative:(NSArray*)arr;
- (void)setOpaque:(BOOL)opaque;
- (void)documentLoaded;
- (void)openURL:(NSString*)url;

- (void)presentPageWithKey:(NSString*)key;
// Make sure you call this function only in truly exceptional circumstances, like end-of-life for an NDK version
- (void)quitApplication;
@end
