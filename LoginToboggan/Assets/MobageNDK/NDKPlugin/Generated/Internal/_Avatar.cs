using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class Avatar {
		static Avatar() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
#if MB_JP
	[DllImport("NDKPlugin")]
	private static extern void MBCAvatar_getAvatarCallbackPingBack(IntPtr token);

	void Avatar_getAvatarCallbackPing(string token) {
		//print(string.Format("Avatar_getAvatarCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCAvatar_getAvatarCallbackPingBack(token_c);
	}
#endif //MB_JP

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
#if MB_JP // whole interface/model is region-specific
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Avatar {

#if MB_JP
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAvatar_getAvatar(IntPtr input_data, getAvatar_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_JP
	
	}
#endregion

#region Native Return Points
	public partial class Avatar {
#if MB_JP
		private delegate void getAvatar_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_entry, IntPtr context);
		[MonoPInvokeCallback (typeof (getAvatar_onCompleteCallbackDispatcherDelegate))]
		private static void getAvatar_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_entry, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			AvatarData entry = null;
			if (input_entry != IntPtr.Zero){
				entry = Convert.toCS_AvatarData(input_entry);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getAvatar callback about to invoke!");
				try {
					getAvatar_onCompleteCallback del = (getAvatar_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  entry );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getAvatar finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
#endif //MB_JP
	}
#endregion
	
#region Static Methods
	public partial class Avatar {
#if MB_JP
		public static void _getAvatar(AvatarData data, getAvatar_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_data = (IntPtr)Convert.toC(data);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAvatar_getAvatar(out_data, getAvatar_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			AvatarData.MBCReleaseAvatarData(out_data);
		}
#endif // MB_JP
	}
#endregion
	

#region Delegate Callbacks
	public partial class Avatar {
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
