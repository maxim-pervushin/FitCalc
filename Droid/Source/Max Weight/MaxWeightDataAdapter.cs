using System;
using System.Collections.Generic;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace FitCalculator.Droid
{
	public class MaxWeightDataAdapter: BaseAdapter
	{
		public List<MaxWeightData> Data { 
			set { 
				data = value;
				NotifyDataSetChanged ();
			}
			get { 
				return data;
			}
		}

		private List<MaxWeightData> data = new List<MaxWeightData> ();
		private LayoutInflater inflater;

		public MaxWeightDataAdapter (Context context)
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
				view = inflater.Inflate (Resource.Layout.max_weight_cell, null);
			}
			var repeatsTextView = view.FindViewById (Resource.Id.repeats_text_view) as TextView;
			if (null != repeatsTextView) {
				repeatsTextView.Text = string.Format ("{0} reps.", data [position].Repeats);
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
