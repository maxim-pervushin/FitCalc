using System;
using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	[Register ("PercentageExercisePickerNavigationController")]
	public class PercentageExercisePickerNavigationController: UINavigationController
	{
		public Action<bool> Finished;

		public PercentageCalculator.ExerciseCategory Exercise { 
			get {
				return percentageExerciseViewController.Exercise;
			} 
			set { 
				percentageExerciseViewController.Exercise = value;
			}
		}

		private PercentageExercisePickerViewController percentageExerciseViewController {
			get {
				foreach (UIViewController vc in ViewControllers) {
					var editVC = vc as PercentageExercisePickerViewController;
					if (null != editVC) {
						return editVC;
					}
				}
				return null;
			}
		}

		public PercentageExercisePickerNavigationController (IntPtr handle) : base (handle)
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
			percentageExerciseViewController.Finished = delegate (bool shouldSave) {
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

