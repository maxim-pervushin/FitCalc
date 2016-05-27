using System;
using Android.Support.V4.App;

namespace FitCalculator.Droid
{
	public class SectionsPagerAdapter : FragmentPagerAdapter
	{
		public SectionsPagerAdapter (FragmentManager fm) : base (fm)
		{
			
		}

		public override Fragment GetItem (int position)
		{
			switch (position) {
			case 0:
				return new MaxWeightFragment ();
			case 1:
				return new PercentageFragment ();
			case 2:
				return new AboutFragment ();
			}
			return null;

		}

		public override int Count {
			get {
				return 3;
			}
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted (int position)
		{
			switch (position) {
			case 0:
				return new Java.Lang.String ("Max Weight");
			case 1:
				return new Java.Lang.String ("Percentage");
			case 2:
				return new Java.Lang.String ("About");
			}
			return null;
		}
	}
}
