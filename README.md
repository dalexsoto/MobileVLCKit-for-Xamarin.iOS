# MobileVLCKit for Xamarin.iOS
This repo contains the Mobile VLCKit bindings for **Xamarin.iOS**, it binds [version 2.2.0-RC1](http://get.videolan.org/vlc-iOS/2.3.0/MobileVLCKit-2.2.0-rc1-binary.zip) of **VLCKit**.

## Usage

Add `MobileVLCKit` binary inside the `MobileVLCKit` directory and build the binding. Please note that you might need to `lipo -thin` the library in order to extract the needed arch due to its huge size. 

## License

The **C# bindings** and **sample code** are available under **MIT License**, see the LICENSE.md file for more info.

## Example Code

  ```csharp
  public partial class SimplePlaybackViewController : UIViewController, IVLCMediaPlayerDelegate
	{
		VLCMediaPlayer mediaPlayer;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// setup the media player instance, give it a delegate and something to draw into
			mediaPlayer = new VLCMediaPlayer ();
			mediaPlayer.Delegate = this;
			mediaPlayer.Drawable = PlayerView;

			// create a media object and give it to the player
			mediaPlayer.Media = new VLCMedia (NSUrl.FromString ("http://streams.videolan.org/streams/mp4/Mr_MrsSmith-h264_aac.mp4"));
			
			// Play the content
			mediaPlayer.Play ();
		}
		
		[Export ("mediaPlayerStateChanged:")]
		public void MediaPlayerStateChanged (NSNotification notification)
		{
			Console.WriteLine ("State changed to: {0}", mediaPlayer.GetState ());
		}
	}