// <copyright file="TestFile.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace GoatDogGames
{
	public class TestFile
	{
		public bool ReadyToGetData
		{
			get
			{
				bool Result = true;
				if (Name.Equals(string.Empty))
				{
					Result = false;
				}
				if (Delimiter.Equals(string.Empty))
				{
					Result = false;
				}
				if (ParameterCount < 2)
				{
					Result = false;
				}
				return Result;
			}
		}
		public bool ReadyToTestData
		{
			get { return TestData.Length > 0; }
		}

		private string[] testData;
		public string[] TestData
		{
			get { return testData; }
			set
			{
				if (value != null)
				{
					testData = value;
				}
			}
		}

		private string name;
		private string delimiter;
		private int parameterCount;
		private string filePath;

		public string Name
		{
			get { return name; }
		}
		public string Delimiter
		{
			get { return delimiter; }
		}
		public int ParameterCount
		{
			get { return parameterCount; }
		}
		public string FilePath
		{
			get { return filePath; }
		}

		public TestFile(string namePassed, string delimiterPassed, int parameterCountPassed)
		{
			testData = new string[0];

			name = string.Empty;
			delimiter = string.Empty;
			filePath = string.Empty;
			parameterCount = 0;

			if (parameterCountPassed > 0)
			{
				parameterCount = parameterCountPassed;
			}
			if (namePassed != null)
			{
				name = namePassed;
			}
			if (delimiterPassed != null)
			{
				delimiter = delimiterPassed;
			}
		}
		public TestFile(string namePassed, string delimiterPassed, int parameterCountPassed, string filePathPassed)
		{
			testData = new string[0];

			name = string.Empty;
			delimiter = string.Empty;
			filePath = string.Empty;
			parameterCount = 0;

			if (parameterCountPassed > 0)
			{
				parameterCount = parameterCountPassed;
			}
			if (namePassed != null)
			{
				name = namePassed;
			}
			if (delimiterPassed != null)
			{
				delimiter = delimiterPassed;
			}
			if (filePathPassed != null)
			{
				filePath = filePathPassed;
			}
		}
	}
}
