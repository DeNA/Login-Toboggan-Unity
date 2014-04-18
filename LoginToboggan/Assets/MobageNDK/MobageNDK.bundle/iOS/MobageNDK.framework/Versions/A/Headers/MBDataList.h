//
//  MBDataList.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 3/2/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#ifndef mobage_ndk_MBDataList_h
#define mobage_ndk_MBDataList_h

#import "MBInterfaceEnums.h"

@protocol MBError;
@class MBPagingAPIResult;

@protocol MBDataList <NSObject>

/**
 * Fetches your list of items, and then returns them when they're all ready.
 */
- (void) getCount:(NSInteger)count fromOffset:(NSUInteger)offset withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>*error, NSArray * list, NSInteger startOffset, NSInteger totalPossibleResultCount))cb;

#pragma mark - Deprecated
@optional
- (void) getCount:(NSInteger)count fromOffset:(NSUInteger)offset withCallbackQueue:(dispatch_queue_t)cbQueue block:(void (^)(NSError*error, NSArray * list, MBPagingAPIResult *result))cb __attribute__((deprecated));

@end

#endif
