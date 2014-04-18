//
//  MBLeaderboardTopScore.h
//  mobage-ndk
//
//  Created by Chris Toliver on 6/13/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//


#import <Foundation/Foundation.h>
#import "MBDataModel.h"

/**
 * Model for information about a high score on a leaderboard.
 * @since 2.0
 */
@protocol MBScore <MBDataModel>
/**
 * The Mobage user ID associated with the score.
 * @since 2.0
 */
@property (atomic, readonly, strong) NSString *userId;

/**
 * The value of the score.
 * @since 2.0
 */
@property (atomic, readonly, assign) double scoreValue;

/**
 * A version of the score that has been formatted for display, based on the leaderboard's settings.
 * @since 2.0
 */
@property (atomic, readonly, strong) NSString *displayValue;

/**
 * The score's rank within the leaderboard.
 * @since 2.0
 */
@property (atomic, readonly, assign) NSInteger rank;
@end

