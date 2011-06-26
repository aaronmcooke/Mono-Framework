// <copyright file="CombinatorialGenerator_UnitTests.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;
using System.Text;
using GoatDogGames;
using NUnit.Framework;

// TODO : Refactor and place regions in helper classes

namespace GoatDogGames_UnitTests
{
    namespace CombinatorialGeneratorTests
    {
        #region Helper Objects

        public class CombinatorialGenerator_TestClass
        {
            public List<Combinatorial<string>> Combinatorials;
            public CombinatorialTier<string> Tier;

            public List<ErrorBase> Errors;
            public List<ParameterBase> Reports;

            public CombinatorialGenerator_TestClass()
            {
                Errors = new List<ErrorBase>();
                Reports = new List<ParameterBase>();
                Combinatorials = new List<Combinatorial<string>>();
                Tier = null;
            }

            public void HandleError(ErrorBase errorToHandle)
            {
                if (errorToHandle != null)
                {
                    Errors.Add(errorToHandle);
                }
            }
            public void HandleReport(ParameterBase reportToHandle)
            {
                if ((reportToHandle != null) && (reportToHandle.Type == typeof(string)))
                {
                    Reports.Add(reportToHandle);

                    if (reportToHandle.Name == "Combinatorial")
                    {
                        CombinatorialParameter<string> newParameter = (CombinatorialParameter<string>)reportToHandle;
                        Combinatorials.Add(newParameter.Combinatorial);
                    }
                    else if (reportToHandle.Name == "CombinatorialTier")
                    {
                        CombinatorialTierParameter<string> newParameter = (CombinatorialTierParameter<string>)reportToHandle;
                        Tier = newParameter.Tier;
                    }
                }
            }

            public bool ContainsError(string errorName)
            {
                bool containsResult = false;
                foreach (ErrorBase error in Errors)
                {
                    if (error.Name == errorName)
                    {
                        containsResult = true;
                    }
                }
                return containsResult;
            }
            
            public static List<string> GetCountOneList()
            {
                List<string> newList = new List<string>();
                newList.Add("A");
                return newList;
            }
            public static List<string> GetCountTwoList()
            {
                List<string> newList = new List<string>();
                newList.Add("A");
                newList.Add("B");
                return newList;
            }
            public static List<string> GetCountThreeList()
            {
                List<string> newList = new List<string>();
                newList.Add("A");
                newList.Add("B");
                newList.Add("C");
                return newList;
            }           
            
            public static List<string> Get_CountOne_TierOne_NoDegenerates()
            {
                List<string> newList = new List<string>();
                newList.Add("A");
                return newList;
            }
            public static List<string> Get_CountTwo_TierOne_NoDegenerates()
            {
                List<string> newList = new List<string>();
                newList.Add("A");
                newList.Add("B");
                return newList;
            }
            public static List<string> Get_CountTwo_TierTwo_NoDegenerates()
            {
                List<string> newList = new List<string>();
                newList.Add("AB");
                return newList;
            }
            public static List<string> Get_CountThree_TierOne_NoDegenerates()
            {
                List<string> newList = new List<string>();
                newList.Add("A");
                newList.Add("B");
                newList.Add("C");
                return newList;
            }
            public static List<string> Get_CountThree_TierTwo_NoDegenerates()
            {
                List<string> newList = new List<string>();
                newList.Add("AB");
                newList.Add("AC");
                newList.Add("BC");
                return newList;
            }
            public static List<string> Get_CountThree_TierThree_NoDegenerates()
            {
                List<string> newList = new List<string>();
                newList.Add("ABC");
                return newList;
            }

            public static List<string> Get_CountOne_TierTwo_DegeneratesAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AA");
                return newList;
            }
            public static List<string> Get_CountTwo_TierTwo_DegeneratesAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AA");
                newList.Add("AB");
                newList.Add("BB");
                return newList;
            }
            public static List<string> Get_CountTwo_TierThree_DegeneratesAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AAA");
                newList.Add("AAB");
                newList.Add("ABB");
                newList.Add("BBB");
                return newList;
            }
            public static List<string> Get_CountThree_TierTwo_DegeneratesAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AA");
                newList.Add("AB");
                newList.Add("AC");
                newList.Add("BB");
                newList.Add("BC");
                newList.Add("CC");
                return newList;
            }
            public static List<string> Get_CountThree_TierThree_DegeneratesAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AAA");
                newList.Add("AAB");
                newList.Add("AAC");
                newList.Add("ABB");
                newList.Add("ABC");
                newList.Add("ACC");
                newList.Add("BBB");
                newList.Add("BBC");
                newList.Add("BCC");
                newList.Add("CCC");
                return newList;
            }
            public static List<string> Get_CountThree_TierFour_DegeneratesAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AAAA");
                newList.Add("AAAB");
                newList.Add("AAAC");
                newList.Add("AABB");
                newList.Add("AABC");
                newList.Add("AACC");
                newList.Add("ABBB");
                newList.Add("ABBC");
                newList.Add("ABCC");
                newList.Add("ACCC");
                newList.Add("BBBB");
                newList.Add("BBBC");
                newList.Add("BBCC");
                newList.Add("BCCC");
                newList.Add("CCCC");
                return newList;
            }

            public static List<string> Get_CountOne_TierTwo_PermutationsAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AA");
                return newList;
            }
            public static List<string> Get_CountTwo_TierTwo_PermutationsAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AA");
                newList.Add("AB");
                newList.Add("BA");
                newList.Add("BB");
                return newList;
            }
            public static List<string> Get_CountTwo_TierThree_PermutationsAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AAA");
                newList.Add("AAB");
                newList.Add("ABA");
                newList.Add("BAA");
                newList.Add("ABB");
                newList.Add("BAB");
                newList.Add("BBA");
                newList.Add("BBB");
                return newList;
            }
            public static List<string> Get_CountThree_TierTwo_PermutationsAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AA");
                newList.Add("AB");
                newList.Add("BA");
                newList.Add("AC");
                newList.Add("CA");
                newList.Add("BB");
                newList.Add("BC");
                newList.Add("CB");
                newList.Add("CC");
                return newList;
            }
            public static List<string> Get_CountThree_TierThree_PermutationsAllowed()
            {
                List<string> newList = new List<string>();
                newList.Add("AAA");
                newList.Add("AAB");
                newList.Add("ABA");
                newList.Add("BAA");
                newList.Add("ABB");
                newList.Add("BAB");
                newList.Add("BBA");
                newList.Add("BBB");
                newList.Add("AAC");
                newList.Add("ACA");
                newList.Add("CAA");
                newList.Add("ACC");
                newList.Add("CAC");
                newList.Add("CCA");
                newList.Add("ABC");
                newList.Add("ACB");
                newList.Add("BAC");
                newList.Add("BCA");
                newList.Add("CAB");
                newList.Add("CBA");
                newList.Add("BBC");
                newList.Add("BCB");
                newList.Add("CBB");
                newList.Add("BCC");
                newList.Add("CBC");
                newList.Add("CCB");
                newList.Add("CCC");
                return newList;
            }

            public static List<string> ConvertCombinatorialsToStringList(List<Combinatorial<string>> combinatorialsPassed)
            {
                List<string> resultList = new List<string>();
                StringBuilder itemText = new StringBuilder();

                foreach (Combinatorial<string> combinatorial in combinatorialsPassed)
                {
                    foreach (string element in combinatorial.Elements)
                    {
                        itemText.Append(element);
                    }

                    resultList.Add(itemText.ToString());
                    itemText.Length = 0;
                }

                return resultList;
            }
            public static List<string> ConvertCombinatorialsToStringList(CombinatorialTier<string> combinatorialsPassed)
            {
                return ConvertCombinatorialsToStringList(combinatorialsPassed.Tier);
            }         
        }

        #endregion
        #region CombinatorialGenerator

        [TestFixture]
        public class CombinatorialGenerator_InitialState
        {
            [Test]
            public void InitialState_CurrentTierValue()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                Assert.AreEqual(0, testGenerator.CurrentTierValue);
            }
            [Test]
            public void InitialState_Elements()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                Assert.IsNotNull(testGenerator.Elements);
                Assert.AreEqual(0, testGenerator.Elements.Count);
            }
            [Test]
            public void InitialState_Type()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                Assert.AreEqual(typeof(string).ToString(), testGenerator.Type.ToString());
            }
            [Test]
            public void InitialState_CurrentRule()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                Assert.AreEqual(CombinatorialRule.Strict, testGenerator.CurrentRule);
            }
            [Test]
            public void InitialState_MinimumTierValue()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                Assert.AreEqual(0,testGenerator.MinimumTierValue);
            }
            [Test]
            public void InitialState_MaximumTierValue()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                Assert.AreEqual(0,testGenerator.MaximumTierValue);
            }
            [Test]
            public void InitialState_ErrorsOn()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                Assert.IsFalse(testGenerator.ErrorsOn);
            }
            [Test]
            public void InitialState_ReportingOn()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                Assert.IsFalse(testGenerator.ReportingOn);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_InitialState_Null
        {
            [Test]
            public void InitialState_CurrentTierValue()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(null);
                Assert.AreEqual(0, testGenerator.CurrentTierValue);
            }
            [Test]
            public void InitialState_Elements()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(null);
                Assert.IsNotNull(testGenerator.Elements);
                Assert.AreEqual(0, testGenerator.Elements.Count);
            }
            [Test]
            public void InitialState_Type()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(null);
                Assert.AreEqual(typeof(string).ToString(), testGenerator.Type.ToString());
            }
            [Test]
            public void InitialState_CurrentRule()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(null);
                Assert.AreEqual(CombinatorialRule.Strict, testGenerator.CurrentRule);
            }
            [Test]
            public void InitialState_MinimumTierValue()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(null);
                Assert.AreEqual(0, testGenerator.MinimumTierValue);
            }
            [Test]
            public void InitialState_MaximumTierValue()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(null);
                Assert.AreEqual(0, testGenerator.MaximumTierValue);
            }
            [Test]
            public void InitialState_ErrorsOn()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(null);
                Assert.IsFalse(testGenerator.ErrorsOn);
            }
            [Test]
            public void InitialState_ReportingOn()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(null);
                Assert.IsFalse(testGenerator.ReportingOn);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_InitialState_Empty
        {
            [Test]
            public void InitialState_CurrentTierValue()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(new List<string>());
                Assert.AreEqual(0, testGenerator.CurrentTierValue);
            }
            [Test]
            public void InitialState_Elements()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(new List<string>());
                Assert.IsNotNull(testGenerator.Elements);
                Assert.AreEqual(0, testGenerator.Elements.Count);
            }
            [Test]
            public void InitialState_Type()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(new List<string>());
                Assert.AreEqual(typeof(string).ToString(), testGenerator.Type.ToString());
            }
            [Test]
            public void InitialState_CurrentRule()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(new List<string>());
                Assert.AreEqual(CombinatorialRule.Strict, testGenerator.CurrentRule);
            }
            [Test]
            public void InitialState_MinimumTierValue()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(new List<string>());
                Assert.AreEqual(0, testGenerator.MinimumTierValue);
            }
            [Test]
            public void InitialState_MaximumTierValue()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(new List<string>());
                Assert.AreEqual(0, testGenerator.MaximumTierValue);
            }
            [Test]
            public void InitialState_ErrorsOn()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(new List<string>());
                Assert.IsFalse(testGenerator.ErrorsOn);
            }
            [Test]
            public void InitialState_ReportingOn()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(new List<string>());
                Assert.IsFalse(testGenerator.ReportingOn);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_InitialState_CountOneList
        {
            [Test]
            public void InitialState_CurrentTierValue()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountOneList()));
                Assert.AreEqual(1, testGenerator.CurrentTierValue);
            }
            [Test]
            public void InitialState_Elements()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountOneList()));
                Assert.IsNotNull(testGenerator.Elements);
                Assert.AreEqual(1, testGenerator.Elements.Count);
            }
            [Test]
            public void InitialState_Type()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountOneList()));
                Assert.AreEqual(typeof(string).ToString(), testGenerator.Type.ToString());
            }
            [Test]
            public void InitialState_CurrentRule()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountOneList()));
                Assert.AreEqual(CombinatorialRule.Strict, testGenerator.CurrentRule);
            }
            [Test]
            public void InitialState_MinimumTierValue()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountOneList()));
                Assert.AreEqual(1, testGenerator.MinimumTierValue);
            }
            [Test]
            public void InitialState_MaximumTierValue()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountOneList()));
                Assert.AreEqual(1, testGenerator.MaximumTierValue);
            }
            [Test]
            public void InitialState_ErrorsOn()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountOneList()));
                Assert.IsFalse(testGenerator.ErrorsOn);
            }
            [Test]
            public void InitialState_ReportingOn()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountOneList()));
                Assert.IsFalse(testGenerator.ReportingOn);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_InitialState_CountTwoList
        {
            [Test]
            public void InitialState_CurrentTierValue()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountTwoList()));
                Assert.AreEqual(1, testGenerator.CurrentTierValue);
            }
            [Test]
            public void InitialState_Elements()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountTwoList()));
                Assert.IsNotNull(testGenerator.Elements);
                Assert.AreEqual(2, testGenerator.Elements.Count);
            }
            [Test]
            public void InitialState_Type()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountTwoList()));
                Assert.AreEqual(typeof(string).ToString(), testGenerator.Type.ToString());
            }
            [Test]
            public void InitialState_CurrentRule()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountTwoList()));
                Assert.AreEqual(CombinatorialRule.Strict, testGenerator.CurrentRule);
            }
            [Test]
            public void InitialState_MinimumTierValue()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountTwoList()));
                Assert.AreEqual(1, testGenerator.MinimumTierValue);
            }
            [Test]
            public void InitialState_MaximumTierValue()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountTwoList()));
                Assert.AreEqual(2, testGenerator.MaximumTierValue);
            }
            [Test]
            public void InitialState_ErrorsOn()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountTwoList()));
                Assert.IsFalse(testGenerator.ErrorsOn);
            }
            [Test]
            public void InitialState_ReportingOn()
            {
                CombinatorialGenerator<string> testGenerator =
                    new CombinatorialGenerator<string>(new List<string>(CombinatorialGenerator_TestClass.GetCountTwoList()));
                Assert.IsFalse(testGenerator.ReportingOn);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_ErrorHandler
        {
            // TODO : Add Test Cases For TryGetFail and ExceptionThrown
            // TODO : Add Test Case For CurrentRuleNotValid

            [Test]
            public void ErrorHandler_Assignment()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                Assert.IsTrue(testGenerator.ErrorsOn);
            }
            [Test]
            public void ErrorHandler_ElementsIsNull()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = null;

                Assert.AreEqual(1, handlerClass.Errors.Count);
                Assert.IsTrue(handlerClass.ContainsError("ElementsIsNull"));
            }
            [Test]
            public void ErrorHandler_ElementsIsEmpty()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = new List<string>();

                Assert.AreEqual(1, handlerClass.Errors.Count);
                Assert.IsTrue(handlerClass.ContainsError("ElementsIsEmpty"));
            }
            [Test]
            public void ErrorHandler_GetCombinatorials_ElementsIsEmpty()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsFalse(getResult);
                Assert.AreEqual(1, handlerClass.Errors.Count);
                Assert.IsTrue(handlerClass.ContainsError("ElementsIsEmpty"));
            }
            [Test]
            public void ErrorHandler_GetCombinatorials_TierMinAndMaxLessThanZero()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                bool getResult = testGenerator.GetCombinatorials(0);

                Assert.IsFalse(getResult);
                Assert.AreEqual(2, handlerClass.Errors.Count);
                Assert.IsTrue(handlerClass.ContainsError("TierMinLessThanOne"));
                Assert.IsTrue(handlerClass.ContainsError("TierMaxLessThanOne"));
            }
            [Test]
            public void ErrorHandler_GetCombinatorials_TierMinAndMaxMoreThanElementsCount()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                bool getResult = testGenerator.GetCombinatorials(2);

                Assert.IsFalse(getResult);
                Assert.AreEqual(2, handlerClass.Errors.Count);
                Assert.IsTrue(handlerClass.ContainsError("TierMinMoreThanElementsCount"));
                Assert.IsTrue(handlerClass.ContainsError("TierMaxMoreThanElementsCount"));
            }
            [Test]
            public void ErrorHandler_GetCombinatorials_TierMinLessThanOne()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                bool getResult = testGenerator.GetCombinatorials(0, 2);

                Assert.IsFalse(getResult);
                Assert.AreEqual(1, handlerClass.Errors.Count);
                Assert.IsTrue(handlerClass.ContainsError("TierMinLessThanOne"));
            }
            [Test]
            public void ErrorHandler_GetCombinatorials_TierMaxLessThanOne()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                bool getResult = testGenerator.GetCombinatorials(1, 0);

                Assert.IsFalse(getResult, "Get Result");
                Assert.AreEqual(2, handlerClass.Errors.Count, "Errors.Count");
                Assert.IsTrue(handlerClass.ContainsError("TierMaxLessThanOne"), "Contains TierMaxLessThanOne");
                Assert.IsTrue(handlerClass.ContainsError("TierMaxLessThanTierMin"), "Contains TierMaxLessThanTierMin");
            }
            [Test]
            public void ErrorHandler_GetCombinatorials_TierMaxLessThanTierMin()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                bool getResult = testGenerator.GetCombinatorials(2, 1);

                Assert.IsFalse(getResult);
                Assert.AreEqual(1, handlerClass.Errors.Count);
                Assert.IsTrue(handlerClass.ContainsError("TierMaxLessThanTierMin"));
            }
            [Test]
            public void ErrorHandler_GetCombinatorials_TierMinGreaterThanElementsCount()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                bool getResult = testGenerator.GetCombinatorials(3, 2);

                Assert.IsFalse(getResult, "Get Result");
                Assert.AreEqual(2, handlerClass.Errors.Count, "Errors.Count");
                Assert.IsTrue(handlerClass.ContainsError("TierMaxLessThanTierMin"), "Contains TierMaxLessThanTierMin");
                Assert.IsTrue(handlerClass.ContainsError("TierMinMoreThanElementsCount"), "Contains TierMinMoreThanElementsCount");
            }
            [Test]
            public void ErrorHandler_GetCombinatorials_TierMaxGreaterThanElementsCount()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                bool getResult = testGenerator.GetCombinatorials(1, 3);

                Assert.IsFalse(getResult, "Get Result");
                Assert.AreEqual(1, handlerClass.Errors.Count, "Errors.Count");
                Assert.IsTrue(handlerClass.ContainsError("TierMaxMoreThanElementsCount"), "Contains TierMaxMoreThanElementsCount");
            }
            [Test]
            public void ErrorHandler_GetTier_TierPassedLessThanOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;
                CombinatorialTier<string> resultTier = null;
               
                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                bool getResult = testGenerator.GetCombinatorials();
                resultTier = testGenerator.GetTier(0);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, handlerClass.Errors.Count, "Errors.Count");
                Assert.IsTrue(handlerClass.ContainsError("TierPassedLessThanOne"), "Contains TierPassedLessThanOne");
            }
            [Test]
            public void GetTier_ElementsCountOne_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string>.ErrorOut errorHandler = handlerClass.HandleError;
                CombinatorialTier<string> resultTier = null;

                testGenerator.ErrorHandler = errorHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                bool getResult = testGenerator.GetCombinatorials();
                resultTier = testGenerator.GetTier(2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, handlerClass.Errors.Count, "Errors.Count");
                Assert.IsTrue(handlerClass.ContainsError("TryGetTierPassedFailed"), "TryGetTierPassedFailed");
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_ReportHandler
        {
            [Test]
            public void HandlersPassed_ReportHandlerAssignment()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ReportOut reportHandler = handlerClass.HandleReport;

                testGenerator.ReportingHandler = reportHandler;

                Assert.IsTrue(testGenerator.ReportingOn);
            }
            [Test]
            public void ReportHandler_ReportingTest()
            {
                CombinatorialGenerator_TestClass handlerClass = new CombinatorialGenerator_TestClass();
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialGenerator<string>.ReportOut reportHandler = handlerClass.HandleReport;
                CombinatorialTier<string> resultTier = null;
                List<string> expectedCombinatorials = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_NoDegenerates();
                
                testGenerator.ReportingHandler = reportHandler;
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(3);
                resultTier = testGenerator.GetTier(3);

                Assert.IsTrue(getResult);
                Assert.Greater(handlerClass.Combinatorials.Count, 0);
                Assert.IsNotNull(handlerClass.Tier);
                Assert.Greater(handlerClass.Tier.Tier.Count, 0);

                List<string> internalTierList = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                List<string> externalTierList = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(handlerClass.Tier);
                List<string> externalCombinatorialList = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(handlerClass.Combinatorials);

                CollectionAssert.AreEquivalent(internalTierList, externalTierList);
                CollectionAssert.AreEquivalent(internalTierList, externalCombinatorialList);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_ElementsPassed
        {
            [Test]
            public void ElementsPassed_null()
            {
                List<string> testList = null;

                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(testList);
                
                Assert.IsNotNull(testGenerator.Elements);
                Assert.AreEqual(0, testGenerator.MinimumTierValue, "MinimumTierValue");
                Assert.AreEqual(0, testGenerator.MaximumTierValue, "MaximumTierValue");
                Assert.AreEqual(0, testGenerator.TierCount, "TierCount");
            }
            [Test]
            public void ElementsPassed_Empty()
            {
                List<string> testList = new List<string>();

                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(testList);
                
                Assert.IsNotNull(testGenerator.Elements);
                Assert.AreEqual(0, testGenerator.Elements.Count, testList.Count.ToString());
                Assert.AreEqual(0, testGenerator.MinimumTierValue, "MinimumTierValue");
                Assert.AreEqual(0, testGenerator.MaximumTierValue, "MaximumTierValue");
                Assert.AreEqual(0, testGenerator.TierCount, "TierCount");
            }
            [Test]
            public void ElementsPassed_Count1()
            {
                List<string> testList = new List<string>();
                testList.Add("A");

                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(testList);

                Assert.IsNotNull(testGenerator.Elements);
                Assert.AreEqual(1, testGenerator.MinimumTierValue);
                Assert.AreEqual(1, testGenerator.MaximumTierValue);
            }
            [Test]
            public void ElementsPassed_Count2()
            {
                List<string> testList = new List<string>();
                testList.Add("A");
                testList.Add("B");

                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>(testList);

                Assert.IsNotNull(testGenerator.Elements);
                Assert.AreEqual(1, testGenerator.MinimumTierValue);
                Assert.AreEqual(2, testGenerator.MaximumTierValue);
            }        
        }

        [TestFixture]
        public class CombinatorialGenerator_CurrentRule
        {
            [Test]
            public void CombinatorialRule_EnumerationMembers()
            {
                int[] expectedValue = new int[] { 0, 1, 2 };
                string[] expectedNames = new string[] { "Strict", "DegeneratesAllowed", "PermutationsAllowed" };

                string[] actualNames = Enum.GetNames(typeof(CombinatorialRule));

                Assert.AreEqual(expectedNames.Length, actualNames.Length);

                for (int i = 0; i < expectedNames.Length; i++)
                {
                    CollectionAssert.Contains(actualNames, expectedNames[i]);
                    int actualValue = (int)Enum.Parse(typeof(CombinatorialRule), expectedNames[i]);
                    Assert.AreEqual(expectedValue[i], actualValue);
                }             
            }
            [Test]
            public void CombinatorialGenerator_CurrentRule_GetAndSet()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                Assert.AreEqual(CombinatorialRule.DegeneratesAllowed, testGenerator.CurrentRule);
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                Assert.AreEqual(CombinatorialRule.PermutationsAllowed, testGenerator.CurrentRule);
                testGenerator.CurrentRule = CombinatorialRule.Strict;
                Assert.AreEqual(CombinatorialRule.Strict, testGenerator.CurrentRule);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_GetTier
        {
            [Test]
            public void GetTier_ElementsIsEmpty_PassZero()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialTier<string> resultTier = null;

                resultTier = testGenerator.GetTier(0);

                Assert.IsNotNull(resultTier, "ResultTier");
                Assert.AreEqual(0, resultTier.Tier.Count, "Tier.Count");
            }
            [Test]
            public void GetTier_ElementsIsEmpty_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialTier<string> resultTier = null;

                resultTier = testGenerator.GetTier(1);

                Assert.IsNotNull(resultTier, "ResultTier");
                Assert.AreEqual(0, resultTier.Tier.Count, "Tier.Count");      
            }
            [Test]
            public void GetTier_ElementsCountOne_PassZero()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialTier<string> resultTier = null;
                
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                testGenerator.GetCombinatorials();
                resultTier = testGenerator.GetTier(0);

                Assert.IsNotNull(resultTier, "ResultTier");
                Assert.AreEqual(0, resultTier.Tier.Count, "Tier.Count");
            }
            [Test]
            public void GetTier_ElementsCountOne_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialTier<string> resultTier = null;

                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                testGenerator.GetCombinatorials();
                resultTier = testGenerator.GetTier(1);

                Assert.IsNotNull(resultTier, "ResultTier");
                Assert.AreEqual(1, resultTier.Tier.Count, "Tier.Count");
            }
            [Test]
            public void GetTier_ElementsCountOne_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                CombinatorialTier<string> resultTier = null;

                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                testGenerator.GetCombinatorials();
                resultTier = testGenerator.GetTier(2);

                Assert.IsNotNull(resultTier, "ResultTier");
                Assert.AreEqual(0, resultTier.Tier.Count, "Tier.Count"); 
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_GetCombinatorial_Strict_PassNone
        {
            [Test]
            public void GetCombinatorial_Strict_CountOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_Strict_CountTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierTwo_NoDegenerates();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_Strict_CountThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsTrue(getResult, "GetResult");
                Assert.AreEqual(3, testGenerator.TierCount, "TierCount");

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings, "CountThree_TierOne");

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_NoDegenerates();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings, "CountThree_TierTwo");

                resultTier = testGenerator.GetTier(3);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_NoDegenerates();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings, "CountThree_TierThree");
            }
        }
        
        [TestFixture]
        public class CombinatorialGenerator_GetCombinatorial_Degenerates_PassNone
        {
            [Test]
            public void GetCombinatorial_Degenerates_CountOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_Degenerates_CountTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierTwo_DegeneratesAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_Degenerates_CountThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsTrue(getResult);
                Assert.AreEqual(3, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_DegeneratesAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(3);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_DegeneratesAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_GetCombinatorial_Permutations_PassNone
        {
            [Test]
            public void GetCombinatorial_CountOne_Permutations_PassNone()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountTwo_Permutations_PassNone()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierTwo_PermutationsAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountThree_Permutations_PassNone()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials();

                Assert.IsTrue(getResult);
                Assert.AreEqual(3, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_PermutationsAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(3);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_PermutationsAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_GetCombinatorial_OverloadEquivalence
        {
            [Test]
            public void GetCombinatorial_CountOne_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                bool getResult = testGenerator.GetCombinatorials(1);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountOne_PassOne_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                bool getResult = testGenerator.GetCombinatorials(1, 1);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountTwo_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                bool getResult = testGenerator.GetCombinatorials(2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierTwo_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountThree_PassTwo_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(2, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountThree_PassOne_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(1, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(3, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_NoDegenerates();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(3);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_NoDegenerates();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_GetCombinatorial_Strict_PassOne
        {
            [Test]
            public void GetCombinatorial_CountTwo_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                bool getResult = testGenerator.GetCombinatorials(1);

                Assert.IsTrue(getResult, "GetResult");
                Assert.AreEqual(1, testGenerator.TierCount, "TierCount");

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings, "Combinatorials");
            }
            [Test]
            public void GetCombinatorial_CountThree_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(1);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountThree_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountThree_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(3);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }

        }

        [TestFixture]
        public class CombinatorialGenerator_GetCombinatorial_Strict_PassTwo
        {
            [Test]
            public void GetCombinatorial_CountTwo_PassOne_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                bool getResult = testGenerator.GetCombinatorials(1, 1);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountThree_PassOne_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(1, 1);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountThree_PassThree_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(3, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(3);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountThree_PassOne_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(1, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_NoDegenerates();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_CountThree_PassTwo_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                bool getResult = testGenerator.GetCombinatorials(2, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(3);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_NoDegenerates();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);

                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_GetCombinatorial_Degenerates_PassTwo
        {
            [Test]
            public void Degenerates_CountTwo_PassOne_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(1, 1);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Degenerates_CountTwo_PassTwo_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierTwo_DegeneratesAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Degenerates_CountThree_PassOne_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(1, 1);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Degenerates_CountThree_PassOne_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(1, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_DegeneratesAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Degenerates_CountThree_PassTwo_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_DegeneratesAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Degenerates_CountThree_PassTwo_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_DegeneratesAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(3);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_DegeneratesAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Degenerates_CountThree_PassThree_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(3, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(3);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_DegeneratesAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
        }

        [TestFixture]
        public class CombinatorialGeneator_GetCombinatorial_Permutations_PassTwo
        {
            [Test]
            public void Permutations_CountTwo_PassOne_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(1, 1);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Permutations_CountTwo_PassTwo_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierTwo_PermutationsAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Permutations_CountThree_PassOne_PassOne()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(1, 1);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Permutations_CountThree_PassOne_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(1, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_PermutationsAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Permutations_CountThree_PassTwo_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_PermutationsAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Permutations_CountThree_PassTwo_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierTwo_PermutationsAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(3);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_PermutationsAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void Permutations_CountThree_PassThree_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountThreeList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(3, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(3);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountThree_TierThree_PermutationsAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_GetCombinatorial_Degenerates_TierMaxMoreThanElementsCount
        {
            [Test]
            public void GetCombinatorial_Degenerates_CountOne_PassOne_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(1, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierTwo_DegeneratesAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_Degenerates_CountOne_PassTwo_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierTwo_DegeneratesAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_Degenerates_CountTwo_PassTwo_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierTwo_DegeneratesAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(3);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierThree_DegeneratesAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }           
            [Test]
            public void GetCombinatorial_Degenerates_CountTwo_PassThree_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.DegeneratesAllowed;
                bool getResult = testGenerator.GetCombinatorials(3, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(3);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierThree_DegeneratesAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
        }

        [TestFixture]
        public class CombinatorialGenerator_GetCombinatorial_Permutations_TierMaxMoreThanElementsCount
        {
            [Test]
            public void GetCombinatorial_Degenerates_CountOne_PassOne_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(1, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(1);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierOne_NoDegenerates();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(2);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierTwo_PermutationsAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_Degenerates_CountOne_PassTwo_PassTwo()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountOneList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 2);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountOne_TierTwo_PermutationsAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_Degenerates_CountTwo_PassTwo_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(2, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(2, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(2);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierTwo_PermutationsAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);

                resultTier = testGenerator.GetTier(3);
                expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierThree_PermutationsAllowed();
                actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
            [Test]
            public void GetCombinatorial_Degenerates_CountTwo_PassThree_PassThree()
            {
                CombinatorialGenerator<string> testGenerator = new CombinatorialGenerator<string>();
                testGenerator.Elements = CombinatorialGenerator_TestClass.GetCountTwoList();
                testGenerator.CurrentRule = CombinatorialRule.PermutationsAllowed;
                bool getResult = testGenerator.GetCombinatorials(3, 3);

                Assert.IsTrue(getResult);
                Assert.AreEqual(1, testGenerator.TierCount);

                CombinatorialTier<string> resultTier = testGenerator.GetTier(3);
                List<string> expectedStrings = CombinatorialGenerator_TestClass.Get_CountTwo_TierThree_PermutationsAllowed();
                List<string> actualStrings = CombinatorialGenerator_TestClass.ConvertCombinatorialsToStringList(resultTier);
                CollectionAssert.AreEquivalent(expectedStrings, actualStrings);
            }
        }

        #endregion
    }
}
