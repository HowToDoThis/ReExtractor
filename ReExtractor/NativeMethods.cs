using System;
using System.Runtime.InteropServices;

namespace ReExtractor
{
    internal static class NativeMethods
    {
        // Token: 0x0600001A RID: 26
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        // Token: 0x0600001B RID: 27
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref NativeMethods.LVCOLUMN lPLVCOLUMN);

        // Token: 0x0400000E RID: 14
        public const int HDI_FORMAT = 4;

        // Token: 0x0400000F RID: 15
        public const int HDF_SORTUP = 1024;

        // Token: 0x04000010 RID: 16
        public const int HDF_SORTDOWN = 512;

        // Token: 0x04000011 RID: 17
        public const int LVM_GETHEADER = 4127;

        // Token: 0x04000012 RID: 18
        public const int HDM_GETITEM = 4619;

        // Token: 0x04000013 RID: 19
        public const int HDM_SETITEM = 4620;

        // Token: 0x02000005 RID: 5
        public struct LVCOLUMN
        {
            // Token: 0x04000014 RID: 20
            public int mask;

            // Token: 0x04000015 RID: 21
            public int cx;

            // Token: 0x04000016 RID: 22
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;

            // Token: 0x04000017 RID: 23
            public IntPtr hbm;

            // Token: 0x04000018 RID: 24
            public int cchTextMax;

            // Token: 0x04000019 RID: 25
            public int fmt;

            // Token: 0x0400001A RID: 26
            public int iSubItem;

            // Token: 0x0400001B RID: 27
            public int iImage;

            // Token: 0x0400001C RID: 28
            public int iOrder;
        }
    }

}
