// <copyright file="Interpolator.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
    public class Interpolator
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        private List<double> xValues;
        private List<double> yValues;
        private List<double> slopes;
        private List<double> intercepts;

        protected HandleErrors errorHandler;
        protected bool errorHandlerOn;
        protected HandleReports reportHandler;
        protected bool reportHandlerOn;

        #endregion
        #region Properties

        public bool Ready
        {
            get { return ((xValues != null) && (intercepts.Count == (xValues.Count - 1))); }        
        }

        public double XValuesMininum
        {
            get
            {
                double result = 0.0;
                if ((xValues != null) && (xValues.Count > 0))
                {
                    result = xValues[0];
                }
                return result;
            }
        }
        public double XValuesMaximum
        {
            get
            {
                double result = 0.0;
                if ((xValues != null) && (xValues.Count > 0))
                {
                    result = xValues[xValues.Count - 1];
                }
                return result;
            }
        }
        public double YValuesMininum
        {
            get
            {
                double result = 0.0;
                if ((yValues != null) && (yValues.Count > 0))
                {
                    result = yValues[0];
                }
                return result;
            }
        }
        public double YValuesMaximum
        {
            get
            {
                double result = 0.0;
                if ((yValues != null) && (yValues.Count > 0))
                {
                    result = yValues[yValues.Count - 1];
                }
                return result;
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

        public Interpolator()
        {
            xValues = null;
            yValues = null;
            slopes = new List<double>();
            intercepts = new List<double>();

            errorHandler = null;
            reportHandler = null;
            errorHandlerOn = false;
            reportHandlerOn = false;
        }

        #endregion
        #region Methods

        public void SetXAndYValues(List<double> xValuesPassed, List<double> yValuesPassed)
        {
            if (xValuesPassed == null)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "xValuesPassed Was NULL";
                HandleError(newError);
            }
            else if (yValuesPassed == null)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "yValuesPassed Was NULL";
                HandleError(newError);
            }
            else if (xValuesPassed.Count != yValuesPassed.Count)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "xValuesPassed.Length Not Equal To yValuesPassed.Length";
                HandleError(newError);
            }
            else if (xValuesPassed.Count < 2)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "ValuesPassed.Length Must Be At Least 2";
                HandleError(newError);
            }
            else
            {
                xValues = xValuesPassed;
                yValues = yValuesPassed;
                CalculateSlopesAndIntercepts();
            }
        }
        public void SetXAndYValues(Histogram tablePassed)
        {
            if (tablePassed != null)
            {
                SetXAndYValues(tablePassed.UpperBoundaries, tablePassed.Counts);
            }
        }
        private void CalculateSlopesAndIntercepts()
        {
            slopes.Clear();
            intercepts.Clear();
            for (int i = 1; i < xValues.Count; i++)
            {
                slopes.Add((yValues[i] - yValues[i - 1]) / (xValues[i] - xValues[i - 1]));
                intercepts.Add(yValues[i] - (slopes[i - 1] * xValues[i]));
            }
        }

        public double GetXFromY(double yValuePassed)
        {
            return GetInterpolatedValue(yValuePassed, yValues, true);
        }
        public double GetYFromX(double xValuePassed)
        {
            return GetInterpolatedValue(xValuePassed, xValues, false);
        }
        private double GetInterpolatedValue(double valuePassed, List<double> valuesToCheckAgainst, bool interpolateXValue)
        {
            double interpolationResult = 0.0;

            if (Ready)
            {
                int interpolationIndex = GetInterpolationIndex(valuePassed, valuesToCheckAgainst);
                if (interpolationIndex > -1)
                {
                    if (interpolateXValue)
                    {
                        interpolationResult = ((valuePassed - intercepts[interpolationIndex]) / slopes[interpolationIndex]);
                    }
                    else
                    {
                        interpolationResult = (slopes[interpolationIndex] * valuePassed) + intercepts[interpolationIndex];
                    }
                }
                else
                {
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "Value Passed Was Outside The Range Of Available Data";
                    HandleError(newError);
                }
            }
            else
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "Not Ready To Interpolate";
                HandleError(newError);
            }

            return interpolationResult;
        }
        private int GetInterpolationIndex(double valuePassed, List<double> valuesToCheckAgainst)
        {
            int getResult = -1;

            int indexCount = 0;
            while (indexCount < valuesToCheckAgainst.Count)
            {
                if ((valuePassed >= valuesToCheckAgainst[indexCount]) && (valuePassed < valuesToCheckAgainst[indexCount + 1]))
                {
                    getResult = indexCount;
                    indexCount = valuesToCheckAgainst.Count;
                }
                else if (indexCount < (valuesToCheckAgainst.Count - 1))
                {
                    indexCount++;
                }
                else
                {
                    indexCount = valuesToCheckAgainst.Count;
                }
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
