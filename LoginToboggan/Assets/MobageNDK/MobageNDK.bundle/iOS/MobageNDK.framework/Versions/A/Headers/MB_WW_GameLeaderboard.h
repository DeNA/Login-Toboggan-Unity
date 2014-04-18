//
//  MB_WW_GameLeaderboard.h
//  NGMobageUS
//
//  Created by Chris Toliver on 6/29/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MB_WW_DataModel.h"
#import "MBGameLeaderboard.h"

@protocol MB_WW_GameLeaderboard <MBGameLeaderboard>
@property (nonatomic, readonly, strong) NSString *appId;
@property (nonatomic, readonly, strong) NSString *title;
@property (nonatomic, readonly, strong) NSString *scoreFormat;
@property (nonatomic, readonly, assign) NSInteger scorePrecision;
@property (nonatomic, readonly, strong) NSString *iconUrl;
@property (nonatomic, readonly, assign) BOOL allowLowerScore;
@property (nonatomic, readonly, assign) BOOL reverse;
@property (nonatomic, readonly, assign) BOOL archived;
@property (nonatomic, readonly, assign) double defaultScore;
@property (nonatomic, readonly, strong) NSString *published;
@property (nonatomic, readonly, strong) NSString *updated;
@end


@interface MB_WW_GameLeaderboard : MB_WW_DataModel <MB_WW_GameLeaderboard>
@end

