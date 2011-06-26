// <copyright file="RandomAgeGenerator.cs" company="GoatDogGames.Demographics">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;
using GoatDogGames;

// TODO : Ask Whether Its Better To Avoid Declaring Variables Or Have Less Readable Code

namespace GoatDogGames.Demographics
{
    public class RandomAgeGenerator
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        private Random source;
        private Interpolator interpolator;

        protected HandleErrors errorHandler;
        protected bool errorHandlerOn;
        protected HandleReports reportHandler;
        protected bool reportHandlerOn;

        #endregion
        #region Properties

        public bool Ready
        {
            get { return ((source != null) && (interpolator != null) && ( interpolator.Ready)); }
        }
        public double AgeMinimum
        {
            get
            {
                double minResult = 0.0;
                if (interpolator != null)
                {
                    minResult = interpolator.XValuesMininum;
                }
                return minResult;
            }
        }
        public double AgeMaximum
        {
            get
            {
                double maxResult = 0.0;
                if (interpolator != null)
                {
                    maxResult = interpolator.XValuesMaximum;
                }
                return maxResult;
            }
        }

        public HandleErrors ErrorHandler
        {
            get { return errorHandler; }
            set
            {
                if (value == null)
                {
                    errorHandler = null;
                    errorHandlerOn = false;
                }
                else
                {
                    errorHandler = value;
                    errorHandlerOn = true;
                }
            }
        }
        public bool ErrorHandlerOn
        {
            get { return errorHandlerOn; }
        }
        public HandleReports ReportHandler
        {
            get { return reportHandler; }
            set
            {
                if (value == null)
                {
                    reportHandler = null;
                    reportHandlerOn = false;
                }
                else
                {
                    reportHandler = value;
                    reportHandlerOn = true;
                }
            }
        }
        public bool ReportHandlerOn
        {
            get { return reportHandlerOn; }
        }

        #endregion
        #region Constructors

        private RandomAgeGenerator()
        {
            source = null;
            interpolator = null;

            errorHandler = null;
            reportHandler = null;
            errorHandlerOn = false;
            reportHandlerOn = false;
        }
        public RandomAgeGenerator(Random sourcePassed) : this()
        {
            if (sourcePassed != null)
            {
                source = sourcePassed;
            }
        }

        #endregion
        #region Methods

        public void SetAgeTables(List<double> ageBandsPassed, List<double> ageDistributionPassed)
        {
            if (source == null)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "Source Is NULL";
                HandleError(newError);
            }
            else if (ageBandsPassed == null)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "ageBandsPassed Was NULL";
                HandleError(newError);
            }
            else if (ageDistributionPassed == null)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "ageDistributionPassed Was NULL";
                HandleError(newError);
            }
            else if (ageBandsPassed.Count != ageDistributionPassed.Count)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "ageBandsPassed.Count Must Equal ageDistributionPassed.Count";
                HandleError(newError);
            }
            else if (ageBandsPassed.Count < 2)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "ageBandsPassed.Count And ageDistributionPassed.Count Must Be At Least 2";
                HandleError(newError);
            }
            else if (IsAgeDistributionPassedNotValid(ageDistributionPassed))
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "ageDistributionPassed Was Not Valid";
                HandleError(newError);
            }
            else if (IsAgeBandsPassedNotValid(ageBandsPassed))
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "ageBandsPassed Was Not Valid";
                HandleError(newError);
            }
            else
            {
                interpolator = new Interpolator();
                interpolator.SetXAndYValues(ageBandsPassed, ageDistributionPassed);
            }
        }
        private bool IsAgeDistributionPassedNotValid(List<double> ageDistributionPassed)
        {
            bool isValid = true;

            double currentSumValue = 0.0;
            foreach (double value in ageDistributionPassed)
            {
                if (value < 0.0)
                {
                    isValid = false;
                    break;
                }

                currentSumValue += value;
                if (currentSumValue > ((double)Int32.MaxValue))
                {
                    isValid = false;
                    break;
                }              
            }   
         
            return !isValid;
        }
        private bool IsAgeBandsPassedNotValid(List<double> ageBandsPassed)
        {
            bool isValid = true;

            double previousValue = -1.0;
            foreach (double value in ageBandsPassed)
            {
                if (value < 0.0)
                {
                    isValid = false;
                    break;
                }

                if (value <= previousValue)
                {
                    isValid = false;
                    break;
                }
                else
                {
                    previousValue = value;
                }
            }

            return !isValid;
        }

        public List<TimeSpan> GetRandomAges(int countOfAgesToGet)
        {
            List<TimeSpan> getResult = new List<TimeSpan>();
            if (Ready)
            {
                for (int i = 0; i < countOfAgesToGet; i++)
                {
                    getResult.Add(GetRandomAge());
                }
            }
            return getResult;
        }
        public TimeSpan GetRandomAge()
        {
            return CalculateRandomAgeWithinRange(interpolator.YValuesMininum, interpolator.YValuesMaximum);
        }
        public TimeSpan GetRandomAgeWithinRange(double minimumAge, double maximumAge)
        {
            TimeSpan getResult = new TimeSpan();
            if ((Ready) && (minimumAge >= interpolator.XValuesMininum) && (maximumAge < interpolator.XValuesMaximum) && (maximumAge >= minimumAge))
            {
                double minValue = interpolator.GetYFromX(minimumAge);
                double maxValue = interpolator.GetYFromX(maximumAge);

                getResult = CalculateRandomAgeWithinRange(minValue, maxValue);
            }
            return getResult;
        }
        private TimeSpan CalculateRandomAgeWithinRange(double minimumDistribution, double maximumDistribution)
        {
            TimeSpan getResult = new TimeSpan();
            if ((Ready) && (minimumDistribution >= interpolator.YValuesMininum) && (maximumDistribution <= interpolator.YValuesMaximum)
                && (maximumDistribution >= minimumDistribution))
            {
                int minValue = (int)minimumDistribution;
                int maxValue = (int)maximumDistribution;

                getResult = GaussianOffset.ConvertDoubleToTimeSpan(
                    365.0 * interpolator.GetXFromY((double)source.Next(minValue, maxValue)), TimeUnits.Day);
            }
            return getResult;
        }
        
        #endregion
        #region Handler Methods

        private void HandleError(ErrorBase errorToHandle)
        {
            if (ErrorHandlerOn)
            {
                ErrorHandler(errorToHandle);
            }
        }
        private void HandleReport(ReportBase reportToHandle)
        {
            if (ReportHandlerOn)
            {
                ReportHandler(reportToHandle);
            }
        }

        #endregion
    }
}
