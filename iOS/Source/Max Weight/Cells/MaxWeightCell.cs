using System;

using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	public partial class MaxWeightCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("MaxWeightCell");

		public MaxWeightData Data {
			get {
				return data;
			}
			set {
				data = value;
				UpdateUI ();
			}
		}

		private MaxWeightData data;

		public MaxWeightCell (IntPtr handle) : base (handle)
		{
		}

		private void UpdateUI ()
		{
			if (null != data) {
				RepeatsLabel.Text = string.Format("{0} reps.", data.Repeats);
				WeightLabel.Text = string.Format("{0:0.00} kgs.", data.Weight);
			} else {
				RepeatsLabel.Text = "";
				WeightLabel.Text = "";
			}
		}
	}
}
