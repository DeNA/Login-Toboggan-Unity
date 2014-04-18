//
//  NGDataModel.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/8/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * @file MBDataModel.h
 * Base model for information about an item.
 * @since 1.5
 */

/**
 * Stores properties for an item.
 * @since 1.5
 */
@protocol MBDataModel <NSObject, NSCopying>
- (BOOL)isEqualToModelInstance:(NSObject<MBDataModel>*)obj;

- (id)initWithDictionary:(NSDictionary*)dict;
/**
 * The unique ID of the item.
 * @since 1.5
 */
// This is "uid" not "id" because "id" is a reserved pointer type in Objective-C
@property (nonatomic, readonly, strong) NSString * uid;

@end

