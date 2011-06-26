// <copyright file="TestSuite.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
    public class TestSuite
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        private string name;
        private string description;
        private Dictionary<int, TestBattery> batteries;

        protected HandleErrors errorHandler;
        protected bool errorHandlerOn;
        protected HandleReports reportHandler;
        protected bool reportHandlerOn;

        #endregion
        #region Properties

        public string Name
        {
            get { return name; }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (value != null)
                {
                    description = value;
                }
                else
                {
                    description = string.Empty;
                }
            }
        }

        public bool IsEmpty
        {
            get { return batteries.Count == 0; }
        }
        public bool IsNotEmpty
        {
            get { return batteries.Count > 0; }
        }
        public int BatteryCount
        {
            get { return batteries.Count; }
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
        public HandleReports ReportHandler
        {
            get { return reportHandler; }
            set
            {
                if (value == null)
                {
                    reportHandler = null;
                    reportHandlerOn = false;
                }
                else
                {
                    reportHandler = value;
                    reportHandlerOn = true;
                }
            }
        }
        public bool ReportHandlerOn
        {
            get { return reportHandlerOn; }
        }

        #endregion
        #region Constructors

        public TestSuite()
        {
            name = string.Empty;
            description = string.Empty;
            batteries = new Dictionary<int, TestBattery>();

            errorHandler = null;
            reportHandler = null;
            errorHandlerOn = false;
            reportHandlerOn = false;
        }

        #endregion
        #region Methods

        public bool AddDataToSuite(TestSuiteData dataToAdd)
        {
            bool addResult = false;

            if (dataToAdd.IsValid)
            {
                if ((!dataToAdd.SuiteName.Equals(string.Empty)) && (!dataToAdd.SuiteName.Equals(Name)))
                {
                    name = dataToAdd.SuiteName;
                }

                if ((!dataToAdd.SuiteName.Equals(string.Empty)) && (!dataToAdd.SuiteDescription.Equals(Description)))
                {
                    description = dataToAdd.SuiteDescription;
                }

                if (dataToAdd.BatteryID > -1)
                {
                    if (batteries.ContainsKey(dataToAdd.BatteryID))
                    {
                        TestBattery currentBattery = null;
                        if (batteries.TryGetValue(dataToAdd.BatteryID, out currentBattery))
                        {
                            currentBattery.AddDataToBattery(dataToAdd);
                        }
                        else
                        {
                            TestBattery newBattery = new TestBattery(this, dataToAdd.BatteryID);
                            newBattery.AddDataToBattery(dataToAdd);
                            batteries.Add(dataToAdd.BatteryID, newBattery);
                        }
                    }
                }
            }
            else
            {
                addResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "dataToAdd.IsValid was FALSE";
                HandleError(newError);
            }

            return addResult;
        }
        public bool Traverse()
        {
            return false;
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
        private void HandleReport(ReportBase reportToHandle)
        {
            if (ReportHandlerOn)
            {
                ReportHandler(reportToHandle);
            }
        }

        #endregion
    }
}
