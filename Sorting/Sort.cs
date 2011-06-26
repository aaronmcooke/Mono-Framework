// <copyright file="Sort.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
    public class Sort<T> where T : IComparable
    {
        protected static bool Swap(int leftIndex, int rightIndex, List<T> listBeingSorted)
        {
            bool swapResult = true;

            if (listBeingSorted == null)
            {
                swapResult = false;
            }
            else if (listBeingSorted.Count == 0)
            {
                swapResult = false;
            }
            else if (leftIndex < 0)
            {
                swapResult = false;
            }
            else if (leftIndex >= listBeingSorted.Count)
            {
                swapResult = false;
            }
            else if (rightIndex < 0)
            {
                swapResult = false;
            }
            else if (rightIndex >= listBeingSorted.Count)
            {
                swapResult = false;
            }
            else if (leftIndex == rightIndex)
            {
                swapResult = false;
            }
            else
            {
                T tempObject = listBeingSorted[leftIndex];
                listBeingSorted[leftIndex] = listBeingSorted[rightIndex];
                listBeingSorted[rightIndex] = tempObject;
            }

            return swapResult;
        }
    }
}
