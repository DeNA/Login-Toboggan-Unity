//
//  MB_WW_Appdata.h
//  NGMobageUS
//
//  Created by Henrik Johansson on 2/24/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MB_WW_DataModel.h"
#import "MBAppdata.h"
#import "MB_WW_User.h"

@protocol MB_WW_Appdata <MBAppdata, MBDataModel>

@property (nonatomic, readwrite, strong) NSString *ownerId;

@end



@interface MB_WW_Appdata : MB_WW_DataModel <MB_WW_Appdata>

@end
