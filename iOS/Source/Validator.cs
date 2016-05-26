using System;
using Foundation;

namespace FitCalculator.iOS
{	
	public static class Validator {

		public enum ValidationResult
		{
			Valid,
			Intermediate,
			Invalid,
		};

		public static ValidationResult ValidateFloat(string input) {
			if (null == input || "" == input) {
				return ValidationResult.Intermediate;
			}

			try {
				Convert.ToSingle (input);
				return ValidationResult.Valid;

			} catch (Exception) {
				return ValidationResult.Invalid;
			}
		}
	}
}

