//
//  AvatarData.cs
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
	 * <summary> Model for information about AvatarData</summary>
	 * <remarks>
	 *
	 * </remarks>
	 */
	public partial class AvatarData {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
	public partial class AvatarData {
		// Properties!
		[NonSerialized]
		public String uid;
		/**
		 * required.
		 */
		[NonSerialized]
		public String userId;
		/**
		 * optional. "xxlarge", "large" or "medium". default is "xxlarge".
		 */
		[NonSerialized]
		public String size;
		/**
		 * optional. "entire" or "upper". default is "entire".
		 */
		[NonSerialized]
		public String view;
		/**
		 * optional. "defined", "normal", "smile", "cry", "angry" or "shy". default is "defined".
		 */
		[NonSerialized]
		public String emotion;
		/**
		 * optional. true or false. default is false.
		 */
		[NonSerialized]
		public String transparent;
		/**
		 * optional. "image" or "sprite". default is "image".
		 */
		[NonSerialized]
		public String type;
		/**
		 * optional. "png" only. default is "png".
		 */
		[NonSerialized]
		public String extension;
		/**
		 * response.
		 */
		[NonSerialized]
		public String url;
		
	}

#region Notifications!
	public partial class AvatarData {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class AvatarData {
	}
#endregion

#region Static Methods
	public partial class AvatarData {
	}
#endregion

#region Instance Methods
	public partial class AvatarData {
	}
#endregion

#endif // MB_JP -- whole interface/model is region-specific
}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
