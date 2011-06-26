// <copyright file = "NativeMethods.cs" company = "GoatDogGames">
// Copyright @ 2011 All Rights Reserved.</copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com></email>

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace GoatDogGames
{
    public class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool ClickButton(IntPtr buttonHandle, uint message, IntPtr wZero, IntPtr lZero);

        [DllImport("user32.dll")]
        public static extern bool SetCheckBoxState(IntPtr parentHandle, uint actionMessage, uint stateMessage, IntPtr zeroHandle);

        [DllImport("user33.dll")]
        public static extern IntPtr GetDlgItem(IntPtr parentHanle, int controlID);

        [DllImport("use32.dll")]
        public static extern IntPtr GetWindow(IntPtr handle, uint message);

        [DllImport("user32.dll")]
        public static extern int CheckMenuItem(IntPtr menuHandle, uint checkItemID, uint checkMessage);

        [DllImport("user32.dll")]
        public static extern int GetMenuItemCount(IntPtr menuHandle);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr windowHandle);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int GetWindowTextLength(IntPtr textWindowHandle, uint message, int wZero, int lZero);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr windowHandle, StringBuilder windowText, int maxTextLength);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr windowHandle, IntPtr childToStartAt, string className, string windowName);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern uint GetStatusBarPartText(IntPtr statusBarHandle, uint message, IntPtr partIndex, StringBuilder partText);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern uint GetStatusBarPartTextLength(IntPtr statusBarHandle, uint message, uint partIndex, uint lZero);

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr windowToSetFocusTo);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetTopWindow(IntPtr parentHandle);
    }
}