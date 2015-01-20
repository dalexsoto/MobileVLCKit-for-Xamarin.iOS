#if __UNIFIED__
using ObjCRuntime;
#else
using MonoTouch.ObjCRuntime;
#endif

namespace MobileVLCKit
{
#if __UNIFIED__
	[Native]
	public enum VLCMediaState : long {
#else
	public enum VLCMediaState : int {
#endif
		NothingSpecial,
		Buffering,
		Playing,
		Error
	}

#if __UNIFIED__
	[Native]
	public enum VLCRepeatMode : long {
#else
	public enum VLCRepeatMode : int {
#endif
		DoNotRepeat,
		RepeatCurrentItem,
		RepeatAllItems
	}

#if __UNIFIED__
	[Native]
	public enum VLCMediaPlayerState : long {
#else
	public enum VLCMediaPlayerState : int {
#endif
		Stopped,
		Opening,
		Buffering,
		Ended,
		Error,
		Playing,
		Paused
	}
}

