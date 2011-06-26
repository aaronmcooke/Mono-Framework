// <copyright file="GaussianOffset_UnitTests.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using GoatDogGames;
using NUnit.Framework;

namespace GoatDogGames_UnitTests
{
    namespace GuassianOffsetTests
    {
        [TestFixture]
        public class ConvertDoubleToTimeSpan_OnePassed
        {
            [Test]
            public void GetDaysForTimeSpan()
            {
                
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(1, 0, 0, 0, 0);
                double valueToPass = 1.0;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Day);
                
                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
            [Test]
            public void GetHoursForTimeSpan()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 1, 0, 0, 0);
                double valueToPass = 1.0;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Hour);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
            [Test]
            public void GetMinutesForTimeSpan()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 0, 1, 0, 0);
                double valueToPass = 1.0;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Minute);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
            [Test]
            public void GetSecondsForTimeSpan()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 0, 0, 1, 0);
                double valueToPass = 1.0;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Second);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
            [Test]
            public void GetMillisecondsForTimeSpan()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 0, 0, 0, 1);
                double valueToPass = 1.0;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Millisecond);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
        }

        [TestFixture]
        public class ConvertDoubleToTimeSpan_OnePointFivePassed
        {
            [Test]
            public void GetDaysForTimeSpan()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(1, 12, 0, 0, 0);
                double valueToPass = 1.5;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Day);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
            [Test]
            public void GetHoursForTimeSpan()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 1, 30, 0, 0);
                double valueToPass = 1.5;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Hour);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
            [Test]
            public void GetMinutesForTimeSpan()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 0, 1, 30, 0);
                double valueToPass = 1.5;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Minute);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
            [Test]
            public void GetSecondsForTimeSpan()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 0, 0, 1, 500);
                double valueToPass = 1.5;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Second);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
        }

        [TestFixture]
        public class ConvertDoubleToTimeSpan_MillisecondRounding
        {
            [Test]
            public void MillisecondRound_RoundUp()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 0, 0, 0, 2);
                double valueToPass = 1.75;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Millisecond);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
            [Test]
            public void MillisecondRound_Midway()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 0, 0, 0, 2);
                double valueToPass = 1.5;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Millisecond);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
            [Test]
            public void MillisecondRound_RoundDown()
            {
                GaussianOffset testOffset = new GaussianOffset(GaussianOffset.NewSeedValue);
                TimeSpan expectedSpan = new TimeSpan(0, 0, 0, 0, 1);
                double valueToPass = 1.0;
                TimeSpan actualSpan = testOffset.ConvertDoubleToTimeSpan(valueToPass, TimeUnits.Millisecond);

                Assert.AreEqual(expectedSpan.Days, actualSpan.Days, "Days");
                Assert.AreEqual(expectedSpan.Hours, actualSpan.Hours, "Hours");
                Assert.AreEqual(expectedSpan.Minutes, actualSpan.Minutes, "Minutes");
                Assert.AreEqual(expectedSpan.Seconds, actualSpan.Seconds, "Seconds");
                Assert.AreEqual(expectedSpan.Milliseconds, actualSpan.Milliseconds, "Milliseconds");
            }
        }
    }
}
