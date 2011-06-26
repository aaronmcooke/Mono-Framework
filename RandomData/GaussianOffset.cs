// <copyright file="GaussianOffset.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

// TODO : Implement error reporting in this class.

namespace GoatDogGames
{
    public enum OffsetConstraints
    {
        None,
        NegativeOnly,
        PositiveOnly
    }
    public enum TimeUnits
    {
        None,
        Day,
        Hour,
        Minute,
        Second,
        Millisecond
    }
    public class GaussianOffset : DataGenerator
    {
        #region Constructors

        public GaussianOffset(int seedValuePassed) : base(seedValuePassed)
        {
        }

        #endregion
        #region Probability Density Methods

        public static double BoltzmannProbability(double a, double x)
        {
            double probability = 0.0;
            double term_01 = Math.Sqrt(2.0 / Math.PI);
            double term_02 = a * a * a;
            double term_03 = x * x;
            double term_04 = (-1.0 * (x * x)) / (2.0 * a * a);
            term_04 = Math.Exp(term_04);
            probability = term_01 * ((term_03 * term_04) / term_02);

            return probability;
        }
        public double GaussianProbability(int N) // Set N to 12 for a standard deviation of 1
        {
            double probability = 0;
            double mean = 0.5 * ((double)N);

            for (int cnt = 0; cnt < N; cnt++)
            {
                probability += valueGen.NextDouble();
            }

            probability -= mean;

            return probability;
        }

        #endregion
        #region Gaussian Shifted Double Methods
        public double GetGaussianShiftedDouble(double initialValue, double meanOffset, double unitsPerSigma)
        {
            return GetGaussianShiftedDouble(initialValue, meanOffset, unitsPerSigma, OffsetConstraints.None);
        }
        public double GetGaussianShiftedDouble(double initialValue, double meanOffset, double unitsPerSigma, OffsetConstraints constraintPassed)
        {
            double probability = GaussianProbability(12);

            switch (constraintPassed)
            {
                case OffsetConstraints.None:
                    // Doesn't do anything
                    break;
                case OffsetConstraints.NegativeOnly:
                    if (probability > 0.0)
                    {
                        probability *= -1;
                    }
                    break;
                case OffsetConstraints.PositiveOnly:
                    if (probability < 0.0)
                    {
                        probability *= -1;
                    }
                    break;
                default:
                    // Report Error Here
                    break;
            }

            double offsetResult = initialValue + meanOffset + (probability * unitsPerSigma);

            return offsetResult;
        }

        #endregion
        #region Gaussian Shifted DateTime Methods

        public DateTime GetGaussianShiftedDateTime(DateTime initialValue, double meanOffset, double unitsPerSigma, TimeUnits unitsPassed, OffsetConstraints constraintsPassed)
        {
            DateTime offsetValue = initialValue;
            TimeSpan offsetSpan = new TimeSpan();

            double probability = GaussianProbability(12);

            switch (constraintsPassed)
            {
                case OffsetConstraints.None:
                    // This does nothing.
                    break;
                case OffsetConstraints.NegativeOnly:
                    if (probability > 0.0)
                    {
                        probability *= -1;
                    }
                    break;
                case OffsetConstraints.PositiveOnly:
                    if (probability < 0.0)
                    {
                        probability *= -1;
                    }
                    break;
                default:
                    // Report error here
                    break;
            }

            double offsetAmount = meanOffset + (probability * unitsPerSigma);
            bool negativeOffset = offsetAmount < 0.0;
            offsetAmount = Math.Abs(offsetAmount);

            offsetSpan = ConvertDoubleToTimeSpan(offsetAmount, unitsPassed);

            if (negativeOffset)
            {
                offsetValue = initialValue - offsetSpan;
            }
            else
            {
                offsetValue = initialValue + offsetSpan;
            }

            return offsetValue;
        }

        #endregion
        #region Convert Double To Timespan Methods

        public static TimeSpan ConvertDoubleToTimeSpan(double amountPassed, TimeUnits spanUnitsPassed)
        {
            TimeSpan spanResult = new TimeSpan();

            switch (spanUnitsPassed)
            {
                case TimeUnits.Day:
                    spanResult = GetDaysForTimeSpan(amountPassed);
                    break;
                case TimeUnits.Hour:
                    spanResult = GetHoursForTimeSpan(amountPassed);
                    break;
                case TimeUnits.Minute:
                    spanResult = GetMinutesForTimeSpan(amountPassed);
                    break;
                case TimeUnits.Second:
                    spanResult = GetSecondsForTimeSpan(amountPassed);
                    break;
                case TimeUnits.Millisecond:
                    spanResult = GetMillisecondsForTimeSpan(amountPassed);
                    break;
                case TimeUnits.None:
                    // This Does Nothing
                    break;
                default:
                    // Generate ErrorBase Here                
                    break;
            }

            return spanResult;
        }
        private static TimeSpan GetDaysForTimeSpan(double amountPassed)
        {
            double days = Math.Round(amountPassed, MidpointRounding.AwayFromZero);
            if (amountPassed - days < 0)
            {
                days = days - 1;
            }

            int dayValue = (int)days;
            double remainder = amountPassed - days;
            TimeSpan remainderSpan = GetHoursForTimeSpan(remainder * 24.0);

            TimeSpan resultSpan = new TimeSpan(dayValue, remainderSpan.Hours,
                remainderSpan.Minutes, remainderSpan.Seconds, remainderSpan.Milliseconds);

            return resultSpan;
        }
        private static TimeSpan GetHoursForTimeSpan(double amountPassed)
        {
            double hours = Math.Round(amountPassed, MidpointRounding.AwayFromZero);
            if (hours - amountPassed < 0)
            {
                hours = hours - 1;
            }

            int hourValue = (int)hours;
            double remainder = amountPassed - hours;
            TimeSpan remainderSpan = GetMinutesForTimeSpan(remainder * 60.0);

            TimeSpan resultSpan = new TimeSpan(0, hourValue,
                remainderSpan.Minutes, remainderSpan.Seconds, remainderSpan.Milliseconds);

            return resultSpan;
        }
        private static TimeSpan GetMinutesForTimeSpan(double amountPassed)
        {
            double minutes = Math.Round(amountPassed, MidpointRounding.AwayFromZero);
            if (amountPassed - minutes < 0)
            {
                minutes = minutes - 1;
            }

            int minuteValue = (int)minutes;
            double remainder = amountPassed - minutes;
            TimeSpan remainderSpan = GetSecondsForTimeSpan(remainder * 60);

            TimeSpan resultSpan = new TimeSpan(0, 0,
                minuteValue, remainderSpan.Seconds, remainderSpan.Milliseconds);

            return resultSpan;
        }
        private static TimeSpan GetSecondsForTimeSpan(double amountPassed)
        {
            double seconds = Math.Round(amountPassed, MidpointRounding.AwayFromZero);
            if (amountPassed - seconds < 0)
            {
                seconds = seconds - 1;
            }

            int secondsValue = (int)seconds;
            double remainder = amountPassed - seconds;
            TimeSpan remainderSpan = GetMillisecondsForTimeSpan(remainder * 1000);

            TimeSpan resultSpan = new TimeSpan(0, 0,
                0, secondsValue, remainderSpan.Milliseconds);

            return resultSpan;
        }
        private static TimeSpan GetMillisecondsForTimeSpan(double amountPassed)
        {
            int millisecondsValue = (int)Math.Round(amountPassed, MidpointRounding.AwayFromZero);
            TimeSpan resultSpan = new TimeSpan(0, 0,
                0, 0, millisecondsValue);

            return resultSpan;
        }

        #endregion
    }
}
