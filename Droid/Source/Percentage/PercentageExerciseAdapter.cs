using System;
using System.Collections.Generic;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace FitCalculator.Droid
{
	public class PercentageExerciseAdapter: BaseAdapter
	{
		public List<PercentageCalculator.ExerciseCategory> Data { get { return data; } }

		private List<PercentageCalculator.ExerciseCategory> data = new List<PercentageCalculator.ExerciseCategory> ();
		private LayoutInflater inflater;

		public PercentageExerciseAdapter (Context context)
		{
			inflater = context.GetSystemService (Context.LayoutInflaterService) as LayoutInflater;
			foreach (PercentageCalculator.ExerciseCategory exercise in (Enum.GetValues (typeof(PercentageCalculator.ExerciseCategory)))) {
				data.Add (exercise);
			}
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
				view = inflater.Inflate (Resource.Layout.spinner_item, null);
			}
			TextView textView = view as TextView;
			if (null != textView) {
				textView.Text = PercentageCalculator.ExerciseDescription (data [position]);
			}
			return view;
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}
	}
}
