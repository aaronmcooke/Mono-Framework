// <copyright file="TestSuiteData.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
    public class TestSuiteData
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);

        #endregion
        #region Fields

        private bool process;

        private string suiteName;
        private string suiteDescription;

        private int batteryID;
        private string batteryName;
        private string batteryDescription;

        private int testCaseID;
        private string testCaseName;
        private string testCaseDescription;

        private int testStepID;
        private string testStepDescription;

        private HandleErrors errorHandler;
        private bool errorHandlerOn;

        #endregion
        #region Properties

        public bool Process
        {
            get { return process; }
        }

        public string SuiteName
        {
            get { return suiteName; }
        }
        public string SuiteDescription
        {
            get { return suiteDescription; }
        }

        public int BatteryID
        {
            get { return batteryID; }
        }
        public string BatteryName
        {
            get { return batteryName; }
        }
        public string BatteryDescription
        {
            get { return batteryDescription; }
        }        
        
        public int TestCaseID
        {
            get { return testCaseID; }
        }
        public string TestCaseName
        {
            get { return testCaseName; }
        }
        public string TestCaseDescription
        {
            get { return testCaseDescription; }
        }
        
        public int TestStepID
        {
            get { return testStepID; }
        }        
        public string TestStepDescription
        {
            get { return testStepDescription; }
        }
 
        public HandleErrors ErrorHandler
        {
            get { return errorHandler; }
            set
            {
                if (value == null)
                {
                    errorHandler = null;
                    errorHandlerOn = false;
                }
                else
                {
                    errorHandler = value;
                    errorHandlerOn = true;
                }
            }
        }
        public bool ErrorHandlerOn
        {
            get { return errorHandlerOn; }
        }

        public bool IsValid
        {
            get { return ValidateTestSuiteData(); }
        }

        #endregion
        #region Constructors

        public TestSuiteData()
        {
            process = false;

            suiteName = string.Empty;
            suiteDescription = string.Empty;

            batteryID = -1;
            batteryName = string.Empty;
            batteryDescription = string.Empty;

            testCaseID = -1;
            testCaseName = string.Empty;
            testCaseDescription = string.Empty;

            testStepID = -1;
            testStepDescription = string.Empty;

            errorHandler = null;
            errorHandlerOn = false;
        }

        #endregion
        #region Methods

        private bool ValidateTestSuiteData()
        {
            bool validateResult = true;

            if (SuiteName.Equals(string.Empty))
            {
                validateResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "SuiteName Empty";
                HandleError(newError);
            }
            else if ((TestCaseID > -1) && (BatteryID < 0))
            {
                validateResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "TestCaseID Set When BatteryID Not Set";
                HandleError(newError);
            }
            else if ((TestStepID > -1) && (BatteryID < 0))
            {
                validateResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "TestStepID Set When BatteryID Not Set";
                HandleError(newError);
            }
            else if ((TestStepID > -1) && (TestCaseID < 0))
            {
                validateResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "TestStepID Set When TestCaseID Not Set";
                HandleError(newError);
            }
            else if ((!BatteryName.Equals(string.Empty)) && (BatteryID < 0))
            {
                validateResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "BatteryName Set When BatteryID Not Set";
                HandleError(newError);
            }
            else if ((!BatteryDescription.Equals(string.Empty)) && (BatteryID < 0))
            {
                validateResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "BatteryDescription Set When BatteryID Not Set";
                HandleError(newError);
            }
            else if ((!TestCaseName.Equals(string.Empty)) && (TestCaseID < 0))
            {
                validateResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "TestCaseName Set When TestCaseID Not Set";
                HandleError(newError);
            }
            else if ((!TestCaseDescription.Equals(string.Empty)) && (TestCaseID < 0))
            {
                validateResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "TestCaseDescription Set When TestCaseID Not Set";
                HandleError(newError);
            }
            else if ((!TestStepDescription.Equals(string.Empty)) && (TestStepID < 0))
            {
                validateResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "BatteryIDNotSet";
                HandleError(newError);
            }

            return validateResult;
        }
        public void SetTestSuiteData(string[] suiteArray)
        {
            if (suiteArray == null)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "TestSuiteDataPassed Was NULL";
                HandleError(newError);
            }
            else if (suiteArray.Length != 11)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "testSuiteDataPassed.Length was not 11";
                HandleError(newError);
            }
            else
            {
                string processText = suiteArray[0].ToUpper();
                if ((processText.Equals("TRUE")) || (processText.Equals("YES")) || (processText.Equals("1")))
                {
                    process = true;
                }

                if (suiteArray[1] != null)
                {
                    suiteName = suiteArray[1];
                }
                if (suiteArray[2] != null)
                {
                    suiteName = suiteArray[2];
                }

                if (!Int32.TryParse(suiteArray[3], out batteryID))
                {
                    batteryID = -1;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "BatteryID Parse Failed";
                    HandleError(newError);
                }

                if (suiteArray[4] != null)
                {
                    batteryName = suiteArray[4];
                }
                if (suiteArray[5] != null)
                {
                    batteryDescription = suiteArray[5];
                }

                if (!Int32.TryParse(suiteArray[6], out testCaseID))
                {
                    testCaseID = -1;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "TestCaseID Parse Failed";
                    HandleError(newError);
                }

                if (suiteArray[7] != null)
                {
                    testCaseName = suiteArray[7];
                }
                if (suiteArray[8] != null)
                {
                    testCaseDescription = suiteArray[8];
                }

                if (!Int32.TryParse(suiteArray[9], out testStepID))
                {
                    testStepID = -1;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "TestStepID Parse Failed";
                    HandleError(newError);
                }

                if (suiteArray[10] != null)
                {
                    testStepDescription = suiteArray[10];
                }
            }
        }
        public override string ToString()
        {
            StringBuilder suiteText = new StringBuilder();
            string[] newArray = ToArray();

            for (int i = 0; i < newArray.Length; i++)
            {
                suiteText.AppendLine(newArray[0]);
            }

            return suiteText.ToString();
        }
        public string[] ToArray()
        {
            return new string[] 
            {
                Process.ToString(),
                SuiteName.ToString(),
                SuiteDescription.ToString(),
                BatteryID.ToString(),
                BatteryName.ToString(),
                BatteryDescription.ToString(),
                TestCaseID.ToString(),
                TestCaseName.ToString(),
                TestCaseDescription.ToString(),
                TestStepID.ToString(),
                TestStepDescription.ToString() 
            };
        }

        #endregion
        #region Handler Methods

        private void HandleError(ErrorBase errorToHandle)
        {
            if (ErrorHandlerOn)
            {
                ErrorHandler(errorToHandle);
            }
        }

        #endregion
    }
}
