// <copyright file="SelectionSort.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
	public class SelectionSort<T> : Sort<T> where T : IComparable
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
                int minimumIndex;
				
                for (int i = 0; i < listToSort.Count; i++)
				{
                    // For the range from i to the end of the array,
                    // find the index of the element with the minimum
                    // value.
					minimumIndex = i;
					for (int j = i; j < listToSort.Count; j++)
					{
                        if (listToSort[j].CompareTo(listToSort[minimumIndex]) < 0)
						{
							minimumIndex = j;
						}
					}

                    // Swap the value at MinimumIndex with the value
                    // at i if the value at i isn't already the minimum.
                    if ((minimumIndex != i) && (!Swap(i, minimumIndex, listToSort)))
					{
                        sortResult = false;
					}
				}                
			}
            return sortResult;
		}
	}
}