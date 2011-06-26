// <copyright file="TestCase.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
    public class TestCase
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        public TestBattery parent;
        private int id;
        private string name;
        private string description;
        private Dictionary<int, TestStep> testSteps;
        private HandleErrors errorHandler;
        private bool errorHandlerOn;
        private HandleReports reportHandler;
        private bool reportHandlerOn;

        #endregion
        #region Properties

        public int ID
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
        }
        public string Description
        {
            get { return description; }
        }
        public bool IsEmpty
        {
            get { return testSteps.Count == 0; }
        }
        public bool IsNotEmpty
        {
            get { return testSteps.Count > 0; }
        }
        public int Count
        {
            get { return testSteps.Count; }
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

        private TestCase()
        {
            name = string.Empty;
            description = string.Empty;
            testSteps = new Dictionary<int, TestStep>();

            reportHandler = null;
            reportHandlerOn = false;
        }
        public TestCase(TestBattery parentPassed, int idPassed)
            : this()
        {
            parent = parentPassed;
            id = idPassed;
        }

        #endregion
        #region Methods

        public void AddDataToTestCase(TestSuiteData dataToAdd)
        {
            if (!dataToAdd.TestCaseName.Equals(string.Empty))
            {
                name = dataToAdd.TestCaseName;
            }

            if (!dataToAdd.TestCaseDescription.Equals(string.Empty))
            {
                description = dataToAdd.TestCaseDescription;
            }

            if (dataToAdd.TestStepID > -1)
            {
                if (testSteps.ContainsKey(dataToAdd.TestStepID))
                {
                    TestStep currentTestStep = null;
                    testSteps.TryGetValue(dataToAdd.TestStepID, out currentTestStep);
                    currentTestStep.AddDataToTestStep(dataToAdd);
                }
                else
                {
                    TestStep newTestStep = new TestStep(this, dataToAdd.TestStepID);
                    newTestStep.AddDataToTestStep(dataToAdd);
                    testSteps.Add(dataToAdd.TestStepID, newTestStep);
                }
            }
        }
        public void Traverse()
        {
            if (IsNotEmpty)
            {
                Dictionary<int, TestStep>.ValueCollection steps = testSteps.Values;

                foreach (TestStep step in steps)
                {
                    ReportBase newReport = new ReportBase();
                    newReport.Name = step.ToString();
                    HandleReport(newReport);
                }
            }
        }
        public override string ToString()
        {
            StringBuilder caseText = new StringBuilder();

            caseText.AppendLine(parent.ID.ToString());
            caseText.AppendLine(ID.ToString());
            caseText.AppendLine(Name.ToString());
            caseText.AppendLine(Description.ToString());

            return caseText.ToString();
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
