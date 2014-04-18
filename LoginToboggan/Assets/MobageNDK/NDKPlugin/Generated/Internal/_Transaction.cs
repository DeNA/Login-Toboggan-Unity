using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class Transaction {
		static Transaction() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
	
	public partial class Convert {
		public static bool IsTransactionState(int intFlag){return (!((intFlag < 0) || (intFlag > 6))); }
		public static int toC(TransactionState enumValue){return (int)enumValue;}
		public static TransactionState toCS_TransactionState(int enumValue){return (TransactionState)enumValue;}
	}
#endregion
	
#region CLayer Marshaling [Shadow Objects]
	public partial class Transaction {
		[NonSerialized]
		public IntPtr thisObj; // Pretty Darn Internal
		
		[StructLayout (LayoutKind.Sequential)]
		private struct CTransaction {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr uid;
			public IntPtr transactionId;
			public IntPtr items;
			public IntPtr comment;
			public Int32 state;
			public IntPtr published;
			public IntPtr updated;
			//End of Marshal struct
		}
		
		// Factories!
		public static Transaction Factory(IntPtr cobj){
			CTransaction tmp = (CTransaction)Marshal.PtrToStructure(cobj, typeof(CTransaction));
			tmp.thisObj = cobj;
			Transaction result = Factory(ref tmp);
			return result;
		}
		private static Transaction Factory(ref CTransaction cobj) {
			Transaction tmp = new Transaction();
			tmp.thisObj = cobj.thisObj;
			MBCRetainTransaction(tmp.thisObj);
			
			tmp.uid = Convert.toCS_String(cobj.uid);
			tmp.transactionId = Convert.toCS_String(cobj.transactionId);
			tmp.items = Convert.toCS_BillingItem_Array(cobj.items);
			tmp.comment = Convert.toCS_String(cobj.comment);
			tmp.state = Convert.toCS_TransactionState(cobj.state);
			tmp.published = Convert.toCS_String(cobj.published);
			tmp.updated = Convert.toCS_String(cobj.updated);
			
			return tmp;
		}
		
		~Transaction(){
			MBCReleaseTransaction(thisObj);
			thisObj = IntPtr.Zero;
		}
		[StructLayout (LayoutKind.Sequential)]
		public struct Transaction_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<Transaction> Factory(IntPtr cobj){
				Transaction_Array tmp = (Transaction_Array)Marshal.PtrToStructure(cobj,typeof(Transaction_Array));
				return tmp.toList();
			}
			private List<Transaction> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<Transaction>();
				}
				
				List<Transaction> tmp = new List<Transaction>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					Transaction tmpItem = Convert.toCS_Transaction(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(Transaction obj){
			Transaction.MBCRetainTransaction(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<Transaction> list){
			Transaction.Transaction_Array tmp = new Transaction.Transaction_Array();
			tmp.length = (list != null) ? list.Count : 0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = Transaction.MBCCopyConstructTransaction_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static Transaction toCS_Transaction(IntPtr obj){
			return Transaction.Factory(obj);
		}
		public static List<Transaction> toCS_Transaction_Array(IntPtr obj){
			return Transaction.Transaction_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class Transaction {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructTransaction(IntPtr /*Transaction*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructTransaction_Array(IntPtr /*Transaction_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainTransaction(IntPtr /*Transaction*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseTransaction(IntPtr /*Transaction*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainTransaction_Array(IntPtr /*Transaction_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseTransaction_Array(IntPtr /*Transaction_Array*/ objects);

	
	}
#endregion

#region Native Return Points
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

#region Delegate Callbacks
	public partial class Transaction {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414

	}
#endregion
	
	public partial class Convert {
	// Has None!
	}
	
}


#endif	// !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
