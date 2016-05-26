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

namespace FitCalculator.iOS
{
	[Register ("PercentageEditorViewController")]
	partial class PercentageEditorViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PercentageLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIStepper PercentageStepper { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField WeightTextField { get; set; }

		[Action ("CancelButtonAction:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CancelButtonAction (UIBarButtonItem sender);

		[Action ("PercentageStepperValueChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PercentageStepperValueChanged (UIStepper sender);

		[Action ("SaveButtonAction:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SaveButtonAction (UIBarButtonItem sender);

		[Action ("WeightTextEditEditingChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void WeightTextEditEditingChanged (UITextField sender);

		void ReleaseDesignerOutlets ()
		{
			if (PercentageLabel != null) {
				PercentageLabel.Dispose ();
				PercentageLabel = null;
			}
			if (PercentageStepper != null) {
				PercentageStepper.Dispose ();
				PercentageStepper = null;
			}
			if (WeightTextField != null) {
				WeightTextField.Dispose ();
				WeightTextField = null;
			}
		}
	}
}
