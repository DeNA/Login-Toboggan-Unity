//
//  MBBalanceButton.h
//  mobage-ndk
//
//  Created by Toliver Chris on 2013/09/02.
//  Copyright (c) 2013年 ngmoco:). All rights reserved.
//
#import <UIKit/UIKit.h>

/**
 * @file MBBalanceButton.h
 * The Balance Button for the Mobage Bank.
 * @since 1.5
 */

/**
 * The Balance Button for the Mobage Bank, which displays the user's current
 * balance of the app-specific purchased currency and opens the Bank when
 * tapped.
 * Call <code>MBSocialService::getBalanceButton:withCallbackQueue:onComplete:</code>
 * to retrieve the Balance Button.
 */
@interface MBBalanceButton : UIButton

/**
 * Update the Balance Button to show the user's current balance.
 * @since 1.5
 */
-(void)update;
@end
