using System;
using VLCLibraryImport;
using System.Threading;

namespace VLCLibrary 
{
	public class VLCMedia : VLCBase
	{
		private IntPtr _instance = IntPtr.Zero;

		public IntPtr Handler {
			get { return _instance;  } 		
			set {} 
		}

		~VLCMedia()
		{
			
			

		}
	
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
			}

			if (_instance == IntPtr.Zero) return;
			NativeVLC.libvlc_media_release(_instance);  
			_instance = IntPtr.Zero;
		}

		public VLCMedia (LibVLC core,String path)
		{
	
			_instance = NativeVLC.libvlc_media_new_path (core.Handler, path);
		
		}

		public VLCMedia (LibVLC core,Uri path)
		{
			string url = path.AbsoluteUri;
			Console.WriteLine ("========================================================");
			Console.WriteLine ("Url: " + url);
			_instance = NativeVLC.libvlc_media_new_location (core.Handler,url);
			Console.WriteLine ("========================================================");
		}
	}
}

