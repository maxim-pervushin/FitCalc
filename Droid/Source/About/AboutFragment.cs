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
	public class AboutFragment : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.settings_fragment, container, false);
			return view;
		}
	}
}

