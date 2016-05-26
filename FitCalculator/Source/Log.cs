using System;

namespace FitCalculator
{
	public static class Log
	{
		public static void Debug (string format, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine (format, args);
		}
	}
}

