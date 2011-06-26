// <copyright file="ArgsHandler.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
	public abstract class BaseArgsHandler
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        private int minArgs;
        private int maxArgs;
        private List<string> allowedParameters;
        private List<string> requiredParameters;
        private List<string> nonUniqueParameters;
        protected List<object> customParameterDefinitions;

        protected string[] args;

        protected int colonIndex;
        protected int hyphenIndex;
        
        protected List<ParameterBase> parameters;

        protected HandleErrors errorHandler;
        protected bool errorHandlerOn;
        protected HandleReports reportHandler;
        protected bool reportHandlerOn;

        protected bool halt;
        private bool noErrors;

        #endregion
        #region Properties

        public string[] Args
        {
            get { return args; }
            set
            {
                string[] argsPassed;

                if (value == null)
                {
                    argsPassed = new string[0];

                    ErrorBase newError = new ErrorBase();
                    newError.Name = "ArgsPassedWasNull";
                    HandleError(newError);
                }
                else
                {
                    argsPassed = value;
                }

                args = argsPassed;
            }
        }
        public List<ParameterBase> Parameters
        {
            get { return parameters; }
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

        public bool Halt
        {
            get { return halt; }
            set { halt = value; }
        }

        #endregion
        #region Constructors

        public BaseArgsHandler()
        {
            args = new string[0];
            parameters = new List<ParameterBase>();

            minArgs = 0;
            maxArgs = 0;
            nonUniqueParameters = new List<string>();
            allowedParameters = new List<string>();
            requiredParameters = new List<string>();
            customParameterDefinitions = new List<object>();

            halt = false;
            noErrors = true;
        }     
        
        private void GetRequiredParameters()
        {
            List<string> listPassed = PassAllowedParametersToBase();
            if ((listPassed != null) && (listPassed.Count > 0))
            {
                if (listPassed.Count > allowedParameters.Count)
                {
                    HandlerError newError = new HandlerError(HandlerErrorTypes.RequiredMoreThanAllowed);
                    HandleError(newError);
                }
                else
                {
                    foreach (string item in listPassed)
                    {
                        if (item == null)
                        {
                            HandlerError newError = new HandlerError(HandlerErrorTypes.RequiredTypeNull);
                            HandleError(newError);
                        }
                        else if (NameListContains(item, requiredParameters))
                        {
                            HandlerError newError = new HandlerError(HandlerErrorTypes.DuplicateRequiredType);
                            HandleError(newError);
                        }
                        else if (!NameListContains(item, allowedParameters))
                        {
                            HandlerError newError = new HandlerError(HandlerErrorTypes.RequiredNotAllowed);
                            HandleError(newError);
                        }
                        else
                        {
                            requiredParameters.Add(item);
                        }
                    }
                }
            }
        }
        private void GetNonUniqueParameters()
        {
            List<string> listPassed = PassNonUniqueParametersToBase();
            if ((listPassed != null) && (listPassed.Count > 0))
            {
                if (listPassed.Count > allowedParameters.Count)
                {
                    HandlerError newError = new HandlerError(HandlerErrorTypes.RequiredMoreThanAllowed);
                    HandleError(newError);
                }
                else
                {
                    foreach (string item in listPassed)
                    {
                        if (item == null)
                        {
                            HandlerError newError = new HandlerError(HandlerErrorTypes.RequiredTypeNull);
                            HandleError(newError);
                        }
                        else if (NameListContains(item, requiredParameters))
                        {
                            HandlerError newError = new HandlerError(HandlerErrorTypes.DuplicateRequiredType);
                            HandleError(newError);
                        }
                        else if (!NameListContains(item, allowedParameters))
                        {
                            HandlerError newError = new HandlerError(HandlerErrorTypes.RequiredNotAllowed);
                            HandleError(newError);
                        }
                        else
                        {
                            requiredParameters.Add(item);
                        }
                    }
                }
            }
        }              
        private bool NameListContains(string itemToCheck, List<string> list)
        {
            bool checkResult = false;
            foreach (string item in list)
            {
                if (itemToCheck.ToString() == item.ToString())
                {
                    checkResult = true;
                }
            }
            return checkResult;
        }
        private void GetCustomParameterDefinitions()
        {
            List<object> customDefinitionsPassed = PassCustomParameterDefinitionsToBase();
            if (customDefinitionsPassed == null)
            {
                customParameterDefinitions = new List<object>();
            }
            else
            {
                customParameterDefinitions = customDefinitionsPassed;
            }
        }
        
        #endregion
        #region Handling Methods

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
        #region Abstract Methods

        protected abstract List<string> PassNonUniqueParametersToBase();
        protected abstract List<string> PassAllowedParametersToBase();
        protected abstract List<string> PassRequiredParametersToBase();
        protected abstract List<object> PassCustomParameterDefinitionsToBase();
        protected abstract int PassMinArgsToBase();
        protected abstract int PassMaxArgsToBase();

        #endregion
        #region General Methods

        public void Reset()
        {
            halt = false;
            noErrors = true;            
            parameters.Clear();
        }
        public void SetPassedFromDerived()
        {
            minArgs = PassMinArgsToBase();
            maxArgs = PassMaxArgsToBase();
            allowedParameters = PassAllowedParametersToBase();
            requiredParameters = PassRequiredParametersToBase();
            nonUniqueParameters = PassNonUniqueParametersToBase();
            customParameterDefinitions = PassCustomParameterDefinitionsToBase();
        }

        #endregion
        #region Validation Methods

        private bool InitialValidation()
        {
            bool validationResult = true;

            if (!ValidateMinAndMaxArgs())
            {
                validationResult = false;
            }
            if (!CheckParameterListsPassedForNull())
            {
                validationResult = false;
            }
            if (!ValidatRequiredAgainstAllowed())
            {
                validationResult = false;
            }


            return validationResult;
        }

        private bool ValidateMinAndMaxArgs()
        {
            bool validationResult = true;

            if (minArgs < 0)
            {
                validationResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "ArgsMinLessThanZero";
                HandleError(newError);
            }
            if (maxArgs < 0)
            {
                validationResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "ArgsMinLessThanZero";
                HandleError(newError);
            }
            if (maxArgs < minArgs)
            {
                validationResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "ArgsMaxLessThanArgsMin";
                HandleError(newError);
            }

            return validationResult;
        }
        private bool CheckParameterListsPassedForNull()
        {
            bool validationResult = true;

            if (allowedParameters == null)
            {
                validationResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "AllowedParametersIsNull";
                HandleError(newError);
            }
            if (requiredParameters == null)
            {
                validationResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "RequiredParametersIsNull";
                HandleError(newError);
            }
            if (nonUniqueParameters == null)
            {
                validationResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "UniqueParametersIsNull";
                HandleError(newError);
            }

            return validationResult;
        }
        private bool ValidatRequiredAgainstAllowed()
        {
            bool validationResult = true;

            QuickSort<string>.Sort(allowedParameters);
            QuickSort<string>.Sort(requiredParameters);

            foreach (string required in requiredParameters)
            {
                bool found = false;

                foreach (string allowed in allowedParameters)
                {
                    if (required.Equals(allowed))
                    {
                        found = true;
                        continue;
                    }
                }

                if(!found)
                {
                    validationResult = false;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "RequiredParameterNotAllowed";
                    newError.Value = required;
                    HandleError(newError);
                }
            }

            return validationResult;
        }
        private bool ValidateMinAndMaxAgainstRequiredAndAllowed()
        {
            bool validationResult = true;
            if (nonUniqueParameters.Count == 0)
            {
                if (minArgs < requiredParameters.Count)
                {
                    validationResult = false;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "MinArgsLessThanRequired";
                    HandleError(newError);
                }
                if ((requiredParameters.Count == allowedParameters.Count) && (maxArgs > allowedParameters.Count))
                {
                    validationResult = false;
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "AllUniqueAndMaxArgsGreaterThanAllowedCount";
                    HandleError(newError);
                }
            }
            return validationResult;
        }

        #endregion
        #region Arg Handling Methods

        // Figure out whether to return a value through the method calls
        // or return the value of a field for ErrorsEncountered.
        public bool HandleArgs()
        {
            bool handleResult = true;
            int counter = 0;

            SetPassedFromDerived();

            if (!InitialValidation())
            {
                handleResult = false;
                halt = true;
            }

            while ((!halt) && (counter < args.Length))
            {
                HandleArg(args[counter]);
                counter++;                
            }

            return handleResult;
        }
        private void HandleArg(string arg)
        {
            CheckArgForNull(arg);
        }
        private void CheckArgForNull(string arg)
        {
            if (arg == null)
            {
                ArgError newError = new ArgError(ArgErrorTypes.Null);
                HandleError(newError);
            }
            else
            {
                CheckArgLength(arg);
            }
        }
        private void CheckArgLength(string arg)
        {
            if (arg.Length == 0)
            {
                ArgError newError = new ArgError(ArgErrorTypes.Empty);
                HandleError(newError);
            }
            else
            {
                CheckArgForLeadingHyphen(arg);
            }
        }
        private void CheckArgForLeadingHyphen(string arg)
        {
            int lastHyphenIndex = arg.LastIndexOf('-');
            if (lastHyphenIndex == -1)
            {
                ArgError newError = new ArgError(ArgErrorTypes.NoHyphen);
                HandleError(newError);
            }
            else if (lastHyphenIndex > 0)
            {
                ArgError newError = new ArgError(ArgErrorTypes.MultipleHyphens);
                HandleError(newError);
            }
            else
            {
                CheckArgForColon(arg);
            }
        }
        private void CheckArgForColon(string arg)
        {
            int firstColonIndex = arg.IndexOf(':');
            int lastColonIndex = arg.LastIndexOf(':');
            if (firstColonIndex == -1)
            {
                ArgError newError = new ArgError(ArgErrorTypes.NoColon);
                HandleError(newError);
            }
            else if (firstColonIndex != lastColonIndex)
            {
                ArgError newError = new ArgError(ArgErrorTypes.MultipleColons);
                HandleError(newError);
            }
            else
            {
                GetParameterAndTypeFromArg(arg, firstColonIndex);            
            }
        }
        private void GetParameterAndTypeFromArg(string arg, int colonIndex)
        {
            string nameFromArg = arg.Substring(1, colonIndex - 1);
            string textFromArg = arg.Substring(colonIndex + 1, arg.Length - 1);

            if ((nameFromArg.Length > 0) && (textFromArg.Length > 0))
            {
                CheckIfNameIsAllowedAndNotDuplicate(nameFromArg, textFromArg);
            }
            else
            {
                if (nameFromArg.Length < 1)
                {
                    ArgError newError = new ArgError(ArgErrorTypes.EmptyType);
                    HandleError(newError);
                }

                if (textFromArg.Length < 1)
                {
                    ArgError newError = new ArgError(ArgErrorTypes.EmptyText);
                    HandleError(newError);
                }
            }
        }
        private void CheckIfNameIsAllowedAndNotDuplicate(string namePassed, string textPassed)
        {
            bool typeIsAllowed = false;
            bool typeIsNotDuplicate = true;
            
            foreach (string item in allowedParameters)
            {
                if (item == namePassed)
                {
                    typeIsAllowed = true;
                    continue;
                }
            }
            foreach (ParameterBase item in parameters)
            {
                if (item.Name == namePassed)
                {
                    typeIsNotDuplicate = false;
                    continue;
                }
            }

            if ((typeIsAllowed) && (typeIsNotDuplicate))
            {
                CreateNewParameter(namePassed, textPassed);
            }
            else
            {
                if (typeIsAllowed)
                {
                    ArgError newError = new ArgError(ArgErrorTypes.ArgTypeIsDuplicate);
                    HandleError(newError);
                }
                else
                {
                    ArgError newError = new ArgError(ArgErrorTypes.ArgTypeNotAllowed);
                    HandleError(newError);
                }
            }
        }
        private void CreateNewParameter(string namePassed, string textPassed)
        {
            ParameterBase newParameter = null;

            if (customParameterDefinitions.Count > 0)
            {
                newParameter = CreateNewCustomDefinedParameter(namePassed, textPassed);
            }
            if (newParameter == null)
            {
                newParameter = CreateNewDefaultParameter(namePassed, textPassed);
            }

            if (newParameter == null)
            {
                HandlerError newError = new HandlerError(HandlerErrorTypes.ParameterNotFound);
                HandleError(newError);
            }
            else
            {
                parameters.Add(newParameter);
            }
        }
        protected ParameterBase CreateNewCustomDefinedParameter(string namePassed, string textPassed)
        {
            return null;
        }
        private ParameterBase CreateNewDefaultParameter(string namePassed, string textPassed)
        {
            return null;    
        }


        private static void CheckArgsForNull(string[] args, List<ErrorBase> result)
        {

        }




        public static List<ErrorBase> HandleArgs(string[] args)
        {
            List<ErrorBase> result = new List<ErrorBase>();
            CheckArgsForNull(args, result);
            return result;
        }
        private static void CheckArgsLength(string[] args, List<ErrorBase> result)
        {

        }
        
        #endregion
	}
}
