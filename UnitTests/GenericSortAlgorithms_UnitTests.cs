// <copyright file="GenericSortAlgorithms_UnitTests.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;
using GoatDogGames;
using NUnit.Framework;

namespace GoatDogGames_UnitTests
{
    namespace GenericSortAlgorithmTests
    {
        #region Helper Methods

        public class GenericSort_TestClass
        {
            public static List<int> GetSortedList(int startValue, int endValue)
            {
                List<int> sortedList = new List<int>();

                for (int i = startValue; i < endValue + 1; i++)
                {
                    sortedList.Add(i);
                }

                return sortedList;
            }
            public static List<int> GetSortedListWithDuplicates(int startValue, int endValue, int duplicateCount)
            {
                List<int> sortedListWithDuplicates = new List<int>();

                for (int i = startValue; i < endValue + 1 ; i++)
                {
                    for ( int j = 0 ; j < duplicateCount ; j++)
                    {
                        sortedListWithDuplicates.Add(i);
                    }
                }

                return sortedListWithDuplicates;
            }
        }

        #endregion
        #region Unit Tests

        [TestFixture]
        public class BubbleSort_ValuesPassed
        {
            [Test]
            public void ValuePassed_Null()
            {
                List<int> testList = null;
                bool sortResult = BubbleSort<int>.Sort(testList);

                Assert.IsFalse(sortResult, "Sort Result");
            }
            [Test]
            public void ValuePassed_Empty()
            {
                List<int> emptyList = new List<int>();

                bool sortResult = BubbleSort<int>.Sort(emptyList);

                Assert.IsFalse(sortResult, "Sort Result");
                Assert.IsNotNull(emptyList);
                Assert.AreEqual(0, emptyList.Count);
            }
            [Test]
            public void ValuePassed_CountOfOne()
            {
                List<int> countOfOneList = new List<int>();
                countOfOneList.Add(1);

                bool sortResult = BubbleSort<int>.Sort(countOfOneList);

                Assert.IsTrue(sortResult, "Sort Result");
                Assert.IsNotNull(countOfOneList);
                Assert.AreEqual(1, countOfOneList.Count);
                Assert.AreEqual(1, countOfOneList[0]);
            }
            [Test]
            public void ValuePassed_RandomizedList()
            {
                List<int> sortedList = GenericSort_TestClass.GetSortedList(0, 100);
                List<int> randomizedList = CollectionManipulation.CopyGenericList<int>(sortedList);
                randomizedList = CollectionManipulation.RandomizeGenericList<int>(randomizedList);

                CollectionAssert.AreEquivalent(sortedList, randomizedList, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedList, randomizedList, "Are Not Equal");

                bool sortResult = BubbleSort<int>.Sort(randomizedList);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedList, randomizedList, "Are Equal");
            }
            [Test]
            public void ValuePassed_ListWithDuplicateValues()
            {
                List<int> sortedListWithDuplicates = GenericSort_TestClass.GetSortedListWithDuplicates(1, 20, 5);
                List<int> randomizedListWithDuplicates = CollectionManipulation.CopyGenericList<int>(sortedListWithDuplicates);
                randomizedListWithDuplicates = CollectionManipulation.RandomizeGenericList<int>(randomizedListWithDuplicates);

                CollectionAssert.AreEquivalent(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Not Equal");

                bool sortResult = BubbleSort<int>.Sort(randomizedListWithDuplicates);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equal");
            }
        }

        [TestFixture]
        public class InsertionSort_ValuesPassed
        {
            [Test]
            public void ValuePassed_Null()
            {
                List<int> testList = null;
                bool sortResult = InsertionSort<int>.Sort(testList);

                Assert.IsFalse(sortResult, "Sort Result");
            }
            [Test]
            public void ValuePassed_Empty()
            {
                List<int> emptyList = new List<int>();

                bool sortResult = InsertionSort<int>.Sort(emptyList);

                Assert.IsFalse(sortResult, "Sort Result");
                Assert.IsNotNull(emptyList);
                Assert.AreEqual(0, emptyList.Count);
            }
            [Test]
            public void ValuePassed_CountOfOne()
            {
                List<int> countOfOneList = new List<int>();
                countOfOneList.Add(1);

                bool sortResult = InsertionSort<int>.Sort(countOfOneList);

                Assert.IsTrue(sortResult, "Sort Result");
                Assert.IsNotNull(countOfOneList);
                Assert.AreEqual(1, countOfOneList.Count);
                Assert.AreEqual(1, countOfOneList[0]);
            }
            [Test]
            public void ValuePassed_RandomizedList()
            {
                List<int> sortedList = GenericSort_TestClass.GetSortedList(0, 100);
                List<int> randomizedList = CollectionManipulation.CopyGenericList<int>(sortedList);
                randomizedList = CollectionManipulation.RandomizeGenericList<int>(randomizedList);

                CollectionAssert.AreEquivalent(sortedList, randomizedList, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedList, randomizedList, "Are Not Equal");

                bool sortResult = InsertionSort<int>.Sort(randomizedList);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedList, randomizedList, "Are Equal");
            }
            [Test]
            public void ValuePassed_ListWithDuplicateValues()
            {
                List<int> sortedListWithDuplicates = GenericSort_TestClass.GetSortedListWithDuplicates(1, 20, 5);
                List<int> randomizedListWithDuplicates = CollectionManipulation.CopyGenericList<int>(sortedListWithDuplicates);
                randomizedListWithDuplicates = CollectionManipulation.RandomizeGenericList<int>(randomizedListWithDuplicates);

                CollectionAssert.AreEquivalent(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Not Equal");

                bool sortResult = InsertionSort<int>.Sort(randomizedListWithDuplicates);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equal");
            }
        }

        [TestFixture]
        public class SelectionSort_ValuesPassed
        {
            [Test]
            public void ValuePassed_Null()
            {
                List<int> testList = null;
                bool sortResult = SelectionSort<int>.Sort(testList);

                Assert.IsFalse(sortResult, "Sort Result");
            }
            [Test]
            public void ValuePassed_Empty()
            {
                List<int> emptyList = new List<int>();

                bool sortResult = SelectionSort<int>.Sort(emptyList);

                Assert.IsFalse(sortResult, "Sort Result");
                Assert.IsNotNull(emptyList);
                Assert.AreEqual(0, emptyList.Count);
            }
            [Test]
            public void ValuePassed_CountOfOne()
            {
                List<int> countOfOneList = new List<int>();
                countOfOneList.Add(1);

                bool sortResult = SelectionSort<int>.Sort(countOfOneList);

                Assert.IsTrue(sortResult, "Sort Result");
                Assert.IsNotNull(countOfOneList);
                Assert.AreEqual(1, countOfOneList.Count);
                Assert.AreEqual(1, countOfOneList[0]);
            }
            [Test]
            public void ValuePassed_RandomizedList()
            {
                List<int> sortedList = GenericSort_TestClass.GetSortedList(0, 100);
                List<int> randomizedList = CollectionManipulation.CopyGenericList<int>(sortedList);
                randomizedList = CollectionManipulation.RandomizeGenericList<int>(randomizedList);

                CollectionAssert.AreEquivalent(sortedList, randomizedList, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedList, randomizedList, "Are Not Equal");

                bool sortResult = SelectionSort<int>.Sort(randomizedList);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedList, randomizedList, "Are Equal");
            }
            [Test]
            public void ValuePassed_ListWithDuplicateValues()
            {
                List<int> sortedListWithDuplicates = GenericSort_TestClass.GetSortedListWithDuplicates(1, 20, 5);
                List<int> randomizedListWithDuplicates = CollectionManipulation.CopyGenericList<int>(sortedListWithDuplicates);
                randomizedListWithDuplicates = CollectionManipulation.RandomizeGenericList<int>(randomizedListWithDuplicates);

                CollectionAssert.AreEquivalent(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Not Equal");

                bool sortResult = SelectionSort<int>.Sort(randomizedListWithDuplicates);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equal");
            }
        }

        [TestFixture]
        public class MergeSort_ValuesPassed
        {
            [Test]
            public void ValuePassed_Null()
            {
                List<int> testList = null;
                List<int> resultList = MergeSort<int>.Sort(testList);
                Assert.IsNull(resultList, "Sort Result");
            }
            [Test]
            public void ValuePassed_Empty()
            {
                List<int> emptyList = new List<int>();

                List<int> resultList = MergeSort<int>.Sort(emptyList);

                Assert.IsNull(resultList, "Sort Result");
            }
            [Test]
            public void ValuePassed_CountOfOne()
            {
                List<int> countOfOneList = new List<int>();
                countOfOneList.Add(1);

                List<int> resultList = MergeSort<int>.Sort(countOfOneList);

                Assert.IsNotNull(resultList, "Sort Result");
                Assert.AreEqual(1, resultList.Count);
                CollectionAssert.AreEqual(resultList, countOfOneList);
            }
            [Test]
            public void ValuePassed_RandomizedList()
            {
                List<int> sortedList = GenericSort_TestClass.GetSortedList(0, 100);
                List<int> randomizedList = CollectionManipulation.CopyGenericList<int>(sortedList);
                randomizedList = CollectionManipulation.RandomizeGenericList<int>(randomizedList);

                CollectionAssert.AreEquivalent(sortedList, randomizedList, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedList, randomizedList, "Are Not Equal");

                List<int> resultList = MergeSort<int>.Sort(randomizedList);

                Assert.IsNotNull(resultList);
                CollectionAssert.AreEqual(resultList, sortedList, "Are Equal");
            }
            [Test]
            public void ValuePassed_ListWithDuplicateValues()
            {
                List<int> sortedListWithDuplicates = GenericSort_TestClass.GetSortedListWithDuplicates(1, 20, 5);
                List<int> randomizedListWithDuplicates = CollectionManipulation.CopyGenericList<int>(sortedListWithDuplicates);
                randomizedListWithDuplicates = CollectionManipulation.RandomizeGenericList<int>(randomizedListWithDuplicates);

                CollectionAssert.AreEquivalent(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Not Equal");

                List<int> resultList = MergeSort<int>.Sort(randomizedListWithDuplicates);

                Assert.IsNotNull(resultList);
                CollectionAssert.AreEqual(resultList, sortedListWithDuplicates, "Are Equal");
            }
        }

        [TestFixture]
        public class ShellSort_ValuesPassed
        {
            [Test]
            public void ValuePassed_Null()
            {
                List<int> testList = null;
                bool sortResult = ShellSort<int>.Sort(testList);

                Assert.IsFalse(sortResult, "Sort Result");
            }
            [Test]
            public void ValuePassed_Empty()
            {
                List<int> emptyList = new List<int>();

                bool sortResult = ShellSort<int>.Sort(emptyList);

                Assert.IsFalse(sortResult, "Sort Result");
                Assert.IsNotNull(emptyList);
                Assert.AreEqual(0, emptyList.Count);
            }
            [Test]
            public void ValuePassed_CountOfOne()
            {
                List<int> countOfOneList = new List<int>();
                countOfOneList.Add(1);

                bool sortResult = ShellSort<int>.Sort(countOfOneList);

                Assert.IsTrue(sortResult, "Sort Result");
                Assert.IsNotNull(countOfOneList);
                Assert.AreEqual(1, countOfOneList.Count);
                Assert.AreEqual(1, countOfOneList[0]);
            }
            [Test]
            public void ValuePassed_RandomizedList()
            {
                List<int> sortedList = GenericSort_TestClass.GetSortedList(0, 100);
                List<int> randomizedList = CollectionManipulation.CopyGenericList<int>(sortedList);
                randomizedList = CollectionManipulation.RandomizeGenericList<int>(randomizedList);

                CollectionAssert.AreEquivalent(sortedList, randomizedList, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedList, randomizedList, "Are Not Equal");

                bool sortResult = ShellSort<int>.Sort(randomizedList);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedList, randomizedList, "Are Equal");
            }
            [Test]
            public void ValuePassed_ListWithDuplicateValues()
            {
                List<int> sortedListWithDuplicates = GenericSort_TestClass.GetSortedListWithDuplicates(1, 20, 5);
                List<int> randomizedListWithDuplicates = CollectionManipulation.CopyGenericList<int>(sortedListWithDuplicates);
                randomizedListWithDuplicates = CollectionManipulation.RandomizeGenericList<int>(randomizedListWithDuplicates);

                CollectionAssert.AreEquivalent(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Not Equal");

                bool sortResult = ShellSort<int>.Sort(randomizedListWithDuplicates);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equal");
            }
        }

        [TestFixture]
        public class QuickSort_ValuesPassed
        {
            [Test]
            public void ValuePassed_Null()
            {
                List<int> testList = null;
                bool sortResult = QuickSort<int>.Sort(testList);

                Assert.IsFalse(sortResult, "Sort Result");
            }
            [Test]
            public void ValuePassed_Empty()
            {
                List<int> emptyList = new List<int>();

                bool sortResult = QuickSort<int>.Sort(emptyList);

                Assert.IsFalse(sortResult, "Sort Result");
                Assert.IsNotNull(emptyList);
                Assert.AreEqual(0, emptyList.Count);
            }
            [Test]
            public void ValuePassed_CountOfOne()
            {
                List<int> countOfOneList = new List<int>();
                countOfOneList.Add(1);

                bool sortResult = QuickSort<int>.Sort(countOfOneList);

                Assert.IsTrue(sortResult, "Sort Result");
                Assert.IsNotNull(countOfOneList);
                Assert.AreEqual(1, countOfOneList.Count);
                Assert.AreEqual(1, countOfOneList[0]);
            }
            [Test]
            public void ValuePassed_RandomizedList()
            {
                List<int> sortedList = GenericSort_TestClass.GetSortedList(0, 100);
                List<int> randomizedList = CollectionManipulation.CopyGenericList<int>(sortedList);
                randomizedList = CollectionManipulation.RandomizeGenericList<int>(randomizedList);

                CollectionAssert.AreEquivalent(sortedList, randomizedList, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedList, randomizedList, "Are Not Equal");

                bool sortResult = QuickSort<int>.Sort(randomizedList);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedList, randomizedList, "Are Equal");
            }
            [Test]
            public void ValuePassed_ListWithDuplicateValues()
            {
                List<int> sortedListWithDuplicates = GenericSort_TestClass.GetSortedListWithDuplicates(1, 20, 5);
                List<int> randomizedListWithDuplicates = CollectionManipulation.CopyGenericList<int>(sortedListWithDuplicates);
                randomizedListWithDuplicates = CollectionManipulation.RandomizeGenericList<int>(randomizedListWithDuplicates);

                CollectionAssert.AreEquivalent(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equivalent");
                CollectionAssert.AreNotEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Not Equal");

                bool sortResult = QuickSort<int>.Sort(randomizedListWithDuplicates);

                Assert.IsTrue(sortResult, "Sort Result");
                CollectionAssert.AreEqual(sortedListWithDuplicates, randomizedListWithDuplicates, "Are Equal");
            }
        }

        #endregion
    }
}
