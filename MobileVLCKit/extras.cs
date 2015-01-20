using System;
using System.Collections;
using System.Collections.Generic;

#if __UNIFIED__
using Foundation;
#else
using MonoTouch.Foundation;
#endif

namespace MobileVLCKit
{
	public partial class VLCMediaList : NSObject, IEnumerable<VLCMedia>
	{
		IEnumerator<VLCMedia> IEnumerable<VLCMedia>.GetEnumerator ()
		{
			for (nint i = 0; i < Count; i++) {
				yield return MediaAt (i);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			for (nint i = 0; i < Count; i++) {
				yield return MediaAt (i);
			}
		}

		public VLCMedia this [int index] {
			get {
				return MediaAt (index);
			}
			set {
				InsertMedia (value, index);
			}
		}
	}
}

