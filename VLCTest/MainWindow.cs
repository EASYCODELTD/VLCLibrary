using System;
using Gtk;
using VLCLibrary;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		vlcplayer.width = 1280;
		vlcplayer.height = 720;

		vlcplayer.Play ("test.mp4");
		//vlcplayer.PlayFromUri(new Uri("rtsp://admin:Abra0906@192.168.1.2/1/"));

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnVlcplayerNewFrameEvent (object sender, INewFrameEventArgs e)
	{
		if (e.frame.Pixbuf != null) {
			Console.WriteLine ("NEW FRAME " + e.frame.Pixbuf.Width + " x " + e.frame.Pixbuf.Height);
		}
	}
}
