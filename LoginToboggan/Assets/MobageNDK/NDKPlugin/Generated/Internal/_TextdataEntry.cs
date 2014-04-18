using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class TextdataEntry {
		static TextdataEntry() {
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
#if MB_JP // whole interface/model is region-specific
	
#region Enums / Bitfields
#endregion
	
#region CLayer Marshaling [Shadow Objects]
	public partial class TextdataEntry {
		[NonSerialized]
		public IntPtr thisObj; // Pretty Darn Internal
		
		[StructLayout (LayoutKind.Sequential)]
		private struct CTextdataEntry {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
#if MB_JP
			public IntPtr uid;
#endif
#if MB_JP
			public IntPtr entryId;
#endif
#if MB_JP
			public IntPtr groupName;
#endif
#if MB_JP
			public IntPtr parentId;
#endif
#if MB_JP
			public IntPtr writerId;
#endif
#if MB_JP
			public IntPtr ownerId;
#endif
#if MB_JP
			public IntPtr data;
#endif
#if MB_JP
			public Int32 status;
#endif
#if MB_JP
			public IntPtr publish;
#endif
#if MB_JP
			public IntPtr updated;
#endif
			//End of Marshal struct
		}
		
		// Factories!
		public static TextdataEntry Factory(IntPtr cobj){
			CTextdataEntry tmp = (CTextdataEntry)Marshal.PtrToStructure(cobj, typeof(CTextdataEntry));
			tmp.thisObj = cobj;
			TextdataEntry result = Factory(ref tmp);
			return result;
		}
		private static TextdataEntry Factory(ref CTextdataEntry cobj) {
			TextdataEntry tmp = new TextdataEntry();
			tmp.thisObj = cobj.thisObj;
			MBCRetainTextdataEntry(tmp.thisObj);
			
#if MB_JP
			tmp.uid = Convert.toCS_String(cobj.uid);
#endif
#if MB_JP
			tmp.entryId = Convert.toCS_String(cobj.entryId);
#endif
#if MB_JP
			tmp.groupName = Convert.toCS_String(cobj.groupName);
#endif
#if MB_JP
			tmp.parentId = Convert.toCS_String(cobj.parentId);
#endif
#if MB_JP
			tmp.writerId = Convert.toCS_String(cobj.writerId);
#endif
#if MB_JP
			tmp.ownerId = Convert.toCS_String(cobj.ownerId);
#endif
#if MB_JP
			tmp.data = Convert.toCS_String(cobj.data);
#endif
#if MB_JP
			tmp.status = Convert.toCS_Integer(cobj.status);
#endif
#if MB_JP
			tmp.publish = Convert.toCS_String(cobj.publish);
#endif
#if MB_JP
			tmp.updated = Convert.toCS_String(cobj.updated);
#endif
			
			return tmp;
		}
		
		~TextdataEntry(){
			MBCReleaseTextdataEntry(thisObj);
			thisObj = IntPtr.Zero;
		}
		[StructLayout (LayoutKind.Sequential)]
		public struct TextdataEntry_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<TextdataEntry> Factory(IntPtr cobj){
				TextdataEntry_Array tmp = (TextdataEntry_Array)Marshal.PtrToStructure(cobj,typeof(TextdataEntry_Array));
				return tmp.toList();
			}
			private List<TextdataEntry> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<TextdataEntry>();
				}
				
				List<TextdataEntry> tmp = new List<TextdataEntry>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					TextdataEntry tmpItem = Convert.toCS_TextdataEntry(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(TextdataEntry obj){
			TextdataEntry.MBCRetainTextdataEntry(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<TextdataEntry> list){
			TextdataEntry.TextdataEntry_Array tmp = new TextdataEntry.TextdataEntry_Array();
			tmp.length = (list != null) ? list.Count : 0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = TextdataEntry.MBCCopyConstructTextdataEntry_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static TextdataEntry toCS_TextdataEntry(IntPtr obj){
			return TextdataEntry.Factory(obj);
		}
		public static List<TextdataEntry> toCS_TextdataEntry_Array(IntPtr obj){
			return TextdataEntry.TextdataEntry_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class TextdataEntry {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructTextdataEntry(IntPtr /*TextdataEntry*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructTextdataEntry_Array(IntPtr /*TextdataEntry_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainTextdataEntry(IntPtr /*TextdataEntry*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseTextdataEntry(IntPtr /*TextdataEntry*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainTextdataEntry_Array(IntPtr /*TextdataEntry_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseTextdataEntry_Array(IntPtr /*TextdataEntry_Array*/ objects);

	
	}
#endregion

#region Native Return Points
	public partial class TextdataEntry {
	}
#endregion
	
#region Static Methods
	public partial class TextdataEntry {
	}
#endregion
	
#region Instance Methods
	public partial class TextdataEntry {
	}
#endregion

#region Delegate Callbacks
	public partial class TextdataEntry {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414

	}
#endregion
	
	public partial class Convert {
	// Has None!
	}
	
#endif // MB_JP -- whole interface/model is region-specific
}


#endif	// !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
