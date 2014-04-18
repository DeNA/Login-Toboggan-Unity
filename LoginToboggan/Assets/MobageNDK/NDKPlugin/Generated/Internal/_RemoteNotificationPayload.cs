using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class RemoteNotificationPayload {
		static RemoteNotificationPayload() {
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
	public partial class RemoteNotificationPayload {
		[NonSerialized]
		public IntPtr thisObj; // Pretty Darn Internal
		
		[StructLayout (LayoutKind.Sequential)]
		private struct CRemoteNotificationPayload {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr message;
			public Int32 badge;
			public IntPtr sound;
			public IntPtr collapseKey;
			public IntPtr style;
			public IntPtr iconUrl;
			public IntPtr extraKeys;
			public IntPtr extraValues;
			//End of Marshal struct
		}
		
		// Factories!
		public static RemoteNotificationPayload Factory(IntPtr cobj){
			CRemoteNotificationPayload tmp = (CRemoteNotificationPayload)Marshal.PtrToStructure(cobj, typeof(CRemoteNotificationPayload));
			tmp.thisObj = cobj;
			RemoteNotificationPayload result = Factory(ref tmp);
			return result;
		}
		private static RemoteNotificationPayload Factory(ref CRemoteNotificationPayload cobj) {
			RemoteNotificationPayload tmp = new RemoteNotificationPayload();
			tmp.thisObj = cobj.thisObj;
			MBCRetainRemoteNotificationPayload(tmp.thisObj);
			
			tmp.message = Convert.toCS_String(cobj.message);
			tmp.badge = Convert.toCS_Integer(cobj.badge);
			tmp.sound = Convert.toCS_String(cobj.sound);
			tmp.collapseKey = Convert.toCS_String(cobj.collapseKey);
			tmp.style = Convert.toCS_String(cobj.style);
			tmp.iconUrl = Convert.toCS_String(cobj.iconUrl);
			tmp.extraKeys = Convert.toCS_String_Array(cobj.extraKeys);
			tmp.extraValues = Convert.toCS_String_Array(cobj.extraValues);
			
			return tmp;
		}
		
		~RemoteNotificationPayload(){
			MBCReleaseRemoteNotificationPayload(thisObj);
			thisObj = IntPtr.Zero;
		}
		[StructLayout (LayoutKind.Sequential)]
		public struct RemoteNotificationPayload_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<RemoteNotificationPayload> Factory(IntPtr cobj){
				RemoteNotificationPayload_Array tmp = (RemoteNotificationPayload_Array)Marshal.PtrToStructure(cobj,typeof(RemoteNotificationPayload_Array));
				return tmp.toList();
			}
			private List<RemoteNotificationPayload> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<RemoteNotificationPayload>();
				}
				
				List<RemoteNotificationPayload> tmp = new List<RemoteNotificationPayload>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					RemoteNotificationPayload tmpItem = Convert.toCS_RemoteNotificationPayload(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(RemoteNotificationPayload obj){
			RemoteNotificationPayload.MBCRetainRemoteNotificationPayload(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<RemoteNotificationPayload> list){
			RemoteNotificationPayload.RemoteNotificationPayload_Array tmp = new RemoteNotificationPayload.RemoteNotificationPayload_Array();
			tmp.length = (list != null) ? list.Count : 0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = RemoteNotificationPayload.MBCCopyConstructRemoteNotificationPayload_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static RemoteNotificationPayload toCS_RemoteNotificationPayload(IntPtr obj){
			return RemoteNotificationPayload.Factory(obj);
		}
		public static List<RemoteNotificationPayload> toCS_RemoteNotificationPayload_Array(IntPtr obj){
			return RemoteNotificationPayload.RemoteNotificationPayload_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class RemoteNotificationPayload {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRemoteNotificationPayload(IntPtr /*RemoteNotificationPayload*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRemoteNotificationPayload_Array(IntPtr /*RemoteNotificationPayload_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRemoteNotificationPayload(IntPtr /*RemoteNotificationPayload*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRemoteNotificationPayload(IntPtr /*RemoteNotificationPayload*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRemoteNotificationPayload_Array(IntPtr /*RemoteNotificationPayload_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRemoteNotificationPayload_Array(IntPtr /*RemoteNotificationPayload_Array*/ objects);

	
	}
#endregion

#region Native Return Points
	public partial class RemoteNotificationPayload {
	}
#endregion
	
#region Static Methods
	public partial class RemoteNotificationPayload {
	}
#endregion
	
#region Instance Methods
	public partial class RemoteNotificationPayload {
	}
#endregion

#region Delegate Callbacks
	public partial class RemoteNotificationPayload {
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
