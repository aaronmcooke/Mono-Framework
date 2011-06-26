using System;

namespace GoatDogGames
{
    //    public class APNInteger
    //    {
    //        private const long pMax32L = (long)Int32.MaxValue;
    //        private const int pMax32 = Int32.MaxValue;
    //        private const long pMax64 = Int64.MaxValue;

    //        private List<int> digits;
    //        private List<int> factors;
    //        private List<APNElement> elementList;

    //        public bool Ready
    //        {
    //            get
    //            {
    //                bool result = true;
    //                if ((factors.Count == 0) || (elementList.Count == 0))
    //                {
    //                    result = false;	
    //                }
    //                return result;
    //            }
    //        }
    //        public List<int> Factors
    //        {
    //            get { return factors; }
    //        }
    //        public List<APNElement> Elements
    //        {
    //            get { return elementList; }
    //        }

    //        public APNInteger(List<int> factorsPassed)
    //        {
    //            factors = new List<int>();
    //            elementList = new List<APNElement>();
    //            digits = new List<int>();

    //            if ((factorsPassed != null) && (factorsPassed.Count != 0))
    //            {
    //                factors = factorsPassed;
    //                //List<APNElement> convertedFactors = ConvertFactorsToAPNInteger(factors);
    //            }
    //        }
    //        #region Void Methods
    //        #endregion

    //        #region Return Methods
    //        private List<APNElement> ConvertFactorsToAPNInteger(List<int> factorsPassed)
    //        {
    //            InsertionSort.Sort(factors);
    //            List<int> compressedFactors = CompressFactors(factorsPassed);
    //            List<int> subtractedFactors = SubtractFactorsFromPMax(compressedFactors);

    //            int subtractedProduct = GetProductOfFactors(subtractedFactors, 0, subtractedFactors.Count - 1);
    //            if (subtractedProduct != 0)
    //            {
    //                List<APNElement> covertedUnsimplifiedFactors = ConvertFactors(compressedFactors);

    //                // Simplify list of APN elements
    //            }

    //            return null;
    //        }
    //        private List<int> CompressFactors(List<int> factorsToCompress)
    //        {
    //            if ((factorsToCompress == null) || (factorsToCompress.Count == 0))
    //            {
    //                return new List<int>();
    //            }
    //            else if (factorsToCompress.Count == 1)
    //            {
    //                CheckForNegativeFactors(factorsToCompress);
    //                return factorsToCompress;
    //            }
    //            else
    //            {
    //                CheckForNegativeFactors(factorsToCompress);
    //                List<int> result = new List<int>();

    //                int startIndex = factorsToCompress.Count - 1;
    //                int endIndex = factorsToCompress.Count - 1;
    //                int currentProduct = 0;
    //                int newProduct = 0;

    //                while (startIndex > -1)
    //                {
    //                    newProduct = GetProductOfFactors(factorsToCompress, startIndex, endIndex);
    //                    if (newProduct == 0)
    //                    {
    //                        result.Add(currentProduct);
    //                        currentProduct = newProduct;
    //                        endIndex = startIndex;
    //                    }
    //                    else
    //                    {
    //                        startIndex--;
    //                        currentProduct = newProduct;
    //                    }
    //                }

    //                if (currentProduct == 0)
    //                {
    //                    result.Add(factorsToCompress[0]);
    //                }
    //                else
    //                {
    //                    result.Add(currentProduct);
    //                }

    //                return result;
    //            }
    //        }
    //        private List<long> CompressFactors(List<long> factorsToCompress)
    //        {
    //            return null;
    //        }
    //        private void CheckForNegativeFactors(List<int> factorsPassed)
    //        {
    //            int counter = 0;
    //            while (counter < factorsPassed.Count)
    //            {
    //                if (factorsPassed[counter] < 0)
    //                {
    //                    factorsPassed[counter] *= -1;
    //                }
    //                counter++;
    //            }
    //        }

    //        private int GetProductOfFactors(List<int> factors, int startIndex, int endIndex)
    //        {
    //            int result = -1;
    //            if ((factors != null)
    //                && (factors.Count > 0)
    //                && (startIndex > -1)
    //                && (startIndex < factors.Count)
    //                && (startIndex <= endIndex)
    //                && (endIndex < factors.Count))
    //            {
    //                result = 1;
    //                for (int i = startIndex; i < endIndex + 1; i++)
    //                {
    //                    if (factors[i] < 0)
    //                    {
    //                        factors[i] *= -1;
    //                    }

    //                    if (pMax32 / result < factors[i])
    //                    {
    //                        result = 0;
    //                        i = endIndex + 2;
    //                    }
    //                    else
    //                    {
    //                        result *= factors[i];
    //                    }
    //                }
    //            }
    //            return result;
    //        }
    //        private long GetProductOfFactors(List<long> factors, int startIndex, int endIndex)
    //        {
    //            long result = -1;
    //            if ((factors != null)
    //                && (factors.Count > 0)
    //                && (startIndex > -1)
    //                && (startIndex < factors.Count)
    //                && (startIndex <= endIndex)
    //                && (endIndex < factors.Count))
    //            {
    //                result = 1L;
    //                for (int i = startIndex; i < endIndex + 1; i++)
    //                {
    //                    if (factors[i] < 0L)
    //                    {
    //                        factors[i] *= -1L;
    //                    }

    //                    if (pMax64 / result < factors[i])
    //                    {
    //                        result = 0L;
    //                        i = endIndex + 2;
    //                    }
    //                    else
    //                    {
    //                        result *= factors[i];
    //                    }
    //                }
    //            }
    //            return result;
    //        }

    //        private List<int> SubtractFactorsFromPMax(List<int> compressedFactors)
    //        {
    //            List<int> result = new List<int>();
    //            foreach (int factor in compressedFactors)
    //            {
    //                result.Add(pMax32 - factor);
    //            }
    //            return result;
    //        }
    //        private List<APNElement> ConvertFactors(List<int> factorsPassed)
    //        {
    //            List<APNElement> result = new List<APNElement>();

    //            int counter = factors.Count;
    //            int lastSign = 1;
    //            while (counter > -1)
    //            {
    //                APNElement newElement = new APNElement();
    //                newElement.Order = counter;
    //                newElement.Sign = lastSign;

    //                // Get newElement.Magnitude

    //                result.Add(newElement);
    //                lastSign *= -1;
    //            }
    //            return result;
    //        }
    //        private List<long> CastIntegerListToLongList(List<int> integerFactorsPassed)
    //        {
    //            List<long> result = new List<long>();
    //            foreach (int factor in integerFactorsPassed)
    //            {
    //                result.Add((long)factor);
    //            }
    //            return result;
    //        }
    //        private APNElement ConvertToAPNElement(int firstFactorPassed, int secondFactorPassed)
    //        {
    //            APNElement result = new APNElement();

    //            long firstFactor = (long)firstFactorPassed;
    //            long secondFactor = (long)secondFactorPassed;

    //            if ((firstFactor == 0L) || (secondFactor == 0L))
    //            {
    //                result.Order = 0L;
    //                result.Magnitude = 0L;
    //                result.Sign = 1L;
    //                result.Remainder = 0L;
    //            }
    //            else
    //            {
    //                if ((firstFactor < 0L) && (secondFactor < 0L))
    //                {
    //                    result.Sign = 1L;
    //                    firstFactor *= -1L;
    //                    secondFactor *= -1L;
    //                }
    //                else if (firstFactor < 0L)
    //                {
    //                    result.Sign = -1L;
    //                    firstFactor *= -1L;
    //                }
    //                else if (secondFactor < 0L)
    //                {
    //                    result.Sign = -1L;
    //                    secondFactor *= -1L;
    //                }
    //                else
    //                {
    //                    result.Sign = 1L;
    //                }

    //                if ((firstFactor == pMax32L) && (secondFactor == pMax32L))
    //                {
    //                    result.Order = 2L;
    //                    result.Magnitude = 1L;
    //                    result.Remainder = 0L;
    //                }
    //                else if (firstFactor == pMax32L)
    //                {
    //                    result.Order = 1L;
    //                    result.Magnitude = secondFactor;
    //                    result.Remainder = 0L;
    //                }
    //                else if (secondFactor == pMax32L)
    //                {
    //                    result.Order = 1L;
    //                    result.Magnitude = firstFactor;
    //                    result.Remainder = 0L;
    //                }
    //                else
    //                {
    //                    long factorProduct = firstFactor * secondFactor;
    //                    if (factorProduct > pMax32L)
    //                    {
    //                        result.Order = 1L;
    //                        result.Magnitude = factorProduct / pMax32L;
    //                        result.Remainder = factorProduct % pMax32L;
    //                    }
    //                    else
    //                    {
    //                        result.Order = 0L;
    //                        result.Magnitude = 0L;
    //                        result.Remainder = factorProduct;
    //                    }
    //                }		
    //            }
    //            return result;
    //        }
    //        private APNElement ConvertToAPNElement(int firstFactor)
    //        {
    //            return null;
    //        }
    //        #endregion

    //        #region Unit Testing Methods
    //        public List<APNElement> ConvertFactorsToAPNIntegerTest(List<int> factorsPassed)
    //        {
    //            return ConvertFactorsToAPNInteger(factorsPassed);
    //        }
    //        public List<int> CompressFactorsTest(List<int> factorsPassed)
    //        {
    //            return CompressFactors(factorsPassed);
    //        }
    //        public int GetProductOfFactorsTest(List<int> factorsPassed, int startIndex, int endIndex)
    //        {
    //            return GetProductOfFactors(factorsPassed, startIndex, endIndex);
    //        }
    //        public List<APNElement> ConvertFactorsTest(List<int> factorsPassed)
    //        {
    //            return ConvertFactors(factorsPassed);
    //        }
    //        public List<int> SubtractFactorsFromPMaxTest(List<int> compressedFactors)
    //        {
    //            return SubtractFactorsFromPMax(compressedFactors);
    //        }
    //        public List<int> CompressFactorsV2Test(int[] factorsPassed)
    //        {
    //            return CompressFactorsV2(factorsPassed);
    //        }
    //        public APNElement ConvertToAPNElementTest(int firstFactorPassed, int secondFactorPassed)
    //        {
    //            return ConvertToAPNElement(firstFactorPassed, secondFactorPassed);
    //        }
    //        #endregion

    //        private List<int> ArrayToList(int[] arrayPassed)
    //        {
    //            List<int> result = new List<int>();
    //            if ((arrayPassed != null) && (arrayPassed.Length > 0))
    //            {
    //                for (int i = 0; i < arrayPassed.Length; i++)
    //                {
    //                    result.Add(arrayPassed[i]);
    //                }
    //            }
    //            return result;
    //        }

    //        private List<int> CompressFactorsV2(int[] factorsPassed)
    //        {
    //            int maxProduct = 1;
    //            List<int> maxProductList = new List<int>();
    //            List<int> updatedList = new List<int>();
    //            List<int> workingList = ArrayToList(factorsPassed);
    //            List<int[]> productArrays = new List<int[]>();
    //            while (workingList.Count > 0)
    //            {
    //                int[] workingSet = workingList.ToArray();
    //                maxProductList.Clear();
    //                updatedList.Clear();
    //                maxProduct = 1;
    //                for (int i = workingSet.Length; i > 1; i--)
    //                {
    //                    List<int[]> combinatorials = Combinatorial.GetCombinatorials(workingSet, i);

    //                    foreach (int[] array in combinatorials)
    //                    {
    //                        List<int> currentList = ArrayToList(array);
    //                        int currentProduct = GetProductOfFactorsTest(currentList, 0, currentList.Count - 1);
    //                        int[] currentProductArray = currentList.ToArray();
    //                        if (currentProduct > maxProduct)
    //                        {
    //                            maxProduct = currentProduct;
    //                            maxProductList = currentList;
    //                        }
    //                    }
    //                }
    //                int[] maxProductArray = maxProductList.ToArray();
    //                productArrays.Add(maxProductArray);

    //                foreach (int factor in workingList)
    //                {
    //                    if (!maxProductList.Contains(factor))
    //                    {
    //                        updatedList.Add(factor);
    //                    }
    //                }

    //                workingList.Clear();
    //                foreach (int factor in updatedList)
    //                {
    //                    workingList.Add(factor);
    //                }
    //                updatedList.Clear();
    //            }
    //            List<int> result = new List<int>();
    //            foreach (int[] array in productArrays)
    //            {
    //                result.Add(GetProductOfFactors(ArrayToList(array), 0, array.Length - 1));
    //            }
    //            return result;
    //        }
    //    }

    //public class APNElement
    //{
    //    // TODO : Convert all fields to Int32
    //    // TODO : Add a sign for the magnitude value or allow magnitude and remainder to be negative or positive.

    //    private long sign;
    //    public long Sign
    //    {
    //        get { return sign > -1L ? 1L : -1L; }
    //        set { sign = value; }
    //    }
    //    private long order;
    //    public long Order
    //    {
    //        get { return order; }
    //        set
    //        {
    //            if (value > 0L)
    //            {
    //                order = value;
    //            }
    //            else
    //            {
    //                order = 0L;
    //            }
    //        }
    //    }
    //    private long magnitude;
    //    public long Magnitude
    //    {
    //        get { return magnitude; }
    //        set
    //        {
    //            if (value > -1L)
    //            {
    //                magnitude = value;
    //            }
    //            else
    //            {
    //                sign = -1L;
    //                magnitude = -1L * value;
    //            }
    //        }
    //    }
    //    private long remainder;
    //    public long Remainder
    //    {
    //        get { return remainder; }
    //        set { remainder = value; }
    //    }

    //    #region Operator Overloads
    //    public static implicit operator APNElement(int valueToCast)
    //    {
    //        return null;
    //    }

    //    public static implicit operator APNElement(long valueToCast)
    //    {
    //        return null;
    //    }

    //    public static APNElement operator +(APNElement leftElement, APNElement rightElement)
    //    {
    //        return null;
    //    }
    //    public static APNElement operator *(APNElement leftElement, APNElement rightElement)
    //    {
    //        APNElement result = new APNElement();

    //        return result;
    //    }
    //    #endregion

    //    public override string ToString()
    //    {
    //        System.Text.StringBuilder stringText = new System.Text.StringBuilder();
    //        stringText.Append("{ ");
    //        stringText.Append(Sign.ToString());
    //        stringText.Append(" ");
    //        stringText.Append(Order.ToString().PadLeft(12, '0'));
    //        stringText.Append(" ");
    //        stringText.Append(Magnitude.ToString().PadLeft(12, '0'));
    //        stringText.Append(" ");
    //        stringText.Append(Remainder.ToString().PadLeft(12, '0'));
    //        stringText.Append(" ]");
    //        return stringText.ToString();
    //    }
    //}
}
