using System;

namespace GoatDogGames
{
	public class Error
	{
		public static void ToConsole(string comment)
		{
			ToConsole(null, comment);
		}
		public static void ToConsole(Exception e)
		{
			ToConsole(e, null);
		}
		public static void ToConsole(Exception e, string comment)
		{
			if (e != null)
			{
				if (comment != null)
				{
					Console.WriteLine(comment);
				}

				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				Console.WriteLine();
				Console.Write("Press Enter To Continue: ");
				Console.ReadLine();
			}
			else
			{
				if (comment != null)
				{
					Console.WriteLine(comment);
					Console.WriteLine();
					Console.Write("Press Enter To Continue: ");
					Console.ReadLine();
				}
				else
				{
					throw new Exception("e and comment were both null.");
				}
			}
		}
	}
}
