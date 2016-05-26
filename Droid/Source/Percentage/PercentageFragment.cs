using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.App;
using System;

namespace FitCalculator.Droid
{
	public class PercentageFragment : Fragment
	{
		private PercentageCalculator calculator;
		private PercentageDataAdapter dataAdapter;
		private PercentageExerciseAdapter exerciseAdapter;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			calculator = new PercentageCalculator (new JsonDataManager (new FileStorage(Context)));
			dataAdapter = new  PercentageDataAdapter (Context);
			exerciseAdapter = new PercentageExerciseAdapter (Context);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.percentage_fragment, container, false);

			Spinner spinner = (Spinner)view.FindViewById (Resource.Id.exercise_spinner);
			spinner.Adapter = exerciseAdapter;
			spinner.ItemSelected += SpinnerItemClick;

			ListView listView = (ListView)view.FindViewById (Resource.Id.list_view);
			listView.Adapter = dataAdapter;
			listView.ItemClick += ListViewItemClick;

			ReloadData ();

			return view;
		}

		private void SpinnerItemClick (object sender, AdapterView.ItemSelectedEventArgs e)
		{			
			calculator.Exercise = exerciseAdapter.Data [e.Position];
			ReloadData ();
		}

		private void ListViewItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{			
			var data = dataAdapter.Data[e.Position];
			ShowEditDialog (data.Weight, data.Percentage);
		}

		private void ReloadData ()
		{
			dataAdapter.Data = calculator.Data;
		}

		private void ShowEditDialog (float Weight, float Percentage)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder (Activity, Resource.Style.AlertDialogCustom);
			LayoutInflater inflater = Activity.LayoutInflater;
			View view = inflater.Inflate (Resource.Layout.edit_percentage_dialog, null);
			EditText weightEditText = (EditText)view.FindViewById (Resource.Id.weight_edit_text);
			weightEditText.Text = Weight.ToString ();
			EditText percentageEditText = (EditText)view.FindViewById (Resource.Id.percentage_edit_text);
			percentageEditText.Text = Percentage.ToString ();
			builder.SetView (view);
			builder.SetPositiveButton ("Save", (sender, e) => {				
				calculator.Weight = Convert.ToSingle (weightEditText.Text);
				calculator.Percentage = Convert.ToInt16 (percentageEditText.Text);
				ReloadData ();
			});
			builder.SetNegativeButton ("Cancel", (sender, e) => {
			});
			AlertDialog dialog = builder.Create ();
			dialog.Show ();
		}

	}
}
	