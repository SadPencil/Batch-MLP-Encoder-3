using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SadPencil.BatchMLPEncoder3 {
    static class NativeMethods {
        internal const Int32 WM_SETTEXT = 12;
        internal const Int32 SW_HIDE = 0;
        internal const Int32 SW_SHOWNORMAL = 1;
        internal const Int32 SW_NORMAL = 1;
        internal const Int32 SW_SHOWMINIMIZED = 2;
        internal const Int32 SW_SHOWMAXIMIZED = 3;
        internal const Int32 SW_MAXIMIZE = 3;
        internal const Int32 SW_SHOWNOACTIVATE = 4;
        internal const Int32 SW_SHOW = 5;
        internal const Int32 SW_MINIMIZE = 6;
        internal const Int32 SW_SHOWMINNOACTIVE = 7;
        internal const Int32 SW_SHOWNA = 8;
        internal const Int32 SW_RESTORE = 9;
        internal const Int32 SW_SHOWDEFAULT = 10;
        internal const Int32 SW_MAX = 10;
        internal const Int32 WM_CLOSE = 16;

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessageW")]
        internal static extern IntPtr SendMessageW(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessageW")]
        internal static extern IntPtr SendMessageW(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindWindowExW")]
        internal static extern IntPtr FindWindowExW(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);

        //[DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShellExecuteW")]
        //internal static extern IntPtr ShellExecuteW(IntPtr hWnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, Int32 nShowCmd);

    }
}
