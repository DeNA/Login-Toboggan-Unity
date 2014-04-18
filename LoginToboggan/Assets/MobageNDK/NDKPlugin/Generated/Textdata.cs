//
//  Textdata.cs
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
	 * <summary> Textdata is an API to receive the text data that the users input.</summary>
	 * <remarks>
	 * The input texts are saved to the server and watched by the server.
	 * <br>
	 * Workflow<br><ol>
	 * <li> Creates a new TextDataGroup (REST APIs only) </li>
	 * <li> The following two functions are available after the TextDataGroup creation (REST APIs only) <ol>
	 * <li> Getting TextDataGroup </li>
	 * <li> Deleting TextDataGroup </li></ol></li>
	 * <li> Creates a new TextData entry that belongs to the TextDataGroup (Both REST APIs and This JS APIs) </li>
	 * <li> The following three functions are available after the TextData entry creation (Both REST APIs and This JS APIs) </li><ol>
	 * <li> Getting TextData </li>
	 * <li> Updating TextData </li>
	 * <li> Deleting TextData </li></ol>
	 * </ol>
	 * <br>
	 * Note that users are required at first to create TextDataGroup for the grouping of
	 * TextData by using REST APIs (OAuth Consumer Request). <br>
	 * </remarks>
	 */
	public partial class Textdata {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class Textdata {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class Textdata {
		/**
		 * <summary> Callback for creating</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="entry" cref="F:Mobage.TextdataEntry">Created Textdata entry</param>
		 */
		public delegate void createEntryForGroupName_onCompleteCallback(SimpleAPIStatus status, Error error, TextdataEntry entry);

		/**
		 * <summary> Callback for retrieving.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="entries" cref="F:System.Collections.Generic.List<Mobage.TextdataEntry>">Retrieved Textdata entries</param>
		 */
		public delegate void getEntriesForGroupName_onCompleteCallback(SimpleAPIStatus status, Error error, List<TextdataEntry> entries);

		/**
		 * <summary> Callback for updating</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void updateEntryForGroupName_onCompleteCallback(SimpleAPIStatus status, Error error);

		/**
		 * <summary> Callback for deleting</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void deleteEntryForGroupName_onCompleteCallback(SimpleAPIStatus status, Error error);

	}
#endregion

#region Static Methods
	public partial class Textdata {
		/**
		 * <summary> Creates an entry</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="groupName" cref="F:System.String">The group name of the TextDataGroup</param>
		 * <param name="entry" cref="F:Mobage.TextdataEntry">The TextData entry to be updated.</param>
		 * <param name="onComplete" cref="F:Mobage.CreateEntryForGroupNameOnCompleteCallback">
		 * Callback for creating</param>
		 * 
		 */
		public static void createEntryForGroupName(String groupName, TextdataEntry entry, createEntryForGroupName_onCompleteCallback onComplete)
		{
			_createEntryForGroupName(groupName, entry, onComplete);
		}
		/**
		 * <summary> Retrieves the specified entries from the server.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="groupName" cref="F:System.String">The group name of the TextDataGroup</param>
		 * <param name="entryIds" cref="F:System.Collections.Generic.List<System.String>">The string array of the ids</param>
		 * <param name="onComplete" cref="F:Mobage.GetEntriesForGroupNameOnCompleteCallback">
		 * Callback for retrieving.</param>
		 * 
		 */
		public static void getEntriesForGroupName(String groupName, List<String> entryIds, getEntriesForGroupName_onCompleteCallback onComplete)
		{
			_getEntriesForGroupName(groupName, entryIds, onComplete);
		}
		/**
		 * <summary> Updates an entry</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="groupName" cref="F:System.String">The group name of the TextDataGroup</param>
		 * <param name="entryId" cref="F:System.String">The id of the TextData object</param>
		 * <param name="entry" cref="F:Mobage.TextdataEntry">The TextData entry to be updated.</param>
		 * <param name="onComplete" cref="F:Mobage.UpdateEntryForGroupNameOnCompleteCallback">
		 * Callback for updating</param>
		 * 
		 */
		public static void updateEntryForGroupName(String groupName, String entryId, TextdataEntry entry, updateEntryForGroupName_onCompleteCallback onComplete)
		{
			_updateEntryForGroupName(groupName, entryId, entry, onComplete);
		}
		/**
		 * <summary> Deletes an entry</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="groupName" cref="F:System.String">The group name of the TextDataGroup</param>
		 * <param name="entryId" cref="F:System.String">The id of the TextData object</param>
		 * <param name="onComplete" cref="F:Mobage.DeleteEntryForGroupNameOnCompleteCallback">
		 * Callback for deleting</param>
		 * 
		 */
		public static void deleteEntryForGroupName(String groupName, String entryId, deleteEntryForGroupName_onCompleteCallback onComplete)
		{
			_deleteEntryForGroupName(groupName, entryId, onComplete);
		}
	}
#endregion


#endif // MB_JP -- whole interface/model is region-specific
}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
