// <copyright file="ParameterBase_UnitTests.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using GoatDogGames;
using NUnit.Framework;

namespace GoatDogGames_UnitTests
{
    namespace ParameterBaseTests
    {
        [TestFixture]
        public class ParameterTypeEnumeration
        {
            [Test]
            public void ParameterType_CheckForExpectedNames()
            {
                string[] expectedNames = new string[] { "None", "Bool", "DateTime", "Directory",
                    "Double", "File", "Integer", "String" };
                string[] actualNames = Enum.GetNames(typeof(ParameterType));
                foreach (string item in expectedNames)
                {
                    Assert.Contains(item, actualNames);
                }
            }
        }

        [TestFixture]
        public class ParameterBase_AfterIntialize
        {
            [Test]
            public void ParameterBase_Type()
            {
                ParameterBase testParameter = new ParameterBase();
                Assert.AreEqual(typeof(ParameterBase).ToString(), testParameter.Type.ToString());
            }
            [Test]
            public void ParameterBase_Errors()
            {
                ParameterBase testParameter = new ParameterBase();
                Assert.IsNotNull(testParameter.Errors);
            }
            [Test]
            public void ParameterBase_HasErrors()
            {
                ParameterBase testParameter = new ParameterBase();
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void ParameterBase_Name()
            {
                ParameterBase testParameter = new ParameterBase();
                Assert.AreEqual(string.Empty, testParameter.Name);
            }
            [Test]
            public void ParameterBase_Text()
            {
                ParameterBase testParameter = new ParameterBase();
                Assert.AreEqual(string.Empty, testParameter.Text);
            }
        }

        [TestFixture]
        public class ParameterBase_NameSet
        {
            [Test]
            public void ParameterBase_FOO()
            {
                string testName = "FOO";
                ParameterBase testParameter = new ParameterBase();
                testParameter.Name = testName;
                Assert.AreEqual(testName, testParameter.Name);
            }
            [Test]
            public void ParameterBase_Empty()
            {
                string testName_01 = "FOO";
                string testName_02 = string.Empty;
                ParameterBase testParameter = new ParameterBase();
                testParameter.Name = testName_01;
                Assert.AreEqual(testName_01, testParameter.Name);
                testParameter.Name = testName_02;
                Assert.AreEqual(testName_02, testParameter.Name);
            }
            [Test]
            public void ParameterBase_Null()
            {
                string testName_01 = "FOO";
                string testName_02 = null;
                ParameterBase testParameter = new ParameterBase();
                testParameter.Name = testName_01;
                Assert.AreEqual(testName_01, testParameter.Name);
                testParameter.Name = testName_02;
                Assert.AreEqual(testName_01, testParameter.Name);
                Assert.IsTrue(testParameter.HasErrors);
            }
        }

        [TestFixture]
        public class ParameterBase_TextSet
        {
            [Test]
            public void ParameterBase_FOO()
            {
                string testName = "FOO";
                ParameterBase testParameter = new ParameterBase();
                testParameter.Text = testName;
                Assert.AreEqual(testName, testParameter.Text);
            }
            [Test]
            public void ParameterBase_Empty()
            {
                string testName_01 = "FOO";
                string testName_02 = string.Empty;
                ParameterBase testParameter = new ParameterBase();
                testParameter.Text = testName_01;
                Assert.AreEqual(testName_01, testParameter.Text);
                testParameter.Text = testName_02;
                Assert.AreEqual(testName_02, testParameter.Text);
            }
            [Test]
            public void ParameterBase_Null()
            {
                string testName_01 = "FOO";
                string testName_02 = null;
                ParameterBase testParameter = new ParameterBase();
                testParameter.Text = testName_01;
                Assert.AreEqual(testName_01, testParameter.Text);
                testParameter.Text = testName_02;
                Assert.AreEqual(testName_01, testParameter.Text);
                Assert.IsTrue(testParameter.HasErrors);
            }
        }
    }
}
