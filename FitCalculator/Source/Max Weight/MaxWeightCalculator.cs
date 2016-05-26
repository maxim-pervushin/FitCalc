using System;
using System.Collections.Generic;

namespace FitCalculator
{
	public class MaxWeightCalculator
	{
		public enum ExerciseCategory
		{
			BenchPress,
			Deadlift,
			Squat,
		};

		public float Weight {
			get { 
				return weight;
			} 
			set { 
				weight = value > 0 ? value : 1;
				Save ();
			}
		}

		public int Repeats {
			get { 
				return repeats;
			} 
			set { 
				if (value < 1) {
					repeats = 1;
				} else if (value > 10) {
					repeats = 10;
				} else {
					repeats = value;
				}
				Save ();
			}
		}

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

		private int repeats;

		private ExerciseCategory exercise;

		private IDataManager storage;

		public MaxWeightCalculator (IDataManager storage)
		{
			this.storage = storage;
			weight = 100;
			repeats = 1;
			exercise = ExerciseCategory.BenchPress;
			Load ();
		}

		public List<MaxWeightData> Data {
			get { 
				var maxWeight = Weight * data [Exercise] [Repeats];
				var result = new List<MaxWeightData> ();
				for (int i = 1; i <= 10; i++) {
					result.Add (new MaxWeightData {
						Weight = maxWeight / data [Exercise] [i],
						Repeats = i

					});
				}
				return result;
			} 
		}

		private Dictionary<ExerciseCategory, Dictionary<int, float> > data = new Dictionary<ExerciseCategory, Dictionary<int, float> > {
			[ExerciseCategory.BenchPress ] = new Dictionary<int, float> {
				[1 ] = 1.0f,
				[2 ] = 1.035f,
				[3 ] = 1.08f,
				[4 ] = 1.115f,
				[5 ] = 1.15f,
				[6 ] = 1.18f,
				[7 ] = 1.22f,
				[8 ] = 1.255f,
				[9 ] = 1.29f,
				[10 ] = 1.325f
			},
			[ExerciseCategory.Deadlift ] = new Dictionary<int, float> {
				[1 ] = 1.0f,
				[2 ] = 1.065f,
				[3 ] = 1.13f,
				[4 ] = 1.147f,
				[5 ] = 1.164f,
				[6 ] = 1.181f,
				[7 ] = 1.198f,
				[8 ] = 1.232f,
				[9 ] = 1.232f,
				[10 ] = 1.24f
			},
			[ExerciseCategory.Squat ] = new Dictionary<int, float> {
				[1 ] = 1.0f,
				[2 ] = 1.0475f,
				[3 ] = 1.13f,
				[4 ] = 1.1575f,
				[5 ] = 1.2f,
				[6 ] = 1.242f,
				[7 ] = 1.284f,
				[8 ] = 1.326f,
				[9 ] = 1.368f,
				[10 ] = 1.41f
			},
		};

		private void Save ()
		{
			var data = new MaxWeightData { 
				Repeats = repeats,
				Weight = weight
			};
			storage.SaveMaxWeightData (exercise.ToString (), data);
		}

		private void Load ()
		{
			var defaultData = new MaxWeightData { 
				Repeats = 1,
				Weight = 100
			};
			var data = storage.LoadMaxWeightData (exercise.ToString (), defaultData);
			weight = data.Weight;
			repeats = data.Repeats;

		}
	}
}

