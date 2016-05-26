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
	[Register ("MaxWeightCell")]
	partial class MaxWeightCell
	{
		[Outlet]
		UIKit.UILabel RepeatsLabel { get; set; }

		[Outlet]
		UIKit.UILabel WeightLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (RepeatsLabel != null) {
				RepeatsLabel.Dispose ();
				RepeatsLabel = null;
			}

			if (WeightLabel != null) {
				WeightLabel.Dispose ();
				WeightLabel = null;
			}
		}
	}
}
