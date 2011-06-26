// <copyright file="RandomString.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Globalization;

namespace GoatDogGames
{
    public enum StringType
    {
        None,
        Alpha,
        Numeric,
        AlphaNumeric,
        Cased,
        Unicode
    }

    public class RandomString : DataGenerator
    {
        public RandomString(int seedValuePassed) : base(seedValuePassed)
        {
        }

        public string GetRandomString(StringType type, int length)
        {
            string result = string.Empty;
            if ((!type.Equals(StringType.None)) && (length > 0))
            {
                int charcode = 0;

                char[] chars = new char[length];

                for (int i = 0; i < length; i++)
                {
                    switch (type)
                    {
                        case StringType.Unicode:
                            charcode = GetUnicodeCharacterValue();
                            break;
                        case StringType.Alpha:
                            charcode = 65 + valueGen.Next(0, 26);
                            break;
                        case StringType.AlphaNumeric:
                            charcode = valueGen.Next(0, 36);
                            if (charcode < 10)
                            {
                                charcode += 48;
                            }
                            else
                            {
                                charcode += 55;
                            }
                            break;
                        case StringType.Numeric:
                            charcode = 48 + valueGen.Next(0, 10);
                            break;
                        case StringType.Cased:
                            charcode = valueGen.Next(0, 52);
                            if (charcode < 26)
                            {
                                charcode += 65;
                            }
                            else
                            {
                                charcode += 71;
                            }
                            break;
                    }
                    chars[i] = (char)charcode;
                }
                for (int i = 0; i < chars.Length; i++)
                {
                    result += chars[i].ToString();
                }
                chars = null;
            }

            return result;
        }

        private int GetUnicodeCharacterValue()
        {
            int result = -1;
            int value = 0;
            while (result == -1)
            {
                value = valueGen.Next(0, UInt16.MaxValue + 1);
                UnicodeCategory category = char.GetUnicodeCategory((char)value);
                if ((category != UnicodeCategory.Control) && (category != UnicodeCategory.Surrogate))
                {
                    result = value;
                }
            }
            return result;
        }
    }
}
