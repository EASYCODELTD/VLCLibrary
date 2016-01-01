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

		vlcplayer.Play ("big_buck_bunny_480p_surround-fix.avi");
		//vlcplayer.PlayFromUri(new Uri("rtsp://admin:Abra0906@192.168.1.2/1/"));

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnVlcplayerNewFrameEvent (object sender, INewFrameEventArgs e)
	{
		if (e.frame != null) {
			//Console.WriteLine ("NEW FRAME " + e.frame.Width + " x " + e.frame.Height);
		}
	}
}
