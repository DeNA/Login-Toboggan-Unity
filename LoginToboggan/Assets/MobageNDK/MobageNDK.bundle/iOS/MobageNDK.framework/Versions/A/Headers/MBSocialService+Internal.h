//
//  MBSocialService+Internal.h
//  mobage-ndk
//
//  Created by ngmoco on 3/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"

@protocol MBSocialServiceInternal <MBSocialService>

// NATIVESDK-6257 : These APIs are used for ngCore integration. 
+ (void) openUserFinder;

@end
