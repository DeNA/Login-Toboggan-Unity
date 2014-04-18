//
//  MBAnalytics.h
//  mobage-ndk
//
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"

@protocol MBAnalytics <NSObject>

+ (void) reportEvent:(NSString*) eventString;
+ (void) reportGameEventWithId:(NSString*)eventId payload:(NSString*)payload playerState:(NSString*)playerState;
+ (void) reportErrorEvent:(NSString*)error;
+ (void) getPlatformDynamicConfigurationWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSDictionary *configuration))onComplete;
+ (void) getUserSpecificDynamicConfigurationWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSDictionary *configuration))onComplete;

/** Private **/
+ (void) cachedPlatformDynamicConfigurationWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSDictionary *configuration))onComplete;

@end

