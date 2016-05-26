using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V7.AppCompat;
using Android.Support.V4.View;

namespace FitCalculator.Droid
{
	[Activity (Theme = "@style/AppTheme.NoActionBar", Label = "FitCalculator", MainLauncher = true, Icon = "@mipmap/ic_launcher")]
	public class MainActivity : AppCompatActivity
	{
		private SectionsPagerAdapter sectionsPagerAdapter;
		private ViewPager viewPager;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.main_activity);

			sectionsPagerAdapter = new SectionsPagerAdapter (SupportFragmentManager);

			viewPager = (ViewPager)FindViewById (Resource.Id.container);
			viewPager.Adapter = sectionsPagerAdapter;

			TabLayout tabLayout = (TabLayout)FindViewById (Resource.Id.tabs);
			tabLayout.SetupWithViewPager (viewPager);
		}
	}
}
