using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class BillingItem {
		static BillingItem() {
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
#endregion
	
#region CLayer Marshaling [Shadow Objects]
	public partial class BillingItem {
		[NonSerialized]
		public IntPtr thisObj; // Pretty Darn Internal
		
		[StructLayout (LayoutKind.Sequential)]
		private struct CBillingItem {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr item;
			public Int32 quantity;
			//End of Marshal struct
		}
		
		// Factories!
		public static BillingItem Factory(IntPtr cobj){
			CBillingItem tmp = (CBillingItem)Marshal.PtrToStructure(cobj, typeof(CBillingItem));
			tmp.thisObj = cobj;
			BillingItem result = Factory(ref tmp);
			return result;
		}
		private static BillingItem Factory(ref CBillingItem cobj) {
			BillingItem tmp = new BillingItem();
			tmp.thisObj = cobj.thisObj;
			MBCRetainBillingItem(tmp.thisObj);
			
			tmp.item = Convert.toCS_ItemData(cobj.item);
			tmp.quantity = Convert.toCS_Integer(cobj.quantity);
			
			return tmp;
		}
		
		~BillingItem(){
			MBCReleaseBillingItem(thisObj);
			thisObj = IntPtr.Zero;
		}
		[StructLayout (LayoutKind.Sequential)]
		public struct BillingItem_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<BillingItem> Factory(IntPtr cobj){
				BillingItem_Array tmp = (BillingItem_Array)Marshal.PtrToStructure(cobj,typeof(BillingItem_Array));
				return tmp.toList();
			}
			private List<BillingItem> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<BillingItem>();
				}
				
				List<BillingItem> tmp = new List<BillingItem>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					BillingItem tmpItem = Convert.toCS_BillingItem(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(BillingItem obj){
			BillingItem.MBCRetainBillingItem(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<BillingItem> list){
			BillingItem.BillingItem_Array tmp = new BillingItem.BillingItem_Array();
			tmp.length = (list != null) ? list.Count : 0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = BillingItem.MBCCopyConstructBillingItem_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static BillingItem toCS_BillingItem(IntPtr obj){
			return BillingItem.Factory(obj);
		}
		public static List<BillingItem> toCS_BillingItem_Array(IntPtr obj){
			return BillingItem.BillingItem_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class BillingItem {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructBillingItem(IntPtr /*BillingItem*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructBillingItem_Array(IntPtr /*BillingItem_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainBillingItem(IntPtr /*BillingItem*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseBillingItem(IntPtr /*BillingItem*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainBillingItem_Array(IntPtr /*BillingItem_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseBillingItem_Array(IntPtr /*BillingItem_Array*/ objects);

	
	}
#endregion

#region Native Return Points
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

#region Delegate Callbacks
	public partial class BillingItem {
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
