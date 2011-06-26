// <copyright file = "Tabbing.cs" company = "SofTest402.TeamAwesome">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com></email>

using System;

namespace GoatDogGames
{
	[Serializable]
	public class Tabbing
	{
		private char tabCharacter;
		private int multiplier;
		private int position;

		public char TabCharacter
		{
			get { return tabCharacter; }
			set { tabCharacter = value; }
		}
		public int Multiplier
		{
			get { return multiplier; }
			set
			{
				if (value > -1)
				{
					multiplier = value;
				}
				else
				{
					multiplier = 0;
				}
			}
		}
		public int Position
		{
			get { return position; }
		}
		public int Value
		{
			get { return Position * Multiplier; }
		}
		public string TabCharacters
		{
			get { return string.Empty.PadLeft(Value, TabCharacter); }
		}

		public Tabbing()
		{
			Multiplier = 3;
			TabCharacter = ' ';
			position = 0;
		}
		public Tabbing(int multiplierPassed)
		{
			Multiplier = multiplierPassed;
		}
		public Tabbing(int multiplierPassed, char tabCharacterPassed)
		{
			Multiplier = multiplierPassed;
			TabCharacter = tabCharacterPassed;
		}
		public Tabbing(int multiplierPassed, char tabCharacterPassed, int startingPosition)
		{
			Multiplier = multiplierPassed;
			TabCharacter = tabCharacterPassed;
			if (startingPosition > -1)
			{
				position = startingPosition;
			}
			else
			{
				TabReset();
			}
		}

		public void TabIn()
		{
			position++;
		}
		public void TabOut()
		{
			if (position > 0)
			{
				position--;
			}
			else
			{
				TabReset();
			}
		}
		public void TabReset()
		{
			position = 0;
		}

		public string TabIn(string lineText)
		{
			TabIn();
			return TabCharacters + lineText;
		}
		public string TabOut(string lineText)
		{
			TabOut();
			return TabCharacters + lineText;
		}

	}
}
