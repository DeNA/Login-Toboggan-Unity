using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class User {
		static User() {
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
	public partial class User {
		[NonSerialized]
		public IntPtr thisObj; // Pretty Darn Internal
		
		[StructLayout (LayoutKind.Sequential)]
		private struct CUser {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr uid;
			public IntPtr nickname;
			public IntPtr displayName;
			public IntPtr thumbnailUrl;
			public IntPtr aboutMe;
			public short hasApp;
			public Int32 age;
			public Int32 grade;
			public short isFamous;
#if MB_JP
			public IntPtr bloodType;
#endif
#if MB_JP
			public short isVerified;
#endif
#if MB_JP
			public IntPtr jobType;
#endif
#if MB_JP
			public IntPtr birthday;
#endif
			//End of Marshal struct
		}
		
		// Factories!
		public static User Factory(IntPtr cobj){
			CUser tmp = (CUser)Marshal.PtrToStructure(cobj, typeof(CUser));
			tmp.thisObj = cobj;
			User result = Factory(ref tmp);
			return result;
		}
		private static User Factory(ref CUser cobj) {
			User tmp = new User();
			tmp.thisObj = cobj.thisObj;
			MBCRetainUser(tmp.thisObj);
			
			tmp.uid = Convert.toCS_String(cobj.uid);
			tmp.nickname = Convert.toCS_String(cobj.nickname);
			tmp.displayName = Convert.toCS_String(cobj.displayName);
			tmp.thumbnailUrl = Convert.toCS_String(cobj.thumbnailUrl);
			tmp.aboutMe = Convert.toCS_String(cobj.aboutMe);
			tmp.hasApp = Convert.toCS_Bool(cobj.hasApp);
			tmp.age = Convert.toCS_Integer(cobj.age);
			tmp.grade = Convert.toCS_Integer(cobj.grade);
			tmp.isFamous = Convert.toCS_Bool(cobj.isFamous);
#if MB_JP
			tmp.bloodType = Convert.toCS_String(cobj.bloodType);
#endif
#if MB_JP
			tmp.isVerified = Convert.toCS_Bool(cobj.isVerified);
#endif
#if MB_JP
			tmp.jobType = Convert.toCS_String(cobj.jobType);
#endif
#if MB_JP
			tmp.birthday = Convert.toCS_String(cobj.birthday);
#endif
			
			return tmp;
		}
		
		~User(){
			MBCReleaseUser(thisObj);
			thisObj = IntPtr.Zero;
		}
		[StructLayout (LayoutKind.Sequential)]
		public struct User_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<User> Factory(IntPtr cobj){
				User_Array tmp = (User_Array)Marshal.PtrToStructure(cobj,typeof(User_Array));
				return tmp.toList();
			}
			private List<User> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<User>();
				}
				
				List<User> tmp = new List<User>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					User tmpItem = Convert.toCS_User(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(User obj){
			User.MBCRetainUser(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<User> list){
			User.User_Array tmp = new User.User_Array();
			tmp.length = (list != null) ? list.Count : 0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = User.MBCCopyConstructUser_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static User toCS_User(IntPtr obj){
			return User.Factory(obj);
		}
		public static List<User> toCS_User_Array(IntPtr obj){
			return User.User_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class User {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructUser(IntPtr /*User*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructUser_Array(IntPtr /*User_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainUser(IntPtr /*User*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseUser(IntPtr /*User*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainUser_Array(IntPtr /*User_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseUser_Array(IntPtr /*User_Array*/ objects);

	
	}
#endregion

#region Native Return Points
	public partial class User {
	}
#endregion
	
#region Static Methods
	public partial class User {
	}
#endregion
	
#region Instance Methods
	public partial class User {
	}
#endregion

#region Delegate Callbacks
	public partial class User {
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
