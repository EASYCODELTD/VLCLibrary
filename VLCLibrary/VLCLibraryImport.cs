using System;
using System.Runtime.InteropServices;

namespace VLCLibraryImport
{
	/*
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



	*/
}

