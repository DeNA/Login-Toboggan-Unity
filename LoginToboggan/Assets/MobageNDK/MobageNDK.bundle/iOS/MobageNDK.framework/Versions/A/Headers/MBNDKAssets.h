//
//  MBNDKAssets.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/24/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBBundle.h"

@interface MBNDKAssets : NSObject

+ (MBBundle*)regionSpecificBundle;
+ (UIViewController *) viewControllerWithClass:(Class)aClass andNibName:(NSString*)name;
+ (UIImage*)imageNamed:(NSString*)name;
+ (UIImage*)globalImageNamed:(NSString*)name;
@end
