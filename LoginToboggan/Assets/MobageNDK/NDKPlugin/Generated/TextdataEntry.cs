//
//  TextdataEntry.cs
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
	 * <summary> Model for information about TextdataEntry</summary>
	 * <remarks>
	 *
	 * </remarks>
	 */
	public partial class TextdataEntry {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
	public partial class TextdataEntry {
		// Properties!
		[NonSerialized]
		public String uid;
		/**
		 * the id of the TextData
		 */
		[NonSerialized]
		public String entryId;
		/**
		 * the name of the TextDataGroup
		 */
		[NonSerialized]
		public String groupName;
		/**
		 * the id of the parent TextData
		 */
		[NonSerialized]
		public String parentId;
		/**
		 * the guid of who wrote the text
		 */
		[NonSerialized]
		public String writerId;
		/**
		 * the guid of who wrote the text
		 */
		[NonSerialized]
		public String ownerId;
		/**
		 * the input text data
		 */
		[NonSerialized]
		public String data;
		/**
		 * the logical status value
		 */
		[NonSerialized]
		public Int32 status;
		/**
		 * the date that the text was published
		 */
		[NonSerialized]
		public String publish;
		/**
		 * the date that the text was updated
		 */
		[NonSerialized]
		public String updated;
		
	}

#region Notifications!
	public partial class TextdataEntry {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class TextdataEntry {
	}
#endregion

#region Static Methods
	public partial class TextdataEntry {
	}
#endregion

#region Instance Methods
	public partial class TextdataEntry {
	}
#endregion

#endif // MB_JP -- whole interface/model is region-specific
}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
