using System;
using System.Drawing;

using Foundation;
using UIKit;

using MobileVLCKit;

namespace SimplePlayback
{
	public partial class SimplePlaybackViewController : UIViewController, IVLCMediaPlayerDelegate
	{
		public SimplePlaybackViewController (IntPtr handle) : base (handle)
		{
		}

		VLCMediaPlayer mediaPlayer;

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// setup the media player instance, give it a delegate and something to draw into
			mediaPlayer = new VLCMediaPlayer ();
			mediaPlayer.Delegate = this;
			mediaPlayer.Drawable = PlayerView;

			// create a media object and give it to the player
			mediaPlayer.Media = new VLCMedia (NSUrl.FromString ("http://streams.videolan.org/streams/mp4/Mr_MrsSmith-h264_aac.mp4"));
		}


		partial void btnPlay_TouchUpInside (UIButton sender)
		{
			mediaPlayer.Play ();
		}

		[Export ("mediaPlayerStateChanged:")]
		public void MediaPlayerStateChanged (Foundation.NSNotification notification)
		{
			Console.WriteLine ("State changed to: {0}", mediaPlayer.GetState ());
		}
	}
}

