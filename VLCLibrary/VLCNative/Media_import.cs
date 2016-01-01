using System;
using System.Runtime.InteropServices;

namespace VLCNative {


	//Types

		[StructLayout(LayoutKind.Sequential)]
		public struct libvlc_media_t { public IntPtr _instance; }

	//Structures


	//Enum



	//Calbacks

	static class Media
	{
		#region media
		[DllImport("libvlc")]
			public static extern libvlc_media_t libvlc_media_new_path (libvlc_instance_t p_instance,[MarshalAs(UnmanagedType.LPStr)] string psz_mrl);

		[DllImport("libvlc")]
			public static extern libvlc_media_t libvlc_media_new_location	(libvlc_instance_t p_instance,[MarshalAs(UnmanagedType.LPStr)] string psz_mrl);

		[DllImport("libvlc")]
			public static extern void libvlc_media_release(libvlc_media_t p_meta_desc);
		#endregion
	}
}
