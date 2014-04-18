//
//  MB_WW_MobageWeb.h
//  NGMobageUS
//
//  Created by Chris Toliver on 8/12/13.
//  Copyright (c) 2013 ngmoco:). All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"

#define MB_WW_2_5 (1)

@interface MB_WW_MobageWeb : NSObject

+(NSString*)LOGIN_ACTION;
+(NSString*)LOGOUT_ACTION; // logout
+(NSString*)USER_UPGRADE_ACTION; //userUpgrade
+(NSString*)BANK_ACTION; //bank
+(NSString*)BANK_PURCHASE_ACTION; //purchase
+(NSString*)DEBIT_ACTION; //debit
+(NSString*)PROFILE_ACTION; //profile
+(NSString*)COMMUNITY_ACTION; //community
+(NSString*)PROMOTION_ACTION; // Promotion
+(NSString*)CHECK_FACEBOOK_ACTION; // checkFacebook

+(void)openMobageWeb:(NSString *)action
       withParameter:(NSDictionary*)parameters
   withCloseCallback:(void (^)(MBDismissableAPIStatus status, NSObject<MBError> *error, NSDictionary *result))closeCallback;


@end
