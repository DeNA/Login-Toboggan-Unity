using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class ItemData {
		static ItemData() {
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
	public partial class ItemData {
		[NonSerialized]
		public IntPtr thisObj; // Pretty Darn Internal
		
		[StructLayout (LayoutKind.Sequential)]
		private struct CItemData {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr itemId;
			public IntPtr name;
			public Int32 price;
			public IntPtr longDescription;
			public IntPtr imageUrl;
#if MB_WW
			public IntPtr originPriceLabel;
#endif
#if MB_WW
			public IntPtr originCurrencyLabel;
#endif
#if MB_WW
			public short itemForCash;
#endif
#if MB_WW
			public double originPrice;
#endif
#if MB_WW
			public IntPtr currency;
#endif
			//End of Marshal struct
		}
		
		// Factories!
		public static ItemData Factory(IntPtr cobj){
			CItemData tmp = (CItemData)Marshal.PtrToStructure(cobj, typeof(CItemData));
			tmp.thisObj = cobj;
			ItemData result = Factory(ref tmp);
			return result;
		}
		private static ItemData Factory(ref CItemData cobj) {
			ItemData tmp = new ItemData();
			tmp.thisObj = cobj.thisObj;
			MBCRetainItemData(tmp.thisObj);
			
			tmp.itemId = Convert.toCS_String(cobj.itemId);
			tmp.name = Convert.toCS_String(cobj.name);
			tmp.price = Convert.toCS_Integer(cobj.price);
			tmp.longDescription = Convert.toCS_String(cobj.longDescription);
			tmp.imageUrl = Convert.toCS_String(cobj.imageUrl);
#if MB_WW
			tmp.originPriceLabel = Convert.toCS_String(cobj.originPriceLabel);
#endif
#if MB_WW
			tmp.originCurrencyLabel = Convert.toCS_String(cobj.originCurrencyLabel);
#endif
#if MB_WW
			tmp.itemForCash = Convert.toCS_Bool(cobj.itemForCash);
#endif
#if MB_WW
			tmp.originPrice = Convert.toCS_Double(cobj.originPrice);
#endif
#if MB_WW
			tmp.currency = Convert.toCS_String(cobj.currency);
#endif
			
			return tmp;
		}
		
		~ItemData(){
			MBCReleaseItemData(thisObj);
			thisObj = IntPtr.Zero;
		}
		[StructLayout (LayoutKind.Sequential)]
		public struct ItemData_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<ItemData> Factory(IntPtr cobj){
				ItemData_Array tmp = (ItemData_Array)Marshal.PtrToStructure(cobj,typeof(ItemData_Array));
				return tmp.toList();
			}
			private List<ItemData> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<ItemData>();
				}
				
				List<ItemData> tmp = new List<ItemData>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					ItemData tmpItem = Convert.toCS_ItemData(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(ItemData obj){
			ItemData.MBCRetainItemData(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<ItemData> list){
			ItemData.ItemData_Array tmp = new ItemData.ItemData_Array();
			tmp.length = (list != null) ? list.Count : 0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = ItemData.MBCCopyConstructItemData_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static ItemData toCS_ItemData(IntPtr obj){
			return ItemData.Factory(obj);
		}
		public static List<ItemData> toCS_ItemData_Array(IntPtr obj){
			return ItemData.ItemData_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class ItemData {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructItemData(IntPtr /*ItemData*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructItemData_Array(IntPtr /*ItemData_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainItemData(IntPtr /*ItemData*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseItemData(IntPtr /*ItemData*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainItemData_Array(IntPtr /*ItemData_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseItemData_Array(IntPtr /*ItemData_Array*/ objects);

	
	}
#endregion

#region Native Return Points
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

#region Delegate Callbacks
	public partial class ItemData {
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
