using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



#region Static constructor
namespace Mobage {
	public partial class Analytics {
		static Analytics() {
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
	

#region Native Method Imports
	public partial class Analytics {

#if MB_WW
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAnalytics_reportEvent(IntPtr input_eventString, IntPtr context);
#endif // MB_WW
#if MB_WW
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAnalytics_reportGameEvent(IntPtr input_eventId, IntPtr input_payload, IntPtr input_playerState, IntPtr context);
#endif // MB_WW
#if MB_WW
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAnalytics_reportErrorEvent(IntPtr input_error, IntPtr context);
#endif // MB_WW
	
	}
#endregion

#region Native Return Points
	public partial class Analytics {
	}
#endregion
	
#region Static Methods
	public partial class Analytics {
#if MB_WW
		public static void _reportEvent(String eventString)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_eventString = (IntPtr)Convert.toC(eventString);

			MBCAnalytics_reportEvent(out_eventString, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_eventString);
		}
#endif // MB_WW
#if MB_WW
		public static void _reportGameEvent(String eventId, String payload, String playerState)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_eventId = (IntPtr)Convert.toC(eventId);

			IntPtr out_payload = (IntPtr)Convert.toC(payload);

			IntPtr out_playerState = (IntPtr)Convert.toC(playerState);

			MBCAnalytics_reportGameEvent(out_eventId, out_payload, out_playerState, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_eventId);
			Marshal.FreeHGlobal(out_payload);
			Marshal.FreeHGlobal(out_playerState);
		}
#endif // MB_WW
#if MB_WW
		public static void _reportErrorEvent(String error)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_error = (IntPtr)Convert.toC(error);

			MBCAnalytics_reportErrorEvent(out_error, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_error);
		}
#endif // MB_WW
	}
#endregion
	

#region Delegate Callbacks
	public partial class Analytics {
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
