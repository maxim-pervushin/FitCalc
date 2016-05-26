using System;
using System.Runtime.Serialization;

namespace FitCalculator
{
	[DataContract]
	public class PercentageData
	{
		[DataMember]
		public float Weight;

		[DataMember]
		public float Percentage;

		public PercentageData ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("{0}% - {1} kgs.", Percentage, Weight);
		}
	}
}
