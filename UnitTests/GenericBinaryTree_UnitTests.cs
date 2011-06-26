// <copyright file="GenericBinaryTree_UnitTests.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;
using System.Text;
using GoatDogGames;
using NUnit.Framework;

// TODO : Add regions to classes

namespace GoatDogGames_UnitTests
{
    namespace GenericBinaryTree
    {
        #region Helper Clases

        public class TestObject_Integer : IComparable
        {
            public int Value;
            public TestObject_Integer(int valuePassed)
            {
                Value = valuePassed;
            }
            public int CompareTo(object objectToCompare)
            {
                TestObject_Integer tempTestObject_Integer = (TestObject_Integer)objectToCompare;
                int valueToCompare = tempTestObject_Integer.Value;

                if (Value == valueToCompare)
                {
                    return 0;
                }
                else if (Value < valueToCompare)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            public override string ToString()
            {
                return Value.ToString().PadLeft(12, '0');
            }
        }

        public class TestObject_TraversalMethodSource
        {
            private StringBuilder traverseText;
            public TestObject_TraversalMethodSource()
            {
                traverseText = new StringBuilder();
            }
            public void HandleNode(TestObject_Integer nodeToHandle)
            {
                if (nodeToHandle != null)
                {
                    traverseText.Append(nodeToHandle.Value.ToString());
                }
            }
            public void Clear()
            {
                traverseText.Length = 0;
            }
            public override string ToString()
            {
                return traverseText.ToString();
            }
        }

        #endregion
        #region Unit Tests

        [TestFixture]
        public class GenericBinaryTree_InitialState
        {
            [Test]
            public void InitialState_Type()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                string expectedValue = typeof(TestObject_Integer).ToString();
                Assert.AreEqual(expectedValue, testTree.Type.ToString());
            }
            [Test]
            public void InitialState_IsEmpty()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                Assert.IsTrue(testTree.IsEmpty);
            }
            [Test]
            public void InitialState_ParentNode()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                Assert.IsNull(testTree.ParentNode);
            }
            [Test]
            public void InitialState_CurrentNode()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                Assert.IsNull(testTree.CurrentNode);
            }
            [Test]
            public void InitialState_LeftGrandChild()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                Assert.IsNull(testTree.LeftGrandChild);
            }
            [Test]
            public void InitialState_RightGrandChild()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                Assert.IsNull(testTree.LeftGrandChild);
            }
            [Test]
            public void InitialState_RootNode()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                Assert.IsNull(testTree.RootNode);
            }
            [Test]
            public void InitialState_Errors()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                Assert.IsNotNull(testTree.Errors);
            }
            [Test]
            public void InitialState_HasErrors()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                Assert.IsFalse(testTree.HasErrors);
            }
        }

        [TestFixture]
        public class GenericBinaryTree_Add
        {
            [Test]
            public void Add_null()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                bool addResult = testTree.Add(null);

                Assert.IsTrue(testTree.IsEmpty);
                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);
            }
            [Test]
            public void Add_4()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                bool addResult = testTree.Add(new TestObject_Integer(4));

                Assert.IsTrue(addResult);
                Assert.IsNull(testTree.ParentNode);
                Assert.IsNotNull(testTree.CurrentNode);
                Assert.AreEqual(4, testTree.CurrentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_2()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(2));

                Assert.IsTrue(addResult);
                Assert.IsNotNull(testTree.ParentNode);
                Assert.AreEqual(4, testTree.ParentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNotNull(testTree.CurrentNode);
                Assert.AreEqual(2, testTree.CurrentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_6()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(6));

                Assert.IsTrue(addResult);
                Assert.IsNotNull(testTree.ParentNode);
                Assert.AreEqual(4, testTree.ParentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNotNull(testTree.CurrentNode);
                Assert.AreEqual(6, testTree.CurrentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_6_5()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(6));
                addResult = testTree.Add(new TestObject_Integer(5));

                Assert.IsTrue(addResult);
                Assert.IsNotNull(testTree.ParentNode);
                Assert.AreEqual(6, testTree.ParentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNotNull(testTree.CurrentNode);
                Assert.AreEqual(5, testTree.CurrentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_6_7()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(6));
                addResult = testTree.Add(new TestObject_Integer(7));

                Assert.IsTrue(addResult);
                Assert.IsNotNull(testTree.ParentNode);
                Assert.AreEqual(6, testTree.ParentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNotNull(testTree.CurrentNode);
                Assert.AreEqual(7, testTree.CurrentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_2_1()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(2));
                addResult = testTree.Add(new TestObject_Integer(1));

                Assert.IsTrue(addResult);
                Assert.IsNotNull(testTree.ParentNode);
                Assert.AreEqual(2, testTree.ParentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNotNull(testTree.CurrentNode);
                Assert.AreEqual(1, testTree.CurrentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_2_3()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(2));
                addResult = testTree.Add(new TestObject_Integer(3));

                Assert.IsTrue(addResult);
                Assert.IsNotNull(testTree.ParentNode);
                Assert.AreEqual(2, testTree.ParentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNotNull(testTree.CurrentNode);
                Assert.AreEqual(3, testTree.CurrentNode.Item.Value, testTree.GetNodeComposition());
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
        }

        [TestFixture]
        public class GenericBinaryTree_AddDuplicate
        {
            [Test]
            public void Add_4_4()
            {
                bool addResult = false;

                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();

                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(4));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.IsNull(testTree.ParentNode);
                Assert.AreEqual(4, testTree.CurrentNode.Item.Value);
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_2_2()
            {
                bool addResult = false;

                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();

                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(2));
                addResult = testTree.Add(new TestObject_Integer(2));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.AreEqual(4, testTree.ParentNode.Item.Value);
                Assert.AreEqual(2, testTree.CurrentNode.Item.Value);
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);

            }
            [Test]
            public void Add_4_6_6()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(6));
                addResult = testTree.Add(new TestObject_Integer(6));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.AreEqual(4, testTree.ParentNode.Item.Value);
                Assert.AreEqual(6, testTree.CurrentNode.Item.Value);
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_6_5_5()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(6));
                addResult = testTree.Add(new TestObject_Integer(5));
                addResult = testTree.Add(new TestObject_Integer(5));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.AreEqual(6, testTree.ParentNode.Item.Value);
                Assert.AreEqual(5, testTree.CurrentNode.Item.Value);
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_6_7_7()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(6));
                addResult = testTree.Add(new TestObject_Integer(7));
                addResult = testTree.Add(new TestObject_Integer(7));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.AreEqual(6, testTree.ParentNode.Item.Value);
                Assert.AreEqual(7, testTree.CurrentNode.Item.Value);
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_2_1_1()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(2));
                addResult = testTree.Add(new TestObject_Integer(1));
                addResult = testTree.Add(new TestObject_Integer(1));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.AreEqual(2, testTree.ParentNode.Item.Value);
                Assert.AreEqual(1, testTree.CurrentNode.Item.Value);
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_2_3_3()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(2));
                addResult = testTree.Add(new TestObject_Integer(3));
                addResult = testTree.Add(new TestObject_Integer(3));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.AreEqual(2, testTree.ParentNode.Item.Value);
                Assert.AreEqual(3, testTree.CurrentNode.Item.Value);
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Add_4_2_6_4()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(2));
                addResult = testTree.Add(new TestObject_Integer(6));
                addResult = testTree.Add(new TestObject_Integer(4));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.IsNull(testTree.ParentNode);
                Assert.AreEqual(4, testTree.CurrentNode.Item.Value);
                Assert.AreEqual(2, testTree.LeftGrandChild.Item.Value);
                Assert.AreEqual(6, testTree.RightGrandChild.Item.Value);
            }
            [Test]
            public void Add_4_2_3_1_2()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(2));
                addResult = testTree.Add(new TestObject_Integer(3));
                addResult = testTree.Add(new TestObject_Integer(1));
                addResult = testTree.Add(new TestObject_Integer(2));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.AreEqual(4, testTree.ParentNode.Item.Value);
                Assert.AreEqual(2, testTree.CurrentNode.Item.Value);
                Assert.AreEqual(1, testTree.LeftGrandChild.Item.Value);
                Assert.AreEqual(3, testTree.RightGrandChild.Item.Value);
            }
            [Test]
            public void Add_4_6_5_7_6()
            {
                bool addResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                addResult = testTree.Add(new TestObject_Integer(4));
                addResult = testTree.Add(new TestObject_Integer(6));
                addResult = testTree.Add(new TestObject_Integer(5));
                addResult = testTree.Add(new TestObject_Integer(7));
                addResult = testTree.Add(new TestObject_Integer(6));

                Assert.IsFalse(addResult);
                Assert.IsTrue(testTree.HasErrors);

                Assert.AreEqual(4, testTree.ParentNode.Item.Value);
                Assert.AreEqual(6, testTree.CurrentNode.Item.Value);
                Assert.AreEqual(5, testTree.LeftGrandChild.Item.Value);
                Assert.AreEqual(7, testTree.RightGrandChild.Item.Value);
            }
        }

        [TestFixture]
        public class GenericBinaryTree_Delete
        {
            [Test]
            public void Delete_4()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Delete(new TestObject_Integer(4));

                Assert.IsFalse(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");
            }
            [Test]
            public void Add_4_Delete_null()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                bool deleteResult = true;
                testTree.Add(new TestObject_Integer(4));
                deleteResult = testTree.Delete(null);

                Assert.IsFalse(deleteResult, "DeleteResult");
                Assert.IsTrue(testTree.HasErrors, "HasErrors");

                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");
            }
            [Test]
            public void Add_4_Delete_6()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                bool deleteResult = true;
                testTree.Add(new TestObject_Integer(4));
                deleteResult = testTree.Delete(new TestObject_Integer(6));

                Assert.IsFalse(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");
            }
            [Test]
            public void Add_4_Delete_4()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                bool deleteResult = false;
                testTree.Add(new TestObject_Integer(4));
                deleteResult = testTree.Delete(new TestObject_Integer(4));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNull(testTree.RootNode, "RootNode");
                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");
            }
            [Test]
            public void Add_4_2_Delete_4()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                deleteResult = testTree.Delete(new TestObject_Integer(4));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.RootNode, "RootNode");
                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(2, testTree.RootNode.Item.Value, "RootNode");
                Assert.AreEqual(2, testTree.CurrentNode.Item.Value, "CurrentNode");
            }
            [Test]
            public void Add_4_2_Delete_2()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                deleteResult = testTree.Delete(new TestObject_Integer(2));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(4, testTree.ParentNode.Item.Value, "ParentNode");
            }
            [Test]
            public void Add_4_6_Delete_4()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(6));
                deleteResult = testTree.Delete(new TestObject_Integer(4));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.RootNode, "RootNode");
                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(6, testTree.RootNode.Item.Value, "RootNode");
                Assert.AreEqual(6, testTree.CurrentNode.Item.Value, "CurrentNode");
            }
            [Test]
            public void Add_4_6_Delete_6()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(6));
                deleteResult = testTree.Delete(new TestObject_Integer(6));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(4, testTree.ParentNode.Item.Value, "ParentNode");

            }
            [Test]
            public void Add_4_6_2_Delete_4()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(2));
                deleteResult = testTree.Delete(new TestObject_Integer(4));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.RootNode, "RootNode");
                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNotNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(6, testTree.RootNode.Item.Value, "RootNode");
                Assert.AreEqual(6, testTree.CurrentNode.Item.Value, "CurrentNode");
                Assert.AreEqual(2, testTree.LeftGrandChild.Item.Value, "RightGrandChild");
            }
            [Test]
            public void Add_4_6_5_7_Delete_6()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                deleteResult = testTree.Delete(new TestObject_Integer(6));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNotNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(4, testTree.ParentNode.Item.Value, "ParentNode");
                Assert.AreEqual(5, testTree.CurrentNode.Item.Value, "CurrentNode");
                Assert.AreEqual(7, testTree.RightGrandChild.Item.Value, "RightGrandChild");
            }
            [Test]
            public void Add_4_6_5_7_Delete_5()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                deleteResult = testTree.Delete(new TestObject_Integer(5));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(6, testTree.ParentNode.Item.Value, "ParentNode");
            }
            [Test]
            public void Add_4_6_5_7_Delete_7()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                deleteResult = testTree.Delete(new TestObject_Integer(5));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(6, testTree.ParentNode.Item.Value, "ParentNode");
            }
            [Test]
            public void Add_4_2_1_3_Delete_2()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                deleteResult = testTree.Delete(new TestObject_Integer(2));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNotNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(4, testTree.ParentNode.Item.Value, "ParentNode");
                Assert.AreEqual(3, testTree.CurrentNode.Item.Value, "CurrentNode");
                Assert.AreEqual(1, testTree.LeftGrandChild.Item.Value, "LeftGrandChild");
            }
            [Test]
            public void Add_4_2_1_3_Delete_3()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                deleteResult = testTree.Delete(new TestObject_Integer(3));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(2, testTree.ParentNode.Item.Value, "ParentNode");
            }
            [Test]
            public void Add_4_2_1_3_Delete_1()
            {
                bool deleteResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                deleteResult = testTree.Delete(new TestObject_Integer(1));

                Assert.IsTrue(deleteResult, "DeleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(2, testTree.ParentNode.Item.Value, "ParentNode");
            }
        }

        [TestFixture]
        public class GenericBinaryTree_Clear
        {
            [Test]
            public void Clear_IsEmpty()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();

                Assert.IsTrue(testTree.IsEmpty);
                Assert.IsFalse(testTree.HasErrors);
                Assert.IsNull(testTree.RootNode);
                Assert.IsNull(testTree.ParentNode);
                Assert.IsNull(testTree.CurrentNode);
                Assert.IsNull(testTree.LeftGrandChild);
                Assert.IsNull(testTree.RightGrandChild);
            }
            [Test]
            public void Clear_IsNotEmpty()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();

                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                testTree.Add(null);

                testTree.Clear();

                Assert.IsTrue(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");
                Assert.IsNull(testTree.RootNode, "RootNode");
                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");
            }
        }

        [TestFixture]
        public class GenericBinaryTree_AddAndDelete
        {
            [Test]
            public void GenericBinaryTree_AddRandomElementsAndDeleteThem()
            {
                TestObject_Integer[] testObjectArray_01 = new TestObject_Integer[100000];
                TestObject_Integer[] testObjectArray_02 = new TestObject_Integer[100000];

                for (int i = 0; i < testObjectArray_01.Length; i++)
                {
                    testObjectArray_01[i] = new TestObject_Integer(i);
                    testObjectArray_02[i] = new TestObject_Integer(i);
                }

                testObjectArray_01 = CollectionManipulation.RandomizeGenericArray<TestObject_Integer>(testObjectArray_01);
                System.Threading.Thread.Sleep(100);
                testObjectArray_02 = CollectionManipulation.RandomizeGenericArray<TestObject_Integer>(testObjectArray_02);

                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();

                bool addResult = true;
                for (int i = 0; i < testObjectArray_01.Length; i++)
                {
                    if (!testTree.Add(testObjectArray_01[i]))
                    {
                        addResult = false;
                    }
                }

                Assert.IsTrue(addResult, "addResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                bool deleteResult = true;
                for (int i = 0; i < testObjectArray_02.Length; i++)
                {
                    if (!testTree.Delete(testObjectArray_02[i]))
                    {
                        deleteResult = false;
                    }
                }

                Assert.IsTrue(deleteResult, "deleteResult");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");
                Assert.IsNull(testTree.RootNode, "RootNode");
            }
        }

        [TestFixture]
        public class GenericBinaryTree_Contains
        {
            [Test]
            public void Contains_null()
            {
                bool containsResult = true;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                containsResult = testTree.Contains(null);

                Assert.IsFalse(containsResult, "ContainsResult");
                Assert.IsTrue(testTree.IsEmpty, "IsEmpty");
                Assert.IsTrue(testTree.HasErrors, "HasErrors");

                Assert.IsNull(testTree.RootNode, "RootNode");
                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");
            }

            [Test]
            public void Contains_4_True()
            {
                bool containsResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(4));

                Assert.IsTrue(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNotNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNotNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(4, testTree.CurrentNode.Item.Value);
                Assert.AreEqual(2, testTree.LeftGrandChild.Item.Value);
                Assert.AreEqual(6, testTree.RightGrandChild.Item.Value);
            }
            [Test]
            public void Contains_2_True()
            {
                bool containsResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(2));

                Assert.IsTrue(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNotNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNotNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(4, testTree.ParentNode.Item.Value);
                Assert.AreEqual(2, testTree.CurrentNode.Item.Value);
                Assert.AreEqual(1, testTree.LeftGrandChild.Item.Value);
                Assert.AreEqual(3, testTree.RightGrandChild.Item.Value);
            }
            [Test]
            public void Contains_6_True()
            {
                bool containsResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(6));

                Assert.IsTrue(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNotNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNotNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(4, testTree.ParentNode.Item.Value);
                Assert.AreEqual(6, testTree.CurrentNode.Item.Value);
                Assert.AreEqual(5, testTree.LeftGrandChild.Item.Value);
                Assert.AreEqual(7, testTree.RightGrandChild.Item.Value);
            }
            [Test]
            public void Contains_1_True()
            {
                bool containsResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(1));

                Assert.IsTrue(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(2, testTree.ParentNode.Item.Value); 
                Assert.AreEqual(1, testTree.CurrentNode.Item.Value);
            }
            [Test]
            public void Contains_3_True()
            {
                bool containsResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(3));

                Assert.IsTrue(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(2, testTree.ParentNode.Item.Value);
                Assert.AreEqual(3, testTree.CurrentNode.Item.Value);
            }
            [Test]
            public void Contains_5_True()
            {
                bool containsResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(5));

                Assert.IsTrue(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(6, testTree.ParentNode.Item.Value);
                Assert.AreEqual(5, testTree.CurrentNode.Item.Value);
            }
            [Test]
            public void Contains_7_True()
            {
                bool containsResult = false;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(7));

                Assert.IsTrue(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNotNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(6, testTree.ParentNode.Item.Value);
                Assert.AreEqual(7, testTree.CurrentNode.Item.Value);
            }

            [Test]
            public void Contains_4_False()
            {
                bool containsResult = true;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                containsResult = testTree.Contains(new TestObject_Integer(4));

                Assert.IsFalse(containsResult, "ContainsResult");
                Assert.IsTrue(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNull(testTree.RootNode, "RootNode");
                Assert.IsNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");
            }
            [Test]
            public void Contains_2_False()
            {
                bool containsResult = true;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(2));

                Assert.IsFalse(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(4, testTree.ParentNode.Item.Value);
            }
            [Test]
            public void Contains_6_False()
            {
                bool containsResult = true;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                containsResult = testTree.Contains(new TestObject_Integer(6));

                Assert.IsFalse(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(4, testTree.ParentNode.Item.Value);
            }
            [Test]
            public void Contains_1_False()
            {
                bool containsResult = true;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(1));

                Assert.IsFalse(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(2, testTree.ParentNode.Item.Value);

            }
            [Test]
            public void Contains_3_False()
            {
                bool containsResult = true;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(3));

                Assert.IsFalse(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(2, testTree.ParentNode.Item.Value);
            }
            [Test]
            public void Contains_5_False()
            {
                bool containsResult = true;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(7));
                containsResult = testTree.Contains(new TestObject_Integer(5));

                Assert.IsFalse(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(6, testTree.ParentNode.Item.Value);
            }
            [Test]
            public void Contains_7_False()
            {
                bool containsResult = true;
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                containsResult = testTree.Contains(new TestObject_Integer(7));

                Assert.IsFalse(containsResult, "ContainsResult");
                Assert.IsFalse(testTree.IsEmpty, "IsEmpty");
                Assert.IsFalse(testTree.HasErrors, "HasErrors");

                Assert.IsNotNull(testTree.ParentNode, "ParentNode");
                Assert.IsNull(testTree.CurrentNode, "CurrentNode");
                Assert.IsNull(testTree.LeftGrandChild, "LeftGrandChild");
                Assert.IsNull(testTree.RightGrandChild, "RightGrandChild");

                Assert.AreEqual(6, testTree.ParentNode.Item.Value);
            }
        }

        [TestFixture]
        public class GenericBinaryTree_Traverse
        {
            [Test]
            public void Traverse_IsEmpty()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                TestObject_TraversalMethodSource testHandler = new TestObject_TraversalMethodSource();
                GenericBinaryTree<TestObject_Integer>.HandleItem testDelegate = testHandler.HandleNode;

                bool traverseResult = true;
                traverseResult = testTree.Traverse(TraverseType.None, testDelegate);

                Assert.IsFalse(traverseResult);
                Assert.IsFalse(testTree.HasErrors);
            }
            [Test]
            public void Traverse_null()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                TestObject_TraversalMethodSource testHandler = new TestObject_TraversalMethodSource();
                GenericBinaryTree<TestObject_Integer>.HandleItem testDelegate = testHandler.HandleNode;

                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));

                bool traverseResult = true;
                traverseResult = testTree.Traverse(TraverseType.InOrder, null);

                Assert.IsFalse(traverseResult);
                Assert.IsTrue(testTree.HasErrors);
            }
            [Test]
            public void Traverse_None()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                TestObject_TraversalMethodSource testHandler = new TestObject_TraversalMethodSource();
                GenericBinaryTree<TestObject_Integer>.HandleItem testDelegate = testHandler.HandleNode;

                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));

                bool traverseResult = true;
                traverseResult = testTree.Traverse(TraverseType.None, testDelegate);

                Assert.IsFalse(traverseResult);
                Assert.IsTrue(testTree.HasErrors); 
            }
            [Test]
            public void Traverse_InOrder()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                TestObject_TraversalMethodSource testHandler = new TestObject_TraversalMethodSource();
                GenericBinaryTree<TestObject_Integer>.HandleItem testDelegate = testHandler.HandleNode;

                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));

                bool traverseResult = false;
                traverseResult = testTree.Traverse(TraverseType.InOrder, testDelegate);
                string expectedResult = "1234567";

                Assert.IsTrue(traverseResult);
                Assert.IsFalse(testTree.HasErrors);
                Assert.AreEqual(expectedResult, testHandler.ToString());
            }
            [Test]
            public void Traverse_PreOrder()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                TestObject_TraversalMethodSource testHandler = new TestObject_TraversalMethodSource();
                GenericBinaryTree<TestObject_Integer>.HandleItem testDelegate = testHandler.HandleNode;

                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));

                bool traverseResult = false;
                traverseResult = testTree.Traverse(TraverseType.PreOrder, testDelegate);
                string expectedResult = "4213657";

                Assert.IsTrue(traverseResult);
                Assert.IsFalse(testTree.HasErrors); 
                Assert.AreEqual(expectedResult, testHandler.ToString());
            }
            [Test]
            public void Traverse_PostOrder()
            {
                GenericBinaryTree<TestObject_Integer> testTree = new GenericBinaryTree<TestObject_Integer>();
                TestObject_TraversalMethodSource testHandler = new TestObject_TraversalMethodSource();
                GenericBinaryTree<TestObject_Integer>.HandleItem testDelegate = testHandler.HandleNode;

                testTree.Add(new TestObject_Integer(4));
                testTree.Add(new TestObject_Integer(2));
                testTree.Add(new TestObject_Integer(6));
                testTree.Add(new TestObject_Integer(1));
                testTree.Add(new TestObject_Integer(3));
                testTree.Add(new TestObject_Integer(5));
                testTree.Add(new TestObject_Integer(7));

                bool traverseResult = false;
                traverseResult = testTree.Traverse(TraverseType.PostOrder, testDelegate);
                string expectedResult = "1325764";

                Assert.IsTrue(traverseResult);
                Assert.IsFalse(testTree.HasErrors); 
                Assert.AreEqual(expectedResult, testHandler.ToString());
            }
        }

        [TestFixture]
        public class GenericBinaryTree_TraverseTypeEnumeration
        {
            [Test]
            public void CheckTraverseTypes()
            {
                string[] actualNames = Enum.GetNames(typeof(TraverseType));
                string[] expectedNames = new string[] { "None", "InOrder", "PreOrder", "PostOrder" };
                foreach (string name in expectedNames)
                {
                    Assert.Contains(name, actualNames);
                }
            }
        }

        #endregion
    }
}
