// <copyright file="FileTree.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.IO;

namespace GoatDogGames
{
    public class FileTree
    {
        #region Delegates

        public delegate void HandleFolder(FolderNode nodeToHandle);
        public delegate void HandleFile(FileNode nodeToHandle);

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        private string rootPath;
        private FolderNode root;

        protected HandleErrors errorHandler;
        protected bool errorHandlerOn;
        protected HandleReports reportHandler;
        protected bool reportHandlerOn;

        #endregion
        #region Properties

        public bool Ready
        {
            get
            {
                return ((root != null) && (rootPath != null) && (Directory.Exists(rootPath)));
            }
        }
        public string RootPath
        {
            get { return rootPath; }
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

        public FileTree()
        {
            root = null;
            rootPath = string.Empty;

            errorHandler = null;
            reportHandler = null;
            errorHandlerOn = false;
            reportHandlerOn = false;
        }

        #endregion
        #region Methods

        public bool SetRoot(string rootPathPassed)
        {
            bool setResult = false;
            if ((rootPathPassed != null) && (Directory.Exists(rootPathPassed)))
            {
                DirectoryInfo rootFolder = new DirectoryInfo(rootPathPassed);
                if (rootFolder.Exists)
                {
                    rootPath = rootFolder.FullName.Substring(0, rootFolder.FullName.Length - rootFolder.Name.Length);
                    root = new RootFolderNode(this, rootFolder.Name);
                    GrowTree(root);
                    setResult = true;
                }
            }
            return setResult;
        }
        private void GrowTree(FolderNode currentNode)
        {
            currentNode.UpdateFoldersAndFiles();
            foreach (FolderNode folder in currentNode.Folders)
            {
                GrowTree(folder);
            }
        }

        public bool Traverse(TraverseType typeOfTraversal, HandleFolder folderHandler)
        {
            bool traverseResult = false;
            if (Ready)
            {
                switch (typeOfTraversal)
                {
                    case TraverseType.PreOrder:

                        PreOrderTraverse(folderHandler, root);
                        traverseResult = true;                        
                        break;

                    case TraverseType.PostOrder:

                        PostOrderTraverse(folderHandler, root);
                        traverseResult = true;
                        break;
                }
            }
            return traverseResult;
        }
        public bool Traverse(TraverseType typeOfTraversal, HandleFile fileHandler)
        {
            bool traverseResult = false;
            if (Ready)
            {
                switch (typeOfTraversal)
                {
                    case TraverseType.PreOrder:

                        foreach (FileNode file in root.Files)
                        {
                            fileHandler(file);
                        }
                        PreOrderTraverse(fileHandler, root);
                        traverseResult = true;
                        break;
                    
                    case TraverseType.PostOrder:
                        
                        PostOrderTraverse(fileHandler, root);
                        foreach (FileNode file in root.Files)
                        {
                            fileHandler(file);
                        }
                        traverseResult = true;                        
                        break;
                }
            }
            return traverseResult;
        }
        private void PreOrderTraverse(HandleFolder folderHandler, FolderNode currentNode)
        {
            folderHandler(currentNode);
            foreach (FolderNode folder in currentNode.Folders)
            {
                PreOrderTraverse(folderHandler, folder);
            }
        }
        private void PreOrderTraverse(HandleFile filehandler, FolderNode currentNode)
        {
            foreach (FileNode file in currentNode.Files)
            {
                filehandler(file);                
            }
            foreach (FolderNode folder in currentNode.Folders)
            {
                PreOrderTraverse(filehandler, folder);
            }
        }
        private void PostOrderTraverse(HandleFolder folderHandler, FolderNode currentNode)
        {
            foreach (FolderNode folder in currentNode.Folders)
            {
                PostOrderTraverse(folderHandler, folder);
            }
            folderHandler(currentNode);
        }
        private void PostOrderTraverse(HandleFile filehandler, FolderNode currentNode)
        {
            foreach (FolderNode folder in currentNode.Folders)
            {
                PreOrderTraverse(filehandler, folder);
            }
            foreach (FileNode file in currentNode.Files)
            {
                filehandler(file);
            }
        }

        #endregion
        #region HandlerMethods

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
