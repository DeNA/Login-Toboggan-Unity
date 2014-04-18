//
//  NGUIKitUtils.h
//  NGPlatform
//
//  Created by James Yopp on 2010/02/09.
//  Copyright 2010 ngmoco :). All rights reserved.
//

#import <UIKit/UIKit.h>

#ifdef __cplusplus
extern "C" {
#endif
	
extern BOOL NGConsoleLoggingEnabled;

// Requires nil termination
void NGReleaseIDList_internal(__unsafe_unretained id* firstOutlet, ... );
// Cleaner than requiring nil be typed every time?  Certainly less error-prone.
#define releaseOutlets(args...) NGReleaseIDList_internal(args, nil);
#define releaseIVars(args...) NGReleaseIDList_internal(args, nil);

void NGNotifyOnMainThread(NSString *name, id object);
void NGNotifyOnMainThreadWithInfo(NSString *name, id object, NSDictionary *userInfo);

BOOL defocusFieldsInView(UIView *view);

void setDurationAndCurveFromKeyboardDictionary(NSDictionary* info);
// When UIDevice+Runtime is included, no checks are necessary.
#define NGGetUserInterfaceIdiom() [[UIDevice currentDevice] userInterfaceIdiom]
//This creates a integer that packs all the version pieces into bytes allowing inequality comparison testing on the OS Version.
NSUInteger comparableSystemVersion(void);

CGFloat defaultRowHeightForScreen(UIScreen *screen);
CGFloat adjustedFontSizeForScreen(UIScreen *screen, CGFloat baseSize);
void NGPlatformLocalizeView(UIView *v);

NSString* NSStringFromInterfaceOrientation(UIInterfaceOrientation o);
UIInterfaceOrientation UIInterfaceOrientationFromString(NSString *s);

BOOL setApplicationStatusBarHidden(BOOL hide, BOOL animate);	// Returns whether the status bar was already hidden.

NSDate * NGDateByRemovingTime(NSDate * aDate);

CGRect CGRectCounteractingTransform(CGRect frame, CGAffineTransform viewTransform);

#ifdef __cplusplus
}
#endif
