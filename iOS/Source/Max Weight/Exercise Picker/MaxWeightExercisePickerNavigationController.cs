using System;
using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	[Register ("MaxWeightExercisePickerNavigationController")]
	public class MaxWeightExercisePickerNavigationController: UINavigationController
	{
		public Action<bool> Finished;

		public MaxWeightCalculator.ExerciseCategory Exercise { 
			get {
				return maxWeightExerciseViewController.Exercise;
			} 
			set { 
				maxWeightExerciseViewController.Exercise = value;
			}
		}

		private MaxWeightExercisePickerViewController maxWeightExerciseViewController {
			get {
				foreach (UIViewController vc in ViewControllers) {
					var editVC = vc as MaxWeightExercisePickerViewController;
					if (null != editVC) {
						return editVC;
					}
				}
				return null;
			}
		}

		public MaxWeightExercisePickerNavigationController (IntPtr handle) : base (handle)
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
			maxWeightExerciseViewController.Finished = delegate (bool shouldSave) {
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

