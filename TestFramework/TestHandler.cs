// <copyright file="TestHandler.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace GoatDogGames
{
//    public enum TestExecutionStep
//    {
//        None,
//        Setup,
//        Run,
//        Validate,
//        TearDown,
//        Report
//    }
//    public class TestHandler
//    {
//        #region Fields

//        private List<TestBattery> batteries;
//        private List<ErrorBase> errors;
        
//        #endregion
//        #region Properties

//        public List<TestBattery> Batteries
//        {
//            get { return batteries; }
//        }
//        public List<ErrorBase> Errors
//        {
//            get { return errors; }
//        }

//        #endregion
//        #region Constructors

//        private TestHandler() { }
//        public TestHandler(HandleTestSetup TestSetupHandled)
//        {
//            batteries = new List<TestBattery>();
//            errors = new List<ErrorBase>();

//            CheckTestSetupHandledForNull(TestSetupHandled);
//        }

//        #endregion
//        #region Methods

//        public void All()
//        {
//            SetupTests();
//            RunTests();
//            ValidateResults();
//            TearDown();
//            Report();
//        }

//        private TestExecutionStep lastStep;
//        public void Next()
//        {
//            int nextStep = -1;
//            Type enumType = typeof(TestExecutionStep);
//            string enumName = string.Empty;

//            int[] steps = (int[])Enum.GetValues(typeof(TestExecutionStep));
//            for (int i = 0; i < steps.Length; i++)
//            {
//                //if (steps[i] = (int)lastStep)
//                //{
//                //    nextStep = steps[i + 1];
//                //    i = steps.Length;
//                //}
//            }

//            if (nextStep != -1)
//            {
//                //enumName = Enum.GetName(enumType, (object)nextStep);
//                //lastStep = Enum.Parse(enumType, enumName);
//            }
//            else
//            {
//                // TODO : Implement Error Message For This
//            }          
//        }
//        private void SetupTests()
//        {
//        }
//        private void RunTests()
//        {
//        }
//        private void ValidateResults()
//        {
//        }
//        private void TearDown()
//        {
//        }
//        public void Report()
//        {
//        }

//        private void CheckTestSetupHandledForNull(HandleTestSetup TestSetupHandled)
//        {
//            if (TestSetupHandled == null)
//            {
//                ErrorBase newError = new ErrorBase();
//                newError.Name = "TestSetupHandledNull";
//                newError.Message = "The HandleTestSetup passed to HandleTests was null.";
//                errors.Add(newError);
//            }
//            else
//            {
//                CheckTestSetupHandledForReady(TestSetupHandled);
//            }
//        }
//        private void CheckTestSetupHandledForReady(HandleTestSetup TestSetupHandled)
//        {
//            //if (TestSetupHandled.Ready)
//            //{
//            //    CreateTestBatteriesFromTestFiles(TestSetupHandled);
//            //}
//            //else
//            //{
//            //    ErrorBase NewError = new ErrorBase();
//            //    NewError.Name = "TestSetupHandledNotReady";
//            //    NewError.Message = "The HandleTestSetup passed to HandleTests wasn't ready.";
//            //    errors.Add(NewError);
//            //}
//        }
		
//        private void CreateTestBatteriesFromTestFiles(HandleTestSetup TestSetupHandled)
//        {
//            //foreach (TestFile FileOfTest in TestSetupHandled.TestFiles)
//            //{
//            //    CheckTestFileForNull(FileOfTest);
//            //}

//            CreateTestCasesInTestBatteries();
//        }
//        private void CheckTestFileForNull(TestFile FileOfTest)
//        {
//            if (FileOfTest == null)
//            {
//                ErrorBase NewError = new ErrorBase();
//                NewError.Name = "TestFileWasNull";
//                NewError.Message = "The TestFile object was null.";
//                errors.Add(NewError);
//            }
//            else
//            {
//                CheckTestFileForReady(FileOfTest);
//            }
//        }
//        private void CheckTestFileForReady(TestFile FileOfTest)
//        {
//            if (FileOfTest.ReadyToGetData)
//            {
//                TestBattery NewBattery = new TestBattery(FileOfTest);
//                batteries.Add(NewBattery);
//            }
//            else
//            {
//                ErrorBase NewError = new ErrorBase();
//                NewError.Name = "TestFileNotReady";
//                NewError.Message = "The TestFile wasn't ready.";
//                errors.Add(NewError);
//            }
//        }

//        private void CreateTestCasesInTestBatteries()
//        {
//            foreach (TestBattery Item in Batteries)
//            {
//                Item.ConvertTestDataToTestCases();
//            }
//            ProcessTestBatteries();
//        }
//        private void ProcessTestBatteries()
//        {			
//            foreach (TestBattery Item in Batteries)
//            {
//                RunTestCasesInTestBattery(Item);
//            }
//        }
//        private void RunTestCasesInTestBattery(TestBattery CurrentBattery)
//        {
//            foreach (TestCase Item in CurrentBattery.TestCases)
//            {
//                // Put Test Method Here
//            }
//        }

//        #endregion
//    }
}
