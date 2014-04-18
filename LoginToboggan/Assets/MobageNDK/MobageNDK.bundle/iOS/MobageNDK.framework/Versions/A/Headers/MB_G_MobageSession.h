//
//  MB_G_MobageSession.h
//  mobage-ndk
//
//  Created by Andy Block on 2/21/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MB_G_MobageRequest.h"
#import "MBUser.h"
#import "MBActiveGameContext.h"
#import "MB_G_Characteristics+Internal.h"
#import "MBMobage.h" 

@class MB_G_MobageSession;
@class MB_G_Cache;

@protocol MB_G_SessionAnalytics
- (NSString *)sessionId;
@end

@protocol MB_G_SessionEstablishmentInfo <NSObject, MBActiveGameContext> 

@property (atomic, readonly, assign) MBServerStage serverStage;
@property (atomic, readonly, assign) MBServerEnvironment serverEnvironment;
@property (atomic, readonly, strong) NSString * consumerKey;
@property (atomic, readonly, strong) NSString * consumerSecret;

@end
@interface MB_G_SessionEstablishmentInfo : NSObject<MB_G_SessionEstablishmentInfo>

- (MB_G_SessionEstablishmentInfo*) initWithEnvironment:(MBServerEnvironment) serverEnvironment
                                 andServerStage:(MBServerStage)serverStage
									   andAppId:(NSString *)theAppId
								  andAppVersion:(NSString *)theAppVersion
								 andConsumerKey:(NSString *)theConsumerKey
							  andConsumerSecret:(NSString *)theConsumerSecret;
@end

@protocol MB_G_MobageSession <NSObject>

+ (NSObject<MB_G_MobageSession>*)currentSession;
- (void)endSession;

@property (nonatomic, readonly, strong) MBUserProtocol *user;
@property (nonatomic, readonly, strong) NSObject<MB_G_NetworkingContext> *networkingContext;

@end

@interface MB_G_MobageSession : NSObject<MB_G_MobageSession> 
{
	// These are all provided by the client in order to establish a session.
	NSObject<MB_G_SessionEstablishmentInfo> *establishmentInfo;
	MB_G_Characteristics *characteristics;
}


// MB_G_NetworkingContext
- (NSString *)socialServer;
- (NSString *)acceptLanguage;
- (NSString *)baseLanguage;
- (NSObject<MB_G_OAuthContext> *)oAuthContext;
- (MBServerStage)serverStage;
- (BOOL)serverModeIsProduction;
- (NSMutableDictionary *)loginParameters;
- (NSString *)analyticsSessionId;
- (NSString *)oAuthToken;

// MB_G_OauthContext
@property (nonatomic, readonly, strong) MB_G_OAuthConsumerInfo * oAuthConsumerInfo;
@property (nonatomic, readonly, strong) NSString * oAuth2Token;
@property (nonatomic, readonly, strong) NSString * userID;

@end

typedef MB_G_MobageSession MBMobageSession;
