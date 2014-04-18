//
//  User.cs
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
	 * <summary> Stores properties for a Mobage user.</summary>
	 * <remarks>
	 *
	 * </remarks>
	 */
	public partial class User {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
	public partial class User {
		// Properties!
		/**
		 * The user's unique ID.
		 */
		[NonSerialized]
		public String uid;
		/**
		 * The user's nickname.
		 */
		[NonSerialized]
		public String nickname;
		/**
		 * The name displayed for the user.
		 */
		[NonSerialized]
		public String displayName;
		/**
		 * The URL for the user's thumbnail image.
		 */
		[NonSerialized]
		public String thumbnailUrl;
		/**
		 * Brief introductory text for the user.
		 */
		[NonSerialized]
		public String aboutMe;
		/**
		 * Set to <c>true</c> if the user has used the current app.
		 */
		[NonSerialized]
		public bool hasApp;
		/**
		 * The user's age.
		 */
		[NonSerialized]
		public Int32 age;
		/**
		 * The type of Mobage account. Contains one of the following values:<ul><li><c>0</c>: Not a Mobage user.</li><li><c>1</c>: The user has a guest account. <strong>Note</strong>: Some Mobage APIs do not support guest accounts. You can prompt the current user to upgrade to a registered account by calling <c>Auth::executeUserUpgrade</c>.</li><li><c>2</c>: The user has a registered account. Users can obtain a registered account by:<ul><li>Upgrading a guest account.</li><li>Using the Mobage login dialog to create a new account.</li><li>Using Facebook Connect to log into Mobage.</li></ul></li><li><c>3</c>: The user has a verified account. This value is reserved for future use. Mobage West does not currently support verified accounts.</li></ul>For more information about guest accounts, see the <a href="https://developer.mobage.com/en/resources/guest_accounts_native">guest accounts overview</a> on the Mobage Developer Portal.
		 */
		[NonSerialized]
		public Int32 grade;
		/**
		 * Indicates whether the user is a celebrity account that is used for promotional purposes, does not represent a real Mobage user, and cannot receive notifications. On Mobage West, this field is always set to <c>false</c>.
		 */
		[NonSerialized]
		public bool isFamous;
		[NonSerialized]
		public String bloodType;
		[NonSerialized]
		public bool isVerified;
		[NonSerialized]
		public String jobType;
		[NonSerialized]
		public String birthday;
		
	}

#region Notifications!
	public partial class User {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class User {
	}
#endregion

#region Static Methods
	public partial class User {
	}
#endregion

#region Instance Methods
	public partial class User {
	}
#endregion

}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
