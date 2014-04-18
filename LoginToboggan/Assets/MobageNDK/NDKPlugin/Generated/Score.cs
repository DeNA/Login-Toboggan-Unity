//
//  Score.cs
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
	 * <summary> Model for information about a high score on a leaderboard.</summary>
	 * <remarks>
	 *
	 * </remarks>
	 */
	public partial class Score {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
	public partial class Score {
		// Properties!
		[NonSerialized]
		public String uid;
		/**
		 * The Mobage user ID associated with the score.
		 */
		[NonSerialized]
		public String userId;
		/**
		 * The value of the score.
		 */
		[NonSerialized]
		public double scoreValue;
		/**
		 * A version of the score that has been formatted for display, based on the leaderboard's settings.
		 */
		[NonSerialized]
		public String displayValue;
		/**
		 * The score's rank within the leaderboard.
		 */
		[NonSerialized]
		public Int32 rank;
		
	}

#region Notifications!
	public partial class Score {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class Score {
	}
#endregion

#region Static Methods
	public partial class Score {
	}
#endregion

#region Instance Methods
	public partial class Score {
	}
#endregion

}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
