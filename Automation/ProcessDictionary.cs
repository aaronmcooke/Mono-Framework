// <copyright file = "ProcessDictionary.cs" company = "SofTest402.TeamAwesome">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com></email>

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GoatDogGames
{
	public class ProcessDictionary
	{
		#region Fields

		private Dictionary<string, Process> testProcesses;
		private int sleepTime;
		private int maxPollCount;
		private int maxWait;
		
        #endregion
		#region Properties
		
        
        
        #endregion
		#region Constructors

		public ProcessDictionary()
		{
			SetDefaultValues();
			InstanceObjects();
		}
		public ProcessDictionary(int sleepTimePassed, int maxPollCountPassed, int maxWaitPassed)
		{
			sleepTime = sleepTimePassed;
			maxPollCount = maxPollCountPassed;
			maxWait = maxWaitPassed;
			InstanceObjects();
		}
		private void SetDefaultValues()
		{
			sleepTime = 10;
			maxPollCount = 500;
			maxWait = 1500;
		}
		private void InstanceObjects()
		{
			testProcesses = new Dictionary<string, Process>();
		}

		#endregion
		#region Methods

		public void AddProcessToDictionary(string processKey, string newProcessPath)
		{
			Process newProcess = new Process();
			newProcess.StartInfo.FileName = newProcessPath;
			testProcesses.Add(processKey, newProcess);
		}
		public void StartProcess(string processKey)
		{
            StartProcess(processKey, false);
		}
        public void StartProcess(string processKey, bool checkForSecurityDialog)
        {
            Process processToStart = GetProcess(processKey);
            if (processToStart != null)
            {
                processToStart.Start();
                if (checkForSecurityDialog)
                {
                    NativeHelperMethods.HandleSecurityDialog(false, true);
                }
                ProcessWait(processKey, processToStart);
            }
        }
		public IntPtr GetMainWindowHandleOfProcess(string processKey)
		{
			ProcessWait(processKey);
			Process currentProcess = GetProcess(processKey);
            if (currentProcess != null)
            {
                return currentProcess.MainWindowHandle;
            }
            else
            {
                return IntPtr.Zero;
            }
		}
		public void ProcessWait(string processKey)
		{
			ProcessWait(processKey, GetProcess(processKey));
		}
		private void ProcessWait(string processKey, Process processToWaitFor)
		{
			int pollCount = 0;
			processToWaitFor.WaitForInputIdle();
			while ((processToWaitFor.MainWindowHandle.ToInt32() == 0) && (pollCount < maxPollCount))
			{
				processToWaitFor.Refresh();
				pollCount++;
				System.Threading.Thread.Sleep(sleepTime);
			}
		}
		public Process GetProcess(string processKey)
		{
			Process result = null;
			testProcesses.TryGetValue(processKey, out result);
			return result;
		}
		public void EndProcess(string processKey)
		{
			Process processToEnd = GetProcess(processKey);
			if (processToEnd != null)
			{
				processToEnd.CloseMainWindow();
				processToEnd.WaitForExit(maxWait);
				if (processToEnd.HasExited)
				{
				}
				else
				{
					processToEnd.Kill();
				}
			}
		}

		#endregion
	}
}
