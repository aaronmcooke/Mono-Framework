// <copyright file="FrequencyParameter.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;

namespace GoatDogGames
{
    public class FrequencyParameter : ParameterBase
    {
        #region Fields

        private delegate DateTime FromDateDelegate();
        private delegate DateTime ThruDateDelegate();
        private FromDateDelegate fromDateMethod;
        private ThruDateDelegate thruDateMethod;
        private DateTime referenceDate;

        #endregion
        #region Properties

        public override Type Type
        {
            get { return typeof(FrequencyParameter); }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (value != null)
                {
                    text = value;
                }
                else
                {
                    text = string.Empty;
                }

                fromDateMethod = GetFromDateMethod();
                thruDateMethod = GetThruDateMethod();
            }
        }
        public DateTime FromDate
        {
            get { return fromDateMethod(); }
        }
        public DateTime ThruDate
        {
            get { return thruDateMethod(); }
        }
        public TimeSpan ReportingPeriod
        {
            get { return ThruDate.Subtract(FromDate); }
        }

        #endregion
        #region Constructors

        public FrequencyParameter()
        {
            SetDefaults();
            SetFrequencyParameterDefaults();
        }
        public FrequencyParameter(DateTime referenceDatePassed)
        {
            SetDefaults();
            SetFrequencyParameterDefaults();
            SetReferenceDateFromDateTimePassed(referenceDatePassed);
        }
        public FrequencyParameter(string referenceDatePassed)
        {
            SetDefaults();
            SetFrequencyParameterDefaults();
            SetReferenceDateFromStringPassed(referenceDatePassed);
        }
        
        #endregion
        #region Constructor Methods

        private void SetFrequencyParameterDefaults()
        {
            referenceDate = DateTime.Now;
            fromDateMethod = GetFromDateMethod();
            thruDateMethod = GetThruDateMethod();
        }
        private void SetReferenceDateFromDateTimePassed(DateTime referenceDatePassed)
        {
            if (referenceDatePassed != null)
            {
                referenceDate = referenceDatePassed;
            }
            else
            {
                FormattingError newError = new FormattingError(FormattingErrorTypes.Null);
                errors.Add(newError);
            }
        }
        private void SetReferenceDateFromStringPassed(string referenceDatePassed)
        {
            if (referenceDatePassed == null)
            {
                FormattingError newError = new FormattingError(FormattingErrorTypes.Null);
                errors.Add(newError);
            }
            else if (referenceDatePassed.Length == 0)
            {
                FormattingError newError = new FormattingError(FormattingErrorTypes.Empty);
                errors.Add(newError);
            }
            else if (!DateIsValid(referenceDatePassed))
            {
                FormattingError newError = new FormattingError(FormattingErrorTypes.FailedParse);
                errors.Add(newError);
            }   
        }

        #endregion
        #region Delegate Assignment Methods

        private FromDateDelegate GetFromDateMethod()
        {
            FromDateDelegate currentMethod = null;
            switch (Text.ToUpper())
            {
                case "PMTD":
                    currentMethod = GetLastMonth;
                    break;
                case "CMTD":
                    currentMethod = GetThisMonth;
                    break;
                case "MNTH":
                    currentMethod = GetLastMonth;
                    break;
                case "YSTR":
                    currentMethod = GetYesterday;
                    break;
                case "CMTH":
                    currentMethod = GetThisMonth;
                    break;
                case "CYR":
                    currentMethod = GetThisYear;
                    break;
                case "PYR":
                    currentMethod = GetLastYear;
                    break;
                default:
                    currentMethod = GetToday;
                    break;
            }
            return currentMethod;
        }
        private ThruDateDelegate GetThruDateMethod()
        {
            ThruDateDelegate currentMethod = null;
            switch (Text.ToUpper())
            {
                case "PMTD":
                    currentMethod = GetTomorrow;
                    break;
                case "CMTD":
                    currentMethod = GetTomorrow;
                    break;
                case "MNTH":
                    currentMethod = GetThisMonth;
                    break;
                case "YSTR":
                    currentMethod = GetToday;
                    break;
                case "CMTH":
                    currentMethod = GetNextMonth;
                    break;
                case "CYR":
                    currentMethod = GetNextYear;
                    break;
                case "PYR":
                    currentMethod = GetThisYear;
                    break;
                default:
                    currentMethod = GetTomorrow;
                    break;
            }
            return currentMethod;
        }

        #endregion
        #region Date Computation Methods

        private DateTime GetTomorrow()
        {
            TimeSpan spanToAdd = new TimeSpan(1, 0, 0, 0);
            DateTime dateResult = DateTime.MaxValue;
            if (DateAddWontExceedMaxDate(referenceDate, spanToAdd))
            {
                dateResult = new DateTime(referenceDate.Year, referenceDate.Month, referenceDate.Day, 0, 0, 0);
                dateResult = dateResult.Add(spanToAdd);
            }
            else
            {
                FrequencyError newError = new FrequencyError(FrequencyErrorTypes.ResultGreaterThanDateMax);
                errors.Add(newError);
            }
            return dateResult;
        }
        private DateTime GetToday()
        {
            return new DateTime(referenceDate.Year, referenceDate.Month, referenceDate.Day, 0, 0, 0);
        }
        private DateTime GetYesterday()
        {
            TimeSpan spanToSubtract = new TimeSpan(1, 0, 0, 0);
            DateTime dateResult = DateTime.MinValue;
            if (DateSubtractWontBeLessThanMinDate(referenceDate, spanToSubtract))
            {
                dateResult = new DateTime(referenceDate.Year, referenceDate.Month, referenceDate.Day, 0, 0, 0);
                dateResult = dateResult.Subtract(spanToSubtract);
            }
            else
            {
                FrequencyError newError = new FrequencyError(FrequencyErrorTypes.ResultLessThanDateMin);
                errors.Add(newError);
            }
            return dateResult;
        }

        private DateTime GetThisMonth()
        {
            return new DateTime(referenceDate.Year, referenceDate.Month, 1, 0, 0, 0);
        }
        private DateTime GetLastMonth()
        {
            int priorMonth = referenceDate.Month - 1;
            int yearOfPriorMonth = referenceDate.Year;
            if (priorMonth == 0)
            {
                priorMonth = 12;
                yearOfPriorMonth -= 1;
            }

            DateTime resultDate = DateTime.MinValue;
            if (YearNotLessThanMinimumYear(yearOfPriorMonth))
            {
                resultDate = new DateTime(yearOfPriorMonth, priorMonth, 1, 0, 0, 0);
            }
            else
            {
                FrequencyError newError = new FrequencyError(FrequencyErrorTypes.ResultLessThanDateMin);
                errors.Add(newError);
            }

            return resultDate;
        }
        private DateTime GetNextMonth()
        {
            DateTime resultDate = DateTime.MaxValue;
            if ((referenceDate.Month != 12) || (YearNotGreaterThanMaximumYear(referenceDate.Year + 1)))
            {
                DateTime nextMonth = GetThisMonth();
                nextMonth = nextMonth.Add(new TimeSpan(27, 0, 0, 0));
                int monthOfPriorDate = nextMonth.Month;
                int monthOfCurrentDate = monthOfPriorDate;
                while (monthOfCurrentDate == monthOfPriorDate)
                {
                    nextMonth = nextMonth.Add(new TimeSpan(1, 0, 0, 0));
                    monthOfCurrentDate = nextMonth.Month;
                }
                resultDate = new DateTime(nextMonth.Year, nextMonth.Month, nextMonth.Day, 0, 0, 0);
            }
            else
            {
                FrequencyError newError = new FrequencyError(FrequencyErrorTypes.ResultGreaterThanDateMax);
                errors.Add(newError);
            }
            return resultDate;
        }

        private DateTime GetThisYear()
        {
            return new DateTime(referenceDate.Year, 1, 1, 0, 0, 0);
        }
        private DateTime GetNextYear()
        {
            DateTime resultDate = DateTime.MaxValue;
            if (YearNotGreaterThanMaximumYear(referenceDate.Year + 1))
            {
                resultDate = new DateTime(referenceDate.Year + 1, 1, 1, 0, 0, 0);
            }
            else
            {
                FrequencyError newError = new FrequencyError(FrequencyErrorTypes.ResultGreaterThanDateMax);
                errors.Add(newError);
            }
            return resultDate;
        }
        private DateTime GetLastYear()
        {
            DateTime resultDate = DateTime.MinValue;
            if (YearNotLessThanMinimumYear(referenceDate.Year - 1))
            {
                resultDate = new DateTime(referenceDate.Year - 1, 1, 1, 0, 0, 0);
            }
            else
            {
                FrequencyError newError = new FrequencyError(FrequencyErrorTypes.ResultLessThanDateMin);
                errors.Add(newError);
            }
            return resultDate;
        }

        #endregion
        #region Validation Methods

        private bool DateIsValid(string dateToCheck)
        {
            bool checkResult = true;
            if (!DateTime.TryParse(dateToCheck, out referenceDate))
            {
                referenceDate = DateTime.Now;
                checkResult = false;            
            }
            return checkResult;
        }
        private bool DateAddWontExceedMaxDate(DateTime datePassed, TimeSpan amountToBeAdded)
        {
            bool checkResult = true;
            DateTime safeDate = DateTime.MaxValue.Subtract(amountToBeAdded);
            if (datePassed.CompareTo(safeDate) == 1)
            {
                checkResult = false;
            }
            return checkResult;
        }
        private bool DateSubtractWontBeLessThanMinDate(DateTime datePassed, TimeSpan amountToBeSubtracted)
        {
            bool checkResult = true;
            DateTime safeDate = DateTime.MinValue.Add(amountToBeSubtracted);
            if (datePassed.CompareTo(safeDate) == -1)
            {
                checkResult = false;
            }
            return checkResult;
        }
        private bool YearNotLessThanMinimumYear(int yearPassed)
        {
            bool resultCheck = true;
            if (yearPassed < DateTime.MinValue.Year)
            {
                resultCheck = false;
            }
            return resultCheck;
        }
        private bool YearNotGreaterThanMaximumYear(int yearPassed)
        {
            bool resultCheck = true;
            if (yearPassed > DateTime.MaxValue.Year)
            {
                resultCheck = false;
            }
            return resultCheck;
        }        
        
        #endregion
    }
}
