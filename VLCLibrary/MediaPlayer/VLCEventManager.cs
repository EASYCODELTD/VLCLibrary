using System;
using System.Runtime.InteropServices;

namespace VLCLibrary
{
	public class VLCEventManager : VLCBase
	{
		private VLCNative.libvlc_event_manager_t _instance;
		private GCHandle _this;

		public VLCEventManager (VLCMediaPlayer player)
		{
			_instance = VLCNative.MediaPlayer.libvlc_media_player_event_manager(player.Handler);
			_this = GCHandle.Alloc(this);


			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaMetaChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaSubItemAdded, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaDurationChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaParsedChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaFreed, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaStateChanged, Event_Process); 
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaSubItemTreeAdded, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerMediaChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerNothingSpecial, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerOpening, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerBuffering, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerPlaying, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerPaused, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerStopped, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerForward, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerBackward, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerEndReached, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerEncounteredError, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerPositionChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerSeekableChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerPausableChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerTitleChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerSnapshotTaken, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerLengthChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerVout, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerScrambledChanged, Event_Process);	
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerESAdded, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerESDeleted, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerESSelected, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerCorked, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerUncorked, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerMuted, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerUnmuted, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerAudioVolume, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerAudioDevice, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaPlayerChapterChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListItemAdded, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListWillAddItem, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListItemDeleted, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListWillDeleteItem, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListEndReached, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListViewItemAdded, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListViewWillAddItem, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListViewItemDeleted, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListViewWillDeleteItem, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListPlayerPlayed, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListPlayerNextItemSet, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaListPlayerStopped, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaDiscovererStarted, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_MediaDiscovererEnded, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaAdded, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaRemoved, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaChanged, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaInstanceStarted, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaInstanceStopped, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaInstanceStatusInit, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaInstanceStatusOpening, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaInstanceStatusPlaying, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaInstanceStatusPause, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaInstanceStatusEnd, Event_Process);
			Attach (VLCNative.libvlc_event_type_t.libvlc_VlmMediaInstanceStatusError, Event_Process);

		}

		~VLCEventManager ()
		{
			

		}

		protected override void Dispose(bool disposing)
		{
			
			if (disposing) {

			}

			_this.Free();
		}

		public static VLCEventManager PtrToEvantManager(IntPtr ptr)
		{
			GCHandle handle2 = (GCHandle) ptr;
			return (handle2.Target as VLCEventManager);
		}

		public bool Attach(VLCNative.libvlc_event_type_t event_type,VLCNative.libvlc_callback_t callback)
		{
			if (GetTypeName (event_type) == "Unknown Event")
				return false;
			
			Console.WriteLine ("Try atach event "+(int)event_type+" = "+GetTypeName(event_type));
			int ret = 0;

			try {
				ret = VLCNative.Event.libvlc_event_attach (_instance, event_type, callback, (IntPtr)_this);
					
				if (ret == 0) {
					Console.WriteLine ("Atach event "+event_type);
					return true;
				} else {
					Console.Error.WriteLine ("Can`t atach event Type: "+GetTypeName(event_type)+" Error:"+ret);
				}
			} catch(Exception e) {
				Console.Error.WriteLine ("Can`t atach event Message: "+e.Message);
			}


		

			return false;
		}


		public void Detach (VLCNative.libvlc_event_type_t event_type, VLCNative.libvlc_callback_t callback)
		{
			VLCNative.Event.libvlc_event_detach (_instance, event_type, callback, (IntPtr)_this);
		}

		public string GetTypeName (VLCNative.libvlc_event_type_t event_type)
		{
			
			return Marshal.PtrToStringAnsi(VLCNative.Event.libvlc_event_type_name (event_type));	

		}

		//Evants
		public void Event_Process(VLCNative.libvlc_event_t p_event, IntPtr ptr)
		{
			VLCEventManager _this = PtrToEvantManager (ptr);

			Console.WriteLine ("EVENT");

			throw new Exception ("GOT EVENT");
		}


	}
}

