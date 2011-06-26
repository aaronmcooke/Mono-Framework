// <copyright file="ConsoleHandler.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Text;

namespace GoatDogGames
{
    public class ConsoleHandler
    {
        #region Fields

        private AppHandlerBase handler;
        private StringBuilder consoleText;

        #endregion
        #region Constructors

        private ConsoleHandler()
        {
            handler = null;
            consoleText = new StringBuilder();
        }
        public ConsoleHandler(AppHandlerBase handlerPassed) : this()
        {
            handler = handlerPassed;
        }

        #endregion
        #region Methods

        public void Start()
        {
            try
            {
                if (handler.Ready)
                {
                    handler.CurrentMenu.KeepLooping = true;
                    while (handler.CurrentMenu.KeepLooping)
                    {
                        handler.IsReEntry = false;
                        Console.Clear();
                        consoleText.Append(handler.CurrentMenu.GetMenuText());
                        Console.Write(consoleText.ToString());
                        handler.UserInput = GetUserInput();
                        consoleText.Length = 0;
                        HandleUserSelection(consoleText, ref handler);
                        Console.Clear();
                        Console.Write(consoleText.ToString());
                        consoleText.Length = 0;
                        if ((!handler.IsReEntry) && (handler.CurrentMenu.KeepLooping))
                        {
                            Pause();
                        }                         
                        Console.Clear();
                    }

                    if (handler.MenuIndexStack.Count > 0)
                    {
                        handler.ChangeCurrentMenu(handler.MenuIndexStack.Pop());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Pause();
            }
            
        }
        private string GetUserInput()
        {
            return Pause("Enter The Selector Of The Desired Menu Item : ");
        }
        private void Pause()
        {
            Pause("Press Any Key To Continue : ");
        }
        private string Pause(string messageToDisplay)
        {
            Console.WriteLine();
            Console.Write(messageToDisplay);
            return Console.ReadLine();
        }
        private void HandleUserSelection(StringBuilder consoleText, ref AppHandlerBase handler)
        {
            MenuItem.HandleSelection handlerSelected = handler.CurrentMenu.GetSelectionHandler(handler.UserInput); ;
            if (handlerSelected != null)
            {
                handlerSelected(consoleText, ref handler);
            }
            else
            {
                consoleText.AppendLine("The menu item selector entered wasn't valid.");
            }
        }

        #endregion
    }

}
