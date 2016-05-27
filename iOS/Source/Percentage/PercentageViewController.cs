using System;

using UIKit;

namespace FitCalculator.iOS
{
	public partial class PercentageViewController : UITableViewController
	{
		private PercentageCalculator calculator = new PercentageCalculator (new JsonDataManager (new FileStorage()));

		public PercentageViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			ReloadData ();
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			if (segue.DestinationViewController is PercentageEditorNavigationController && null != TableView.IndexPathForSelectedRow) {
				var indexPath = TableView.IndexPathForSelectedRow;
				var percentageEditor = segue.DestinationViewController as PercentageEditorNavigationController;
				percentageEditor.Data = calculator.Data [indexPath.Row];
				percentageEditor.Finished = delegate (bool shouldSave) {
					if (shouldSave) {
						calculator.Weight = percentageEditor.Data.Weight;
						calculator.Percentage = percentageEditor.Data.Percentage;
						ReloadData ();
					}
					percentageEditor.DismissViewController (true, null);
				};
			} else if (segue.DestinationViewController is PercentageExercisePickerNavigationController) {
				var percentageExercisePicker = segue.DestinationViewController as PercentageExercisePickerNavigationController;
				percentageExercisePicker.Exercise = calculator.Exercise;
				percentageExercisePicker.Finished = delegate (bool shouldSave) {
					if (shouldSave) {
						calculator.Exercise = percentageExercisePicker.Exercise;
						ReloadData ();
					}
					percentageExercisePicker.DismissViewController (true, null);
				};
			}
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return calculator.Data.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (PercentageCell.Key, indexPath) as PercentageCell;
			cell.Data = calculator.Data [indexPath.Row];
			return cell;
		}

		private void ReloadData ()
		{
			var exerciseDescription = PercentageCalculator.ExerciseDescription (calculator.Exercise);
			ExerciseButton.SetTitle (exerciseDescription, UIControlState.Normal);
			ExerciseButton.SetTitle (exerciseDescription, UIControlState.Selected);
			TableView.ReloadData ();
		}
	}
}
