using System;
using System.Runtime.InteropServices;

namespace VLCNative {


	//Types

	[StructLayout(LayoutKind.Sequential)]
	public struct libvlc_instance_t { public IntPtr _instance; }

	//Structures


	//Enum



	//Calbacks

	static class Core
	{
		#region core
		[DllImport("libvlc")]
			public static extern libvlc_instance_t libvlc_new(int argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] argv);

		[DllImport("libvlc")]
			public static extern void libvlc_release(libvlc_instance_t instance);
		#endregion
	}
}

