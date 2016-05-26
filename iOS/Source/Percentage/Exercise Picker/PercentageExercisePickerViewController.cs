using System;
using System.Collections.Generic;
using UIKit;

namespace FitCalculator.iOS
{
	public partial class PercentageExercisePickerViewController : UITableViewController
	{
		public Action<bool> Finished;

		public PercentageCalculator.ExerciseCategory Exercise {
			get {
				return exercise;
			}
			set { 
				exercise = value;
				ReloadData ();
			}
		}

		private PercentageCalculator.ExerciseCategory exercise;
		private List<PercentageCalculator.ExerciseCategory> exercises = new List<PercentageCalculator.ExerciseCategory> ();

		public PercentageExercisePickerViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			ReloadData ();
		}

		private void ReloadData ()
		{
			exercises.Clear ();
			foreach (PercentageCalculator.ExerciseCategory data in Enum.GetValues (typeof(PercentageCalculator.ExerciseCategory))) {
				exercises.Add (data);
			}
			TableView.ReloadData ();
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return exercises.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("PercentageExerciseCell", indexPath);
			var value = exercises [indexPath.Row];
			cell.TextLabel.Text = PercentageCalculator.ExerciseDescription (value);
			if (value == exercise) {
				cell.Accessory = UITableViewCellAccessory.Checkmark;
			} else {
				cell.Accessory = UITableViewCellAccessory.None;
			}
			return cell;
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
			exercise = exercises [indexPath.Row];
			if (null != Finished) {				
				Finished (true);
			}
		}
	}
}
