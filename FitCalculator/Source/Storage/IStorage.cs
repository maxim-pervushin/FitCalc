using System;

namespace FitCalculator
{
	public interface IStorage
	{
		bool WriteFile (string name, string content);

		string ReadFile (string name);
	}
}

