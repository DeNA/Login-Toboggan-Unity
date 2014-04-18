//
//  NSObjectDebugReferenceCounting.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 7/26/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#define DebugType(type)\
@interface type ## DebugReferenceCounting : type\
@end

DebugType(NSObject)
DebugType(NSError)

#undef DebugType
