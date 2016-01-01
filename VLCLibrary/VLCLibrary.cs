using System;
using VLCLibraryImport;

namespace VLCLibrary
{

	public class LibVLC: VLCBase 
	{
		private IntPtr library_instance;

		public LibVLC ()
		{
	
			string[] args = new string[] {
				"-I", "dummy", 
				"--ignore-config",
				"--no-xlib",
				"--vout","vmem",
				"-v",
				"--noaudio",
				"--extraintf=logger","--verbose=4",

				"--deinterlace-mode=blend",
				"--no-osd", "--disable-screensaver",

			};


			library_instance = NativeVLC.libvlc_new(args.Length, args);

			NativeVLC.libvlc_set_log_verbosity (library_instance, 0);
			NativeVLC.libvlc_log_set (library_instance, new NativeVLC.Log_Callback(_log),IntPtr.Zero);

		}

		~LibVLC ()
		{
			
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing) {
			}

			NativeVLC.libvlc_release (library_instance);
		}

		public static void _log(IntPtr data, int level, IntPtr ctx,string psz_mrl,  IntPtr arg )
		{
			//string log = "";
			//for (var i = 0; i < argv.Length; i++) {
			//	log += "["+argv [i]+"]";
			//}
			if (psz_mrl != "") {
				NativeVLC.vprintf (psz_mrl, arg);
				Console.WriteLine ("");
			}
		}

		public IntPtr Handler {
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

