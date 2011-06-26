// <copyright file="FolderNode.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoatDogGames
{
    public class FolderNode
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        private FolderNode parent;
        protected string name;
        private List<FolderNode> folders;
        private List<FileNode> files;

        protected HandleErrors errorHandler;
        protected bool errorHandlerOn;
        protected HandleReports reportHandler;
        protected bool reportHandlerOn;

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
        public string Path
        {
            get
            {
                StringBuilder pathText = new StringBuilder();
                return GetPath(pathText).ToString();
            }
        }
        public DirectoryInfo Folder
        {
            get { return new DirectoryInfo(Path); }
        }
        public List<FolderNode> Folders
        {
            get { return folders; }
        }
        public List<FileNode> Files
        {
            get { return files; }
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

        protected FolderNode()
        {
            parent = null;
            name = string.Empty;
            folders = new List<FolderNode>();
            files = new List<FileNode>();

            errorHandler = null;
            reportHandler = null;
            errorHandlerOn = false;
            reportHandlerOn = false;
        }
        public FolderNode(string namePassed, FolderNode parentPassed) : this()
        {
            if (namePassed != null)
            {
                name = namePassed;
            }
            parent = parentPassed;
        }

        #endregion
        #region Methods

        public StringBuilder GetPath(StringBuilder pathText)
        {
            if (Parent != null)
            {
                pathText = Parent.GetPath(pathText);
                pathText.Append(Name);
                pathText.Append("/");
            }
            else
            {
                RootFolderNode currentNodeAsRoot = (RootFolderNode)this;
                pathText.Append(currentNodeAsRoot.Tree.RootPath);
                pathText.Append(Name);
                pathText.Append("/");
            }
            return pathText;
        }
        public void UpdateFoldersAndFiles()
        {
            DirectoryInfo currentFolder = Folder;
            foreach (DirectoryInfo folder in currentFolder.GetDirectories())
            {
                folders.Add(new FolderNode(folder.Name, this));
            }
            foreach (FileInfo file in currentFolder.GetFiles())
            {
                if (file.Name[0].Equals('.'))
                {
                    files.Add(new FileNode(
                        string.Empty,
                        file.Name,
                        this));
                }
                else
                {
                    files.Add(new FileNode(
                        file.Name.Substring(0, file.Name.Length - file.Extension.Length - 1),
                        file.Extension,
                        this));
                }
            }
        }

        #endregion
        #region Handler Methods

        protected void HandleError(ErrorBase errorToHandle)
        {
            if (ErrorHandlerOn)
            {
                ErrorHandler(errorToHandle);
            }
        }
        protected void HandleReport(ReportBase reportToHandle)
        {
            if (ReportHandlerOn)
            {
                ReportHandler(reportToHandle);
            }
        }

        #endregion
    }
}
