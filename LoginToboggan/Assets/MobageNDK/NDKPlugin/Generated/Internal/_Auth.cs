using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class Auth {
		static Auth() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCAuth_authorizeTokenCallbackPingBack(IntPtr token);

	void Auth_authorizeTokenCallbackPing(string token) {
		//print(string.Format("Auth_authorizeTokenCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCAuth_authorizeTokenCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCAuth_executeUserUpgradeCallbackPingBack(IntPtr token);

	void Auth_executeUserUpgradeCallbackPing(string token) {
		//print(string.Format("Auth_executeUserUpgradeCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCAuth_executeUserUpgradeCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCAuth_executeUserUpgradeWithParamsCallbackPingBack(IntPtr token);

	void Auth_executeUserUpgradeWithParamsCallbackPing(string token) {
		//print(string.Format("Auth_executeUserUpgradeWithParamsCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCAuth_executeUserUpgradeWithParamsCallbackPingBack(token_c);
	}

	[DllImport("NDKPlugin")]
	private static extern void MBUserSessionReestablishedNotificationPingBack(IntPtr token);

	void AuthProxies_MBUserSessionReestablishedNotificationPing(string token) {
		//print(string.Format("Auth_CallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBUserSessionReestablishedNotificationPingBack(token_c);
	}

	[DllImport("NDKPlugin")]
	private static extern void MBUserLoginNotificationPingBack(IntPtr token);

	void AuthProxies_MBUserLoginNotificationPing(string token) {
		//print(string.Format("Auth_CallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBUserLoginNotificationPingBack(token_c);
	}

	[DllImport("NDKPlugin")]
	private static extern void MBUserLogoutNotificationPingBack(IntPtr token);

	void AuthProxies_MBUserLogoutNotificationPing(string token) {
		//print(string.Format("Auth_CallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBUserLogoutNotificationPingBack(token_c);
	}

	[DllImport("NDKPlugin")]
	private static extern void MBUserGradeUpgradeNotificationPingBack(IntPtr token);

	void AuthProxies_MBUserGradeUpgradeNotificationPing(string token) {
		//print(string.Format("Auth_CallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBUserGradeUpgradeNotificationPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Auth {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCUserSessionReestablishedNotification_registerObserver(IntPtr context, UserSessionReestablishedNotification.UserSessionReestablishedNotification_dispatcherDelegate cb);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCUserSessionReestablishedNotification_deregisterObserver(IntPtr context);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainUserSessionReestablishedNotification(IntPtr /*UserSessionReestablishedNotification*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseUserSessionReestablishedNotification(IntPtr /*UserSessionReestablishedNotification*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCUserLoginNotification_registerObserver(IntPtr context, UserLoginNotification.UserLoginNotification_dispatcherDelegate cb);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCUserLoginNotification_deregisterObserver(IntPtr context);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainUserLoginNotification(IntPtr /*UserLoginNotification*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseUserLoginNotification(IntPtr /*UserLoginNotification*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCUserLogoutNotification_registerObserver(IntPtr context, UserLogoutNotification.UserLogoutNotification_dispatcherDelegate cb);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCUserLogoutNotification_deregisterObserver(IntPtr context);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainUserLogoutNotification(IntPtr /*UserLogoutNotification*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseUserLogoutNotification(IntPtr /*UserLogoutNotification*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCUserGradeUpgradeNotification_registerObserver(IntPtr context, UserGradeUpgradeNotification.UserGradeUpgradeNotification_dispatcherDelegate cb);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCUserGradeUpgradeNotification_deregisterObserver(IntPtr context);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainUserGradeUpgradeNotification(IntPtr /*UserGradeUpgradeNotification*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseUserGradeUpgradeNotification(IntPtr /*UserGradeUpgradeNotification*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAuth_authorizeToken(IntPtr input_token, authorizeToken_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAuth_executeUserUpgrade(executeUserUpgrade_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAuth_executeUserUpgradeWithParams(IntPtr input_keys, IntPtr input_values, executeUserUpgradeWithParams_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class Auth {
		private delegate void authorizeToken_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_verifier, IntPtr context);
		[MonoPInvokeCallback (typeof (authorizeToken_onCompleteCallbackDispatcherDelegate))]
		private static void authorizeToken_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_verifier, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			String verifier = null;
			if (input_verifier != IntPtr.Zero){
				verifier = Convert.toCS_String(input_verifier);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("authorizeToken callback about to invoke!");
				try {
					authorizeToken_onCompleteCallback del = (authorizeToken_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  verifier );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("authorizeToken finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void executeUserUpgrade_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (executeUserUpgrade_onCompleteCallbackDispatcherDelegate))]
		private static void executeUserUpgrade_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("executeUserUpgrade callback about to invoke!");
				try {
					executeUserUpgrade_onCompleteCallback del = (executeUserUpgrade_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("executeUserUpgrade finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void executeUserUpgradeWithParams_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (executeUserUpgradeWithParams_onCompleteCallbackDispatcherDelegate))]
		private static void executeUserUpgradeWithParams_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("executeUserUpgradeWithParams callback about to invoke!");
				try {
					executeUserUpgradeWithParams_onCompleteCallback del = (executeUserUpgradeWithParams_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("executeUserUpgradeWithParams finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		

		public partial class UserSessionReestablishedNotification {
			
			[StructLayout (LayoutKind.Sequential)]
			private struct CUserSessionReestablishedNotification {
				public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
				public IntPtr thisObj; // ALSO VERY INTERNAL
						
				//End of Marshal struct
			}
			// Factories!
			public static UserSessionReestablishedNotification Factory(IntPtr cobj){
				CUserSessionReestablishedNotification tmp = (CUserSessionReestablishedNotification)Marshal.PtrToStructure(cobj, typeof(CUserSessionReestablishedNotification));
				UserSessionReestablishedNotification result = Factory(ref tmp);
				return result;
			}
			private static UserSessionReestablishedNotification Factory(ref CUserSessionReestablishedNotification cobj) {
				UserSessionReestablishedNotification tmp = new UserSessionReestablishedNotification();
				
				
				return tmp;
			}
			
			~UserSessionReestablishedNotification(){
				
			}
			
			public delegate void UserSessionReestablishedNotification_dispatcherDelegate(IntPtr context, IntPtr notification);
			[MonoPInvokeCallback (typeof (UserSessionReestablishedNotification_dispatcherDelegate))]
			public static void UserSessionReestablishedNotification_dispatcher(IntPtr context, IntPtr cobj) {
				UserSessionReestablishedNotification notification = Convert.toCS_UserSessionReestablishedNotification(cobj);
				try {
					UserSessionReestablishedNotificationDelegate del = (UserSessionReestablishedNotificationDelegate)UserSessionReestablished_observers[context.ToInt32()];
					del(notification);
				} catch ( Exception e) {
					MobageLogger.exceptionLog(e);
				}
			}
		}

		public partial class UserLoginNotification {
			
			[StructLayout (LayoutKind.Sequential)]
			private struct CUserLoginNotification {
				public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
				public IntPtr thisObj; // ALSO VERY INTERNAL
						
				//End of Marshal struct
			}
			// Factories!
			public static UserLoginNotification Factory(IntPtr cobj){
				CUserLoginNotification tmp = (CUserLoginNotification)Marshal.PtrToStructure(cobj, typeof(CUserLoginNotification));
				UserLoginNotification result = Factory(ref tmp);
				return result;
			}
			private static UserLoginNotification Factory(ref CUserLoginNotification cobj) {
				UserLoginNotification tmp = new UserLoginNotification();
				
				
				return tmp;
			}
			
			~UserLoginNotification(){
				
			}
			
			public delegate void UserLoginNotification_dispatcherDelegate(IntPtr context, IntPtr notification);
			[MonoPInvokeCallback (typeof (UserLoginNotification_dispatcherDelegate))]
			public static void UserLoginNotification_dispatcher(IntPtr context, IntPtr cobj) {
				UserLoginNotification notification = Convert.toCS_UserLoginNotification(cobj);
				try {
					UserLoginNotificationDelegate del = (UserLoginNotificationDelegate)UserLogin_observers[context.ToInt32()];
					del(notification);
				} catch ( Exception e) {
					MobageLogger.exceptionLog(e);
				}
			}
		}

		public partial class UserLogoutNotification {
			
			[StructLayout (LayoutKind.Sequential)]
			private struct CUserLogoutNotification {
				public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
				public IntPtr thisObj; // ALSO VERY INTERNAL
						
				//End of Marshal struct
			}
			// Factories!
			public static UserLogoutNotification Factory(IntPtr cobj){
				CUserLogoutNotification tmp = (CUserLogoutNotification)Marshal.PtrToStructure(cobj, typeof(CUserLogoutNotification));
				UserLogoutNotification result = Factory(ref tmp);
				return result;
			}
			private static UserLogoutNotification Factory(ref CUserLogoutNotification cobj) {
				UserLogoutNotification tmp = new UserLogoutNotification();
				
				
				return tmp;
			}
			
			~UserLogoutNotification(){
				
			}
			
			public delegate void UserLogoutNotification_dispatcherDelegate(IntPtr context, IntPtr notification);
			[MonoPInvokeCallback (typeof (UserLogoutNotification_dispatcherDelegate))]
			public static void UserLogoutNotification_dispatcher(IntPtr context, IntPtr cobj) {
				UserLogoutNotification notification = Convert.toCS_UserLogoutNotification(cobj);
				try {
					UserLogoutNotificationDelegate del = (UserLogoutNotificationDelegate)UserLogout_observers[context.ToInt32()];
					del(notification);
				} catch ( Exception e) {
					MobageLogger.exceptionLog(e);
				}
			}
		}

		public partial class UserGradeUpgradeNotification {
			
			[StructLayout (LayoutKind.Sequential)]
			private struct CUserGradeUpgradeNotification {
				public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
				public IntPtr thisObj; // ALSO VERY INTERNAL
						
			public IntPtr previousNickname;
			public Int32 previousGrade;
			public IntPtr currentNickname;
			public Int32 currentGrade;
				//End of Marshal struct
			}
			// Factories!
			public static UserGradeUpgradeNotification Factory(IntPtr cobj){
				CUserGradeUpgradeNotification tmp = (CUserGradeUpgradeNotification)Marshal.PtrToStructure(cobj, typeof(CUserGradeUpgradeNotification));
				UserGradeUpgradeNotification result = Factory(ref tmp);
				return result;
			}
			private static UserGradeUpgradeNotification Factory(ref CUserGradeUpgradeNotification cobj) {
				UserGradeUpgradeNotification tmp = new UserGradeUpgradeNotification();
				
				tmp.previousNickname = Convert.toCS_String(cobj.previousNickname);
				tmp.previousGrade = Convert.toCS_Integer(cobj.previousGrade);
				tmp.currentNickname = Convert.toCS_String(cobj.currentNickname);
				tmp.currentGrade = Convert.toCS_Integer(cobj.currentGrade);
				
				return tmp;
			}
			
			~UserGradeUpgradeNotification(){
				
			}
			
			public delegate void UserGradeUpgradeNotification_dispatcherDelegate(IntPtr context, IntPtr notification);
			[MonoPInvokeCallback (typeof (UserGradeUpgradeNotification_dispatcherDelegate))]
			public static void UserGradeUpgradeNotification_dispatcher(IntPtr context, IntPtr cobj) {
				UserGradeUpgradeNotification notification = Convert.toCS_UserGradeUpgradeNotification(cobj);
				try {
					UserGradeUpgradeNotificationDelegate del = (UserGradeUpgradeNotificationDelegate)UserGradeUpgrade_observers[context.ToInt32()];
					del(notification);
				} catch ( Exception e) {
					MobageLogger.exceptionLog(e);
				}
			}
		}
	}
#endregion
	
#region Static Methods
	public partial class Auth {
		public static void _authorizeToken(String token, authorizeToken_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_token = (IntPtr)Convert.toC(token);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAuth_authorizeToken(out_token, authorizeToken_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_token);
		}
		public static void _executeUserUpgrade(executeUserUpgrade_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAuth_executeUserUpgrade(executeUserUpgrade_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _executeUserUpgradeWithParams(List<String> keys, List<String> values, executeUserUpgradeWithParams_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_keys = (IntPtr)Convert.toC(keys);

			IntPtr out_values = (IntPtr)Convert.toC(values);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAuth_executeUserUpgradeWithParams(out_keys, out_values, executeUserUpgradeWithParams_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_keys);
			Marshal.FreeHGlobal(out_values);
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class Auth {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414


#pragma warning disable 0414
		private static Dictionary<int, Object> UserSessionReestablished_observers = new Dictionary<int, Object>();
		private static Dictionary<Object,int> UserSessionReestablished_reverseObservers = new Dictionary<Object,int>();
		private static int UserSessionReestablishedObserverUIDGenerator = 0;
#pragma warning restore 0414
		private static void UserSessionReestablishedNotificationDelegate_add(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = UserSessionReestablishedObserverUIDGenerator++;
				UserSessionReestablished_observers.Add(identifier, val);
				UserSessionReestablished_reverseObservers.Add(val, identifier);
				MBCUserSessionReestablishedNotification_registerObserver(new IntPtr(identifier), UserSessionReestablishedNotification.UserSessionReestablishedNotification_dispatcher);
		}
		private static void UserSessionReestablishedNotificationDelegte_remove(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = UserSessionReestablished_reverseObservers[val];
				MBCUserSessionReestablishedNotification_deregisterObserver(new IntPtr(identifier));
				UserSessionReestablished_reverseObservers.Remove(val);
				UserSessionReestablished_observers.Remove(identifier);
		}

#pragma warning disable 0414
		private static Dictionary<int, Object> UserLogin_observers = new Dictionary<int, Object>();
		private static Dictionary<Object,int> UserLogin_reverseObservers = new Dictionary<Object,int>();
		private static int UserLoginObserverUIDGenerator = 0;
#pragma warning restore 0414
		private static void UserLoginNotificationDelegate_add(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = UserLoginObserverUIDGenerator++;
				UserLogin_observers.Add(identifier, val);
				UserLogin_reverseObservers.Add(val, identifier);
				MBCUserLoginNotification_registerObserver(new IntPtr(identifier), UserLoginNotification.UserLoginNotification_dispatcher);
		}
		private static void UserLoginNotificationDelegte_remove(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = UserLogin_reverseObservers[val];
				MBCUserLoginNotification_deregisterObserver(new IntPtr(identifier));
				UserLogin_reverseObservers.Remove(val);
				UserLogin_observers.Remove(identifier);
		}

#pragma warning disable 0414
		private static Dictionary<int, Object> UserLogout_observers = new Dictionary<int, Object>();
		private static Dictionary<Object,int> UserLogout_reverseObservers = new Dictionary<Object,int>();
		private static int UserLogoutObserverUIDGenerator = 0;
#pragma warning restore 0414
		private static void UserLogoutNotificationDelegate_add(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = UserLogoutObserverUIDGenerator++;
				UserLogout_observers.Add(identifier, val);
				UserLogout_reverseObservers.Add(val, identifier);
				MBCUserLogoutNotification_registerObserver(new IntPtr(identifier), UserLogoutNotification.UserLogoutNotification_dispatcher);
		}
		private static void UserLogoutNotificationDelegte_remove(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = UserLogout_reverseObservers[val];
				MBCUserLogoutNotification_deregisterObserver(new IntPtr(identifier));
				UserLogout_reverseObservers.Remove(val);
				UserLogout_observers.Remove(identifier);
		}

#pragma warning disable 0414
		private static Dictionary<int, Object> UserGradeUpgrade_observers = new Dictionary<int, Object>();
		private static Dictionary<Object,int> UserGradeUpgrade_reverseObservers = new Dictionary<Object,int>();
		private static int UserGradeUpgradeObserverUIDGenerator = 0;
#pragma warning restore 0414
		private static void UserGradeUpgradeNotificationDelegate_add(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = UserGradeUpgradeObserverUIDGenerator++;
				UserGradeUpgrade_observers.Add(identifier, val);
				UserGradeUpgrade_reverseObservers.Add(val, identifier);
				MBCUserGradeUpgradeNotification_registerObserver(new IntPtr(identifier), UserGradeUpgradeNotification.UserGradeUpgradeNotification_dispatcher);
		}
		private static void UserGradeUpgradeNotificationDelegte_remove(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = UserGradeUpgrade_reverseObservers[val];
				MBCUserGradeUpgradeNotification_deregisterObserver(new IntPtr(identifier));
				UserGradeUpgrade_reverseObservers.Remove(val);
				UserGradeUpgrade_observers.Remove(identifier);
		}
	}
#endregion
	
	public partial class Convert {

		public static Auth.UserSessionReestablishedNotification toCS_UserSessionReestablishedNotification(IntPtr obj){
			return Auth.UserSessionReestablishedNotification.Factory(obj);
		}

		public static Auth.UserLoginNotification toCS_UserLoginNotification(IntPtr obj){
			return Auth.UserLoginNotification.Factory(obj);
		}

		public static Auth.UserLogoutNotification toCS_UserLogoutNotification(IntPtr obj){
			return Auth.UserLogoutNotification.Factory(obj);
		}

		public static Auth.UserGradeUpgradeNotification toCS_UserGradeUpgradeNotification(IntPtr obj){
			return Auth.UserGradeUpgradeNotification.Factory(obj);
		}

	}
	
}


#endif	// !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
