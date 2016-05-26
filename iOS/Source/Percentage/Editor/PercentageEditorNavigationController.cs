using System;
using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	[Register ("PercentageEditorNavigationController")]
	public class PercentageEditorNavigationController: UINavigationController
	{
		public Action<bool> Finished;

		public PercentageData Data { 
			get {
				return percentageEditorViewController.Data;
			} 
			set { 
				percentageEditorViewController.Data = value;
			}
		}

		private PercentageEditorViewController percentageEditorViewController {
			get {
				foreach (UIViewController viewController in ViewControllers) {
					var editPercentageViewController = viewController as PercentageEditorViewController;
					if (null != editPercentageViewController) {
						return editPercentageViewController;
					}
				}
				return null;
			}
		}

		public PercentageEditorNavigationController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			NavigationBar.TintColor = UIColor.White;
			SetNeedsStatusBarAppearanceUpdate ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			percentageEditorViewController.Finished = delegate (bool shouldSave) {
				if (null != Finished) {
					Finished (shouldSave);
				}
			};
		}

		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.LightContent;
		}
	}
}

