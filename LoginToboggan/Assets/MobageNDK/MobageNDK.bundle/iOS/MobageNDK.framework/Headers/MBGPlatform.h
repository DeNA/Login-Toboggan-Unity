/**
 * Mobage Social Platform APIs
 */

#import <Foundation/Foundation.h>
#import "MBGError.h"
#import "MBGSocialPeople.h"
#import "MBGSocialAppdata.h"
#import "MBGSocialBlacklist.h"
#import "MBGSocialProfanity.h"
#import "MBGSocialAuth.h"

/*!
 * @abstract Region Type
 */
enum MBG_REGION {
	MBG_REGION_US, //unsupported for now
	MBG_REGION_JP,  
	MBG_REGION_CN //unsupported for now
};

/*!
 * @abstract Server Type
 */
enum MBG_SERVER_TYPE {
	MBG_SANDBOX,
	MBG_PRODUCTION,
	INTEGRATION = 2,
	INTEGRATION_STABLE = 3
};

# pragma mark -

/*!
 * @abstract Delegate interface for Login, notifying completion of showing Mobage's splash screen 
 */
@protocol MBGPlatformDelegate <NSObject>
/*! */
-(void) onLoginComplete:(NSString *)userId;
/*! */
-(void) onLoginRequired;
/*! */
-(void) onLoginError:(MBGError *)error;
/*! */
-(void) onSplashComplete;
@end

# pragma mark -

/*!
 * @abstract Main class for controlling the mobage SDK. Includes:
 * <br /> - Application activity control
 * <br /> - Login 
 * <br /> - Splash screen control 
 * <br /> - Tick(asynchronous operation handle) control 
 */
@interface MBGPlatform: NSObject
{
	id<MBGPlatformDelegate> _delegate;
}
@property(nonatomic, strong) id<MBGPlatformDelegate> delegate;

/*!
 * @abstract gets an instance of this singleton
 */
+ (id) sharedPlatform;

/*!
 * @abstract initializes the mobage platform sdk
 */
+ (void) initialize:(NSInteger)region
		 serverType:(NSInteger)server
		 cosumerKey:(NSString *)key
	  cosumerSecret:(NSString *)secret
			  appId:(NSString *)appId;

/*!
 * @abstract tick method to handle async operation.
 */
+ (void) tick;

/*!
 * @abstract register tick method with timer
 */
+ (void) registerTick;

/*!
 * @abstract returns version of SDK
 */
+ (NSString *) getSDKVersion;

/*!
 * @abstract notify mobage sdk that application will be paused. this method should be called in applicationWillResignActive 
 */
+(void)pause;

/*!
 * @abstract notify mobage sdk that application has been resumed. this method should be called in applicationDidBecomeActive
 */
+(void)resume;

/*!
 * @abstract notify mobage sdk that application will be stopped. this method should be called in applicationWillTerminate
 */
+(void)stop;

/*!
 * @abstract Asks the delegate to open a resource identified by URL.
 */
+ (BOOL)handleOpenURL:(NSURL *)url;

/*!
 * @abstract hides Mobage's splash screen 
 */
- (void) hideSplashScreen;

/*!
 * @abstract checks login status
 */
- (void) checkLoginStatus;

/*!
 * @abstract shows login dialog
 */
- (void) showLoginDialog;

/*!
 * @abstract shows logout dialog
 */
+ (void) showLogoutDialog:( void (^)( ) )successCB 
				 onCancel:( void (^)( ) )cancelCB;


@end
