using System;

namespace FitCalculator
{
	public interface IDataManager
	{
		void SaveMaxWeightData (string exerciseCategory, MaxWeightData data);

		MaxWeightData LoadMaxWeightData (string exerciseCategory, MaxWeightData defaultData);

		void SavePercentageData (string exerciseCategory, PercentageData data);

		PercentageData LoadPercentageData (string exerciseCategory, PercentageData defaultData);
	}
}	