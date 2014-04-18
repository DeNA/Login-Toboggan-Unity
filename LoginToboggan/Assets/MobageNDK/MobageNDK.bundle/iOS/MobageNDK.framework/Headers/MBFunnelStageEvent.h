//
//  MBFunnelStageEvent+internal.h
//  mobage-ndk
//
//  Created by Jan-Eric Duden on 2/28/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBFunnelEvent.h"

/**
 * \internal
 * 
 */
@interface MBFunnelStageEvent : MBFunnelEvent

- (id) initWithName: (NSString*) funnelName funnelStage: (NSString*) funnelStage stageName: (NSString*) stageName playerState:(NSDictionary*) playerState;

@end
