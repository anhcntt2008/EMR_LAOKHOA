using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections;
using System.Windows.Forms;

namespace BOSERP.Utilities.Paint
{
    public class DrawShape
    {
        public enum ShapeType { Pencil, Ellipse, Rectangle, Line, Arrow, Polygon, Eraser, None, RoundedRectangle, FreeSelect, Select, FillWithColor, PickColor, Magnifier, Brush, AirBrush, Text, Curve, Resize, Rotate, Zoom }
        public enum FlipType { Horizontal, Vertical }

        #region Variable
        private Graphics Graphics;
        private Graphics Fg;
        private Image ImageUndo;
        private Image ImageToFill;
        private Image StartImage;
        private Graphics Gf;
        private IntPtr HdcFill;
        /// <summary>
        /// check mouse down
        /// </summary>
        private bool Md;
        private int RoundX = 20;
        private int RoundY = 20;
        private List<DrawProcess> OrginProcess = new List<DrawProcess>();
        private List<DrawProcess> CurrentProcess = new List<DrawProcess>();
        private ShapeType PreShape = ShapeType.None;
        private DrawProcess Dpp;
        private bool Repeal = false;
        private List<Point> PolygonPoints = new List<Point>();
        private DrawProcess CurveProcessBackup;
        /// <summary>
        /// The select area
        /// </summary>
        private Rectangle SelectArea;
        /// <summary>
        /// Whether selection area is valid
        /// </summary>
        private bool IsAreaSelected;
        /// <summary>
        /// Whether selection area can move
        /// </summary>
        private bool IsMovingSelectionArea;
        /// <summary>
        /// Image in selection area
        /// </summary>
        private Image SelectionImage;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets pen
        /// </summary>
        public Pen Pen { get; set; }
        /// <summary>
        /// Gets or sets brush
        /// </summary>
        public Brush Brush { get; set; }
        /// <summary>
        /// Gets or sets brush color
        /// </summary>
        public Color Brushcolor { get; set; }
        public Point Ps { get; set; }
        /// <summary>
        /// Gets or sets key Shift is pressed
        /// </summary>
        public bool Shift { get; set; }
        /// <summary>
        /// Gets or sets size of eraser
        /// </summary>
        public int EraserSize { get; set; }
        public GraphicsPath EraserPolygonPath { get; set; }
        public int Fill { get; set; }
        /// <summary>
        /// Gets or sets whether image is saved
        /// </summary>
        public bool Saved { get; set; } 
        public int AirBrushStyle { get; set; } 
        public int BrushWidth { get; set; }
        public int BrushStyle { get; set; }
        public Point PsBack { get; set; }  
        public bool PsFinish { get; set; } 
        public Point CurveStartPt { get; set; }  
        public Point CurveEndPt { get; set; }
        public Point CurveMidPt1 { get; set; }
        public Point CurveMidPt2 { get; set; }
        public Image ImageStatus { get; set; }
        /// <summary>
        /// Process map
        /// </summary>
        public Image ImageDrew { get; set; }
        /// <summary>
        /// Draw polygon or curve back up pictures
        /// </summary>
        public Image ImageCurve { get; set; }
        /// <summary>
        /// Gets whether image can undo
        /// </summary>
        public bool CanUndo
        {
            get { if (CurrentProcess.Count > 0)return true; return false; }
        }
        /// <summary>
        /// Gets can restore value
        /// </summary>
        public bool CanRedo
        {
            get { if (CurrentProcess.Count < OrginProcess.Count)return true; return false; }
        }
        /// <summary>
        /// Add text whether create transparent background
        /// </summary>
        public bool TextTransparent { get; set; }
        /// <summary>
        /// Gets or sets enable move selected point
        /// </summary>
        public MoveSelectedPoint MoveSelectedAreaEnable { get; set; }
        
        #endregion    

        #region Constructor
        public DrawShape()
        {
            Pen = new Pen(Color.Black);
            Brush = Brushes.White;
            Shift = false;
            Ps = Point.Empty;
            EraserSize = 8;
            EraserPolygonPath = new GraphicsPath();
            Fill = 0;
            Saved = true;
            AirBrushStyle = 0;
            BrushWidth = 8;
            BrushStyle = 0;
            PsBack = Point.Empty;
            PsFinish = false;
            CurveStartPt = Point.Empty;
            CurveEndPt = Point.Empty;
            CurveMidPt1 = Point.Empty;
            CurveMidPt2 = Point.Empty;
        }

        public DrawShape(Image img)
            : this()
        {
            Bitmap bmp = new Bitmap(img);
            ImageStatus = bmp;
            ImageToFill = (Image)ImageStatus.Clone();
            StartImage = (Image)img.Clone();
            Fg = Graphics = Graphics.FromImage(ImageStatus);
            Brush = Brushes.White;
            Pen = Pens.Black;
            OrginProcess.Clear();
            CurrentProcess.Clear();
        }
        public DrawShape(System.Windows.Forms.Form form)
            : this()
        {
            ImageStatus = CreateBitmap(form.Width, form.Height, form.BackColor);
            StartImage = (Image)ImageStatus.Clone();
            Fg = Graphics = form.CreateGraphics();
            Brush = Brushes.White;
            Pen = Pens.Black;
            OrginProcess.Clear();
            CurrentProcess.Clear();
        }
        public DrawShape(System.Windows.Forms.Control control)
            : this()
        {
            ImageStatus = CreateBitmap(control.Width, control.Height, control.BackColor);
            StartImage = (Image)ImageStatus.Clone();
            Fg = Graphics = control.CreateGraphics();
            Brush = Brushes.White;
            Pen = Pens.Black;
            OrginProcess.Clear();
            CurrentProcess.Clear();
        }
        #endregion

        #region Events
        public delegate void UndoEventHandler(object sender, EventArgs e);
        public event UndoEventHandler UndoEvent;
        protected virtual void OnUndoEvent(EventArgs e)
        {
            if (UndoEvent != null) UndoEvent(this, e);
        }
        public delegate void RedoEventHandler(object sender, EventArgs e);
        public event UndoEventHandler RedoEvent;
        protected virtual void OnRedoEvent(EventArgs e)
        {
            if (RedoEvent != null) RedoEvent(this, e);
        }
        
        /// <summary>
        /// Cancel the current drawn curve or polygon
        /// </summary>
        public void Cancel()
        {
            if (null != ImageCurve)
            {
                ImageStatus = (Image)ImageCurve.Clone();
                PsBack = Ps = CurveStartPt = CurveEndPt = CurveMidPt1 = CurveMidPt2 = Point.Empty;
                ImageCurve = null;
                PolygonPoints.Clear();
                EraserPolygonPath.Reset();
            }
        }
        /// <summary>
        /// Curve of the current drawn to the undo / save to go
        /// </summary>
        /// <returns></returns>
        public bool AddDrawShape()
        {
            if (CurveProcessBackup == null)
                return false;
            CurrentProcess.Add(CurveProcessBackup);
            OrginProcess.Add(CurveProcessBackup);
            CurveStartPt = CurveEndPt = CurveMidPt1 = CurveMidPt2 = Point.Empty;
            return true;
        }

        #region Undo / Recovery

        /// <summary>
        /// Revocation
        /// </summary>
        public void Undo()
        {
            if (CurrentProcess.Count <= 0)
                return;
            Pen oldPen = (Pen)Pen.Clone();
            Brush oldBrush = (Brush)Brush.Clone();
            ImageUndo = (Image)StartImage.Clone();
            Graphics gt = Graphics.FromImage(ImageUndo);
            IntPtr hwnd = gt.GetHdc();
            for (int i = 0; i < CurrentProcess.Count - 1; i++)
            {
                DrawProcess dp = (DrawProcess)CurrentProcess[i];
                Pen = dp.PenUsed;
                Brush = dp.BrushUsed;
                if (ShapeType.Resize == dp.ShapeTypeValue)
                {
                    Bitmap bitmap = DrawShape.CreateBitmap(dp.CanvasSize, Brushcolor);
                    ImageUndo = DrawShape.CombineBitmap(bitmap, ImageToFill, new Point(0, 0));
                }
                else
                {
                    if (ShapeType.Polygon == dp.ShapeTypeValue)
                    {
                        PolygonPoints.Clear();
                        PolygonPoints.AddRange(dp.PolygonPoints);
                    }
                    if (dp.ShapeTypeValue == ShapeType.Pencil)
                    {
                        for (int j = 0; j < dp.LinePoints.Count; j++)
                        {
                            DrawGDI2(dp.ShapeTypeValue, dp.LinePoints[j].StartPoint, dp.LinePoints[j].EndPoint, true, dp.FillType, dp.BrushUsed, dp.PenUsed, hwnd, dp.CurvePoints.ToArray());
                        }
                    }
                    else if (dp.ShapeTypeValue == ShapeType.Eraser)
                    {
                        for (int j = 0; j < dp.LinePoints.Count; j++)
                        {
                            DrawGDI2(dp.ShapeTypeValue, dp.LinePoints[j].StartPoint, dp.LinePoints[j].EndPoint, true, dp.FillType, dp.BrushUsed, dp.PenUsed, hwnd, dp.CurvePoints.ToArray());
                        }
                    }
                    else
                        DrawGDI2(dp.ShapeTypeValue, dp.StartPoint, dp.EndPoint, dp.MouseDown, dp.FillType, dp.BrushUsed, dp.PenUsed, hwnd, dp.CurvePoints.ToArray());
                }
            }
            Pen = (Pen)oldPen.Clone();
            Brush = (Brush)oldBrush.Clone();
            CurrentProcess.RemoveAt(CurrentProcess.Count - 1);
            gt.ReleaseHdc();
            gt.Dispose();
            ImageStatus = ImageDrew = (Image)ImageUndo.Clone();
            OnUndoEvent(new EventArgs());
            Repeal = true;
        }

        /// <summary>
        /// Redo
        /// </summary>
        public void Redo()
        {
            if (CurrentProcess.Count >= OrginProcess.Count)
                return;
            Pen oldPen = (Pen)this.Pen.Clone();
            Brush oldBrush = (Brush)this.Brush.Clone();
            CurrentProcess.Add((DrawProcess)OrginProcess[CurrentProcess.Count]);
            ImageUndo = (Image)StartImage.Clone();
            Graphics gt = Graphics.FromImage(ImageUndo);
            IntPtr hwnd = gt.GetHdc();
            for (int i = 0; i < CurrentProcess.Count; i++)
            {
                DrawProcess dp = (DrawProcess)CurrentProcess[i];
                Pen = dp.PenUsed;
                Brush = dp.BrushUsed;
                if (ShapeType.Resize == dp.ShapeTypeValue)
                {
                    Bitmap bitmap = DrawShape.CreateBitmap(dp.CanvasSize, Brushcolor);
                    ImageUndo = DrawShape.CombineBitmap(bitmap, ImageToFill, new Point(0, 0));
                }
                else
                {
                    if (ShapeType.Polygon == dp.ShapeTypeValue)
                    {
                        PolygonPoints.Clear();
                        PolygonPoints.AddRange(dp.PolygonPoints);
                    }
                    if (dp.ShapeTypeValue == ShapeType.Pencil)
                    {
                        for (int j = 0; j < dp.LinePoints.Count; j++)
                        {
                            DrawGDI2(dp.ShapeTypeValue, dp.LinePoints[j].StartPoint, dp.LinePoints[j].EndPoint, true, dp.FillType, dp.BrushUsed, dp.PenUsed, hwnd, dp.CurvePoints.ToArray());
                        }
                    }
                    else if (dp.ShapeTypeValue == ShapeType.Eraser)
                    {
                        DrawGDI2(dp.ShapeTypeValue, dp.LinePoints[0].StartPoint, dp.LinePoints[0].EndPoint, true, dp.FillType, dp.BrushUsed, dp.PenUsed, hwnd, dp.CurvePoints.ToArray());
                        for (int j = 1; j < dp.LinePoints.Count - 1; j++)
                        {
                            DrawGDI2(dp.ShapeTypeValue, dp.LinePoints[j].StartPoint, dp.LinePoints[j].EndPoint, true, dp.FillType, dp.BrushUsed, dp.PenUsed, hwnd, dp.CurvePoints.ToArray());
                        }
                        DrawGDI2(dp.ShapeTypeValue, dp.LinePoints[dp.LinePoints.Count - 1].StartPoint, dp.LinePoints[dp.LinePoints.Count - 1].EndPoint, false, dp.FillType, dp.BrushUsed, dp.PenUsed, hwnd, dp.CurvePoints.ToArray());
                    }
                    else
                        DrawGDI2(dp.ShapeTypeValue, dp.StartPoint, dp.EndPoint, dp.MouseDown, dp.FillType, dp.BrushUsed, dp.PenUsed, hwnd, dp.CurvePoints.ToArray());
                }
            }
            this.Pen = (Pen)oldPen.Clone();
            this.Brush = (Brush)oldBrush.Clone();
            gt.ReleaseHdc();
            gt.Dispose();
            ImageStatus = ImageDrew = (Image)ImageUndo.Clone();
            OnRedoEvent(new EventArgs());
        }

        #endregion

        #endregion

        #region General Graphics

        public void DrawGDI(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown, bool canAdd)
        {
            if (ImageDrew == null)
                ImageDrew = ImageStatus;
            if (Repeal)
            {
                OrginProcess.Clear();
                OrginProcess.AddRange(CurrentProcess);
            }
            if (canAdd)
            {
                Saved = false;
                if (ShapeType.Eraser != shapeType && ShapeType.Pencil != shapeType)
                {
                    int fillStyle = this.Fill;
                    if (ShapeType.Rectangle != shapeType && ShapeType.Ellipse != shapeType && ShapeType.Polygon != shapeType && ShapeType.RoundedRectangle != shapeType)
                        Fill = 0;
                    Dpp = new DrawProcess(shapeType, startPoint, endPoint, mouseDown, ImageDrew.Size, (Pen)this.Pen.Clone(), (Brush)this.Brush.Clone(), fillStyle, LinePoint.Empty);
                    OrginProcess.Add(Dpp);
                    CurrentProcess.Add(Dpp);
                }
                else
                {
                    Dpp = new DrawProcess(shapeType, startPoint, endPoint, mouseDown, ImageDrew.Size, (Pen)this.Pen.Clone(), (Brush)this.Brush.Clone(), 0, new LinePoint(startPoint, endPoint));
                    OrginProcess.Add(Dpp);
                    CurrentProcess.Add(Dpp);
                }
            }
            int ft = this.Fill;
            if (ShapeType.Ellipse != shapeType && ShapeType.Rectangle != shapeType && ShapeType.RoundedRectangle != shapeType && ShapeType.Polygon != shapeType)
            {
                this.Fill = 0;
            }
            if (this.Fill == 0)
                DrawGDI_Line(shapeType, startPoint, endPoint, mouseDown);
            else if (this.Fill == 1)
            {
                DrawGDI_Line_Fill(shapeType, startPoint, endPoint, mouseDown, Brushcolor);
            }
            else if (this.Fill == 2)
                DrawGDI_Fill(shapeType, startPoint, endPoint, mouseDown, this.Pen.Color);
            this.Fill = ft;
            PreShape = shapeType;
        }

        private void DrawGDI_Line(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown)
        {
            this.Md = mouseDown;
            PointF rectStartPointF = startPoint;
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.DrawRectangle(Pen, rectStartPointF.X, rectStartPointF.Y, Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.DrawRectangle(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            if (this.Shift)
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.DrawRectangle(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                            else
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.DrawRectangle(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                        }
                        break;
                    }
                case ShapeType.Ellipse:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.DrawEllipse(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                            else
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.DrawEllipse(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            if (this.Shift)
                            {
                                height = width;
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.DrawEllipse(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                            else
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.DrawEllipse(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                        }
                        break;
                    }
                case ShapeType.Polygon:
                    {
                        if (!mouseDown)
                        {
                            Graphics = Graphics.FromImage(ImageStatus);
                            if (PsFinish)
                            {
                                EraserPolygonPath.AddLine(Ps.X, Ps.Y, PsBack.X, PsBack.Y);
                                PolygonPoints.Add(Ps);
                                PolygonPoints.Add(PsBack);
                                this.Dpp = Dpp = new DrawProcess(shapeType, startPoint, endPoint, mouseDown, ImageDrew.Size, (Pen)this.Pen.Clone(), (Brush)this.Brush.Clone(), this.Fill, LinePoint.Empty);
                                this.Dpp.AddPolygonPoint(PolygonPoints);
                                CurrentProcess.Add(Dpp);
                                OrginProcess.Add(Dpp);
                            }
                            else
                            {
                                EraserPolygonPath.AddLine(Ps.X, Ps.Y, endPoint.X, endPoint.Y);
                                PolygonPoints.Add(Ps);
                                PolygonPoints.Add(endPoint);
                            }
                            Graphics.DrawPath(Pen, EraserPolygonPath);
                            if (PsFinish)
                                PolygonPoints.Clear();
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            ImageDrew = (Image)ImageStatus.Clone();
                            Graphics = Graphics.FromImage(ImageDrew);
                            Graphics.DrawLine(Pen, Ps.X, Ps.Y, endPoint.X, endPoint.Y);
                        }
                        break;
                    }
                case ShapeType.RoundedRectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (Convert.ToInt32(width) == 0 || Convert.ToInt32(height) == 0)
                            return;

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                DrawRoundRectangle_API_Ex(Graphics, this.Pen, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                            }
                            else
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                DrawRoundRectangle_API_Ex(Graphics, this.Pen, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                            }
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            if (this.Shift)
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                DrawRoundRectangle_API_Ex(Graphics, this.Pen, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                            }
                            else
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                DrawRoundRectangle_API_Ex(Graphics, this.Pen, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                            }
                        }
                        break;
                    }
                case ShapeType.Text:
                    {
                        break;
                    }
                case ShapeType.Arrow:
                    {
                        if (!mouseDown)
                        {
                            Pen.EndCap = LineCap.ArrowAnchor;
                            Pen.Width = 4;
                            Graphics = Graphics.FromImage(ImageStatus);
                            Graphics.DrawLine(Pen, startPoint, endPoint);
                            Pen.Width = 1;
                            Pen.EndCap = LineCap.NoAnchor;
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            ImageDrew = (Image)ImageStatus.Clone();
                            Graphics = Graphics.FromImage(ImageDrew);
                            Pen.EndCap = LineCap.ArrowAnchor;
                            Pen.Width = 4;
                            Graphics.DrawLine(Pen, startPoint, endPoint);
                            Pen.Width = 1;
                            Pen.EndCap = LineCap.NoAnchor;
                        }
                        break;
                    }
                case ShapeType.Pencil:
                    {
                        Dpp.AddLinePoint(new LinePoint(startPoint, endPoint));
                        if (!mouseDown)
                        {
                            Bitmap bitmap = new Bitmap(1, 1);
                            Graphics = Graphics.FromImage(bitmap);
                            Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, 1, 1));
                            Graphics.Dispose();
                            Graphics = Graphics.FromImage(ImageDrew);
                            Graphics.DrawImage(bitmap, endPoint);
                        }
                        else
                        {
                            Graphics = Graphics.FromImage(ImageStatus);
                            LineCap lc = this.Pen.EndCap;
                            this.Pen.StartCap = this.Pen.EndCap = LineCap.Round;
                            Graphics.DrawLine(Pen, startPoint, endPoint);
                            this.Pen.StartCap = this.Pen.EndCap = lc;
                            ImageDrew = ImageStatus;
                        }
                        break;
                    }
                case ShapeType.Eraser:
                    {
                        Dpp.AddLinePoint(new LinePoint(startPoint, endPoint));
                        Graphics = Graphics.FromImage(ImageStatus);
                        if (mouseDown)
                        {
                            if (startPoint != endPoint)
                            {
                                Pen tempPen = new Pen(Brush);
                                tempPen.Width = EraserSize;
                                tempPen.StartCap = LineCap.Round;
                                tempPen.EndCap = LineCap.Round;
                                Graphics.DrawLine(tempPen, startPoint, endPoint);
                            }
                            else
                            {
                                Graphics.FillRectangle(Brush, new Rectangle(new Point(startPoint.X - EraserSize / 2, startPoint.Y - EraserSize / 2), new Size(EraserSize, EraserSize)));

                            }
                        }
                        else
                        {
                            Pen tempPen = new Pen(Brush);
                            tempPen.Width = EraserSize;
                            Graphics.FillRectangle(Brush, new Rectangle(new Point(startPoint.X - EraserSize / 2, startPoint.Y - EraserSize / 2), new Size(EraserSize, EraserSize)));

                        }
                        ImageDrew = ImageStatus;
                        break;
                    }
                case ShapeType.Line:
                    {
                        if (!mouseDown)
                        {
                            Graphics = Graphics.FromImage(ImageStatus);
                            Graphics.DrawLine(Pen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            ImageDrew = (Image)ImageStatus.Clone();
                            Graphics = Graphics.FromImage(ImageDrew);
                            Graphics.DrawLine(Pen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
                        }
                        break;
                    }
                case ShapeType.Curve:
                    {
                        if (!mouseDown)
                        {
                            if (Point.Empty == CurveMidPt1)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.DrawLine(Pen, CurveStartPt.X, CurveStartPt.Y, CurveEndPt.X, CurveEndPt.Y);
                                ImageDrew = ImageStatus;
                                CurveProcessBackup = new DrawProcess(shapeType, startPoint, endPoint, mouseDown, ImageDrew.Size, (Pen)this.Pen.Clone(), (Brush)this.Brush.Clone(), 0, LinePoint.Empty);
                                CurveProcessBackup.AddCurvePoint(CurveStartPt);
                                CurveProcessBackup.AddCurvePoint(CurveEndPt);
                            }
                            else if (Point.Empty != CurveMidPt1 && Point.Empty == CurveMidPt2)
                            {
                                ImageStatus = (Image)ImageCurve.Clone();
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.DrawBeziers(Pen, new Point[] { CurveStartPt, CurveMidPt1, CurveMidPt1, CurveEndPt });
                                ImageDrew = ImageStatus;
                                CurveProcessBackup = new DrawProcess(shapeType, startPoint, endPoint, mouseDown, ImageDrew.Size, (Pen)this.Pen.Clone(), (Brush)this.Brush.Clone(), 0, LinePoint.Empty);
                                CurveProcessBackup.AddCurvePoint(CurveStartPt);
                                CurveProcessBackup.AddCurvePoint(CurveMidPt1);
                                CurveProcessBackup.AddCurvePoint(CurveMidPt1);
                                CurveProcessBackup.AddCurvePoint(CurveEndPt);
                            }
                            else if (Point.Empty != CurveMidPt2)
                            {
                                ImageStatus = (Image)ImageCurve.Clone();
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.DrawBeziers(Pen, new Point[] { CurveStartPt, CurveMidPt1, CurveMidPt2, CurveEndPt });
                                ImageDrew = ImageStatus;
                                CurveProcessBackup = null;
                                Dpp = new DrawProcess(shapeType, startPoint, endPoint, mouseDown, ImageDrew.Size, (Pen)this.Pen.Clone(), (Brush)this.Brush.Clone(), 0, LinePoint.Empty);
                                OrginProcess.Add(Dpp);
                                CurrentProcess.Add(Dpp);
                                Dpp.AddCurvePoint(CurveStartPt);
                                Dpp.AddCurvePoint(CurveMidPt1);
                                Dpp.AddCurvePoint(CurveMidPt2);
                                Dpp.AddCurvePoint(CurveEndPt);
                                CurveStartPt = CurveEndPt = CurveMidPt1 = CurveMidPt2 = Point.Empty;
                                ImageCurve = null;
                            }
                        }
                        else
                        {
                            if (Point.Empty == CurveMidPt1)
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.DrawLine(Pen, CurveStartPt.X, CurveStartPt.Y, endPoint.X, endPoint.Y);
                            }
                            else if (Point.Empty != CurveMidPt1 && Point.Empty == CurveMidPt2)
                            {
                                ImageDrew = (Image)ImageCurve.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.DrawBeziers(Pen, new Point[] { CurveStartPt, CurveMidPt1, CurveMidPt1, CurveEndPt });
                            }
                            else if (Point.Empty != CurveMidPt2)
                            {
                                ImageDrew = (Image)ImageCurve.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.DrawBeziers(Pen, new Point[] { CurveStartPt, CurveMidPt1, CurveMidPt2, CurveEndPt });
                            }
                        }
                        break;
                    }
                case ShapeType.AirBrush:
                    {
                        Bitmap bitmap = new Bitmap(1, 1);
                        Graphics = Graphics.FromImage(bitmap);
                        Graphics.FillRectangle(new SolidBrush(Pen.Color), new Rectangle(0, 0, 1, 1));
                        Graphics.Dispose();
                        switch (AirBrushStyle)
                        {
                            case 0:
                                {
                                    Random random = new Random();
                                    Graphics = Graphics.FromImage(ImageDrew);
                                    for (int i = -5; i < Convert.ToInt32(random.NextDouble() * 5); i++)
                                    {
                                        for (int j = -5; j < Convert.ToInt32(random.NextDouble() * i); j++)
                                            Graphics.DrawImage(bitmap, new Point(endPoint.X + Convert.ToInt32(random.NextDouble() * i), endPoint.Y + Convert.ToInt32(random.NextDouble() * j)));
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    Random random = new Random();
                                    Graphics = Graphics.FromImage(ImageDrew);
                                    for (int i = -8; i < Convert.ToInt32(random.NextDouble() * 9); i++)
                                    {
                                        for (int j = -8; j < Convert.ToInt32(random.NextDouble() * i); j++)
                                            Graphics.DrawImage(bitmap, new Point(endPoint.X + Convert.ToInt32(random.NextDouble() * i), endPoint.Y + Convert.ToInt32(random.NextDouble() * j)));
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Random random = new Random();
                                    Graphics = Graphics.FromImage(ImageDrew);
                                    for (int i = -12; i < 13; i++)
                                    {
                                        for (int j = -12; j < Convert.ToInt32(random.NextDouble() * i); j++)
                                        {
                                            Graphics.DrawImage(bitmap, new Point(endPoint.X + Convert.ToInt32(random.NextDouble() * i), endPoint.Y + Convert.ToInt32(random.NextDouble() * j)));
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case ShapeType.Brush:
                    {
                        Graphics = Graphics.FromImage(ImageStatus);
                        if (mouseDown)
                        {
                            if (startPoint != endPoint)
                            {
                                Pen tempPen = new Pen(Pen.Color);
                                tempPen.Width = BrushWidth;
                                if (BrushStyle == 0)
                                {
                                    tempPen.StartCap = LineCap.Round;
                                    tempPen.EndCap = LineCap.Round;
                                }
                                else if (BrushStyle == 1)
                                {
                                    tempPen.StartCap = LineCap.Square;
                                    tempPen.EndCap = LineCap.Square;
                                }
                                else if (BrushStyle == 2)
                                {
                                    tempPen.StartCap = LineCap.AnchorMask;
                                    tempPen.EndCap = LineCap.AnchorMask;
                                }
                                else if (BrushStyle == 3)
                                {
                                }

                                EraserPolygonPath.AddLine(new Point(startPoint.X, startPoint.Y), new Point(endPoint.X, endPoint.Y));
                                Graphics.DrawPath(tempPen, EraserPolygonPath);
                            }
                            else
                                Graphics.FillRectangle(Brush, new Rectangle(new Point(startPoint.X - EraserSize / 2, startPoint.Y - EraserSize / 2), new Size(EraserSize, EraserSize)));
                        }
                        else
                        {
                            Pen tempPen = new Pen(Pen.Color);
                            tempPen.Width = BrushWidth;
                            if (BrushStyle == 0)
                            {
                                tempPen.StartCap = LineCap.Round;
                                tempPen.EndCap = LineCap.Round;
                            }
                            else if (BrushStyle == 1)
                            {
                                tempPen.StartCap = LineCap.Square;
                                tempPen.EndCap = LineCap.Square;
                            }
                            else if (BrushStyle == 2)
                            {
                            }
                            else if (BrushStyle == 3)
                            {
                            }

                            EraserPolygonPath.AddLine(new Point(startPoint.X, startPoint.Y), new Point(endPoint.X, endPoint.Y));
                            Graphics.DrawPath(tempPen, EraserPolygonPath);
                        }
                        ImageDrew = ImageStatus;
                        break;
                    }
                case ShapeType.FillWithColor:
                    {
                        PlayDrawing();
                        break;
                    }
            }
        }

        private void DrawGDI_Fill(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown, Color color)
        {
            this.Md = mouseDown;
            PointF rectStartPointF = startPoint;
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.FillRectangle(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                FillRectangle_API_Ex(HdcFill, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.FillRectangle(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                FillRectangle_API_Ex(HdcFill, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            if (this.Shift)
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.FillRectangle(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height); DrawEllipse_API_Ex(HdcFill, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.FillRectangle(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                        }
                        break;
                    }
                case ShapeType.Ellipse:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.FillEllipse(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                FillEllipse_API_Ex(HdcFill, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.FillEllipse(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                FillEllipse_API_Ex(HdcFill, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            if (this.Shift)
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.FillEllipse(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                            else
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.FillEllipse(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                        }
                        break;
                    }
                case ShapeType.Polygon:
                    {
                        DrawGDI_Line_Fill(shapeType, startPoint, endPoint, mouseDown, color);
                        break;
                    }
                case ShapeType.RoundedRectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (Convert.ToInt32(width) == 0 || Convert.ToInt32(height) == 0)
                            return;

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                FillRoundRectangle_API_Ex(Graphics, color, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                                FillRoundRectangle_API_Ex(HdcFill, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                            else
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                FillRoundRectangle_API_Ex(Graphics, color, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                                FillRoundRectangle_API_Ex(HdcFill, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            if (this.Shift)
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                FillRoundRectangle_API_Ex(Graphics, color, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                            }
                            else
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                FillRoundRectangle_API_Ex(Graphics, color, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                            }
                        }
                        break;
                    }
            }
        }

        private void DrawGDI_Line_Fill(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown, Color color)
        {
            this.Md = mouseDown;
            PointF rectStartPointF = startPoint;
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.FillRectangle(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                Graphics.DrawRectangle(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                                FillRectangle_API_Ex(HdcFill, Brushcolor, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                                DrawRectangle_API_Ex(HdcFill, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.FillRectangle(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                Graphics.DrawRectangle(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                                FillRectangle_API_Ex(HdcFill, Brushcolor, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                                DrawRectangle_API_Ex(HdcFill, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            if (this.Shift)
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.FillRectangle(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                Graphics.DrawRectangle(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                            else
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.FillRectangle(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                Graphics.DrawRectangle(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                        }
                        break;
                    }
                case ShapeType.Ellipse:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.FillEllipse(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                Graphics.DrawEllipse(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                                FillEllipse_API_Ex(HdcFill, Brushcolor, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                                DrawEllipse_API_Ex(HdcFill, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                Graphics.FillEllipse(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                Graphics.DrawEllipse(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                                FillEllipse_API_Ex(HdcFill, Brushcolor, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                                DrawEllipse_API_Ex(HdcFill, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            if (this.Shift)
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.FillEllipse(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                Graphics.DrawEllipse(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                            else
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                Graphics.FillEllipse(new SolidBrush(color), rectStartPointF.X, rectStartPointF.Y, width, height);
                                Graphics.DrawEllipse(Pen, rectStartPointF.X, rectStartPointF.Y, width, height);
                            }
                        }
                        break;
                    }
                case ShapeType.Polygon:
                    {
                        if (!mouseDown)
                        {
                            Graphics = Graphics.FromImage(ImageStatus);
                            if (PsFinish)
                            {
                                EraserPolygonPath.AddLine(Ps.X, Ps.Y, PsBack.X, PsBack.Y);
                                PolygonPoints.Add(Ps);
                                PolygonPoints.Add(PsBack);
                                this.Dpp = Dpp = new DrawProcess(shapeType, startPoint, endPoint, mouseDown, this.ImageDrew.Size, (Pen)this.Pen.Clone(), (Brush)this.Brush.Clone(), this.Fill, LinePoint.Empty);
                                this.Dpp.AddPolygonPoint(PolygonPoints);
                                CurrentProcess.Add(Dpp);
                                OrginProcess.Add(Dpp);
                                Graphics.FillPath(Brush, EraserPolygonPath);
                                Graphics.DrawPath(Pen, EraserPolygonPath);
                            }
                            else
                            {
                                EraserPolygonPath.AddLine(Ps.X, Ps.Y, endPoint.X, endPoint.Y);
                                PolygonPoints.Add(Ps);
                                PolygonPoints.Add(endPoint);
                                Graphics.DrawPath(Pen, EraserPolygonPath);
                            }
                            if (PsFinish)
                                PolygonPoints.Clear();
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            ImageDrew = (Image)ImageStatus.Clone();
                            Graphics = Graphics.FromImage(ImageDrew);
                            Graphics.DrawLine(Pen, Ps.X, Ps.Y, endPoint.X, endPoint.Y);
                        }
                        break;
                    }
                case ShapeType.RoundedRectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (Convert.ToInt32(width) == 0 || Convert.ToInt32(height) == 0)
                            return;

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                FillRoundRectangle_API_Ex(Graphics, color, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                                DrawRoundRectangle_API_Ex(Graphics, Pen, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                                FillRoundRectangle_API_Ex(HdcFill, Brushcolor, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                                DrawRoundRectangle_API_Ex(HdcFill, this.Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                            else
                            {
                                Graphics = Graphics.FromImage(ImageStatus);
                                FillRoundRectangle_API_Ex(Graphics, color, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                                DrawRoundRectangle_API_Ex(Graphics, Pen, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                                FillRoundRectangle_API_Ex(HdcFill, Brushcolor, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                                DrawRoundRectangle_API_Ex(HdcFill, this.Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            if (this.Shift)
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                FillRoundRectangle_API_Ex(Graphics, color, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                                DrawRoundRectangle_API_Ex(Graphics, Pen, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                            }
                            else
                            {
                                ImageDrew = (Image)ImageStatus.Clone();
                                Graphics = Graphics.FromImage(ImageDrew);
                                FillRoundRectangle_API_Ex(Graphics, color, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                                DrawRoundRectangle_API_Ex(Graphics, Pen, new Rectangle(Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height)), RoundX, RoundY);
                            }
                        }
                        break;
                    }
            }
        }

        #endregion

        /// <summary>
        /// When an event using the method fill fill area color
        /// </summary>
        public void PlayDrawing()
        {
            Pen oldPen = (Pen)this.Pen.Clone();
            Brush oldBrush = (Brush)this.Brush.Clone();
            Color oldBrushcolor = Brushcolor;
            ImageToFill = (Image)StartImage.Clone();
            Gf = Graphics.FromImage(ImageToFill);
            HdcFill = Gf.GetHdc();
            for (int i = 0; i < CurrentProcess.Count; i++)
            {
                DrawProcess dp = (DrawProcess)CurrentProcess[i];
                this.Pen = dp.PenUsed;
                this.Brush = dp.BrushUsed;
                if (ShapeType.Resize == dp.ShapeTypeValue)
                {
                    Bitmap bitmap = DrawShape.CreateBitmap(dp.CanvasSize, Brushcolor);
                    ImageToFill = DrawShape.CombineBitmap(bitmap, ImageToFill, new Point(0, 0));
                }
                else
                {
                    if (ShapeType.Polygon == dp.ShapeTypeValue)
                    {
                        PolygonPoints.Clear();
                        PolygonPoints.AddRange(dp.PolygonPoints);
                    }
                    DrawGDI2(dp.ShapeTypeValue, dp.StartPoint, dp.EndPoint, dp.MouseDown, dp.FillType, dp.BrushUsed, dp.PenUsed, HdcFill, dp.CurvePoints.ToArray());
                    if (dp.ShapeTypeValue == ShapeType.Pencil)
                    {
                        for (int j = 0; j < dp.LinePoints.Count; j++)
                        {
                            DrawGDI2(dp.ShapeTypeValue, dp.LinePoints[j].StartPoint, dp.LinePoints[j].EndPoint, true, dp.FillType, dp.BrushUsed, dp.PenUsed, HdcFill, dp.CurvePoints.ToArray());
                        }
                    }
                    if (dp.ShapeTypeValue == ShapeType.Eraser)
                    {
                        for (int j = 0; j < dp.LinePoints.Count; j++)
                        {
                            DrawGDI2(dp.ShapeTypeValue, dp.LinePoints[j].StartPoint, dp.LinePoints[j].EndPoint, true, dp.FillType, dp.BrushUsed, dp.PenUsed, HdcFill, dp.CurvePoints.ToArray());
                        }
                    }
                }
            }
            this.Pen = (Pen)oldPen.Clone();
            this.Brush = (Brush)oldBrush.Clone();
            Brushcolor = oldBrushcolor;
            Gf.ReleaseHdc();
            Gf.Dispose();
            ImageStatus = ImageDrew = (Image)ImageToFill.Clone();
        }

        #region memory mapping
        public void DrawGDI2(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown, int fillType, Brush brush, Pen pen, IntPtr hdcd, Point[] points)
        {
            if (fillType == 0)
                DrawGDI_Line2(shapeType, startPoint, endPoint, mouseDown, hdcd, points);
            else if (fillType == 1)
            {
                SolidBrush solidBrush = (SolidBrush)Brush;
                DrawGDI_Line_Fill2(shapeType, startPoint, endPoint, mouseDown, solidBrush.Color, Pen, hdcd);
            }
            else if (fillType == 2)
                DrawGDI_Fill2(shapeType, startPoint, endPoint, mouseDown, Pen.Color, hdcd);
        }

        private void DrawGDI_Line2(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown, IntPtr hdcd, Point[] points)
        {
            this.Md = mouseDown;
            PointF rectStartPointF = startPoint;
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                DrawRectangle_API_Ex(hdcd, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                DrawRectangle_API_Ex(hdcd, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                        }
                        break;
                    }
                case ShapeType.Ellipse:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                DrawEllipse_API_Ex(hdcd, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                DrawEllipse_API_Ex(hdcd, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                        }
                        break;
                    }
                case ShapeType.Polygon:
                    {
                        if (!mouseDown)
                        {
                            IntPtr vBrush = CreateNullBrush();
                            IntPtr vPen = CreateRoundPen(Pen.Color);
                            IntPtr vPreviousBrush = WindowsAPI.SelectObject(hdcd, vBrush);
                            IntPtr vPreviousPen = WindowsAPI.SelectObject(hdcd, vPen);
                            WindowsAPI.Polygon(hdcd, PolygonPoints.ToArray(), PolygonPoints.Count);
                            WindowsAPI.SelectObject(hdcd, vPreviousBrush);
                            WindowsAPI.SelectObject(hdcd, vPreviousPen);
                        }
                        break;
                    }
                case ShapeType.RoundedRectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (Convert.ToInt32(width) == 0 || Convert.ToInt32(height) == 0)
                            return;

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                DrawRoundRectangle_API_Ex(hdcd, this.Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                            else
                            {
                                DrawRoundRectangle_API_Ex(hdcd, this.Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                        }
                        break;
                    }
                case ShapeType.Text:
                    {

                        break;
                    }
                case ShapeType.Arrow:
                    {
                        if (!mouseDown)
                        {
                            Pen.EndCap = LineCap.ArrowAnchor;
                            Pen.Width = 4;
                            Graphics = Graphics.FromImage(ImageStatus);
                            Graphics.DrawLine(Pen, startPoint, endPoint);
                            Pen.Width = 1;
                            Pen.EndCap = LineCap.NoAnchor;
                            ImageDrew = ImageStatus;
                        }
                        else
                        {
                            ImageDrew = (Image)ImageStatus.Clone();
                            Graphics = Graphics.FromImage(ImageDrew);
                            Pen.EndCap = LineCap.ArrowAnchor;
                            Pen.Width = 4;
                            Graphics.DrawLine(Pen, startPoint, endPoint);
                            Pen.Width = 1;
                            Pen.EndCap = LineCap.NoAnchor;
                        }
                        break;
                    }
                case ShapeType.Pencil:
                    {
                        if (!mouseDown)
                        {
                            WindowsAPI.SetPixel(hdcd, endPoint.X, endPoint.Y, ColorTranslator.ToWin32(this.Pen.Color));
                        }
                        else
                        {
                            IntPtr vPen = WindowsAPI.CreatePen(CommonConst.PS_SOLID, 1, ColorTranslator.ToWin32(this.Pen.Color));
                            IntPtr vPreviousPen = WindowsAPI.SelectObject(hdcd, vPen);
                            Point pt = new Point();
                            WindowsAPI.MoveToEx(hdcd, startPoint.X, startPoint.Y, ref pt);
                            WindowsAPI.LineTo(hdcd, endPoint.X, endPoint.Y);
                            WindowsAPI.SelectObject(hdcd, vPreviousPen);
                            WindowsAPI.DeleteObject(vPen);
                        }
                        break;
                    }
                case ShapeType.Eraser:
                    {
                        Pen tempPen = new Pen(Brush);
                        tempPen.Width = EraserSize;
                        if (mouseDown)
                        {
                            if (startPoint != endPoint)
                            {
                                IntPtr vBrush = CreateNullBrush();
                                IntPtr vPen = CreateRoundPen(tempPen.Color, (uint)EraserSize);
                                IntPtr vPreviouseBrush = WindowsAPI.SelectObject(hdcd, vBrush);
                                IntPtr vPreviousePen = WindowsAPI.SelectObject(hdcd, vPen);
                                Point pt = new Point();
                                WindowsAPI.MoveToEx(hdcd, startPoint.X, startPoint.Y, ref pt);
                                WindowsAPI.LineTo(hdcd, endPoint.X, endPoint.Y);
                                WindowsAPI.SelectObject(hdcd, vPreviouseBrush);
                                WindowsAPI.SelectObject(hdcd, vPreviousePen);
                            }
                            else
                                FillRectangle_API_Ex(hdcd, tempPen.Color, startPoint.X - EraserSize / 2, startPoint.Y - EraserSize / 2, EraserSize, EraserSize);
                        }
                        else
                        {
                            FillRectangle_API_Ex(hdcd, tempPen.Color, startPoint.X - EraserSize / 2, startPoint.Y - EraserSize / 2, EraserSize, EraserSize);
                        }
                        break;
                    }
                case ShapeType.Line:
                    {
                        if (!mouseDown)
                        {
                            DrawLine_API_Ex(hdcd, Pen, startPoint, endPoint);
                        }
                        break;
                    }
                case ShapeType.Curve:
                    {
                        if (!mouseDown)
                        {
                            if (points.Length == 2)
                                DrawLine_API_Ex(hdcd, Pen, startPoint, endPoint);
                            else
                                DrawPolyBezier_API_Ex(hdcd, Pen, points);
                        }
                        break;
                    }
                case ShapeType.AirBrush:
                    {
                        Bitmap bitmap = new Bitmap(1, 1);
                        Graphics = Graphics.FromImage(bitmap);
                        Graphics.FillRectangle(new SolidBrush(this.Pen.Color), new Rectangle(0, 0, 1, 1));
                        Graphics.Dispose();
                        switch (AirBrushStyle)
                        {
                            case 0:
                                {
                                    Random random = new Random();
                                    Graphics = Graphics.FromImage(ImageDrew);
                                    for (int i = -5; i < Convert.ToInt32(random.NextDouble() * 5); i++)
                                    {
                                        for (int j = -5; j < Convert.ToInt32(random.NextDouble() * i); j++)
                                            Graphics.DrawImage(bitmap, new Point(endPoint.X + Convert.ToInt32(random.NextDouble() * i), endPoint.Y + Convert.ToInt32(random.NextDouble() * j)));
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    Random random = new Random();
                                    Graphics = Graphics.FromImage(ImageDrew);
                                    for (int i = -8; i < Convert.ToInt32(random.NextDouble() * 9); i++)
                                    {
                                        for (int j = -8; j < Convert.ToInt32(random.NextDouble() * i); j++)
                                            Graphics.DrawImage(bitmap, new Point(endPoint.X + Convert.ToInt32(random.NextDouble() * i), endPoint.Y + Convert.ToInt32(random.NextDouble() * j)));
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Random random = new Random();
                                    Graphics = Graphics.FromImage(ImageDrew);
                                    for (int i = -12; i < 13; i++)
                                    {
                                        for (int j = -12; j < Convert.ToInt32(random.NextDouble() * i); j++)
                                        {
                                            Graphics.DrawImage(bitmap, new Point(endPoint.X + Convert.ToInt32(random.NextDouble() * i), endPoint.Y + Convert.ToInt32(random.NextDouble() * j)));
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case ShapeType.Brush:
                    {
                        Graphics = Graphics.FromImage(ImageStatus);
                        if (mouseDown)
                        {
                            if (startPoint != endPoint)
                            {
                                Pen tempPen = new Pen(Pen.Color);
                                tempPen.Width = BrushWidth;
                                if (BrushStyle == 0)
                                {
                                    tempPen.StartCap = LineCap.Round;
                                    tempPen.EndCap = LineCap.Round;
                                }
                                else if (BrushStyle == 1)
                                {
                                    tempPen.StartCap = LineCap.Square;
                                    tempPen.EndCap = LineCap.Square;
                                }
                                else if (BrushStyle == 2)
                                {
                                }
                                else if (BrushStyle == 3)
                                {
                                }

                                EraserPolygonPath.AddLine(new Point(startPoint.X, startPoint.Y), new Point(endPoint.X, endPoint.Y));
                                Graphics.DrawPath(tempPen, EraserPolygonPath);
                            }
                            else
                                Graphics.FillRectangle(Brush, new Rectangle(new Point(startPoint.X - EraserSize / 2, startPoint.Y - EraserSize / 2), new Size(EraserSize, EraserSize)));
                        }
                        else
                        {
                            Pen tempPen = new Pen(Pen.Color);
                            tempPen.Width = BrushWidth;
                            if (BrushStyle == 0)
                            {
                                tempPen.StartCap = LineCap.Round;
                                tempPen.EndCap = LineCap.Round;
                            }
                            else if (BrushStyle == 1)
                            {
                                tempPen.StartCap = LineCap.Square;
                                tempPen.EndCap = LineCap.Square;
                            }
                            else if (BrushStyle == 2)
                            {
                            }
                            else if (BrushStyle == 3)
                            {
                            }

                            EraserPolygonPath.AddLine(new Point(startPoint.X, startPoint.Y), new Point(endPoint.X, endPoint.Y));
                            Graphics.DrawPath(tempPen, EraserPolygonPath);
                        }
                        ImageDrew = ImageStatus;
                        break;
                    }
                case ShapeType.FillWithColor:
                    {
                        ImageToFill = (Image)ImageDrew.Clone();
                        FloodFill((Bitmap)ImageToFill, endPoint.X, endPoint.Y, Pen.Color);
                        break;
                    }
            }
        }

        private void DrawGDI_Fill2(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown, Color color, IntPtr hdcd)
        {
            this.Md = mouseDown;
            PointF rectStartPointF = startPoint;
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                FillRectangle_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                FillRectangle_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                        }
                        break;
                    }
                case ShapeType.Ellipse:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                FillEllipse_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                FillEllipse_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                        }
                        break;
                    }
                case ShapeType.Polygon:
                    {
                        DrawGDI_Line_Fill2(shapeType, startPoint, endPoint, mouseDown, color, Pen, hdcd);
                        break;
                    }
                case ShapeType.RoundedRectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (Convert.ToInt32(width) == 0 || Convert.ToInt32(height) == 0)
                            return;

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                FillRoundRectangle_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                            else
                            {
                                FillRoundRectangle_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                        }
                        break;
                    }
            }
        }

        private void DrawGDI_Line_Fill2(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown, Color color, Pen Pen, IntPtr hdcd)
        {
            this.Md = mouseDown;
            PointF rectStartPointF = startPoint;
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                FillRectangle_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                                DrawRectangle_API_Ex(hdcd, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                FillRectangle_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                                DrawRectangle_API_Ex(hdcd, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                        }
                        break;
                    }
                case ShapeType.Ellipse:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                FillEllipse_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                                DrawEllipse_API_Ex(hdcd, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                            else
                            {
                                FillEllipse_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                                DrawEllipse_API_Ex(hdcd, Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height));
                            }
                        }
                        break;
                    }
                case ShapeType.Polygon:
                    {
                        if (!mouseDown)
                        {
                            IntPtr vBrush = CreateColorBrush(Brushcolor);
                            IntPtr vPen = CreateRoundPen(Pen.Color);
                            IntPtr vPreviousBrush = WindowsAPI.SelectObject(hdcd, vBrush);
                            IntPtr vPreviousPen = WindowsAPI.SelectObject(hdcd, vPen);
                            WindowsAPI.Polygon(hdcd, PolygonPoints.ToArray(), PolygonPoints.Count);
                            WindowsAPI.SelectObject(hdcd, vPreviousBrush);
                            WindowsAPI.SelectObject(hdcd, vPreviousPen);
                        }
                        break;
                    }
                case ShapeType.RoundedRectangle:
                    {
                        float width = Math.Abs(endPoint.X - startPoint.X);
                        float height = Math.Abs(endPoint.Y - startPoint.Y);
                        if (endPoint.X < startPoint.X)
                        {
                            rectStartPointF.X = endPoint.X;
                        }
                        if (endPoint.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = endPoint.Y;
                        }

                        if (Convert.ToInt32(width) == 0 || Convert.ToInt32(height) == 0)
                            return;

                        if (!mouseDown)
                        {
                            if (this.Shift)
                            {
                                FillRoundRectangle_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                                DrawRoundRectangle_API_Ex(hdcd, this.Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                            else
                            {
                                FillRoundRectangle_API_Ex(hdcd, color, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                                DrawRoundRectangle_API_Ex(hdcd, this.Pen, Convert.ToInt32(rectStartPointF.X), Convert.ToInt32(rectStartPointF.Y), Convert.ToInt32(width), Convert.ToInt32(height), RoundX, RoundY);
                            }
                        }
                        break;
                    }
            }
        }

        #endregion

        #region Create a solid color image

        /// <summary>
        /// Create a solid color image
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(int width, int height, Color color)
        {
            if (width == 0 || height == 0)
                return null;
            if (color == Color.Empty)
                color = Color.White;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(new SolidBrush(color), new Rectangle(new Point(0, 0), new Size(width, height)));
            g.Dispose();
            return bitmap;
        }

        /// <summary>
        /// Create a solid color image
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(int width, int height, Color color, PixelFormat pixel)
        {
            if (width == 0 || height == 0)
                return null;
            if (color == Color.Empty)
                color = Color.White;
            Bitmap bitmap = new Bitmap(width, height, pixel);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(new SolidBrush(color), new Rectangle(new Point(0, 0), new Size(width, height)));
            g.Dispose();
            return bitmap;
        }

        /// <summary>
        /// Create a solid color image
        /// </summary>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(Size size, Color color)
        {
            if (size == Size.Empty)
                return null;
            if (color == Color.Empty)
                color = Color.White;
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(new SolidBrush(color), new Rectangle(new Point(0, 0), size));
            g.Dispose();
            return bitmap;
        }

        /// <summary>
        /// Create a solid color image
        /// </summary>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(Size size, Color color, PixelFormat pixel)
        {
            if (size == Size.Empty)
                return null;
            if (color == Color.Empty)
                color = Color.White;
            Bitmap bitmap = new Bitmap(size.Width, size.Height, pixel);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(new SolidBrush(color), new Rectangle(new Point(0, 0), size));
            g.Dispose();
            return bitmap;
        }

        #endregion

        #region Draw / fill the rounded rectangle

        /// <summary>
        /// Microsoft's API calls to draw the rounded rectangle to achieve the picture
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void DrawRoundRectangle_API_Ex(Image img, Pen pen, int x, int y, int width, int height, int radiusx, int radiusy)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawRoundRectangle_API_Ex(graphics, pen, x, y, width, height, radiusx, radiusy);
        }

        /// <summary>
        /// Microsoft's API calls to draw the rounded rectangle to achieve the picture
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void DrawRoundRectangle_API_Ex(Graphics graphics, Pen pen, int x, int y, int width, int height, int radiusx, int radiusy)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.RoundRect(vDC, x, y, x + width, y + height, radiusx, radiusy);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Microsoft's API calls to draw the rounded rectangle to achieve the picture
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void DrawRoundRectangle_API_Ex(IntPtr vDC, Pen pen, int x, int y, int width, int height, int radiusx, int radiusy)
        {
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.RoundRect(vDC, x, y, x + width, y + height, radiusx, radiusy);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
        }

        /// <summary>
        /// Microsoft's API calls to draw the rounded rectangle to achieve the picture
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pen"></param>
        /// <param name="rc"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void DrawRoundRectangle_API_Ex(Image img, Pen pen, Rectangle rc, int radiusx, int radiusy)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawRoundRectangle_API_Ex(graphics, pen, rc, radiusx, radiusy);
        }

        /// <summary>
        /// Microsoft's API calls to draw the rounded rectangle to achieve the picture
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="rc"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void DrawRoundRectangle_API_Ex(Graphics graphics, Pen pen, Rectangle rc, int radiusx, int radiusy)
        {
            DrawRoundRectangle_API_Ex(graphics, pen, rc.X, rc.Y, rc.Width, rc.Height, radiusx, radiusy);
        }

        /// <summary>
        /// Microsoft's API calls to draw the rounded rectangle to achieve the picture
        /// </summary>
        /// <param name="img"></param>
        /// <param name="color"></param>
        /// <param name="rc"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void FillRoundRectangle_API_Ex(Image img, Color color, Rectangle rc, int radiusx, int radiusy)
        {
            Graphics graphics = Graphics.FromImage(img);
            FillRoundRectangle_API_Ex(graphics, color, rc, radiusx, radiusy);
        }

        /// <summary>
        /// Microsoft's API calls to achieve the picture filled rounded rectangle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="color"></param>
        /// <param name="rc"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void FillRoundRectangle_API_Ex(Graphics graphics, Color color, Rectangle rc, int radiusx, int radiusy)
        {
            FillRoundRectangle_API_Ex(graphics, color, rc.X, rc.Y, rc.Width, rc.Height, radiusx, radiusy);
        }

        /// <summary>
        /// Microsoft's API calls to achieve the picture filled rounded rectangle
        /// </summary>
        /// <param name="img"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void FillRoundRectangle_API_Ex(Image img, Color color, int x, int y, int width, int height, int radiusx, int radiusy)
        {
            Graphics graphics = Graphics.FromImage(img);
            FillRoundRectangle_API_Ex(graphics, color, x, y, width, height, radiusx, radiusy);
        }

        /// <summary>
        /// Microsoft's API calls to achieve the picture filled rounded rectangle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void FillRoundRectangle_API_Ex(Graphics graphics, Color color, int x, int y, int width, int height, int radiusx, int radiusy)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            FillCreate(vDC, color, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.RoundRect(vDC, x, y, x + width, y + height, radiusx, radiusy);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Microsoft's API calls to achieve the picture filled rounded rectangle
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radiusx"></param>
        /// <param name="radiusy"></param>
        public static void FillRoundRectangle_API_Ex(IntPtr vDC, Color color, int x, int y, int width, int height, int radiusx, int radiusy)
        {
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            FillCreate(vDC, color, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.RoundRect(vDC, x, y, x + width, y + height, radiusx, radiusy);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
        }

        #endregion

        #region Draw / fill rectangle

        /// <summary>
        /// Draw a rectangle
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawRectangle_API_Ex(Image img, Pen pen, int x, int y, int width, int height)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawRectangle_API_Ex(graphics, pen, x, y, width, height);
        }

        /// <summary>
        /// Draw a rectangle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawRectangle_API_Ex(Graphics graphics, Pen pen, int x, int y, int width, int height)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Rectangle(vDC, x, y, x + width, y + height);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Draw a rectangle
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawRectangle_API_Ex(IntPtr vDC, Pen pen, int x, int y, int width, int height)
        {
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Rectangle(vDC, x, y, x + width, y + height);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
        }

        /// <summary>
        /// Draw a rectangle
        /// </summary>
        /// <param name="img"></param>
        /// <param name="Pen"></param>
        /// <param name="rc"></param>
        public static void DrawRectangle_API_Ex(Image img, Pen pen, Rectangle rc)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawRectangle_API_Ex(graphics, pen, rc);
        }

        /// <summary>
        /// Draw a rectangle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="rc"></param>
        public static void DrawRectangle_API_Ex(Graphics graphics, Pen pen, Rectangle rc)
        {
            DrawRectangle_API_Ex(graphics, pen, rc.X, rc.Y, rc.Width, rc.Height);
        }

        /// <summary>
        /// Filled
        /// </summary>
        /// <param name="img"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void FillRectangle_API_Ex(Image img, Color color, int x, int y, int width, int height)
        {
            Graphics graphics = Graphics.FromImage(img);
            FillRectangle_API_Ex(graphics, color, x, y, width, height);
        }

        /// <summary>
        /// Filled
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void FillRectangle_API_Ex(Graphics graphics, Color color, int x, int y, int width, int height)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            FillCreate(vDC, color, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Rectangle(vDC, x, y, x + width, y + height);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Filled
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void FillRectangle_API_Ex(IntPtr vDC, Color color, int x, int y, int width, int height)
        {
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            FillCreate(vDC, color, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Rectangle(vDC, x, y, x + width, y + height);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
        }

        /// <summary>
        /// Filled
        /// </summary>
        /// <param name="img"></param>
        /// <param name="color"></param>
        /// <param name="rc"></param>
        public static void FillRectangle_API_Ex(Image img, Color color, Rectangle rc)
        {
            Graphics graphics = Graphics.FromImage(img);
            FillRectangle_API_Ex(graphics, color, rc);
        }

        /// <summary>
        /// Filled
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="color"></param>
        /// <param name="rc"></param>
        public static void FillRectangle_API_Ex(Graphics graphics, Color color, Rectangle rc)
        {
            FillRectangle_API_Ex(graphics, color, rc.X, rc.Y, rc.Width, rc.Height);
        }

        #endregion

        #region Draw / Fill Ellipse

        /// <summary>
        ///Draw Ellipse
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawEllipse_API_Ex(Image img, Pen pen, int x, int y, int width, int height)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawEllipse_API_Ex(graphics, pen, x, y, width, height);
        }

        /// <summary>
        ///Draw Ellipse
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawEllipse_API_Ex(Graphics graphics, Pen pen, int x, int y, int width, int height)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Ellipse(vDC, x, y, x + width, y + height);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        ///Draw Ellipse
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawEllipse_API_Ex(IntPtr vDC, Pen pen, int x, int y, int width, int height)
        {
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Ellipse(vDC, x, y, x + width, y + height);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
        }

        /// <summary>
        ///Draw Ellipse
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pen"></param>
        /// <param name="rc"></param>
        public static void DrawEllipse_API_Ex(Image img, Pen pen, Rectangle rc)
        {
            Graphics vGraphics = Graphics.FromImage(img);
            DrawEllipse_API_Ex(vGraphics, pen, rc);
        }

        /// <summary>
        ///Draw Ellipse
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="rc"></param>
        public static void DrawEllipse_API_Ex(Graphics graphics, Pen pen, Rectangle rc)
        {
            DrawEllipse_API_Ex(graphics, pen, rc.X, rc.Y, rc.Width, rc.Height);
        }

        /// <summary>
        /// Filled Ellipse
        /// </summary>
        /// <param name="img"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void FillEllipse_API_Ex(Image img, Color color, int x, int y, int width, int height)
        {
            Graphics graphics = Graphics.FromImage(img);
            FillEllipse_API_Ex(graphics, color, x, y, width, height);
        }

        /// <summary>
        /// Filled Ellipse
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void FillEllipse_API_Ex(Graphics graphics, Color color, int x, int y, int width, int height)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            FillCreate(vDC, color, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Ellipse(vDC, x, y, x + width, y + height);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Filled Ellipse
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void FillEllipse_API_Ex(IntPtr vDC, Color color, int x, int y, int width, int height)
        {
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            FillCreate(vDC, color, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Ellipse(vDC, x, y, x + width, y + height);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
        }

        /// <summary>
        /// Filled Ellipse
        /// </summary>
        /// <param name="img"></param>
        /// <param name="color"></param>
        /// <param name="rc"></param>
        public static void FillEllipse_API_Ex(Image img, Color color, Rectangle rc)
        {
            Graphics graphics = Graphics.FromImage(img);
            FillEllipse_API_Ex(graphics, color, rc);
        }

        /// <summary>
        /// Filled Ellipse
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="color"></param>
        /// <param name="rc"></param>
        public static void FillEllipse_API_Ex(Graphics graphics, Color color, Rectangle rc)
        {
            FillEllipse_API_Ex(graphics, color, rc.X, rc.Y, rc.Width, rc.Height);
        }

        #endregion

        #region Draw a straight line

        /// <summary>
        /// Draw a straight line
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pen"></param>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        public static void DrawLine_API_Ex(Image img, Pen pen, Point startPoint, Point endPoint)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawLine_API_Ex(graphics, pen, startPoint, endPoint);
        }

        /// <summary>
        /// Draw a straight line
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        public static void DrawLine_API_Ex(Graphics graphics, Pen pen, Point startPoint, Point endPoint)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            Point pt = new Point();
            WindowsAPI.MoveToEx(vDC, startPoint.X, startPoint.Y, ref pt);
            WindowsAPI.LineTo(vDC, endPoint.X, endPoint.Y);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Draw a straight line
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="pen"></param>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        public static void DrawLine_API_Ex(IntPtr vDC, Pen pen, Point startPoint, Point endPoint)
        {
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            Point pt = new Point();
            WindowsAPI.MoveToEx(vDC, startPoint.X, startPoint.Y, ref pt);
            WindowsAPI.LineTo(vDC, endPoint.X, endPoint.Y);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
        }

        /// <summary>
        /// Draw a straight line
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public static void DrawLine_API_Ex(Image img, Pen pen, int x1, int y1, int x2, int y2)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawLine_API_Ex(graphics, pen, x1, y1, x2, y2);
        }

        /// <summary>
        /// Draw a straight line
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public static void DrawLine_API_Ex(Graphics graphics, Pen pen, int x1, int y1, int x2, int y2)
        {
            DrawLine_API_Ex(graphics, pen, new Point(x1, y1), new Point(x2, y2));
        }

        #endregion

        #region Draw / filled polygons

        /// <summary>
        /// Polygon
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pen"></param>
        /// <param name="points"></param>
        public static void DrawPolygon_API_Ex(Image img, Pen pen, Point[] points)
        {
            if (points.Length < 2)
                return;
            Graphics graphics = Graphics.FromImage(img);
            DrawPolygon_API_Ex(graphics, pen, points);
        }

        /// <summary>
        /// Polygon
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="points"></param>
        public static void DrawPolygon_API_Ex(Graphics graphics, Pen pen, Point[] points)
        {
            if (points.Length < 2)
                return;
            IntPtr vDC = graphics.GetHdc();
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Polygon(vDC, points, points.Length);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Polygon
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="pen"></param>
        /// <param name="points"></param>
        public static void DrawPolygon_API_Ex(IntPtr vDC, Pen pen, Point[] points)
        {
            if (points.Length < 2)
                return;
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            DrawCreate(vDC, pen, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Polygon(vDC, points, points.Length);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
        }

        /// <summary>
        /// Fill Polygon
        /// </summary>
        /// <param name="img"></param>
        /// <param name="color"></param>
        /// <param name="points"></param>
        public static void FillPolygon_API_Ex(Image img, Color color, Point[] points)
        {
            if (points.Length < 2)
                return;
            Graphics vGraphics = Graphics.FromImage(img);
            FillPolygon_API_Ex(vGraphics, color, points);
        }

        /// <summary>
        /// Fill Polygon
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="color"></param>
        /// <param name="points"></param>
        public static void FillPolygon_API_Ex(Graphics graphics, Color color, Point[] points)
        {
            if (points.Length < 2)
                return;
            IntPtr vDC = graphics.GetHdc();
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            FillCreate(vDC, color, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Polygon(vDC, points, points.Length);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Fill Polygon
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="color"></param>
        /// <param name="points"></param>
        public static void FillPolygon_API_Ex(IntPtr vDC, Color color, Point[] points)
        {
            if (points.Length < 2)
                return;
            IntPtr vPreviouseBrush, vPreviousePen, vBrush, vPen;
            FillCreate(vDC, color, out vPreviouseBrush, out vPreviousePen, out vBrush, out vPen);
            WindowsAPI.Polygon(vDC, points, points.Length);
            GDIRelease(vDC, vPreviousePen, vPreviousePen, vBrush, vPen);
        }

        #endregion

        #region Fill area

        /// <summary>
        /// Flood fill with old image
        /// </summary>
        /// <param name="bitmap">The bitmap</param>
        /// <param name="x">X location of current point</param>
        /// <param name="y">Y location of current point</param>
        /// <param name="color">The color to fill</param>
        public void FloodFill(Bitmap bitmap, int x, int y, Color color)
        {
            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] bits = new int[data.Stride / 4 * data.Height];
            Marshal.Copy(data.Scan0, bits, 0, bits.Length);

            LinkedList<Point> check = new LinkedList<Point>();
            int floodTo = color.ToArgb();
            int floodFrom = bits[x + y * data.Stride / 4];
            bits[x + y * data.Stride / 4] = floodTo;

            if (floodFrom != floodTo)
            {
                check.AddLast(new Point(x, y));
                while (check.Count > 0)
                {
                    Point cur = check.First.Value;
                    check.RemoveFirst();

                    foreach (Point off in new Point[] {
                new Point(0, -1), new Point(0, 1), 
                new Point(-1, 0), new Point(1, 0)})
                    {
                        Point next = new Point(cur.X + off.X, cur.Y + off.Y);
                        if (next.X >= 0 && next.Y >= 0 &&
                            next.X < data.Width &&
                            next.Y < data.Height)
                        {
                            if (bits[next.X + next.Y * data.Stride / 4] == floodFrom)
                            {
                                check.AddLast(next);
                                bits[next.X + next.Y * data.Stride / 4] = floodTo;
                            }
                        }
                    }
                }
            }

            Marshal.Copy(bits, 0, data.Scan0, bits.Length);
            bitmap.UnlockBits(data);
        }

        /// <summary>
        /// Fill area
        /// </summary>
        /// <param name="img"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public static void FloodFill1(Image img, int x, int y, Color color)
        {
            Graphics vGraphics = Graphics.FromImage(img);
            FloodFill1(vGraphics, x, y, color);
        }

        /// <summary>
        /// Fill area
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public static void FloodFill1(Graphics graphics, int x, int y, Color color)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr vBrush = WindowsAPI.CreateSolidBrush(ColorTranslator.ToWin32(color));
            IntPtr vPreviouseBrush = WindowsAPI.SelectObject(vDC, vBrush);
            WindowsAPI.ExtFloodFill(vDC, x, y, WindowsAPI.GetPixel(vDC, x, y), CommonConst.FLOODFILLSURFACE);
            WindowsAPI.SelectObject(vDC, vPreviouseBrush);
            WindowsAPI.DeleteObject(vBrush);
            //DDCan
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Fill area
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public static void FloodFill1(IntPtr vDC, int x, int y, Color color)
        {
            IntPtr vBrush = WindowsAPI.CreateSolidBrush(ColorTranslator.ToWin32(color));
            IntPtr vPreviouseBrush = WindowsAPI.SelectObject(vDC, vBrush);
            WindowsAPI.ExtFloodFill(vDC, x, y, WindowsAPI.GetPixel(vDC, x, y), CommonConst.FLOODFILLSURFACE);
            WindowsAPI.SelectObject(vDC, vPreviouseBrush);
            WindowsAPI.DeleteObject(vBrush);
        }

        /// <summary>
        /// Fill area
        /// </summary>
        /// <param name="img"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public static void FloodFill2(Image img, int x, int y, Color color)
        {
            Graphics vGraphics = Graphics.FromImage(img);
            FloodFill2(vGraphics, x, y, color);
        }

        /// <summary>
        /// Fill area
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public static void FloodFill2(Graphics graphics, int x, int y, Color color)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr vBrush = WindowsAPI.CreateSolidBrush(ColorTranslator.ToWin32(color));
            IntPtr vPreviouseBrush = WindowsAPI.SelectObject(vDC, vBrush);
            WindowsAPI.ExtFloodFill(vDC, x, y, WindowsAPI.GetPixel(vDC, x, y), CommonConst.FLOODFILLBORDER);
            WindowsAPI.SelectObject(vDC, vPreviouseBrush);
            WindowsAPI.DeleteObject(vBrush);
            //DDCan
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Fill area
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public static void FloodFill2(IntPtr vDC, int x, int y, Color color)
        {
            IntPtr vBrush = WindowsAPI.CreateSolidBrush(ColorTranslator.ToWin32(color));
            IntPtr vPreviouseBrush = WindowsAPI.SelectObject(vDC, vBrush);
            WindowsAPI.ExtFloodFill(vDC, x, y, WindowsAPI.GetPixel(vDC, x, y), CommonConst.FLOODFILLBORDER);
            WindowsAPI.SelectObject(vDC, vPreviouseBrush);
            WindowsAPI.DeleteObject(vBrush);
        }

        #endregion

        #region Draw Border

        /// <summary>
        /// Draw Border
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rc"></param>
        public static void DrawEdge_API_Ex(Image img, Rectangle rc)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawEdge_API_Ex(graphics, rc);
        }

        /// <summary>
        /// Draw Border
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="rc"></param>
        public static void DrawEdge_API_Ex(Graphics graphics, Rectangle rc)
        {
            IntPtr vDC = graphics.GetHdc();
            RECT rect = new RECT(rc);
            WindowsAPI.DrawEdge(vDC, ref rect, CommonConst.BDR_RAISEDINNER | CommonConst.BDR_SUNKENOUTER, CommonConst.BF_RECT | CommonConst.BF_FLAT);
            //DDCan
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Draw Border
        /// </summary>
        /// <param name="img"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawEdge_API_Ex(Image img, int x, int y, int width, int height)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawEdge_API_Ex(graphics, x, y, width, height);
        }

        /// <summary>
        /// Draw Border
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawEdge_API_Ex(Graphics graphics, int x, int y, int width, int height)
        {
            DrawEdge_API_Ex(graphics, new RECT(x, y, width, height));
        }

        #endregion

        #region Dotted rectangle drawn

        /// <summary>
        /// Dotted rectangle drawn
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rc"></param>
        public static void DrawFocusRect_API_Ex(Image img, Rectangle rc)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawFocusRect_API_Ex(graphics, rc);
        }

        /// <summary>
        /// Dotted rectangle drawn
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="rc"></param>
        public static void DrawFocusRect_API_Ex(Graphics graphics, Rectangle rc)
        {
            IntPtr vDC = graphics.GetHdc();
            RECT rect = new RECT(rc);
            WindowsAPI.DrawFocusRect(vDC, ref rect);
            //DDCan
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Dotted rectangle drawn
        /// </summary>
        /// <param name="img"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawFocusRect_API_Ex(Image img, int x, int y, int width, int height)
        {
            Graphics graphics = Graphics.FromImage(img);
            DrawFocusRect_API_Ex(graphics, x, y, width, height);
        }

        /// <summary>
        /// Dotted rectangle drawn
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawFocusRect_API_Ex(Graphics graphics, int x, int y, int width, int height)
        {
            DrawFocusRect_API_Ex(graphics, new RECT(x, y, width, height));
        }

        #endregion

        #region Draw curve

        /// <summary>
        /// Draw curve
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pen"></param>
        /// <param name="points"></param>
        public static void DrawPolyBezier_API_Ex(Image img, Pen pen, Point[] points)
        {
            Graphics vGraphics = Graphics.FromImage(img);
            DrawPolyBezier_API_Ex(vGraphics, pen, points);
        }

        /// <summary>
        /// Draw curve
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="points"></param>
        public static void DrawPolyBezier_API_Ex(Graphics graphics, Pen pen, Point[] points)
        {
            IntPtr vDC = graphics.GetHdc();
            IntPtr previouseBrush, previousePen, brush, vPen;
            DrawCreate(vDC, pen, out previouseBrush, out previousePen, out brush, out vPen);
            WindowsAPI.PolyBezier(vDC, points, 4);
            GDIRelease(vDC, previousePen, previousePen, brush, vPen);
            graphics.ReleaseHdc(vDC);
            //DDCan
            graphics.ReleaseHdc(vDC);
        }

        /// <summary>
        /// Draw curve
        /// </summary>
        /// <param name="vDC"></param>
        /// <param name="pen"></param>
        /// <param name="points"></param>
        public static void DrawPolyBezier_API_Ex(IntPtr vDC, Pen pen, Point[] points)
        {
            IntPtr previouseBrush, previousePen, brush, vPen;
            DrawCreate(vDC, pen, out previouseBrush, out previousePen, out brush, out vPen);
            WindowsAPI.PolyBezier(vDC, points, 4);
            GDIRelease(vDC, previousePen, previousePen, brush, vPen);
        }

        #endregion

        #region Draw control framework

        /// <summary>
        /// Draw control framework
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rc"></param>
        public static void DrawFrameControl_API_Ex(Image img, Rectangle rc)
        {
            Graphics vGraphics = Graphics.FromImage(img);
            DrawFrameControl_API_Ex(vGraphics, rc);
        }

        /// <summary>
        /// Draw control framework
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="rc"></param>
        public static void DrawFrameControl_API_Ex(Graphics graphics, Rectangle rc)
        {
            IntPtr vDC = graphics.GetHdc();
            RECT rect = new RECT(rc);
            WindowsAPI.DrawFrameControl(vDC, ref rect, CommonConst.DFC_BUTTON, CommonConst.DFCS_PUSHED | CommonConst.DFCS_BUTTONPUSH);
            //DDCan
            graphics.ReleaseHdc(vDC);
        }

        #endregion

        #region Picture rotation

        /// <summary>
        /// Picture rotation (clockwise rotation)
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="angle"></param>
        /// <param name="bkColor"></param>
        /// <returns></returns>
        public static Bitmap RotateWise(Bitmap bmp, float angle, Color bkColor)
        {
            int w = bmp.Width + 2;
            int h = bmp.Height + 2;

            PixelFormat pixelFormat;

            if (bkColor == Color.Transparent)
                pixelFormat = PixelFormat.Format32bppArgb;
            else
                pixelFormat = bmp.PixelFormat;

            Bitmap tmp = new Bitmap(w, h, pixelFormat);
            Graphics g = Graphics.FromImage(tmp);
            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            Matrix mtrx = new Matrix();
            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);

            Bitmap result = new Bitmap((int)rct.Width, (int)rct.Height, pixelFormat);
            g = Graphics.FromImage(result);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tmp, 0, 0);
            g.Dispose();

            tmp.Dispose();

            return result;
        }

        /// <summary>
        /// Picture rotation (counterclockwise rotation)
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="angle"></param>
        /// <param name="bkColor"></param>
        /// <returns></returns>
        public static Bitmap RotateInverse(Bitmap bmp, float angle, Color bkColor)
        {
            int w = bmp.Width + 2;
            int h = bmp.Height + 2;
            angle = angle % 360;
            angle = 360 - angle;
            PixelFormat pixelFormat;

            if (bkColor == Color.Transparent)
                pixelFormat = PixelFormat.Format32bppArgb;
            else
                pixelFormat = bmp.PixelFormat;

            Bitmap tmp = new Bitmap(w, h, pixelFormat);
            tmp.MakeTransparent();
            Graphics g = Graphics.FromImage(tmp);

            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            Matrix mtrx = new Matrix();
            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);

            Bitmap result = new Bitmap((int)rct.Width, (int)rct.Height, pixelFormat);
            g = Graphics.FromImage(result);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tmp, 0, 0);
            g.Dispose();

            tmp.Dispose();

            return result;
        }

        #endregion

        #region Draw dot-matrix

        /// <summary>
        /// Draw dot-matrix
        /// </summary>
        /// <param name="source"></param>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap DrawSquare(Image source, int size, Color color)
        {
            if (source == null || size < 0)
                return null;
            Bitmap dest = (Bitmap)source.Clone();
            int width = dest.Size.Width, height = dest.Size.Height;
            Graphics g = Graphics.FromImage(dest);
            for (int i = size; i < width; i += size * 2)
            {
                for (int j = size; j < height; j += size * 2)
                {
                    g.FillRectangle(new SolidBrush(color), new Rectangle(new Point(i, j), new Size(size, size)));
                }
            }
            return dest;
        }

        /// <summary>
        /// Draw dot-matrix
        /// </summary>
        /// <param name="source"></param>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap DrawSquareEx(Image source, int size, Color color)
        {
            if (source == null || size < 0)
                return null;
            Bitmap dest = (Bitmap)source.Clone();
            int width = dest.Size.Width, height = dest.Size.Height;
            Graphics g = Graphics.FromImage(dest);
            int style = 0;
            for (int i = 0; i < height; i += size)
            {
                if (style == size)
                    style = 0;
                else
                    style = size;
                for (int j = style; j < width; j += size * 2)
                {
                    g.FillRectangle(new SolidBrush(color), new Rectangle(new Point(i, j), new Size(size, size)));
                }
            }
            return dest;
        }

        #endregion

        #region Photo Synthesis

        /// <summary>
        /// Photo Synthesis
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Bitmap CombineBitmap(Image destination, Image source, int x, int y)
        {
            if (destination == null || source == null)
                return null;
            Image imgSource = (Image)destination.Clone();
            Graphics g = Graphics.FromImage(imgSource);
            g.DrawImage(source, x, y);
            return new Bitmap(imgSource);
        }

        /// <summary>
        /// Photo Synthesis
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Bitmap CombineBitmap(Image destination, Image source, Point p)
        {
            if (destination == null || source == null)
                return null;
            Image imgSource = (Image)destination.Clone();
            Graphics g = Graphics.FromImage(imgSource);
            g.DrawImage(source, p.X, p.Y);
            return new Bitmap(imgSource);
        }

        #endregion

        #region Color reversal

        /// <summary>
        /// Color reversal
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static bool Invert(ref Bitmap bmp)
        {
            P2PFunc func = new P2PFunc(InvertFunc);

            return P2PCore(ref bmp, func);
        }

        private static void InvertFunc(ref byte r, ref byte g, ref byte b, params double[] param)
        {
            r = (byte)(255 - r);
            g = (byte)(255 - g);
            b = (byte)(255 - b);
        }

        private delegate void P2PFunc(ref byte r, ref byte g, ref byte b, params double[] param);

        private static bool P2PCore(ref Bitmap bmp, P2PFunc func, params double[] param)
        {
            if (bmp.PixelFormat != PixelFormat.Format24bppRgb)
                return false;

            int w = bmp.Width;
            int h = bmp.Height;

            byte r, g, b;
            int ir;

            BmpProc24 bd = new BmpProc24(bmp);

            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    ir = bd.IndexR(x, y);

                    r = bd[ir]; g = bd[ir - 1]; b = bd[ir - 2];

                    func(ref r, ref g, ref b, param);

                    bd[ir] = r; bd[ir - 1] = g; bd[ir - 2] = b;
                }

            bd.Dispose();

            return true;
        }

        private class BmpProc24 : IDisposable
        {
            private bool flagDispose = false;

            private Bitmap rbmp;
            private int w, h;
            private BitmapData bmpData;
            private IntPtr ptr;
            private int stride;
            private int bytes;
            private byte[] data;
            private int xyr, xyg, xyb;

            public BmpProc24(Bitmap bmp)
            {
                rbmp = bmp;
                w = bmp.Width;
                h = bmp.Height;
                Rectangle rect = new Rectangle(0, 0, w, h);
                bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite,
                                              PixelFormat.Format24bppRgb);
                ptr = bmpData.Scan0;
                stride = Math.Abs(bmpData.Stride);

                bytes = stride * h;
                data = new byte[bytes];
                Marshal.Copy(ptr, data, 0, bytes);
            }

            public byte this[int x, int y, eRGB rgb]
            {
                get { return data[stride * y + x * 3 + (int)(rgb)]; }
                set { data[stride * y + x * 3 + (int)(rgb)] = value; }
            }

            public byte this[int index]
            {
                get { return data[index]; }
                set { data[index] = value; }
            }

            public int IndexR(int x, int y)
            {
                return stride * y + x * 3 + 2;
            }

            public void SetXY(int x, int y)
            {
                xyb = stride * y + x * 3;
                xyg = xyb + 1;
                xyr = xyg + 1;
            }

            public byte R
            {
                get { return data[xyr]; }
                set { data[xyr] = value; }
            }

            public byte G
            {
                get { return data[xyg]; }
                set { data[xyg] = value; }
            }

            public byte B
            {
                get { return data[xyb]; }
                set { data[xyb] = value; }
            }

            public int DataLength
            {
                get { return bytes; }
            }

            protected virtual void Dispose(bool flag)
            {
                if (!flagDispose)
                {
                    if (flag)
                    {
                        Marshal.Copy(data, 0, ptr, bytes);
                        rbmp.UnlockBits(bmpData);
                    }
                    flagDispose = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            ~BmpProc24()
            {
                Dispose(false);
            }
        }

        private enum eRGB
        {
            b, g, r, a
        }

        #endregion

        #region GDI preparation

        /// <summary>
        /// Replacement of GDI objects
        /// </summary>
        /// <param name="drawCreate"></param>
        /// <param name="pen"></param>
        /// <param name="previouseBrush"></param>
        /// <param name="previousePen"></param>
        /// <param name="brush"></param>
        /// <param name="vPen"></param>
        public static void DrawCreate(IntPtr drawCreate, Pen pen, out IntPtr previouseBrush, out IntPtr previousePen, out IntPtr brush, out IntPtr vPen)
        {
            // create a transparent brush
            brush = WindowsAPI.GetStockObject(CommonConst.NULL_BRUSH);  
            vPen = CreateFlatPen(pen.Color, (uint)pen.Width);
            previouseBrush = WindowsAPI.SelectObject(drawCreate, brush);
            previousePen = WindowsAPI.SelectObject(drawCreate, vPen);
        }

        /// <summary>
        /// Restore and delete the newly created object
        /// </summary>
        /// <param name="drawCreate"></param>
        /// <param name="previouseBrush"></param>
        /// <param name="previousePen"></param>
        /// <param name="brush"></param>
        /// <param name="pen"></param>
        public static void GDIRelease(IntPtr drawCreate, IntPtr previouseBrush, IntPtr previousePen, IntPtr brush, IntPtr pen)
        {
            WindowsAPI.SelectObject(drawCreate, previouseBrush);
            WindowsAPI.SelectObject(drawCreate, previousePen);
            WindowsAPI.DeleteObject(brush);
            WindowsAPI.DeleteObject(pen);
        }

        /// <summary>
        /// Replacement of GDI objects
        /// </summary>
        /// <param name="drawCreate"></param>
        /// <param name="color"></param>
        /// <param name="previouseBrush"></param>
        /// <param name="previousePen"></param>
        /// <param name="brush"></param>
        /// <param name="pen"></param>
        public static void FillCreate(IntPtr drawCreate, Color color, out IntPtr previouseBrush, out IntPtr previousePen, out IntPtr brush, out IntPtr pen)
        {
            brush = WindowsAPI.CreateSolidBrush(ColorTranslator.ToWin32(color));
            previouseBrush = WindowsAPI.SelectObject(drawCreate, brush);
            pen = WindowsAPI.CreatePen(CommonConst.PS_SOLID, 1, ColorTranslator.ToWin32(color));
            previousePen = WindowsAPI.SelectObject(drawCreate, pen);
        }

        /// <summary>
        /// Create a circular pen
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static IntPtr CreateRoundPen(Color color, uint width)
        {
            LOGBRUSH lp = new LOGBRUSH();
            lp.lbColor = WindowsAPI.RGB(color);
            IntPtr vPen = WindowsAPI.ExtCreatePen(CommonConst.PS_GEOMETRIC | CommonConst.PS_SOLID | CommonConst.PS_ENDCAP_ROUND | CommonConst.PS_JOIN_MITER, width, ref lp, 0, null);
            return vPen;
        }

        /// <summary>
        /// Create a circular pen
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public static IntPtr CreateRoundPen(uint width)
        {
            LOGBRUSH lp = new LOGBRUSH();
            lp.lbColor = WindowsAPI.RGB(Color.Black);
            IntPtr vPen = WindowsAPI.ExtCreatePen(CommonConst.PS_GEOMETRIC | CommonConst.PS_SOLID | CommonConst.PS_ENDCAP_ROUND | CommonConst.PS_JOIN_MITER, width, ref lp, 0, null);
            return vPen;
        }

        /// <summary>
        /// Create a circular pen
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static IntPtr CreateRoundPen(Color color)
        {
            LOGBRUSH lp = new LOGBRUSH();
            lp.lbColor = WindowsAPI.RGB(color);
            IntPtr vPen = WindowsAPI.ExtCreatePen(CommonConst.PS_GEOMETRIC | CommonConst.PS_SOLID | CommonConst.PS_ENDCAP_ROUND | CommonConst.PS_JOIN_MITER, 1, ref lp, 0, null);
            return vPen;
        }

        /// <summary>
        /// Create a square pen
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static IntPtr CreateSquarePen(Color color, uint width)
        {
            LOGBRUSH lp = new LOGBRUSH();
            lp.lbColor = WindowsAPI.RGB(color);
            IntPtr vPen = WindowsAPI.ExtCreatePen(CommonConst.PS_GEOMETRIC | CommonConst.PS_SOLID | CommonConst.PS_ENDCAP_SQUARE | CommonConst.PS_JOIN_MITER, width, ref lp, 0, null);
            return vPen;
        }

        /// <summary>
        /// Create a square pen
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public static IntPtr CreateSquarePen(uint width)
        {
            LOGBRUSH lp = new LOGBRUSH();
            lp.lbColor = WindowsAPI.RGB(Color.Black);
            IntPtr vPen = WindowsAPI.ExtCreatePen(CommonConst.PS_GEOMETRIC | CommonConst.PS_SOLID | CommonConst.PS_ENDCAP_SQUARE | CommonConst.PS_JOIN_MITER, width, ref lp, 0, null);
            return vPen;
        }

        /// <summary>
        /// Create a square pen
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static IntPtr CreateSquarePen(Color color)
        {
            LOGBRUSH lp = new LOGBRUSH();
            lp.lbColor = WindowsAPI.RGB(color);
            IntPtr vPen = WindowsAPI.ExtCreatePen(CommonConst.PS_GEOMETRIC | CommonConst.PS_SOLID | CommonConst.PS_ENDCAP_SQUARE | CommonConst.PS_JOIN_MITER, 1, ref lp, 0, null);
            return vPen;
        }

        /// <summary>
        /// Create a flat-shaped pen
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static IntPtr CreateFlatPen(Color color, uint width)
        {
            LOGBRUSH lp = new LOGBRUSH();
            lp.lbColor = WindowsAPI.RGB(color);
            IntPtr vPen = WindowsAPI.ExtCreatePen(CommonConst.PS_GEOMETRIC | CommonConst.PS_SOLID | CommonConst.PS_ENDCAP_FLAT | CommonConst.PS_JOIN_MITER, width, ref lp, 0, null);
            return vPen;
        }

        /// <summary>
        /// Create a flat-shaped pen
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public static IntPtr CreateFlatPen(uint width)
        {
            LOGBRUSH lp = new LOGBRUSH();
            lp.lbColor = WindowsAPI.RGB(Color.Black);
            IntPtr vPen = WindowsAPI.ExtCreatePen(CommonConst.PS_GEOMETRIC | CommonConst.PS_SOLID | CommonConst.PS_ENDCAP_FLAT | CommonConst.PS_JOIN_MITER, width, ref lp, 0, null);
            return vPen;
        }

        /// <summary>
        /// Create a flat-shaped pen
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static IntPtr CreateFlatPen(Color color)
        {
            LOGBRUSH lp = new LOGBRUSH();
            lp.lbColor = WindowsAPI.RGB(color);
            IntPtr vPen = WindowsAPI.ExtCreatePen(CommonConst.PS_GEOMETRIC | CommonConst.PS_SOLID | CommonConst.PS_ENDCAP_FLAT | CommonConst.PS_JOIN_MITER, 1, ref lp, 0, null);
            return vPen;
        }

        /// <summary>
        /// Create an empty brush
        /// </summary>
        public static IntPtr CreateNullBrush()
        {
            IntPtr vBrush = WindowsAPI.GetStockObject(CommonConst.NULL_BRUSH);  
            return vBrush;
        }

        /// <summary>
        /// Create colored brush
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static IntPtr CreateColorBrush(Color color)
        {
            IntPtr vBrush = WindowsAPI.CreateSolidBrush(ColorTranslator.ToWin32(color));
            return vBrush;
        }

        /// <summary>
        /// Create an empty document
        /// </summary>
        public static IntPtr CreateNullPen()
        {
            IntPtr vPen = WindowsAPI.GetStockObject(CommonConst.NULL_PEN);
            return vPen;
        }

        /// <summary>
        /// Replace Color brush
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="color"></param>
        public static void ChangeBrushColor(IntPtr hdc, Color color)
        {
            WindowsAPI.SetDCBrushColor(hdc, WindowsAPI.RGB(color));
        }

        /// <summary>
        /// Replacement pen color
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="color"></param>
        public static void ChangePenColor(IntPtr hdc, Color color)
        {
            WindowsAPI.SetDCPenColor(hdc, WindowsAPI.RGB(color));
        }

        #endregion

        #region The process of drawing class

        private class DrawProcess
        {
            #region Public propertise
            /// <summary>
            /// Draw Type
            /// </summary>
            public ShapeType ShapeTypeValue { get; set; }
            /// <summary>
            /// Start position
            /// </summary>
            public Point StartPoint { get; set; }
            /// <summary>
            /// End point
            /// </summary>
            public Point EndPoint { get; set; }
            /// <summary>
            /// Is the mouse to leave the event (that is, to determine whether the MouseUp event)
            /// </summary>
            public bool MouseDown { get; set; }
            /// <summary>
            /// Canvas Size
            /// </summary>
            public Size CanvasSize { get; set; }
            /// <summary>
            /// Current pen
            /// </summary>
            public Pen PenUsed { get; set; }
            /// <summary>
            /// Current brush
            /// </summary>
            public Brush BrushUsed { get; set; }
            /// <summary>
            ///Fill type used for drawing geometry
            /// </summary>
            public int FillType { get; set; }
            /// <summary>
            /// When drawing the path of pen or rubber
            /// </summary>
            public List<LinePoint> LinePoints { get; set; }
            /// <summary>
            /// Polygon
            /// </summary>
            public List<Point> PolygonPoints { get; set; }
            /// <summary>
            /// Draw curve
            /// </summary>
            public List<Point> CurvePoints { get; set; }
            #endregion

            public DrawProcess()
            {
                LinePoints = new List<LinePoint>();
                PolygonPoints = new List<Point>();
                CurvePoints = new List<Point>();
            }
            public DrawProcess(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown, Size canvasSize, Pen penUsed, Brush brushUsed, int fillType, LinePoint linePoint, Point polygonPoint) 
                : this()
            {
                ShapeTypeValue = shapeType;
                StartPoint = startPoint;
                EndPoint = endPoint;
                MouseDown = mouseDown;
                CanvasSize = canvasSize;
                PenUsed = penUsed;
                BrushUsed = brushUsed;
                FillType = fillType;
                if (linePoint != LinePoint.Empty)
                    LinePoints.Add(linePoint);
                if (polygonPoint != Point.Empty)
                    PolygonPoints.Add(polygonPoint);
            }
            public DrawProcess(ShapeType shapeType, Point startPoint, Point endPoint, bool mouseDown, Size canvasSize, Pen penUsed, Brush brushUsed, int fillType, LinePoint linePoint) 
                : this()
            {
                ShapeTypeValue = shapeType;
                StartPoint = startPoint;
                EndPoint = endPoint;
                MouseDown = mouseDown;
                CanvasSize = canvasSize;
                PenUsed = penUsed;
                BrushUsed = brushUsed;
                FillType = fillType;
                if (linePoint != LinePoint.Empty)
                    LinePoints.Add(linePoint);
            }
           
            /// <summary>
            /// Add a pen or the eraser path
            /// </summary>
            /// <param name="linePoint"></param>
            public void AddLinePoint(LinePoint linePoint)
            {
                if (linePoint != LinePoint.Empty)
                    LinePoints.Add(linePoint);
            }
            /// <summary>
            /// Add a polygon path
            /// </summary>
            /// <param name="polygonPoint"></param>
            public void AddPolygonPoint(List<Point> polygonPoint)
            {
                PolygonPoints.Clear();
                PolygonPoints.AddRange(polygonPoint);
            }
            /// <summary>
            /// Add a curved path points
            /// </summary>
            /// <param name="curvePoint"></param>
            public void AddCurvePoint(Point curvePoint)
            {
                CurvePoints.Add(curvePoint);
            }
            /// <summary>
            /// Into the curved path
            /// </summary>
            /// <param name="cp"></param>
            /// <param name="pos"></param>
            public void InsertCurvePoint(Point cp, int pos)
            {
                if (CurvePoints.Count == 4)
                    CurvePoints.RemoveAt(1);
                CurvePoints.Insert(pos, cp);
            }
        }

        /// <summary>
        /// Create a pen or rubber path
        /// </summary>
        private struct LinePoint
        {
            public Point StartPoint;
            public Point EndPoint;

            public LinePoint(Point startPoint, Point endPoint)
            {
                StartPoint = startPoint;
                EndPoint = endPoint;
            }

            /// <summary>
            /// Determine the current LinePoint object is empty
            /// </summary>
            public static LinePoint Empty = new LinePoint();

            /// <summary>
            /// Overloading == to compare objects to Empty
            /// </summary>
            /// <param name="lp1"></param>
            /// <param name="lp2"></param>
            /// <returns></returns>
            public static bool operator ==(LinePoint lp1, LinePoint lp2)
            {
                if (lp1.StartPoint == lp2.StartPoint && lp1.EndPoint == lp2.EndPoint)
                    return true;
                return false;
            }

            /// <summary>
            /// Heavy! = used to compare the object with the Empty
            /// </summary>
            /// <param name="lp1"></param>
            /// <param name="lp2"></param>
            /// <returns></returns>
            public static bool operator !=(LinePoint lp1, LinePoint lp2)
            {
                if (lp1.StartPoint != lp2.StartPoint || lp1.EndPoint != lp2.EndPoint)
                    return true;
                return false;
            }

            public override bool Equals(object obj)
            {
                if (((LinePoint)obj).StartPoint == StartPoint && ((LinePoint)obj).EndPoint == EndPoint)
                    return true;
                return false;
            }
        }

        #endregion

        #region Select area
        public struct MoveSelectedPoint
        {
            /// <summary>
            /// Gets or sets whether the selected point can move
            /// </summary>
            public bool Enable { get; set; }
            /// <summary>
            /// Selected point
            /// </summary>
            public Point StartPoint { get; set; }
        }
        /// <summary>
        /// Check selection area is valid
        /// </summary>
        /// <param name="rec"></param>
        /// <returns>true if selection area not null and size is valid, otherwise false</returns>
        private bool IsValidSelectionArea(Rectangle rec)
        {
            return rec != null && rec.Height > 0 && rec.Width > 0;
        }
        /// <summary>
        /// Determines whether [is in selected area] [the specified location].
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns>
        /// true if [is in selected area] [the specified location]; otherwise, false.
        /// </returns>
        public bool IsInSelectedArea(Point location)
        {
            return IsAreaSelected && (SelectArea != null && SelectArea.Contains(location));
        }
        /// <summary>
        /// Moves the selected area.
        /// </summary>
        /// <param name="mouseLocation">The mouse location.</param>
        public void MoveSelectedArea(Point mouseLocation)
        {
            IsMovingSelectionArea = true;
            if (IsAreaSelected && MoveSelectedAreaEnable.Enable)
            {
                SelectArea.X += (mouseLocation.X - MoveSelectedAreaEnable.StartPoint.X);
                SelectArea.Y += (mouseLocation.Y - MoveSelectedAreaEnable.StartPoint.Y);
                MoveSelectedAreaEnable = new MoveSelectedPoint()
                {
                    Enable = true,
                    StartPoint = mouseLocation
                };

                DrawSelectionArea(SelectArea.Location, new Point(SelectArea.X + SelectArea.Width, SelectArea.Y + SelectArea.Height), true, true);

            }
            IsMovingSelectionArea = false;
        }
        /// <summary>
        /// Draws the selection area
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="finished"></param>
        /// <param name="imageInSelection"></param>
        public void DrawSelectionArea(Point startPoint, Point endPoint, bool finished, bool imageInSelection)
        {
            Pen pen = new Pen(Brushes.Gray);
            pen.DashStyle = DashStyle.Dash;

            float width = Math.Abs(startPoint.X - endPoint.X);
            float height = Math.Abs(startPoint.Y - endPoint.Y);
            SelectArea.X = Math.Min(startPoint.X, endPoint.X);
            SelectArea.Y = Math.Min(startPoint.Y, endPoint.Y);
            
            ImageDrew = (Image)ImageStatus.Clone();
            Graphics = Graphics.FromImage(ImageDrew);

            SelectArea = new Rectangle(Convert.ToInt32(SelectArea.X),
                                        Convert.ToInt32(SelectArea.Y),
                                        Convert.ToInt32(width), Convert.ToInt32(height));

            if (imageInSelection && SelectionImage != null)
            {
                using (Graphics g = Graphics.FromImage(ImageDrew))
                {
                    g.DrawImage(SelectionImage, SelectArea.Location);
                }
            }
            Graphics.DrawRectangle(pen, SelectArea);
            // Draw 8 small rectangle if selection area is valid
            if (SelectArea != null && SelectArea.Width > 0 && SelectArea.Height > 0)
            {
                Pen smallPen = new Pen(Brushes.Gray);

                Graphics.FillRectangle(Brushes.White, SelectArea.X - 2, SelectArea.Y - 2, 4, 4);
                Graphics.DrawRectangle(smallPen, SelectArea.X - 2, SelectArea.Y - 2, 4, 4);

                Graphics.FillRectangle(Brushes.White, SelectArea.X - 2, SelectArea.Y + height - 2, 4, 4);
                Graphics.DrawRectangle(smallPen, SelectArea.X - 2, SelectArea.Y + height - 2, 4, 4);

                Graphics.FillRectangle(Brushes.White, SelectArea.X - 2, SelectArea.Y + height / 2, 4, 4);
                Graphics.DrawRectangle(smallPen, SelectArea.X - 2, SelectArea.Y + height / 2, 4, 4);

                Graphics.FillRectangle(Brushes.White, SelectArea.X + width - 2, SelectArea.Y + height / 2, 4, 4);
                Graphics.DrawRectangle(smallPen, SelectArea.X + width - 2, SelectArea.Y + height / 2, 4, 4);

                Graphics.FillRectangle(Brushes.White, SelectArea.X + width - 2, SelectArea.Y + height - 2, 4, 4);
                Graphics.DrawRectangle(smallPen, SelectArea.X + width - 2, SelectArea.Y + height - 2, 4, 4);

                Graphics.FillRectangle(Brushes.White, SelectArea.X + width - 2, SelectArea.Y - 2, 4, 4);
                Graphics.DrawRectangle(smallPen, SelectArea.X + width - 2, SelectArea.Y - 2, 4, 4);

                Graphics.FillRectangle(Brushes.White, SelectArea.X + width / 2, SelectArea.Y - 2, 4, 4);
                Graphics.DrawRectangle(smallPen, SelectArea.X + width / 2, SelectArea.Y - 2, 4, 4);

                Graphics.FillRectangle(Brushes.White, SelectArea.X + width / 2, SelectArea.Y + height - 2, 4, 4);
                Graphics.DrawRectangle(smallPen, SelectArea.X + width / 2, SelectArea.Y + height - 2, 4, 4);
            }

            IsAreaSelected = finished;

            if (finished && !IsMovingSelectionArea && IsValidSelectionArea(SelectArea))
            {
                Bitmap cloneImage = new Bitmap((Image)ImageStatus.Clone());
                SelectionImage = cloneImage.Clone(SelectArea, cloneImage.PixelFormat);
            }

            if (finished && !IsMovingSelectionArea)
            {
                using (Graphics g = Graphics.FromImage(ImageStatus))
                {
                    g.FillRectangle(Brushes.White, SelectArea);
                }
            }
        }
        /// <summary>
        /// Dispose the select area.
        /// </summary>
        public void DeSelectArea()
        {
            IsAreaSelected = false;
            if (SelectionImage != null)
            {
                using (Graphics g = Graphics.FromImage(ImageStatus))
                {
                    g.DrawImage(SelectionImage, SelectArea.Location);
                }
                SelectionImage = null;
            }
            ImageDrew = ImageStatus;
        }
        /// <summary>
        /// Cut the image in selection area
        /// </summary>
        public void CutSelection()
        {
            if (IsAreaSelected && SelectionImage != null)
            {
                Clipboard.SetImage(SelectionImage);
                IsMovingSelectionArea = true;

                Point startPoint = SelectArea.Location;
                Point endPoint = new Point(SelectArea.X + SelectArea.Width, SelectArea.Y + SelectArea.Height);

                DrawSelectionArea(startPoint, endPoint, true, false);
                IsMovingSelectionArea = false;
                SelectionImage = null;
            }
        }
        /// <summary>
        /// Copy the image in selection area
        /// </summary>
        public void CopySelection()
        {
            Clipboard.SetImage(SelectionImage);
            IsMovingSelectionArea = true;

            Point startPoint = SelectArea.Location;
            Point endPoint = new Point(SelectArea.X + SelectArea.Width, SelectArea.Y + SelectArea.Height);

            DrawSelectionArea(startPoint, endPoint, true, true);
            IsMovingSelectionArea = false;
        }
        /// <summary>
        /// Paste image
        /// </summary>
        public void PasteSelection()
        {
            SelectionImage = Clipboard.GetImage();
            IsMovingSelectionArea = true;

            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(SelectArea.Width, SelectArea.Height);

            DrawSelectionArea(startPoint, endPoint, true, true);
            IsMovingSelectionArea = false;
        }
        /// <summary>
        /// Rotate the image in selection area
        /// </summary>
        /// <param name="angle">positive value if angle rotate clockwise, nagative in otherwise</param>
        public void RotateSelection(float angle)
        {
            if (IsAreaSelected && SelectionImage != null)
            {
                IsMovingSelectionArea = true;
                Bitmap tmpImage = new Bitmap((Image)SelectionImage.Clone());
                SelectionImage = (Image)(RotateWise(tmpImage, angle, Color.Transparent));
                
                Point startPoint = new Point(SelectArea.X + (SelectArea.Width - SelectArea.Height) / 2,
                                            SelectArea.Y + (SelectArea.Height - SelectArea.Width) / 2);
                Point endPoint = new Point(startPoint.X + SelectArea.Height, startPoint.Y + SelectArea.Width);

                DrawSelectionArea(startPoint, endPoint, true, true);
                IsMovingSelectionArea = false;
            }
        }
        /// <summary>
        /// Flip vertical image in selection area
        /// </summary>
        /// <param name="flipType">horizontal if FlipHorizontal and veritcal if FlipVertical</param>
        public void FlipSelection(FlipType flipType)
        {
            if (IsAreaSelected && SelectionImage != null)
            {
                IsMovingSelectionArea = true;
                Bitmap tmpImage = new Bitmap((Image)SelectionImage.Clone());
                if (flipType == FlipType.Horizontal)
                {
                    tmpImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
                if (flipType == FlipType.Vertical)
                {
                    tmpImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                }
                SelectionImage = (Image)tmpImage;

                Point startPoint = SelectArea.Location;
                Point endPoint = new Point(SelectArea.X + SelectArea.Width, SelectArea.Y + SelectArea.Height);

                DrawSelectionArea(startPoint, endPoint, true, true);
                IsMovingSelectionArea = false;
            }
        }
        /// <summary>
        /// Delete image in selection area
        /// </summary>
        public void DeleteSelection()
        {
            if (IsAreaSelected && SelectionImage != null)
            {
                IsMovingSelectionArea = true;

                Point startPoint = SelectArea.Location;
                Point endPoint = new Point(SelectArea.X + SelectArea.Width, SelectArea.Y + SelectArea.Height);

                DrawSelectionArea(startPoint, endPoint, true, false);
                IsMovingSelectionArea = false;
                SelectionImage = null;
            }
        }
        /// <summary>
        /// select all image
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="paintImage"></param>
        public void SelectAll(Point endPoint, Image paintImage)
        {
            SelectionImage = paintImage;
            IsMovingSelectionArea = false;
            Point startPoint = new Point(0, 0);
            DrawSelectionArea(startPoint, endPoint, true, true);
        }
        /// <summary>
        /// Check selection area
        /// </summary>
        /// <returns>true if size of selection area is positive, otherwise: flase</returns>
        public bool IsValidSelection()
        {
            return (SelectArea != null && SelectArea.Width > 0 && SelectArea.Height > 0);
        }
        #endregion
    }
}