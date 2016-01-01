using System;

namespace VLCLibrary
{
	public class MediaEncoder
	{
		private LibVLC localLib;

		public MediaEncoder (string fileName)
		{
			localLib = new LibVLC (true,fileName);
		}

		public void encodeFrame(Gdk.Pixbuf frame)
		{

			Console.WriteLine ("NEW FRAME");


		}
	}
}

