using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.MEEmr
{
    sealed public class Freehand : IDrawShapes
    {

        #region Public accessors

        /// <summary>
        /// Gets or sets the Fore Color of this Freehand drawing
        /// </summary>
        public Color FillColor
        {
            get;
            set;
        }
        public Color ForeColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Border Width of this Freehand drawing
        /// </summary>
        public float BorderWidth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a collection of Points that comprise this Freehand drawing
        /// </summary>
        public IList<Point> Points
        {
            get;
            set;
        }

        public Brush Brush
        {
            get;
            set;
        }
        public string Name
        {
            get { return "Vẽ tự do"; }
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the Freehand class
        /// </summary>
        public Freehand()
        {
            FillColor = Color.Black;
            BorderWidth = 1.0f;
            Brush = null;
        }

        public bool Selected
        {
            get;
            set;
        }

        /// <summary>
        /// Starts this drawing by registering the start location coordinates
        /// </summary>
        /// <param name="Location">Start location</param>
        public void StartDrawing(Point Location)
        {
            Points.Add(Location);

        }   //End the StartDrawing() method



        /// <summary>
        /// Ends this drawing by registering the end location coordinates
        /// </summary>
        /// <param name="Location">Start location</param>
        public void EndDrawing(Point Location)
        {
            Points.Add(Location);

        }   //End the EndDrawing() method



        /// <summary>
        /// Draws this Freehand drawing
        /// </summary>
        /// <param name="graphics">Current Graphic context</param>
        public void Draw(Graphics graphics)
        {
            if (Points == null || Points.Count < 2)
                return;
            if (Brush != null)
                using (Pen pen = new Pen(Brush, BorderWidth))
                {
                    for (int i = 1; i < Points.Count; i++)
                    {
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                        graphics.DrawLine(pen, Points[i - 1], Points[i]);
                    }
                }
            else
                using (Pen pen = new Pen(FillColor, BorderWidth))
                {
                    for (int i = 1; i < Points.Count; i++)
                    {
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                        graphics.DrawLine(pen, Points[i - 1], Points[i]);
                    }
                }

            if (Selected)
            {
                int StartX = int.MaxValue, EndX = 0, StartY = int.MaxValue, EndY = 0;
                foreach (var point in Points)
                {
                    if (StartX > point.X) StartX = point.X;
                    if (StartY > point.Y) StartY = point.Y;
                    if (EndX < point.X) EndX = point.X;
                    if (EndY < point.Y) EndY = point.Y;
                }
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    graphics.DrawRectangle(pen, Math.Min(StartX, EndX), Math.Min(StartY, EndY), Math.Abs(EndX - StartX), Math.Abs(EndY - StartY));
                }
            }

        }   //End the Draw() method

        public IDrawShapes Clone()
        {

            return new Freehand()
            {
                Points = new List<Point>(50),
                BorderWidth = this.BorderWidth,
                FillColor = this.FillColor,
                Brush = Brush,
            };
        }
    }   //End the Freehand class
}   //End the PictureEditDrawing namespace
