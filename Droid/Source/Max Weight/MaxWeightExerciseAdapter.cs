using System;
using System.Collections.Generic;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace FitCalculator.Droid
{
	public class MaxWeightExerciseAdapter: BaseAdapter
	{
		public List<MaxWeightCalculator.ExerciseCategory> Data { get { return data; } }

		private List<MaxWeightCalculator.ExerciseCategory> data = new List<MaxWeightCalculator.ExerciseCategory> ();
		private LayoutInflater inflater;

		public MaxWeightExerciseAdapter (Context context)
		{
			inflater = context.GetSystemService (Context.LayoutInflaterService) as LayoutInflater;
			foreach (MaxWeightCalculator.ExerciseCategory exercise in (Enum.GetValues (typeof(MaxWeightCalculator.ExerciseCategory)))) {
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
				textView.Text = MaxWeightCalculator.ExerciseDescription (data [position]);
			}
			return view;
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}
	}
}
