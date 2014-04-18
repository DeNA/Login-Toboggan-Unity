//
//  MBPagingAPIResult.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/14/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBModelSerialization.h"

/**
 * @file MBPagingAPIResult.h
 * Information about how search results were paginated.
 * @since 1.5
 */

/**
 * Stores information about how search results were paginated.
 * @since 1.5
 */
@interface MBPagingAPIResult : NSObject<MBSerializableItem>

/**
 * The starting index for this group of items within the entire list.
 * <strong>Important</strong>: The index's numbering begins at <code>1</code>, <em>not</em>
 * <code>0</code>.
 * @since 1.5
 */
@property (nonatomic, assign) NSInteger start;
/**
 * The number of search results that were returned.
 * @since 1.5
 */
@property (nonatomic, assign) NSInteger count;
/**
 * The total number of items that can be retrieved.
 * @since 1.5
 */
@property (nonatomic, assign) NSInteger total;

- (id)initWithStart:(NSInteger)theStartIndex andCount:(NSInteger)theCount andTotal:(NSInteger)theTotal;

@end
