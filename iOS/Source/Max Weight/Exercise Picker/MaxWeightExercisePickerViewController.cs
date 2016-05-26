using System;
using System.Collections.Generic;
using UIKit;

namespace FitCalculator.iOS
{
	public partial class MaxWeightExercisePickerViewController : UITableViewController
	{
		public Action<bool> Finished;

		public MaxWeightCalculator.ExerciseCategory Exercise {
			get {
				return exercise;
			}
			set { 
				exercise = value;
				ReloadData ();
			}
		}

		private MaxWeightCalculator.ExerciseCategory exercise;
		private List<MaxWeightCalculator.ExerciseCategory> exercises = new List<MaxWeightCalculator.ExerciseCategory> ();

		public MaxWeightExercisePickerViewController (IntPtr handle) : base (handle)
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
			foreach (MaxWeightCalculator.ExerciseCategory data in Enum.GetValues (typeof(MaxWeightCalculator.ExerciseCategory))) {
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
			var cell = tableView.DequeueReusableCell ("MaxWeightExerciseCell", indexPath);
			var value = exercises [indexPath.Row];
			cell.TextLabel.Text = MaxWeightCalculator.ExerciseDescription(value);
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
