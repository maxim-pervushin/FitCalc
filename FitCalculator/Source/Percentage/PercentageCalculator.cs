using System;
using System.Collections.Generic;

namespace FitCalculator
{
	public class PercentageCalculator
	{
		public enum ExerciseCategory
		{
			// TODO: Make this list changeble
			BenchPress,
			Deadlift,
			Squat,
		};

		public List<PercentageData> Data {
			get { 
				float maxWeight = Weight / (Percentage / 100);
				List<PercentageData> result = new List<PercentageData> ();
				for (int i = 100; i > 0; i = i - 10) {
					result.Add (new PercentageData {
						Weight = maxWeight * i / 100,
						Percentage = i
					});
				}
				return result;
			}
		}

		public float Weight { 
			get {
				return weight;
			} 
			set {
				weight = value > 0 ? value : 1;
				Save ();
			}
		}

		public float Percentage { 
			get {
				return percentage;
			} 
			set {
				if (value < 0) {
					percentage = 1;
				} else if (value > 100) {
					percentage = 100;
				} else {
					percentage = value;
				}
				Save ();
			}
		}

		public ExerciseCategory Exercise { 
			get {
				return exercise;
			} 
			set {
				exercise = value;
				Load ();
			}
		}

		private float weight;

		private float percentage;

		private ExerciseCategory exercise;

		private IDataManager storage;

		public static string ExerciseDescription (ExerciseCategory exercise)
		{
			switch (exercise) {
			case ExerciseCategory.BenchPress:
				return "Bench Press";
			case ExerciseCategory.Deadlift:
				return "Deadlift";
			case ExerciseCategory.Squat:
				return "Squat";
			default:
				return "";
			}
		}

		public PercentageCalculator (IDataManager storage)
		{
			this.storage = storage;
			weight = 100;
			percentage = 100;
			exercise = ExerciseCategory.BenchPress;
			Load ();
		}

		private void Save ()
		{
			var data = new PercentageData {
				Weight = weight,
				Percentage = percentage
			};
			storage.SavePercentageData (exercise.ToString (), data);
		}

		private void Load() {
			var defaultData = new PercentageData {
				Weight = 100,
				Percentage = 100
			};
			var data = storage.LoadPercentageData (exercise.ToString (), defaultData);
			weight = data.Weight;
			percentage = data.Percentage;
		}
	}
}

