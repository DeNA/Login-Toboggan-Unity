//
//  Avatar.cs
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
#if MB_JP // whole interface/model is region-specific

	/**
	 * <summary></summary>
	 * <remarks>
	 *
	 * </remarks>
	 */
	public partial class Avatar {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class Avatar {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class Avatar {
#if MB_JP
		/**
		 * <summary> Callback for retrieving.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="entry" cref="F:Mobage.AvatarData">AvatarData</param>
		 */
		public delegate void getAvatar_onCompleteCallback(SimpleAPIStatus status, Error error, AvatarData entry);
#endif //MB_JP
	}
#endregion

#region Static Methods
	public partial class Avatar {
#if MB_JP
		/**
		 * <summary> Retrieves the specified entry from the server.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="data" cref="F:Mobage.AvatarData">AvatarData</param>
		 * <param name="onComplete" cref="F:Mobage.GetAvatarOnCompleteCallback">
		 * Callback for retrieving.</param>
		 * 
		 */
		public static void getAvatar(AvatarData data, getAvatar_onCompleteCallback onComplete)
		{
			_getAvatar(data, onComplete);
		}
#endif // MB_JP
	}
#endregion


#endif // MB_JP -- whole interface/model is region-specific
}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
