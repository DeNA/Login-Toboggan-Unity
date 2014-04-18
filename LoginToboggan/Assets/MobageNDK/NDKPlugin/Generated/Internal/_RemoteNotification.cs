using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class RemoteNotification {
		static RemoteNotification() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCRemoteNotification_sendToUserCallbackPingBack(IntPtr token);

	void RemoteNotification_sendToUserCallbackPing(string token) {
		//print(string.Format("RemoteNotification_sendToUserCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCRemoteNotification_sendToUserCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCRemoteNotification_getRemoteNotificationsEnabledCallbackPingBack(IntPtr token);

	void RemoteNotification_getRemoteNotificationsEnabledCallbackPing(string token) {
		//print(string.Format("RemoteNotification_getRemoteNotificationsEnabledCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCRemoteNotification_getRemoteNotificationsEnabledCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCRemoteNotification_setRemoteNotificationsEnabledCallbackPingBack(IntPtr token);

	void RemoteNotification_setRemoteNotificationsEnabledCallbackPing(string token) {
		//print(string.Format("RemoteNotification_setRemoteNotificationsEnabledCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCRemoteNotification_setRemoteNotificationsEnabledCallbackPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class RemoteNotification {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCRemoteNotification_sendToUser(IntPtr input_user, IntPtr input_message, Int32 input_badge, IntPtr input_sound, IntPtr input_collapseKey, IntPtr input_style, IntPtr input_iconUrl, IntPtr input_extraKeys, IntPtr input_extraValues, sendToUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCRemoteNotification_getRemoteNotificationsEnabled(getRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCRemoteNotification_setRemoteNotificationsEnabled(bool input_enabled, setRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class RemoteNotification {
		private delegate void sendToUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_response, IntPtr context);
		[MonoPInvokeCallback (typeof (sendToUser_onCompleteCallbackDispatcherDelegate))]
		private static void sendToUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_response, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			RemoteNotificationResponse response = null;
			if (input_response != IntPtr.Zero){
				response = Convert.toCS_RemoteNotificationResponse(input_response);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("sendToUser callback about to invoke!");
				try {
					sendToUser_onCompleteCallback del = (sendToUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  response );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("sendToUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, bool input_canBeNotified, IntPtr context);
		[MonoPInvokeCallback (typeof (getRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate))]
		private static void getRemoteNotificationsEnabled_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, bool input_canBeNotified, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			bool canBeNotified = input_canBeNotified;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getRemoteNotificationsEnabled callback about to invoke!");
				try {
					getRemoteNotificationsEnabled_onCompleteCallback del = (getRemoteNotificationsEnabled_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  canBeNotified );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getRemoteNotificationsEnabled finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void setRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (setRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate))]
		private static void setRemoteNotificationsEnabled_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("setRemoteNotificationsEnabled callback about to invoke!");
				try {
					setRemoteNotificationsEnabled_onCompleteCallback del = (setRemoteNotificationsEnabled_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("setRemoteNotificationsEnabled finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion
	
#region Static Methods
	public partial class RemoteNotification {
		public static void _sendToUser(User user, String message, Int32 badge, String sound, String collapseKey, String style, String iconUrl, List<String> extraKeys, List<String> extraValues, sendToUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			IntPtr out_message = (IntPtr)Convert.toC(message);

			Int32 out_badge = badge;

			IntPtr out_sound = (IntPtr)Convert.toC(sound);

			IntPtr out_collapseKey = (IntPtr)Convert.toC(collapseKey);

			IntPtr out_style = (IntPtr)Convert.toC(style);

			IntPtr out_iconUrl = (IntPtr)Convert.toC(iconUrl);

			IntPtr out_extraKeys = (IntPtr)Convert.toC(extraKeys);

			IntPtr out_extraValues = (IntPtr)Convert.toC(extraValues);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCRemoteNotification_sendToUser(out_user, out_message, out_badge, out_sound, out_collapseKey, out_style, out_iconUrl, out_extraKeys, out_extraValues, sendToUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
			Marshal.FreeHGlobal(out_message);
			Marshal.FreeHGlobal(out_sound);
			Marshal.FreeHGlobal(out_collapseKey);
			Marshal.FreeHGlobal(out_style);
			Marshal.FreeHGlobal(out_iconUrl);
			Marshal.FreeHGlobal(out_extraKeys);
			Marshal.FreeHGlobal(out_extraValues);
		}
		public static void _getRemoteNotificationsEnabled(getRemoteNotificationsEnabled_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCRemoteNotification_getRemoteNotificationsEnabled(getRemoteNotificationsEnabled_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _setRemoteNotificationsEnabled(bool enabled, setRemoteNotificationsEnabled_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			bool out_enabled = enabled;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCRemoteNotification_setRemoteNotificationsEnabled(out_enabled, setRemoteNotificationsEnabled_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class RemoteNotification {
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
