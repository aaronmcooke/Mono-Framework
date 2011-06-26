// <copyright file="GeneralMethods.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    public class Numbers
    {
        public static int OrderOfMagnitude(int order)
        {	
            int Result = -1;
			if (order > 0)
			{
				Result = 1;
				for (int i = 0; i < order; i++)
				{
					Result *= 10;
				}
			}
			else if (order == 0)
			{
				Result = 1;
			}
			return Result;
        }
    }
}
