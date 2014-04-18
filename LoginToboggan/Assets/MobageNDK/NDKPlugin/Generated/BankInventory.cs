//
//  BankInventory.cs
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
	 * <summary> Provides access to information about virtual items.</summary>
	 * <remarks>
	 * Use the <a href="https://developer.mobage.com/">Mobage Developer Portal</a> to set up the virtual
	 * items for your app.
	 * </remarks>
	 */
	public partial class BankInventory {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
#region Notifications!
	public partial class BankInventory {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class BankInventory {
		/**
		 * <summary> Callback for retrieving information about a virtual item.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="itemData" cref="F:Mobage.ItemData">Information about the virtual item, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getItemForId_onCompleteCallback(SimpleAPIStatus status, Error error, ItemData itemData);

		/**
		 * <summary> Callback for retrieving information about multiple virtual items.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="items" cref="F:System.Collections.Generic.List<Mobage.ItemData>">Information about the virtual items, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getItemsForIds_onCompleteCallback(SimpleAPIStatus status, Error error, List<ItemData> items);

	}
#endregion

#region Static Methods
	public partial class BankInventory {
		/**
		 * <summary> Retrieve information about a virtual item.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="itemId" cref="F:System.String">The item's unique ID.</param>
		 * <param name="onComplete" cref="F:Mobage.GetItemForIdOnCompleteCallback">
		 * Callback for retrieving information about a virtual item.</param>
		 * 
		 */
		public static void getItemForId(String itemId, getItemForId_onCompleteCallback onComplete)
		{
			_getItemForId(itemId, onComplete);
		}
		/**
		 * <summary> Retrieve information about the virtual items with the specified item IDs.</summary>
		 * <remarks>
		 *
		 * </remarks>
		 * <param name="itemIds" cref="F:System.Collections.Generic.List<System.String>">The IDs of the virtual items.</param>
		 * <param name="onComplete" cref="F:Mobage.GetItemsForIdsOnCompleteCallback">
		 * Callback for retrieving information about multiple virtual items.</param>
		 * 
		 */
		public static void getItemsForIds(List<String> itemIds, getItemsForIds_onCompleteCallback onComplete)
		{
			_getItemsForIds(itemIds, onComplete);
		}
	}
#endregion


}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
