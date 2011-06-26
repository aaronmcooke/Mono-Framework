// <copyright file = "PrimeNumbers.cs" company = "GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com></email>
using System;
using System.Collections.Generic;

// TODO :   Switch over to new delegate based error and report
//          handling methods.

namespace GoatDogGames
{
	public class PrimeNumbers
    {
        #region OutputSettings Enumeration

        [Flags()]
        public enum OutputSettings
        {
            None = 0,
            ErrorLogOn = 1,
            ConsoleOutputOn = 2,
            LogFileOn = 4
        }

        #endregion
        #region Fields

        private List<ErrorBase> errors;       
        private DataReporter classLogger;

        private bool errorLogOn;
        private bool consoleOutputOn;
        private bool logFileOn;

        private List<int> primes;

        #endregion
        #region Properties

        public List<int> Primes
        {
            get { return primes; }
        }
        
        public DataReporter ClassLogger
        {
            get
            {
                if ((consoleOutputOn) || (logFileOn))
                {
                    return classLogger;
                }
                else
                {
                    return null;
                }
            }
        }
        
        public List<ErrorBase> Errors
        {
            get
            {
                if (errorLogOn)
                {
                    return errors;
                }
                else
                {
                    return null;
                }
            }
        }
        public bool HasErrors
        {
            get
            {
                bool hasErrorsResult = false;
                if (errorLogOn)
                {
                    hasErrorsResult = errors.Count > 0;
                }
                return hasErrorsResult;
            }
        }
        public bool ErrorLogOn
        {
            get { return errorLogOn; }
        }
        public bool ConsoleOn
        {
            get { return consoleOutputOn; }
        }
        public bool LogFileOn
        {
            get { return logFileOn; }
        }

        #endregion
        #region Constructors

        public PrimeNumbers()
        {
            primes = new List<int>();
            classLogger = null;
            errors = null;
        }
        public PrimeNumbers(OutputSettings desiredSettings)
        {
            primes = new List<int>();
            classLogger = null;
            errors = null;

            if ((desiredSettings & OutputSettings.ErrorLogOn) == 0) 
            {
                errors = new List<ErrorBase>();
            }

            if (((desiredSettings & OutputSettings.ConsoleOutputOn) == 0)
                || ((desiredSettings & OutputSettings.LogFileOn)==0))
            {
                classLogger = new DataReporter();

                if ((desiredSettings & OutputSettings.LogFileOn) == 0)
                {
                    classLogger.LogOn = true;
                }
                if ((desiredSettings & OutputSettings.ConsoleOutputOn) == 0)
                {
                    classLogger.ConsoleOn = true;
                }
            } 
        }

        #endregion
        #region Methods

        public void FindFirstNPrimes(int numberOfPrimesToFind)
		{
			List<int> primesFoundSoFar = new List<int>();

			try
			{
				primesFoundSoFar.Add(2);
				primesFoundSoFar.Add(3);
				
                int currentNumber = 5;
				bool primeFound = true;
                int primeCountMustBeLessThan = numberOfPrimesToFind + 1;
				
                while (primesFoundSoFar.Count < primeCountMustBeLessThan)
				{
					int counter = 0;
					int primeMaximum = (int)Math.Sqrt((double)currentNumber);
					
                    while ((primeFound) && (primesFoundSoFar[counter] <= primeMaximum))
					{
						if ((currentNumber % primesFoundSoFar[counter++]) == 0)
						{
							primeFound = false;
						}
					}

					if (primeFound)
					{
						primesFoundSoFar.Add(currentNumber);
					}

					currentNumber += 2;
					primeFound = true;
				}
			}
			catch (Exception e)
			{
                if ((ConsoleOn) || (LogFileOn))
                {
                    classLogger.AppendLine(e.GetType().ToString());
                    classLogger.AppendLine(e.Message);
                    classLogger.AppendLine(e.StackTrace);
                    classLogger.WriteAll();
                }

                if (errorLogOn)
                {
                    ErrorBase newError = new ErrorBase();
                    newError.Exception = e;
                    newError.Name = "Exception";
                }
			}

			primes = primesFoundSoFar;
        }

        #endregion
    }
}
