//
//  MB_G_Characteristics+Internal.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/29/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"

/**
 * Reports characteristics of the device and operating system in a consistent way,
 * such that the characteristics used by different  (networking) classes are the same and not slightly different.
 */

@interface MB_G_Characteristics : NSObject 

@property (atomic, readonly, strong) NSString * idForPlatformServer;
@property (atomic, readonly, strong) NSDictionary * idsForAnalytics;
@property (atomic, readonly, strong) NSString * deviceName;
@property (atomic, readonly, strong) NSString * deviceModel;
@property (atomic, readonly, strong) NSString * carrier; //nil if not available
@property (atomic, readonly, strong) NSString * platformOS;
@property (atomic, readonly, strong) NSString * platformOSVersion;
@property (atomic, readonly, strong) NSString * language;
@property (atomic, readonly, strong) NSString * locale;
@property (atomic, readonly, strong) NSString * timezone;

-(id) init;
-(void) getMVIDWithCallback:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSString * mvid))completeCb;
-(NSString*) getMVID;

+(MB_G_Characteristics*) defaultCharacteristics;

@end
