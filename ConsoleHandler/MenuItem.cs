// <copyright file="MenuItem.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Text;

namespace GoatDogGames
{
    public class MenuItem : IComparable
    {
        #region Delegates

        public delegate void HandleSelection(StringBuilder consoleText, ref AppHandlerBase consoleHandler);

        #endregion
        #region Fields

        private int menuIndex;
        private string menuText;
        private string menuSelector;
        private HandleSelection selectionHandler;

        #endregion
        #region Properties

        public int MenuIndex
        {
            get { return menuIndex; }
        }
        public string MenuText
        {
            get { return menuText; }
        }
        public string MenuSelector
        {
            get { return menuSelector; }
        }
        public HandleSelection SelectionHandler
        {
            get { return selectionHandler; }
        }
        public bool Ready
        {
            get
            {
                bool readyResult = false;
                if ((SelectionHandler == null) && (MenuText.Equals(string.Empty)) && (MenuSelector.Equals(string.Empty)))
                {
                    readyResult = true;
                }
                if ((SelectionHandler == null) && (!MenuText.Equals(string.Empty)) && (MenuSelector.Equals(string.Empty)))
                {
                    readyResult = true;
                }
                if ((SelectionHandler != null) && (!MenuText.Equals(string.Empty)) && (!MenuSelector.Equals(string.Empty)))
                {
                    readyResult = true;
                }
                return readyResult;
            }
        }

        #endregion
        #region Constructors

        private MenuItem()
        {
            menuIndex = 0;
            menuText = string.Empty;
            menuSelector = string.Empty;
            selectionHandler = null;
        }
        public MenuItem(int menuIndexPassed, string menuSelectorPassed, string menuTextPassed, HandleSelection selectionHandlerPassed)
            : this()
        {
            menuIndex = menuIndexPassed;
            if (menuText != null)
            {
                menuText = menuTextPassed;
            }
            if (menuSelector != null)
            {
                menuSelector = menuSelectorPassed;
            }
            selectionHandler = selectionHandlerPassed;
        }

        #endregion
        #region Methods

        public int CompareTo(object objectToCompare)
        {
            int compareResult = 0;
            MenuItem menuItemToCompare = (MenuItem)objectToCompare;
            if (MenuIndex < menuItemToCompare.MenuIndex)
            {
                compareResult = -1;
            }
            else if (MenuIndex > menuItemToCompare.MenuIndex)
            {
                compareResult = 1;
            }
            else
            {
                compareResult = 0;
            }
            return compareResult;
        }

        #endregion
    }
}
