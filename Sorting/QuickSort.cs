// <copyright file="QuickSort.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
	public class QuickSort<T> : Sort<T> where T : IComparable
	{
        public static bool Sort(T[] arrayToSort)
        {
            List<T> listToSort = CollectionManipulation.ConvertArrayToList(arrayToSort);
            bool sortResult = Sort(listToSort);
            arrayToSort = listToSort.ToArray();
            return sortResult;
        }

        public static bool Sort(List<T> listToSort)
        {
            bool sortResult = true;

            if (listToSort == null)
            {
                sortResult = false;
            }
            else if (listToSort.Count == 0)
            {
                sortResult = false;
            }
            else if (listToSort.Count > 1)
            {
                QuickSortRecursor(listToSort, 0, listToSort.Count - 1);
            }

            return sortResult;
        }
        private static void QuickSortRecursor(List<T> listToSort, int leftIndex, int rightIndex)
        {
            int size = rightIndex - leftIndex + 1;

            if (size > 3)
            {
                T pivotValue = GetPivotValue(listToSort, leftIndex, rightIndex);
                int partitionIndex = PartitionList(listToSort, leftIndex, rightIndex, pivotValue);
                
                QuickSortRecursor(listToSort, leftIndex, partitionIndex - 1);
                QuickSortRecursor(listToSort, partitionIndex + 1, rightIndex);
            }
            else
            {
                ManualSort(listToSort, leftIndex, rightIndex);
            }
        }
		private static T GetPivotValue(List<T> listToSort, int leftIndex, int rightIndex)
		{
			int middleIndex = (rightIndex + leftIndex) / 2;

			if (listToSort[leftIndex].CompareTo(listToSort[middleIndex]) > 0)
			{
				Swap(leftIndex, middleIndex, listToSort);
			}
			if (listToSort[leftIndex].CompareTo(listToSort[rightIndex]) > 0)
			{
				Swap(leftIndex, rightIndex, listToSort);
			}
			if (listToSort[middleIndex].CompareTo(listToSort[rightIndex]) > 0)
			{
				Swap(middleIndex, rightIndex, listToSort);
			}

			Swap(middleIndex, rightIndex, listToSort);
			
            return listToSort[rightIndex];
		}
        private static int PartitionList(List<T> listToSort, int leftIndex, int rightIndex, T pivotValue)
        {
            bool notDone = true;
            int leftCount = leftIndex - 1;
            int rightCount = rightIndex;

            while (notDone)
            {
                while (listToSort[++leftCount].CompareTo(pivotValue) < 0) { ; }
                while (listToSort[--rightCount].CompareTo(pivotValue) > 0) { ; }

                if (leftCount >= rightCount)
                {
                    notDone = false;
                }
                else
                {
                    Swap(leftCount, rightCount, listToSort);
                }
            }

            Swap(leftCount, rightIndex, listToSort);

            return leftCount;
        }
		private static void ManualSort(List<T> listToSort, int leftIndex, int rightIndex)
		{
			int size = rightIndex - leftIndex + 1;

			if (size == 3)
			{
				if (listToSort[leftIndex].CompareTo(listToSort[rightIndex-1]) > 0)
				{
                    Swap(leftIndex, rightIndex - 1, listToSort);
				}
				if (listToSort[leftIndex].CompareTo(listToSort[rightIndex]) > 0)
				{
                    Swap(leftIndex, rightIndex, listToSort);
				}
				if (listToSort[rightIndex - 1].CompareTo(listToSort[rightIndex]) > 0)
				{
                    Swap(rightIndex - 1, rightIndex, listToSort);
				}
			}
			else if (size == 2)
			{
				if (listToSort[leftIndex].CompareTo(listToSort[rightIndex]) > 0)
				{
                    Swap(leftIndex, rightIndex, listToSort);
				}
			}
		}
	}
}