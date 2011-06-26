// <copyright file="ShellSort.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
	public class ShellSort<T> : Sort<T> where T : IComparable
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
				int interval = 1;
				T tempObject;
				int holeIndex = 0;
				int holeStartIndex = 0;
				bool inserted = false;

				// Calculate the max interval value
				// and then step back one increment
				while ( interval < listToSort.Count )
				{
					interval = ( 3 * interval ) + 1;
				}

				interval = ( interval - 1 ) / 3;

				while ( interval > 0 )
				{
					for (int i = 0 ; i < interval ; i++ )
					{
						holeStartIndex = i + interval;

						while ( holeStartIndex < listToSort.Count )
						{
							holeIndex = holeStartIndex;
							tempObject = listToSort[holeIndex];
							inserted = false;

							while ( (!inserted) && (holeIndex > i) )
							{

								if ( tempObject.CompareTo(listToSort[holeIndex - interval]) < 0 )
								{
									listToSort[holeIndex] = listToSort[holeIndex - interval];
									holeIndex -= interval;
								}
								else
								{
									listToSort[holeIndex] = tempObject;
									inserted = true;
								}
							}

							if (!inserted)
							{
								listToSort[i] = tempObject;
							}

							holeStartIndex += interval;
						}
					}

					interval = ( interval - 1 ) / 3;
				}
			}

            return sortResult;
		}
	}
}