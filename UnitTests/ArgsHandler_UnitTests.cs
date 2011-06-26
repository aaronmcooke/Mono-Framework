// <copyright file="ArgsHandler_UnitTests.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;
using GoatDogGames;
using NUnit.Framework;

namespace GoatDogGames_UnitTests
{
    namespace ArgsHandlerTests
    {
        public class TestArgsHandler : BaseArgsHandler
        {
            #region Fields

            public List<string> Required;
            public List<string> Allowed;
            public List<string> Unique;
            public int MinArgs;
            public int MaxArgs;

            #endregion
            #region Constructors

            public TestArgsHandler()
            {
                Required = new List<string>();
                Allowed = new List<string>();
                Unique = new List<string>();
                MinArgs = 0;
                MaxArgs = 0;                
            }

            #endregion
            #region Implemented Abstract Methods

            protected override int PassMaxArgsToBase()
            {
                return MaxArgs;
            }
            protected override int PassMinArgsToBase()
            {
                return MinArgs;
            }
            protected override List<string> PassRequiredParametersToBase()
            {
                return Required;
            }
            protected override List<string> PassAllowedParametersToBase()
            {
                return Allowed;
            }
            protected override List<string> PassNonUniqueParametersToBase()
            {
                return Unique;
            }
            protected override List<Object> PassCustomParameterDefinitionsToBase()
            {
                return new List<object>();
            }
            
            #endregion
        }

        public class ArgsHandler_HelperClass
        {
            #region Fields

            public List<ErrorBase> Errors;
            public List<ReportBase> Reports;
            public TestArgsHandler ArgsHandler;

            #endregion
            #region Constructors

            public ArgsHandler_HelperClass()
            {
                Errors = new List<ErrorBase>();
                Reports = new List<ReportBase>();
                ArgsHandler = new TestArgsHandler();
            }

            #endregion
            #region Methods

            public void HandleError(ErrorBase errorPassed)
            {
                if (errorPassed != null)
                {
                    Errors.Add(errorPassed);
                }
            }
            public void HandleReport(ReportBase reportPassed)
            {
                if (reportPassed != null)
                {
                    Reports.Add(reportPassed);
                }
            }
            public bool ContainsError(string errorNamePassed)
            {
                bool containsResult = false;
                foreach (ErrorBase error in Errors)
                {
                    if (error.Name.Equals(errorNamePassed))
                    {
                        containsResult = true;
                    }
                }
                return containsResult;
            }
            public bool ContainsReport(string reportNamePassed)
            {
                bool containsResult = false;
                foreach (ReportBase report in Reports)
                {
                    if (report.Name.Equals(reportNamePassed))
                    {
                        containsResult = true;
                    }
                }
                return containsResult;
            }
            public void SetHandlersOn()
            {
                TestArgsHandler.HandleErrors errorHandler = HandleError;
                ArgsHandler.ErrorHandler = errorHandler;
                TestArgsHandler.HandleReports reportHandler = HandleReport;
                ArgsHandler.ReportHandler = reportHandler;
            }
            public void SetHandlersOff()
            {
                TestArgsHandler.HandleErrors errorHandler = null;
                ArgsHandler.ErrorHandler = errorHandler;
                TestArgsHandler.HandleReports reportHandler = null;
                ArgsHandler.ReportHandler = reportHandler;
            }

            #endregion
        }

        [TestFixture]
        public class ArgsHandler_Handlers
        {
            [Test]
            public void ArgsHandler_HandlersInitialStates()
            {
                ArgsHandler_HelperClass helperClass = new ArgsHandler_HelperClass();

                Assert.IsFalse(helperClass.ArgsHandler.ErrorHandlerOn, "ErrorHandlerOn");
                Assert.IsNull(helperClass.ArgsHandler.ErrorHandler, "ErrorHandler");
                Assert.IsFalse(helperClass.ArgsHandler.ReportHandlerOn, "ReportHandlerOn");
                Assert.IsNull(helperClass.ArgsHandler.ReportHandler, "ReportHandler");
            }
            [Test]
            public void ArgsHandler_SetHandlersToNotNull()
            {
                ArgsHandler_HelperClass helperClass = new ArgsHandler_HelperClass();
                helperClass.SetHandlersOn();

                Assert.IsTrue(helperClass.ArgsHandler.ErrorHandlerOn, "ErrorHandlerOn");
                Assert.IsNotNull(helperClass.ArgsHandler.ErrorHandler, "ErrorHandler");
                Assert.IsTrue(helperClass.ArgsHandler.ReportHandlerOn, "ReportHandlerOn");
                Assert.IsNotNull(helperClass.ArgsHandler.ReportHandler, "ReportHandler");
            }
            [Test]
            public void ArgsHandler_SetHandlerToNull()
            {
                ArgsHandler_HelperClass helperClass = new ArgsHandler_HelperClass();
                helperClass.SetHandlersOn();
                helperClass.SetHandlersOff();

                Assert.IsFalse(helperClass.ArgsHandler.ErrorHandlerOn, "ErrorHandlerOn");
                Assert.IsNull(helperClass.ArgsHandler.ErrorHandler, "ErrorHandler");
                Assert.IsFalse(helperClass.ArgsHandler.ReportHandlerOn, "ReportHandlerOn");
                Assert.IsNull(helperClass.ArgsHandler.ReportHandler, "ReportHandler");
            }
        }

        [TestFixture]
        public class ArgsHandler_ArgsPassed
        {
            [Test]
            public void ArgsPassed_Null()
            {
                ArgsHandler_HelperClass helperClass = new ArgsHandler_HelperClass();
                helperClass.SetHandlersOn();
                helperClass.ArgsHandler.Args = null;

                Assert.IsNotNull(helperClass.ArgsHandler.Args);
                Assert.AreEqual(0, helperClass.ArgsHandler.Args.Length);
                Assert.AreEqual(1, helperClass.Errors.Count);
                Assert.IsTrue(helperClass.ContainsError("ArgsPassedWasNull"));
            }
            [Test]
            public void ArgsPassed_Empty()
            {
                ArgsHandler_HelperClass helperClass = new ArgsHandler_HelperClass();
                helperClass.SetHandlersOn();
                helperClass.ArgsHandler.Args = new string[0];

                Assert.IsNotNull(helperClass.ArgsHandler.Args);
                Assert.AreEqual(0, helperClass.ArgsHandler.Args.Length);
                Assert.AreEqual(0, helperClass.Errors.Count);
            }
            [Test]
            public void ArgsPassed_LengthIs1()
            {
                ArgsHandler_HelperClass helperClass = new ArgsHandler_HelperClass();
                helperClass.SetHandlersOn();
                helperClass.ArgsHandler.Args = new string[] { "TEST" };

                Assert.IsNotNull(helperClass.ArgsHandler.Args);
                Assert.AreEqual(1, helperClass.ArgsHandler.Args.Length);
                Assert.AreEqual("TEST", helperClass.ArgsHandler.Args[0]);
                Assert.AreEqual(0, helperClass.Errors.Count);
            }
        }

        [TestFixture]
        public class ArgsHandler_PassedFromDerived
        {
            [Test]
            public void PassedFromDerived_ArgsMinLessThanZero()
            {
                ArgsHandler_HelperClass helper = new ArgsHandler_HelperClass();
                helper.SetHandlersOn();
                helper.ArgsHandler.MinArgs = -1;
                helper.ArgsHandler.MaxArgs = 2;

                Assert.AreEqual(1, helper.Errors.Count);
                Assert.IsTrue(helper.ContainsError("ArgsMinLessThanZero"));
            }
            [Test]
            public void PassedFromDerived_ArgsMaxLessThanZero()
            {
                ArgsHandler_HelperClass helper = new ArgsHandler_HelperClass();
                helper.SetHandlersOn();
                helper.ArgsHandler.MinArgs = -1;
                helper.ArgsHandler.MaxArgs = -1;

                Assert.AreEqual(2, helper.Errors.Count);
                Assert.IsTrue(helper.ContainsError("ArgsMinLessThanZero"));
                Assert.IsTrue(helper.ContainsError("ArgsMaxLessThanZero"));
            }
            [Test]
            public void PassedFromDerived_ArgsMaxLessThanArgsMin()
            {
                ArgsHandler_HelperClass helper = new ArgsHandler_HelperClass();
                helper.SetHandlersOn();
                helper.ArgsHandler.MinArgs = 2;
                helper.ArgsHandler.MaxArgs = 1;

                Assert.AreEqual(2, helper.Errors.Count);
                Assert.IsTrue(helper.ContainsError("ArgsMinLessThanZero"));
                Assert.IsTrue(helper.ContainsError("ArgsMaxLessThanZero"));
            }
            [Test]
            public void PassedFromDerived_RequiredCountGreaterThanArgsMax()
            {
                ArgsHandler_HelperClass helper = new ArgsHandler_HelperClass();
                helper.SetHandlersOn();
                helper.ArgsHandler.MinArgs = 1;
                helper.ArgsHandler.MaxArgs = 1;
                helper.ArgsHandler.Required.Add("-Test01:TestValue01");
                helper.ArgsHandler.Required.Add("-Test02:TestValue02");

                Assert.AreEqual(1, helper.Errors.Count);
                Assert.IsTrue(helper.ContainsError("ArgsRequiredMoreThanArgsMax"));
            }
        }
    }
}
