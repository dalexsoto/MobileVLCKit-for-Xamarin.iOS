using System;

#if __UNIFIED__
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;

using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace MobileVLCKit
{
	[BaseType (typeof (NSObject))]
	interface VLCAudio 
	{
		[Field ("VLCMediaPlayerVolumeChanged", "__Internal")]
		[Notification]
		NSString VolumeChangedNotification { get; }

		[Export ("isMuted")]
		bool IsMuted { get; [Bind ("setMute:")] set; }

		[Export ("volume", ArgumentSemantic.UnsafeUnretained)]
		int Volume { get; set; }

		[Export ("volumeDown")]
		void VolumeDown ();

		[Export ("volumeUp")]
		void VolumeUp ();
	}

	[BaseType (typeof (NSObject))]
	interface VLCLibrary 
	{
		[Static, Export ("sharedLibrary")]
		VLCLibrary SharedLibrary { get; }

		[Export ("initWithOptions:")]
		IntPtr Constructor ([NullAllowed] string [] options);

		[Export ("version")]
		string Version { get; }

		[Export ("compiler")]
		string Compiler { get; }

		[Export ("changeset")]
		string Changeset { get; }

		[Export ("setHumanReadableName:withHTTPUserAgent:")]
		void SetHumanReadableName (string readableName, string userAgent);

		[Export ("setApplicationIdentifier:withVersion:andApplicationIconName:")]
		void SetApplicationIdentifier (string identifier, string version, string icon);
	}

	[Static]
	interface VLCMetaInformation
	{
		[Field ("VLCMetaInformationTitle", "__Internal")]
		NSString TitleKey { get; }

		[Field ("VLCMetaInformationArtist", "__Internal")]
		NSString ArtistKey { get; }

		[Field ("VLCMetaInformationGenre", "__Internal")]
		NSString GenreKey { get; }

		[Field ("VLCMetaInformationCopyright", "__Internal")]
		NSString CopyrightKey { get; }

		[Field ("VLCMetaInformationAlbum", "__Internal")]
		NSString AlbumKey { get; }

		[Field ("VLCMetaInformationTrackNumber", "__Internal")]
		NSString TrackNumberKey { get; }

		[Field ("VLCMetaInformationDescription", "__Internal")]
		NSString DescriptionKey { get; }

		[Field ("VLCMetaInformationRating", "__Internal")]
		NSString RatingKey { get; }

		[Field ("VLCMetaInformationDate", "__Internal")]
		NSString DateKey { get; }

		[Field ("VLCMetaInformationSetting", "__Internal")]
		NSString SettingKey { get; }

		[Field ("VLCMetaInformationURL", "__Internal")]
		NSString UrlKey { get; }

		[Field ("VLCMetaInformationLanguage", "__Internal")]
		NSString LanguageKey { get; }

		[Field ("VLCMetaInformationNowPlaying", "__Internal")]
		NSString NowPlayingKey { get; }

		[Field ("VLCMetaInformationPublisher", "__Internal")]
		NSString PublisherKey { get; }

		[Field ("VLCMetaInformationEncodedBy", "__Internal")]
		NSString EncodedByKey { get; }

		[Field ("VLCMetaInformationArtworkURL", "__Internal")]
		NSString ArtworkUrlKey { get; }

		[Field ("VLCMetaInformationArtwork", "__Internal")]
		NSString ArtworkKey { get; }

		[Field ("VLCMetaInformationTrackID", "__Internal")]
		NSString TrackIdKey { get; }
	}

	[Static]
	interface VLCMediaTracksInformation
	{
		[Field ("VLCMediaTracksInformationCodec", "__Internal")]
		NSString CodecKey { get; }

		[Field ("VLCMediaTracksInformationId", "__Internal")]
		NSString IdKey { get; }

		[Field ("VLCMediaTracksInformationType", "__Internal")]
		NSString TypeKey { get; }

		[Field ("VLCMediaTracksInformationCodecProfile", "__Internal")]
		NSString CodecProfileKey { get; }

		[Field ("VLCMediaTracksInformationCodecLevel", "__Internal")]
		NSString CodecLevelKey { get; }

		[Field ("VLCMediaTracksInformationBitrate", "__Internal")]
		NSString BitrateKey { get; }

		[Field ("VLCMediaTracksInformationLanguage", "__Internal")]
		NSString LanguageKey { get; }

		[Field ("VLCMediaTracksInformationDescription", "__Internal")]
		NSString DescriptionKey { get; }

		[Field ("VLCMediaTracksInformationAudioChannelsNumber", "__Internal")]
		NSString AudioChannelsNumberKey { get; }

		[Field ("VLCMediaTracksInformationAudioRate", "__Internal")]
		NSString AudioRateKey { get; }

		[Field ("VLCMediaTracksInformationVideoHeight", "__Internal")]
		NSString VideoHeightKey { get; }

		[Field ("VLCMediaTracksInformationVideoWidth", "__Internal")]
		NSString VideoWidthKey { get; }

		[Field ("VLCMediaTracksInformationSourceAspectRatio", "__Internal")]
		NSString SourceAspectRatioKey { get; }

		[Field ("VLCMediaTracksInformationFrameRate", "__Internal")]
		NSString FrameRateKey { get; }

		[Field ("VLCMediaTracksInformationFrameRateDenominator", "__Internal")]
		NSString FrameRateDenominatorKey { get; }

		[Field ("VLCMediaTracksInformationTextEncoding", "__Internal")]
		NSString TextEncodingKey { get; }

		[Field ("VLCMediaTracksInformationTypeAudio", "__Internal")]
		NSString TypeAudioKey { get; }

		[Field ("VLCMediaTracksInformationTypeVideo", "__Internal")]
		NSString TypeVideoKey { get; }

		[Field ("VLCMediaTracksInformationTypeText", "__Internal")]
		NSString TypeTextKey { get; }

		[Field ("VLCMediaTracksInformationTypeUnknown", "__Internal")]
		NSString TypeUnknownKey { get; }
	}

	interface IVLCMediaDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface VLCMediaDelegate 
	{

		[Export ("media:metaValueChangedFrom:forKey:")]
		[Abstract]
		void MetaValueChanged (VLCMedia media, NSObject oldValue, NSString key);

		[Export ("mediaMetaDataDidChange:")]
		[Abstract]
		void MediaMetaDataDidChange (VLCMedia media);

		[Export ("mediaDidFinishParsing:")]
		[Abstract]
		void MediaDidFinishParsing (VLCMedia media);
	}

	[BaseType (typeof (NSObject))]
	interface VLCMedia 
	{
		[Field ("VLCMediaMetaChanged", "__Internal")]
		[Notification]
		NSString MediaMetadataChangedNotification { get; }

		[Static, Export ("mediaWithURL:")]
		VLCMedia FromUrl (NSUrl url);

		[Static, Export ("mediaWithPath:")]
		VLCMedia FromPath (string path);

		[Static, Export ("mediaAsNodeWithName:")]
		VLCMedia FromMediaAsNode (string name);

		[Export ("initWithURL:")]
		IntPtr Constructor (NSUrl url);

		[Export ("initWithPath:")]
		IntPtr Constructor (string path);

		[Export ("compare:")]
		NSComparisonResult Compare ([NullAllowed] VLCMedia media);

		[Export ("delegate", ArgumentSemantic.Weak)][NullAllowed]
		IVLCMediaDelegate Delegate { get; set; }

		[Export ("length", ArgumentSemantic.Retain)]
		VLCTime Length { get; }

		[Export ("lengthWaitUntilDate:")]
		VLCTime LengthWaitUntilDate (NSDate aDate);

		[Export ("isParsed")]
		bool IsParsed { get; }

		[Export ("url", ArgumentSemantic.Retain)]
		NSUrl Url { get; }

		[Export ("subitems", ArgumentSemantic.Retain)]
		VLCMediaList Subitems { get; }

		[Export ("metadataForKey:")]
		string MetadataForKey (NSString key);

		[Export ("setMetadata:forKey:")]
		void SetMetadata (string data, NSString key);

		[Export ("saveMetadata")]
		bool SaveMetadata ();

		[Export ("metaDictionary", ArgumentSemantic.Retain)]
		NSDictionary MetaDictionary { get; }

		[Export ("state")]
		VLCMediaState State { get; }

		[Export ("isMediaSizeSuitableForDevice")]
		bool IsMediaSizeSuitableForDevice ();

		// Keys from VLCMediaTracksInformation
		// TODO: Strongify 
		[Export ("tracksInformation")]
		NSDictionary [] TracksInformation ();

		[Export ("parse")]
		void Parse ();

		[Export ("synchronousParse")]
		void SynchronousParse ();

		[Export ("addOptions:")]
		void AddOptions (NSDictionary options);

		[Export ("stats")]
		NSDictionary Stats ();

		[Export ("numberOfReadBytesOnInput")]
		nint NumberOfReadBytesOnInput ();

		[Export ("inputBitrate")]
		float InputBitrate ();

		[Export ("numberOfReadBytesOnDemux")]
		nint NumberOfReadBytesOnDemux ();

		[Export ("demuxBitrate")]
		float DemuxBitrate ();

		[Export ("numberOfDecodedVideoBlocks")]
		nint NumberOfDecodedVideoBlocks ();

		[Export ("numberOfDecodedAudioBlocks")]
		nint NumberOfDecodedAudioBlocks ();

		[Export ("numberOfDisplayedPictures")]
		nint NumberOfDisplayedPictures ();

		[Export ("numberOfLostPictures")]
		nint NumberOfLostPictures ();

		[Export ("numberOfPlayedAudioBuffers")]
		nint NumberOfPlayedAudioBuffers ();

		[Export ("numberOfLostAudioBuffers")]
		nint NumberOfLostAudioBuffers ();

		[Export ("numberOfSentPackets")]
		nint NumberOfSentPackets ();

		[Export ("numberOfSentBytes")]
		nint NumberOfSentBytes ();

		[Export ("streamOutputBitrate")]
		float StreamOutputBitrate ();

		[Export ("numberOfCorruptedDataPackets")]
		nint NumberOfCorruptedDataPackets ();

		[Export ("numberOfDiscontinuties")]
		nint NumberOfDiscontinuties ();
	}

	[BaseType (typeof (NSObject))]
	interface VLCMediaDiscoverer 
	{
		[Static, Export ("availableMediaDiscoverer")]
		VLCMediaDiscoverer [] GetAvailableMediaDiscoverer ();

		[Export ("initWithName:")]
		IntPtr Constructor (string serviceName);

		[Export ("discoveredMedia")]
		VLCMediaList DiscoveredMedia { get; }

		[Export ("localizedName")]
		string LocalizedName { get; }

		[Export ("isRunning")]
		bool IsRunning { get; }
	}

	interface IVLCMediaListDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface VLCMediaListDelegate {

		[Export ("mediaList:mediaAdded:atIndex:")]
		void MediaAdded (VLCMediaList mediaList, VLCMedia media, nint index);

		[Export ("mediaList:mediaRemovedAtIndex:")]
		void MediaRemoved (VLCMediaList mediaList, nint atIndex);
	}

	[BaseType (typeof (NSObject))]
	interface VLCMediaList 
	{
		[Field ("VLCMediaListItemAdded", "__Internal")]
		[Notification]
		NSString ItemAddedNotification { get; }

		[Field ("VLCMediaListItemDeleted", "__Internal")]
		[Notification]
		NSString ItemDeletedNotification { get; }

		[Export ("initWithArray:")]
		IntPtr Constructor (VLCMedia [] mediaArr);

		[Export ("lock")]
		void Lock ();

		[Export ("unlock")]
		void Unlock ();

		[Export ("addMedia:")]
		nint AddMedia (VLCMedia media);

		[Export ("insertMedia:atIndex:")]
		void InsertMedia (VLCMedia media, nint index);

		[Export ("removeMediaAtIndex:")]
		void RemoveMedia (nint index);

		[Export ("mediaAtIndex:")]
		VLCMedia MediaAt (nint index);

		[Export ("indexOfMedia:")]
		nint IndexOfMedia (VLCMedia media);

		[Export ("count")]
		nint Count { get; }

		[Export ("delegate", ArgumentSemantic.Weak)][NullAllowed]
		IVLCMediaListDelegate Delegate { get; set; }

		[Export ("isReadOnly")]
		bool IsReadOnly { get; }
	}

	[BaseType (typeof (NSObject))]
	interface VLCMediaListPlayer 
	{
		[Export ("mediaList", ArgumentSemantic.Retain)]
		VLCMediaList MediaList { get; set; }

		[Export ("rootMedia", ArgumentSemantic.Retain)]
		VLCMedia RootMedia { get; set; }

		[Export ("mediaPlayer", ArgumentSemantic.Retain)]
		VLCMediaPlayer MediaPlayer { get; }

		[Export ("initWithOptions:")]
		IntPtr Constructor (NSObject [] options);

		[Export ("play")]
		void Play ();

		[Export ("pause")]
		void Pause ();

		[Export ("stop")]
		void Stop ();

		[Export ("next")]
		bool Next ();

		[Export ("previous")]
		bool Previous ();

		[Export ("playItemAtIndex:")]
		bool PlayItem (int index);

		[Export ("repeatMode")]
		VLCRepeatMode RepeatMode { get; set; }

		[Export ("playMedia:")]
		void PlayMedia (VLCMedia media);
	}

	interface IVLCMediaPlayerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface VLCMediaPlayerDelegate 
	{

		[Export ("mediaPlayerStateChanged:")]
		void MediaPlayerStateChanged (NSNotification notification);

		[Export ("mediaPlayerTimeChanged:")]
		void MediaPlayerTimeChanged (NSNotification notification);
	}

	[BaseType (typeof (NSObject))]
	interface VLCMediaPlayer 
	{
		[Field ("VLCMediaPlayerTimeChanged", "__Internal")]
		[Notification]
		NSString TimeChangedNotification { get; }

		[Field ("VLCMediaPlayerStateChanged", "__Internal")]
		[Notification]
		NSString StateChangedNotification { get; }

		[Export ("libraryInstance")]
		VLCLibrary LibraryInstance { get; }

		[Export ("initWithOptions:")]
		IntPtr Constructor (NSObject [] options);

		[Export ("delegate", ArgumentSemantic.Weak)][NullAllowed]
		IVLCMediaPlayerDelegate Delegate { get; set; }

		[Export ("drawable", ArgumentSemantic.Retain)]
		NSObject Drawable { get; set; }

		[Export ("videoAspectRatio")][NullAllowed][PlainString]
		string VideoAspectRatio { get; set; }

		[Export ("videoCropGeometry")][NullAllowed][PlainString]
		string VideoCropGeometry { get; set; }

		[Export ("scaleFactor")]
		float ScaleFactor { get; set; }

		[Export ("saveVideoSnapshotAt:withWidth:andHeight:")]
		void SaveVideoSnapshot (string path, int width, int height);

		[Export ("setDeinterlaceFilter:")]
		void SetDeinterlaceFilter ([NullAllowed] string name);

		[Export ("adjustFilterEnabled")]
		bool AdjustFilterEnabled { get; set; }

		[Export ("contrast")]
		float Contrast { get; set; }

		[Export ("brightness")]
		float Brightness { get; set; }

		[Export ("hue")]
		int Hue { get; set; }

		[Export ("saturation")]
		float Saturation { get; set; }

		[Export ("gamma")]
		float Gamma { get; set; }

		[Export ("rate")]
		float Rate { get; set; }

		[Export ("audio")]
		VLCAudio Audio { get; }

		[Export ("videoSize")]
		CGSize VideoSize { get; }

		[Export ("hasVideoOut")]
		bool HasVideoOut { get; }

		[Export ("framesPerSecond")]
		float FramesPerSecond { get; }

		[Export ("time")]
		VLCTime Time { get; set; }

		[Export ("remainingTime")]
		VLCTime RemainingTime { get; }

		[Export ("currentVideoTrackIndex")]
		nuint CurrentVideoTrackIndex { get; set; }

		[Export ("videoTrackNames")]
		string [] VideoTrackNames { get; }

		[Export ("videoTrackIndexes")]
		NSValue [] VideoTrackIndexes { get; }

		[Export ("currentVideoSubTitleIndex")]
		nuint CurrentVideoSubTitleIndex { get; set; }

		[Export ("videoSubTitlesNames")]
		string [] VideoSubTitlesNames ();

		[Export ("videoSubTitlesIndexes")]
		NSValue [] VideoSubTitlesIndexes ();

		[Export ("openVideoSubTitlesFromFile:")]
		bool OpenVideoSubTitlesFromFile (string path);

		[Export ("currentVideoSubTitleDelay")]
		nint CurrentVideoSubTitleDelay { get; set; }

		[Export ("currentChapterIndex")]
		int CurrentChapterIndex { get; set; }

		[Export ("previousChapter")]
		void PreviousChapter ();

		[Export ("nextChapter")]
		void NextChapter ();

		[Export ("chaptersForTitleIndex:")]
		NSValue [] ChaptersForTitleIndex (int titleIndex);

		[Export ("currentTitleIndex")]
		nuint CurrentTitleIndex { get; set; }

		[Export ("titles")]
		string [] Titles { get; }

		[Export ("currentAudioTrackIndex")]
		nuint CurrentAudioTrackIndex { get; set; }

		[Export ("audioTrackNames")]
		string [] AudioTrackNames { get; }

		[Export ("audioTrackIndexes")]
		NSValue [] AudioTrackIndexes { get; }

		[Export ("audioChannel")]
		int AudioChannel { get; set; }

		[Export ("currentAudioPlaybackDelay")]
		nint CurrentAudioPlaybackDelay { get; set; }

		[Export ("equalizerProfiles")]
		NSObject [] EqualizerProfiles { get; }

		[Export ("resetEqualizerFromProfile:")]
		void ResetEqualizerFromProfile (uint profile);

		[Export ("equalizerEnabled")]
		bool EqualizerEnabled { get; set; }

		[Export ("preAmplification")]
		nfloat PreAmplification { get; set; }

		[Export ("numberOfBands")]
		uint NumberOfBands { get; }

		[Export ("frequencyOfBandAtIndex:")]
		nfloat FrequencyOfBand (uint index);

		[Export ("setAmplification:forBand:")]
		void SetAmplification (nfloat amplification, uint index);

		[Export ("amplificationOfBand:")]
		nfloat AmplificationOfBand (uint index);

		[Export ("media")]
		VLCMedia Media { get; set; }

		[Export ("play")]
		bool Play ();

		[Export ("pause")]
		void Pause ();

		[Export ("stop")]
		void Stop ();

		[Export ("gotoNextFrame")]
		void GotoNextFrame ();

		[Export ("fastForward")]
		void FastForward ();

		[Export ("fastForwardAtRate:")]
		void FastForward (float rate);

		[Export ("rewind")]
		void Rewind ();

		[Export ("rewindAtRate:")]
		void Rewind (float rate);

		[Export ("jumpBackward:")]
		void JumpBackward (int interval);

		[Export ("jumpForward:")]
		void JumpForward (int interval);

		[Export ("extraShortJumpBackward")]
		void ExtraShortJumpBackward ();

		[Export ("extraShortJumpForward")]
		void ExtraShortJumpForward ();

		[Export ("shortJumpBackward")]
		void ShortJumpBackward ();

		[Export ("shortJumpForward")]
		void ShortJumpForward ();

		[Export ("mediumJumpBackward")]
		void MediumJumpBackward ();

		[Export ("mediumJumpForward")]
		void MediumJumpForward ();

		[Export ("longJumpBackward")]
		void LongJumpBackward ();

		[Export ("longJumpForward")]
		void LongJumpForward ();

		[Export ("isPlaying")]
		bool IsPlaying ();

		[Export ("willPlay")]
		bool WillPlay ();

		[Export ("state")]
		VLCMediaPlayerState GetState ();

		[Export ("position")]
		float Position { get; set; }

		[Export ("isSeekable")]
		bool IsSeekable ();

		[Export ("canPause")]
		bool CanPause ();
	}

	interface IVLCMediaThumbnailerDelegate { }

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface VLCMediaThumbnailerDelegate {

		[Export ("mediaThumbnailerDidTimeOut:")]
		[Abstract]
		void DidTimeOut (VLCMediaThumbnailer mediaThumbnailer);

		[Export ("mediaThumbnailer:didFinishThumbnail:")]
		[Abstract]
		void DidFinishThumbnail (VLCMediaThumbnailer mediaThumbnailer, CGImage thumbnail);
	}

	[BaseType (typeof (NSObject))]
	interface VLCMediaThumbnailer 
	{
		[Static, Export ("thumbnailerWithMedia:andDelegate:")]
		VLCMediaThumbnailer FromMedia (VLCMedia media, [NullAllowed] IVLCMediaThumbnailerDelegate aDelegate);

		[Static, Export ("thumbnailerWithMedia:delegate:andVLCLibrary:")]
		VLCMediaThumbnailer FromMedia (VLCMedia media, [NullAllowed] IVLCMediaThumbnailerDelegate aDelegate, VLCLibrary library);

		[Export ("fetchThumbnail")]
		void FetchThumbnail ();

		[Export ("delegate", ArgumentSemantic.Weak)][NullAllowed]
		IVLCMediaThumbnailerDelegate Delegate { get; set; }

		[Export ("media", ArgumentSemantic.Retain)]
		VLCMedia Media { get; set; }

		[Export ("thumbnail", ArgumentSemantic.Assign)]
		CGImage Thumbnail { get; set; }

		[Export ("libVLCinstance")]
		NSObject LibVLCinstance { get; set; }

		[Export ("thumbnailHeight", ArgumentSemantic.Assign)]
		nfloat ThumbnailHeight { get; set; }

		[Export ("thumbnailWidth", ArgumentSemantic.Assign)]
		nfloat ThumbnailWidth { get; set; }

		[Export ("snapshotPosition", ArgumentSemantic.Assign)]
		float SnapshotPosition { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface VLCTime : INSCopying 
	{
		[Static, Export ("nullTime")]
		VLCTime NullTime { get; }

		[Static, Export ("timeWithNumber:")]
		VLCTime FromNumber (NSNumber number);

		[Static, Export ("timeWithInt:")]
		VLCTime FromInt (int aInt);

		[Export ("initWithNumber:")]
		IntPtr Constructor (NSNumber number);

		[Export ("initWithInt:")]
		IntPtr Constructor (int aInt);

		[Export ("numberValue")]
		NSNumber NumberValue { get; }

		[Export ("stringValue")]
		string StringValue { get; }

		[Export ("verboseStringValue")]
		string VerboseStringValue { get; }

		[Export ("minuteStringValue")]
		string MinuteStringValue { get; }

		[Export ("intValue")]
		int IntValue { get; }

		[Export ("compare:")]
		NSComparisonResult Compare (VLCTime aTime);
	}
}

