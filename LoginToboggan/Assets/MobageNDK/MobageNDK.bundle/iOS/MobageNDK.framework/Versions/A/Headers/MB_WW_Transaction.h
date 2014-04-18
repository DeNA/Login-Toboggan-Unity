//
//  MB_WW_Transation.h
//  NGMobageUS
//
//  Created by Kinkoi Lo on 5/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBTransaction.h"
#import "MB_WW_DataModel.h"

@protocol MB_WW_Transaction <MBTransaction>

@end

@interface MB_WW_Transaction : MB_WW_DataModel <MB_WW_Transaction>

@end
