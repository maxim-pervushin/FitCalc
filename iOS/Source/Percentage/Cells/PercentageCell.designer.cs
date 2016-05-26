// WARNING
//
// This file has been generated automatically by Xamarin Studio Community to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FitCalculator.iOS
{
	[Register ("PercentageCell")]
	partial class PercentageCell
	{
		[Outlet]
		UIKit.UILabel PercentageLabel { get; set; }

		[Outlet]
		UIKit.UILabel WeightLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (PercentageLabel != null) {
				PercentageLabel.Dispose ();
				PercentageLabel = null;
			}

			if (WeightLabel != null) {
				WeightLabel.Dispose ();
				WeightLabel = null;
			}
		}
	}
}
