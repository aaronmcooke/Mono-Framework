// <copyright file="Parameter.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.IO;
using System.Collections.Generic;

namespace GoatDogGames
{
    public enum ParameterType
    {
        None,
        Bool,
        DateTime,
        Directory,
        Double,
        File,
        Integer,
        String,
        Report
    }
    public class ParameterBase
    {
        #region Fields
        
        protected List<ErrorBase> errors;
        protected string name;
        protected string text;
        
        #endregion
        #region Properties
        
        public virtual Type Type
        {
            get { return typeof(ParameterBase); }
        }
        public bool HasErrors
        {
            get { return errors.Count > 0 ? true : false; }
        }
        public List<ErrorBase> Errors
        {
            get { return errors; }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
                else
                {
                    ParameterError newError = new ParameterError(ParameterErrorTypes.NameWasNull);
                    errors.Add(newError);
                }
            }
        }
        public virtual string Text
        {
            get { return text; }
            set
            {
                if (value != null)
                {
                    text = value;
                }
                else
                {
                    ParameterError newError = new ParameterError(ParameterErrorTypes.TextWasNull);
                    errors.Add(newError);
                }
            }
        }
        
        #endregion
        #region Constructors
        
        public ParameterBase()
        {
            SetDefaults();
        }

        #endregion
        #region Constructor Methods

        protected void SetDefaults()
        {
            errors = new List<ErrorBase>();
            name = string.Empty;
            text = string.Empty;
        }
        
        #endregion
        #region Methods


        #endregion
    }

}
