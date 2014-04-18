using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class Profanity {
		static Profanity() {
			NDKPlugin.EnsureInstantiated();
		}
	}
}
#endregion

#if UNITY_ANDROID
public partial class NDKPlugin : UnityEngine.MonoBehaviour {
	[DllImport("NDKPlugin")]
	private static extern void MBCProfanity_checkProfanityCallbackPingBack(IntPtr token);

	void Profanity_checkProfanityCallbackPing(string token) {
		//print(string.Format("Profanity_checkProfanityCallbackPing: {0}", token));
		IntPtr token_c = (IntPtr)Mobage.Convert.toC(token);
		MBCProfanity_checkProfanityCallbackPingBack(token_c);
	}

}
#endif	// UNITY_ANDROID callback shenanigans

namespace Mobage {
	
#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Profanity {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCProfanity_checkProfanity(IntPtr input_text, checkProfanity_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion

#region Native Return Points
	public partial class Profanity {
		private delegate void checkProfanity_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, bool input_textIsValid, IntPtr context);
		[MonoPInvokeCallback (typeof (checkProfanity_onCompleteCallbackDispatcherDelegate))]
		private static void checkProfanity_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, bool input_textIsValid, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			bool textIsValid = input_textIsValid;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("checkProfanity callback about to invoke!");
				try {
					checkProfanity_onCompleteCallback del = (checkProfanity_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  textIsValid );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("checkProfanity finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion
	
#region Static Methods
	public partial class Profanity {
		public static void _checkProfanity(String text, checkProfanity_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_text = (IntPtr)Convert.toC(text);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCProfanity_checkProfanity(out_text, checkProfanity_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_text);
		}
	}
#endregion
	

#region Delegate Callbacks
	public partial class Profanity {
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
