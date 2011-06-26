// <copyright file="MergeSort.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
	public class MergeSort<T> : Sort<T> where T : IComparable
	{
        public static T[] Sort(T[] arrayToSort)
        {
            List<T> listToSort = CollectionManipulation.ConvertArrayToList(arrayToSort);
            arrayToSort = Sort(listToSort).ToArray();
            listToSort = null;
            return arrayToSort;
        }
		public static List<T> Sort(List<T> listToSort)
		{
            List<T> resultList = null;

			if ((listToSort != null) && (listToSort.Count > 0))
			{
                if (listToSort.Count == 1)
                {
                    resultList = listToSort;
                }
                else
                {
                    resultList = SplitList(listToSort);
                }
			}

            return resultList;
		}
        private static List<T> SplitList(List<T> listToSplit)
        {
            if (listToSplit.Count > 1)
            {
                int leftCount = (listToSplit.Count / 2);
                int rightCount = leftCount;
                leftCount += listToSplit.Count % 2;

                List<T> leftList = new List<T>();
                List<T> rightList = new List<T>();

                int counter = 0;
                foreach (T item in listToSplit)
                {
                    if (counter < leftCount)
                    {
                        leftList.Add(item);
                    }
                    else
                    {
                        rightList.Add(item);
                    }
                    counter++;
                }

                return MergeLists(SplitList(leftList), SplitList(rightList));
            }
            else
            {
                return listToSplit;
            }
        }
		private static List<T> MergeLists(List<T> leftList, List<T> rightList )
		{
            List<T> mergeResult = null;

			if ((leftList != null) && (rightList != null))
			{
				mergeResult = new List<T>();
				int leftIndex = 0;
				int rightIndex = 0;

				while ((leftIndex < leftList.Count) && (rightIndex < rightList.Count))
				{
                    if (leftList[leftIndex].CompareTo(rightList[rightIndex]) < 0)
					{
                        mergeResult.Add(leftList[leftIndex++]);
					}
					else
					{
                        mergeResult.Add(rightList[rightIndex++]);
					}
				}

				while (leftIndex < leftList.Count)
				{
                    mergeResult.Add(leftList[leftIndex++]);
				}

				while (rightIndex < rightList.Count)
				{
                    mergeResult.Add(rightList[rightIndex++]);
				}                
			}

            return mergeResult;
		}
	}
}