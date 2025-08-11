using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;

namespace BOSERP.Utilities.Paint
{
    #region RECT

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public int width
        {
            get { return Math.Abs(this.right - this.left); }
        }

        public int height
        {
            get { return Math.Abs(this.bottom - this.top); }
        }

        public RECT(Rectangle rectangle)
        {
            this.left = rectangle.Left;
            this.right = rectangle.Right;
            this.top = rectangle.Top;
            this.bottom = rectangle.Bottom;
        }

        public RECT(int x, int y, int width, int height)
        {
            this.left = x;
            this.right = this.left + width;
            this.top = y;
            this.bottom = this.top + height;
        }

        public RECT(Point pt, Size size)
        {
            this.left = pt.X;
            this.right = pt.X + size.Width;
            this.top = pt.Y;
            this.bottom = pt.Y + size.Height;
        }

        public override string ToString()
        {
            return "{X=" + this.left.ToString() + ",Y=" + this.top.ToString() + ",Width=" + this.width.ToString() + ",Height=" + this.height.ToString() + "}";
        }

        public bool Contains(Point pt)
        {
            return WindowsAPI.PtInRect(ref this, pt);
        }

        public Size Size
        {
            get { return new Size(this.width, this.height); }
        }

        public Point Location
        {
            get { return new Point(this.left, this.top); }
        }

        public bool IsEmpty
        {
            get { return WindowsAPI.IsRectEmpty(ref this); }
        }

        public static implicit operator Rectangle(RECT rect)
        {
            return new Rectangle(rect.left, rect.top, rect.width, rect.height);
        }
    }

    #endregion

    #region LOGBRUSH

    [StructLayout(LayoutKind.Sequential)]
    public struct LOGBRUSH
    {
        public uint lbStyle;        //brush style
        public UInt32 lbColor;    //colorref RGB(...)
        public HatchStyle lbHatch;        //hatch style
    }

    #endregion

    #region API_const

    /// <summary>
    /// Windows API 
    /// </summary>
    public class CommonConst
    {
        #region PEN & BRUSH

        public const int WHITE_BRUSH = 0;
        public const int LTGRAY_BRUSH = 1;
        public const int GRAY_BRUSH = 2;
        public const int DKGRAY_BRUSH = 3;
        public const int BLACK_BRUSH = 4;
        public const int NULL_BRUSH = 5;
        public const int HOLLOW_BRUSH = NULL_BRUSH;
        public const int WHITE_PEN = 6;
        public const int BLACK_PEN = 7;
        public const int NULL_PEN = 8;
        public const int OEM_FIXED_FONT = 10;
        public const int ANSI_FIXED_FONT = 11;
        public const int ANSI_VAR_FONT = 12;
        public const int SYSTEM_FONT = 13;
        public const int DEVICE_DEFAULT_FONT = 14;
        public const int DEFAULT_PALETTE = 15;
        public const int SYSTEM_FIXED_FONT = 16;
        public const int DEFAULT_GUI_FONT = 17;
        public const int DC_BRUSH = 18;
        public const int DC_PEN = 19;

        #endregion

        public const int SRCCOPY = 0x00CC0020;
        public const int CAPTUREBLT = 0x40000000;

        #region PS

        public const int PS_SOLID = 0;
        public const int PS_DASH = 1;
        public const int PS_DOT = 2;
        public const int PS_DASHDOT = 3;
        public const int PS_DASHDOTDOT = 4;
        public const int PS_NULL = 5;
        public const int PS_INSIDEFRAME = 6;
        public const int PS_USERSTYLE = 7;
        public const int PS_ALTERNATE = 8;
        public const int PS_STYLE_MASK = 0xF;
        public const int PS_ENDCAP_ROUND = 0x0;
        public const int PS_ENDCAP_SQUARE = 0x100;
        public const int PS_ENDCAP_FLAT = 0x200;
        public const int PS_ENDCAP_MASK = 0xF00;
        public const int PS_JOIN_ROUND = 0x0;
        public const int PS_JOIN_BEVEL = 0x1000;
        public const int PS_JOIN_MITER = 0x2000;
        public const int PS_JOIN_MASK = 0xF000;
        public const int PS_COSMETIC = 0x0;
        public const int PS_GEOMETRIC = 0x10000;
        public const int PS_TYPE_MASK = 0xF0000;

        #endregion

        #region FLOODFILL

        public const uint FLOODFILLBORDER = 0;
        public const uint FLOODFILLSURFACE = 1;

        #endregion

        #region BDR

        public const int BDR_RAISEDOUTER = 0x1;
        public const int BDR_SUNKENOUTER = 0x2;
        public const int BDR_RAISEDINNER = 0x4;
        public const int BDR_SUNKENINNER = 0x8;

        #endregion

        #region EDGE

        public const int EDGE_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER);
        public const int EDGE_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER);
        public const int EDGE_ETCHED = (BDR_SUNKENOUTER | BDR_RAISEDINNER);
        public const int EDGE_BUMP = (BDR_RAISEDOUTER | BDR_SUNKENINNER);

        #endregion

        #region BF

        public const int BF_LEFT = 0x1;
        public const int BF_TOP = 0x2;
        public const int BF_RIGHT = 0x4;
        public const int BF_BOTTOM = 0x8;
        public const int BF_TOPLEFT = (BF_TOP | BF_LEFT);
        public const int BF_TOPRIGHT = (BF_TOP | BF_RIGHT);
        public const int BF_BOTTOMLEFT = (BF_BOTTOM | BF_LEFT);
        public const int BF_BOTTOMRIGHT = (BF_BOTTOM | BF_RIGHT);
        public const int BF_RECT = (BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM);
        public const int BF_DIAGONAL = 0x10;
        public const int BF_DIAGONAL_ENDTOPRIGHT = (BF_DIAGONAL | BF_TOP | BF_RIGHT);
        public const int BF_DIAGONAL_ENDTOPLEFT = (BF_DIAGONAL | BF_TOP | BF_LEFT);
        public const int BF_DIAGONAL_ENDBOTTOMLEFT = (BF_DIAGONAL | BF_BOTTOM | BF_LEFT);
        public const int BF_DIAGONAL_ENDBOTTOMRIGHT = (BF_DIAGONAL | BF_BOTTOM | BF_RIGHT);
        public const int BF_MIDDLE = 0x800;
        public const int BF_SOFT = 0x1000;
        public const int BF_ADJUST = 0x2000;
        public const int BF_FLAT = 0x4000;
        public const int BF_MONO = 0x8000;

        #endregion

        #region BS

        public const uint BS_SOLID = 0;
        public const uint BS_NULL = 1;
        public const uint BS_HOLLOW = BS_NULL;
        public const uint BS_HATCHED = 2;
        public const uint BS_PATTERN = 3;
        public const uint BS_INDEXED = 4;
        public const uint BS_DIBPATTERN = 5;
        public const uint BS_DIBPATTERNPT = 6;
        public const uint BS_PATTERN8X8 = 7;
        public const uint BS_DIBPATTERN8X8 = 8;

        #endregion

        #region DFC

        public const uint DFC_CAPTION = 1;
        public const uint DFC_MENU = 2;
        public const uint DFC_SCROLL = 3;
        public const uint DFC_BUTTON = 4;
        public const uint DFC_POPUPMENU = 5;

        #endregion

        #region DFCS

        public const uint DFCS_CAPTIONCLOSE = 0;
        public const uint DFCS_CAPTIONMIN = 1;
        public const uint DFCS_CAPTIONMAX = 2;
        public const uint DFCS_CAPTIONRESTORE = 3;
        public const uint DFCS_CAPTIONHELP = 4;

        public const uint DFCS_MENUARROW = 0;
        public const uint DFCS_MENUCHECK = 1;
        public const uint DFCS_MENUBULLET = 2;
        public const uint DFCS_MENUARROWRIGHT = 4;

        public const uint DFCS_SCROLLUP = 0;
        public const uint DFCS_SCROLLDOWN = 1;
        public const uint DFCS_SCROLLLEFT = 2;
        public const uint DFCS_SCROLLRIGHT = 3;
        public const uint DFCS_SCROLLCOMBOBOX = 5;
        public const uint DFCS_SCROLLSIZEGRIP = 8;
        public const uint DFCS_SCROLLSIZEGRIPRIGHT = 0x10;

        public const uint DFCS_BUTTONCHECK = 0;
        public const uint DFCS_BUTTONRADIOIMAGE = 1;
        public const uint DFCS_BUTTONRADIOMASK = 2;
        public const uint DFCS_BUTTONRADIO = 4;
        public const uint DFCS_BUTTON3STATE = 8;
        public const uint DFCS_BUTTONPUSH = 0x10;

        public const uint DFCS_INACTIVE = 0x100;
        public const uint DFCS_PUSHED = 0x200;
        public const uint DFCS_CHECKED = 0x400;
        public const uint DFCS_TRANSPARENT = 0x800;
        public const uint DFCS_HOT = 0x1000;
        public const uint DFCS_ADJUSTRECT = 0x2000;
        public const uint DFCS_FLAT = 0x4000;
        public const uint DFCS_MONO = 0x8000;

        #endregion

        #region GetDeviceCaps

        public const uint DRIVERVERSION = 0;
        public const uint TECHNOLOGY = 2;
        public const uint HORZSIZE = 4;
        public const uint VERTSIZE = 6;
        public const uint HORZRES = 8;
        public const uint VERTRES = 10;
        public const uint BITSPIXEL = 12;
        public const uint PLANES = 14;
        public const uint NUMBRUSHES = 16;
        public const uint NUMPENS = 18;
        public const uint NUMMARKERS = 20;
        public const uint NUMFONTS = 22;
        public const uint NUMCOLORS = 24;
        public const uint PDEVICESIZE = 26;
        public const uint CURVECAPS = 28;
        public const uint LINECAPS = 30;
        public const uint POLYGONALCAPS = 32;
        public const uint TEXTCAPS = 34;
        public const uint CLIPCAPS = 36;
        public const uint RASTERCAPS = 38;
        public const uint ASPECTX = 40;
        public const uint ASPECTY = 42;
        public const uint ASPECTXY = 44;
        public const uint SHADEBLENDCAPS = 45;
        public const uint LOGPIXELSX = 88;
        public const uint LOGPIXELSY = 90;
        public const uint SIZEPALETTE = 104;
        public const uint NUMRESERVED = 106;
        public const uint COLORRES = 108;
        public const uint PHYSICALWIDTH = 110;
        public const uint PHYSICALHEIGHT = 111;
        public const uint PHYSICALOFFSETX = 112;
        public const uint PHYSICALOFFSETY = 113;
        public const uint SCALINGFACTORX = 114;
        public const uint SCALINGFACTORY = 115;
        public const uint VREFRESH = 116;
        public const uint DESKTOPVERTRES = 117;
        public const uint DESKTOPHORZRES = 118;
        public const uint BLTALIGNMENT = 119;

        #endregion

        #region PT

        public const int PT_CLOSEFIGURE = 0x1;
        public const int PT_LINETO = 0x2;
        public const int PT_BEZIERTO = 0x4;
        public const int PT_MOVETO = 0x6;

        #endregion
    }

    #endregion

    public class WindowsAPI
    {
        #region SystemParametersInfo

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fuWinIni);

        #endregion

        #region IsRectEmpty

        [DllImport("user32.dll")]
        public static extern bool IsRectEmpty(ref RECT lprc);

        #endregion

        #region SelectObject

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        #endregion

        #region ReleaseDC

        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hDC);

        #endregion

        #region RoundRect

        [DllImport("gdi32.dll")]
        public static extern bool RoundRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidth, int nHeight);

        #endregion

        #region PtInRect

        [DllImport("user32.dll")]
        public static extern bool PtInRect(ref RECT lprc, Point pt);

        #endregion

        #region CreateSolidBrush 

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateSolidBrush(uint crColor);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateSolidBrush(int crColor);

        #endregion

        #region CreatePen 

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, int crColor);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, uint crColor);

        #endregion

        #region SelectClipPath

        [DllImport("gdi32.dll")]
        public static extern bool SelectClipPath(IntPtr hdc, int iMode);

        #endregion

        #region GetStockObject

        [DllImport("gdi32.dll")]
        public static extern IntPtr GetStockObject(int fnObject);

        #endregion

        #region SetDCPenColor

        [DllImport("gdi32.dll")]
        public static extern uint SetDCPenColor(IntPtr hdc, uint crColor);

        #endregion

        #region SetDCBrushColor

        [DllImport("gdi32.dll")]
        public static extern uint SetDCBrushColor(IntPtr hdc, uint crColor);

        #endregion

        #region BitBlt

        [DllImportAttribute("gdi32.dll")]
        public static extern bool BitBlt(
            IntPtr hdcDest,   //目标设备的句柄  
            int nXDest,   //   目标对象的左上角的X坐标  
            int nYDest,   //   目标对象的左上角的X坐标  
            int nWidth,   //   目标对象的矩形的宽度  
            int nHeight,   //   目标对象的矩形的长度  
            IntPtr hdcSrc,   //   源设备的句柄  
            int nXSrc,   //   源对象的左上角的X坐标  
            int nYSrc,   //   源对象的左上角的X坐标  
            uint dwRop   //   光栅的操作值  
            );

        #endregion

        #region CreateDC

        [DllImportAttribute("gdi32.dll")]
        public static extern IntPtr CreateDC(
            string lpszDriver,   //   驱动名称  
            string lpszDevice,   //   设备名称  
            string lpszOutput,   //   无用，可以设定位"NULL"  
            IntPtr lpInitData   //   任意的打印机数据  
            );

        #endregion

        #region GetPrivateProfileInt

        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

        #endregion

        #region GetPrivateProfileString

        [DllImport("kernel32.dll")]
        public static extern bool GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        #endregion

        #region GetPrivateProfileSection

        [DllImport("kernel32.dll")]
        public static extern bool GetPrivateProfileSection(string lpAppName, StringBuilder lpReturnedString, int nSize, string lpFileName);

        #endregion

        #region WritePrivateProfileString

        [DllImport("kernel32.dll")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        #endregion

        #region WritePrivateProfileSection

        [DllImport("kernel32.dll")]
        public static extern bool WritePrivateProfileSection(string lpAppName, string lpString, string lpFileName);

        #endregion

        #region WritePrivateProfileStruct

        [DllImport("kernel32.dll")]
        public static extern bool WritePrivateProfileStruct(string lpszSection, string lpszKey, StringBuilder lpStruct, uint uSizeStruct, string szFile);

        #endregion

        #region CreateCompatibleDC

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        #endregion

        #region CreateCompatibleBitmap

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        #endregion

        #region DeleteObject

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        #endregion

        #region Rectangle

        [DllImport("gdi32.dll")]
        public static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        #endregion

        #region Ellipse

        [DllImport("gdi32.dll")]
        public static extern bool Ellipse(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        #endregion

        #region Polygon

        [DllImport("gdi32.dll")]
        public static extern bool Polygon(IntPtr hdc, Point[] lpPoints, int nCount);

        [DllImport("gdi32.dll")]
        public static extern bool PolyPolygon(IntPtr hdc, Point[] lpPoints, int[] lpPolyCounts, int nCount);

        #endregion

        #region ExtCreatePen

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        public static extern IntPtr ExtCreatePen(uint dwPenStyle, uint dwWidth, [In] ref LOGBRUSH lplb, uint dwStyleCount, uint[] lpStyle);

        #endregion

        #region FloodFill

        [DllImport("gdi32.dll")]
        static extern bool FloodFill(IntPtr hdc, int nXStart, int nYStart, uint crFill);

        #endregion

        #region MoveToEx

        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr hdc, int X, int Y, ref Point lpPoint);

        #endregion

        #region GetPixel

        [DllImport("gdi32.dll")]
        public static extern int GetPixel(IntPtr hdc, int nXPos, int nYPos);

        #endregion

        #region LineTo

        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);

        #endregion

        #region ExtFloodFill 

        [DllImport("gdi32.dll")]
        public static extern bool ExtFloodFill(IntPtr hdc, int nXStart, int nYStart, uint crColor, uint fuFillType);

        [DllImport("gdi32.dll")]
        public static extern bool ExtFloodFill(IntPtr hdc, int nXStart, int nYStart, int crColor, uint fuFillType);

        #endregion

        #region DrawEdge

        [DllImport("user32.dll")]
        public static extern bool DrawEdge(IntPtr hdc, ref RECT qrc, uint edge, uint grfFlags);

        #endregion

        #region DrawFocusRect

        [DllImport("user32.dll")]
        public static extern bool DrawFocusRect(IntPtr hDC, [In] ref RECT lprc);

        #endregion

        #region CreateBrushIndirect

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateBrushIndirect([In] ref LOGBRUSH lplb);

        #endregion

        #region PolyBezier

        [DllImport("gdi32.dll")]
        public static extern bool PolyBezier(IntPtr hdc, Point[] lppt, uint cPoints);

        #endregion

        #region DrawFrameControl

        [DllImport("user32.dll")]
        public static extern bool DrawFrameControl(IntPtr hdc, [In] ref RECT lprc, uint uType, uint uState);

        #endregion

        #region SetPixel 

        [DllImport("gdi32.dll")]
        public static extern int SetPixel(IntPtr hdc, int X, int Y, int crColor);

        [DllImport("gdi32.dll")]
        public static extern int SetPixel(IntPtr hdc, int X, int Y, uint crColor);

        #endregion

        #region PolyBezierTo

        [DllImport("gdi32.dll")]
        public static extern bool PolyBezierTo(IntPtr hdc, Point[] lppt, uint cCount);

        #endregion

        #region GetDeviceCaps

        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        #endregion

        #region GetDC

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        #endregion

        #region GetDesktopWindow

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        #endregion


        #region RGB

        public static uint RGB(Color color)
        {
            byte byRed, byGreen, byBlue, RESERVED;

            byRed = color.R;
            byGreen = color.G;
            byBlue = color.B;
            RESERVED = 0;
            byte[] RGBCOLORS = new byte[4];
            RGBCOLORS[0] = byRed;
            RGBCOLORS[1] = byGreen;
            RGBCOLORS[2] = byBlue;
            RGBCOLORS[3] = RESERVED;
            return BitConverter.ToUInt32(RGBCOLORS, 0);
        }

        #endregion
    }

    public class Accessory
    {
        #region Set wallpaper

        /// <summary>
        /// Set wallpaper style
        /// </summary>
        public enum WPSTYLE
        {
            /// <summary>
            /// center
            /// </summary>
            CENTER = 0,
            /// <summary>
            /// Tile
            /// </summary>
            TILE = 1,
            /// <summary>
            /// Stretch
            /// </summary>
            STRETCH = 2,
            /// <summary>
            /// Maximize
            /// </summary>
            MAX = 3
        }

        private struct WALLPAPEROPT
        {
            public int dwSize;
            public WPSTYLE dwStyle;
        }

        private struct COMPONENTSOPT
        {
            public int dwSize;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fEnableComponents;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fActiveDesktop;
        }

        private struct COMPPOS
        {
            public const int COMPONENT_TOP = 0x3FFFFFFF;
            public const int COMPONENT_DEFAULT_LEFT = 0xFFFF;
            public const int COMPONENT_DEFAULT_TOP = 0xFFFF;

            public int dwSize;
            public int iLeft;
            public int iTop;
            public int dwWidth;
            public int dwHeight;
            public int izIndex;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fCanResize;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fCanResizeX;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fCanResizeY;
            public int iPreferredLeftPercent;
            public int iPreferredTopPercent;
        }

        [Flags]
        private enum ITEMSTATE
        {
            NORMAL = 0x00000001,
            FULLSCREEN = 00000002,
            SPLIT = 0x00000004,
            VALIDSIZESTATEBITS = NORMAL | SPLIT | FULLSCREEN,
            VALIDSTATEBITS = NORMAL | SPLIT | FULLSCREEN | unchecked((int)0x80000000) | 0x40000000
        }

        private struct COMPSTATEINFO
        {
            public int dwSize;
            public int iLeft;
            public int iTop;
            public int dwWidth;
            public int dwHeight;
            public int dwItemState;
        }

        private enum COMP_TYPE
        {
            HTMLDOC = 0,
            PICTURE = 1,
            WEBSITE = 2,
            CONTROL = 3,
            CFHTML = 4,
            MAX = 4
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct COMPONENT
        {
            private const int INTERNET_MAX_URL_LENGTH = 2084;   //   =   
            // INTERNET_MAX_SCHEME_LENGTH   (32)   +   "://\0".Length   +   
            // INTERNET_MAX_PATH_LENGTH   (2048)   

            public int dwSize;
            public int dwID;
            public COMP_TYPE iComponentType;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fChecked;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fDirty;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fNoScroll;
            public COMPPOS cpPos;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string wszFriendlyName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = INTERNET_MAX_URL_LENGTH)]
            public string wszSource;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = INTERNET_MAX_URL_LENGTH)]
            public string wszSubscribedURL;

#if   AD_IE5   
      public   int   dwCurItemState;   
      public   COMPSTATEINFO   csiOriginal;   
      public   COMPSTATEINFO   csiRestored;   
#endif
        }

        private enum DTI_ADTIWUI
        {
            DTI_ADDUI_DEFAULT = 0x00000000,
            DTI_ADDUI_DISPSUBWIZARD = 0x00000001,
            DTI_ADDUI_POSITIONITEM = 0x00000002,
        }

        [Flags]
        private enum AD_APPLY
        {
            SAVE = 0x00000001,
            HTMLGEN = 0x00000002,
            REFRESH = 0x00000004,
            ALL = SAVE | HTMLGEN | REFRESH,
            FORCE = 0x00000008,
            BUFFERED_REFRESH = 0x00000010,
            DYNAMICREFRESH = 0x00000020
        }

        [Flags]
        private enum COMP_ELEM
        {
            TYPE = 0x00000001,
            CHECKED = 0x00000002,
            DIRTY = 0x00000004,
            NOSCROLL = 0x00000008,
            POS_LEFT = 0x00000010,
            POS_TOP = 0x00000020,
            SIZE_WIDTH = 0x00000040,
            SIZE_HEIGHT = 0x00000080,
            POS_ZINDEX = 0x00000100,
            SOURCE = 0x00000200,
            FRIENDLYNAME = 0x00000400,
            SUBSCRIBEDURL = 0x00000800,
            ORIGINAL_CSI = 0x00001000,
            RESTORED_CSI = 0x00002000,
            CURITEMSTATE = 0x00004000,
            ALL = TYPE | CHECKED | DIRTY | NOSCROLL | POS_LEFT | SIZE_WIDTH |
                SIZE_HEIGHT | POS_ZINDEX | SOURCE |
                FRIENDLYNAME | POS_TOP | SUBSCRIBEDURL | ORIGINAL_CSI |
                RESTORED_CSI | CURITEMSTATE
        }

        [Flags]
        private enum ADDURL
        {
            SILENT = 0x0001
        }

        [
            ComImport(),
            Guid("F490EB00-1240-11D1-9888-006097DEACF9"),
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
        ]
        private interface IActiveDesktop
        {
            void ApplyChanges(AD_APPLY dwFlags);
            void GetWallpaper([MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder pwszWallpaper, int cchWallpaper, int dwReserved);
            void SetWallpaper([MarshalAs(UnmanagedType.LPWStr)]   string pwszWallpaper, int dwReserved);
            void GetWallpaperOptions(ref   WALLPAPEROPT pwpo, int dwReserved);
            void SetWallpaperOptions([In]   ref   WALLPAPEROPT pwpo, int dwReserved);
            void GetPattern([MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder pwszPattern, int cchPattern, int dwReserved);
            void SetPattern([MarshalAs(UnmanagedType.LPWStr)]   string pwszPattern, int dwReserved);
            void GetDesktopItemOptions(ref   COMPONENTSOPT pco, int dwReserved);
            void SetDesktopItemOptions([In]   ref   COMPONENTSOPT pco, int dwReserved);
            void AddDesktopItem([In]   ref   COMPONENT pcomp, int dwReserved);
            void AddDesktopItemWithUI(IntPtr hwnd, [In]   ref   COMPONENT pcomp, DTI_ADTIWUI dwFlags);
            void ModifyDesktopItem([In]   ref   COMPONENT pcomp, COMP_ELEM dwFlags);
            void RemoveDesktopItem([In]   ref   COMPONENT pcomp, int dwReserved);
            void GetDesktopItemCount(out   int lpiCount, int dwReserved);
            void GetDesktopItem(int nComponent, ref   COMPONENT pcomp, int dwReserved);
            void GetDesktopItemByID(IntPtr dwID, ref   COMPONENT pcomp, int dwReserved);
            void GenerateDesktopItemHtml([MarshalAs(UnmanagedType.LPWStr)] string pwszFileName, [In]   ref   COMPONENT pcomp, int dwReserved);
            void AddUrl(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)]   string pszSource, [In]   ref   COMPONENT pcomp, ADDURL dwFlags);
            void GetDesktopItemBySource([MarshalAs(UnmanagedType.LPWStr)]  string pwszSource, ref   COMPONENT pcomp, int dwReserved);
        }

        [
            ComImport(),
            Guid("75048700-EF1F-11D0-9888-006097DEACF9")
        ]
        private class ActiveDesktop   /*   :   IActiveDesktop   */   { }

        /// <summary>
        /// Set wallpaper。AdditionalMethod.SetWallpaper(@"C:\Windows\Web\Wallpaper\\C03.jpg", AdditionalMethod.WPSTYLE.STRETCH);
        /// </summary>
        /// <param name="path"></param>
        /// <param name="wps"></param>
        public static void SetWallpaper(string path, WPSTYLE wps)
        {
            if (File.Exists(path))
            {
                ActiveDesktop ad = new ActiveDesktop();
                IActiveDesktop iad = ad as IActiveDesktop;

                if (iad != null)
                {
                    WALLPAPEROPT wp = new WALLPAPEROPT();
                    wp.dwSize = Marshal.SizeOf(wp);
                    wp.dwStyle = wps;
                    iad.SetWallpaperOptions(ref wp, 0);
                    iad.SetWallpaper(path, 0);
                    iad.ApplyChanges(AD_APPLY.ALL);
                    Marshal.ReleaseComObject(ad);
                    ad = null;
                }
            }
        }

        #endregion

        #region WriteINI

        /// <summary>
        /// Write INI file
        /// </summary>
        /// <param name="option"></param>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        /// <param name="path"></param>
        public static void WritePrivateProfileString(string option, object[] caption, object[] text, string path)
        {
            int i;
            for (i = 0; i < text.Length; i++)
            {
                WindowsAPI.WritePrivateProfileString(option, caption[i].ToString(), text[i].ToString(), path);
            }
        }

        /// <summary>
        /// Write INI file
        /// </summary>
        /// <param name="option"></param>
        /// <param name="text"></param>
        /// <param name="path"></param>
        public static void WritePrivateProfileSection(string option, string text, string path)
        {
            WindowsAPI.WritePrivateProfileSection(option, text, path);
        }

        #endregion

        #region GetINI

        /// <summary>
        /// INI files for the information, the return string type
        /// </summary>
        /// <param name="option"></param>
        /// <param name="caption"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetPrivateProfileStrings(string option, object[] caption, string path)
        {
            StringBuilder sb = new StringBuilder(32767);
            int i;
            ArrayList list = new ArrayList();
            for (i = 0; i < caption.Length; i++)
            {
                WindowsAPI.GetPrivateProfileString(option, caption[i].ToString(), "", sb, sb.Capacity, path);
                list.Add(sb.ToString());
            }
            return (string[])list.ToArray(typeof(string));
        }

        public static string GetPrivateProfileString(string option, object caption, string path)
        {
            StringBuilder sb = new StringBuilder(32767);
            WindowsAPI.GetPrivateProfileString(option, caption.ToString(), "", sb, sb.Capacity, path);
            return sb.ToString();
        }

        /// <summary>
        /// INI files for the information, the return type of uint
        /// </summary>
        /// <param name="option"></param>
        /// <param name="caption"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static uint[] GetPrivateProfileInt(string option, object[] caption, string path)
        {
            int i;
            ArrayList list = new ArrayList();
            for (i = 0; i < caption.Length; i++)
            {
                list.Add(WindowsAPI.GetPrivateProfileInt(option, caption[i].ToString(), 0, path));
            }
            int count = list.Count;
            uint[] ii = new uint[count];
            Array.Copy(list.ToArray(), ii, count);
            return ii;
        }

        /// <summary>
        /// INI files for the information, the return string type
        /// </summary>
        /// <param name="option"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetPrivateProfileSection(string option, string path)
        {
            StringBuilder sb = new StringBuilder(32767);
            WindowsAPI.GetPrivateProfileSection(option, sb, sb.Capacity, path);
            return sb.ToString();
        }

        #endregion

        #region PixelToCentimeter

        /// <summary>
        /// Pixels transferred cm
        /// </summary>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static double PixelToCentimeterH(double pixel)
        {
            int horzres = WindowsAPI.GetDeviceCaps(WindowsAPI.GetDC(WindowsAPI.GetDesktopWindow()), (int)CommonConst.HORZRES);
            int horzsize = WindowsAPI.GetDeviceCaps(WindowsAPI.GetDC(WindowsAPI.GetDesktopWindow()), (int)CommonConst.HORZSIZE);
            double cm = horzres * 10.0 / horzsize;
            cm = pixel / cm;
            return cm;
        }

        /// <summary>
        /// Pixels transferred cm
        /// </summary>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static double PixelToCentimeterV(double pixel)
        {
            int vertres = WindowsAPI.GetDeviceCaps(WindowsAPI.GetDC(WindowsAPI.GetDesktopWindow()), (int)CommonConst.VERTRES);
            int vertsize = WindowsAPI.GetDeviceCaps(WindowsAPI.GetDC(WindowsAPI.GetDesktopWindow()), (int)CommonConst.VERTSIZE);
            double cm = vertres * 10.0 / vertsize;
            cm = pixel / cm;
            return cm;
        }

        #endregion

        #region PixelToInch

        /// <summary>
        /// Switch to inch pixels
        /// </summary>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static double PixelToInchH(double pixel)
        {
            double cm = PixelToCentimeterH(pixel);
            double inch = cm / 2.54;
            return inch;
        }

        /// <summary>
        /// Switch to inch pixels
        /// </summary>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static double PixelToInchV(double pixel)
        {
            double cm = PixelToCentimeterV(pixel);
            double inch = cm / 2.54;
            return inch;
        }

        #endregion
    }
}