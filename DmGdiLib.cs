using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DmGdiLib
{
    class GdiFunc
    {
        /* RasterOp For StretchBlt */
        enum RasterOp
        {
            SRCCOPY = 0x00CC0020, /* dest = source                   */
            SRCPAINT = 0x00EE0086, /* dest = source OR dest           */
            SRCAND = 0x008800C6, /* dest = source AND dest          */
            SRCINVERT = 0x00660046, /* dest = source XOR dest          */
            SRCERASE = 0x00440328, /* dest = source AND (NOT dest )   */
            NOTSRCCOPY = 0x00330008, /* dest = (NOT source)             */
            NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
            MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)     */
            MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest     */
            PATCOPY = 0x00F00021, /* dest = pattern                  */
            PATPAINT = 0x00FB0A09, /* dest = DPSnoo                   */
            PATINVERT = 0x005A0049, /* dest = pattern XOR dest         */
            DSTINVERT = 0x00550009, /* dest = (NOT dest)               */
            BLACKNESS = 0x00000042, /* dest = BLACK                    */
            WHITENESS = 0x00FF0062 /* dest = WHITE                    */
        };

        /* IMPORTS */
        [DllImport("user32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        internal static extern IntPtr ReleaseDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern bool StretchBlt(
              IntPtr hdcDest,      // handle to destination DC
              int nXOriginDest, // x-coord of destination upper-left corner
              int nYOriginDest, // y-coord of destination upper-left corner
              int nWidthDest,   // width of destination rectangle
              int nHeightDest,  // height of destination rectangle
              IntPtr hdcSrc,       // handle to source DC
              int nXOriginSrc,  // x-coord of source upper-left corner
              int nYOriginSrc,  // y-coord of source upper-left corner
              int nWidthSrc,    // width of source rectangle
              int nHeightSrc,   // height of source rectangle
              uint dwRop       // raster operation code
            );

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int Width, int Height);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hobj);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern bool DeleteObject(IntPtr hobj);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern int SetDIBitsToDevice(IntPtr hdc, int xdst, int ydst,
                                                int width, int height, int xsrc, int ysrc, int start, int lines,
                                                IntPtr bitsptr, IntPtr bmiptr, int color);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalLock(IntPtr handle);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern bool GlobalUnlock(IntPtr handle);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalFree(IntPtr handle);
    }
}
