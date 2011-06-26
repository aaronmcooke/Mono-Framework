// <copyright file="_DataReporter.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

// TODO : Implement abstract Set() method

namespace GoatDogGames
{
    public enum Template
    {
        None,
        File,
        Console,
        Class,
        Program
    }

    public class _DataReporter
    {
        #region Fields

        protected ReportingTemplateBase template;

        #endregion
        #region Properties

        public virtual Template TemplateType
        {
            get { return Template.None; }
        }

        #endregion
        #region Constructors

        public _DataReporter()
        {
            template = null;
        }

        #endregion
        #region Methods



        #endregion
    }
}
