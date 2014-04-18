//
//  MB_WW_MobageWeb+Internal.h
//  NGMobageUS
//
//  Created by Chris Toliver on 8/12/13.
//  Copyright (c) 2013 ngmoco:). All rights reserved.
//

#import "MB_WW_MobageWeb.h"

#define MB_WEB_CONTENTS_TIME_OUT 15

#define MB_WEB_INACTIVITY_TIME_OUT 30

@class MB_WW_MobageWebView;

@interface MB_WW_MobageWeb ()

@property (nonatomic, retain) NSTimer *webContentsTimer;
@property (nonatomic, retain) NSTimer *webInactivityTimer;

@property (nonatomic, copy) void(^closeCallback)(MBDismissableAPIStatus, NSObject<MBError>*, NSDictionary*);

// This showing property nonatomic, it must only be accessed from the main thread. No atomic
// properties or synchronized should be used with in conjunction with this class since
// that could lead to blocking of the main thread.

@property (nonatomic, assign) BOOL showing;

// When this property is set to TRUE, ignore device orientation change notifications.
// This is useful in the case where a modal dialog that might force a Portrait
// orientation is shown over a webview but we do not want the webview to resize.

@property (nonatomic, assign) BOOL ignoreOrientationChanges;

// This MB_WW_MobageWeb object contains a view kind of like a view controller.
// This MB_WW_MobageWebView is a subclass of UIView.

@property (nonatomic, retain) MB_WW_MobageWebView *view;

+(MB_WW_MobageWeb*)sharedInstance;
+(NSString*)urlEncode:(NSString*)obj;
+(NSString*)urlEncodedStringFromDictionary:(NSDictionary*)dict;
+(NSString*)urlDecode:(NSString*)str;

-(void)initHostsWith:(NSString**)sandboxPrefix dotSandboxPrefix:(NSString**)dotSandboxPrefix stagePrefix:(NSString**)stagePrefix;
-(NSString*)apiHost;
-(NSString*)webViewHost;

-(void)closeWithError:(NSError*)error;
-(void)closeWebview:(NSMutableDictionary*)params;

-(void)startWebContentsTimer;
-(void)stopWebContentsTimer;

- (void) startIgnoreOrientationChanges;
- (void) stopIgnoreOrientationChanges;

@end
