//
//  MBJSAPITunnel.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 5/30/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#import "MBJSAPITunnelClient.h"

@interface MBJSAPITunnel : NSObject

+ (void)forTunnelClient:(NSObject<MBJSAPITunnelClient>*)client dispatchMessagesFromString:(NSString*)messagesJSON;

@end
