using System;
using VLCLibraryImport;
using System.Runtime.InteropServices;
using System.Threading;

namespace VLCLibrary
{

	public class INewFrameEventArgs : EventArgs
	{
		public INewFrameEventArgs (Gtk.Image frame)
		{
			this.frame = frame;
		}
		public Gtk.Image frame=null;
	}

	public delegate void NewFrameEventHandler(object sender, INewFrameEventArgs e);

	public class VLCMediaPlayer : VLCBase
	{
		public  event NewFrameEventHandler NewFrameEvent=null;

		private LibVLC _core=null;
		private VLCMedia _media=null;

		private IntPtr _instance;
	
		private VLCVideoBuffer videoBuffer;

		private uint _width = 1280;
		private uint _height= 720;
		private Gtk.Image drawObject;
		private Gdk.Pixbuf buffer;

		public IntPtr Handler {
			get { return _instance;  } 		
			set {} 
		}


		public uint width {
			get { return _width;  } 		
			set { _width = value;  } 
		}

		public uint height {
			get { return _height;  } 		
			set { _height = value; } 
		}

		public VLCMediaPlayer (LibVLC core,VLCMedia media)
		{
			_core = core;
			_media = media;
		
			_instance = NativeVLC.libvlc_media_player_new_from_media(_media.Handler);

			NativeVLC.libvlc_video_set_callbacks (_instance,new NativeVLC.Lock_Callback(LockCalback),new NativeVLC.Unlock_Callback(UnlockCalback),new NativeVLC.Display_Callback(DisplayCalback),IntPtr.Zero); 

			drawObject = new Gtk.Image ();
		}

		~VLCMediaPlayer ()
		{
			
		

		}


		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				_core.Dispose ();
				_media.Dispose ();
			}

			if (_instance == IntPtr.Zero) return;
			//@TODO native instance remove
			_instance = IntPtr.Zero;
		}

		public void SetDrawable(Gtk.Image obj)
		{
			drawObject = obj;
		}

		private void CreateBuffer(uint width,uint height,uint bytes)
		{
			NativeVLC.libvlc_video_set_format(_instance, "RGBA", width, height, bytes * width);
			videoBuffer = new VLCVideoBuffer(width, height,bytes);
		}

		public  int setVideoFormat(ref IntPtr opaque, string chroma, ref UInt32 width, ref UInt32 height, ref UInt32 pitches,ref UInt32 lines)
		{
			return 0;
		}


		public  void videoFormatClean(ref IntPtr opaque) {

		}

		public  IntPtr LockCalback(ref IntPtr opaque, ref IntPtr planes)
		{

			planes = videoBuffer.Lock();

			return IntPtr.Zero;
		}

		public  void UnlockCalback(ref IntPtr opaque,ref IntPtr picture, ref IntPtr planes)
		{

			buffer = videoBuffer.Pixbuf ();

			videoBuffer.Unlock();
		}

		public   void DisplayCalback(ref IntPtr opaque, ref IntPtr picture)
		{

			if (drawObject!=null) {
				drawObject.Pixbuf = buffer;


				if (NewFrameEvent != null && drawObject.Pixbuf!=null) {
					Gtk.Application.Invoke (delegate {
							NewFrameEvent (this, new INewFrameEventArgs (drawObject));
					}
					);
				}
			}
		}

		public void Play()
		{
			CreateBuffer (_width,_height,4);
			 
			NativeVLC.libvlc_media_player_play(_instance);

	
		}
	}
}

