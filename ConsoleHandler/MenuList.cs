// <copyright file="MenuList.cs" company="GoatDogGames.Reporters">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
    public class MenuList
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        private int tabWidth;
        private char tabChar;
        private int minSelectorWidth;
        private char selectorPadCharacter;

        private int menuIndex;
        private string menuName;
        private List<MenuItem> menuItems;

        private bool keepLooping;

        protected HandleErrors errorHandler;
        protected bool errorHandlerOn;
        protected HandleReports reportHandler;
        protected bool reportHandlerOn;

        #endregion
        #region Properties

        public int TabWidth
        {
            get { return tabWidth; }
            set
            {
                if (value > -1)
                {
                    tabWidth = value;
                }
            }
        }
        public char TabChar
        {
            get { return tabChar; }
            set
            {
                if (value != (char)0)
                {
                    tabChar = value;
                }
            }
        }
        public int MinSelectorWidth
        {
            get { return minSelectorWidth; }
            set
            {
                if (value > -1)
                {
                    minSelectorWidth = value;
                }
            }
        }
        public char SelectorPadCharacter
        {
            get { return selectorPadCharacter; }
        }

        public int Index
        {
            get { return menuIndex; }
        }
        public string MenuName
        {
            get { return menuName;}
        }
        public int Count
        {
            get { return menuItems.Count; }
        }
        public bool KeepLooping
        {
            get { return keepLooping; }
            set { keepLooping = value; }
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

        private MenuList()
        {
            tabWidth = 5;
            tabChar = ' ';
            minSelectorWidth = 2;
            selectorPadCharacter = ' ';

            menuIndex = 0;
            menuName = string.Empty;
            menuItems = new List<MenuItem>();

            keepLooping = false;

            errorHandler = null;
            reportHandler = null;
            errorHandlerOn = false;
            reportHandlerOn = false;
        }
        public MenuList(int menuIndexPassed, string menuNamePassed) : this()
        {
            menuIndex = menuIndexPassed;
            if (menuNamePassed != null)
            {
                menuName = menuNamePassed;
            }
        }

        #endregion
        #region Methods

        public bool AddMenuItemToMenuItems(MenuItem itemToAdd)
        {
            bool addResult = true;
            if (itemToAdd == null)
            {
                addResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "MenuItemPassedWasNull";
                HandleError(newError);
            }
            else if (!itemToAdd.Ready)
            {
                addResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "MenuItemPassedWasNotReady";
                HandleError(newError);
            }
            else if (ContainsIndex(itemToAdd.MenuIndex))
            {
                addResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "MenuItemsContainedIndexOfMenuItemPassed";
                HandleError(newError);
            }
            else
            {
                menuItems.Add(itemToAdd);
                QuickSort<MenuItem>.Sort(menuItems);
            }
            return addResult;
        }
        private bool ContainsIndex(int indexToLookFor)
        {
            bool containsResult = false;
            foreach (MenuItem item in menuItems)
            {
                if (item.MenuIndex == indexToLookFor)
                {
                    containsResult = true;
                    continue;
                }
            }
            return containsResult;
        }
        public string GetMenuText()
        {
            StringBuilder menuText = new StringBuilder();
            if (!MenuName.Equals(string.Empty))
            {
                menuText.AppendLine(MenuName);
                menuText.AppendLine(string.Empty.PadLeft(MenuName.Length, '-'));
            }
            if ((!MenuName.Equals(string.Empty) && (menuItems.Count > 0)))
            {
                menuText.AppendLine();
            }

            int maxSelectorWidth = 0;
            foreach (MenuItem item in menuItems)
            {
                if (item.MenuSelector.Length > maxSelectorWidth)
                {
                    maxSelectorWidth = item.MenuSelector.Length;
                }
            }

            foreach (MenuItem item in menuItems)
            {
                if ((item.SelectionHandler == null) && (item.MenuText.Equals(string.Empty)))
                {
                    menuText.AppendLine();
                }
                else if (item.SelectionHandler == null)
                {
                    menuText.Append(string.Empty.PadLeft(TabWidth, TabChar));
                    menuText.AppendLine(item.MenuText);
                }
                else
                {
                    menuText.Append(string.Empty.PadLeft(TabWidth, TabChar));

                    if (maxSelectorWidth > MinSelectorWidth)
                    {
                        menuText.Append(item.MenuSelector.PadLeft(maxSelectorWidth, SelectorPadCharacter));
                    }
                    else
                    {
                        menuText.Append(item.MenuSelector.PadLeft(minSelectorWidth, SelectorPadCharacter));
                    }

                    menuText.Append(" - ");
                    menuText.AppendLine(item.MenuText);
                }
            }
            return menuText.ToString();
        }
        public MenuItem.HandleSelection GetSelectionHandler(string selectorPassed)
        {
            MenuItem.HandleSelection handlerSelected = null;
            foreach (MenuItem item in menuItems)
            {
                if (item.MenuSelector.ToUpper().Equals(selectorPassed.ToUpper()))
                {
                    handlerSelected = item.SelectionHandler;
                }
            }
            return handlerSelected;
        }
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
