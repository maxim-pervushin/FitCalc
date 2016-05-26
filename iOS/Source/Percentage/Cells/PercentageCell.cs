using System;

using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	public partial class PercentageCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("PercentageCell");

		public PercentageData Data {
			get {
				return data;
			}
			set {
				data = value;
				UpdateUI ();
			}
		}

		private PercentageData data;

		public PercentageCell (IntPtr handle) : base (handle)
		{
		}

		private void UpdateUI ()
		{
			if (null != data) {
				PercentageLabel.Text = string.Format("{0}%", data.Percentage);
				WeightLabel.Text = string.Format("{0:0.00} kgs.", data.Weight);
			} else {
				PercentageLabel.Text = "";
				WeightLabel.Text = "";
			}
		}
	}
}
