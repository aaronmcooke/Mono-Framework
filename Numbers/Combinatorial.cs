// <copyright file = "CombinatorialGenerator.cs" company = "GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com></email>

using System;
using System.Collections.Generic;

// TODO :   Refactor Combinatorial<T> and Combinatorial<T> and 
//          implement the IList<T> interface.
// 
//          Put Combinatorial<T> and CombinatorialTier<T> into their
//          own .cs files.
//
//          Implement the Halt() and Pause() methods in Combinatorial
//          Generator.
//
//          Consider turning CombinatorialRule into a bitwise enumeration      

namespace GoatDogGames
{
    public class Combinatorial<T>
    {
        public List<T> Elements;
        public Type Type
        {
            get { return typeof(T); }
        }
        public Combinatorial()
        {
            Elements = new List<T>();
        }       
    }

    public class CombinatorialTier<T>
    {
        private List<Combinatorial<T>> combinatorials;
        public List<Combinatorial<T>> Tier
        {
            get { return combinatorials; }
        }
        public Type Type
        {
            get { return typeof(T); }
        }
        public CombinatorialTier()
        {
            combinatorials = new List<Combinatorial<T>>();
        }
        public void Clear()
        {
            Tier.Clear();
        }
    }

    public enum CombinatorialRule
    {
        Strict = 0,
        DegeneratesAllowed = 1,
        PermutationsAllowed = 2
    }
    
    public class CombinatorialGenerator<T>
    {
        #region Delegates

        public delegate void ErrorOut(ErrorBase errorToSend);
        public delegate void ReportOut(ParameterBase parameterToSend);

        #endregion
        #region Fields

        private List<T> elements;
        private Dictionary<int, CombinatorialTier<T>> tiers;
        private CombinatorialTier<T> currentTier;

        private int minimumTierValue;
        private int currentTierValue; 
        private int maximumTierValue;

        private CombinatorialRule currentRule;

        private ErrorOut errorHandler;
        private bool errorsOn;

        private ReportOut reportHandler;
        private bool reportingOn;

        #endregion
        #region Properties

        public List<T> Elements
        {
            get
            {
                return CollectionManipulation.CopyGenericList<T>(elements);
            }
            set
            {
                ResetCollections();

                if (value == null)
                {
                    ResetTierMinMaxAndCurrent();
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "ElementsIsNull";
                    HandleError(newError);
                }
                else if (value.Count == 0)
                {
                    ResetTierMinMaxAndCurrent();
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "ElementsIsEmpty";
                    HandleError(newError);
                }
                else
                {
                    elements = value;

                    minimumTierValue = 1;
                    currentTierValue = minimumTierValue;
                    maximumTierValue = elements.Count;
                }
            }
        }

        public int MinimumTierValue
        {
            get { return minimumTierValue; }
        }
        public int CurrentTierValue
        {
            get { return currentTierValue; }
        }
        public int MaximumTierValue
        {
            get { return maximumTierValue; }
        }

        public CombinatorialRule CurrentRule
        {
            get { return currentRule; }
            set { currentRule = value; }
        }
        public ErrorOut ErrorHandler
        {
            set
            {
                if (value != null)
                {
                    errorHandler = value;
                    errorsOn = true;
                }
                else
                {
                    errorHandler = null;
                    errorsOn = false;
                }
            }
        }
        public bool ErrorsOn
        {
            get { return errorsOn; }
        }
        
        public ReportOut ReportingHandler
        {
            set
            {
                if (value != null)
                {
                    reportHandler = value;
                    reportingOn = true;
                }
                else
                {
                    reportHandler = null;
                    reportingOn = false;
                }
            }
        }
        public bool ReportingOn
        {
            get { return reportingOn; }
        }

        public Type Type
        {
            get { return typeof(T); }
        }
        public int TierCount
        {
            get { return tiers.Count; }
        }
        
        #endregion
        #region Constructors

        public CombinatorialGenerator()
        {
            elements = new List<T>();
            tiers = new Dictionary<int, CombinatorialTier<T>>();
            currentTier = null;

            minimumTierValue = 0;
            currentTierValue = 0;
            maximumTierValue = 0;

            currentRule = CombinatorialRule.Strict;

            reportHandler = null;
            reportingOn = false;

            errorHandler = null;
            errorsOn = false;
        }
        public CombinatorialGenerator(List<T> elementsPassed) : this()
        {
            if ((elementsPassed != null) && (elementsPassed.Count > 0))
            {
                elements = elementsPassed;

                minimumTierValue = 1;
                currentTierValue = minimumTierValue;
                maximumTierValue = elementsPassed.Count;
            }
        }        

        #endregion
        #region Methods

        public void Reset()
        {
            ResetCollections();
            ResetTierMinMaxAndCurrent();
            currentRule = CombinatorialRule.Strict;
        }
        private void ResetCollections()
        {
            elements.Clear();
            tiers.Clear();
            currentTier = null;
        }
        private void ResetTierMinMaxAndCurrent()
        {
            minimumTierValue = 0;
            currentTierValue = 0;
            maximumTierValue = 0;
        }

        private bool SetTierMinMaxAndCurrent(int tierMinPassed, int tierMaxPassed)
        {
            bool setResult = true;

            minimumTierValue = tierMinPassed;
            currentTierValue = 0;
            maximumTierValue = tierMaxPassed;

            if (tierMinPassed < 1)
            {
                setResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "TierMinLessThanOne";
                HandleError(newError);
            }
            
            if (tierMaxPassed < 1)
            {
                setResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "TierMaxLessThanOne";
                HandleError(newError);
            }
            
            if (tierMaxPassed < tierMinPassed)
            {
                setResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "TierMaxLessThanTierMin";
                HandleError(newError);
            }

            if (CurrentRule == CombinatorialRule.Strict)
            {
                if (tierMinPassed > elements.Count)
                {
                    setResult = false;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "TierMinMoreThanElementsCount";
                    HandleError(newError);
                }

                if (tierMaxPassed > elements.Count)
                {
                    setResult = false;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "TierMaxMoreThanElementsCount";
                    HandleError(newError);
                }
            }

            if (setResult)
            {
                currentTierValue = MinimumTierValue;
            }

            return setResult;
        }
        private void UpdateTiers()
        {
            for (int i = MinimumTierValue; i < MaximumTierValue + 1; i++)
            {
                CombinatorialTier<T> tier = new CombinatorialTier<T>();

                if (tiers.TryGetValue(i, out tier))
                {
                    tier.Clear();
                }
                else
                {
                    tiers.Add(i, new CombinatorialTier<T>());
                }
            }
        }

        public bool GetCombinatorials()
        {
            return GetCombinatorials(1, elements.Count);
        }
        public bool GetCombinatorials(int tierToCompute)
        {
            return GetCombinatorials(tierToCompute, tierToCompute);
        }
        public bool GetCombinatorials(int minTierPassed, int maxTierPassed)
        {
            bool getResult = true;

            if (Elements.Count == 0)
            {
                getResult = false;
                ResetTierMinMaxAndCurrent();
                ErrorBase newError = new ErrorBase();
                newError.Name = "ElementsIsEmpty";
                HandleError(newError);
            }
            else
            {
                getResult = SetTierMinMaxAndCurrent(minTierPassed, maxTierPassed);
            }

            if (getResult)
            {
                try
                {
                    getResult = ComputeCombinatorials();
                }
                catch (Exception e)
                {
                    getResult = false;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "ExceptionThrown";
                    newError.Exception = e;
                    HandleError(newError);
                }
            }

            return getResult;
        }
        
        private bool ComputeCombinatorials()
        {
            UpdateTiers();

            bool computeResult = true;
            while ((computeResult) && (CurrentTierValue <= MaximumTierValue))
            {
                if (tiers.TryGetValue(CurrentTierValue, out currentTier))
                {
                    switch (CurrentRule)
                    {
                        case CombinatorialRule.Strict:
                            
                            ComputeCombinatorial_Strict(new Combinatorial<T>(), 0);
                            break;
                        
                        case CombinatorialRule.DegeneratesAllowed:
                            
                            ComputeCombinatorial_DegeneratesAllowed(new Combinatorial<T>(), 0);
                            break;
                        
                        case CombinatorialRule.PermutationsAllowed:
                           
                            ComputeCombinatorial_PermutationsAllowed(new Combinatorial<T>());
                            break;
                        
                        default:

                            computeResult = false;
                            ErrorBase newError = new ErrorBase();
                            newError.Name = "CurrentRuleNotValid";
                            HandleError(newError);
                            break;
                    }

                    if (computeResult)
                    {
                        CombinatorialTierParameter<T> newParameter = new CombinatorialTierParameter<T>(currentTier);
                        HandleReport(newParameter);
                    }

                    currentTier = null;
                    currentTierValue++;
                }
                else
                {
                    computeResult = false;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "TryGetCurrentTierFailed";
                    HandleError(newError);
                }
            }
  
            return computeResult;
        }
        private void ComputeCombinatorial_Strict(Combinatorial<T> currentCombinatorial, int currentIndex)
        {
            if (currentCombinatorial.Elements.Count < CurrentTierValue)
            {
                for (int i = currentIndex ; i < Elements.Count ; i++) 
                {
                    Combinatorial<T> newCombinatorial = new Combinatorial<T>();
                    newCombinatorial.Elements = CollectionManipulation.CopyGenericList<T>(currentCombinatorial.Elements);
                    newCombinatorial.Elements.Add(elements[i]);
                    ComputeCombinatorial_Strict(newCombinatorial, i + 1);
                }
            }
            else
            {
                AddCombinatorialToTier(currentCombinatorial);
            }
        }
        private void ComputeCombinatorial_DegeneratesAllowed(Combinatorial<T> currentCombinatorial, int currentIndex)
        {
            if (currentCombinatorial.Elements.Count < CurrentTierValue)
            {
                for (int i = currentIndex; i < elements.Count; i++)
                {
                    Combinatorial<T> newCombinatorial = new Combinatorial<T>();
                    newCombinatorial.Elements = CollectionManipulation.CopyGenericList<T>(currentCombinatorial.Elements);
                    newCombinatorial.Elements.Add(elements[i]);
                    ComputeCombinatorial_DegeneratesAllowed(newCombinatorial, i);
                }
            }
            else
            {
                AddCombinatorialToTier(currentCombinatorial);
            }
        }
        private void ComputeCombinatorial_PermutationsAllowed(Combinatorial<T> currentCombinatorial)
        {
            if (currentCombinatorial.Elements.Count < CurrentTierValue)
            {
                foreach (T item in elements)
                {
                    Combinatorial<T> newCombinatorial = new Combinatorial<T>();
                    newCombinatorial.Elements = CollectionManipulation.CopyGenericList<T>(currentCombinatorial.Elements);
                    newCombinatorial.Elements.Add(item);
                    ComputeCombinatorial_PermutationsAllowed(newCombinatorial);
                }
            }
            else
            {
                AddCombinatorialToTier(currentCombinatorial);
            }
        }  
        private void AddCombinatorialToTier(Combinatorial<T> combinatorialToAdd)
        {
            currentTier.Tier.Add(combinatorialToAdd);

            CombinatorialParameter<T> newParameter = new CombinatorialParameter<T>(combinatorialToAdd);
            HandleReport(newParameter);
        }

        public CombinatorialTier<T> GetTier(int tierToGet)
        {
            CombinatorialTier<T> tierRetrieved = null;

            if (tierToGet > 0)
            {
                if (!tiers.TryGetValue(tierToGet, out tierRetrieved))
                {
                    tierRetrieved = new CombinatorialTier<T>();

                    ErrorBase newError = new ErrorBase();
                    newError.Name = "TryGetTierPassedFailed";
                    HandleError(newError);
                }
            }
            else
            {
                tierRetrieved = new CombinatorialTier<T>();

                ErrorBase newError = new ErrorBase();
                newError.Name = "TierPassedLessThanOne";
                HandleError(newError);
            }

            return tierRetrieved;
        }

        private void HandleError(ErrorBase errorToHandle)
        {
            if (errorsOn)
            {
                errorHandler(errorToHandle);
            }
        }
        private void HandleReport(ParameterBase reportToHandle)
        {
            if (reportingOn)
            {
                reportHandler(reportToHandle);
            }
        }

        #endregion
    }
}
