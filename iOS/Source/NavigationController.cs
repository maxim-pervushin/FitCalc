using System;
using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	[Register ("NavigationController")]
	public class NavigationController: UINavigationController
	{
		public NavigationController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			NavigationBar.TintColor = UIColor.White;
			SetNeedsStatusBarAppearanceUpdate ();
		}

		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.LightContent;
		}
	}
}

