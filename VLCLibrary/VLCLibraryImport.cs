using System;
using System.Runtime.InteropServices;

namespace VLCLibraryImport
{
	// http://www.videolan.org/developers/vlc/doc/doxygen/html/group__libvlc.html

	enum libvlc_event_e {
		libvlc_MediaMetaChanged,
		libvlc_MediaSubItemAdded, 	
		libvlc_MediaDurationChanged,
		libvlc_MediaParsedChanged, 	
		libvlc_MediaFreed, 	
		libvlc_MediaStateChanged, 	
		libvlc_MediaSubItemTreeAdded, 	
		libvlc_MediaPlayerMediaChanged, 	
		libvlc_MediaPlayerNothingSpecial,
		libvlc_MediaPlayerOpening, 	
		libvlc_MediaPlayerBuffering, 	
		libvlc_MediaPlayerPlaying, 	
		libvlc_MediaPlayerPaused, 	
		libvlc_MediaPlayerStopped, 	
		libvlc_MediaPlayerForward, 	
		libvlc_MediaPlayerBackward, 	
		libvlc_MediaPlayerEndReached, 	
		libvlc_MediaPlayerEncounteredError, 	
		libvlc_MediaPlayerTimeChanged, 	
		libvlc_MediaPlayerPositionChanged, 	
		libvlc_MediaPlayerSeekableChanged, 	
		libvlc_MediaPlayerPausableChanged, 	
		libvlc_MediaPlayerTitleChanged, 	
		libvlc_MediaPlayerSnapshotTaken, 	
		libvlc_MediaPlayerLengthChanged, 	
		libvlc_MediaPlayerVout, 	
		libvlc_MediaPlayerScrambledChanged, 	
		libvlc_MediaPlayerESAdded, 	
		libvlc_MediaPlayerESDeleted, 	
		libvlc_MediaPlayerESSelected, 	
		libvlc_MediaPlayerCorked, 	
		libvlc_MediaPlayerUncorked, 	
		libvlc_MediaPlayerMuted, 	
		libvlc_MediaPlayerUnmuted, 	
		libvlc_MediaPlayerAudioVolume, 	
		libvlc_MediaPlayerAudioDevice, 	
		libvlc_MediaPlayerChapterChanged, 	
		libvlc_MediaListItemAdded, 	
		libvlc_MediaListWillAddItem, 	
		libvlc_MediaListItemDeleted, 	
		libvlc_MediaListWillDeleteItem, 	
		libvlc_MediaListEndReached, 	
		libvlc_MediaListViewItemAdded, 	
		libvlc_MediaListViewWillAddItem, 	
		libvlc_MediaListViewItemDeleted, 	
		libvlc_MediaListViewWillDeleteItem, 	
		libvlc_MediaListPlayerPlayed, 	
		libvlc_MediaListPlayerNextItemSet, 	
		libvlc_MediaListPlayerStopped, 	
		libvlc_MediaDiscovererStarted, 	
		libvlc_MediaDiscovererEnded, 	
		libvlc_VlmMediaAdded, 	
		libvlc_VlmMediaRemoved, 	
		libvlc_VlmMediaChanged, 	
		libvlc_VlmMediaInstanceStarted, 	
		libvlc_VlmMediaInstanceStopped, 	
		libvlc_VlmMediaInstanceStatusInit, 	
		libvlc_VlmMediaInstanceStatusOpening, 	
		libvlc_VlmMediaInstanceStatusPlaying, 	
		libvlc_VlmMediaInstanceStatusPause, 	
		libvlc_VlmMediaInstanceStatusEnd, 	
		libvlc_VlmMediaInstanceStatusError, 
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct libvlc_log_message_t
	{
		public UInt32 sizeof_msg;
		public Int32 i_severity;
		public IntPtr psz_type;
		public IntPtr psz_name;
		public IntPtr psz_header;
		public IntPtr psz_message;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct libvlc_event_t
	{
		[FieldOffset(0)]
		public int type;

		[FieldOffset(4)]
		public IntPtr p_obj;

		[FieldOffset(8)]
		public media_player_time_changed media_player_time_changed;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct media_player_time_changed
	{
		public long new_time;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void VlcEventHandlerDelegate(ref libvlc_event_t libvlc_event, IntPtr userData);
	
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct libvlc_exception_t
	{
		public int b_raised;
		public int i_code;
		[MarshalAs(UnmanagedType.LPStr)]
		public string psz_message;
	}

	static class NativeVLC
	{
		#region core
		[DllImport("libvlc")]
		public static extern IntPtr libvlc_new(int argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] argv);

		[DllImport("libvlc")]
		public static extern void libvlc_release(IntPtr instance);
		#endregion

		#region media
		[DllImport("libvlc")]
		public static extern IntPtr libvlc_media_new_path (IntPtr p_instance,[MarshalAs(UnmanagedType.LPStr)] string psz_mrl);

		[DllImport("libvlc")]
		public static extern IntPtr libvlc_media_new_location	(IntPtr p_instance,[MarshalAs(UnmanagedType.LPStr)] string psz_mrl);

		[DllImport("libvlc")]
		public static extern void libvlc_media_release(IntPtr p_meta_desc);
		#endregion

		public delegate void Log_Callback(IntPtr data, int level, IntPtr ctx,[MarshalAs(UnmanagedType.LPStr,SizeConst=255)] string psz_mrl,  IntPtr arg );

		#region log

		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int vprintf(string format, IntPtr ptr);

		[DllImport("libvlc")]
		public static extern void  libvlc_set_log_verbosity (IntPtr p_instance, int	level);

		[DllImport("libvlc")]
		public static extern void libvlc_log_set(IntPtr p_instance, Log_Callback cb,  IntPtr data );
		#endregion

		#region media player
		[DllImport("libvlc")]
		public static extern IntPtr libvlc_media_player_new_from_media(IntPtr media);

		[DllImport("libvlc")]
		public static extern void libvlc_media_player_release(IntPtr player);

		[DllImport("libvlc")]
		public static extern void libvlc_media_player_set_hwnd(IntPtr player, IntPtr drawable);

		[DllImport("libvlc")]
		public static extern void libvlc_media_player_set_xwindow(IntPtr player, IntPtr drawable);

		public delegate IntPtr Lock_Callback( IntPtr opaque, ref IntPtr planes);
		public delegate void Unlock_Callback( IntPtr opaque,ref IntPtr picture, ref IntPtr planes);
		public delegate void Display_Callback( IntPtr opaque, ref IntPtr picture);

		[DllImport("libvlc")]
		public static extern void libvlc_video_set_callbacks ( IntPtr mp, 
																 Lock_Callback 	lockCallback, 
			 Unlock_Callback 	unlockCallBack, 
			 Display_Callback 	displayCallBack, 
		                                                         IntPtr 	opaque); 
		[DllImport("libvlc")]
		public static extern void libvlc_video_set_format ( IntPtr	mp, 
		                                                    [MarshalAs (UnmanagedType.LPStr)] string chroma, 
		                                                     UInt32 	width, 
		                                                     UInt32 	height, 
		                                                     UInt32 	pitch);


		public delegate int  libvlc_video_format_cb (ref IntPtr opaque, [MarshalAs (UnmanagedType.LPStr)] string chroma, ref UInt32 width, ref UInt32 height, ref UInt32 pitches,ref UInt32 lines);
		public delegate void libvlc_video_cleanup_cb(ref IntPtr opaque);

		[DllImport("libvlc")]
		public static extern void  libvlc_video_set_format_callbacks (IntPtr mp, 
		                                          libvlc_video_format_cb 	setup, 
		                                          libvlc_video_cleanup_cb 	cleanup 
		);

		[DllImport("libvlc")]
		public static extern void libvlc_media_player_play(IntPtr player);

		[DllImport("libvlc")]
		public static extern void libvlc_media_player_pause(IntPtr player);

		[DllImport("libvlc")]
		public static extern void libvlc_media_player_stop(IntPtr player);
		#endregion

		#region events
	//	public static extern int libvlc_event_attach 	(	libvlc_event_manager_t * 	p_event_manager, 
	//		libvlc_event_type_t 	i_event_type, 
	//		libvlc_callback_t 	f_callback, 
	//		void * 	user_data 
	//	)

		#endregion

	}
}

