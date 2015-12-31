using System;
using System.Threading;
using Gdk;

namespace VLCLibrary
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class VLCWidget : Gtk.Bin
	{
		public  event NewFrameEventHandler NewFrameEvent=null;

		LibVLC lib = null;
		VLCMedia media = null;
		VLCMediaPlayer player = null;
		public uint width=640;
		public uint height=480;

		public VLCWidget ()
		{
			this.Build ();
			lib = new LibVLC ();
		}

		public bool OpenMediaFromMedia(VLCMedia media)
		{
	
			if (media == null)
				return false;

			player = new VLCMediaPlayer (lib, media);
			player.width = width;
			player.height = height;

			if (player == null)
				return false;

			player.NewFrameEvent += delegate(object sender, INewFrameEventArgs e) {

				Gdk.Pixbuf buffer = (Gdk.Pixbuf )e.frame.Pixbuf.Clone();

				output.Pixbuf = buffer.ScaleSimple ((int)width, (int)height, InterpType.Bilinear);

				if(NewFrameEvent!=null) NewFrameEvent(sender,e);	
			};

			//player.SetDrawable (output);

			return true;
		}

		public bool OpenMediaFromPath(string path)
		{
			media = lib.CreateMediaFromPath (path);	
			if (media == null)
				return false;
			
			return OpenMediaFromMedia(media);
		}

		public bool OpenMediaFromUri(Uri uri)
		{
			media = lib.CreateMediaFromUri (uri);	
			if (media == null)
				return false;
			
			return OpenMediaFromMedia(media);
		}

		public bool Play()
		{
			if (media == null)
				return false;

			if (player == null)
				return false;

			player.Play ();
			return true;
		}

		public bool Play(string path)
		{
			if (!OpenMediaFromPath (path))
				return false;

			Play ();

			return true;
		}

		public bool PlayFromUri(Uri uri)
		{
			if (!OpenMediaFromUri (uri))
				return false;

		

			Play ();

			return true;
		}

		private void OnSizeAllocated (object o, Gtk.SizeAllocatedArgs e)
		{ 

			width = (uint)e.Allocation.Width; 
			height = (uint)e.Allocation.Height; 

			Console.WriteLine ("Resize " + width + "px " + height+" px");


		}
	}


}

