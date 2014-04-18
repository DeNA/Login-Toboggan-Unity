//
//  MBBundle.h Originally: NGPlatformBundle
//  NGPlatform
//
//  Created by James Yopp on 2010/09/01.
//  Created by Frederic Barthelemy on 2/24/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreGraphics/CoreGraphics.h>
#import <UIKit/UIKit.h>

@interface MBBundle : NSBundle
{
	CGFloat rasterScale;
}
@property (nonatomic, readonly, strong) NSString * bundleLanguage;

- (NSString*)pathForImageResource:(NSString *)name ofType:(NSString *)ext;
- (NSURL*)URLForImageResource:(NSString *)name withExtension:(NSString *)ext;
- (UIImage*)bundledImageForPath:(NSString *)path ofType:(NSString *)extension;

@end
