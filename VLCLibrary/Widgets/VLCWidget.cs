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


		public uint _width=640;
		public uint _height=480;
		private bool inresizemode=false;

		public uint width {
			get { return _width;  } 		
			set {
				_width = value;

			} 
		}

		public uint height {
			get { return _height;  } 		
			set {
				_height = value;
			
			} 
		}

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


				Console.WriteLine ("FRAME ");

				//Gtk.Application.Invoke (delegate {
					//Gdk.Pixbuf old =  output.Pixbuf;
					Gdk.Pixbuf old =  output.Pixbuf;

					output.Pixbuf = (Gdk.Pixbuf)e.frame.Clone();
					
					if(old!=null)
					{

						old.Dispose();
						old = null;
					}

					//if(old!=null)
					//{
						//old.Dispose();
						//old = null;
					//}

				//});
					
				if(NewFrameEvent!=null) NewFrameEvent(sender,e);	

				System.GC.Collect();
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
			if (!inresizemode && output.Pixbuf!=null) {
				if (output.Pixbuf.Width != _width || output.Pixbuf.Height != _height) {
					inresizemode = true;
					output.Pixbuf = output.Pixbuf.ScaleSimple ((int)_width, (int)_height, InterpType.Bilinear);
					inresizemode = false;
				}
			}
		}
	}


}

