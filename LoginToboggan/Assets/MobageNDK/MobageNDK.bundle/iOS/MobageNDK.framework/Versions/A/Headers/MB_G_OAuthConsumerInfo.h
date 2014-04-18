//
//  MB_G_OAuthConsumerInfo.h
//  mobage-ndk
//
//  Created by Andy Block on 2/23/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

@interface MB_G_OAuthConsumerInfo : NSObject {
	NSString *token, *tokenSecret, *consumerKey, *consumerSecret;
}
@property (nonatomic, strong) NSString *token;
@property (nonatomic, strong) NSString *tokenSecret;
@property (nonatomic, strong) NSString *consumerKey;
@property (nonatomic, strong) NSString *consumerSecret;
- initWithToken:(NSString *)token andTokenSecret:(NSString *)tokenSecret andConsumerKey:(NSString *)consumerKey andConsumerSecret:(NSString *)consumerSecret;
@end
