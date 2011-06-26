// <copyright file="FrequencyParameter_UnitTests.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using GoatDogGames;
using NUnit.Framework;

// TODO : Refactor to handle multi-day straddle breakdown
// in FrequencyParameter_StringPassed.

namespace GoatDogGames_UnitTests
{
    namespace FrequencyParameterTests
    {
        [TestFixture]
        public class FrequencyParameter_NoArgPassed
        {
            [Test]
            public void FrequencyParameter_NoArgPassed_Type()
            {
                FrequencyParameter testParameter = new FrequencyParameter();
                Assert.AreEqual(typeof(FrequencyParameter).ToString(), testParameter.Type.ToString());
            }
            [Test]
            public void FrequencyParameter_NoArgPassed_Name()
            {
                FrequencyParameter testParameter = new FrequencyParameter();
                Assert.AreEqual(string.Empty, testParameter.Name);
            }
            [Test]
            public void FrequencyParameter_NoArgPassed_Text()
            {
                FrequencyParameter testParameter = new FrequencyParameter();
                Assert.AreEqual(string.Empty, testParameter.Text);
            }
            [Test]
            public void FrequencyParameter_NoArgPassed_Errors()
            {
                FrequencyParameter testParameter = new FrequencyParameter();
                Assert.IsNotNull(testParameter.Errors);
            }
            [Test]
            public void FrequencyParameter_NoArgPassed_HasErrors()
            {
                FrequencyParameter testParameter = new FrequencyParameter();
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_NoArgPassed_FromDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter();
                DateTime expectedResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                Assert.AreEqual(expectedResult, testParameter.FromDate);
            }
            [Test]
            public void FrequencyParameter_NoArgPassed_ThruDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter();
                DateTime expectedResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                expectedResult = expectedResult.Add(new TimeSpan(1, 0, 0, 0));
                Assert.AreEqual(expectedResult, testParameter.ThruDate);
            }
            [Test]
            public void FrequencyParameter_NoArgPassed_ReportingPeriod()
            {
                FrequencyParameter testParameter = new FrequencyParameter();
                DateTime fromResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                DateTime thruResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                thruResult = thruResult.Add(new TimeSpan(1, 0, 0, 0));
                TimeSpan expectedResult = thruResult.Subtract(fromResult);
                Assert.AreEqual(expectedResult, testParameter.ReportingPeriod);
            }
        }

        [TestFixture]
        public class FrequencyParameter_DateTimePassed
        {
            [Test]
            public void FrequencyParameter_NullPassed()
            {
                DateTime testFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                DateTime testThru = testFrom.Add(new TimeSpan(1, 0, 0, 0));

                FrequencyParameter testParameter = new FrequencyParameter(null);

                Assert.Greater(testParameter.Errors.Count, 0);
                Assert.AreEqual(testFrom, testParameter.FromDate);
                Assert.AreEqual(testThru, testParameter.ThruDate);
            }
        }

        [TestFixture]
        public class FrequencyParameter_StringPassed
        {
            // These tests will fail if execution time straddles
            // two days such that expectedResult isn't equal to DateTime.Now
            [Test]
            public void FrequencyParameter_NullPassed()
            {
                string testValue = null;
                DateTime expectedResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(testValue);
                Assert.IsTrue(testParameter.HasErrors);
                Assert.AreEqual(expectedResult, testParameter.FromDate);
            }
            [Test]
            public void FrequencyParameter_EmptyPassed()
            {
                string testValue = string.Empty;
                DateTime expectedResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(testValue);
                Assert.IsTrue(testParameter.HasErrors);
                Assert.AreEqual(expectedResult, testParameter.FromDate);
            }
            [Test]
            public void FrequencyParameter_InvalidPassed()
            {
                string testValue = "FOO";
                DateTime expectedResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(testValue);
                Assert.IsTrue(testParameter.HasErrors);
                Assert.AreEqual(expectedResult, testParameter.FromDate);
            }
            [Test]
            public void FrequencyParameter_ValidPassed()
            {
                DateTime expectedResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.Now.ToString());
                Assert.IsFalse(testParameter.HasErrors);
                Assert.AreEqual(expectedResult, testParameter.FromDate);
            }
        }

        [TestFixture]
        public class FrequencyParameter_SetText
        {
            [Test]
            public void FrequencyParameter_Default()
            {
                DateTime testDate = new DateTime(2010, 6, 15, 12, 12, 12);
                DateTime testFrom = new DateTime(2010, 6, 15, 0, 0, 0);
                DateTime testThru = new DateTime(2010, 6, 16, 0, 0, 0);

                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "FOO";

                Assert.AreEqual(testFrom, testParameter.FromDate);
                Assert.AreEqual(testThru, testParameter.ThruDate);
            }
            [Test]
            public void FrequencyParameter_CMTD()
            {
                DateTime testDate = new DateTime(2010, 6, 15, 12, 12, 12);
                DateTime testFrom = new DateTime(2010, 6, 1, 0, 0, 0);
                DateTime testThru = new DateTime(2010, 6, 16, 0, 0, 0);

                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "CMTD";

                Assert.AreEqual(testFrom, testParameter.FromDate);
                Assert.AreEqual(testThru, testParameter.ThruDate);
            }
            [Test]
            public void FrequencyParameter_PMTD()
            {
                DateTime testDate = new DateTime(2010, 6, 15, 12, 12, 12);
                DateTime testFrom = new DateTime(2010, 5, 1, 0, 0, 0);
                DateTime testThru = new DateTime(2010, 6, 16, 0, 0, 0);

                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "PMTD";

                Assert.AreEqual(testFrom, testParameter.FromDate);
                Assert.AreEqual(testThru, testParameter.ThruDate);
            }
            [Test]
            public void FrequencyParameter_MNTH()
            {
                DateTime testDate = new DateTime(2010, 6, 15, 12, 12, 12);
                DateTime testFrom = new DateTime(2010, 5, 1, 0, 0, 0);
                DateTime testThru = new DateTime(2010, 6, 1, 0, 0, 0);

                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "MNTH";

                Assert.AreEqual(testFrom, testParameter.FromDate);
                Assert.AreEqual(testThru, testParameter.ThruDate);
            }
            [Test]
            public void FrequencyParameter_YSTR()
            {
                DateTime testDate = new DateTime(2010, 6, 15, 12, 12, 12);
                DateTime testFrom = new DateTime(2010, 6, 14, 0, 0, 0);
                DateTime testThru = new DateTime(2010, 6, 15, 0, 0, 0);

                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "YSTR";

                Assert.AreEqual(testFrom, testParameter.FromDate);
                Assert.AreEqual(testThru, testParameter.ThruDate);
            }
            [Test]
            public void FrequencyParameter_CMTH()
            {
                DateTime testDate = new DateTime(2010, 6, 15, 12, 12, 12);
                DateTime testFrom = new DateTime(2010, 6, 1, 0, 0, 0);
                DateTime testThru = new DateTime(2010, 7, 1, 0, 0, 0);

                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "CMTH";

                Assert.AreEqual(testFrom, testParameter.FromDate);
                Assert.AreEqual(testThru, testParameter.ThruDate);
            }
            [Test]
            public void FrequencyParameter_PYR()
            {
                DateTime testDate = new DateTime(2010, 6, 15, 12, 12, 12);
                DateTime testFrom = new DateTime(2009, 1, 1, 0, 0, 0);
                DateTime testThru = new DateTime(2010, 1, 1, 0, 0, 0);

                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "PYR";

                Assert.AreEqual(testFrom, testParameter.FromDate);
                Assert.AreEqual(testThru, testParameter.ThruDate);
            }
            [Test]
            public void FrequencyParameter_CYR()
            {
                DateTime testDate = new DateTime(2010, 6, 15, 12, 12, 12);
                DateTime testFrom = new DateTime(2010, 1, 1, 0, 0, 0);
                DateTime testThru = new DateTime(2011, 1, 1, 0, 0, 0);

                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "CYR";

                Assert.AreEqual(testFrom, testParameter.FromDate);
                Assert.AreEqual(testThru, testParameter.ThruDate);
            }
        }

        [TestFixture]
        public class FrequencyParameter_YearChange
        {
            [Test]
            public void FrequencyParameter_Yesterday_YearChange()
            {
                DateTime testDate = new DateTime(2010, 1, 1, 0, 0, 0);
                DateTime expectedResult = new DateTime(2009, 12, 31, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "YSTR";
                Assert.AreEqual(expectedResult, testParameter.FromDate);
            }
            [Test]
            public void FrequencyParameter_Tomorrow_YearChange()
            {
                DateTime testDate = new DateTime(2010, 12, 31, 0, 0, 0);
                DateTime expectedResult = new DateTime(2011, 1, 1, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "DEFAULT";
                Assert.AreEqual(expectedResult, testParameter.ThruDate);
            }
            [Test]
            public void FrequencyParameter_LastMonth_YearChange()
            {
                DateTime testDate = new DateTime(2010, 1, 31, 0, 0, 0);
                DateTime expectedResult = new DateTime(2009, 12, 01, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "MNTH";
                Assert.AreEqual(expectedResult, testParameter.FromDate);
            }
            [Test]
            public void FrequencyParameter_NextMonth_YearChange()
            {
                DateTime testDate = new DateTime(2010, 12, 31, 0, 0, 0);
                DateTime expectedResult = new DateTime(2011, 1, 1, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "CMTH";
                Assert.AreEqual(expectedResult, testParameter.ThruDate);
            }
        }

        [TestFixture]
        public class FrequencyParameter_MonthChange
        {
            [Test]
            public void FrequencyParameter_Yesterday_MonthChange()
            {
                DateTime testDate = new DateTime(2010, 6, 1, 0, 0, 0);
                DateTime expectedResult = new DateTime(2010, 5, 31, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "YSTR";
                Assert.AreEqual(expectedResult, testParameter.FromDate);
            }
            [Test]
            public void FrequencyParameter_Tomorrow_MonthChange()
            {
                DateTime testDate = new DateTime(2010, 6, 30, 0, 0, 0);
                DateTime expectedResult = new DateTime(2010, 7, 1, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(testDate);
                testParameter.Text = "CMTD";
                Assert.AreEqual(expectedResult, testParameter.ThruDate);
            }
        }

        [TestFixture]
        public class FrequencyParameter_BoundaryValues
        {
            [Test]
            public void FrequencyParameter_Yesterday_MinDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MinValue);
                testParameter.Text = "YSTR";
                Assert.IsFalse(testParameter.HasErrors);
                Assert.AreEqual(DateTime.MinValue, testParameter.FromDate);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_Yesterday_MaxDate()
            {
                DateTime expectedResult = new DateTime(9999, 12, 30, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MaxValue);
                testParameter.Text = "YSTR";
                Assert.AreEqual(expectedResult, testParameter.FromDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_Today_MinDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MinValue);
                testParameter.Text = "FOO";
                Assert.AreEqual(DateTime.MinValue, testParameter.FromDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_Today_MaxDate()
            {
                DateTime expectedResult = new DateTime(9999, 12, 31, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MaxValue);
                testParameter.Text = "FOO";
                Assert.AreEqual(expectedResult, testParameter.FromDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_Tomorrow_MinDate()
            {
                DateTime expectedResult = new DateTime(1, 1, 2, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MinValue);
                testParameter.Text = "FOO";
                Assert.AreEqual(expectedResult, testParameter.ThruDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_Tomorrow_MaxDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MaxValue);
                testParameter.Text = "FOO";
                Assert.IsFalse(testParameter.HasErrors);
                Assert.AreEqual(DateTime.MaxValue, testParameter.ThruDate);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_LastMonth_MinDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MinValue);
                testParameter.Text = "MNTH";
                Assert.IsFalse(testParameter.HasErrors);
                Assert.AreEqual(DateTime.MinValue, testParameter.FromDate);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_LastMonth_MaxDate()
            {
                DateTime expectedResults = new DateTime(9999, 11, 1, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MaxValue);
                testParameter.Text = "MNTH";
                Assert.AreEqual(expectedResults, testParameter.FromDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_ThisMonth_MinDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MinValue);
                testParameter.Text = "MNTH";
                Assert.AreEqual(DateTime.MinValue, testParameter.ThruDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_ThisMonth_MaxDate()
            {
                DateTime expectedResult = new DateTime(9999, 12, 1, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MaxValue);
                testParameter.Text = "MNTH";
                Assert.AreEqual(expectedResult, testParameter.ThruDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_NextMonth_MinDate()
            {
                DateTime expectedResult = new DateTime(1, 2, 1, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MinValue);
                testParameter.Text = "CMTH";
                Assert.AreEqual(expectedResult, testParameter.ThruDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_NextMonth_MaxDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MaxValue);
                testParameter.Text = "CMTH";
                Assert.IsFalse(testParameter.HasErrors);
                Assert.AreEqual(DateTime.MaxValue, testParameter.ThruDate);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_LastYear_MinDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MinValue);
                testParameter.Text = "PYR";
                Assert.IsFalse(testParameter.HasErrors);
                Assert.AreEqual(DateTime.MinValue, testParameter.FromDate);
                Assert.IsTrue(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_LastYear_MaxDate()
            {
                DateTime expectedResult = new DateTime(9998, 1, 1, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MaxValue);
                testParameter.Text = "PYR";
                Assert.AreEqual(expectedResult, testParameter.FromDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_ThisYear_MinDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MinValue);
                testParameter.Text = "CYR";
                Assert.AreEqual(DateTime.MinValue, testParameter.FromDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_ThisYear_MaxDate()
            {
                DateTime expectedResult = new DateTime(9999, 1, 1, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MaxValue);
                testParameter.Text = "CYR";
                Assert.AreEqual(expectedResult, testParameter.FromDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_NextYear_MinDate()
            {
                DateTime expectedResult = new DateTime(2, 1, 1, 0, 0, 0);
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MinValue);
                testParameter.Text = "CYR";
                Assert.AreEqual(expectedResult, testParameter.ThruDate);
                Assert.IsFalse(testParameter.HasErrors);
            }
            [Test]
            public void FrequencyParameter_NextYear_MaxDate()
            {
                FrequencyParameter testParameter = new FrequencyParameter(DateTime.MaxValue);
                testParameter.Text = "CYR";
                Assert.IsFalse(testParameter.HasErrors);
                Assert.AreEqual(DateTime.MaxValue, testParameter.ThruDate);
                Assert.IsTrue(testParameter.HasErrors);
            }
        }
    }
}
