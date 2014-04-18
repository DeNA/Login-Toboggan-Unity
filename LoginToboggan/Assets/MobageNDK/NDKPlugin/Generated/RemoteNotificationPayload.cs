//
//  RemoteNotificationPayload.cs
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
// Mobage don't support Unity Editor right now. (add "-define:HAS_MOBAGE_DESKTOP_SHIM" to /Assets/smcs.rsp to override)


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Mobage {

	/**
	 * <summary> Content of a remote notification.</summary>
	 * <remarks>
	 * The maximum size of the payload is 256 bytes.
	 * <p>
	 * The payload can include app-specific key/value pairs that trigger a special behavior in your app,
	 * such as displaying a message to the user on launch. These key/value pairs are stored in the
	 * <c>extraKeys</c> and <c>extraValues</c> properties.
	 * <p>
	 * <strong>Note</strong>: Some properties are used only on Android or iOS, but not both. The Mobage
	 * server automatically discards any parameters that are not supported by the target user's device.
	 * Discarded parameters do not count towards the 256-byte limit.
	 * </remarks>
	 */
	public partial class RemoteNotificationPayload {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
	public partial class RemoteNotificationPayload {
		// Properties!
		/**
		 * The notification message.
		 */
		[NonSerialized]
		public String message;
		/**
		 * The numeric badge to display on the app's icon. Used only on iOS.
		 */
		[NonSerialized]
		public Int32 badge;
		/**
		 * The alert sound to play. This property must contain the name of a sound file in the application bundle, or <c>default</c> to play the default alert sound. The sound file must be in a format that is supported for system sounds. Used only on iOS.
		 */
		[NonSerialized]
		public String sound;
		/**
		 * An identifier that causes newer notifications with the same identifier to be discarded. For example, if a user receives four notifications with the same identifier, only the newest notification will be displayed on the user's device. Used only on Android.
		 */
		[NonSerialized]
		public String collapseKey;
		/**
		 * The layout style for the notification in the device's notification tray. Set to <c>normal</c> to display a standard-size icon or <c>largeIcon</c> to display a large icon. Used only on Android.
		 */
		[NonSerialized]
		public String style;
		/**
		 * The URL for the icon to display in the device's notification bar. This value is ignored unless you also use the <c>style</c> property to specify the layout style. Used only on Android.
		 */
		[NonSerialized]
		public String iconUrl;
		/**
		 * The app-specific keys to include in the payload. Each key must be represented as a string. The following key names are reserved and cannot be used:<ul><li><c>badge</c></li><li><c>collapseKey</c></li><li><c>extras</c></li><li><c>iconUrl</c></li><li><c>message</c></li><li><c>sound</c></li><li><c>style</c></li></ul>
		 */
		[NonSerialized]
		public List<String> extraKeys;
		/**
		 * The app-specific values to include in the payload. Each value must be represented as a string.
		 */
		[NonSerialized]
		public List<String> extraValues;
		
	}

#region Notifications!
	public partial class RemoteNotificationPayload {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class RemoteNotificationPayload {
	}
#endregion

#region Static Methods
	public partial class RemoteNotificationPayload {
	}
#endregion

#region Instance Methods
	public partial class RemoteNotificationPayload {
	}
#endregion

}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
