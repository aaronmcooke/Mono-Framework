// <copyright file="Error.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>


using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace GoatDogGames
{
    public class ErrorBase
    {
        #region Fields

        protected string arg;
        protected Exception exception; 
        protected string message;
        protected string name;
        protected ErrorType baseType;
        protected string errorValue;

        #endregion
        #region Properties

        public string Arg
		{
			get { return arg; }
			set { arg = value; }
		}
        public Exception Exception
        {
            get { return exception; }
            set { exception = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
        public ErrorType Type
        {
            get { return Type; }
        }
        public string Value
        {
            get { return errorValue; }
            set { errorValue = value; }
        }

        #endregion
        #region Constructors

        public ErrorBase()
		{
			arg = string.Empty;
            exception = null;
            message = string.Empty;
			name = string.Empty;
            baseType = ErrorType.None;
            errorValue = string.Empty;
        }

        #endregion
    }

    public class HandlerError : ErrorBase
    {
        private HandlerErrorTypes derivedType;
        public HandlerErrorTypes DerivedType
        {
            get { return derivedType; }
        }
        public HandlerError(HandlerErrorTypes derivedTypePassed)
        {
            baseType = ErrorType.Handler;
            derivedType = derivedTypePassed;
        }
    }

    public class ArgsError : ErrorBase
    {
        private ArgsErrorTypes derivedType;
        public ArgsErrorTypes DerivedType
        {
            get { return derivedType; }
        }
        public ArgsError(ArgsErrorTypes derivedTypePassed)
        {
            baseType = ErrorType.Args;
            derivedType = derivedTypePassed;
        }
    }

    public class ArgError : ErrorBase
    {
        private ArgErrorTypes derivedType;
        public ArgErrorTypes DerivedType
        {
            get { return derivedType; }
        }
        public ArgError(ArgErrorTypes derivedTypePassed)
        {
            baseType = ErrorType.Arg;
            derivedType = derivedTypePassed;
        }
    }

    public class ParameterError : ErrorBase
    {
        private ParameterErrorTypes derivedType;
       
        public ParameterErrorTypes DerivedType
        {
            get { return derivedType; }
        }

        public ParameterError(ParameterErrorTypes derivedTypePassed)
        {
            baseType = ErrorType.Parameter;
            derivedType = derivedTypePassed;
        }
    }

    public class FormattingError : ErrorBase
    {
        private FormattingErrorTypes derivedType;
       
        public FormattingErrorTypes DerivedType
        {
            get { return derivedType; }
        }

        public FormattingError(FormattingErrorTypes derivedTypePassed)
        {
            baseType = ErrorType.Formatting;
            derivedType = derivedTypePassed;
        }
    }

    public class FrequencyError : ErrorBase
    {
        private FrequencyErrorTypes derivedType;
        public FrequencyErrorTypes DerivedType
        {
            get { return derivedType; }
        }
        public FrequencyError(FrequencyErrorTypes derivedTypePassed)
        {
            baseType = ErrorType.FrequencyParameter;
            derivedType = derivedTypePassed;
        }
    }

    public class IOError : ErrorBase
    {
        private IOErrorTypes derivedType;
        public IOErrorTypes DerivedType
        {
            get { return derivedType; }
        }
        public IOError(IOErrorTypes derivedTypePassed)
        {
            baseType = ErrorType.IOParameter;
            derivedType = derivedTypePassed;
        }
    }
}
