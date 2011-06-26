// <copyright file="BubbleSort.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
	public class BubbleSort<T> : Sort<T> where T : IComparable
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
				int maxIndex = listToSort.Count - 1;

				for (int i = 0; i < listToSort.Count; i++)
				{
					for (int j = maxIndex; j > i; j--)
					{
                        if ((listToSort[j].CompareTo(listToSort[j - 1]) < 0) && (!Swap(j, j - 1, listToSort)))
                        {
                            sortResult = false;
                        }
					}
				}
			}

            return sortResult;
		}
	}
}