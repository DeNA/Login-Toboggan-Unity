//
//  MBCacheableModel.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/8/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#import "MBDataModel.h"

@protocol MBCacheableModel <MBDataModel>

+ (NSString*)cacheClassName;

/* Recommendation: uid */
@property (atomic, readonly, strong) NSString * cacheId;

@end

#pragma mark MemoryCache
@protocol MBMemoryCacheableModel <MBCacheableModel>
- (id) initWithCacheId:(NSString*)cacheId;
@end

typedef NSObject<MBMemoryCacheableModel> MBMemoryCacheable;

#pragma mark DiskCache
typedef enum {
	kMBCacheableModelCacheStyleUnknown = 0,
	kMBCacheableModelCacheStyleSingleObject,
	kMBCacheableModelCacheStyleList
} MBCacheableModelCacheStyle;


@protocol MBDiskCacheableModel <MBCacheableModel>

//+ (ObjectCacheStyle) cacheStyle;
- (id) initWithCacheId:(NSString*)cacheId cacheControl:(NSString*)cacheControl andDiskRepresentation:(NSData*)cacheRep;

/* Recommendation: etag */
@property (atomic, readonly, strong) NSString * cacheControl;

- (void) renderToCache:(void (^)(NSString* cacheClassName,NSString* cacheId,NSString* cacheControl, NSData* cacheRep))block;
- (NSDictionary*)cacheReference;

- (void)saveToDisk;

@end


typedef NSObject<MBDiskCacheableModel> MBDiskCacheable;
