// <copyright file="Histogram.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
    public class Histogram
    {
        #region Private ProbabilityBand Class

        private class Bin : IComparable
        {
            #region Fields

            private double upperBoundary;
            private double count;

            #endregion
            #region Properties

            public double UpperBoundary
            {
                get { return upperBoundary; }
            }
            public double Count
            {
                get { return count; }
            }

            #endregion
            #region Constructors

            private Bin()
            {
                upperBoundary = 0.0;
                count = 0.0;
            }
            public Bin(double upperBoundaryPassed, double countPassed)
                : this()
            {
                if (upperBoundaryPassed > 0.0)
                {
                    upperBoundary = upperBoundaryPassed;
                }
                if (countPassed > 0.0)
                {
                    count = countPassed;
                }
            }

            #endregion
            #region Methods

            public int CompareTo(object objectToCompareTo)
            {
                Bin bandPassed = (Bin)objectToCompareTo;
                int compareResult = 0;
                if (UpperBoundary < bandPassed.UpperBoundary)
                {
                    compareResult = -1;
                }
                else if (UpperBoundary > bandPassed.UpperBoundary)
                {
                    compareResult = 1;
                }
                return compareResult;
            }
            public override string ToString()
            {
                return UpperBoundary.ToString() + (char)9 + Count.ToString();
            }

            #endregion
        }

        #endregion
        #region Fields

        private List<Bin> distribution;

        #endregion
        #region Properties

        public List<double> UpperBoundaries
        {
            get
            {
                List<double> getResult = new List<double>();
                foreach (Bin item in distribution)
                {
                    getResult.Add(item.UpperBoundary);
                }
                return getResult;
            }
        }
        public List<double> Counts
        {
            get
            {
                List<double> getResult = new List<double>();
                foreach (Bin item in distribution)
                {
                    getResult.Add(item.Count);
                }
                return getResult;
            }
        }
        public int BandCount
        {
            get { return distribution.Count; }
        }

        #endregion
        #region Constructors

        public Histogram()
        {
            distribution = new List<Bin>();
            distribution.Add(new Bin(0.0, 0.0));
        }

        #endregion
        #region Methods

        public void Clear()
        {
            distribution.Clear();
        }

        public bool AddProbabilityBands(List<double> upperBoundaries, List<double> counts)
        {
            bool addResult = false;
            if ((upperBoundaries != null) && (counts != null) && (upperBoundaries.Count == counts.Count))
            {
                int counter = 0;
                while (counter < upperBoundaries.Count)
                {
                    AddBandToDistribution(upperBoundaries[counter], counts[counter]);
                }
                SortDistribution();
                addResult = true;
            }
            return addResult;
        }
        public bool AddProbabilityBand(double upperBoundaryPassed, double countPassed)
        {
            bool addResult = AddBandToDistribution(upperBoundaryPassed, countPassed);
            if (addResult)
            {
                SortDistribution();
            }
            return addResult;
        }
        private bool AddBandToDistribution(double upperBoundaryPassed, double countPassed)
        {
            bool addResult = false;
            if ((upperBoundaryPassed > 0.0) && (countPassed >= 0.0))
            {
                int indexFound = IndexOf(upperBoundaryPassed);

                if (indexFound == -1)
                {
                    distribution.Add(new Bin(upperBoundaryPassed, countPassed));

                }
                else
                {
                    distribution[indexFound] = new Bin(upperBoundaryPassed, countPassed);
                }
            }
            return addResult;
        }
        private int IndexOf(double upperBoundaryToFind)
        {
            int indexResult = -1;
            int counter = 0;
            while (counter < distribution.Count)
            {
                if (distribution[counter].UpperBoundary == upperBoundaryToFind)
                {
                    indexResult = counter;
                    counter = distribution.Count;
                }
                else
                {
                    counter++;
                }
            }
            return indexResult;
        }
        private void SortDistribution()
        {
            GoatDogGames.QuickSort<Bin>.Sort(distribution);
        }

        public override string ToString()
        {
            System.Text.StringBuilder distributionText = new System.Text.StringBuilder();
            foreach (Bin item in distribution)
            {
                distributionText.AppendLine(item.ToString());
            }
            return distributionText.ToString();
        }

        #endregion
    }
}
