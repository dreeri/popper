// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Popper
{
	[Register ("OptionsViewController")]
	partial class OptionsViewController
	{
		[Outlet]
		UIKit.UILabel label1 { get; set; }

		[Outlet]
		UIKit.UILabel label2 { get; set; }

		[Outlet]
		UIKit.UILabel label3 { get; set; }

		[Outlet]
		UIKit.UISlider slider1 { get; set; }

		[Outlet]
		UIKit.UISlider slider2 { get; set; }

		[Outlet]
		UIKit.UISlider slider3 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (label1 != null) {
				label1.Dispose ();
				label1 = null;
			}

			if (label2 != null) {
				label2.Dispose ();
				label2 = null;
			}

			if (label3 != null) {
				label3.Dispose ();
				label3 = null;
			}

			if (slider1 != null) {
				slider1.Dispose ();
				slider1 = null;
			}

			if (slider2 != null) {
				slider2.Dispose ();
				slider2 = null;
			}

			if (slider3 != null) {
				slider3.Dispose ();
				slider3 = null;
			}
		}
	}
}
