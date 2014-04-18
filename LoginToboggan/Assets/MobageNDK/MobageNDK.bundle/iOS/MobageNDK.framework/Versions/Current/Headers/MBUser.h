//
//  MBUser.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#import "MBDataModel.h"
#import "MBDataList.h"

/**
 * @file MBUser.h
 * Model for Mobage user information.
 * @since 1.5
 */

/**
 * Stores properties for a Mobage user.
 * @since 1.5
 */
@protocol MBUser <MBDataModel>

/* + (NSObject<MBUser>*) currentUser; */

+ (void)fetchUserWithUserID:(NSString*) userId callbackQueue:(dispatch_queue_t)cbQueue block:(void (^)(NSError *err, NSObject<MBUser> * user))cb;
+ (void)fetchUserWithNickname:(NSString*) nickname callbackQueue:(dispatch_queue_t)cbQueue block:(void (^)(NSError *err, NSObject<MBUser> * user))cb;

- (BOOL)isEqualToUser:(NSObject<MBUser>*)object;

/**
 * The user's nickname.
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString * nickname; //username
/**
 * The name displayed for the user.
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString * displayName;
/**
 * The URL for the user's thumbnail image.
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString * thumbnailUrl;
/**
 * The profile for the user
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString * aboutMe;

/**
 * Set to <code>YES</code> if the user has used the current app.
 * @since 1.5
 */
@property (nonatomic, readonly, assign) BOOL hasApp;
// legacy field
@property (nonatomic, readonly, assign) BOOL ageRestricted;
/**
 * The user's age.
 * @since 1.5
 */
@property (nonatomic, readonly, assign) NSInteger age;
/**
 * The type of Mobage account. Contains one of the following values:
 * <ul>
 * <li><code>0</code>: Not a Mobage user.</li>
 * <li><code>1</code>: The user has a guest account. <strong>Note</strong>: Some Mobage APIs do not
 * support guest accounts. You can prompt the user to upgrade to a registered account by calling
 * <code>MBAuth::executeUserUpgradeWithCallbackQueue:onComplete:</code>.</li>
 * <li><code>2</code>: The user has a registered account. Users can obtain a registered account by:
 * <ul>
 * <li>Upgrading a guest account.</li>
 * <li>Using the Mobage login dialog to create a new account.</li>
 * <li>Using Facebook Connect to log into Mobage.</li>
 * </ul>
 * </li>
 * <li><code>3</code>: The user has a verified account. This value is reserved for future use.
 * Mobage West does not currently support verified accounts.</li>
 * </ul>
 * For more information about guest accounts, see the
 * <a href="https://developer.mobage.com/en/resources/guest_accounts_native">guest accounts
 * overview</a> on the Mobage Developer Portal.
 * @since 2.2
 */
@property (nonatomic, readonly, assign) NSInteger grade;
/**
 * Indicates whether the user is a celebrity account that is used for promotional purposes, does not
 * represent a real Mobage user, and cannot receive notifications. On Mobage West, this field is
 * always set to <code>NO</code>.
 * @since 2.2
 */
@property (nonatomic, readonly, assign) BOOL isFamous;

@property (nonatomic, readonly, strong) NSObject<MBDataList> * mutualFriends;
@property (nonatomic, readonly, strong) NSObject<MBDataList> * mutualFriendsWithCurrentGame;
@property (nonatomic, readonly, strong) NSObject<MBDataList> * pendingFriendRequests;
@property (nonatomic, readonly, strong) NSObject<MBDataList> * blacklistedUsers;

// In Place Mutation!
- (void)updateFromServerWithCallbackQueue:(dispatch_queue_t)cbQueue block:(void (^)(NSError *err, NSObject<MBUser> * user))block;

// *note* For Internal use. Temporary placing here because of codegen limitation.
// need to move into MB_WW_User+Internal.h.
// currently only motto, firstName, lastName, password, email are supported
- (void) saveWithCallbackQueue:(dispatch_queue_t)cbQueue
                    onComplete:(void (^)(NSObject<MBError> *error, 
                                         NSObject<MBUser> * user))completeCb;

@end

typedef NSObject<MBUser> MBUserProtocol;
