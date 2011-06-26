// <copyright file="DerivedParameters_UnitTests.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.IO;
using GoatDogGames;
using NUnit.Framework;

// TODO : Write TestSetup and TestTearDown Classes

namespace GoatDogGames_UnitTests
{
    namespace DerivedParametersTests
    {
        #region DirInfoParameter
        
        [TestFixture]
        public class DirInfoParameter_InitialState
        {
            [Test]
            public void DirInfoParameter_Type()
            {
                string expectedResult = typeof(DirectoryInfo).ToString();
                DirInfoParamter testParameter = new DirInfoParamter();
                Assert.AreEqual(expectedResult, testParameter.Type.ToString());
            }
            [Test]
            public void DirInfoParameter_Text()
            {
                string expectedResult = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DirInfoParamter testParameter = new DirInfoParamter();
                Assert.AreEqual(expectedResult, testParameter.Text);
            }
            [Test]
            public void DirInfoParameter_DirectoryInfo()
            {
                string expectedResult = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DirInfoParamter testParameter = new DirInfoParamter();
                Assert.IsNotNull(testParameter.DirectoryIndicated);
                Assert.AreEqual(expectedResult, testParameter.DirectoryIndicated.FullName);
            }
        }
        [TestFixture]
        public class DirInfoParameter_SetText
        {
            [Test]
            public void SetText_Null()
            {
                string expectedResult = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DirInfoParamter testParameter = new DirInfoParamter();
                Assert.AreEqual(expectedResult, testParameter.DirectoryIndicated.FullName);
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = null;
                Assert.IsTrue(testParameter.HasErrors);
                Assert.AreEqual(expectedResult, testParameter.DirectoryIndicated.FullName);
            }
            [Test]
            public void SetText_Empty()
            {
                string expectedResult = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DirInfoParamter testParameter = new DirInfoParamter();
                Assert.AreEqual(expectedResult, testParameter.DirectoryIndicated.FullName);
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = string.Empty;
                Assert.IsTrue(testParameter.HasErrors);
                Assert.AreEqual(expectedResult, testParameter.DirectoryIndicated.FullName);
            }
            [Test]
            public void SetText_DoesntExist()
            {
                string testPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\FOO";
                string expectedResult = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DirInfoParamter testParameter = new DirInfoParamter();
                Assert.AreEqual(expectedResult, testParameter.DirectoryIndicated.FullName);
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testPath;
                Assert.IsNotNull(testParameter.DirectoryIndicated);
                Assert.AreEqual(expectedResult, testParameter.DirectoryIndicated.FullName);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void SetText_NotADirectory()
            {
                string testPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\DirInfoParameter Test Folder\a";
                string expectedResult = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DirInfoParamter testParameter = new DirInfoParamter();
                Assert.AreEqual(expectedResult, testParameter.DirectoryIndicated.FullName);
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testPath;
                Assert.IsNotNull(testParameter.DirectoryIndicated);
                Assert.AreEqual(expectedResult, testParameter.DirectoryIndicated.FullName);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void SetTest_ValidDirectory()
            {
                string expectedResult_01 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string expectedResult_02 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\DirInfoParameter Test Folder";
                DirInfoParamter testParameter = new DirInfoParamter();
                Assert.AreEqual(expectedResult_01, testParameter.DirectoryIndicated.FullName, testParameter.Text);
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = expectedResult_02;
                Assert.IsFalse(testParameter.HasErrors);
                Assert.AreEqual(expectedResult_02, testParameter.DirectoryIndicated.FullName, testParameter.Text);
            }
        }
        
        #endregion
        #region FileInfoParameter

        [TestFixture]
        public class FileInfoParameter_InitialState
        {
            [Test]
            public void FileInfoParameter_Type()
            {
                string expectedResult = typeof(FileInfo).ToString();
                FileInfoParameter testParameter = new FileInfoParameter();
                Assert.AreEqual(expectedResult, testParameter.Type.ToString());
            }
            [Test]
            public void FileInfoParameter_Text()
            {
                string expectedResult = string.Empty;
                FileInfoParameter testParameter = new FileInfoParameter();
                Assert.AreEqual(expectedResult, testParameter.Text);
            }
            [Test]
            public void FileInfoParameter_FileIndicated()
            {
                FileInfoParameter testParameter = new FileInfoParameter();
                Assert.IsFalse(testParameter.HasErrors);
                FileInfo actualResult = testParameter.FileIndicated;
                Assert.IsNull(actualResult);
                Assert.IsTrue(testParameter.HasErrors);
            }
        }
        [TestFixture]
        public class FileInfoParameter_SetText
        {
            [Test]
            public void FileInfoParameter_Null()
            {
                string testPath = null;
                FileInfoParameter testParameter = new FileInfoParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testPath;
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void FileInfoParameter_Empty()
            {
                string testPath = string.Empty;
                FileInfoParameter testParameter = new FileInfoParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testPath;
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void FileInfoParameter_DoesntExist()
            {
                string testPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    + @"\FooFilers.txt";
                FileInfoParameter testParameter = new FileInfoParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testPath;
                FileInfo actualResult = testParameter.FileIndicated;
                Assert.IsNull(actualResult);
                Assert.IsTrue(testParameter.HasErrors); 
            }
            [Test]
            public void FileInfoParameter_NotAFile()
            {
                string testPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                FileInfoParameter testParameter = new FileInfoParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testPath;
                FileInfo actualResult = testParameter.FileIndicated;
                Assert.IsNull(actualResult);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void FileInfoParameter_Valid()
            {
                string testPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    + @"\TestFile.txt";
                FileInfoParameter testParameter = new FileInfoParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testPath;
                FileInfo actualResult = testParameter.FileIndicated;
                Assert.IsNotNull(actualResult);
                Assert.AreEqual(testPath, actualResult.FullName);             
            }
        }
        
        #endregion
        #region IntegerParameter

        [TestFixture]
        public class IntegerParameter_InitialState
        {
            [Test]
            public void IntegerParameter_Type()
            {
                IntegerParameter testParameter = new IntegerParameter();
                string expectedResult = typeof(Int32).ToString();
                Assert.AreEqual(expectedResult,testParameter.Type.ToString());
            }
            [Test]
            public void IntegerParameter_Text()
            {
                IntegerParameter testParameter = new IntegerParameter();
                string expectedResult = typeof(Int32).ToString();
                Assert.AreEqual(expectedResult, testParameter.Type.ToString());
            }
            [Test]
            public void IntegerParameter_Value()
            {
                IntegerParameter testParameter = new IntegerParameter();
                int expectedResult = 0;
                Assert.AreEqual(expectedResult, testParameter.Value);
            }
        }
        [TestFixture]
        public class IntegerParameter_SetText
        {
            [Test]
            public void IntegerParameter_Null()
            {
                string testValue = null;
                int expectedResult = 0;
                IntegerParameter testParameter = new IntegerParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testValue;
                Assert.IsTrue(testParameter.HasErrors);
                Assert.AreEqual(expectedResult, testParameter.Value);
            }
            [Test]
            public void IntegerParameter_Empty()
            {
                string testValue = string.Empty;
                int expectedResult = 0; 
                IntegerParameter testParameter = new IntegerParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testValue; 
                Assert.IsTrue(testParameter.HasErrors);
                Assert.AreEqual(expectedResult, testParameter.Value);
            }
            [Test]
            public void IntegerParameter_NotAnInteger()
            {
                string testValue = "FOO";
                int expectedResult = 0; 
                IntegerParameter testParameter = new IntegerParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testValue;
                Assert.AreEqual(expectedResult, testParameter.Value);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void IntegerParameter_LessThanMinInt32()
            {
                string testValue = "1" + Int32.MinValue.ToString();
                int expectedResult = 0;
                IntegerParameter testParameter = new IntegerParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testValue;
                Assert.AreEqual(expectedResult, testParameter.Value);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void IntegerParameter_MinInt32()
            {
                string testValue = Int32.MinValue.ToString();
                int expectedResult = Int32.MinValue;
                IntegerParameter testParameter = new IntegerParameter();
                testParameter.Text = testValue;
                Assert.AreEqual(expectedResult, testParameter.Value); 
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void IntegerParameter_MaxInt32()
            {
                string testValue = Int32.MaxValue.ToString();
                int expectedResult = Int32.MaxValue;
                IntegerParameter testParameter = new IntegerParameter();
                testParameter.Text = testValue;
                Assert.AreEqual(expectedResult, testParameter.Value); 
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void IntegerParameter_GreaterThanMaxInt32()
            {
                string testValue = "1" + Int32.MaxValue.ToString();
                int expectedResult = 0;
                IntegerParameter testParameter = new IntegerParameter();
                Assert.IsFalse(testParameter.HasErrors);
                testParameter.Text = testValue;
                Assert.AreEqual(expectedResult, testParameter.Value); 
                Assert.IsTrue(testParameter.HasErrors);
            }
        }

        #endregion
        #region DoubleParameter

        [TestFixture]
        public class DoubleParameter_InitialState
        {

        }
        [TestFixture]
        public class DoubleParameter_SetText
        {

        }

        #endregion
        #region BoolParameter

        [TestFixture]
        public class BoolParameter_InitialState
        {
            [Test]
            public void Bool_Parameter_Type()
            {
                string expectedResult = typeof(Boolean).ToString();
                BoolParameter testParameter = new BoolParameter();
                Assert.AreEqual(expectedResult, testParameter.Type.ToString());
            }
            [Test]
            public void BoolParameter_Text()
            {
                string expectedResult = "FALSE";
                BoolParameter testParameter = new BoolParameter();
                Assert.AreEqual(expectedResult, testParameter.Text.ToUpper());
            }
            [Test]
            public void BoolParameter_Value()
            {
                BoolParameter testParameter = new BoolParameter();
                Assert.IsFalse(testParameter.Value);
            }
        }
        [TestFixture]
        public class BoolParameter_SetText
        {
            [Test]
            public void BoolParameter_Null()
            {
                string testValue = null;
                BoolParameter testParameter = new BoolParameter();
                testParameter.Text = testValue;
                Assert.IsTrue(testParameter.HasErrors);
                Assert.IsFalse(testParameter.Value);
            }
            [Test]
            public void BoolParameter_Empty()
            {
                string testValue = string.Empty;
                BoolParameter testParameter = new BoolParameter();
                testParameter.Text = testValue;
                Assert.IsTrue(testParameter.HasErrors);
                Assert.IsFalse(testParameter.Value);
            }
            [Test]
            public void BoolParameter_FailedParse()
            {
                string testValue = "FOO";
                BoolParameter testParameter = new BoolParameter();
                testParameter.Text = testValue;
                Assert.IsFalse(testParameter.HasErrors);
                Assert.IsFalse(testParameter.Value);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void BoolParameter_FALSE()
            {
                string testValue = "FALSE";
                BoolParameter testParameter = new BoolParameter();
                testParameter.Text = testValue; 
                Assert.IsFalse(testParameter.Value);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void BoolParameter_TRUE()
            {
                string testValue = "TRUE";
                BoolParameter testParameter = new BoolParameter();
                testParameter.Text = testValue; 
                Assert.IsTrue(testParameter.Value);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void BoolParameter_0()
            {
                string testValue = "0";
                BoolParameter testParameter = new BoolParameter();
                testParameter.Text = testValue; 
                Assert.IsFalse(testParameter.Value);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void BoolParameter_1()
            {
                string testValue = "1";
                BoolParameter testParameter = new BoolParameter();
                testParameter.Text = testValue; 
                Assert.IsTrue(testParameter.Value);
                Assert.IsFalse(testParameter.HasErrors);
            }
        }

        #endregion
        #region TimeSpanParameter

        [TestFixture]
        public class TimeSpanParameter_InitialState
        {

        }
        [TestFixture]
        public class TimeSpanParameter_SetText
        {

        }

        #endregion
        #region DateTimeParameter

        [TestFixture]
        public class DateTimeParameter_InitialState
        {

        }
        [TestFixture]
        public class DateTimeParameter_SetText
        {

        }

        #endregion
    }
}
