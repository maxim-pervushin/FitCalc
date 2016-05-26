using System;
using UIKit;

namespace FitCalculator.iOS
{
	public class MaxWeightTableViewDelegate: UITableViewDelegate
	{
		private MaxWeightViewController viewController;

		public MaxWeightTableViewDelegate (MaxWeightViewController viewController)
		{
			this.viewController = viewController;
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
		}
	}
}
	