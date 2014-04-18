using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class SocialService {
		static SocialService() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
#if MB_JP
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_openFriendPickerCallbackPingBack(IntPtr token);

	void SocialService_openFriendPickerCallbackPing(string token) {
		//print(string.Format("SocialService_openFriendPickerCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_openFriendPickerCallbackPingBack(token_c);
	}
#endif //MB_JP
#if MB_JP
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_openDocumentCallbackPingBack(IntPtr token);

	void SocialService_openDocumentCallbackPing(string token) {
		//print(string.Format("SocialService_openDocumentCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_openDocumentCallbackPingBack(token_c);
	}
#endif //MB_JP
#if MB_KO
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_openDocumentCallbackPingBack(IntPtr token);

	void SocialService_openDocumentCallbackPing(string token) {
		//print(string.Format("SocialService_openDocumentCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_openDocumentCallbackPingBack(token_c);
	}
#endif //MB_KO
#if MB_JP
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_openDiaryWriterCallbackPingBack(IntPtr token);

	void SocialService_openDiaryWriterCallbackPing(string token) {
		//print(string.Format("SocialService_openDiaryWriterCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_openDiaryWriterCallbackPingBack(token_c);
	}
#endif //MB_JP
#if MB_KO
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_openDiaryWriterCallbackPingBack(IntPtr token);

	void SocialService_openDiaryWriterCallbackPing(string token) {
		//print(string.Format("SocialService_openDiaryWriterCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_openDiaryWriterCallbackPingBack(token_c);
	}
#endif //MB_KO
#if MB_JP
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_openMinimailSenderCallbackPingBack(IntPtr token);

	void SocialService_openMinimailSenderCallbackPing(string token) {
		//print(string.Format("SocialService_openMinimailSenderCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_openMinimailSenderCallbackPingBack(token_c);
	}
#endif //MB_JP
#if MB_KO
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_openMinimailSenderCallbackPingBack(IntPtr token);

	void SocialService_openMinimailSenderCallbackPing(string token) {
		//print(string.Format("SocialService_openMinimailSenderCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_openMinimailSenderCallbackPingBack(token_c);
	}
#endif //MB_KO
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_executeLoginCallbackPingBack(IntPtr token);

	void SocialService_executeLoginCallbackPing(string token) {
		//print(string.Format("SocialService_executeLoginCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_executeLoginCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_executeLoginWithParamsCallbackPingBack(IntPtr token);

	void SocialService_executeLoginWithParamsCallbackPing(string token) {
		//print(string.Format("SocialService_executeLoginWithParamsCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_executeLoginWithParamsCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_executeLogoutCallbackPingBack(IntPtr token);

	void SocialService_executeLogoutCallbackPing(string token) {
		//print(string.Format("SocialService_executeLogoutCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_executeLogoutCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_showBalanceButtonCallbackPingBack(IntPtr token);

	void SocialService_showBalanceButtonCallbackPing(string token) {
		//print(string.Format("SocialService_showBalanceButtonCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_showBalanceButtonCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_getCurrentBalanceCallbackPingBack(IntPtr token);

	void SocialService_getCurrentBalanceCallbackPing(string token) {
		//print(string.Format("SocialService_getCurrentBalanceCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_getCurrentBalanceCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_getCurrentBalanceDetailsCallbackPingBack(IntPtr token);

	void SocialService_getCurrentBalanceDetailsCallbackPing(string token) {
		//print(string.Format("SocialService_getCurrentBalanceDetailsCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_getCurrentBalanceDetailsCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_showPromotionsCallbackPingBack(IntPtr token);

	void SocialService_showPromotionsCallbackPing(string token) {
		//print(string.Format("SocialService_showPromotionsCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_showPromotionsCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_checkFacebookStatusCallbackPingBack(IntPtr token);

	void SocialService_checkFacebookStatusCallbackPing(string token) {
		//print(string.Format("SocialService_checkFacebookStatusCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_checkFacebookStatusCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_getFacebookIdCallbackPingBack(IntPtr token);

	void SocialService_getFacebookIdCallbackPing(string token) {
		//print(string.Format("SocialService_getFacebookIdCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_getFacebookIdCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_getASCItemsCallbackPingBack(IntPtr token);

	void SocialService_getASCItemsCallbackPing(string token) {
		//print(string.Format("SocialService_getASCItemsCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_getASCItemsCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_purchaseASCItemCallbackPingBack(IntPtr token);

	void SocialService_purchaseASCItemCallbackPing(string token) {
		//print(string.Format("SocialService_purchaseASCItemCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_purchaseASCItemCallbackPingBack(token_c);
	}
	[DllImport("NDKPlugin")]
	private static extern void MBCSocialService_giftASCCallbackPingBack(IntPtr token);

	void SocialService_giftASCCallbackPing(string token) {
		//print(string.Format("SocialService_giftASCCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCSocialService_giftASCCallbackPingBack(token_c);
	}

	[DllImport("NDKPlugin")]
	private static extern void MBBalanceUpdateNotificationPingBack(IntPtr token);

	void SocialServiceProxies_MBBalanceUpdateNotificationPing(string token) {
		//print(string.Format("SocialService_CallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBBalanceUpdateNotificationPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
	
	public partial class Convert {
		public static bool IsGravity(int intFlag){return (!((intFlag < 0) || (intFlag > 3))); }
		public static int toC(Gravity enumValue){return (int)enumValue;}
		public static Gravity toCS_Gravity(int enumValue){return (Gravity)enumValue;}
	}
#endregion
	

#region Native Method Imports
	public partial class SocialService {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCBalanceUpdateNotification_registerObserver(IntPtr context, BalanceUpdateNotification.BalanceUpdateNotification_dispatcherDelegate cb);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
	public static extern void MBCBalanceUpdateNotification_deregisterObserver(IntPtr context);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainBalanceUpdateNotification(IntPtr /*BalanceUpdateNotification*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseBalanceUpdateNotification(IntPtr /*BalanceUpdateNotification*/ obj);

#if MB_JP
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openFriendPicker(Int32 input_maxFriendsToSelect, openFriendPicker_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_JP
#if MB_JP
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openDocument(IntPtr input_path, openDocument_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_JP
#if MB_KO
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openDocument(IntPtr input_path, openDocument_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_KO
#if MB_JP
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openDiaryWriter(IntPtr input_subject, IntPtr input_body, IntPtr input_imageUrl, openDiaryWriter_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_JP
#if MB_KO
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openDiaryWriter(IntPtr input_subject, IntPtr input_body, IntPtr input_imageUrl, openDiaryWriter_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_KO
#if MB_JP
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openMinimailSender(IntPtr input_userId, IntPtr input_subject, IntPtr input_body, openMinimailSender_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_JP
#if MB_KO
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openMinimailSender(IntPtr input_userId, IntPtr input_subject, IntPtr input_body, openMinimailSender_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_KO
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_executeLogin(executeLogin_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_executeLoginWithParams(IntPtr input_keys, IntPtr input_values, executeLoginWithParams_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_executeLogout(executeLogout_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openUserProfile(IntPtr input_user, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_showCommunityUI(IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_showCommunityButton(Int32 input_gravity, IntPtr input_theme, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_hideCommunityButton(IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openBankDialog(IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_showBalanceButton(Int32 input_x, Int32 input_y, Int32 input_width, Int32 input_height, showBalanceButton_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_getCurrentBalance(getCurrentBalance_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_hideBalanceButton(IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_getCurrentBalanceDetails(Int32 input_imageHeight, getCurrentBalanceDetails_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_showPromotions(IntPtr input_keys, IntPtr input_values, showPromotions_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_checkFacebookStatus(checkFacebookStatus_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_getFacebookId(getFacebookId_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_getASCItems(getASCItems_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_purchaseASCItem(IntPtr input_item, purchaseASCItem_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_giftASC(IntPtr input_giftCode, giftASC_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class SocialService {
#if MB_JP
		private delegate void openFriendPicker_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_pickedFriends, IntPtr input_invitedFriends, IntPtr context);
		[MonoPInvokeCallback (typeof (openFriendPicker_onCompleteCallbackDispatcherDelegate))]
		private static void openFriendPicker_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_pickedFriends, IntPtr input_invitedFriends, IntPtr context)
		{
			DismissableAPIStatus status = Convert.toCS_DismissableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<User> pickedFriends = null;
			if (input_pickedFriends != IntPtr.Zero){
				pickedFriends = Convert.toCS_User_Array(input_pickedFriends);
			}
			List<User> invitedFriends = null;
			if (input_invitedFriends != IntPtr.Zero){
				invitedFriends = Convert.toCS_User_Array(input_invitedFriends);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openFriendPicker callback about to invoke!");
				try {
					openFriendPicker_onCompleteCallback del = (openFriendPicker_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  pickedFriends,  invitedFriends );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openFriendPicker finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_JP
#if MB_JP
		private delegate void openDocument_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_Error, IntPtr context);
		[MonoPInvokeCallback (typeof (openDocument_onCompleteCallbackDispatcherDelegate))]
		private static void openDocument_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_Error, IntPtr context)
		{
			DismissableAPIStatus status = Convert.toCS_DismissableAPIStatus(input_status);
			Error Error = null;
			if (input_Error != IntPtr.Zero){
				Error = Convert.toCS_Error(input_Error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openDocument callback about to invoke!");
				try {
					openDocument_onCompleteCallback del = (openDocument_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  Error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openDocument finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_JP
#if MB_KO
		private delegate void openDocument_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_Error, IntPtr context);
		[MonoPInvokeCallback (typeof (openDocument_onCompleteCallbackDispatcherDelegate))]
		private static void openDocument_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_Error, IntPtr context)
		{
			DismissableAPIStatus status = Convert.toCS_DismissableAPIStatus(input_status);
			Error Error = null;
			if (input_Error != IntPtr.Zero){
				Error = Convert.toCS_Error(input_Error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openDocument callback about to invoke!");
				try {
					openDocument_onCompleteCallback del = (openDocument_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  Error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openDocument finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_KO
#if MB_JP
		private delegate void openDiaryWriter_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_Error, bool input_isWrote, IntPtr context);
		[MonoPInvokeCallback (typeof (openDiaryWriter_onCompleteCallbackDispatcherDelegate))]
		private static void openDiaryWriter_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_Error, bool input_isWrote, IntPtr context)
		{
			DismissableAPIStatus status = Convert.toCS_DismissableAPIStatus(input_status);
			Error Error = null;
			if (input_Error != IntPtr.Zero){
				Error = Convert.toCS_Error(input_Error);
			}
			bool isWrote = input_isWrote;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openDiaryWriter callback about to invoke!");
				try {
					openDiaryWriter_onCompleteCallback del = (openDiaryWriter_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  Error,  isWrote );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openDiaryWriter finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_JP
#if MB_KO
		private delegate void openDiaryWriter_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_Error, bool input_isWrote, IntPtr context);
		[MonoPInvokeCallback (typeof (openDiaryWriter_onCompleteCallbackDispatcherDelegate))]
		private static void openDiaryWriter_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_Error, bool input_isWrote, IntPtr context)
		{
			DismissableAPIStatus status = Convert.toCS_DismissableAPIStatus(input_status);
			Error Error = null;
			if (input_Error != IntPtr.Zero){
				Error = Convert.toCS_Error(input_Error);
			}
			bool isWrote = input_isWrote;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openDiaryWriter callback about to invoke!");
				try {
					openDiaryWriter_onCompleteCallback del = (openDiaryWriter_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  Error,  isWrote );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openDiaryWriter finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_KO
#if MB_JP
		private delegate void openMinimailSender_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_Error, bool input_isSent, IntPtr context);
		[MonoPInvokeCallback (typeof (openMinimailSender_onCompleteCallbackDispatcherDelegate))]
		private static void openMinimailSender_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_Error, bool input_isSent, IntPtr context)
		{
			DismissableAPIStatus status = Convert.toCS_DismissableAPIStatus(input_status);
			Error Error = null;
			if (input_Error != IntPtr.Zero){
				Error = Convert.toCS_Error(input_Error);
			}
			bool isSent = input_isSent;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openMinimailSender callback about to invoke!");
				try {
					openMinimailSender_onCompleteCallback del = (openMinimailSender_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  Error,  isSent );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openMinimailSender finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_JP
#if MB_KO
		private delegate void openMinimailSender_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_Error, bool input_isSent, IntPtr context);
		[MonoPInvokeCallback (typeof (openMinimailSender_onCompleteCallbackDispatcherDelegate))]
		private static void openMinimailSender_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_Error, bool input_isSent, IntPtr context)
		{
			DismissableAPIStatus status = Convert.toCS_DismissableAPIStatus(input_status);
			Error Error = null;
			if (input_Error != IntPtr.Zero){
				Error = Convert.toCS_Error(input_Error);
			}
			bool isSent = input_isSent;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openMinimailSender callback about to invoke!");
				try {
					openMinimailSender_onCompleteCallback del = (openMinimailSender_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  Error,  isSent );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openMinimailSender finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_KO
		private delegate void executeLogin_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (executeLogin_onCompleteCallbackDispatcherDelegate))]
		private static void executeLogin_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("executeLogin callback about to invoke!");
				try {
					executeLogin_onCompleteCallback del = (executeLogin_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("executeLogin finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void executeLoginWithParams_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (executeLoginWithParams_onCompleteCallbackDispatcherDelegate))]
		private static void executeLoginWithParams_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("executeLoginWithParams callback about to invoke!");
				try {
					executeLoginWithParams_onCompleteCallback del = (executeLoginWithParams_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("executeLoginWithParams finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void executeLogout_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (executeLogout_onCompleteCallbackDispatcherDelegate))]
		private static void executeLogout_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("executeLogout callback about to invoke!");
				try {
					executeLogout_onCompleteCallback del = (executeLogout_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("executeLogout finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void showBalanceButton_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (showBalanceButton_onCompleteCallbackDispatcherDelegate))]
		private static void showBalanceButton_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("showBalanceButton callback about to invoke!");
				try {
					showBalanceButton_onCompleteCallback del = (showBalanceButton_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("showBalanceButton finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getCurrentBalance_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_currencyName, IntPtr input_currencyIconUrl, Int32 input_balance, IntPtr context);
		[MonoPInvokeCallback (typeof (getCurrentBalance_onCompleteCallbackDispatcherDelegate))]
		private static void getCurrentBalance_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_currencyName, IntPtr input_currencyIconUrl, Int32 input_balance, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			String currencyName = null;
			if (input_currencyName != IntPtr.Zero){
				currencyName = Convert.toCS_String(input_currencyName);
			}
			String currencyIconUrl = null;
			if (input_currencyIconUrl != IntPtr.Zero){
				currencyIconUrl = Convert.toCS_String(input_currencyIconUrl);
			}
			Int32 balance = input_balance;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getCurrentBalance callback about to invoke!");
				try {
					getCurrentBalance_onCompleteCallback del = (getCurrentBalance_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  currencyName,  currencyIconUrl,  balance );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getCurrentBalance finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getCurrentBalanceDetails_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, Int32 input_imageWidth, IntPtr input_currencyName, IntPtr input_currencyIconUrl, IntPtr input_balanceImageUrl, IntPtr context);
		[MonoPInvokeCallback (typeof (getCurrentBalanceDetails_onCompleteCallbackDispatcherDelegate))]
		private static void getCurrentBalanceDetails_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, Int32 input_imageWidth, IntPtr input_currencyName, IntPtr input_currencyIconUrl, IntPtr input_balanceImageUrl, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Int32 imageWidth = input_imageWidth;
			String currencyName = null;
			if (input_currencyName != IntPtr.Zero){
				currencyName = Convert.toCS_String(input_currencyName);
			}
			String currencyIconUrl = null;
			if (input_currencyIconUrl != IntPtr.Zero){
				currencyIconUrl = Convert.toCS_String(input_currencyIconUrl);
			}
			String balanceImageUrl = null;
			if (input_balanceImageUrl != IntPtr.Zero){
				balanceImageUrl = Convert.toCS_String(input_balanceImageUrl);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getCurrentBalanceDetails callback about to invoke!");
				try {
					getCurrentBalanceDetails_onCompleteCallback del = (getCurrentBalanceDetails_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  imageWidth,  currencyName,  currencyIconUrl,  balanceImageUrl );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getCurrentBalanceDetails finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void showPromotions_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (showPromotions_onCompleteCallbackDispatcherDelegate))]
		private static void showPromotions_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			DismissableAPIStatus status = Convert.toCS_DismissableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("showPromotions callback about to invoke!");
				try {
					showPromotions_onCompleteCallback del = (showPromotions_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("showPromotions finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void checkFacebookStatus_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_userId, IntPtr input_facebookId, IntPtr input_accessToken, IntPtr context);
		[MonoPInvokeCallback (typeof (checkFacebookStatus_onCompleteCallbackDispatcherDelegate))]
		private static void checkFacebookStatus_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_userId, IntPtr input_facebookId, IntPtr input_accessToken, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			String userId = null;
			if (input_userId != IntPtr.Zero){
				userId = Convert.toCS_String(input_userId);
			}
			String facebookId = null;
			if (input_facebookId != IntPtr.Zero){
				facebookId = Convert.toCS_String(input_facebookId);
			}
			String accessToken = null;
			if (input_accessToken != IntPtr.Zero){
				accessToken = Convert.toCS_String(input_accessToken);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("checkFacebookStatus callback about to invoke!");
				try {
					checkFacebookStatus_onCompleteCallback del = (checkFacebookStatus_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  userId,  facebookId,  accessToken );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("checkFacebookStatus finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getFacebookId_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_userId, IntPtr input_facebookId, IntPtr context);
		[MonoPInvokeCallback (typeof (getFacebookId_onCompleteCallbackDispatcherDelegate))]
		private static void getFacebookId_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_userId, IntPtr input_facebookId, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			String userId = null;
			if (input_userId != IntPtr.Zero){
				userId = Convert.toCS_String(input_userId);
			}
			String facebookId = null;
			if (input_facebookId != IntPtr.Zero){
				facebookId = Convert.toCS_String(input_facebookId);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getFacebookId callback about to invoke!");
				try {
					getFacebookId_onCompleteCallback del = (getFacebookId_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  userId,  facebookId );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getFacebookId finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getASCItems_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_items, IntPtr context);
		[MonoPInvokeCallback (typeof (getASCItems_onCompleteCallbackDispatcherDelegate))]
		private static void getASCItems_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_items, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<ItemData> items = null;
			if (input_items != IntPtr.Zero){
				items = Convert.toCS_ItemData_Array(input_items);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getASCItems callback about to invoke!");
				try {
					getASCItems_onCompleteCallback del = (getASCItems_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  items );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getASCItems finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void purchaseASCItem_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (purchaseASCItem_onCompleteCallbackDispatcherDelegate))]
		private static void purchaseASCItem_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("purchaseASCItem callback about to invoke!");
				try {
					purchaseASCItem_onCompleteCallback del = (purchaseASCItem_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("purchaseASCItem finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void giftASC_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, Int32 input_amount, IntPtr context);
		[MonoPInvokeCallback (typeof (giftASC_onCompleteCallbackDispatcherDelegate))]
		private static void giftASC_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, Int32 input_amount, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Int32 amount = input_amount;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("giftASC callback about to invoke!");
				try {
					giftASC_onCompleteCallback del = (giftASC_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  amount );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("giftASC finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		

		public partial class BalanceUpdateNotification {
			
			[StructLayout (LayoutKind.Sequential)]
			private struct CBalanceUpdateNotification {
				public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
				public IntPtr thisObj; // ALSO VERY INTERNAL
						
				//End of Marshal struct
			}
			// Factories!
			public static BalanceUpdateNotification Factory(IntPtr cobj){
				CBalanceUpdateNotification tmp = (CBalanceUpdateNotification)Marshal.PtrToStructure(cobj, typeof(CBalanceUpdateNotification));
				BalanceUpdateNotification result = Factory(ref tmp);
				return result;
			}
			private static BalanceUpdateNotification Factory(ref CBalanceUpdateNotification cobj) {
				BalanceUpdateNotification tmp = new BalanceUpdateNotification();
				
				
				return tmp;
			}
			
			~BalanceUpdateNotification(){
				
			}
			
			public delegate void BalanceUpdateNotification_dispatcherDelegate(IntPtr context, IntPtr notification);
			[MonoPInvokeCallback (typeof (BalanceUpdateNotification_dispatcherDelegate))]
			public static void BalanceUpdateNotification_dispatcher(IntPtr context, IntPtr cobj) {
				BalanceUpdateNotification notification = Convert.toCS_BalanceUpdateNotification(cobj);
				try {
					BalanceUpdateNotificationDelegate del = (BalanceUpdateNotificationDelegate)BalanceUpdate_observers[context.ToInt32()];
					del(notification);
				} catch ( Exception e) {
					MobageLogger.exceptionLog(e);
				}
			}
		}
	}
#endregion
	
#region Static Methods
	public partial class SocialService {
#if MB_JP
		public static void _openFriendPicker(Int32 maxFriendsToSelect, openFriendPicker_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			Int32 out_maxFriendsToSelect = maxFriendsToSelect;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openFriendPicker(out_maxFriendsToSelect, openFriendPicker_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
#endif // MB_JP
#if MB_JP
		public static void _openDocument(String path, openDocument_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_path = (IntPtr)Convert.toC(path);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openDocument(out_path, openDocument_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_path);
		}
#endif // MB_JP
#if MB_KO
		public static void _openDocument(String path, openDocument_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_path = (IntPtr)Convert.toC(path);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openDocument(out_path, openDocument_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_path);
		}
#endif // MB_KO
#if MB_JP
		public static void _openDiaryWriter(String subject, String body, String imageUrl, openDiaryWriter_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_subject = (IntPtr)Convert.toC(subject);

			IntPtr out_body = (IntPtr)Convert.toC(body);

			IntPtr out_imageUrl = (IntPtr)Convert.toC(imageUrl);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openDiaryWriter(out_subject, out_body, out_imageUrl, openDiaryWriter_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_subject);
			Marshal.FreeHGlobal(out_body);
			Marshal.FreeHGlobal(out_imageUrl);
		}
#endif // MB_JP
#if MB_KO
		public static void _openDiaryWriter(String subject, String body, String imageUrl, openDiaryWriter_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_subject = (IntPtr)Convert.toC(subject);

			IntPtr out_body = (IntPtr)Convert.toC(body);

			IntPtr out_imageUrl = (IntPtr)Convert.toC(imageUrl);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openDiaryWriter(out_subject, out_body, out_imageUrl, openDiaryWriter_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_subject);
			Marshal.FreeHGlobal(out_body);
			Marshal.FreeHGlobal(out_imageUrl);
		}
#endif // MB_KO
#if MB_JP
		public static void _openMinimailSender(String userId, String subject, String body, openMinimailSender_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_userId = (IntPtr)Convert.toC(userId);

			IntPtr out_subject = (IntPtr)Convert.toC(subject);

			IntPtr out_body = (IntPtr)Convert.toC(body);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openMinimailSender(out_userId, out_subject, out_body, openMinimailSender_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_userId);
			Marshal.FreeHGlobal(out_subject);
			Marshal.FreeHGlobal(out_body);
		}
#endif // MB_JP
#if MB_KO
		public static void _openMinimailSender(String userId, String subject, String body, openMinimailSender_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_userId = (IntPtr)Convert.toC(userId);

			IntPtr out_subject = (IntPtr)Convert.toC(subject);

			IntPtr out_body = (IntPtr)Convert.toC(body);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openMinimailSender(out_userId, out_subject, out_body, openMinimailSender_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_userId);
			Marshal.FreeHGlobal(out_subject);
			Marshal.FreeHGlobal(out_body);
		}
#endif // MB_KO
		public static void _executeLogin(executeLogin_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_executeLogin(executeLogin_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _executeLoginWithParams(List<String> keys, List<String> values, executeLoginWithParams_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_keys = (IntPtr)Convert.toC(keys);

			IntPtr out_values = (IntPtr)Convert.toC(values);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_executeLoginWithParams(out_keys, out_values, executeLoginWithParams_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_keys);
			Marshal.FreeHGlobal(out_values);
		}
		public static void _executeLogout(executeLogout_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_executeLogout(executeLogout_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _openUserProfile(User user)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			MBCSocialService_openUserProfile(out_user, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
		}
		public static void _showCommunityUI()
		{
			int cbId = (cbUidGenerator++);
			MBCSocialService_showCommunityUI(new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _showCommunityButton(Gravity gravity, String theme)
		{
			int cbId = (cbUidGenerator++);
			Int32 out_gravity = (int)gravity;

			IntPtr out_theme = (IntPtr)Convert.toC(theme);

			MBCSocialService_showCommunityButton(out_gravity, out_theme, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_theme);
		}
		public static void _hideCommunityButton()
		{
			int cbId = (cbUidGenerator++);
			MBCSocialService_hideCommunityButton(new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _openBankDialog()
		{
			int cbId = (cbUidGenerator++);
			MBCSocialService_openBankDialog(new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _showBalanceButton(Int32 x, Int32 y, Int32 width, Int32 height, showBalanceButton_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			Int32 out_x = x;

			Int32 out_y = y;

			Int32 out_width = width;

			Int32 out_height = height;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_showBalanceButton(out_x, out_y, out_width, out_height, showBalanceButton_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _getCurrentBalance(getCurrentBalance_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_getCurrentBalance(getCurrentBalance_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _hideBalanceButton()
		{
			int cbId = (cbUidGenerator++);
			MBCSocialService_hideBalanceButton(new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _getCurrentBalanceDetails(Int32 imageHeight, getCurrentBalanceDetails_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			Int32 out_imageHeight = imageHeight;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_getCurrentBalanceDetails(out_imageHeight, getCurrentBalanceDetails_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _showPromotions(List<String> keys, List<String> values, showPromotions_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_keys = (IntPtr)Convert.toC(keys);

			IntPtr out_values = (IntPtr)Convert.toC(values);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_showPromotions(out_keys, out_values, showPromotions_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_keys);
			Marshal.FreeHGlobal(out_values);
		}
		public static void _checkFacebookStatus(checkFacebookStatus_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_checkFacebookStatus(checkFacebookStatus_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _getFacebookId(getFacebookId_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_getFacebookId(getFacebookId_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _getASCItems(getASCItems_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_getASCItems(getASCItems_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		public static void _purchaseASCItem(ItemData item, purchaseASCItem_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_item = (IntPtr)Convert.toC(item);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_purchaseASCItem(out_item, purchaseASCItem_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			ItemData.MBCReleaseItemData(out_item);
		}
		public static void _giftASC(String giftCode, giftASC_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_giftCode = (IntPtr)Convert.toC(giftCode);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_giftASC(out_giftCode, giftASC_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_giftCode);
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class SocialService {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414


#pragma warning disable 0414
		private static Dictionary<int, Object> BalanceUpdate_observers = new Dictionary<int, Object>();
		private static Dictionary<Object,int> BalanceUpdate_reverseObservers = new Dictionary<Object,int>();
		private static int BalanceUpdateObserverUIDGenerator = 0;
#pragma warning restore 0414
		private static void BalanceUpdateNotificationDelegate_add(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = BalanceUpdateObserverUIDGenerator++;
				BalanceUpdate_observers.Add(identifier, val);
				BalanceUpdate_reverseObservers.Add(val, identifier);
				MBCBalanceUpdateNotification_registerObserver(new IntPtr(identifier), BalanceUpdateNotification.BalanceUpdateNotification_dispatcher);
		}
		private static void BalanceUpdateNotificationDelegte_remove(Object val) {
				//IntPtr handle = Marshal.GetFunctionPointerForDelegate(value);
				int identifier = BalanceUpdate_reverseObservers[val];
				MBCBalanceUpdateNotification_deregisterObserver(new IntPtr(identifier));
				BalanceUpdate_reverseObservers.Remove(val);
				BalanceUpdate_observers.Remove(identifier);
		}
	}
#endregion
	
	public partial class Convert {

		public static SocialService.BalanceUpdateNotification toCS_BalanceUpdateNotification(IntPtr obj){
			return SocialService.BalanceUpdateNotification.Factory(obj);
		}

	}
	
}


#endif	// !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
