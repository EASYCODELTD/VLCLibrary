using System;
using System.Runtime.InteropServices;

namespace VLCNative {

	 
	//Types
	[StructLayout(LayoutKind.Sequential)]
	public struct libvlc_media_player_t { public IntPtr _instance; }

	[StructLayout(LayoutKind.Sequential)]
	public struct libvlc_event_manager_t { public IntPtr _instance; }

	[StructLayout(LayoutKind.Sequential)]
	public struct libvlc_time_t { public Int64 value; }


	//Structures

	[StructLayout(LayoutKind.Sequential)]
	public struct libvlc_track_description_t
	{
		public int 	i_id;
		public  IntPtr psz_name;
		public  IntPtr 	p_next;
	}

	//Enum

	enum libvlc_state_t {
		libvlc_NothingSpecial, 	
		libvlc_Opening,
		libvlc_Buffering, 	
		libvlc_Playing, 	
		libvlc_Paused, 	
		libvlc_Stopped, 	
		libvlc_Ended, 	
		libvlc_Error, 
	}

	enum libvlc_position_t {
		libvlc_position_disable, 	
		libvlc_position_center, 	
		libvlc_position_left, 	
		libvlc_position_right, 	
		libvlc_position_top, 	
		libvlc_position_top_left, 	
		libvlc_position_top_right, 	
		libvlc_position_bottom, 	
		libvlc_position_bottom_left, 	
		libvlc_position_bottom_right, 
	}

	//Calbacks

	public delegate IntPtr libvlc_video_lock_cb( IntPtr opaque, ref IntPtr planes);
	public delegate void libvlc_video_unlock_cb( IntPtr opaque,ref IntPtr picture, ref IntPtr planes);
	public delegate void libvlc_video_display_cb( IntPtr opaque, ref IntPtr picture);

	public delegate int  libvlc_video_format_cb (ref IntPtr opaque, [MarshalAs (UnmanagedType.LPStr)] string chroma, ref UInt32 width, ref UInt32 height, ref UInt32 pitches,ref UInt32 lines);
	public delegate void libvlc_video_cleanup_cb(ref IntPtr opaque);

	static class MediaPlayer
	{
		

	#region mediaplayer

	//Create an empty Media Player object. More...
	[DllImport("libvlc")]
	public static extern  libvlc_media_player_t libvlc_media_player_new (libvlc_instance_t p_libvlc_instance);


	//Create a Media Player object from a Media. More...
	[DllImport("libvlc")]
		public static extern  libvlc_media_player_t libvlc_media_player_new_from_media (libvlc_media_t p_md);

	//Release a media_player after use Decrement the reference count of a media player object. More...
	[DllImport("libvlc")]
		public static extern  void 	libvlc_media_player_release (libvlc_media_player_t p_mi);

	//Retain a reference to a media player object. More...
	[DllImport("libvlc")]
		public static extern  void 	libvlc_media_player_retain (libvlc_media_player_t p_mi);
	
	//Set the media that will be used by the media_player. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_set_media (libvlc_media_player_t  p_mi, libvlc_media_t  p_md);

	//Get the media used by the media_player. More...
	[DllImport("libvlc")]
	public static extern  libvlc_media_t   	libvlc_media_player_get_media (libvlc_media_player_t  p_mi);

	//Get the Event Manager from which the media player send event. More...
	[DllImport("libvlc")]
	public static extern  libvlc_event_manager_t   	libvlc_media_player_event_manager (libvlc_media_player_t  p_mi);

	//is_playing More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_is_playing (libvlc_media_player_t  p_mi);

	//Play. More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_play (libvlc_media_player_t  p_mi);

	//Pause or resume (no effect if there is no media); More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_set_pause (libvlc_media_player_t  mp, int do_pause);

	//Toggle pause (no effect if there is no media); More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_pause (libvlc_media_player_t  p_mi);

	//Stop (no effect if there is no media); More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_stop (libvlc_media_player_t  p_mi);

	//Set callbacks and private data to render decoded video to a custom area in memory. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_video_set_callbacks (libvlc_media_player_t  mp, libvlc_video_lock_cb lock_calback, libvlc_video_unlock_cb unlock_calback, libvlc_video_display_cb display, IntPtr  opaque);

	//Set decoded video chroma and dimensions. More...
	[DllImport("libvlc")]
		public static extern  void 	libvlc_video_set_format (libvlc_media_player_t  mp, [MarshalAs (UnmanagedType.LPStr)] string   chroma, uint width, uint height, uint pitch);

	//Set decoded video chroma and dimensions. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_video_set_format_callbacks (libvlc_media_player_t  mp, libvlc_video_format_cb setup, libvlc_video_cleanup_cb cleanup);

	//Set the NSView handler where the media player should render its video output. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_set_nsobject (libvlc_media_player_t  p_mi, IntPtr  drawable);

	//Get the NSView handler previously set with libvlc_media_player_set_nsobject();. More...
	[DllImport("libvlc")]
	public static extern  void   	libvlc_media_player_get_nsobject (libvlc_media_player_t  p_mi);

	//Set an X Window System drawable where the media player should render its video output. More...
	[DllImport("libvlc")]
		public static extern  void 	libvlc_media_player_set_xwindow (libvlc_media_player_t  p_mi, UInt32 drawable);

	//Get the X Window System window identifier previously set with libvlc_media_player_set_xwindow();. More...
	[DllImport("libvlc")]
		public static extern  UInt32 	libvlc_media_player_get_xwindow (libvlc_media_player_t  p_mi);

	//Set a Win32/Win64 API window handle (HWND); where the media player should render its video output. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_set_hwnd (libvlc_media_player_t  p_mi, IntPtr  drawable);

	//Get the Windows API window handle (HWND); previously set with libvlc_media_player_set_hwnd();. More...
	[DllImport("libvlc")]
	public static extern  void   	libvlc_media_player_get_hwnd (libvlc_media_player_t  p_mi);

	//Set the android context. More...
	[DllImport("libvlc")]
		public static extern  void 	libvlc_media_player_set_android_context (libvlc_media_player_t  p_mi, IntPtr  p_jvm, IntPtr  p_awindow_handler);

	//Set the EFL Evas Object. More...
	[DllImport("libvlc")]
		public static extern  int 	libvlc_media_player_set_evas_object (libvlc_media_player_t  p_mi, IntPtr  p_evas_object);

	//Set callbacks and private data for decoded audio. More...
	//[DllImport("libvlc")]
	//public static extern  void 	libvlc_audio_set_callbacks (libvlc_media_player_t  mp, libvlc_audio_play_cb play, libvlc_audio_pause_cb pause, libvlc_audio_resume_cb resume, libvlc_audio_flush_cb flush, libvlc_audio_drain_cb drain, void  opaque);

	//Set callbacks and private data for decoded audio. More...
	//[DllImport("libvlc")]
	//public static extern  void 	libvlc_audio_set_volume_callback (libvlc_media_player_t  mp, libvlc_audio_set_volume_cb set_volume);

	//		Set decoded audio format. More...
	//[DllImport("libvlc")]
	//public static extern  void 	libvlc_audio_set_format_callbacks (libvlc_media_player_t  mp, libvlc_audio_setup_cb setup, libvlc_audio_cleanup_cb cleanup);

	//		Set decoded audio format. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_audio_set_format (libvlc_media_player_t  mp,[MarshalAs (UnmanagedType.LPStr)] string  format, uint rate, uint channels);

	// Get the current movie length (in ms);. More...
	[DllImport("libvlc")]
	public static extern  libvlc_time_t 	libvlc_media_player_get_length (libvlc_media_player_t  p_mi);

	// Get the current movie time (in ms);. More...
	[DllImport("libvlc")]
	public static extern  libvlc_time_t 	libvlc_media_player_get_time (libvlc_media_player_t  p_mi);

	//Set the movie time (in ms);. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_set_time (libvlc_media_player_t  p_mi, libvlc_time_t i_time);

	//Get movie position as percentage between 0.0 and 1.0. More...
	[DllImport("libvlc")]
	public static extern  float 	libvlc_media_player_get_position (libvlc_media_player_t  p_mi);

	//Set movie position as percentage between 0.0 and 1.0. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_set_position (libvlc_media_player_t  p_mi, float f_pos);

	//Set movie chapter (if applicable);. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_set_chapter (libvlc_media_player_t  p_mi, int i_chapter);

	//Get movie chapter. More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_get_chapter (libvlc_media_player_t  p_mi);

	//Get movie chapter count. More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_get_chapter_count (libvlc_media_player_t  p_mi);

	//Is the player able to play. More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_will_play (libvlc_media_player_t  p_mi);

	//Get title chapter count. More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_get_chapter_count_for_title (libvlc_media_player_t  p_mi, int i_title);

	//Set movie title. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_set_title (libvlc_media_player_t  p_mi, int i_title);

	//Get movie title. More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_get_title (libvlc_media_player_t  p_mi);

	//Get movie title count. More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_get_title_count (libvlc_media_player_t  p_mi);

	//Set previous chapter (if applicable); More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_previous_chapter (libvlc_media_player_t  p_mi);

	// Set next chapter (if applicable); More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_next_chapter (libvlc_media_player_t  p_mi);

	// Get the requested movie play rate. More...
	[DllImport("libvlc")]
	public static extern  float 	libvlc_media_player_get_rate (libvlc_media_player_t  p_mi);

	//Set movie play rate. More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_set_rate (libvlc_media_player_t  p_mi, float rate);

	//Get current movie state. More...
	[DllImport("libvlc")]
	public static extern  libvlc_state_t 	libvlc_media_player_get_state (libvlc_media_player_t  p_mi);

	//end bug More...
	[DllImport("libvlc")]
	public static extern  uint 	libvlc_media_player_has_vout (libvlc_media_player_t  p_mi);

	//Is this media player seekable? More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_is_seekable (libvlc_media_player_t  p_mi);

	//Can this media player be paused? More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_can_pause (libvlc_media_player_t  p_mi);

	//Check if the current program is scrambled. More...
	[DllImport("libvlc")]
	public static extern  int 	libvlc_media_player_program_scrambled (libvlc_media_player_t  p_mi);

	//Display the next frame (if supported); More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_next_frame (libvlc_media_player_t  p_mi);

	//Navigate through DVD Menu. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_navigate (libvlc_media_player_t  p_mi, uint navigate);
		
	//Set if, and how, the video title will be shown when media is played. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_media_player_set_video_title_display (libvlc_media_player_t  p_mi, libvlc_position_t position, uint timeout);

	//Release (free); libvlc_track_description_t. More...
	[DllImport("libvlc")]
	public static extern  void 	libvlc_track_description_list_release (libvlc_track_description_t  p_track_description);

	#endregion
	}
}
