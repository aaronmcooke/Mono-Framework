// <copyright file="GoatDogGames_ClassTemplate.cs" company="GoatDogGames.FileSystem">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    public class RootFolderNode : FolderNode
    {
        #region Fields

        private FileTree tree;

        #endregion
        #region Properties

        public FileTree Tree
        {
            get { return tree; }
        }

        #endregion
        #region Constructors

        private RootFolderNode() { }
        public RootFolderNode(FileTree treePassed, string namePassed) : base()
        {
            tree = treePassed;
            if (namePassed != null)
            {
                name = namePassed;
            }
        }

        #endregion
    }
}
