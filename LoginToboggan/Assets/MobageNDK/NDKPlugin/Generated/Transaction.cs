//
//  Transaction.cs
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
	 * <summary> Stores information about a Bank transaction.</summary>
	 * <remarks>
	 *
	 * </remarks>
	 */
	public partial class Transaction {}
	#region Enums / Bitfields
		/**
		 * Enumeration for transaction states.
		 */
		public enum TransactionState {
			/**
					 *
		 * The transaction is new.
			 */
			New = 0, 
			/**
					 *
		 * The transaction has been authorized and is ready to be opened.
			 */
			Authorized = 1, 
			/**
					 *
		 * The transaction has been canceled.
			 */
			Canceled = 2, 
			/**
					 *
		 * The transaction has been opened, and the user's funds have been placed into escrow.
			 */
			Open = 3, 
			/**
					 *
		 * The transaction has been closed, and the user's funds have been captured.
			 */
			Closed = 4, 
			/**
			
			 */
			Same = 5, 
			/**
			
			 */
			Invalid = 6, 
		};

	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields

	 * Enumeration for transaction states.

	public enum TransactionState {

				 *
		 * The transaction is new.

		New = 0, 

				 *
		 * The transaction has been authorized and is ready to be opened.

		Authorized = 1, 

				 *
		 * The transaction has been canceled.

		Canceled = 2, 

				 *
		 * The transaction has been opened, and the user's funds have been placed into escrow.

		Open = 3, 

				 *
		 * The transaction has been closed, and the user's funds have been captured.

		Closed = 4, 

		

		Same = 5, 

		

		Invalid = 6, 
	};
	
#endregion
*/
	
	public partial class Transaction {
		// Properties!
		[NonSerialized]
		public String uid;
		/**
		 * The transaction's unique ID.
		 */
		[NonSerialized]
		public String transactionId;
		/**
		 * The billing items for the transaction. The array must contain only one item, which must be a <c>BillingItem</c>.
		 */
		[NonSerialized]
		public List<BillingItem> items;
		/**
		 * A comment on the transaction. On the US/worldwide platform, this comment is not currently displayed to users.
		 */
		[NonSerialized]
		public String comment;
		/**
		 * The transaction's current state. Contains an enumerated value of Mobage::TransactionState.
		 */
		[NonSerialized]
		public TransactionState state;
		/**
		 * The date and time when the transaction was created, represented in Unix time (milliseconds since 00:00:00 UTC on January 1, 1970).
		 */
		[NonSerialized]
		public String published;
		/**
		 * The date and time when the transaction was last modified, represented in Unix time (milliseconds since 00:00:00 UTC on January 1, 1970).
		 */
		[NonSerialized]
		public String updated;
		
	}

#region Notifications!
	public partial class Transaction {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class Transaction {
	}
#endregion

#region Static Methods
	public partial class Transaction {
	}
#endregion

#region Instance Methods
	public partial class Transaction {
	}
#endregion

}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
