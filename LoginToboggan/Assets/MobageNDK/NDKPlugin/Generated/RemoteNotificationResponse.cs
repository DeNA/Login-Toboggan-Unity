//
//  RemoteNotificationResponse.cs
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
	 * <summary> Response to a client's request to send a remote notification.</summary>
	 * <remarks>
	 *
	 * </remarks>
	 */
	public partial class RemoteNotificationResponse {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
	public partial class RemoteNotificationResponse {
		// Properties!
		[NonSerialized]
		public String uid;
		[NonSerialized]
		public String responseId;
		/**
		 * The remote notification's payload.
		 */
		[NonSerialized]
		public RemoteNotificationPayload payload;
		/**
		 * The UTC date and time when the Mobage server received the request, using the format <c>YYYY-MM-DDThh:mm:ssZ</c>.
		 */
		[NonSerialized]
		public String published;
		
	}

#region Notifications!
	public partial class RemoteNotificationResponse {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class RemoteNotificationResponse {
	}
#endregion

#region Static Methods
	public partial class RemoteNotificationResponse {
	}
#endregion

#region Instance Methods
	public partial class RemoteNotificationResponse {
	}
#endregion

}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
