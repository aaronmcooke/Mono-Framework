// <copyright file = "User32Constants.cs" company = "GoatDogGames">
// Copyright @ 2011 All Rights Reserved.</copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com></email>

using System;

namespace GoatDogGames
{
    public class User32Constants
    {
        public const uint WM_USER = 0x0400;

        public enum SecurityDialog : uint
        {
            RunButtonID = 0x114A,
            CancelButtonID = 0x0002,
            AlwaysAskID = 0x114C
        }

        public enum MenuFunctionConstants : uint
        {
            MF_BYCOMMAND = 0x0000,
            MF_BYPOSITION = 0x0400,
            MF_CHECKED = 0x0008,
            MF_UNCHECKED = 0x0000
        }

        public enum StatusBarMessage : uint
        {
            SB_GETTEXTLENGTH = (int)WM_USER + 12,
            SB_GETTEXT = (int)WM_USER + 13,
            SB_GETPARTS = (int)WM_USER + 6
        }

        public enum GetWindowType : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        public enum WindowMessage : uint
        {
            WM_SETFOCUS = 0x0007,      // Set focus
            WM_SETTEXT = 0x000C,      // Set text to a textbox
            WM_GETTEXT = 0x000D,
            WM_GETTEXTLENGTH = 0x000E,
            WM_COMMAND = 0x0111          // Simulate clicking a menu item
        }

        public enum ButtonMessage : uint
        {
            BM_SETCHECK = 0x00F1,  // set radio or checkbox button state
            BST_UNCHECKED = 0x0000,
            BST_CHECKED = 0x0001,
            BM_CLICK = 0x00F5    // click button
        }

        public enum CommonDialog : uint
        {
            FILENAME_TEXTBOX = 0x047C,
            OPEN_SAVE_BUTTON = 0x0001,
            CANCEL_BUTTON = 0x0002
        }
    }
}