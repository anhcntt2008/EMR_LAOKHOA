using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.MEEmr
{
    sealed public class Ellipse : FillableShape
    {

        /// <summary>
        /// Initializes a new instance of the Ellipse class
        /// </summary>
        public Ellipse()
            : base()
        {

        }
        public override bool Selected
        {
            get
            {
                return base.Selected;
            }

            set
            {
                base.Selected = value;
            }
        }
        public override string Name
        {
            get
            {
                return "Hình Ellipse";
            }
        }

        /// <summary>
        /// Draws this Ellipse
        /// </summary>
        /// <param name="graphics">Current Graphics context</param>
        public override void Draw(Graphics graphics)
        {
            Pen pen;
            if (Brush == null)
            {
                pen = new Pen(ForeColor, BorderWidth);
                pen.DashStyle = BorderStyle;
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                //Anti-alias the ellipse for the best look
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawEllipse(pen, StartX, StartY, Math.Abs(EndX - StartX), Math.Abs(EndY - StartY));
                graphics.FillEllipse(new SolidBrush(FillColor), StartX, StartY, Math.Abs(EndX - StartX), Math.Abs(EndY - StartY));
            }
            else
            {
                pen = new Pen(Brush, BorderWidth);
                pen.DashStyle = BorderStyle;
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawEllipse(pen, StartX, StartY, Math.Abs(EndX - StartX), Math.Abs(EndY - StartY));
                graphics.FillEllipse(Brush, StartX, StartY, Math.Abs(EndX - StartX), Math.Abs(EndY - StartY));
            }
            pen.Dispose();
            if (Selected)
            {
                using (Pen p = new Pen(Color.Red, 3))
                {
                    graphics.DrawRectangle(p, StartX, StartY, Math.Abs(EndX - StartX), Math.Abs(EndY - StartY));
                }
            }
        }   //End the Draw() method

        public override IDrawShapes Clone()
        {
            return new Ellipse()
            {
                Brush = this.Brush,
                ForeColor = this.ForeColor,
                FillColor = this.FillColor,
                BorderStyle = this.BorderStyle,
                BorderWidth = BorderWidth
            };
        }

    }   //End the Shape class
}   //End the PictureEditDrawing namespace
