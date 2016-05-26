using System;
using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	[Register ("MaxWeightEditorNavigationController")]
	public class MaxWeightEditorNavigationController: UINavigationController
	{
		public Action<bool> Finished;

		public MaxWeightData Data { 
			get {
				return maxWeightEditorViewController.Data;
			} 
			set { 
				maxWeightEditorViewController.Data = value;
			}
		}

		private MaxWeightEditorViewController maxWeightEditorViewController {
			get {
				foreach (UIViewController viewController in ViewControllers) {
					var editMaxWeightViewController = viewController as MaxWeightEditorViewController;
					if (null != editMaxWeightViewController) {
						return editMaxWeightViewController;
					}
				}
				return null;
			}
		}

		public MaxWeightEditorNavigationController (IntPtr handle) : base (handle)
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
			maxWeightEditorViewController.Finished = delegate (bool shouldSave) {
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

