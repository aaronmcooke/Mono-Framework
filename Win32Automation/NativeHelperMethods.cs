// <copyright file="NativeHelperMethods.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    public class NativeHelperMethods
    {
        public static int GetZOrderOfWindow(IntPtr handlePassed)
        {
            IntPtr desktopHandle = NativeMethods.GetDesktopWindow();
            return GetZOrderOfWindow(handlePassed, desktopHandle);
        }
        public static int GetZOrderOfWindow(IntPtr handlePassed, IntPtr parentWindow)
        {
            IntPtr currentHandle = NativeMethods.GetTopWindow(parentWindow);
            int zOrder = -1;
            int zCounter = 0;

            if (currentHandle == handlePassed)
            {
                zOrder = 0;
            }
            else
            {
                while ((zOrder == -1) && (currentHandle != null) && (currentHandle != IntPtr.Zero))
                {
                    zCounter++;
                    currentHandle = NativeMethods.GetWindow(currentHandle, (uint)User32Constants.GetWindowType.GW_HWNDNEXT);

                    if (currentHandle == handlePassed)
                    {
                        zOrder = zCounter;
                    }
                }
            }

            return zOrder;
        }
        public static bool HandleSecurityDialog(bool uncheckAlwaysAsk, bool runApplication)
        {
            System.Threading.Thread.Sleep(100);
            bool result = false;
            IntPtr desktopHandle = NativeMethods.GetDesktopWindow();
            IntPtr securityHandle = NativeMethods.FindWindowEx(desktopHandle, IntPtr.Zero, string.Empty, "Open File - Security Warning");

            if (securityHandle != IntPtr.Zero)
            {
                IntPtr runButtonHandle = NativeMethods.GetDlgItem(securityHandle, (int)User32Constants.SecurityDialog.RunButtonID);
                IntPtr cancelButtonHandle = NativeMethods.GetDlgItem(securityHandle, (int)User32Constants.SecurityDialog.CancelButtonID);
                IntPtr alwaysAskCheckboxHandle = NativeMethods.GetDlgItem(securityHandle, (int)User32Constants.SecurityDialog.AlwaysAskID);

                if (uncheckAlwaysAsk)
                {
                    result = NativeMethods.SetCheckBoxState(alwaysAskCheckboxHandle, (uint)User32Constants.ButtonMessage.BM_SETCHECK, (uint)User32Constants.ButtonMessage.BST_UNCHECKED, IntPtr.Zero);
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    result = true;
                }

                if ((result) && (runApplication))
                {
                    result = NativeMethods.ClickButton(runButtonHandle, (uint)User32Constants.ButtonMessage.BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    result = NativeMethods.ClickButton(cancelButtonHandle, (uint)User32Constants.ButtonMessage.BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                    System.Threading.Thread.Sleep(100);
                }
            }
            return result;
        }
    }
}
