using System;
using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	[Register ("TabBarController")]
	public class TabBarController: UITabBarController
	{
		public TabBarController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TabBar.TintColor = UIColor.White;
			SetNeedsStatusBarAppearanceUpdate ();
		}

		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.LightContent;
		}
	}
}

