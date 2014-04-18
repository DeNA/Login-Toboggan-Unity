//
//  MB_G_MobageRequest.h
//  mobage-ndk
//
//  Created by Andy Block on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//
#import "MB_G_OAuthConsumerInfo.h"
#import <Foundation/Foundation.h>

#import "MBActiveGameContext.h"
#import "MBError.h"
#import "MBMobage.h"

typedef enum {
	kMBAuthOauth1,
	kMBAuthOauth2,
	kMBAuthNone
} MBAuthenticationType;

typedef enum {
	kMBServerModeProduction,
	kMBServerModeStaging,
	kMBServerModeIntegration,
	kMBServerModeSandbox, // NOTE: Also referred to as 'partner' in the old Plus
	kMBServerModeUnitTests,
	kMBServerModeUnknown
} MB_G_ServerMode;

typedef enum {
	kMBRequestTypeJson,
	kMBRequestTypeFormdata
} MB_G_RequestType;

typedef void (^MB_G_MobageRequestCallbackBlock_t)(MBError *error, id data, NSDictionary *headers, int status);

@class MB_G_OAuth;



@protocol MB_G_OAuthContext <MBActiveGameContext>
@property (nonatomic, readonly, strong) MB_G_OAuthConsumerInfo * oAuthConsumerInfo;
@property (nonatomic, readonly, strong) NSString * oAuth2Token;
@end


@protocol MB_G_NetworkingContext <MBActiveGameContext>

@property (nonatomic, readonly, strong) NSString* socialServer;
@property (nonatomic, readonly, strong) NSString* acceptLanguage;
@property (nonatomic, readonly, strong) NSString* baseLanguage;

@property (nonatomic, readonly, strong) NSObject<MB_G_OAuthContext> *oAuthContext;

@property (nonatomic, readonly, assign) MBServerEnvironment serverEnvironment;
@property (nonatomic, readonly, assign) MBServerStage serverStage;

@property (nonatomic, readonly, assign) BOOL serverModeIsProduction;
@property (nonatomic, readonly, strong) NSDictionary *loginParameters;

@property (nonatomic, readonly, strong) NSString *analyticsSessionId;

@end



@interface MB_G_MobageRequest : NSObject
{
@private
	BOOL secure;
	NSMutableDictionary *HTTPHeaders; // May use arrays as values to indicate multiple instances of a header.
	NSMutableDictionary *postBody;
	NSMutableDictionary *queryString;
	NSMutableDictionary *rawPostHash;
	NSData *rawPostData;
	NSMutableArray *attachments;
	MBAuthenticationType authenticationType;
	MB_G_OAuth *oauth;
}
@property (nonatomic, copy) NSString *APIDomain;
@property (nonatomic, copy) NSString *APIMethod;
@property (nonatomic, copy) NSString *entityTag;
@property (nonatomic, assign) MBAuthenticationType authenticationType;
@property (nonatomic, copy) NSString *HTTPMethod;
@property (nonatomic, copy) NSDictionary *postBody;
@property (nonatomic, copy) NSDictionary *queryString;
@property (nonatomic, strong) NSObject<MB_G_NetworkingContext>* networkingContext;
@property (nonatomic, assign) MB_G_RequestType requestType;

// Constructor when using the default network context

+ (MB_G_MobageRequest*) request;

// Constructor when passing a specific context

+ (MB_G_MobageRequest*) requestWithContext:(NSObject<MB_G_NetworkingContext>*)networkingContext;

+ (MB_G_MobageRequest *)newBankRequestWithContext:(NSObject<MB_G_NetworkingContext>*)networkingContext;
+ (MB_G_MobageRequest *)checkSessionStatusWithContext:(NSObject<MB_G_NetworkingContext>*)networkingContext
                                              queue:(dispatch_queue_t)queue
                                           callback:(MB_G_MobageRequestCallbackBlock_t)block;

+ (MB_G_MobageRequest *)checkSessionStatusSecureWithContext:(NSObject<MB_G_NetworkingContext>*)networkingContext
                                                    queue:(dispatch_queue_t)queue
                                                 callback:(MB_G_MobageRequestCallbackBlock_t)block;

+ (MB_G_MobageRequest *)sendPasswordResetEmailWithAddress:(NSString *)address
											withContext:(NSObject<MB_G_NetworkingContext>*)networkingContext
                                                  queue:(dispatch_queue_t)queue
                                               callback:(MB_G_MobageRequestCallbackBlock_t)block;

- (MB_G_MobageRequest *)initWithContext:(NSObject<MB_G_NetworkingContext>*)networkingContext;


- (void)sendOnQueue:(dispatch_queue_t)callbackQueue
            callback:(MB_G_MobageRequestCallbackBlock_t)block;

- (void)addAttachment:(NSData *)attachment
             withName:(NSString *)name
             filename:(NSString *)filename
          contentType:(NSString *)type;
- (NSString *)getRequestURL;

@end


