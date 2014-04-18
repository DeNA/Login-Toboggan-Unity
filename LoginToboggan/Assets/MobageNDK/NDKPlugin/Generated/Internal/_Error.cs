using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class Error {
		static Error() {
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
		public static bool IsStandardError(int intFlag){return (!((intFlag < 10001) || (intFlag > 10007))); }
		public static int toC(StandardError enumValue){return (int)enumValue;}
		public static StandardError toCS_StandardError(int enumValue){return (StandardError)enumValue;}
	}
	
	public partial class Convert {
		public static bool IsHTTPError(int intFlag){return (!((intFlag < 109) || (intFlag > 599))); }
		public static int toC(HTTPError enumValue){return (int)enumValue;}
		public static HTTPError toCS_HTTPError(int enumValue){return (HTTPError)enumValue;}
	}
	
	public partial class Convert {
		public static bool IsCommonAPIError(int intFlag){return (!((intFlag < 20001) || (intFlag > 20005))); }
		public static int toC(CommonAPIError enumValue){return (int)enumValue;}
		public static CommonAPIError toCS_CommonAPIError(int enumValue){return (CommonAPIError)enumValue;}
	}
	
	public partial class Convert {
		public static bool IsAnalyticsServerError(int intFlag){return (!((intFlag < 30001) || (intFlag > 30005))); }
		public static int toC(AnalyticsServerError enumValue){return (int)enumValue;}
		public static AnalyticsServerError toCS_AnalyticsServerError(int enumValue){return (AnalyticsServerError)enumValue;}
	}
	
	public partial class Convert {
		public static bool IsBankError(int intFlag){return (!((intFlag < 40001) || (intFlag > 40012))); }
		public static int toC(BankError enumValue){return (int)enumValue;}
		public static BankError toCS_BankError(int enumValue){return (BankError)enumValue;}
	}
	
	public partial class Convert {
		public static bool IsErrorEnum(int intFlag){return (!((intFlag < 109) || (intFlag > 100005))); }
		public static int toC(ErrorEnum enumValue){return (int)enumValue;}
		public static ErrorEnum toCS_ErrorEnum(int enumValue){return (ErrorEnum)enumValue;}
	}
	
	public partial class Convert {
		public static bool IsMobageAPIErrorType(int intFlag){return (!((intFlag < 109) || (intFlag > 100005))); }
		public static int toC(MobageAPIErrorType enumValue){return (int)enumValue;}
		public static MobageAPIErrorType toCS_MobageAPIErrorType(int enumValue){return (MobageAPIErrorType)enumValue;}
	}
#endregion
	
#region CLayer Marshaling [Shadow Objects]
	public partial class Error {
		[NonSerialized]
		public IntPtr thisObj; // Pretty Darn Internal
		
		[StructLayout (LayoutKind.Sequential)]
		private struct CError {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr domain;
			public Int32 code;
			public IntPtr localizedDescription;
			public IntPtr description;
			//End of Marshal struct
		}
		
		// Factories!
		public static Error Factory(IntPtr cobj){
			CError tmp = (CError)Marshal.PtrToStructure(cobj, typeof(CError));
			tmp.thisObj = cobj;
			Error result = Factory(ref tmp);
			return result;
		}
		private static Error Factory(ref CError cobj) {
			Error tmp = new Error();
			tmp.thisObj = cobj.thisObj;
			MBCRetainError(tmp.thisObj);
			
			tmp.domain = Convert.toCS_String(cobj.domain);
			tmp.code = Convert.toCS_Integer(cobj.code);
			tmp.localizedDescription = Convert.toCS_String(cobj.localizedDescription);
			tmp.description = Convert.toCS_String(cobj.description);
			
			return tmp;
		}
		
		~Error(){
			MBCReleaseError(thisObj);
			thisObj = IntPtr.Zero;
		}
		[StructLayout (LayoutKind.Sequential)]
		public struct Error_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<Error> Factory(IntPtr cobj){
				Error_Array tmp = (Error_Array)Marshal.PtrToStructure(cobj,typeof(Error_Array));
				return tmp.toList();
			}
			private List<Error> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<Error>();
				}
				
				List<Error> tmp = new List<Error>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					Error tmpItem = Convert.toCS_Error(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(Error obj){
			Error.MBCRetainError(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<Error> list){
			Error.Error_Array tmp = new Error.Error_Array();
			tmp.length = (list != null) ? list.Count : 0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = Error.MBCCopyConstructError_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static Error toCS_Error(IntPtr obj){
			return Error.Factory(obj);
		}
		public static List<Error> toCS_Error_Array(IntPtr obj){
			return Error.Error_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class Error {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructError(IntPtr /*Error*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructError_Array(IntPtr /*Error_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainError(IntPtr /*Error*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseError(IntPtr /*Error*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainError_Array(IntPtr /*Error_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseError_Array(IntPtr /*Error_Array*/ objects);

	
	}
#endregion

#region Native Return Points
	public partial class Error {
	}
#endregion
	
#region Static Methods
	public partial class Error {
	}
#endregion
	
#region Instance Methods
	public partial class Error {
	}
#endregion

#region Delegate Callbacks
	public partial class Error {
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
