// <copyright file="FileNode.cs" company="GoatDogGames.FileSystem">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.IO;
using System.Text;

namespace GoatDogGames
{
    public class FileNode
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        private FolderNode parent;
        private string name;
        private string extension;

        private HandleErrors errorHandler;
        private bool errorHandlerOn;
        private HandleReports reportHandler;
        private bool reportHandlerOn;

        #endregion
        #region Properties

        public FolderNode Parent
        {
            get { return parent; }
        }
        public string Name
        {
            get { return name; }
        }
        public string Extension
        {
            get { return extension; }
        }
        public FileInfo File
        {
            get { return new FileInfo(Path); }
        }
        public string Path
        {
            get
            {
                StringBuilder pathText = new StringBuilder();
                return GetPath(pathText).ToString();
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

        private FileNode()
        {
            parent = null;
            name = string.Empty;
            extension = string.Empty;

            errorHandler = null;
            reportHandler = null;
            errorHandlerOn = false;
            reportHandlerOn = false;
        }
        public FileNode(string namePassed, string extensionPassed, FolderNode parentPassed) : this()
        {
            if (namePassed != null)
            {
                name = namePassed;
            }
            if (extensionPassed != null)
            {
                extension = extensionPassed;
            }
            parent = parentPassed;
        }

        #endregion
        #region Methods

        public StringBuilder GetPath(StringBuilder pathText)
        {
            pathText = Parent.GetPath(pathText);
            pathText.Append(Name);
            pathText.Append(".");
            pathText.Append(Extension);
            return pathText;
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
