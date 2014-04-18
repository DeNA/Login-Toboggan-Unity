//
//  MBRemoteNotificationPayload.h
//  mobage-ndk
//
//  Created by Toliver Chris on 7/23/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBDataModel.h"

/**
 * @file MBRemoteNotificationPayload.h
 * Model for information about the content of a remote notification.
 * @since 2.0
 */

/**
 * Content of a remote notification. The maximum size of the payload is 256 bytes.
 * <p>
 * The payload can include app-specific key/value pairs that trigger a special behavior in your app,
 * such as displaying a message to the user on launch. These key/value pairs are stored in the
 * <code>extraKeys</code> and <code>extraValues</code> properties.
 * <p>
 * <strong>Note</strong>: Some properties are used only on Android or iOS, but not both. The Mobage
 * server automatically discards any parameters that are not supported by the target user's device.
 * Discarded parameters do not count towards the 256-byte limit.
 * @since 2.0
 */
@protocol MBRemoteNotificationPayload <MBDataModel>

/**
 * The numeric badge to display on the app's icon. Used only on iOS.
 * @since 2.0
 */
@property (atomic, readwrite, assign) NSInteger badge;

/**
 * The notification message.
 * @since 2.0
 */
@property (atomic, readwrite, strong) NSString *message;

/**
 * The alert sound to play. This property must contain the name of a sound file in the application
 * bundle, or <code>default</code> to play the default alert sound. The sound file must be in a
 * format that is supported for system sounds. Used only on iOS.
 * @since 2.0
 */
@property (atomic, readwrite, strong) NSString *sound;

/**
 * An identifier that causes newer notifications with the same identifier to be discarded. For
 * example, if a user receives four notifications with the same identifier, only the newest
 * notification will be displayed on the user's device. Used only on Android.
 * @since 2.0
 */
@property (atomic, readwrite, strong) NSString *collapseKey;

/**
 * The layout style for the notification in the device's notification tray. Set to
 * <code>normal</code> to display a standard-size icon or <code>largeIcon</code> to display a large
 * icon. Used only on Android.
 * @since 2.0
 */
@property (atomic, readwrite, strong) NSString *style;

/**
 * The URL for the icon to display in the device's notification bar. This value is ignored unless
 * you also use the <code>style</code> property to specify the layout style. Used only on Android.
 * @since 2.0
 */
@property (atomic, readwrite, strong) NSString *iconUrl;

/**
 * The app-specific keys to include in the payload. Each key must be represented as an
 * <code>NSString</code>. The following key names are reserved and cannot be used:
 * <ul>
 * <li><code>badge</code></li>
 * <li><code>collapseKey</code></li>
 * <li><code>extras</code></li>
 * <li><code>iconUrl</code></li>
 * <li><code>message</code></li>
 * <li><code>sound</code></li>
 * <li><code>style</code></li>
 * </ul>
 * @since 2.0
 */
@property (atomic, readwrite, strong) NSArray *extraKeys;

/**
 * The app-specific values to include in the payload. Each value must be represented as an
 * <code>NSString</code>.
 * @since 2.0
 */
@property (atomic, readwrite, strong) NSArray *extraValues;
@end
