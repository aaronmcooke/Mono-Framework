// <copyright file="FileReporter.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.IO;

namespace GoatDogGames
{
    public class FileReporter : _DataReporter
    {
        #region Delegates

        public delegate string GenerateName();
        public delegate string GenerateHeader();
        public delegate string GenerateFooter();

        #endregion
        #region Fields

        protected string outputFileDirectory;
        protected string outputFileName;
        protected string outputFileExtension;

        protected bool hasFileHeader;
        protected bool hasFileFooter;

        protected GenerateName nameGenerator;
        protected bool nameGeneratorOn;
        protected GenerateHeader headerGenerator;
        protected bool headerGeneratorOn;
        protected GenerateFooter footerGenerator;
        protected bool footerGeneratorOn;

        protected bool isSet;

        #endregion
        #region Properties
        
        public string OutputFileDirectory
        {
            get { return outputFileDirectory; }
            set
            {
                if (value != null)
                {
                    outputFileDirectory = value;
                }
                else
                {
                    outputFileDirectory = string.Empty;
                }
            }
        }
        public string OutputFileName
        {
            get { return outputFileName; }
            set
            {
                if (value != null)
                {
                    outputFileName = value;
                    nameGeneratorOn = false;
                }
                else if ((value == null) && (nameGenerator != null))
                {
                    outputFileName = string.Empty;
                    nameGeneratorOn = true;
                }
                else
                {
                    outputFileName = string.Empty;
                    nameGeneratorOn = false;
                }
            }
        }
        public string OutputFileExtension
        {
            get { return TemplateSet.Extension; }
        }

        public GenerateName NameGenerator
        {
            get { return nameGenerator; }
            set
            {
                nameGenerator = value;
                if (value == null)
                {
                    nameGeneratorOn = false;
                }
                else
                {
                    nameGeneratorOn = true;
                }
            }
        }
        public bool NameGeneratorOn
        {
            get { return nameGeneratorOn; }
        }
        public GenerateHeader HeaderGenerator
        {
            get { return headerGenerator; }
            set
            {
                headerGenerator = value;
                if (value == null)
                {
                    headerGeneratorOn = false;
                }
                else
                {
                    headerGeneratorOn = true;
                }
            }
        }
        public bool HeaderGeneratorOn
        {
            get { return headerGeneratorOn; }
        }
        public GenerateFooter FooterGenerator
        {
            get { return footerGenerator; }
            set
            {
                footerGenerator = value;
                if (value == null)
                {
                    footerGeneratorOn = false;
                }
                else
                {
                    footerGeneratorOn = true;
                }
            }
        }
        public bool FooterGeneratorOn
        {
            get { return footerGeneratorOn; }
        }

        public bool IsSet
        {
            get { return isSet; }
        }

        private FileTemplate TemplateSet
        {
            get { return (FileTemplate)template; }
        }
        public override Template TemplateType
        {
            get { return Template.File; }
        }

        #endregion
        #region Constructors

        public FileReporter(FileTemplate templateToUse)
        {
            template = templateToUse;
        }

        #endregion
        #region Methods

        // TODO : Set() method needs to be implementation of
        // abstract method in DataReporter() class.
        public bool Set()
        {
            bool setResult = false;

            TemplateSet.Set(this);
            isSet = setResult;

            return setResult;
        }

        public bool StartReport()
        {
            return true;
        }
        public bool Append()
        {
            return true;
        }
        public bool AppendLine()
        {
            return true;
        }
        public bool EndReport()
        {
            return true;
        }

        public void HandleHeader()
        {
            
        }
        public void HandleFooter()
        {

        }
        public void HandleNameGeneration()
        {
            if (nameGeneratorOn)
            {
                outputFileName = NameGenerator();
            }        
        }

        #endregion
    }
}
