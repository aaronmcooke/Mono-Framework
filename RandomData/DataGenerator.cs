using System;
using System.Globalization;

// TODO :  Add XML tags that describe how to use GetBoltzmannProbability()

namespace GoatDogGames
{
	public enum SortOrder
	{
		None,
		Standard,
		Inverse
	}

    public class DataGenerator
    {
        public static int NewSeedValue
        {
            get
            {
                Random seedGenerator = new Random();
                return seedGenerator.Next(Int32.MaxValue);
            }
        }

        protected Random valueGen;
        public Random ValueGen
        {
            get { return valueGen; }
        }

        public DataGenerator()
        {
            valueGen = new Random();
        }
        public DataGenerator(int seedValue)
        {
            valueGen = new Random(seedValue);
        }

        public int[] GetArray(int length, SortOrder sort)
        {
            int[] result = new int[0];
            if (length > 0)
            {
                // Create array of integers with unique values
                result = new int[length];

                // Fill the array with the specified number
                // of values based on length and sort order
                for (int i = 0; i < length; i++)
                {
                    result[i] = i;
                }

                // If SortOrder is Inverse, reverse the array
                if (sort == SortOrder.Inverse)
                {
                    Array.Reverse(result);
                }
            }
            return result;
        }
    }

}