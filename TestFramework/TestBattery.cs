// <copyright file="TestBattery.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
    public class TestBattery
    {
        #region Fields

        private TestSuite parent;
        private int id;
        private string name;
        private string description;
        private Dictionary<int, TestCase> testCases;

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

        #endregion
        #region Constructor

        private TestBattery()
        {
            name = string.Empty;
            description = string.Empty;
            testCases = new Dictionary<int, TestCase>();
        }
        public TestBattery(TestSuite parentPassed, int idPassed)
            : this()
        {
            parent = parentPassed;
            id = idPassed;
        }

        #endregion
        #region Methods

        public void AddDataToBattery(TestSuiteData dataToAdd)
        {
            if (!dataToAdd.BatteryName.Equals(string.Empty))
            {
                name = dataToAdd.BatteryName;
            }

            if (!dataToAdd.BatteryDescription.Equals(string.Empty))
            {
                description = dataToAdd.BatteryDescription;
            }

            if (dataToAdd.TestCaseID > -1)
            {
                if (testCases.ContainsKey(dataToAdd.TestCaseID))
                {
                    TestCase currentTestCase = null;
                    testCases.TryGetValue(dataToAdd.TestCaseID, out currentTestCase);
                    currentTestCase.AddDataToTestCase(dataToAdd);
                }
                else
                {
                    TestCase newTestCase = new TestCase(this, dataToAdd.TestCaseID);
                    newTestCase.AddDataToTestCase(dataToAdd);
                    testCases.Add(dataToAdd.TestCaseID, newTestCase);
                }
            }
        }

        #endregion
    }
}
