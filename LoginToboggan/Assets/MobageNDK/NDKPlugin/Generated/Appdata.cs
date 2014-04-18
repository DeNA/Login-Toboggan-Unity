//
//  Appdata.cs
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
	 * <summary> Create, update, retrieve, and delete app-specific data on the Mobage server.</summary>
	 * <remarks>
	 * Data is stored as key/value pairs that are tied to the current user and are limited as follows:
	 * <ul>
	 * <li>An app can store a maximum of 30 key/value pairs for each user.</li>
	 * <li>The maximum key length is 32 bytes.</li>
	 * <li>The maximum value length is 1,024 bytes.</li>
	 * </ul>
	 * Use the methods in this class to store app data that is tied to a specific user and should be
	 * available whenever the user is logged into Mobage.
	 * </remarks>
	 */
	public partial class Appdata {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class Appdata {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class Appdata {
		/**
		 * <summary> Callback for deleting key-value pairs.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="deletedKeys" cref="F:System.Collections.Generic.List<System.String>">A list of keys that were deleted, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.</param>
		 */
		public delegate void deleteEntriesForKeys_onCompleteCallback(SimpleAPIStatus status, Error error, List<String> deletedKeys);

		/**
		 * <summary> Callback for retrieving key-value pairs.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="keys" cref="F:System.Collections.Generic.List<System.String>">The keys that were retrieved, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.</param>
		 * <param name="values" cref="F:System.Collections.Generic.List<System.String>">The values that were retrieved, with each value represented as a <c>String</c>, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getEntriesForKeys_onCompleteCallback(SimpleAPIStatus status, Error error, List<String> keys, List<String> values);

		/**
		 * <summary> Callback for creating or updating key/value pairs.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="updatedKeys" cref="F:System.Collections.Generic.List<System.String>">The keys that were created or updated, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.</param>
		 */
		public delegate void updateEntries_onCompleteCallback(SimpleAPIStatus status, Error error, List<String> updatedKeys);

	}
#endregion

#region Static Methods
	public partial class Appdata {
		/**
		 * <summary> Delete one or more key/value pairs.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="theKeys" cref="F:System.Collections.Generic.List<System.String>">The keys to delete. Each key name must be a <c>String</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.DeleteEntriesForKeysOnCompleteCallback">
		 * Callback for deleting key-value pairs.</param>
		 * 
		 */
		public static void deleteEntriesForKeys(List<String> theKeys, deleteEntriesForKeys_onCompleteCallback onComplete)
		{
			_deleteEntriesForKeys(theKeys, onComplete);
		}
		/**
		 * <summary> Retrieve one or more key/value pairs.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="theKeys" cref="F:System.Collections.Generic.List<System.String>">The keys to retrieve. Each key name must be a <c>String</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetEntriesForKeysOnCompleteCallback">
		 * Callback for retrieving key-value pairs.</param>
		 * 
		 */
		public static void getEntriesForKeys(List<String> theKeys, getEntriesForKeys_onCompleteCallback onComplete)
		{
			_getEntriesForKeys(theKeys, onComplete);
		}
		/**
		 * <summary> Create or update one or more key/value pairs.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="theKeys" cref="F:System.Collections.Generic.List<System.String>">The keys to create or update. Each key name must be a <c>String</c>.</param>
		 * <param name="theValues" cref="F:System.Collections.Generic.List<System.String>">The values for each key. Each value must be a <c>String</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.UpdateEntriesOnCompleteCallback">
		 * Callback for creating or updating key/value pairs.</param>
		 * 
		 */
		public static void updateEntries(List<String> theKeys, List<String> theValues, updateEntries_onCompleteCallback onComplete)
		{
			_updateEntries(theKeys, theValues, onComplete);
		}
	}
#endregion


}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
