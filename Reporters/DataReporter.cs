// <copyright file = "DataReporter.cs" company = "GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com></email>

// Version 2.0

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace GoatDogGames
{


	public class DataReporter
	{
		#region Fields

		private bool logOn;
		private bool consoleOn;
		private bool appendOn;
		private bool clearOnOpen;
		private bool tabsOn;
		private string logPath;
		private int lineWidth;
		private Encoding encodingToUse;
		private StringBuilder logText;
		private Tabbing tabs;
		private Delimited delimtedOutput;

		#endregion
		#region Properties

		public bool Ready
		{
			get
			{
				bool result = true;
				if (File.Exists(logPath))
				{
					try
					{
						if (AppendOn)
						{
							File.AppendAllText(logPath, string.Empty, UseThisEncoding);
						}
						else
						{
							File.WriteAllText(logPath, string.Empty, UseThisEncoding);
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
						result = false;
					}
				}
				else
				{
					result = false;
				}
				return result;
			}
		}
		public bool LogOn
		{
			get { return logOn; }
			set { logOn = value; }
		}
		public bool ConsoleOn
		{
			get { return consoleOn; }
			set { consoleOn = value; }
		}
		public bool AppendOn
		{
			get { return appendOn; }
			set { appendOn = value; }
		}
		public bool ClearOnFirstOpen
		{
			get { return clearOnOpen; }
			set { clearOnOpen = value; }
		}
		public bool TabsOn
		{
			get { return tabsOn; }
			set { tabsOn = value; }
		}
		public string LogPath
		{
			get { return logPath; }
			set { logPath = value; }
		}
		public int LineWidth
		{
			get { return lineWidth; }
			set { lineWidth = value; }
		}
		public Encoding UseThisEncoding
		{
			get { return encodingToUse; }
			set { encodingToUse = value; }
		}
		public Tabbing Tabs
		{
			get { return tabs; }
		}
		public Delimited DelimitedOutput
		{
			get { return delimtedOutput; }
		}
		
        #endregion
		#region Constructors

		// Instances DataReporter without creating or writing to the file.
		public DataReporter()
		{
			SetDefaults();
		}
		//Instances DataReporter and doesn't clear the file before writing a header line to it.
		public DataReporter(string logFilePath)
		{
			SetDefaults();
			DataReporterFirstOpened(logFilePath, true, true, false, true, string.Empty);
		}
		public DataReporter(string logFilePath, bool clearOnOpen)
		{
			SetDefaults();
			DataReporterFirstOpened(logFilePath, true, true, clearOnOpen, true, string.Empty);
		}
		public DataReporter(string logFilePath, bool logIsOn, bool consoleIsOn,
			bool clearOnOpen, bool useDefaultHeader, string customHeader)
		{
			SetDefaults();
			DataReporterFirstOpened(logFilePath, logIsOn, consoleIsOn, clearOnOpen, useDefaultHeader, customHeader);
		}
		private void SetDefaults()
		{
			logText = new StringBuilder();
			tabs = new Tabbing(3);
			delimtedOutput = new Delimited();

			LogOn = false;
			ConsoleOn = false;
			AppendOn = false;
			ClearOnFirstOpen = false;
			TabsOn = false;

			//LogPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "log.txt";
			UseThisEncoding = Encoding.ASCII;
			LineWidth = 78;
		}
		private void DataReporterFirstOpened(string logFilePath, bool logIsOn, bool consoleIsOn,
			bool clearOnOpen, bool useDefaultHeader, string customHeader)
		{
			if ((logFilePath != null) && (!logFilePath.Equals(string.Empty)))
			{
				LogPath = logFilePath;
				if (!File.Exists(LogPath))
				{
					FileStream newStream = File.Create(LogPath);
					newStream.Close();
				}
			}

			LogOn = logIsOn;
			ConsoleOn = consoleIsOn;

			if (clearOnOpen)
			{
				AppendOn = false;
			}
			else
			{
				AppendOn = true;
			}

			if ((useDefaultHeader) || ((customHeader != null) && (!customHeader.Equals(string.Empty))))
			{
				logText.AppendLine();
			}
			if (useDefaultHeader)
			{
				logText.AppendLine(GetHeaderLine("DataReporter"));
			}
			if ((customHeader != null) && (!customHeader.Equals(string.Empty)))
			{
				logText.Append(customHeader);
			}
			if ((useDefaultHeader) || ((customHeader != null) && (!customHeader.Equals(string.Empty))))
			{
				logText.AppendLine();
			}

			WriteAll();
			Clear();
			AppendOn = true;
		}
		
        #endregion
		#region Methods

		public void Append(string textToAppend)
		{
			logText.Append(textToAppend);
		}
		public void AppendLine()
		{
			AppendLine(string.Empty);
		}
		public void AppendLine(string textToAppend)
		{
            if ((textToAppend.Length > 0) & (TabsOn))
            {
                logText.AppendLine(tabs.TabCharacters + textToAppend);
            }
            else
            {
                logText.AppendLine(textToAppend);
            }
		}
		public void Clear()
		{
			logText.Length = 0;
		}
		public int WriteLine()
		{
			return WriteLine(string.Empty);
		}
		public int WriteLine(string lineToWrite)
		{
			int writeResult = 0;

            if (LogOn)
            {
                if ((lineToWrite.Length > 0) && (TabsOn))
                {
                    writeResult += WriteToLog(tabs.TabCharacters + lineToWrite);
                }
                else
                {
                    writeResult += WriteToLog(lineToWrite);
                }
            }
            if (ConsoleOn)
            {
                if ((lineToWrite.Length > 0) && (TabsOn))
                {
                    writeResult += WriteToConsole(tabs.TabCharacters + lineToWrite);
                }
                else
                {
                    writeResult += WriteToConsole(lineToWrite);
                }
            }

			return writeResult;
		}
		public int WriteAll()
		{
			int writeResult = 0;

            TabsOn = false;
			writeResult = WriteLine(logText.ToString());
            TabsOn = true;

			if (writeResult == 0)
			{
				Clear();
			}

			return writeResult;
		}
		private int WriteToLog(string lineText)
		{
			if (Ready)
			{
				try
				{
					if (AppendOn)
					{
						File.AppendAllText(logPath, lineText, UseThisEncoding);
					}
					else
					{
						File.WriteAllText(logPath, lineText, UseThisEncoding);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return 1;
				}
				return 0;
			}
			else
			{
				return 1;
			}
		}
		private int WriteToConsole(string lineText)
		{
			if (AppendOn)
			{
				Console.Write(lineText);
			}
			else
			{
				Console.Clear();
				Console.Write(lineText);
			}
			return 0;
		}
		public string GetHeaderLine(string headerText)
		{
			string header = " " + headerText + " Started At " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + " ";
			int leftPadLength = (lineWidth - header.ToString().Length) / 2;
			return "[" + header.PadLeft(header.Length + leftPadLength,'-').PadRight(lineWidth,'-') + "]";
		}
		public override string ToString()
		{
			return logText.ToString();
		}
		
        #endregion
	}
}