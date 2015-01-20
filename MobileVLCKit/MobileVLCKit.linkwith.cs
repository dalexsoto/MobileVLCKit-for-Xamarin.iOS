using System;

#if __UNIFIED__
using ObjCRuntime;
using Foundation;
#else
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
#endif


// This attribute allows you to mark your assemblies as “safe to link”.
// When the attribute is present, the linker—if enabled—will process the assembly
// even if you’re using the “Link SDK assemblies only” option, which is the default for device builds.
[assembly: LinkerSafe]

[assembly: LinkWith ("MobileVLCKit", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Arm64 | LinkTarget.Simulator64, Frameworks = "AudioToolbox CoreAudio OpenGLES CFNetwork CoreText QuartzCore CoreGraphics UIKit Security", LinkerFlags = "-lbz2 -liconv -lstdc++", IsCxx = true, SmartLink = true, ForceLoad = true)]
