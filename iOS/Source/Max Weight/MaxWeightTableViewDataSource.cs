using System;
using UIKit;

namespace FitCalculator.iOS
{
	public class MaxWeightTableViewDataSource: UITableViewDataSource
	{
		public MaxWeightCalculator Calculator = new MaxWeightCalculator (new JsonDataManager (new FileStorage()));

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return Calculator.Data.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (MaxWeightCell.Key, indexPath) as MaxWeightCell;
			cell.Data = Calculator.Data [indexPath.Row];
//			cell.TextLabel.Text = data.ToString ();
			//			cell.DetailTextLabel.Text = data.Weight.ToString ();
			return cell;
		}
	}
}

