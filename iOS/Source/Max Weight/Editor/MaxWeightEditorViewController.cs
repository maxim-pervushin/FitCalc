using System;
using UIKit;
using Foundation;

namespace FitCalculator.iOS
{
	public partial class MaxWeightEditorViewController : UITableViewController
	{
		public Action<bool> Finished;

		public MaxWeightData Data { 
			get {  
				return maxWeightData;
			} 
			set { 
				maxWeightData = value;
				ReloadData ();
			} 
		}

		private MaxWeightData maxWeightData;

		public MaxWeightEditorViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			WeightTextField.Delegate = new FloatTextFieldDelegate ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			ReloadData ();
		}

		partial void CancelButtonAction (UIBarButtonItem sender)
		{
			if (null != Finished) {
				Finished (false);
			}
		}

		partial void SaveButtonAction (UIBarButtonItem sender)
		{
			if (null != Finished) {
				Finished (true);
			}
		}

		partial void RepeatsStepperValueChanged (UIStepper sender)
		{
			Data.Repeats = Convert.ToInt32 (sender.Value);
			ReloadData ();
		}

		partial void WeightTextEditEditingChanged (UITextField sender)
		{
			try {
				Data.Weight = Convert.ToSingle (sender.Text);
			} catch (Exception) {				
			}
		}

		private void ReloadData ()
		{
			if (!IsViewLoaded) {
				return;
			}

			if (null != maxWeightData) {
				RepeatsStepper.Value = maxWeightData.Repeats;
				WeightTextField.Text = maxWeightData.Weight.ToString ();
			} else {
				RepeatsStepper.Value = 0;
				WeightTextField.Text = "0";
			}

			RepeatsLabel.Text = RepeatsStepper.Value.ToString ();
		}
	}
}
