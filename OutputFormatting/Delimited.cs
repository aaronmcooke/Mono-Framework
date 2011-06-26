// <copyright file = "Delimited.cs" company = "SofTest402.TeamAwesome">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com></email>

using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
    /// <summary>
    /// Converts input in the form of a string array, a string list or a list of string arrays
    /// to output in the form of a character delimited file with line and file termination characters.
    /// </summary>
	public class Delimited
    {
        #region Fields

        private char delimiter;
		private char[] lineTerminator;
		private char[] fileTerminator;

        #endregion
        #region Properties

        public char Delimiter
		{
			set { delimiter = value; }
		}
		public char[] LineTerminator
		{
			set { lineTerminator = value; }
		}
		public char[] FileTerminator
		{
			set { fileTerminator = value; }
        }

        #endregion
        #region Constructors

        public Delimited()
		{
			SetDefaults();
		}
		public Delimited(char delimiterPassed)
		{
			SetDefaults();
			delimiter = delimiterPassed;
		}
		public Delimited(char delimiterPassed, char[] lineTerminatorPassed, char[] fileTerminatorPassed)
		{
			delimiter = delimiterPassed;
			lineTerminator = lineTerminatorPassed;
			fileTerminator = fileTerminatorPassed;
		}
		private void SetDefaults()
		{
			delimiter = (char)9;
			lineTerminator = new char[] { (char)13, (char)10 };
			fileTerminator = new char[0];
        }

        #endregion
        #region Constructor Methods

        public void ResetDefaults()
		{
			SetDefaults();
        }

        #endregion
        #region Methods

        public string ArrayToString(string[] arrayPassed)
		{
			StringBuilder resultText = new StringBuilder();
			if ((arrayPassed != null) && (arrayPassed.Length > 1))
			{
				resultText.Append(arrayPassed[0]);
				for (int i = 1; i < arrayPassed.Length; i++)
				{
					resultText.Append(delimiter);
					resultText.Append(arrayPassed[i]);
				}
				resultText.Append(lineTerminator);
			}
			else if ((arrayPassed != null) && (arrayPassed.Length == 1))
			{
				resultText.Append(arrayPassed[0]);
				resultText.Append(lineTerminator);
			}
			else
			{
				resultText.Append(lineTerminator);
			}
			return resultText.ToString();
		}
		public string ArrayToString(string[] arrayPassed, int columnCount)
		{
			StringBuilder resultText = new StringBuilder();
			if ((arrayPassed != null) && (arrayPassed.Length > 0))
			{
				int lengthModColumnCount = arrayPassed.Length % columnCount;
				int lineCount = arrayPassed.Length / columnCount;


				int lineCounter = 0;
				int columnCounter = 0;
				List<string> listToPass = new List<string>();

				while (lineCounter < lineCount)
				{
					while (columnCounter < columnCount)
					{
						listToPass.Add(arrayPassed[lineCounter * columnCount + columnCounter]);
						columnCounter++;
					}
					columnCounter = 0;
					lineCounter++;

					resultText.Append(ListToString(listToPass));
					listToPass.Clear();
				}

				if (lengthModColumnCount != 0)
				{
					for (int i = (lineCounter * columnCount); i < arrayPassed.Length; i++)
					{
						listToPass.Add(arrayPassed[lineCounter * columnCount + columnCounter]);
					}
					for (int i = 0; i < (columnCount - lengthModColumnCount); i++)
					{
						listToPass.Add(string.Empty);
					}
					resultText.Append(ListToString(listToPass));
					listToPass.Clear();
				}
				resultText.Append(fileTerminator);
			}
			else
			{
				resultText.Append(ArrayListToString(null));
			}

			return resultText.ToString();
		}
		public string ListToString(List<string> listPassed)
		{
			string[] arrayToPass = listPassed.ToArray();
			return ArrayToString(arrayToPass);
		}
		public string ArrayListToString(List<string[]> arrayListPassed)
		{
			StringBuilder resultText = new StringBuilder();

			if ((arrayListPassed != null) && (arrayListPassed.Count > 0))
			{
				foreach (string[] item in arrayListPassed)
				{
					resultText.Append(ArrayToString(item));
				}
			}
			resultText.Append(fileTerminator);
			return resultText.ToString();
        }

        #endregion
    }
}
