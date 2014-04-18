//
//  MBMobage+Notifications.h
//
//  Created by Frederic Barthelemy on 2012-12-01.
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//

#import <Foundation/Foundation.h>

#import "MBMobage.h"
#import "MBNotification.h"


@interface MBMobageUIVisibleNotification : MBNotification
/**
 * @description Set to <c>true</c> if a Mobage UI component is visible or <c>false</c> if the component was hidden.
 * @type BOOL
 */
@property (nonatomic, readwrite, assign) BOOL visible;
@end
