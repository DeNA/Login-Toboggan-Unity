//
//  MB_WW_DataModel.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#import "MBDataModel.h"
#import "MBModelSerialization.h"
#import "MB_WW_CacheableModel.h"

@interface MB_WW_DataModel : NSObject <MBDataModel, MB_WW_MemoryCacheableModel, MBDiskCacheableModel, MBSerializableModel>
- (id) initWithCacheId:(NSString*)cacheId cacheControl:(NSString*)cacheControl andDiskRepresentation:(NSData*)cacheRep;
- (BOOL) updateWithDictionary:(NSDictionary*)dict;
- (BOOL) updateWithJSONData:(NSData*)cacheRep;

@property (atomic, readwrite, strong) NSString * cacheControl;

@end

#define kMB_WW_DataModelUIDKey @"uid"
#define kMB_WW_DataModelIDKey @"id"
#define kMB_WW_DataModelRecordIdKey @"recordId"
#define kMB_WW_DataModelUserIdKey @"user_id"

#define MB_WW_AliasProperty(type, lowName, CapsName, aliasProperty)\
@dynamic lowName;\
- (type)lowName \
{ \
	return self.aliasProperty;\
}\
- (void)set ## CapsName:(type)value\
{\
	self.aliasProperty = value;\
}
