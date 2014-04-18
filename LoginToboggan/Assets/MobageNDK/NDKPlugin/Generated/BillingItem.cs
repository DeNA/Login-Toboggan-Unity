//
//  BillingItem.cs
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
	 * <summary> Stores information about a billing item for a transaction.</summary>
	 * <remarks>
	 *
	 * </remarks>
	 */
	public partial class BillingItem {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
	public partial class BillingItem {
		// Properties!
		/**
		 * The virtual item that will be purchased. Call <c>BankInventory::getItemForId</c> to retrieve an <c>ItemData</c> object for the virtual item.
		 */
		[NonSerialized]
		public ItemData item;
		/**
		 * The quantity of the virtual item being purchased.
		 */
		[NonSerialized]
		public Int32 quantity;
		
	}

#region Notifications!
	public partial class BillingItem {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class BillingItem {
	}
#endregion

#region Static Methods
	public partial class BillingItem {
	}
#endregion

#region Instance Methods
	public partial class BillingItem {
	}
#endregion

}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
