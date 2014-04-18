//
//  ItemData.cs
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
	 * <summary> Stores information about a virtual item for your app.</summary>
	 * <remarks>
	 * <p>
	 * <strong>Note</strong>: This class provides a representation of a virtual item that you have
	 * already set up for your app. You must use the <a href="https://developer.mobage.com/">Mobage
	 * Developer Portal</a> to set up a virtual item.
	 * <p>
	 * <strong>iOS Only</strong>: If an item can be purchased for cash, the values for
	 * <c>originPrice</c>, <c>originPriceLabel</c>, and <c>originCurrencyLabel</c> are retrieved
	 * from the App Store using the StoreKit framework. Therefore, you must set up your virtual
	 * items on iTunes Connect (in addition to the <a href="https://developer.mobage.com/">Mobage
	 * Developer Portal</a>). Otherwise, the values returned for <c>originPrice</c>,
	 * <c>originPriceLabel</c>, and <c>originCurrencyLabel</c> will be <c>0</c>, <c>nil</c>,
	 * and <c>nil</c> respectively.
	 * <p>
	 * You only need to set up your virtual items on iTunes Connect when you are testing your app.
	 * When you submit your app for publishing, we will set up your virtual items on iTunes
	 * Connect for you, using your entries on the Mobage Developer Portal as a reference.
	 * <p>
	 * When setting up your app on the Apple Developer portal, and then subsequently on iTunes
	 * Connect, do not use the Mobage bundle ID.
	 * </remarks>
	 */
	public partial class ItemData {}
	#region Enums / Bitfields
	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields
#endregion
*/
	
	public partial class ItemData {
		// Properties!
		/**
		 * The item's unique ID.
		 */
		[NonSerialized]
		public String itemId;
		/**
		 * The item's name.
		 */
		[NonSerialized]
		public String name;
		/**
		 * The item's price, represented in MobaCoin (on Android) or app-specific purchased currency (on iOS). For iOS apps, if the item can only be purchased with cash, this property contains the value <c>0</c>.
		 */
		[NonSerialized]
		public Int32 price;
		/**
		 * A description of the item. <strong>Note</strong>: In version 2.1 and earlier, this property was named <code>description</code>.
		 */
		[NonSerialized]
		public String longDescription;
		/**
		 * The URL for an image of the item.
		 */
		[NonSerialized]
		public String imageUrl;
		/**
		 * The item's cash price in the user's local currency, formatted based on the user's locale, or <c>null</c> if the item cannot be purchased for cash. Used only on iOS.
		 */
		[NonSerialized]
		public String originPriceLabel;
		/**
		 * The symbol for the user's local currency, or <c>null</c> if the item cannot be purchased for cash. Used only on iOS.
		 */
		[NonSerialized]
		public String originCurrencyLabel;
		/**
		 * Set to <c>true</c> if the item can be purchased with cash or <c>false</c> if the item can be purchased with virtual currency. Used only on iOS.
		 */
		[NonSerialized]
		public bool itemForCash;
		/**
		 * The item's cash price in the user's local currency, or <c>null</c> if the item cannot be purchased with cash. Used only on iOS.<p>The user's local currency is identified based on the user's Apple ID settings.
		 */
		[NonSerialized]
		public double originPrice;
		[NonSerialized]
		public String currency;
		
	}

#region Notifications!
	public partial class ItemData {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class ItemData {
	}
#endregion

#region Static Methods
	public partial class ItemData {
	}
#endregion

#region Instance Methods
	public partial class ItemData {
	}
#endregion

}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
