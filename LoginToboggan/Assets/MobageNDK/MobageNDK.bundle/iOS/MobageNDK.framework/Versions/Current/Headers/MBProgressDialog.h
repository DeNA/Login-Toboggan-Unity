//
//  MBProgressDialog.h
//  NGMobageUS
//
//  Created by rcuser on 3/26/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <UIKit/UIKit.h>

@interface MBProgressDialog : UIAlertView<UIAlertViewDelegate>
@property (nonatomic, strong) UIButton * closeButton;
@property (nonatomic) BOOL showCloseButton;
@property (nonatomic) float closeTimer;
@property (strong) NSTimer* timer;
-(id)initWithTitle:(NSString *)title message:(NSString *)message autoDismissDialog:(BOOL) isAutoDismissDialog timeIntervalToDisplay:(NSTimeInterval) seconds;
-(id)initWithTitle:(NSString*)title message:(NSString*)message showCloseButton:(BOOL)showCloseButton;
-(id)initWithTitle:(NSString*)title message:(NSString*)message;
-(void)hide;
-(void)show;
-(void)timerDisplayCloseButton;
-(void)closeBtnPressed;
@end
