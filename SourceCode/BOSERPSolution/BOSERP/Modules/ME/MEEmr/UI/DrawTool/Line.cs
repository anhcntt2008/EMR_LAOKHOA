using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.MEEmr
{
    sealed public class Line : Shape
    {

        #region Public properties

        /// <summary>
        /// Gets or sets the start cap style for this Line
        /// </summary>
        public LineCap StartCap
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end cap style for this Line
        /// </summary>
        public LineCap EndCap
        {
            get;
            set;
        }
        public Color FillColor
        {
            get;
            set;
        }
        public override string Name
        {
            get
            {
                return "Đường";
            }
        }
        #endregion


        /// <summary>
        /// Initializes a new instance of the Line class
        /// </summary>
        public Line()
            : base()
        {
            EndCap = LineCap.Flat;
            StartCap = LineCap.Flat;
        }
        /// <summary>
        /// Draws this Line
        /// </summary>
        /// <param name="graphics">Current Graphics context</param>
        public override void Draw(Graphics graphics)
        {
            if (Brush != null) using (Pen pen = new Pen(Brush, BorderWidth))
                {
                    pen.EndCap = EndCap;
                    pen.StartCap = StartCap;
                    pen.DashStyle = BorderStyle;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawLine(pen, StartX, StartY, EndX, EndY);
                }
            else
                using (Pen pen = new Pen(FillColor, BorderWidth))
                {
                    pen.EndCap = EndCap;
                    pen.StartCap = StartCap;
                    pen.DashStyle = BorderStyle;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawLine(pen, StartX, StartY, EndX, EndY);
                }   //End the using() statement
            if (Selected)
            {
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    graphics.DrawRectangle(pen, Math.Min(StartX, EndX), Math.Min(StartY, EndY), Math.Abs(EndX - StartX), Math.Abs(EndY - StartY));
                }
            }
        }   //End the Draw() method
        public override IDrawShapes Clone()
        {
            return new Line()
            {
                BorderWidth = this.BorderWidth,
                FillColor = this.FillColor,
                Brush = this.Brush,
                StartCap = this.StartCap,
                EndCap = this.EndCap,
                BorderStyle = this.BorderStyle
            };
        }
    }   //End the Line class
}   //End the PictureEditDrawing namespace
