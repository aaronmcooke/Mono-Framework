using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
	[Flags()]
	public enum StringOperationType
	{
		None = 0,
		Modify = 1,
		Find = 2,
		Replace = 4,
		ModifyTooShort = 8
	}			
	public class StringOperator
	{
        public static int GetMaxLength(List<string> listToGetMaxLengthFrom)
        {
            int result = 0;
            if (listToGetMaxLengthFrom != null)
            {
                foreach (string item in listToGetMaxLengthFrom)
                {
                    if (item.Length > result)
                    {
                        result = item.Length;
                    }
                }
            }
            return result;
        }
		public static List<int[]> FindIndexesOfSubstringsInString(string StringToSearch, string StringToFind)
		{
			StringOperationType TypeOfOperation = GetStringOperationType(StringToSearch, StringToFind, null);

			List<int[]> Result = new List<int[]>();

			if (((TypeOfOperation & StringOperationType.ModifyTooShort) != (StringOperationType.ModifyTooShort))
				&& ((TypeOfOperation & StringOperationType.Modify) == StringOperationType.Modify)
				&& ((TypeOfOperation & StringOperationType.Find) == StringOperationType.Find))
			{
				bool SubstringFound;
				for (int i = 0; i < (StringToSearch.Length - StringToFind.Length + 1); i++)
				{
					SubstringFound = true;
					for (int j = 0; j < StringToFind.Length; j++)
					{
						if (StringToSearch[i + j] != StringToFind[j])
						{
							SubstringFound = false;
							j = StringToFind.Length;
						}
					}

					if (SubstringFound)
					{
						Result.Add(new int[2] { i, i + StringToFind.Length - 1 });
					}
				}
				return Result;
			}
			else
			{
				return Result;
			}
		}
		public static StringOperationType GetStringOperationType(string StringToModify, string StringToFind, string StringToReplace)
		{
			StringOperationType Result = StringOperationType.None;
			if ((StringToModify != null) && (!StringToModify.Equals(string.Empty)))
			{
				Result = Result | StringOperationType.Modify;
			}
			if ((StringToFind != null) && (!StringToFind.Equals(string.Empty)))
			{
				Result = Result | StringOperationType.Find;
			}
			if ((StringToReplace != null) && (!StringToReplace.Equals(string.Empty)))
			{
				Result = Result | StringOperationType.Replace;
			}

			StringOperationType ModifyAndFindNotNull = StringOperationType.Modify ^ StringOperationType.Find;
			if ((ModifyAndFindNotNull & Result) == ModifyAndFindNotNull)
			{
				if (StringToModify.Length < StringToFind.Length)
				{
					Result = Result | StringOperationType.ModifyTooShort;
				}
			}

			return Result;
		}
		public static string OperateOnString(string StringToModify, string StringToFind, string StringToReplace)
		{
			StringOperationType TypeOfOperation = GetStringOperationType(StringToModify, StringToFind, StringToReplace);
			
			// Error conditions
			if ((int)((StringOperationType.ModifyTooShort & TypeOfOperation)) == 8)
			{
				return string.Empty;
			}

			switch (TypeOfOperation)
			{
				case (StringOperationType.Modify):
					return StringToModify;
					break;
				case (StringOperationType.Find):
					return string.Empty;
					break;
				case (StringOperationType.Modify ^ StringOperationType.Find):
					return RemoveSubstringFromString(StringToModify, StringToFind);
					break;
				case (StringOperationType.Replace):
					return StringToReplace;
					break;
				case (StringOperationType.Modify ^ StringOperationType.Replace):
					return StringToModify;
					break;
				case (StringOperationType.Find ^ StringOperationType.Replace):
					return string.Empty;
					break;
				case (StringOperationType.Modify ^ StringOperationType.Find ^ StringOperationType.Replace):
					return ReplaceSubstringWithSubstring(StringToModify, StringToFind, StringToReplace);
					break;
				case (StringOperationType.None):
					return string.Empty;
					break;
				default:
					return string.Empty;
					break;
			}
		}
		public static string RemoveSubstringFromString(string StringToModify, string StringToRemove)
		// This is currently sort of an O[n^2] operation because I'm using BubbleSort on the Indexes array.
		// In the future I'll make it into an O[nlogn] operation by finishing my implementation of quicksort and
		// adding it to the class library in this solution.
		{
			StringBuilder ModifiedString = new StringBuilder();
			ModifiedString.Append(StringToModify);
			List<int[]> ListOfIndexes = FindIndexesOfSubstringsInString(StringToModify, StringToRemove);
			
			if (ListOfIndexes.Count > 0)
			{
				ModifiedString.Length = 0;

				int[] Indexes = GetSubstringStartIndexes(ListOfIndexes.ToArray());
				
                //BubbleSort<int>.Sort();
				int IndexOfIndexes = 0;

				for (int i = 0; i < StringToModify.Length; i++)
				{
					if ((IndexOfIndexes < Indexes.Length) && (i == Indexes[IndexOfIndexes]))
					{
						// While loop finds the right-most valid Index in Indexes that doesn't have an
						// overlapping index to it's right.
						while ((IndexOfIndexes < Indexes.Length - 1) &&
							((Indexes[IndexOfIndexes + 1] <= Indexes[IndexOfIndexes] + StringToRemove.Length - 1)))
						{
							IndexOfIndexes++;
						}

						i = Indexes[IndexOfIndexes] + StringToRemove.Length - 1;
						IndexOfIndexes++;
					}
					else
					{
						ModifiedString.Append(StringToModify[i]);
					}
				}
			}
			
			return ModifiedString.ToString();
		}
		public static string ReplaceSubstringWithSubstring(string StringToModify, string StringToFind, string StringToReplace)
		{
			StringBuilder ModifiedString = new StringBuilder();
			ModifiedString.Append(StringToModify);


			return ModifiedString.ToString();
		}

		public static int[] GetSubstringStartIndexes(int[][] SubstringIndexes)
		{
			return GetSubstringIndexesOf(SubstringIndexes, 0);
		}
		public static int[] GetSubstringEndIndexes(int[][] SubstringIndexes)
		{
			return GetSubstringIndexesOf(SubstringIndexes, 1);
		}
		public static int[] GetSubstringIndexesOf(int[][] SubstringIndexes, int Dimension)
		{
			int[] Result = new int[0];
			if ((SubstringIndexes != null) && (SubstringIndexes.GetLength(0) > 0))
			{
				Result = new int[SubstringIndexes.GetLength(0)];
				for (int i = 0; i < Result.Length; i++)
				{
					Result[i] = SubstringIndexes[i][Dimension];
				}
			}
			return Result;
		}
	}
}
