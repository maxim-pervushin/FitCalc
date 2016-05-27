using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace FitCalculator
{
	public class JsonDataManager : IDataManager
	{
		private static string MaxWeightFileName = "MaxWeight.json";
		private static string PercentageFileName = "Percentage.json";

		private IStorage storage;
		private Dictionary<string, MaxWeightData> maxWeightStorage = new Dictionary<string, MaxWeightData> ();
		private DataContractJsonSerializer maxWeightDataSerializer = new DataContractJsonSerializer (typeof(Dictionary<string, MaxWeightData>));
		private Dictionary<string, PercentageData> percentageStorage = new Dictionary<string, PercentageData> ();
		private DataContractJsonSerializer percentageDataSerializer = new DataContractJsonSerializer (typeof(Dictionary<string, PercentageData>));

		public JsonDataManager (IStorage storage)
		{
			this.storage = storage;
		}

		public void SaveMaxWeightData (string exerciseCategory, MaxWeightData data)
		{
			maxWeightStorage [exerciseCategory] = data;

			if (null != storage) {
				var stream = new MemoryStream ();
				maxWeightDataSerializer.WriteObject (stream, maxWeightStorage);
				stream.Position = 0;
				var reader = new StreamReader (stream);
				storage.WriteFile (JsonDataManager.MaxWeightFileName, reader.ReadToEnd ());
			}
		}

		public MaxWeightData LoadMaxWeightData (string exerciseCategory, MaxWeightData defaultData)
		{
			try {
				var content = storage.ReadFile (JsonDataManager.MaxWeightFileName);
				var stream = new MemoryStream ();
				var writer = new StreamWriter (stream);
				writer.Write (content);
				writer.Flush ();
				stream.Position = 0;
				var obj = (Dictionary<string, MaxWeightData>)maxWeightDataSerializer.ReadObject (stream);
				if (null != obj) {
					maxWeightStorage = obj;
				} else {
					maxWeightStorage.Clear ();
				}
				return maxWeightStorage [exerciseCategory];

			} catch (Exception) {
				return defaultData;
			}
		}

		public void SavePercentageData (string exerciseCategory, PercentageData data)
		{
			percentageStorage [exerciseCategory] = data;

			if (null != storage) {
				var stream = new MemoryStream ();
				percentageDataSerializer.WriteObject (stream, percentageStorage);
				stream.Position = 0;
				StreamReader reader = new StreamReader (stream);
				storage.WriteFile (JsonDataManager.PercentageFileName, reader.ReadToEnd ());
			}
		}

		public PercentageData LoadPercentageData (string exerciseCategory, PercentageData defaultData)
		{
			try {
				var content = storage.ReadFile (JsonDataManager.PercentageFileName);
				var stream = new MemoryStream ();
				var writer = new StreamWriter (stream);
				writer.Write (content);
				writer.Flush ();
				stream.Position = 0;
				var obj = (Dictionary<string, PercentageData>)percentageDataSerializer.ReadObject (stream);
				if (null != obj) {
					percentageStorage = obj;
				} else {
					percentageStorage.Clear ();
				}
				return percentageStorage [exerciseCategory];

			} catch (Exception) {
				return defaultData;
			}
		}
	}
}
