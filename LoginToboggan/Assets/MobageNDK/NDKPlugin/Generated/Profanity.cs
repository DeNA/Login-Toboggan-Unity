//
//  Profanity.cs
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
	 * <summary> Determine whether a string contains words that are clearly profane or offensive.</summary>
	 * <remarks>
	 * On the US/worldwide platform, this class checks for English-language profanity.
	 * <p>
	 * The list of profane and offensive words may be updated at any time.
	 * </remarks>
	 */
	public partial class Profanity {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class Profanity {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class Profanity {
		/**
		 * <summary> Callback for checking a text string for profane or offensive words.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="textIsValid" cref="F:System.bool">Set to <c>true</c> if the string is valid, or <c>false</c> if the string contains profane or offensive words.</param>
		 */
		public delegate void checkProfanity_onCompleteCallback(SimpleAPIStatus status, Error error, bool textIsValid);

	}
#endregion

#region Static Methods
	public partial class Profanity {
		/**
		 * <summary> Check a text string to determine whether it contains words that are clearly profane or offensive.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="text" cref="F:System.String">The string to check for profanity.</param>
		 * <param name="onComplete" cref="F:Mobage.CheckProfanityOnCompleteCallback">
		 * Callback for checking a text string for profane or offensive words.</param>
		 * 
		 */
		public static void checkProfanity(String text, checkProfanity_onCompleteCallback onComplete)
		{
			_checkProfanity(text, onComplete);
		}
	}
#endregion


}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
