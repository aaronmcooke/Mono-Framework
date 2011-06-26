// <copyright file="GenericTree_UnitTests.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;
using GoatDogGames;
using GoatDogGames.Demographics;
using NUnit.Framework;

namespace GoatDogGames_UnitTests
{
    namespace GenericTreeTests
    {
        public class Person : IGenericNodeKeys<int>
        {
            public string ParentSSN;
            public string FirstName;
            public string MiddleName;
            public string LastName;
            public string SSN;
            public Sex PersonSex;

            public int Key
            {
                get { return Convert.ToInt32(SSN); }
            }
            public int ParentKey
            {
                get { return Convert.ToInt32(ParentSSN); }
            }

            public Person()
            {
                SSN = string.Empty;
                ParentSSN = string.Empty;
                FirstName = string.Empty;
                MiddleName = string.Empty;
                LastName = string.Empty;
                PersonSex = Sex.None;
            }
        }

        public class GenericTree_TestClass
        {
            private RandomDemographics DemographicGenerator;
            private RandomString StringGenerator;

            public List<ErrorBase> Errors;
            public List<ReportBase> Reports;
            public List<Person> ExpectedResults;
            public List<Person> ActualResults;

            public GenericTree_TestClass()
            {
                DemographicGenerator = new RandomDemographics(RandomDemographics.NewSeedValue);
                StringGenerator = new RandomString(RandomString.NewSeedValue);

                Errors = new List<ErrorBase>();
                Reports = new List<ReportBase>();
                ExpectedResults = new List<Person>();
                ActualResults = new List<Person>();
            }

            public void HandlerOfItems(Person itemToHandle)
            {
                ActualResults.Add(itemToHandle);
            }
            public void HandlerOfErrors(ErrorBase errorToHandle)
            {
                Errors.Add(errorToHandle);
            }
            public void HandlerOfReports(ReportBase reportToHandle)
            {
                Reports.Add(reportToHandle);
            }

            public bool CheckIfErrorsContains(string errorName)
            {
                bool checkResult = false;
                foreach (ErrorBase error in Errors)
                {
                    if (errorName.Equals(error.Name))
                    {
                        checkResult = true;
                    }
                }
                return checkResult;
            }

            public Person GetRootForTree(GenericTree<Person,int> testTreePassed)
            {
                ExpectedResults.Clear();
                Person newRoot = GetItemForTree(true);
                ExpectedResults.Add(newRoot);
                testTreePassed.SetRoot(newRoot);
                return newRoot;
            }
            public Person GetItemForTree(GenericTree<Person, int> testTreePassed)
            {
                ExpectedResults.Clear();
                Person newPerson = GetItemForTree(false);
                ExpectedResults.Add(newPerson);
                testTreePassed.Add(newPerson);
                return newPerson;
            }
            private Person GetItemForTree(bool isRootItem)
            {
                Person newPerson = new Person();

                newPerson.SSN = StringGenerator.GetRandomString(StringType.Numeric, 9);
                newPerson.PersonSex = DemographicGenerator.GetRandomSex();

                string[] nameArray = DemographicGenerator.GetName(newPerson.PersonSex);
                newPerson.FirstName = nameArray[0];
                newPerson.MiddleName = nameArray[1];
                newPerson.LastName = nameArray[2];

                if ((!isRootItem) && (ExpectedResults.Count > 0))
                {
                    int parentIndex = DemographicGenerator.ValueGen.Next(0, ExpectedResults.Count);
                    newPerson.ParentSSN = ExpectedResults[parentIndex].SSN;
                }

                return newPerson;
            }
        }

        [TestFixture]
        public class GenericTreeTests_HandleItems
        {
            [Test]
            public void HandleItems_DelegateNotSet()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();

                Assert.IsFalse(testTree.ItemHandlerOn, "ItemHandlerOn");
                Assert.IsNull(testTree.ItemHandler, "ItemHandler");
            }
            [Test]
            public void HandleItems_DelegateSet()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();
                GenericTree_TestClass testClass = new GenericTree_TestClass();
                GenericTree<Person, int>.HandleItems itemHandler = testClass.HandlerOfItems;
                testTree.ItemHandler = itemHandler;
                               
                Assert.IsTrue(testTree.ItemHandlerOn, "ItemHandlerOn");
                Assert.IsNotNull(testTree.ItemHandler, "ItemHandler");
            }
            [Test]
            public void HandleItems_DelegateSetBackToNull()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();
                GenericTree_TestClass testClass = new GenericTree_TestClass();
                GenericTree<Person, int>.HandleItems itemHandler = testClass.HandlerOfItems;
                testTree.ItemHandler = itemHandler;

                Assert.IsTrue(testTree.ItemHandlerOn, "ItemHandlerOn");
                Assert.IsNotNull(testTree.ItemHandler, "ItemHandler");

                testTree.ItemHandler = null;

                Assert.IsFalse(testTree.ItemHandlerOn, "ItemHandlerOn");
                Assert.IsNull(testTree.ItemHandler, "ItemHandler");
            }
        }

        [TestFixture]
        public class GenericTreeTests_HandleErrors
        {
            [Test]
            public void HandleErrors_DelegateNotSet()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();

                Assert.IsFalse(testTree.ErrorHandlerOn, "ErrorHandlerOn");
                Assert.IsNull(testTree.ErrorHandler, "ErrorHandler");
            }
            [Test]
            public void HandleErrors_DelegateSet()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();
                GenericTree_TestClass testClass = new GenericTree_TestClass();
                GenericTree<Person, int>.HandleErrors errorHandler = testClass.HandlerOfErrors;
                testTree.ErrorHandler = errorHandler;

                Assert.IsTrue(testTree.ErrorHandlerOn, "ErrorHandlerOn");
                Assert.IsNotNull(testTree.ErrorHandler, "ErrorHandler");
            }
            [Test]
            public void HandleErrors_DelegateSetBackToNull()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();
                GenericTree_TestClass testClass = new GenericTree_TestClass();
                GenericTree<Person, int>.HandleErrors errorHandler = testClass.HandlerOfErrors;
                testTree.ErrorHandler = errorHandler;

                Assert.IsTrue(testTree.ErrorHandlerOn, "ErrorHandlerOn");
                Assert.IsNotNull(testTree.ErrorHandler, "ErrorHandler");

                testTree.ErrorHandler = null;

                Assert.IsFalse(testTree.ErrorHandlerOn, "ErrorHandlerOn");
                Assert.IsNull(testTree.ErrorHandler, "ErrorHandler");
            }
        }

        [TestFixture]
        public class GenericTreeTests_TreeEmptyState
        {
            [Test]
            public void TreeEmptyState_TreeIsEmpty()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();
                GenericTree_TestClass helperClass = new GenericTree_TestClass();

                Assert.IsTrue(testTree.IsEmpty, "IsEmpty : True");

                helperClass.GetRootForTree(testTree);

                Assert.IsFalse(testTree.IsEmpty, "IsEmpty : False");
            }
            [Test]
            public void TreeEmptyState_TreeIsNotEmpty()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();
                GenericTree_TestClass helperClass = new GenericTree_TestClass();

                Assert.IsFalse(testTree.IsNotEmpty, "IsNotEmpty : True");

                helperClass.GetRootForTree(testTree);

                Assert.IsTrue(testTree.IsNotEmpty,"IsNotEmpty : False");
            }
        }

        [TestFixture]
        public class GenericTreeTests_AddItem
        {
            [Test]
            public void AddItem_ItemIsNull()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();
                GenericTree_TestClass helperClass = new GenericTree_TestClass();
                GenericTree<Person, int>.HandleErrors errorHandler = helperClass.HandlerOfErrors;
                testTree.ErrorHandler = errorHandler;

                bool addResult = testTree.Add(null);

                Assert.IsFalse(addResult);
                Assert.AreEqual(1, helperClass.Errors.Count);
                Assert.IsTrue(helperClass.CheckIfErrorsContains("ItemPassedWasNull"));
            }
            [Test]
            public void AddItem_RootNodeNotSet()
            {
                GenericTree<Person, int> testTree = new GenericTree<Person, int>();
                GenericTree_TestClass helperClass = new GenericTree_TestClass();
                GenericTree<Person, int>.HandleErrors errorHandler = helperClass.HandlerOfErrors;
                testTree.ErrorHandler = errorHandler;

                Person newPerson = new Person();
                bool addResult = testTree.Add(newPerson);

                Assert.IsFalse(addResult);
                Assert.AreEqual(1, helperClass.Errors.Count);
                Assert.IsTrue(helperClass.CheckIfErrorsContains("RootNodeNotSet"));
            }
            [Test]
            public void AddItem_ParentKeyNotFound()
            {

            }
            [Test]
            public void AddItem_ItemKeyAlreadyInTree()
            {

            }
            [Test]
            public void AddItem_ItemAdded()
            {

            }
        }

        [TestFixture]
        public class GenericTreeTests_SetRoot
        {

        }

        [TestFixture]
        public class GenericTreeTests_Count
        {
            //[Test]
            //public void Count_TreeIsEmpty()
            //{
            //}
            //[Test]
            //public void Count_TreeHasDepthOfZero()
            //{
            //}
            //[Test]
            //public void Count_TreeHasDepthOfOne()
            //{
            //}
        }


    }
}
