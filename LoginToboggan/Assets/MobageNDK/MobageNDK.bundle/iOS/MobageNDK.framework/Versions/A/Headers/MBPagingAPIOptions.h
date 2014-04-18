//
//  MBPagingAPIOptions.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/14/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * @file MBPagingAPIOptions.h
 * Pagination options for a search.
 * @since 1.5
 */

/**
 * Stores pagination options to control the number of results that are retrieved and the
 * start index for the search results.
 * @since 1.5
 */
@interface MBPagingAPIOptions : NSObject

/**
 * The number of results to retrieve. The default value is <code>50</code>.
 * @since 1.5
 */
@property (nonatomic, assign)NSInteger count;
/**
 * The start index for the search results. The default value is <code>1</code>.
 * <strong>Important</strong>: The index's numbering begins at <code>1</code>, <em>not</em>
 * <code>0</code>.
 * @since 1.5
 */
@property (nonatomic, assign)NSInteger start;

/**
 * Create a set of pagination options, specifying the number of results to retrieve and
 * the start index for the search results.
 * @param count The number of results to retrieve. The default value is <code>50</code>.
 * @param start The start index for the search results. The default value is <code>1</code>.
 * <strong>Important</strong>: The index's numbering begins at <code>1</code>, <em>not</em>
 * <code>0</code>.
 * @since 1.5
 */
- (id)initWithCount:(NSInteger)count andStart:(NSInteger)start;

@end
