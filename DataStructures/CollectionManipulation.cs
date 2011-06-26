// <copyright file="CollectionManipulation.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
    public static class CollectionManipulation
    {
        public static int SumArray(int[] arrayToSum)
        {
            int result = 0;
            if (arrayToSum != null)
            {
                for (int i = 0; i < arrayToSum.Length; i++)
                {
                    result += arrayToSum[i];
                }
            }
            return result;
        }
        
        public static T[] CombineArrays<T>(T[] arrayA, T[] arrayB)
        {
            T[] combinedArray = new T[arrayA.Length + arrayB.Length];

            for (int i = 0; i < arrayA.Length; i++)
            {
                combinedArray[i] = arrayA[i];
            }
            for (int i = 0; i < arrayB.Length; i++)
            {
                combinedArray[i + arrayA.Length] = arrayB[i];
            }

            return combinedArray;
        }
        public static T[] RandomizeGenericArray<T>(T[] arrayToRandomize)
        {
            return RandomizeGenericArray<T>(arrayToRandomize, 1.0);
        }
        public static T[] RandomizeGenericArray<T>(T[] arrayToRandomize, double countMultiple)
        {
            if ((arrayToRandomize != null) && (arrayToRandomize.Length > 1))
            {
                if (countMultiple < 0.0)
                {
                    countMultiple *= -1.0;
                }
                double countResult = ((double)arrayToRandomize.Length) * countMultiple;
                long swapCount = (int)countResult;

                Random newRandom = new Random(DataGenerator.NewSeedValue);
                T tempElement;
                int index_01 = -1;
                int index_02 = -1;
                int length = arrayToRandomize.Length;
                for (long i = 0; i < swapCount; i++)
                {
                    index_01 = newRandom.Next(0,length);
                    index_02 = newRandom.Next(0,length);

                    tempElement = arrayToRandomize[index_01];
                    arrayToRandomize[index_01] = arrayToRandomize[index_02];
                    arrayToRandomize[index_02] = tempElement;
                }
            }
            return arrayToRandomize;
        }

        public static double SumList(List<double> listToSum)
        {
            double sumResult = 0.0;
            if (listToSum != null)
            {
                foreach (double value in listToSum)
                {
                    sumResult += value;
                }
            }
            return sumResult;
        }
        
        public static List<double> GetRollingSumList(List<double> listToSum)
        {
            List<double> resultList = new List<double>();
            if ((listToSum != null) && (listToSum.Count > 0))
            {
                int counter = 1;
                resultList.Add(listToSum[0]);
                while (counter < listToSum.Count)
                {
                    resultList.Add(resultList[counter - 1] + listToSum[counter]);
                    counter++;
                }
            }
            return resultList;
        }

        public static List<T> CombineArraysToList<T>(T[] arrayA, T[] arrayB)
        {
            return CombineLists<T>(CollectionManipulation.ConvertArrayToList<T>(arrayA),
                CollectionManipulation.ConvertArrayToList<T>(arrayB));
        }
        public static List<T> CombineLists<T>(List<T> listA, List<T> listB)
        {
            List<T> combineResult = new List<T>();
            if ((listA != null) && (listB != null))
            {
                foreach (T item in listA)
                {
                    combineResult.Add(item);
                }
                foreach (T item in listB)
                {
                    combineResult.Add(item);
                }
            }
            return combineResult;
        }
        public static List<T> ConvertArrayToList<T>(T[] arrayToConvert)
        {
            List<T> resultList = new List<T>();

            for (int i = 0; i < arrayToConvert.Length; i++)
            {
                resultList.Add(arrayToConvert[i]);
            }

            return resultList;
        }
        public static List<T> CopyGenericList<T>(List<T> listToCopy)
        {
            List<T> copyOfList = new List<T>();
            
            foreach (T item in listToCopy)
            {
                copyOfList.Add(item);
            }

            return copyOfList;
        }     
        public static List<T> RandomizeGenericList<T>(List<T> listToRandomize)
        {
            return RandomizeGenericList<T>(listToRandomize, 1.0);
        }
        public static List<T> RandomizeGenericList<T>(List<T> listToRandomize, double countMultiple)
        {
            if ((listToRandomize != null) && (listToRandomize.Count > 1))
            {
                if (countMultiple < 0.0)
                {
                    countMultiple *= -1.0;
                }
                double countResult = ((double)listToRandomize.Count) * countMultiple;
                long swapCount = (int)countResult;

                Random newRandom = new Random(DataGenerator.NewSeedValue);
                T tempElement;
                int index_01 = -1;
                int index_02 = -1;
                int length = listToRandomize.Count;
                for (long i = 0; i < swapCount; i++)
                {
                    index_01 = newRandom.Next(0, length);
                    index_02 = newRandom.Next(0, length);

                    tempElement = listToRandomize[index_01];
                    listToRandomize[index_01] = listToRandomize[index_02];
                    listToRandomize[index_02] = tempElement;
                }
            }
            return listToRandomize;
        }

        public static LinkedList<T> GetReversedList<T>(LinkedList<T> listToReverse)
        {
            LinkedList<T> reversedList = new LinkedList<T>();

            foreach (T item in listToReverse)
            {
                T newItem = item;
                reversedList.AddLast(newItem);
            }

            return reversedList;
        }
    }
}
