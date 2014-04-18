//
//  MB_WW_CacheableModel.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 3/6/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef NGMobageUS_MB_WW_CacheableModel_h
#define NGMobageUS_MB_WW_CacheableModel_h

#import "MBCacheableModel.h"

@protocol MB_WW_MemoryCacheableModel <MBMemoryCacheableModel>
+ (id) cachedVersionForUID:(NSString *)uid;
+ (id) cachedVersionForDictionary:(NSDictionary*)dict;

- (NSObject<MB_WW_MemoryCacheableModel>*)staticCopy;

@property (nonatomic, readonly, assign) BOOL isMasterObject;
@property (nonatomic, readwrite, strong) NSObject<MB_WW_MemoryCacheableModel>* masterObject;
- (void)updateFromMasterObject;

@end

@interface NSArray (MB_WW_ModelCopyAdditions)
- (NSArray*)staticCopiedArray;
@end

#endif
