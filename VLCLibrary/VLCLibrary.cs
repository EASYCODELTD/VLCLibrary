using System;
using VLCLibraryImport;
using System.Text;
using System.Runtime.InteropServices;

namespace VLCLibrary
{

	public class LibVLC: VLCBase 
	{
		private VLCNative.libvlc_instance_t library_instance;

		public LibVLC (bool encoder=false,string outputfile="")
		{

			string[] args;

			if (encoder) {
				args = new string[] {
					"-I", "dummy", 
					"--ignore-config",
					"--no-xlib",
					"--vout", "vmem",
					"-v",
					"--noaudio",
					//"--extraintf=logger","--verbose=4",

					"--deinterlace-mode=blend",
					"--no-osd", "--disable-screensaver",
					"--sub-source","marq",
					"--sout=file/ps:example.mpg",
				};

			} else {
				args = new string[] {
					"-I", "dummy", 
					"--ignore-config",
					"--no-xlib",
					"--vout", "vmem",
					"-v",
					"--noaudio",
					//"--extraintf=logger","--verbose=4",

					"--deinterlace-mode=blend",
					"--no-osd", "--disable-screensaver",

				};

			}

			library_instance = VLCNative.Core.libvlc_new(args.Length, args);

			VLCNative.Logging.libvlc_set_log_verbosity (library_instance, 4);


			VLCNative.Logging.libvlc_log_set (library_instance, _log,IntPtr.Zero);

		}

		~LibVLC ()
		{

		}

		protected override void Dispose(bool disposing)
		{
			if (disposing) {
			}

			VLCNative.Core.libvlc_release (library_instance);
		}

		public static void _log(IntPtr data, int level, VLCNative.libvlc_log_t ctx,string psz_mrl,   IntPtr args  )
		{
	
			
	
			String log = "Log: "+psz_mrl;

			VLCNative.Logging.vprintf (log,args);


		}

		public VLCNative.libvlc_instance_t Handler {
			get { return library_instance;  } 		
			set {} 
		}

		public VLCMedia CreateMediaFromPath(String path)
		{
			return new VLCMedia (this, path);
		}

		public VLCMedia CreateMediaFromUri(Uri path)
		{
			return new VLCMedia (this, path);
		}

		public VLCMediaPlayer CreatePlayer(VLCMedia media)
		{
			return new VLCMediaPlayer (this, media);
		}
	}
}
