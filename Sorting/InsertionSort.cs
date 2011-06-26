// <copyright file="InsertionSort.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
	public class InsertionSort<T> : Sort<T> where T : IComparable
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
				int holeIndex = 0;
				T tempObject;
				bool inserted = false;

                // Start the sort at one index position in
                // from the left side of the array.
				for (int i = 1 ; i < listToSort.Count ; i++)
				{
					holeIndex = i;
					tempObject = listToSort[holeIndex];
					inserted = false;

                    // Compare the value to be inserted to every
                    // value to the left until the insertion point
                    // is found or the left boundary is reached.
					while ((!inserted) && (holeIndex >= 1))
					{
                        // Is the value to be inserted less than the
                        // value to the left of the current index of
                        // the hole?
                        if (tempObject.CompareTo(listToSort[holeIndex - 1]) < 0)
						{
                            // If it is, shift the value to the left
                            // to the right and continue.
							listToSort[holeIndex--] = listToSort[holeIndex];
						}
						else
						{
                            // If it isn't, insert the value into the
                            // current index position of the hole.
							listToSort[holeIndex] = tempObject;
							inserted = true;
						}
					}

                    // If the while loop ended without an insertion
                    // that means that the value to be inserted belongs in
                    // the left most index.
					if (!inserted)
					{
						listToSort[holeIndex] = tempObject;
					}
				}
			}
            return sortResult;
		}
	}
}