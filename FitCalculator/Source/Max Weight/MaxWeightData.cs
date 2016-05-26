using System;
using System.Runtime.Serialization;

namespace FitCalculator
{
	[DataContract]
	public class MaxWeightData
	{
		[DataMember]
		public float Weight;

		[DataMember]
		public int Repeats;

		public MaxWeightData ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("{0} reps. - {1:0.00} kgs.", Repeats, Weight);
		}
	}
}
