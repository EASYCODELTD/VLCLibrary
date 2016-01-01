using System;
using System.Runtime.InteropServices;

namespace VLCNative {


	//Types
		[StructLayout(LayoutKind.Sequential)]
		public struct libvlc_log_t { public IntPtr _instance; }

	//Structures


	//Enum



	//Calbacks
	public delegate void libvlc_log_cb (IntPtr data, int level,  libvlc_log_t  ctx,[MarshalAs(UnmanagedType.LPStr,SizeConst=255)] string psz_mrl,  IntPtr arg );

	static class Logging
	{
		

		#region logging

		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)] 
			public static extern int vprintf(string format, IntPtr ptr);

		[DllImport("libvlc")]
			public static extern void  libvlc_set_log_verbosity (libvlc_instance_t  p_instance, int	level);

		[DllImport("libvlc")]
			public static extern void libvlc_log_set(	libvlc_instance_t p_instance, libvlc_log_cb  cb,  IntPtr data );

		#endregion
	}
}
