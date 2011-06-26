// <copyright file="Formatting.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Text;

namespace GoatDogGames
{
    public class Formatting
    {
        public static string GetBinaryString(Int32 valuePassed)
        {
            StringBuilder binaryString = new StringBuilder();
            int compareValue = 1;
            int compareResult = 0;
            
            for (int i = 0; i < 32; i++)
            {
                compareResult = compareValue & valuePassed;

                if (compareResult != 0)
                {
                    binaryString.Append("1");
                }
                else
                {
                    binaryString.Append("0");
                }

                compareValue = compareValue << 1;
            }

            return binaryString.ToString();
        }
        public static string GetBinaryString(byte valuePassed)
        {
            StringBuilder binaryString = new StringBuilder();
            byte compareValue = (byte)1;
            byte compareResult = (byte)0;

            for (byte i = 0; i < 8; i++)
            {
                compareResult = (byte)(compareValue & valuePassed);

                if (compareResult != 0)
                {
                    binaryString.Append("1");
                }
                else
                {
                    binaryString.Append("0");
                }

                compareValue = (byte)(compareValue << 1);
            }

            return binaryString.ToString();
        }
        public static string GetBinaryString(char valuePassed)
        {
            StringBuilder binaryString = new StringBuilder();
            char compareValue = (char)1;
            char compareResult = (char)0;

            for (int i = 0; i < 16; i++)
            {
                compareResult = (char)(compareValue & valuePassed);

                if (compareResult != 0)
                {
                    binaryString.Append("1");
                }
                else
                {
                    binaryString.Append("0");
                }

                compareValue = (char)(compareValue << 1);
            }

            return binaryString.ToString();
        }
        
    }
}
