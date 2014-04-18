//
//  Analytics.cs
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
	 * <summary> Report an Analytics event to the Mobage server.</summary>
	 * <remarks>
	 * You can view reports on your app's Analytics events on the
	 * <a href="https://developer.mobage.com/">Mobage Developer Portal</a>.
	 * </remarks>
	 */
	public partial class Analytics {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class Analytics {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class Analytics {
	}
#endregion

#region Static Methods
	public partial class Analytics {
#if MB_WW
		/**
		 * <summary> <strong>DEPRECATED:</strong> Use <c>reportGameEvent</c> or <c>reportErrorEvent</c> instead.</summary>
		 * <remarks>
		 * <p>
		 * Report an Analytics event.
		 * <p>
		 * The <c>eventString</c> parameter is a <a href="http://www.json.org/">JSON</a>-formatted
		 * string that contains the following properties:
		 * <ul>
		 * <li><c>evcl</c>: Must contain the value <c>GAME</c>.</li>
		 * <li><c>evid</c>: An alphanumeric string identifying the type of event that is being reported.
		 * Must not contain spaces, punctuation, or other special characters.</li>
		 * <li><c>evpl</c>: A JSON object whose properties are key/value pairs with additional
		 * information about the event. Each key must be a string, and each value must be a string or
		 * number.</li>
		 * <li><c>plst</c>: Information about the user's current state, such as the user's level and
		 * experience points. Do not include information that is unique to a specific user, such as a
		 * user ID or nickname.</li>
		 * </ul>
		 * For example, your app could report a <c>battle</c> event whenever a user completes a
		 * battle, passing a value similar to the following in the <c>eventString</c> parameter.
		 * (For clarity, this example is split into multiple lines.)
		 * <code>
		 * {
		 *   "evcl": "GAME",
		 *   "evid": "battle",
		 * 	 "evpl": {
		 * 		"enemyType": "greenDragon",
		 * 		"enemyHitPoints": 58,
		 * 		"quest": "treasureHunt",
		 * 		"battleWon": "true"
		 * 	 },
		 * 	 "plst": {
		 * 		"hitPoints": 36,
		 * 		"level": 8,
		 * 		"xp": 143
		 * 	 }
		 * }
		 * </code>
		 * </remarks>
		 * <param name="eventString" cref="F:System.String">A JSON-formatted string with information about the event, using the format shown above.</param>
		 * 
		 */
		public static void reportEvent(String eventString)
		{
			_reportEvent(eventString);
		}
#endif // MB_WW
#if MB_WW
		/**
		 * <summary> Report a custom, app-specific event.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="eventId" cref="F:System.String">An alphanumeric string identifying the event being reported.</param>
		 * <param name="payload" cref="F:System.String">Additional information about the event, or <c>nil</c> if there is no additional information to provide. Encode information as key-value pairs in a <a href="http://www.json.org/">JSON</a>-formatted string.</param>
		 * <param name="playerState" cref="F:System.String">Information about the user's current state, or <c>nil</c> to omit this information. Examples of a user's state include a user's level, number of lives remaining, and so on. Encode information as key-value pairs in a <a href="http://www.json.org/">JSON</a>-formatted string. <strong>Note:</strong> Do not include information that is unique to the user, such as a user ID or nickname.</param>
		 * 
		 */
		public static void reportGameEvent(String eventId, String payload, String playerState)
		{
			_reportGameEvent(eventId, payload, playerState);
		}
#endif // MB_WW
#if MB_WW
		/**
		 * <summary> Report an error event.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="error" cref="F:System.String">%Error message.</param>
		 * 
		 */
		public static void reportErrorEvent(String error)
		{
			_reportErrorEvent(error);
		}
#endif // MB_WW
	}
#endregion


}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
