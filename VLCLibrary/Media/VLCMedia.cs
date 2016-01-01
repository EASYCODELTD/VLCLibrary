using System;
using VLCLibraryImport;
using System.Threading;

namespace VLCLibrary 
{
	public class VLCMedia : VLCBase
	{
		private VLCNative.libvlc_media_t _instance;

		public VLCNative.libvlc_media_t Handler {
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


			VLCNative.Media.libvlc_media_release(_instance);  

		}

		public VLCMedia (LibVLC core,String path)
		{
	
			_instance = VLCNative.Media.libvlc_media_new_path (core.Handler, path);
		
		}

		public VLCMedia (LibVLC core,Uri path)
		{
			string url = path.AbsoluteUri;
			Console.WriteLine ("========================================================");
			Console.WriteLine ("Url: " + url);
			_instance = VLCNative.Media.libvlc_media_new_location (core.Handler,url);
			Console.WriteLine ("========================================================");
		}
	}
}

