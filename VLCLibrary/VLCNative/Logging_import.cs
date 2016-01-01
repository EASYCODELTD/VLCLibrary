using System;
using System.Runtime.InteropServices;
using System.Text;

namespace VLCNative {


	//Types
		[StructLayout(LayoutKind.Sequential)]
		public struct libvlc_log_t { public IntPtr _instance; }

	//Structures


	//Enum



	//Calbacks
	public delegate void libvlc_log_cb (IntPtr data, int level,  libvlc_log_t  ctx,[MarshalAs(UnmanagedType.LPStr,SizeConst=255)] string psz_mrl, IntPtr args );

	static class Logging
	{
		

		#region logging

		[DllImport("msvcrt.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)] 
		public static extern int vprintf([MarshalAs(UnmanagedType.LPStr,SizeConst=255)] string format, IntPtr ptr);


		[DllImport("msvcrt.dll", SetLastError = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		public static extern int vsprintf([Out] StringBuilder outString, string format, ref IntPtr args);


		[DllImport("libvlc")]
			public static extern void  libvlc_set_log_verbosity (libvlc_instance_t  p_instance, int	level);

		[DllImport("libvlc")]
			public static extern void libvlc_log_set(	libvlc_instance_t p_instance, libvlc_log_cb  cb,  IntPtr data );

		#endregion
	}
}
