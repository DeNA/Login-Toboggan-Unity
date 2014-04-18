using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class AvatarData {
		static AvatarData() {
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
	public partial class AvatarData {
		[NonSerialized]
		public IntPtr thisObj; // Pretty Darn Internal
		
		[StructLayout (LayoutKind.Sequential)]
		private struct CAvatarData {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
#if MB_JP
			public IntPtr uid;
#endif
#if MB_JP
			public IntPtr userId;
#endif
#if MB_JP
			public IntPtr size;
#endif
#if MB_JP
			public IntPtr view;
#endif
#if MB_JP
			public IntPtr emotion;
#endif
#if MB_JP
			public IntPtr transparent;
#endif
#if MB_JP
			public IntPtr type;
#endif
#if MB_JP
			public IntPtr extension;
#endif
#if MB_JP
			public IntPtr url;
#endif
			//End of Marshal struct
		}
		
		// Factories!
		public static AvatarData Factory(IntPtr cobj){
			CAvatarData tmp = (CAvatarData)Marshal.PtrToStructure(cobj, typeof(CAvatarData));
			tmp.thisObj = cobj;
			AvatarData result = Factory(ref tmp);
			return result;
		}
		private static AvatarData Factory(ref CAvatarData cobj) {
			AvatarData tmp = new AvatarData();
			tmp.thisObj = cobj.thisObj;
			MBCRetainAvatarData(tmp.thisObj);
			
#if MB_JP
			tmp.uid = Convert.toCS_String(cobj.uid);
#endif
#if MB_JP
			tmp.userId = Convert.toCS_String(cobj.userId);
#endif
#if MB_JP
			tmp.size = Convert.toCS_String(cobj.size);
#endif
#if MB_JP
			tmp.view = Convert.toCS_String(cobj.view);
#endif
#if MB_JP
			tmp.emotion = Convert.toCS_String(cobj.emotion);
#endif
#if MB_JP
			tmp.transparent = Convert.toCS_String(cobj.transparent);
#endif
#if MB_JP
			tmp.type = Convert.toCS_String(cobj.type);
#endif
#if MB_JP
			tmp.extension = Convert.toCS_String(cobj.extension);
#endif
#if MB_JP
			tmp.url = Convert.toCS_String(cobj.url);
#endif
			
			return tmp;
		}
		
		~AvatarData(){
			MBCReleaseAvatarData(thisObj);
			thisObj = IntPtr.Zero;
		}
		[StructLayout (LayoutKind.Sequential)]
		public struct AvatarData_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<AvatarData> Factory(IntPtr cobj){
				AvatarData_Array tmp = (AvatarData_Array)Marshal.PtrToStructure(cobj,typeof(AvatarData_Array));
				return tmp.toList();
			}
			private List<AvatarData> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<AvatarData>();
				}
				
				List<AvatarData> tmp = new List<AvatarData>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					AvatarData tmpItem = Convert.toCS_AvatarData(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(AvatarData obj){
			AvatarData.MBCRetainAvatarData(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<AvatarData> list){
			AvatarData.AvatarData_Array tmp = new AvatarData.AvatarData_Array();
			tmp.length = (list != null) ? list.Count : 0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = AvatarData.MBCCopyConstructAvatarData_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static AvatarData toCS_AvatarData(IntPtr obj){
			return AvatarData.Factory(obj);
		}
		public static List<AvatarData> toCS_AvatarData_Array(IntPtr obj){
			return AvatarData.AvatarData_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class AvatarData {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructAvatarData(IntPtr /*AvatarData*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructAvatarData_Array(IntPtr /*AvatarData_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainAvatarData(IntPtr /*AvatarData*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseAvatarData(IntPtr /*AvatarData*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainAvatarData_Array(IntPtr /*AvatarData_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseAvatarData_Array(IntPtr /*AvatarData_Array*/ objects);

	
	}
#endregion

#region Native Return Points
	public partial class AvatarData {
	}
#endregion
	
#region Static Methods
	public partial class AvatarData {
	}
#endregion
	
#region Instance Methods
	public partial class AvatarData {
	}
#endregion

#region Delegate Callbacks
	public partial class AvatarData {
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
