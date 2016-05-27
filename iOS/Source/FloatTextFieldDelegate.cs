using System;
using Foundation;
using UIKit;

namespace FitCalculator.iOS
{
	class FloatTextFieldDelegate: UITextFieldDelegate
	{
		public override bool ShouldChangeCharacters (UITextField textField, Foundation.NSRange range, string replacementString)
		{
			NSString original = NSObject.FromObject (textField.Text) as NSString;
			NSString replacement = NSObject.FromObject (replacementString) as NSString;
			NSString updated = original.Replace (range, replacement);

			var result = Validator.ValidateFloat (updated);

			return result == Validator.ValidationResult.Intermediate || result == Validator.ValidationResult.Valid;
		}
	}
}
