//
//  MB_WW_SocialService.h
//  NGMobageUS
//
//  Created by Henrik Johansson on 3/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBSocialService.h"
#import "MBSocialService+Internal.h"

@protocol MB_WW_SocialService <MBSocialService, MBSocialServiceInternal>

+ (void)showToast:(NSString*)displayText;
+ (void)openBankDialog;
+ (void)openCurrentUserProfile;

+ (void)openOtherUserProfileWithUser:(NSObject<MBUser> *)user;

+ (void)openOtherUserSettingsWithUser:(NSObject<MBUser> *)user; //DEPRECATED BECAUSE SENSELESS
@end

@interface MB_WW_SocialService : NSObject <MB_WW_SocialService>

/**
 * @abstract Open the Player Inviter, which enables the user to invite friends via viral channels.
 * @discussion Open the Player Inviter
 * @since 2.0
 */
+ (void)openOSViralChannel;

@end

extern NSString *const kMB_G_BalanceBtnUpdatedNotification;
