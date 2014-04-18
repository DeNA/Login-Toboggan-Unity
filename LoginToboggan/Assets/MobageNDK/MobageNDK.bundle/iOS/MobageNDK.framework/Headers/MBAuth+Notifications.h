//
//  MBAuth+Notifications.h
//
//  Created by Frederic Barthelemy on 2012-12-01.
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//

#import <Foundation/Foundation.h>

#import "MBAuth.h"
#import "MBNotification.h"


@interface MBUserSessionReestablishedNotification : MBNotification
@end
@interface MBUserLoginNotification : MBNotification
@end
@interface MBUserLogoutNotification : MBNotification
@end
@interface MBUserGradeUpgradeNotification : MBNotification
/**
 * @description The user's previous nickname.
 * @type NSString * 
 */
@property (nonatomic, readwrite, strong) NSString *  previousNickname;
/**
 * @description The previous type of the user's Mobage account. Contains one of the following values: <ul><li><c>0</c>: Not logged into Mobage.</li><li><c>1</c>: Guest account.</li><li><c>2</c>: Registered account.</li><li><c>3</c>: Verified account. Reserved for future use.</li></ul>
 * @type NSInteger
 */
@property (nonatomic, readwrite, assign) NSInteger previousGrade;
/**
 * @description The user's current nickname.
 * @type NSString * 
 */
@property (nonatomic, readwrite, strong) NSString *  currentNickname;
/**
 * @description The current type of the user's Mobage account. Contains one of the following values: <ul><li><c>0</c>: Not logged into Mobage.</li><li><c>1</c>: Guest account.</li><li><c>2</c>: Registered account.</li><li><c>3</c>: Verified account. Reserved for future use.</li></ul>
 * @type NSInteger
 */
@property (nonatomic, readwrite, assign) NSInteger currentGrade;
@end
