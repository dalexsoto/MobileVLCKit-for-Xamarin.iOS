// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SimplePlayback
{
	[Register ("SimplePlaybackViewController")]
	partial class SimplePlaybackViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnPlay { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView PlayerView { get; set; }

		[Action ("btnPlay_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnPlay_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnPlay != null) {
				btnPlay.Dispose ();
				btnPlay = null;
			}
			if (PlayerView != null) {
				PlayerView.Dispose ();
				PlayerView = null;
			}
		}
	}
}
