// <copyright file="AppHandlerBase.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
    public abstract class AppHandlerBase
    {
        #region Fields

        private List<MenuList> menus;
        private MenuList mainMenu;
        private MenuList currentMenu;
        private Stack<int> menuIndexStack;
        private bool isReEntry;

        private string userInput;

        #endregion
        #region Properties

        public bool Ready
        {
            get { return ValidateIfHandlerIsReady(); }
        }
        public bool IsReEntry
        {
            get { return isReEntry; }
            set { isReEntry = value; }
        }
        public string UserInput
        {
            get { return userInput; }
            set { userInput = value; }
        }
        public MenuList MainMenu
        {
            get { return mainMenu; }
        }
        public MenuList CurrentMenu
        {
            get { return currentMenu; }
        }
        public Stack<int> MenuIndexStack
        {
            get { return menuIndexStack; }
        }
        #endregion
        #region Constructors

        public AppHandlerBase()
        {
            menus = null;
            userInput = string.Empty;
            mainMenu = null;
            currentMenu = null;
            menuIndexStack = new Stack<int>();
            isReEntry = false;
        }

        #endregion
        #region Methods

        private bool ValidateIfHandlerIsReady()
        {
            bool validationResult = true;

            if (menus == null)
            {
                validationResult = false;
            }
            else if (mainMenu == null)
            {
                validationResult = false;
            }
            else if (currentMenu == null)
            {
                validationResult = false;
            }

            return validationResult;
        }
        public MenuList GetMenuList(int indexPassed)
        {
            MenuList currentMenuList = null;
            foreach (MenuList item in menus)
            {
                if (item.Index == indexPassed)
                {
                    currentMenuList = item;
                    continue;
                }
            }
            return currentMenuList;
        }
        public bool ChangeCurrentMenu(int indexOfNewCurrent)
        {
            bool changeResult = false;
            foreach (MenuList item in menus)
            {
                if (item.Index == indexOfNewCurrent)
                {
                    if ((CurrentMenu != null) && (CurrentMenu.KeepLooping))
                    {
                        MenuIndexStack.Push(CurrentMenu.Index);
                    }
                    currentMenu = item;
                    continue;
                }
            }
            return changeResult;
        }
        public void SetMenus()
        {
            menus = SetAllMenus();
            if (menus != null)
            {
                mainMenu = menus[0];
                ChangeCurrentMenu(0);
            }
        }
        protected abstract List<MenuList> SetAllMenus();
        protected void QuitLooping(StringBuilder consoleTextPassed, ref AppHandlerBase handlerPassed)
        {
            CurrentMenu.KeepLooping = false;
            IsReEntry = true;
        }

        #endregion
    }
}
