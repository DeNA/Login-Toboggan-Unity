//
//  MB_WW_User.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MB_WW_DataModel.h"
#import "MBUser.h"

@protocol MB_WW_User <MBUser>
// Aliased properties:
@property (nonatomic, readonly, copy) NSString * gamertag; // nickname
@property (nonatomic, readonly, copy) NSString * motto; // aboutMe

// US-only properties
@property (nonatomic, readonly, copy) NSString * firstName; //Can't be atomic, because they generate displayName (custom handling)
@property (nonatomic, readonly, copy) NSString * lastName;

@property (atomic, readonly, copy)   NSString * relation; //friends/buddies/followers
@property (atomic, readonly, copy)   NSString * gender;
@property (atomic, readonly, copy)   NSString * phoneNumber;

@property (atomic, readonly, assign) NSInteger unreadWallPostCount;
@property (atomic, readonly, assign) NSInteger gamerScore;
@property (atomic, readonly, assign) NSInteger levelNumber;
@property (atomic, readonly, copy)   NSString* levelName;
@property (atomic, readonly, assign) NSInteger currentLevelScore;
@property (atomic, readonly, assign) NSInteger nextLevelScore;

@property (atomic, readonly, assign) NSInteger sessionCount;
@property (atomic, readonly, assign) BOOL isNuxComplete;

@property (atomic, readonly, assign) BOOL isMobageUser;
@property (atomic, readonly, assign) BOOL isGameHubUser;
@property (atomic, readonly, assign) BOOL isNewBuddy;
@property (atomic, readonly, assign) BOOL isMutualFriend;

@property (atomic, readonly, assign) BOOL privacyFlag;
@property (atomic, readonly, assign) BOOL mailOptInFlag;
@property (atomic, readonly, assign) BOOL hidePresenceFlag;
@property (atomic, readonly, assign) BOOL ignoreFriendRequestsFlag;
@property (atomic, readonly, assign) BOOL onlyShowFriendNotifications;
@property (atomic, readonly, assign) BOOL filterWallPostsToFriendsOnly;

@end


// TODO: describe SocialAccounts, Capabilities etc.
@interface MB_WW_User : MB_WW_DataModel <MB_WW_User>

@end
