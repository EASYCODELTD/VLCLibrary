using System;
using System.Runtime.InteropServices;

namespace VLCNative {

	//Enum

	public enum libvlc_event_type_t {
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

	//Types


	//Structures
	[StructLayout(LayoutKind.Sequential)]
	public struct libvlc_event_t
	{
		libvlc_event_type_t type;
		IntPtr 	p_obj;
		/*
		union {
			struct {
				libvlc_meta_t   meta_type

			}   media_meta_changed

			struct {
				libvlc_media_t *   new_child

			}   media_subitem_added

			struct {
				int64_t   new_duration

			}   media_duration_changed

			struct {
				int   new_status

			}   media_parsed_changed

			struct {
				libvlc_media_t *   md

			}   media_freed

			struct {
				libvlc_state_t   new_state

			}   media_state_changed

			struct {
				libvlc_media_t *   item

			}   media_subitemtree_added

			struct {
				float   new_cache

			}   media_player_buffering

			struct {
				int   new_chapter

			}   media_player_chapter_changed

			struct {
				float   new_position

			}   media_player_position_changed

			struct {
				libvlc_time_t   new_time

			}   media_player_time_changed

			struct {
				int   new_title

			}   media_player_title_changed

			struct {
				int   new_seekable

			}   media_player_seekable_changed

			struct {
				int   new_pausable

			}   media_player_pausable_changed

			struct {
				int   new_scrambled

			}   media_player_scrambled_changed

			struct {
				int   new_count

			}   media_player_vout

			struct {
				libvlc_media_t *   item

				int   index

			}   media_list_item_added

			struct {
				libvlc_media_t *   item

				int   index

			}   media_list_will_add_item

			struct {
				libvlc_media_t *   item

				int   index

			}   media_list_item_deleted

			struct {
				libvlc_media_t *   item

				int   index

			}   media_list_will_delete_item

			struct {
				libvlc_media_t *   item

			}   media_list_player_next_item_set

			struct {
				char *   psz_filename

			}   media_player_snapshot_taken

			struct {
				libvlc_time_t   new_length

			}   media_player_length_changed

			struct {
				const char *   psz_media_name

				const char *   psz_instance_name

			}   vlm_media_event

			struct {
				libvlc_media_t *   new_media

			}   media_player_media_changed

			struct {
				libvlc_track_type_t   i_type

				int   i_id

			}   media_player_es_changed

			struct {
				float   volume

			}   media_player_audio_volume

			struct {
				const char *   device

			}   media_player_audio_device
			*/
	}


	//Calbacks
	public delegate void libvlc_callback_t(libvlc_event_t p_event, IntPtr data);

	static class Event
	{
		#region events
	//[DllImport("libvlc")]
		//public static extern libvlc_instance_t libvlc_new(int argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] argv);

		//Register for an event notification. More...
		[DllImport("libvlc")]
		public static extern int libvlc_event_attach (libvlc_event_manager_t p_event_manager, libvlc_event_type_t i_event_type, libvlc_callback_t f_callback, IntPtr user_data);

		//Unregister an event notification. More...
		[DllImport("libvlc")]
		public static extern void 	libvlc_event_detach (libvlc_event_manager_t p_event_manager, libvlc_event_type_t i_event_type, libvlc_callback_t f_callback, IntPtr p_user_data);
			
		//Get an event's type name. More...
		[DllImport("libvlc")]
		public static extern IntPtr libvlc_event_type_name (libvlc_event_type_t event_type);
			

		#endregion
	}
}

