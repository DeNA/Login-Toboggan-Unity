using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class People {
		static People() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCPeople_getCurrentUserCallbackPingBack(IntPtr token);

	void People_getCurrentUserCallbackPing(string token) {
		//print(string.Format("People_getCurrentUserCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCPeople_getCurrentUserCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCPeople_getUserForIdCallbackPingBack(IntPtr token);

	void People_getUserForIdCallbackPing(string token) {
		//print(string.Format("People_getUserForIdCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCPeople_getUserForIdCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCPeople_getUsersForIdsCallbackPingBack(IntPtr token);

	void People_getUsersForIdsCallbackPing(string token) {
		//print(string.Format("People_getUsersForIdsCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCPeople_getUsersForIdsCallbackPingBack(token_c);
	}
#if MB_JP
	[DllImport("NDKPlugin")]
	private static extern void MBCPeople_getFriendsForUserCallbackPingBack(IntPtr token);

	void People_getFriendsForUserCallbackPing(string token) {
		//print(string.Format("People_getFriendsForUserCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCPeople_getFriendsForUserCallbackPingBack(token_c);
	}
#endif //MB_JP
#if MB_JP
	[DllImport("NDKPlugin")]
	private static extern void MBCPeople_getFriendsWithGameForUserCallbackPingBack(IntPtr token);

	void People_getFriendsWithGameForUserCallbackPing(string token) {
		//print(string.Format("People_getFriendsWithGameForUserCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCPeople_getFriendsWithGameForUserCallbackPingBack(token_c);
	}
#endif //MB_JP

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class People {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getCurrentUser(getCurrentUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getUserForId(IntPtr input_userId, getUserForId_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getUsersForIds(IntPtr input_userIds, getUsersForIds_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#if MB_JP
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getFriendsForUser(IntPtr input_user, Int32 input_howMany, Int32 input_offset, getFriendsForUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_JP
#if MB_JP
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getFriendsWithGameForUser(IntPtr input_user, Int32 input_howMany, Int32 input_offset, getFriendsWithGameForUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_JP
	
	}
#endregion

#region Native Return Points
	public partial class People {
		private delegate void getCurrentUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_currentUser, IntPtr context);
		[MonoPInvokeCallback (typeof (getCurrentUser_onCompleteCallbackDispatcherDelegate))]
		private static void getCurrentUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_currentUser, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			User currentUser = null;
			if (input_currentUser != IntPtr.Zero){
				currentUser = Convert.toCS_User(input_currentUser);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getCurrentUser callback about to invoke!");
				try {
					getCurrentUser_onCompleteCallback del = (getCurrentUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  currentUser );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getCurrentUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getUserForId_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_user, IntPtr context);
		[MonoPInvokeCallback (typeof (getUserForId_onCompleteCallbackDispatcherDelegate))]
		private static void getUserForId_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_user, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			User user = null;
			if (input_user != IntPtr.Zero){
				user = Convert.toCS_User(input_user);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getUserForId callback about to invoke!");
				try {
					getUserForId_onCompleteCallback del = (getUserForId_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  user );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getUserForId finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getUsersForIds_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_users, IntPtr context);
		[MonoPInvokeCallback (typeof (getUsersForIds_onCompleteCallbackDispatcherDelegate))]
		private static void getUsersForIds_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_users, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<User> users = null;
			if (input_users != IntPtr.Zero){
				users = Convert.toCS_User_Array(input_users);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getUsersForIds callback about to invoke!");
				try {
					getUsersForIds_onCompleteCallback del = (getUsersForIds_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  users );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getUsersForIds finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#if MB_JP
		private delegate void getFriendsForUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_users, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context);
		[MonoPInvokeCallback (typeof (getFriendsForUser_onCompleteCallbackDispatcherDelegate))]
		private static void getFriendsForUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_users, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<User> users = null;
			if (input_users != IntPtr.Zero){
				users = Convert.toCS_User_Array(input_users);
			}
			Int32 startOffset = input_startOffset;
			Int32 totalPossibleResultCount = input_totalPossibleResultCount;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getFriendsForUser callback about to invoke!");
				try {
					getFriendsForUser_onCompleteCallback del = (getFriendsForUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  users,  startOffset,  totalPossibleResultCount );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getFriendsForUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_JP
#if MB_JP
		private delegate void getFriendsWithGameForUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_users, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context);
		[MonoPInvokeCallback (typeof (getFriendsWithGameForUser_onCompleteCallbackDispatcherDelegate))]
		private static void getFriendsWithGameForUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_users, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<User> users = null;
			if (input_users != IntPtr.Zero){
				users = Convert.toCS_User_Array(input_users);
			}
			Int32 startOffset = input_startOffset;
			Int32 totalPossibleResultCount = input_totalPossibleResultCount;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getFriendsWithGameForUser callback about to invoke!");
				try {
					getFriendsWithGameForUser_onCompleteCallback del = (getFriendsWithGameForUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  users,  startOffset,  totalPossibleResultCount );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getFriendsWithGameForUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_JP
	}
#endregion
	
#region Static Methods
	public partial class People {
		public static void _getCurrentUser(getCurrentUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getCurrentUser(getCurrentUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _getUserForId(String userId, getUserForId_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_userId = (IntPtr)Convert.toC(userId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getUserForId(out_userId, getUserForId_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_userId);
		}
		public static void _getUsersForIds(List<String> userIds, getUsersForIds_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_userIds = (IntPtr)Convert.toC(userIds);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getUsersForIds(out_userIds, getUsersForIds_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_userIds);
		}
#if MB_JP
		public static void _getFriendsForUser(User user, Int32 howMany, Int32 offset, getFriendsForUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			Int32 out_howMany = howMany;

			Int32 out_offset = offset;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getFriendsForUser(out_user, out_howMany, out_offset, getFriendsForUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
		}
#endif // MB_JP
#if MB_JP
		public static void _getFriendsWithGameForUser(User user, Int32 howMany, Int32 offset, getFriendsWithGameForUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			Int32 out_howMany = howMany;

			Int32 out_offset = offset;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getFriendsWithGameForUser(out_user, out_howMany, out_offset, getFriendsWithGameForUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
		}
#endif // MB_JP
	}
#endregion
	

#region Delegate Callbacks
	public partial class People {
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
