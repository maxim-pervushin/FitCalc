using System;
using System.Collections.Generic;
		
using UIKit;

namespace FitCalculator.iOS
{
	public partial class MaxWeightViewController : UIViewController
	{
		private MaxWeightTableViewDataSource dataSource = new MaxWeightTableViewDataSource ();

		public MaxWeightViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TableView.DataSource = dataSource;
			TableView.Delegate = new MaxWeightTableViewDelegate (this);
			ReloadData ();
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			if ((segue.DestinationViewController is MaxWeightEditorNavigationController) && null != TableView.IndexPathForSelectedRow) {
				var maxWeightEditor = segue.DestinationViewController as MaxWeightEditorNavigationController;
				var indexPath = TableView.IndexPathForSelectedRow;
				var maxWeightData = dataSource.Calculator.Data [indexPath.Row];
				maxWeightEditor.Data = maxWeightData;
				maxWeightEditor.Finished = delegate (bool shouldSave) {
					if (shouldSave) {
						dataSource.Calculator.Repeats = maxWeightEditor.Data.Repeats;
						dataSource.Calculator.Weight = maxWeightEditor.Data.Weight;
						ReloadData();
					} 
					maxWeightEditor.DismissViewController(true, null);
				};
			} else if (segue.DestinationViewController is MaxWeightExercisePickerNavigationController) {
				var maxWeightExercisePicker = segue.DestinationViewController as MaxWeightExercisePickerNavigationController;
				maxWeightExercisePicker.Exercise = dataSource.Calculator.Exercise;
				maxWeightExercisePicker.Finished = delegate (bool shouldSave) {
					if (shouldSave) {
						dataSource.Calculator.Exercise = maxWeightExercisePicker.Exercise;
						ReloadData ();
					}
					maxWeightExercisePicker.DismissViewController (true, null);
				};
			}
		}

		private void ReloadData ()
		{
			var exerciseDescription = MaxWeightCalculator.ExerciseDescription (dataSource.Calculator.Exercise);
			CategoryButton.SetTitle (" " + exerciseDescription, UIControlState.Normal);
			CategoryButton.SetTitle (" " + exerciseDescription, UIControlState.Selected);
			TableView.ReloadData ();
		}
	}
}
