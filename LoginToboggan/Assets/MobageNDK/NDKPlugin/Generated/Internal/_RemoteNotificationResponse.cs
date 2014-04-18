using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class RemoteNotificationResponse {
		static RemoteNotificationResponse() {
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
	public partial class RemoteNotificationResponse {
		[NonSerialized]
		public IntPtr thisObj; // Pretty Darn Internal
		
		[StructLayout (LayoutKind.Sequential)]
		private struct CRemoteNotificationResponse {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr uid;
			public IntPtr responseId;
			public IntPtr payload;
#if MB_JP
			public IntPtr published;
#endif
			//End of Marshal struct
		}
		
		// Factories!
		public static RemoteNotificationResponse Factory(IntPtr cobj){
			CRemoteNotificationResponse tmp = (CRemoteNotificationResponse)Marshal.PtrToStructure(cobj, typeof(CRemoteNotificationResponse));
			tmp.thisObj = cobj;
			RemoteNotificationResponse result = Factory(ref tmp);
			return result;
		}
		private static RemoteNotificationResponse Factory(ref CRemoteNotificationResponse cobj) {
			RemoteNotificationResponse tmp = new RemoteNotificationResponse();
			tmp.thisObj = cobj.thisObj;
			MBCRetainRemoteNotificationResponse(tmp.thisObj);
			
			tmp.uid = Convert.toCS_String(cobj.uid);
			tmp.responseId = Convert.toCS_String(cobj.responseId);
			tmp.payload = Convert.toCS_RemoteNotificationPayload(cobj.payload);
#if MB_JP
			tmp.published = Convert.toCS_String(cobj.published);
#endif
			
			return tmp;
		}
		
		~RemoteNotificationResponse(){
			MBCReleaseRemoteNotificationResponse(thisObj);
			thisObj = IntPtr.Zero;
		}
		[StructLayout (LayoutKind.Sequential)]
		public struct RemoteNotificationResponse_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<RemoteNotificationResponse> Factory(IntPtr cobj){
				RemoteNotificationResponse_Array tmp = (RemoteNotificationResponse_Array)Marshal.PtrToStructure(cobj,typeof(RemoteNotificationResponse_Array));
				return tmp.toList();
			}
			private List<RemoteNotificationResponse> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<RemoteNotificationResponse>();
				}
				
				List<RemoteNotificationResponse> tmp = new List<RemoteNotificationResponse>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					RemoteNotificationResponse tmpItem = Convert.toCS_RemoteNotificationResponse(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(RemoteNotificationResponse obj){
			RemoteNotificationResponse.MBCRetainRemoteNotificationResponse(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<RemoteNotificationResponse> list){
			RemoteNotificationResponse.RemoteNotificationResponse_Array tmp = new RemoteNotificationResponse.RemoteNotificationResponse_Array();
			tmp.length = (list != null) ? list.Count : 0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = RemoteNotificationResponse.MBCCopyConstructRemoteNotificationResponse_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static RemoteNotificationResponse toCS_RemoteNotificationResponse(IntPtr obj){
			return RemoteNotificationResponse.Factory(obj);
		}
		public static List<RemoteNotificationResponse> toCS_RemoteNotificationResponse_Array(IntPtr obj){
			return RemoteNotificationResponse.RemoteNotificationResponse_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class RemoteNotificationResponse {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRemoteNotificationResponse(IntPtr /*RemoteNotificationResponse*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRemoteNotificationResponse_Array(IntPtr /*RemoteNotificationResponse_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRemoteNotificationResponse(IntPtr /*RemoteNotificationResponse*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRemoteNotificationResponse(IntPtr /*RemoteNotificationResponse*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRemoteNotificationResponse_Array(IntPtr /*RemoteNotificationResponse_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRemoteNotificationResponse_Array(IntPtr /*RemoteNotificationResponse_Array*/ objects);

	
	}
#endregion

#region Native Return Points
	public partial class RemoteNotificationResponse {
	}
#endregion
	
#region Static Methods
	public partial class RemoteNotificationResponse {
	}
#endregion
	
#region Instance Methods
	public partial class RemoteNotificationResponse {
	}
#endregion

#region Delegate Callbacks
	public partial class RemoteNotificationResponse {
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
