using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BOSERP.Utilities.Paint;
using BOSERP.UI.Paint;
using Localization;
using System.Drawing.Drawing2D;

namespace BOSERP
{
    public partial class Canvas : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// Gets directions when user resize
        /// </summary>
        private enum ResizeType { SizeNS, SizeNWSE, SizeWE, None }

        #region Constant
        /// <summary>
        /// Font type of text on image
        /// </summary>
        private const string FontFamily = "Arial";
        private const string ConvertRtfPath = @"C:\rtf.jpg";
        #endregion

        #region Variable
        private ResizeType ResizeShape;
        private Cursor CurPanel;
        /// <summary>
        /// Style in the mouse on the picturebox
        /// </summary>
        private Cursor CurPictureBox;
        /// <summary>
        /// New image size value
        /// </summary>
        private Size NewSize;
        private Cursor[] Icons;
        //Small rectangle drawing
        private Rectangle Rc1;
        private Rectangle Rc2;
        private Rectangle Rc3;
        private Rectangle Rc4;
        private Rectangle Rc5;
        private Rectangle Rc6;
        private Rectangle Rc7;
        private Rectangle Rc8;
        
        private Pen PenSize = new Pen(Color.Gray);
        /// <summary>
        /// Gets or sets starting point
        /// </summary>
        private Point StartingPoint = Point.Empty;
        private bool Cancel = false;
        /// <summary>
        /// Check exist of text input
        /// </summary>
        private bool CheckInput = false;

        private RichTextBox InputText = new RichTextBox();
        private RichTextBox RtbTemp = new RichTextBox();
        private float FontSize = 0;
        private Color FontColor = Color.Black;
        /// <summary>
        /// default percent of zoom
        /// </summary>
        private int Percent = 10;
        #endregion

        #region public properties
        public DrawShape DrawShape { get; set; }
        public bool MouseDown { get; set; }
        public Size CustomeSize { get; set; }
        public guiPaint PaintForm { get; set; }

        /// <summary>
        /// Setting the canvas
        /// </summary>
        public Image PaintImage
        {
            get { return CanvasPaint.Image; }
            set { CanvasPaint.Image = value; }
        }
        /// <summary>
        /// Set the graphics
        /// </summary>
        public DrawShape.ShapeType ShapeType { get; set; }

        public Color PenColor
        {
            set { DrawShape.Pen.Color = value; }
        }

        public Color BrushColor
        {
            set { DrawShape.Brush = new SolidBrush(value); DrawShape.Brushcolor = value; }
        }
        /// <summary>
        /// Gets or sets selection font style. True if font style is bold, otherwise, false.
        /// </summary>
        public bool IsBold { get; set; }
        /// <summary>
        /// Gets or sets selection font style. True if font style is italic, otherwise, false.
        /// </summary>
        public bool IsItalic { get; set; }
        /// <summary>
        /// Gets or sets selection font style. True if font style is underline, otherwise, false.
        /// </summary>
        public bool IsUnderline { get; set; }
        #endregion

        #region Constructor
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);

        public Canvas()
        {
            InitializeComponent();
            CustomeSize = new Size(480, 331);

            Icons = new Cursor[] 
            {
                GetFileCursor((Path.GetDirectoryName(Application.ExecutablePath) + "\\res\\cross2.cur")),
                GetFileCursor((Path.GetDirectoryName(Application.ExecutablePath) + "\\res\\cross3.cur")),
                GetFileCursor((Path.GetDirectoryName(Application.ExecutablePath) + "\\res\\pickcolor.cur")),
                GetFileCursor((Path.GetDirectoryName(Application.ExecutablePath) + "\\res\\fillcolor.cur")),
                GetFileCursor((Path.GetDirectoryName(Application.ExecutablePath) + "\\res\\Pencil.cur")),
                GetFileCursor((Path.GetDirectoryName(Application.ExecutablePath) + "\\res\\magnifier.cur")),
                GetFileCursor((Path.GetDirectoryName(Application.ExecutablePath) + "\\res\\airBrush.cur"))
            };
            CurPictureBox = Icons[4];
            Rc1 = new Rectangle(0, 0, 3, 3);
            PenSize.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            AutoScrollMargin = new Size(3, 3);
            MouseDown = false;
            InputText.BorderStyle = BorderStyle.None;
            InputText.WordWrap = false;
            InputText.SelectionChanged += new EventHandler(InputText_SelectionChanged);

            Initial();
        }

        #endregion

        #region Main

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Size sz = new Size(3, 3);
            Point pt = new Point(0, 0);
            pt.X -= this.HorizontalScroll.Value;
            pt.Y -= this.VerticalScroll.Value;
            Rc1 = new Rectangle(pt, sz);

            pt = new Point(CanvasPaint.Width / 2, 0);
            pt.X -= this.HorizontalScroll.Value;
            pt.Y -= this.VerticalScroll.Value;
            Rc2 = new Rectangle(pt, sz);

            pt = new Point(CanvasPaint.Width + 3, 0);
            pt.X -= this.HorizontalScroll.Value;
            pt.Y -= this.VerticalScroll.Value;
            Rc3 = new Rectangle(pt, sz);

            pt = new Point(0, CanvasPaint.Height / 2);
            pt.X -= this.HorizontalScroll.Value;
            pt.Y -= this.VerticalScroll.Value;
            Rc4 = new Rectangle(pt, sz);

            pt = new Point(0, CanvasPaint.Height + 3);
            pt.X -= this.HorizontalScroll.Value;
            pt.Y -= this.VerticalScroll.Value;
            Rc5 = new Rectangle(pt, sz);

            pt = new Point(CanvasPaint.Width / 2, CanvasPaint.Height + 3);
            pt.X -= this.HorizontalScroll.Value;
            pt.Y -= this.VerticalScroll.Value;
            Rc6 = new Rectangle(pt, sz);

            pt = new Point(CanvasPaint.Width + 3, CanvasPaint.Height + 3);
            pt.X -= this.HorizontalScroll.Value;
            pt.Y -= this.VerticalScroll.Value;
            Rc7 = new Rectangle(pt, sz);

            pt = new Point(CanvasPaint.Width + 3, CanvasPaint.Height / 2);
            pt.X -= this.HorizontalScroll.Value;
            pt.Y -= this.VerticalScroll.Value;
            Rc8 = new Rectangle(pt, sz);

            e.Graphics.FillRectangle(Brushes.White, Rc1);
            e.Graphics.FillRectangle(Brushes.White, Rc2);
            e.Graphics.FillRectangle(Brushes.White, Rc3);

            e.Graphics.FillRectangle(Brushes.White, Rc4);
            e.Graphics.FillRectangle(Brushes.White, Rc5);

            e.Graphics.FillRectangle(Brushes.Blue, Rc6);
            e.Graphics.FillRectangle(Brushes.Blue, Rc7);
            e.Graphics.FillRectangle(Brushes.Blue, Rc8);
        }

        public void Initial()
        {
            CanvasPaint.Image = DrawShape.CreateBitmap(CustomeSize, Color.White);
            if (CanvasPaint.Size != CustomeSize)
                CanvasPaint.Size = CustomeSize;
            DrawShape = new DrawShape(CanvasPaint.Image);
            DrawShape.Pen = new Pen(Color.Black);
            DrawShape.Brush = Brushes.White;
            DrawShape.UndoEvent += new DrawShape.UndoEventHandler(DrawShape_UndoEvent);
            DrawShape.RedoEvent += new DrawShape.UndoEventHandler(DrawShape_RedoEvent);
            Invalidate();
        }

        public void ChangeBackgroundImage(string path)
        {
            Bitmap bmp = new Bitmap(path);
            CanvasPaint.Image = bmp;
            CanvasPaint.Size = bmp.Size;
            Pen oldPen = (Pen)DrawShape.Pen.Clone();
            Brush oldBrush = (Brush)DrawShape.Brush.Clone();
            DrawShape = new DrawShape(CanvasPaint.Image);
            DrawShape.Pen = (Pen)oldPen.Clone();
            DrawShape.Brush = (Brush)oldBrush.Clone();
            DrawShape.UndoEvent += new DrawShape.UndoEventHandler(DrawShape_UndoEvent);
            DrawShape.RedoEvent += new DrawShape.UndoEventHandler(DrawShape_RedoEvent);
            PaintForm.Text = Path.GetFileName(path) + " - Paint";
            PaintForm.openFileDialog1.FileName = path;
            PaintForm.WriteRecent(path);
            DrawShape.Saved = true;
            PaintForm.CurrentFilePath = path;
            PaintForm.EnableSetWallpaper = true;
            Invalidate();
        }

        public void ClearBackgroundImage()
        {
            CanvasPaint.Image = DrawShape.CreateBitmap(CanvasPaint.Size, DrawShape.Brushcolor);
            ChangeBackgroundImage((Bitmap)CanvasPaint.Image);
        }

        public void ChangeBackgroundImage(Bitmap bitmap)
        {
            CanvasPaint.Image = bitmap;
            CanvasPaint.Size = bitmap.Size;
            Pen oldPen = (Pen)DrawShape.Pen.Clone();
            Brush oldBrush = (Brush)DrawShape.Brush.Clone();
            DrawShape = new DrawShape(CanvasPaint.Image);
            DrawShape.Pen = (Pen)oldPen.Clone();
            DrawShape.Brush = (Brush)oldBrush.Clone();
            DrawShape.UndoEvent += new DrawShape.UndoEventHandler(DrawShape_UndoEvent);
            DrawShape.RedoEvent += new DrawShape.UndoEventHandler(DrawShape_RedoEvent);
            Invalidate();
        }

        private void DrawShape_UndoEvent(object sender, EventArgs e)
        {
            CanvasPaint.Image = DrawShape.ImageDrew;
            CanvasPaint.Size = new Size(CanvasPaint.Image.Width, CanvasPaint.Image.Height);
            Invalidate();
        }

        public void DrawShape_RedoEvent(object sender, EventArgs e)
        {
            CanvasPaint.Image = DrawShape.ImageDrew;
            CanvasPaint.Size = new Size(CanvasPaint.Image.Width, CanvasPaint.Image.Height);
            Invalidate();
        }

        /// <summary>
        /// Replacement of the mouse style
        /// </summary>
        /// <param name="shape"></param>
        public void GetCursorStyle(DrawShape.ShapeType shape)
        {
            switch (shape)
            {
                case DrawShape.ShapeType.Arrow:
                    {
                        break;
                    }
                case DrawShape.ShapeType.Text:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
                case DrawShape.ShapeType.Ellipse:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
                case DrawShape.ShapeType.Eraser:
                    {
                        Bitmap bitmap = DrawShape.CreateBitmap(DrawShape.EraserSize, DrawShape.EraserSize, Color.White);
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, bitmap.Size.Width - 1, bitmap.Size.Width - 1));
                        g.Dispose();
                        CurPictureBox = new Cursor(Icon.FromHandle(bitmap.GetHicon()).Handle);
                        break;
                    }
                case DrawShape.ShapeType.Line:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
                case DrawShape.ShapeType.Curve:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
                case DrawShape.ShapeType.Pencil:
                    {
                        CurPictureBox = Icons[4];
                        break;
                    }
                case DrawShape.ShapeType.Polygon:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
                case DrawShape.ShapeType.Rectangle:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
                case DrawShape.ShapeType.RoundedRectangle:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
                case DrawShape.ShapeType.AirBrush:
                    {
                        CurPictureBox = Icons[6];
                        break;
                    }
                case DrawShape.ShapeType.Brush:
                    {
                        CurPictureBox = Icons[0];
                        break;
                    }
                case DrawShape.ShapeType.FillWithColor:
                    {
                        CurPictureBox = Icons[3];
                        break;
                    }
                case DrawShape.ShapeType.FreeSelect:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
                case DrawShape.ShapeType.Magnifier:
                    {
                        CurPictureBox = Icons[5];
                        break;
                    }
                case DrawShape.ShapeType.PickColor:
                    {
                        CurPictureBox = Icons[2];
                        break;
                    }
                case DrawShape.ShapeType.Select:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
                case DrawShape.ShapeType.Zoom:
                    {
                        CurPictureBox = Icons[5];
                        Percent = 10;
                        break;
                    }
                case DrawShape.ShapeType.Rotate:
                    {
                        CurPictureBox = Icons[1];
                        break;
                    }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            DrawShape.Shift = e.Shift;
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            DrawShape.Shift = false;
            base.OnKeyUp(e);
        }

        public Cursor GetFileCursor(string file)
        {
            Cursor cursor = new Cursor(Cursor.Current.Handle);
            IntPtr colorCursorHandle = LoadCursorFromFile(file);
            cursor.GetType().InvokeMember("handle", System.Reflection.BindingFlags.Public |
              System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance |
              System.Reflection.BindingFlags.SetField, null, cursor,
              new object[] { colorCursorHandle });
            return cursor;
        }

        #endregion

        #region Control-related

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Rectangle rc = new Rectangle(CanvasPaint.Width / 2, CanvasPaint.Height + 3, 3, 3);
            rc.X -= this.HorizontalScroll.Value;
            rc.Y -= this.VerticalScroll.Value;
            if (rc.Contains(e.Location))
                MouseDown = true;
            rc = new Rectangle(CanvasPaint.Width + 3, CanvasPaint.Height + 3, 3, 3);
            rc.X -= this.HorizontalScroll.Value;
            rc.Y -= this.VerticalScroll.Value;
            if (rc.Contains(e.Location))
                MouseDown = true;
            rc = new Rectangle(CanvasPaint.Width + 3, CanvasPaint.Height / 2, 3, 3);
            rc.X -= this.HorizontalScroll.Value;
            rc.Y -= this.VerticalScroll.Value;
            if (rc.Contains(e.Location))
                MouseDown = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!MouseDown)
            {
                Rectangle rc = new Rectangle(CanvasPaint.Width / 2, CanvasPaint.Height + 3, 3, 3);
                rc.X -= this.HorizontalScroll.Value;
                rc.Y -= this.VerticalScroll.Value;
                bool contain = false;
                ResizeShape = ResizeType.None;
                if (rc.Contains(e.Location))
                {
                    CurPanel = Cursors.SizeNS;
                    contain = true;
                    ResizeShape = ResizeType.SizeNS;
                }
                else
                    CurPanel = Cursors.Default;
                rc = new Rectangle(CanvasPaint.Width + 3, CanvasPaint.Height + 3, 3, 3);
                rc.X -= this.HorizontalScroll.Value;
                rc.Y -= this.VerticalScroll.Value;
                if (rc.Contains(e.Location))
                {
                    CurPanel = Cursors.SizeNWSE;
                    contain = true;
                    ResizeShape = ResizeType.SizeNWSE;
                }
                else if (!contain)
                    CurPanel = Cursors.Default;
                rc = new Rectangle(CanvasPaint.Width + 3, CanvasPaint.Height / 2, 3, 3);
                rc.X -= this.HorizontalScroll.Value;
                rc.Y -= this.VerticalScroll.Value;
                if (rc.Contains(e.Location))
                {
                    CurPanel = Cursors.SizeWE;
                    contain = true;
                    ResizeShape = ResizeType.SizeWE;
                }
                else if (!contain)
                    CurPanel = Cursors.Default;
            }

            Cursor = CurPanel;

            if (MouseDown)
            {
                switch (ResizeShape)
                {
                    case ResizeType.SizeNS:
                        {
                            NewSize = new Size(CanvasPaint.Width, e.Y - 3);
                            Refresh();

                            Bitmap bmp = new Bitmap(this.Width, this.Height);
                            Graphics g = Graphics.FromImage(bmp);
                            Pen Pen = new Pen(Color.Gray);
                            Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            if (CanvasPaint.Bounds.Contains(e.Location))
                                g.DrawRectangle(Pen, new Rectangle(new Point(0, 0), new Size(NewSize.Width - 1, NewSize.Height)));
                            else
                                g.DrawRectangle(Pen, new Rectangle(new Point(3, 3), NewSize));
                            g.Dispose();
                            bmp.MakeTransparent();
                            if (CanvasPaint.Bounds.Contains(e.Location))
                                g = CanvasPaint.CreateGraphics();
                            else
                                g = CreateGraphics();
                            g.DrawImage(bmp, new Point(0, 0));
                            g.Dispose();
                            guiPaint.CanvasSizeStatus.Text = (CanvasPaint.Size.Width) + "x" + (e.Y - 3);
                            break;
                        }
                    case ResizeType.SizeNWSE:
                        {
                            NewSize = new Size(e.X - 3, e.Y - 3);
                            Refresh();

                            Bitmap bmp = new Bitmap(this.Width, this.Height);
                            Graphics g = Graphics.FromImage(bmp);
                            Pen Pen = new Pen(Color.Gray);
                            Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            if (CanvasPaint.Bounds.Contains(e.Location))
                                g.DrawRectangle(Pen, new Rectangle(new Point(0, 0), new Size(NewSize.Width, NewSize.Height - 1)));
                            else
                                g.DrawRectangle(Pen, new Rectangle(new Point(2, 2), new Size(NewSize.Width, NewSize.Height + 1)));
                            g.Dispose();
                            bmp.MakeTransparent();
                            if (CanvasPaint.Bounds.Contains(e.Location))
                                g = CanvasPaint.CreateGraphics();
                            else
                                g = CreateGraphics();
                            g.DrawImage(bmp, new Point(0, 0));
                            g.Dispose();
                            guiPaint.CanvasSizeStatus.Text = (e.X - 3) + "x" + (e.Y - 3);
                            break;
                        }
                    case ResizeType.SizeWE:
                        {
                            NewSize = new Size(e.X - 3, CanvasPaint.Height);
                            Refresh();

                            Bitmap bmp = new Bitmap(this.Width, this.Height);
                            Graphics g = Graphics.FromImage(bmp);
                            Pen Pen = new Pen(Color.Gray);
                            Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            if (CanvasPaint.Bounds.Contains(e.Location))
                                g.DrawRectangle(Pen, new Rectangle(new Point(0, 0), new Size(NewSize.Width, NewSize.Height - 1)));
                            else
                                g.DrawRectangle(Pen, new Rectangle(new Point(2, 2), new Size(NewSize.Width, NewSize.Height + 1)));
                            g.Dispose();
                            bmp.MakeTransparent();
                            if (CanvasPaint.Bounds.Contains(e.Location))
                                g = CanvasPaint.CreateGraphics();
                            else
                                g = CreateGraphics();
                            g.DrawImage(bmp, new Point(0, 0));
                            g.Dispose();
                            guiPaint.CanvasSizeStatus.Text = (e.X - 3) + "x" + (CanvasPaint.Size.Height);
                            break;
                        }
                }
            }
            guiPaint.LocationStatus.Text = "";
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (MouseDown)
            {
                MouseDown = false;
                Bitmap bitmap = DrawShape.CreateBitmap(NewSize, DrawShape.Brushcolor);
                CanvasPaint.Size = new Size(NewSize.Width, NewSize.Height);
                bitmap = DrawShape.CombineBitmap(bitmap, CanvasPaint.Image, new Point(0, 0));
                CanvasPaint.Image = bitmap;
                DrawShape.ImageStatus = DrawShape.ImageDrew = bitmap;
                Invalidate();
                DrawShape.DrawGDI(DrawShape.ShapeType.Resize, Point.Empty, Point.Empty, true, true);
            }
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            Invalidate();
            base.OnScroll(se);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
            if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
            {
                drgevent.Effect = DragDropEffects.All;
            }
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            string text = PaintForm.Text;
            DialogResult dr = DialogResult.Cancel;
            if (!DrawShape.Saved)
            {
                if (PaintForm.SaveDialog.IsDisposed)
                    PaintForm.SaveDialog = new SaveDialog();
                dr = PaintForm.SaveDialog.ShowDialog();
            }
            if (dr == DialogResult.OK || DrawShape.Saved)
            {
                string path = ((System.Array)drgevent.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                ChangeBackgroundImage(path);
            }
            else
                PaintForm.Text = text;
            base.OnDragDrop(drgevent);
        }

        #endregion

        #region Drawing

        private void CanvasPaint_MouseDown(object sender, MouseEventArgs e)
        {
            Cancel = false;
            // Finish polygon when user right click
            if (e.Button == MouseButtons.Right)
            {
                if (DrawShape.ShapeType.Polygon == ShapeType)
                {
                    FinishPolygon();
                }
                // Zoom out image
                if (ShapeType == DrawShape.ShapeType.Zoom)
                {
                    Percent--;
                    ChangeBackgroundImage((Bitmap)ZoomImage(guiPaint.OriginalImage, 10 * Percent));
                }
            }

            if (SystemInformation.MouseButtonsSwapped)
            {
                if (e.Button != MouseButtons.Right)
                    return;
            }
            else
            {
                if (e.Button != MouseButtons.Left)
                    return;
            }
            MouseDown = true;
            StartingPoint = e.Location;

            if (!PaintForm.EnableSetWallpaper)
                PaintForm.EnableSetWallpaper = true;
            if (DrawShape.ShapeType.Polygon == ShapeType)
            {
                if (Point.Empty == DrawShape.Ps)
                {
                    DrawShape.Ps = e.Location;
                    DrawShape.PsBack = e.Location;
                }
                if (DrawShape.EraserPolygonPath.PointCount == 0)
                {
                    DrawShape.ImageCurve = (Image)DrawShape.ImageStatus.Clone();
                    DrawShape.DrawGDI(ShapeType, DrawShape.Ps, e.Location, false, false);
                }
                else
                    DrawShape.DrawGDI(ShapeType, DrawShape.Ps, e.Location, false, false);
                DrawShape.Ps = e.Location;
                CanvasPaint.Image = DrawShape.ImageDrew;
                Cancel = true;
            }
            if (DrawShape.ShapeType.Eraser == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, e.Location, true, true);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Pencil == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, e.Location, false, true);
                StartingPoint = e.Location;
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.AirBrush == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, e.Location, false, true);
                StartingPoint = e.Location;
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Brush == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, e.Location, true, true);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.FillWithColor == ShapeType)
            {
                int ft = DrawShape.Fill;
                DrawShape.Fill = 0;
                DrawShape.DrawGDI(ShapeType, StartingPoint, e.Location, true, true);
                DrawShape.Fill = ft;
                CanvasPaint.Image = DrawShape.ImageDrew;
            }

            else if (DrawShape.ShapeType.Curve == ShapeType)
            {
                if (Point.Empty == DrawShape.CurveStartPt)
                {
                    DrawShape.ImageCurve = (Image)DrawShape.ImageStatus.Clone();
                    DrawShape.CurveStartPt = e.Location;
                }
                else if (Point.Empty == DrawShape.CurveMidPt1)
                {
                    DrawShape.CurveMidPt1 = e.Location;
                }
                else if (Point.Empty == DrawShape.CurveMidPt2)
                {
                    DrawShape.CurveMidPt1 = new Point(e.Location.X, DrawShape.CurveMidPt1.Y);
                    DrawShape.CurveMidPt2 = new Point(e.Location.X + 10, e.Location.Y + 10);
                }
                Cancel = true;
            }

            else if (DrawShape.ShapeType.Text == ShapeType)
            {
                
            }

            else if (DrawShape.ShapeType.Select == ShapeType)
            {
                if (DrawShape.IsInSelectedArea(e.Location))
                {
                    DrawShape.MoveSelectedAreaEnable = new DrawShape.MoveSelectedPoint()
                    {
                        Enable = true,
                        StartPoint = e.Location
                    };
                }
                else
                {
                    DrawShape.MoveSelectedAreaEnable = new DrawShape.MoveSelectedPoint()
                    {
                        Enable = false,
                        StartPoint = e.Location
                    };
                    DrawShape.DeSelectArea();
                    CanvasPaint.Image = DrawShape.ImageDrew;
                }
            }

            else if(ShapeType == DrawShape.ShapeType.Zoom)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Percent++;
                    ChangeBackgroundImage((Bitmap)ZoomImage(guiPaint.OriginalImage, 10 * Percent));
                }
            }

            Point pt = new Point(e.Location.X - 8, e.Location.Y + 3);
            this.Text = pt.ToString();
            if (DrawShape.ShapeType.PickColor == ShapeType)
            {
                //OnPickColorChanged(new PickedColor((new Bitmap(this.CanvasPaint.Image)).GetPixel(e.Location.X, e.Location.Y)));
            }
        }
        
        private void CanvasPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawShape.ShapeType.Eraser == ShapeType)
            {
                Bitmap bitmap = DrawShape.CreateBitmap(DrawShape.EraserSize, DrawShape.EraserSize, Color.White);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, bitmap.Size.Width - 1, bitmap.Size.Width - 1));
                g.Dispose();
                CurPictureBox = new Cursor(Icon.FromHandle(bitmap.GetHicon()).Handle);
            }
            if (DrawShape.IsInSelectedArea(e.Location))
            {
                if (ShapeType == DrawShape.ShapeType.Select)
                    Cursor = Cursors.SizeAll;
            }
            else
            {
                Cursor = CurPictureBox;
            }
            
            guiPaint.CanvasSizeStatus.Text = string.Empty;
            guiPaint.LocationStatus.Text = e.X.ToString() + "," + e.Y.ToString();
            Point pt = e.Location;

            if (DrawShape.ShapeType.Polygon == ShapeType && Point.Empty != DrawShape.Ps)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, true, false);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }

            if (!MouseDown)
                return;

            if (DrawShape.ShapeType.Rectangle == ShapeType)
            {
                if (DrawShape.Shift)
                    pt.Y = pt.X - StartingPoint.X + StartingPoint.Y;
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, true, false);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Ellipse == ShapeType)
            {
                if (DrawShape.Shift)
                {
                    if (Math.Abs(pt.Y - StartingPoint.Y) < Math.Abs(pt.X - StartingPoint.X))
                        pt.Y = pt.X - StartingPoint.X + StartingPoint.Y;
                    else
                        pt.X = pt.Y - StartingPoint.Y + StartingPoint.X;
                }
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, true, false);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.RoundedRectangle == ShapeType)
            {
                if (DrawShape.Shift)
                    pt.Y = pt.X - StartingPoint.X + StartingPoint.Y;
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, true, false);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Line == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, true, false);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Curve == ShapeType)
            {
                if (Point.Empty != DrawShape.CurveMidPt1 && Point.Empty == DrawShape.CurveMidPt2)
                {
                    DrawShape.CurveMidPt1 = pt;
                }
                else if (Point.Empty != DrawShape.CurveMidPt2)
                {
                    DrawShape.CurveMidPt2 = pt;
                }
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, true, false);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Pencil == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, true, false);
                StartingPoint = pt;
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Eraser == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, true, false);
                StartingPoint = pt;
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.AirBrush == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, e.Location, false, true);
                StartingPoint = e.Location;
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Brush == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, true, true);
                StartingPoint = pt;
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Text == ShapeType)
            {
                if (MouseDown)
                {
                    Refresh();
                    Pen pen = new Pen(Color.Gray);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    Bitmap bmp = new Bitmap(CanvasPaint.Image);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawRectangle(pen, StartingPoint.X, StartingPoint.Y, e.X - StartingPoint.X, e.Y - StartingPoint.Y);
                    g.Dispose();
                    g = CanvasPaint.CreateGraphics();
                    g.DrawImage(bmp, new Point(0, 0));
                    g.Dispose();
                }
            }
            else if (DrawShape.ShapeType.Select == ShapeType)
            {
                if (DrawShape.MoveSelectedAreaEnable.Enable)
                {
                    DrawShape.MoveSelectedArea(e.Location);
                    CanvasPaint.Image = DrawShape.ImageDrew;
                }
                else
                {
                    DrawShape.DrawSelectionArea(StartingPoint, pt, false, false);
                    CanvasPaint.Image = DrawShape.ImageDrew;
                }
            }
        }

        public void CanvasPaint_MouseUp(object sender, MouseEventArgs e)
        {
            if (!MouseDown)
                return;
            Point pt = new Point();
            if (e != null)
                pt = e.Location;

            if (DrawShape.ShapeType.Rectangle == ShapeType)
            {
                if (DrawShape.Shift)
                    pt.Y = pt.X - StartingPoint.X + StartingPoint.Y;
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, false, true);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Ellipse == ShapeType)
            {
                if (DrawShape.Shift)
                    pt.Y = pt.X - StartingPoint.X + StartingPoint.Y;
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, false, true);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.RoundedRectangle == ShapeType)
            {
                if (DrawShape.Shift)
                    pt.Y = pt.X - StartingPoint.X + StartingPoint.Y;
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, false, true);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Line == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, false, true);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Curve == ShapeType)
            {
                if (Point.Empty == DrawShape.CurveEndPt)
                {
                    DrawShape.CurveEndPt = e.Location;
                }
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, false, false);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Pencil == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, false, false);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.Eraser == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, false, false);
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            else if (DrawShape.ShapeType.AirBrush == ShapeType)
            {
                
            }
            else if (DrawShape.ShapeType.Brush == ShapeType)
            {
                DrawShape.DrawGDI(ShapeType, StartingPoint, pt, false, true);
                DrawShape.EraserPolygonPath.Reset();
                CanvasPaint.Image = DrawShape.ImageDrew;
            }
            // Edit text onto image
            else if (DrawShape.ShapeType.Text == ShapeType)
            {
                CheckInput = !CheckInput;
                if (CheckInput)
                {
                    InputText.Location = new Point(StartingPoint.X + 1, StartingPoint.Y + 1);
                    InputText.Size = new Size(pt.X - StartingPoint.X - 1, pt.Y - StartingPoint.Y - 1);
                    CanvasPaint.Controls.Add(InputText);
                }
                else
                {
                    Point startPoint = new Point();
                    startPoint.X = CanvasPaint.Location.X + InputText.Location.X;
                    startPoint.Y = CanvasPaint.Location.Y + InputText.Location.Y;
                    InputText.SelectAll();
                    Bitmap bmp = new Bitmap(CanvasPaint.Image);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawString(InputText.Text,
                                 InputText.SelectionFont,
                                 new SolidBrush(FontColor),
                                 new PointF(InputText.Location.X, InputText.Location.Y));
                    ChangeBackgroundImage(bmp);
                    SetDefaultValueForInputText();
                    CanvasPaint.Controls.Remove(InputText);
                }
                if (InputText.Width > 0 && InputText.Height > 0)
                {
                    PaintForm.ShowTextToolbar(CheckInput);
                }
            }
            else if (DrawShape.ShapeType.Select == ShapeType)
            {
                if (!DrawShape.MoveSelectedAreaEnable.Enable)
                {
                    Point endPoint = new Point();
                    endPoint.X = Math.Max(Math.Min(pt.X, CanvasPaint.Width), 0);
                    endPoint.Y = Math.Max(Math.Min(pt.Y, CanvasPaint.Height), 0);

                    DrawShape.DrawSelectionArea(StartingPoint, endPoint, true, false);
                    CanvasPaint.Image = DrawShape.ImageDrew;
                }
            }
            MouseDown = false;
        }

        /// <summary>
        /// Complete the polygon
        /// </summary>
        public void FinishPolygon()
        {
            if (Point.Empty == DrawShape.PsBack)
                return;
            DrawShape.PsFinish = true;
            DrawShape.DrawGDI(DrawShape.ShapeType.Polygon, Point.Empty, Point.Empty, false, false);
            DrawShape.EraserPolygonPath.Reset();
            DrawShape.PsFinish = false;
            CanvasPaint.Image = DrawShape.ImageDrew;
            DrawShape.Ps = Point.Empty;
            DrawShape.PsBack = Point.Empty;
        }

        /// <summary>
        /// Cancel the current drawn curve or polygon
        /// </summary>
        public void CancelDraw()
        {
            if (!Cancel)
                return;
            if (DrawShape.ShapeType.Curve == ShapeType || DrawShape.ShapeType.Polygon == ShapeType)
            {
                DrawShape.Cancel();
                CanvasPaint.Image = DrawShape.ImageStatus;
                Invalidate();
                Cancel = false;
            }
        }

        /// <summary>
        /// Curve of the current drawn to the undo / save to go
        /// </summary>
        public void AddCurve()
        {
            if (DrawShape.AddDrawShape())
                DrawShape.ImageCurve = null;
        }

        /// <summary>
        /// Rotate image in selection area
        /// </summary>
        /// <param name="angle">positive value if angle rotate clockwise, nagative in otherwise</param>
        public void RotateSelectionArea(float angle)
        {
            DrawShape.RotateSelection(angle);
            CanvasPaint.Image = DrawShape.ImageDrew;
        }
        /// <summary>
        /// Flip vertical image in selection area
        /// </summary>
        /// <param name="flipType">horizontal if FlipHorizontal and veritcal if FlipVertical</param>
        public void FlipSelectionArea(DrawShape.FlipType flipType)
        {
            DrawShape.FlipSelection(flipType);
            CanvasPaint.Image = DrawShape.ImageDrew;
        }
        /// <summary>
        /// Cut image in selection area
        /// </summary>
        public void CutSelectionArea()
        {
            DrawShape.CutSelection();
            DrawShape.DeSelectArea();
            CanvasPaint.Image = DrawShape.ImageDrew;
        }
        /// <summary>
        /// Copy image in selection area
        /// </summary>
        public void CopySelectionArea()
        {
            DrawShape.CopySelection();
            DrawShape.DeSelectArea();
            CanvasPaint.Image = DrawShape.ImageDrew;
        }
        /// <summary>
        /// Paste image
        /// </summary>
        public void PasteSelectionArea()
        {
            DrawShape.PasteSelection();
            CanvasPaint.Image = DrawShape.ImageDrew;
        }
        /// <summary>
        /// Delete image in selection area
        /// </summary>
        public void DeleteSelectionArea()
        {
            DrawShape.DeleteSelection();
            DrawShape.DeSelectArea();
            CanvasPaint.Image = DrawShape.ImageDrew;
        }
        /// <summary>
        /// Select all image
        /// </summary>
        public void SelectAllImage()
        {
            Point endPoint = new Point(PaintImage.Width - 1, PaintImage.Height - 1);
            DrawShape.SelectAll(endPoint, PaintImage);
            CanvasPaint.Image = DrawShape.ImageDrew;
        }
        /// <summary>
        /// Check sizes of selection area
        /// </summary>
        /// <returns>true if sizes of selection area is positive, otherwise: false</returns>
        public bool IsValidSelectionArea()
        {
            return DrawShape.IsValidSelection();
        }
        #endregion

        #region Text tool

        #region Change font style
        /// <summary>
        ///     Change the richtextbox style for the current selection
        /// </summary>
        public void ChangeFontStyle(FontStyle style, bool add)
        {
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            //	style - eg FontStyle.Bold
            //	add - IF true then add else remove

            // throw error if style isn't: bold, italic, strikeout or underline
            if (style != FontStyle.Bold
                && style != FontStyle.Italic
                && style != FontStyle.Underline)
                throw new System.InvalidProgramException(CommonLocalizedResources.InvalidFontStyleMessage);

            int inputStart = InputText.SelectionStart;
            int len = InputText.SelectionLength;
            int rtbTempStart = 0;

            //if len <= 1 and there is a selection font then just handle and return
            if (len <= 1 && InputText.SelectionFont != null)
            {
                //add or remove style 
                if (add)
                    InputText.SelectionFont = new Font(InputText.SelectionFont, InputText.SelectionFont.Style | style);
                else
                    InputText.SelectionFont = new Font(InputText.SelectionFont, InputText.SelectionFont.Style & ~style);

                return;
            }

            // Step through the selected text one char at a time	
            RtbTemp.Rtf = InputText.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                RtbTemp.Select(rtbTempStart + i, 1);

                //add or remove style 
                if (add)
                    RtbTemp.SelectionFont = new Font(RtbTemp.SelectionFont, RtbTemp.SelectionFont.Style | style);
                else
                    RtbTemp.SelectionFont = new Font(RtbTemp.SelectionFont, RtbTemp.SelectionFont.Style & ~style);
            }

            // Replace & reselect
            RtbTemp.Select(rtbTempStart, len);
            InputText.SelectedRtf = RtbTemp.SelectedRtf;
            InputText.Select(inputStart, len);
            return;
        }
        #endregion

        #region Change font size
        /// <summary>
        ///     Change the richtextbox font size for the current selection
        /// </summary>
        public void ChangeFontSize(float fontSize)
        {
            FontSize = fontSize;
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            // fontSize - the fontsize to be applied, eg 33.5

            if (fontSize <= 0.0)
                throw new System.InvalidProgramException(CommonLocalizedResources.InvalidFontSizeMessage);

            int inputStart = InputText.SelectionStart;
            int len = InputText.SelectionLength;
            int rtbTempStart = 0;

            // If len <= 1 and there is a selection font, amend and return
            if (len <= 1 && InputText.SelectionFont != null)
            {
                InputText.SelectionFont =
                    new Font(InputText.SelectionFont.FontFamily, fontSize, InputText.SelectionFont.Style);
                return;
            }

            // Step through the selected text one char at a time
            RtbTemp.Rtf = InputText.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                RtbTemp.Select(rtbTempStart + i, 1);
                RtbTemp.SelectionFont = new Font(RtbTemp.SelectionFont.FontFamily, fontSize, RtbTemp.SelectionFont.Style);
            }

            // Replace & reselect
            RtbTemp.Select(rtbTempStart, len);
            InputText.SelectedRtf = RtbTemp.SelectedRtf;
            InputText.Select(inputStart, len);
            return;
        }
        #endregion

        #region Change font color
        /// <summary>
        ///     Change the richtextbox font color for the current selection
        /// </summary>
        public void ChangeFontColor(Color newColor)
        {
            FontColor = newColor;
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            //	newColor - eg Color.Red

            int inputStart = InputText.SelectionStart;
            int len = InputText.SelectionLength;
            int rtbTempStart = 0;

            //if len <= 1 and there is a selection font then just handle and return
            if (len <= 1 && InputText.SelectionFont != null)
            {
                InputText.SelectionColor = newColor;
                return;
            }

            // Step through the selected text one char at a time	
            RtbTemp.Rtf = InputText.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                RtbTemp.Select(rtbTempStart + i, 1);

                //change color
                RtbTemp.SelectionColor = newColor;
            }

            // Replace & reselect
            RtbTemp.Select(rtbTempStart, len);
            InputText.SelectedRtf = RtbTemp.SelectedRtf;
            InputText.Select(inputStart, len);
            return;
        }
        #endregion

        #region Get Font Details
        /// <summary>
        ///     Returns a Font with:
        ///     1) The font applying to the entire selection, if none is the default font. 
        ///     2) The font size applying to the entire selection, if none is the size of the default font.
        ///     3) A style containing the attributes that are common to the entire selection, default regular.
        /// </summary>		
        /// 
        public Font GetFontDetails()
        {
            //This method should handle cases that occur when multiple fonts/styles are selected

            int inputStart = InputText.SelectionStart;
            int len = InputText.SelectionLength;
            int rtbTempStart = 0;

            if (len <= 1)
            {
                // Return the selection or default font
                if (InputText.SelectionFont != null)
                    return InputText.SelectionFont;
                else
                    return InputText.Font;
            }

            // Step through the selected text one char at a time	
            // after setting defaults from first char
            RtbTemp.Rtf = InputText.Rtf;
            RtbTemp.SelectionStart = InputText.SelectionStart;
            RtbTemp.SelectionLength = InputText.SelectionLength;

            rtbTempStart = InputText.SelectionStart;

            //Turn everything on so we can turn it off one by one
            FontStyle replyStyle =
                FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout | FontStyle.Underline;

            // Set reply font, size and style to that of first char in selection.
            RtbTemp.Select(rtbTempStart, 1);
            string replyFont = RtbTemp.SelectionFont.Name;
            float replyFontSize = RtbTemp.SelectionFont.Size;
            replyStyle = replyStyle & RtbTemp.SelectionFont.Style;

            // Search the rest of the selection
            for (int i = 1; i < len; ++i)
            {
                RtbTemp.Select(rtbTempStart + i, 1);

                // Check reply for different style
                replyStyle = replyStyle & RtbTemp.SelectionFont.Style;

                // Check font
                if (replyFont != RtbTemp.SelectionFont.FontFamily.Name)
                    replyFont = string.Empty;

                // Check font size
                if (replyFontSize != RtbTemp.SelectionFont.Size)
                    replyFontSize = (float)0.0;
            }

            // Now set font and size if more than one font or font size was selected
            if (replyFont == string.Empty)
                replyFont = RtbTemp.Font.FontFamily.Name;

            if (replyFontSize == 0.0)
                replyFontSize = RtbTemp.Font.Size;

            // generate reply font
            Font reply = new Font(replyFont, replyFontSize, replyStyle);
            
            return reply;
        }
        #endregion

        #region Update Toolbar
        /// <summary>
        ///     Update the toolbar button statuses
        /// </summary>
        public void UpdateToolbar()
        {
            // Get the font, fontsize and style to apply to the toolbar buttons
            Font fnt = GetFontDetails();
            // Set font style buttons to the styles applying to the entire selection
            FontStyle style = fnt.Style;
            //Set all the style buttons using the gathered style
            IsBold = fnt.Bold; //bold button
            IsItalic= fnt.Italic; //italic button
            IsUnderline = fnt.Underline; //underline button
            
            // Update toolbar
            PaintForm.UpdateToolBar(IsBold, IsItalic, IsUnderline);
        }
        #endregion

        #region Selection Change event
        [Description("Occurs when the selection is changed"),
        Category("Behavior")]
        // Raised in tb1 SelectionChanged event so that user can do useful things
        public event System.EventHandler SelChanged;
        #endregion

        #region RichTextBox Selection Change
        /// <summary>
        ///		Change the toolbar buttons when new text is selected
        ///		and raise event SelChanged
        /// </summary>
        private void InputText_SelectionChanged(object sender, System.EventArgs e)
        {
            //Update the toolbar buttons
            UpdateToolbar();

            //Send the SelChangedEvent
            if (SelChanged != null)
                SelChanged(this, e);
        }
        #endregion
        /// <summary>
        /// Set default value when Richtextbox is created
        /// </summary>
        private void SetDefaultValueForInputText()
        {
            InputText.Text = string.Empty;
            FontSize = 8;
            FontColor = Color.Black;
        }

        #endregion

        #region Resize
        /// <summary>
        /// Resize image
        /// </summary>
        /// <param name="img">The image to resize</param>
        /// <param name="newWidth">new width of image</param>
        /// <param name="newHeight">new height of image</param>
        /// <returns>image resized</returns>
        public Image ResizeImage(Image img, int newWidth, int newHeight)
        {
            //get the height and width of the image
            int originalW = img.Width;
            int originalH = img.Height;
            //create a new Bitmap the size of the new image
            Bitmap bmp = new Bitmap(newWidth, newHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //draw the newly resized image
            graphic.DrawImage(img, 0, 0, newWidth, newHeight);
            graphic.Dispose();
            return (Image)bmp;
        }
        /// <summary>
        /// Zoom the image
        /// </summary>
        /// <param name="img">original image</param>
        /// <param name="percent">percent to zoom</param>
        /// <returns>Image after zooming</returns>
        private Image ZoomImage(Image img, float percent)
        {
            if (percent <= 0)
            {
                percent = 1;
            }
            return ResizeImage(img, (int)(img.Width * percent / 100), (int)(img.Height * percent / 100));
        }
        #endregion
    }
}