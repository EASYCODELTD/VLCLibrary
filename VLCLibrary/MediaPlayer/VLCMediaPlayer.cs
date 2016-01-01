using System;
using VLCLibraryImport;
using System.Runtime.InteropServices;
using System.Threading;

namespace VLCLibrary
{

	public class INewFrameEventArgs : EventArgs
	{
		public INewFrameEventArgs (Gdk.Pixbuf frame)
		{
			this.frame = frame;
		}
		public Gdk.Pixbuf frame=null;
	}

	public delegate void NewFrameEventHandler(object sender, INewFrameEventArgs e);

	public class VLCMediaPlayer : VLCBase
	{
		public  event NewFrameEventHandler NewFrameEvent=null;

		private LibVLC _core=null;
		private VLCMedia _media=null;

		private VLCNative.libvlc_media_player_t _instance;
	
		private VLCVideoBuffer videoBuffer=null;

		private uint _width = 1280;
		private uint _height= 720;
		private Gtk.Image drawObject=null;
		private Gdk.Pixbuf buffer=null;

		GCHandle _this;

		public VLCNative.libvlc_media_player_t Handler {
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


		private VLCEventManager _eventManager;

		public VLCEventManager EventManager {
			get { return _eventManager;  } 		
			set {} 
		}

		public VLCMediaPlayer (LibVLC core,VLCMedia media)
		{
			_this = GCHandle.Alloc(this);

			_core = core;
			_media = media;
	

			_instance = VLCNative.MediaPlayer.libvlc_media_player_new_from_media(_media.Handler);

			VLCNative.MediaPlayer.libvlc_video_set_callbacks (_instance,LockCalback,UnlockCalback,DisplayCalback,(IntPtr)_this); 

			drawObject = new Gtk.Image ();

			_eventManager = new VLCEventManager (this);

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

			_this.Free();
		}

		public void SetDrawable(Gtk.Image obj)
		{
			drawObject = obj;
		}

		private void CreateBuffer(uint width,uint height,uint bytes)
		{

			videoBuffer = new VLCVideoBuffer(width, height,bytes);

			VLCNative.MediaPlayer.libvlc_video_set_format(_instance, "RGBA", width, height, bytes * width);


		}

		public  int setVideoFormat(ref IntPtr opaque, string chroma, ref UInt32 width, ref UInt32 height, ref UInt32 pitches,ref UInt32 lines)
		{
			return 0;
		}


		public  void videoFormatClean(ref IntPtr opaque) {

		}

		public static VLCMediaPlayer PtrToMediaPlayer(IntPtr ptr)
		{
			GCHandle handle2 = (GCHandle) ptr;
			return (handle2.Target as VLCMediaPlayer);
		}

		public static IntPtr LockCalback( IntPtr opaque, ref IntPtr planes)
		{
			
			VLCMediaPlayer _this = PtrToMediaPlayer (opaque);

		
		
			planes = _this.videoBuffer.Lock ();
		
			return IntPtr.Zero;
		}

		public static void UnlockCalback( IntPtr opaque,ref IntPtr picture, ref IntPtr planes)
		{
			VLCMediaPlayer _this = PtrToMediaPlayer (opaque);

		
			_this.videoBuffer.Unlock ();

		}

		public void NewFrame()
		{
			Gtk.Application.Invoke (delegate {

				if (NewFrameEvent != null) {
					Gdk.Pixbuf frame = new Gdk.Pixbuf (videoBuffer.FrameBuffer, Gdk.Colorspace.Rgb, true, 8, (int)videoBuffer.Width, (int)videoBuffer.Height,(int) videoBuffer.Stride);

					NewFrameEvent (this, new INewFrameEventArgs (frame));

					frame.Dispose();
					frame = null;
				}
			});
		}

		public static  void DisplayCalback( IntPtr opaque, ref IntPtr picture)
		{

				
				VLCMediaPlayer _this = PtrToMediaPlayer (opaque);

		
				_this.NewFrame();
		

				System.GC.Collect();
			


		}

		public void Play()
		{
			CreateBuffer (_width,_height,4);
			 
			VLCNative.MediaPlayer.libvlc_media_player_play(_instance);

	
		}
	}
}

