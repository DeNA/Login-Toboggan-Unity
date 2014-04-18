//
//  MobageUtils.cs
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)



using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using UnityEngine;

namespace Mobage {
#region Mono Magic!
	#pragma warning disable 0414
	public class MonoPInvokeCallbackAttribute : System.Attribute
	{
		private Type type;
		public MonoPInvokeCallbackAttribute( Type t ) { type = t; }
	}
	#pragma warning restore 0414
#endregion
	
	public partial class Mobage {
#if UNITY_IPHONE
		//[DllImport("NDKPlugin")]
		//private static extern void NotificationPingBack(IntPtr token);
		[DllImport("__Internal")]
		public static extern void setDelayedCallback(bool enabled);
		[DllImport("__Internal")]
		public static extern void invokeAllCallbacks();
#endif
	}
#region Enums
	/**
	
	 */
	public enum SimpleAPIStatus {
		/**
		
		 */
		SimpleAPIStatusSuccess = 0, 
		/**
		
		 */
		SimpleAPIStatusError = 1, 
	};
	
	public partial class Convert {
		public static bool IsSimpleAPIStatus(int intFlag){return (!((intFlag < 0) || (intFlag > 1))); }
		public static int toC(SimpleAPIStatus enumValue){return (int)enumValue;}
		public static SimpleAPIStatus toCS_SimpleAPIStatus(int enumValue){return (SimpleAPIStatus)enumValue;}
	}
	
	/**
	
	 */
	public enum DismissableAPIStatus {
		/**
		
		 */
		DismissableAPIStatusSuccess = 0, 
		/**
		
		 */
		DismissableAPIStatusError = 1, 
		/**
		
		 */
		DismissableAPIStatusDismiss = 2, 
	};
	
	public partial class Convert {
		public static bool IsDismissableAPIStatus(int intFlag){return (!((intFlag < 0) || (intFlag > 2))); }
		public static int toC(DismissableAPIStatus enumValue){return (int)enumValue;}
		public static DismissableAPIStatus toCS_DismissableAPIStatus(int enumValue){return (DismissableAPIStatus)enumValue;}
	}
	
	/**
	
	 */
	public enum CancelableAPIStatus {
		/**
		
		 */
		CancelableAPIStatusSuccess = 0, 
		/**
		
		 */
		CancelableAPIStatusError = 1, 
		/**
		
		 */
		CancelableAPIStatusCancel = 2, 
	};
	
	public partial class Convert {
		public static bool IsCancelableAPIStatus(int intFlag){return (!((intFlag < 0) || (intFlag > 2))); }
		public static int toC(CancelableAPIStatus enumValue){return (int)enumValue;}
		public static CancelableAPIStatus toCS_CancelableAPIStatus(int enumValue){return (CancelableAPIStatus)enumValue;}
	}
	
#endregion
	
	public class MobageLogger : MonoBehaviour
	{
		public static bool LoggingEnabled = true;
		public static void exceptionLog(object obj)
		{
			if (!MobageLogger.LoggingEnabled){return;}
			print("MBUnityLogger[GameException]: "+obj);
		}
		public static void log(object obj)
		{
			if (!MobageLogger.LoggingEnabled){return;}
			print("MBUnityLogger[Log]: "+obj);
		}
	}
		
	[StructLayout (LayoutKind.Sequential)]
	public struct CString {
		public uint __CAPI_REFCOUNT; // VERY INTERNAL
		public IntPtr thisObj; // ALSO VERY INTERNAL
				
		public IntPtr c_str;
					//End of Marshal struct
	}
	
	[StructLayout (LayoutKind.Sequential)]
	public struct String_Array {
		private uint __CAPI_REFCOUNT; // VERY INTERNAL
		private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		public int length;
		public IntPtr elements;
		
		public static List<String> Factory(IntPtr cobj){
			String_Array tmp = (String_Array)Marshal.PtrToStructure(cobj,typeof(String_Array));
			return tmp.toList();
		}
		public static string StringFactory(IntPtr cobj){
			CString tmp = (CString)Marshal.PtrToStructure(cobj, typeof(CString));
			tmp.thisObj = cobj;
			string result = StringFactory(tmp);
			return result;
		}
		private static string StringFactory(CString cobj) {
			return Convert.toCS_String(cobj.c_str);
		}
		private List<String> toList()
		{
			if (length <= 0 || elements == IntPtr.Zero){
				return new List<String>();
			}
			
			List<String> tmp = new List<String>(length);
			uint stepSize = 4;
			
			for (int i = 0; i < length; i++){
				// Calculate current offset from start of elements
				uint offset = ((uint)i) * stepSize;
				
				// Jump to the offset, and then deref pointer to get another pointer
				// 		This means read the integer at the location of
				//		(start + offset), and turn that into a new pointer
				IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,(int)offset));
				
				String tmpItem = StringFactory(curPtr);
				if (tmpItem != null){
					tmp.Add(tmpItem);
				}
			}
			return tmp;
		}
	}
	
#if UNITY_ANDROID && !UNITY_EDITOR
	[StructLayout (LayoutKind.Sequential)]
	public struct Integer_Array {
		private uint __CAPI_REFCOUNT; // VERY INTERNAL
		private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		public int length;
		public IntPtr elements;
		
		public static List<int> Factory(IntPtr cobj){
			Integer_Array tmp = (Integer_Array)Marshal.PtrToStructure(cobj,typeof(Integer_Array));
			return tmp.toList();
		}
		private List<int> toList()
		{
			if (length <= 0 || elements == IntPtr.Zero){
				return new List<int>();
			}
			
			List<int> tmp = new List<int>(length);
			uint stepSize = sizeof(int);
			
			for (int i = 0; i < length; i++){
				// Calculate current offset from start of elements
				uint offset = ((uint)i) * stepSize;
				int value = BitConverter.ToInt32(BitConverter.GetBytes(Marshal.ReadInt32(elements,(int)offset)), 0);
				tmp.Add(Convert.toCS_Integer(value));
			}
			return tmp;
		}
	}
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
	[StructLayout (LayoutKind.Sequential)]
	public struct Double_Array {
		private uint __CAPI_REFCOUNT; // VERY INTERNAL
		private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		public int length;
		public IntPtr elements;
		
		public static List<double> Factory(IntPtr cobj){
			Double_Array tmp = (Double_Array)Marshal.PtrToStructure(cobj,typeof(Double_Array));
			return tmp.toList();
		}
		private List<double> toList()
		{
			if (length <= 0 || elements == IntPtr.Zero){
				return new List<double>();
			}
			
			List<double> tmp = new List<double>(length);
			uint stepSize = sizeof(double);
			
			for (int i = 0; i < length; i++){
				// Calculate current offset from start of elements
				uint offset = ((uint)i) * stepSize;
				double value = BitConverter.ToDouble(BitConverter.GetBytes(Marshal.ReadInt64(elements,(int)offset)), 0);
				tmp.Add(Convert.toCS_Double(value));
			}
			return tmp;
		}
	}
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
	[StructLayout (LayoutKind.Sequential)]
	public struct Bool_Array {
		private uint __CAPI_REFCOUNT; // VERY INTERNAL
		private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		public int length;
		public IntPtr elements;
		
		public static List<bool> Factory(IntPtr cobj){
			Bool_Array tmp = (Bool_Array)Marshal.PtrToStructure(cobj,typeof(Bool_Array));
			return tmp.toList();
		}
		private List<bool> toList()
		{
			if (length <= 0 || elements == IntPtr.Zero){
				return new List<bool>();
			}
			
			List<bool> tmp = new List<bool>(length);
			uint stepSize = sizeof(bool);
			
			for (int i = 0; i < length; i++){
				// Calculate current offset from start of elements
				uint offset = ((uint)i) * stepSize;
				bool value = BitConverter.ToBoolean(BitConverter.GetBytes(Marshal.ReadByte(elements,(int)offset)), 0);
				tmp.Add(Convert.toCS_Bool(value));
			}
			return tmp;
		}
	}
#endif
	public partial class Convert {
		public static IntPtr toC(String str)
		{
			return MarshalPtrToUtf8.GetInstance("").MarshalManagedToNative(str);
		}
		private static Int32 intToInt32(int v) {
			return (Int32)v;
		}
		private static Int64 doubleToInt64(double v) {
			return (Int64)v;
		}
		private static Byte boolToByte(bool v) {
			return (byte)(v ? 1 : 0);
		}
		private static CString toC_MBCString(String str){
			CString tmp = new CString();
			tmp.__CAPI_REFCOUNT = 1;
			tmp.thisObj = IntPtr.Zero;
			tmp.c_str = Convert.toC(str);
			return tmp;
		}
		public static IntPtr toC(List<String> list)
		{
			List<IntPtr> allocatedMemory = new List<IntPtr>();
			String_Array tmp = new String_Array();
			tmp.length = (list != null) ? list.Count:0;
			tmp.elements = Marshal.AllocHGlobal(4 * tmp.length);
			
			CString tmpMBCString = new CString();
			tmpMBCString.__CAPI_REFCOUNT = 1;
			tmpMBCString.c_str = IntPtr.Zero;
			for (int i = 0; i < tmp.length; i++)
			{
				IntPtr nativeObj = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CString)));
				allocatedMemory.Add(nativeObj);
				
				tmpMBCString.c_str = Convert.toC(list[i]);
				allocatedMemory.Add(tmpMBCString.c_str);
				
				Marshal.StructureToPtr(tmpMBCString, nativeObj, false);
				
				Marshal.WriteIntPtr(tmp.elements, i * 4, nativeObj);
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = MBCCopyConstructString_Array(tmpHandle.AddrOfPinnedObject(),Convert.toC_Bool(true));
			
			tmpHandle.Free();
			
			foreach(IntPtr tPtr in allocatedMemory){
				Marshal.FreeHGlobal(tPtr);
			}
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		private static Int32 bitConverter_intToInt32(int v) {
			return BitConverter.ToInt32(BitConverter.GetBytes(v), 0);
		}
		private static Int64 bitConverter_doubleToInt64(double v) {
			return BitConverter.ToInt64(BitConverter.GetBytes(v), 0);
		}
		private static Byte bitConverter_boolToByte(bool v) {
			return (Byte)(v ? 1 : 0);
		}
#if UNITY_ANDROID && !UNITY_EDITOR
		public static IntPtr toC(List<int> list) {
			Integer_Array tmp = new Integer_Array();
			tmp.length = (list != null) ? list.Count:0;
			tmp.elements = Marshal.AllocHGlobal(sizeof(int) * tmp.length);
			for(int i = 0; i < tmp.length; i++) {
				Marshal.WriteInt32(tmp.elements, i * sizeof(int), bitConverter_intToInt32(list[i]));
			}
			GCHandle tmpHandle = GCHandle.Alloc(tmp, GCHandleType.Pinned);
			IntPtr cVersion = MBCCopyConstructInteger_Array(tmpHandle.AddrOfPinnedObject(), 0);
			tmpHandle.Free();
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static List<int> toCS_Integer_Array(IntPtr obj){
			return Integer_Array.Factory(obj);
		}
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
		public static IntPtr toC(List<double> list) {
			Double_Array tmp = new Double_Array();
			tmp.length = (list != null) ? list.Count:0;
			tmp.elements = Marshal.AllocHGlobal(sizeof(double) * tmp.length);
			for(int i = 0; i < tmp.length; i++) {
				Marshal.WriteInt64(tmp.elements, i * sizeof(double), bitConverter_doubleToInt64(list[i]));
			}
			GCHandle tmpHandle = GCHandle.Alloc(tmp, GCHandleType.Pinned);
			IntPtr cVersion = MBCCopyConstructDouble_Array(tmpHandle.AddrOfPinnedObject(), 0);
			tmpHandle.Free();
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static List<double> toCS_Double_Array(IntPtr obj){
			return Double_Array.Factory(obj);
		}
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
		public static IntPtr toC(List<bool> list) {
			Bool_Array tmp = new Bool_Array();
			tmp.length = (list != null) ? list.Count:0;
			tmp.elements = Marshal.AllocHGlobal(sizeof(bool) * tmp.length);
			for(int i = 0; i < tmp.length; i++) {
				Marshal.WriteByte(tmp.elements, i * sizeof(bool), bitConverter_boolToByte(list[i]));
			}
			GCHandle tmpHandle = GCHandle.Alloc(tmp, GCHandleType.Pinned);
			IntPtr cVersion = MBCCopyConstructBool_Array(tmpHandle.AddrOfPinnedObject(), 0);
			tmpHandle.Free();
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static List<bool> toCS_Bool_Array(IntPtr obj){
			return Bool_Array.Factory(obj);
		}
#endif
		public static String toCS_String(IntPtr obj){
			return (String)Marshal.PtrToStringAnsi(obj);
		}
		public static List<String> toCS_String_Array(IntPtr obj){
			return String_Array.Factory(obj);
		}
		
		
		public static double toCS_Double(double obj){
			return obj;
		}
		public static int toCS_Integer(int obj){
			return obj;
		}
		public static bool toCS_Bool(short obj){
			return (obj == 0) ? false : true;
		}
		public static bool toCS_Bool(bool obj) {
			return obj;
		}
		public static short toC_Bool(bool obj){
			return (short)((obj) ? 1 : 0);
		}
		
		#if UNITY_IPHONE && !UNITY_EDITOR
			[DllImport("__Internal")]
		#else
			[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
		#endif
			private static extern IntPtr MBCCopyConstructString(IntPtr /*MBCString*/ obj);
		#if UNITY_IPHONE && !UNITY_EDITOR
			[DllImport("__Internal")]
		#else
			[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
		#endif
			private static extern IntPtr MBCCopyConstructString_Array(IntPtr /*MBCString_Array*/ obj, short shouldCopyArrayElements);
		#if UNITY_ANDROID && !UNITY_EDITOR
			[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
			private static extern IntPtr MBCCopyConstructInteger_Array(IntPtr /*MBCInteger_Array*/ obj, short ignored);
		#endif
		#if UNITY_ANDROID && !UNITY_EDITOR
			[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
			private static extern IntPtr MBCCopyConstructDouble_Array(IntPtr /*MBCDouble_Array*/ obj, short ignored);
		#endif
		#if UNITY_ANDROID && !UNITY_EDITOR
			[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
			private static extern IntPtr MBCCopyConstructBool_Array(IntPtr /*MBCBool_Array*/ obj, short ignored);
		#endif
	}
	
	// From: http://blog.gebhardtcomputing.com/2007/11/marshal-utf8-strings-in-net.html
	public class MarshalPtrToUtf8 : ICustomMarshaler
	{
		static MarshalPtrToUtf8 marshaler = new MarshalPtrToUtf8();

		public void CleanUpManagedData(object ManagedObj)
		{

		}

		public void CleanUpNativeData(IntPtr pNativeData)
		{
			Marshal.Release(pNativeData);
		}

		public int GetNativeDataSize()
		{
			return Marshal.SizeOf(typeof(byte));
		}

		public int GetNativeDataSize(IntPtr ptr)
		{
			int size = 0;
			
			for (size = 0; Marshal.ReadByte(ptr, size) > 0; size++)
				; //All done in ReadByte
			
			return size;
		}

		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			if (ManagedObj == null)
				return IntPtr.Zero;
			if (ManagedObj.GetType() != typeof(string))
				throw new ArgumentException("ManagedObj", "Can only marshal type of System.String");
			byte[] array = Encoding.UTF8.GetBytes((string)ManagedObj);
			if(array.Length == 0)
				return IntPtr.Zero;
			int size = Marshal.SizeOf(array[0]) * array.Length + Marshal.SizeOf(array[0]);
			IntPtr ptr = Marshal.AllocHGlobal(size);
			Marshal.Copy(array, 0, ptr, array.Length);
			Marshal.WriteByte(ptr, size - 1, 0);
			return ptr;
		}

		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero)
				return null;
			int size = GetNativeDataSize(pNativeData);
			byte[] array = new byte[size - 1];
			Marshal.Copy(pNativeData, array, 0, size - 1);
			return Encoding.UTF8.GetString(array);
		}

		public static ICustomMarshaler GetInstance(string cookie)
		{
			return marshaler;
		}
	}
}



#endif	// !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
