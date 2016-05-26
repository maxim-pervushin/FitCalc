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
	[Register ("MaxWeightEditorViewController")]
	partial class MaxWeightEditorViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel RepeatsLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIStepper RepeatsStepper { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField WeightTextField { get; set; }

		[Action ("CancelButtonAction:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CancelButtonAction (UIBarButtonItem sender);

		[Action ("RepeatsStepperValueChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void RepeatsStepperValueChanged (UIStepper sender);

		[Action ("SaveButtonAction:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SaveButtonAction (UIBarButtonItem sender);

		[Action ("WeightTextEditEditingChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void WeightTextEditEditingChanged (UITextField sender);

		void ReleaseDesignerOutlets ()
		{
			if (RepeatsLabel != null) {
				RepeatsLabel.Dispose ();
				RepeatsLabel = null;
			}
			if (RepeatsStepper != null) {
				RepeatsStepper.Dispose ();
				RepeatsStepper = null;
			}
			if (WeightTextField != null) {
				WeightTextField.Dispose ();
				WeightTextField = null;
			}
		}
	}
}
