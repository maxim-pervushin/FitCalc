using System;
using System.Collections.Generic;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace FitCalculator.Droid
{
	public class PercentageDataAdapter: BaseAdapter
	{
		public List<PercentageData> Data { 
			set { 
				data = value;
				NotifyDataSetChanged ();
			}
			get { 
				return data;
			}
		}

		private List<PercentageData> data = new List<PercentageData> ();
		private LayoutInflater inflater;

		public PercentageDataAdapter (Context context)
		{
			inflater = context.GetSystemService (Context.LayoutInflaterService) as LayoutInflater;
		}

		public override int Count {
			get {
				return data.Count;
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			if (null == view) {
				view = inflater.Inflate (Resource.Layout.percentage_cell, null);
			}
			var percentageTextView = view.FindViewById (Resource.Id.percentage_text_view) as TextView;
			if (null != percentageTextView) {
				percentageTextView.Text = string.Format ("{0:0}%", data [position].Percentage);
			}
			var weightTextView = view.FindViewById (Resource.Id.weight_text_view) as TextView;
			if (null != weightTextView) {
				weightTextView.Text = string.Format ("{0:0.00} kgs.", data [position].Weight);
			}

			return view;
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}
	}
}

