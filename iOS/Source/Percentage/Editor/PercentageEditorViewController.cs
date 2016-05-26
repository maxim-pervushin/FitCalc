using System;
using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	public partial class PercentageEditorViewController : UITableViewController
	{
		public Action<bool> Finished;

		public PercentageData Data { 
			get {  
				return data;
			} 
			set { 
				data = value;
				ReloadData ();
			} 
		}

		private PercentageData data;

		public PercentageEditorViewController (IntPtr handle) : base (handle)
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

		partial void PercentageStepperValueChanged (UIStepper sender)
		{
			Data.Percentage = Convert.ToInt32 (sender.Value);
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

			if (null != data) {
				PercentageStepper.Value = data.Percentage;
				WeightTextField.Text = data.Weight.ToString ();
			} else {
				PercentageStepper.Value = 0;
				WeightTextField.Text = "0";
			}

			PercentageLabel.Text = PercentageStepper.Value.ToString ();
		}
	}
}
