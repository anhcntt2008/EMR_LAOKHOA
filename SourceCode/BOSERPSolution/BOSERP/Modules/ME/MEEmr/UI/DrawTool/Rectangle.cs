using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.MEEmr
{
    sealed public class Rectangle : FillableShape
    {

        /// <summary>
        /// Initializes a new instance of the Rectangle class
        /// </summary>
        public Rectangle()
            : base()
        {

        }
        public override string Name
        {
            get
            {
                return "Hình chữ nhật";
            }
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
        /// <summary>
        /// Draws this Rectangle
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
                graphics.DrawRectangle(pen,
                    Math.Min(StartX, EndX),
                    Math.Min(StartY, EndY),
                    Math.Abs(EndX - StartX),
                    Math.Abs(EndY - StartY));
                graphics.FillRectangle(new SolidBrush(FillColor),
                    Math.Min(StartX + BorderWidth, EndX - BorderWidth),
                    Math.Min(StartY + BorderWidth, EndY - BorderWidth),
                    Math.Abs((EndX - BorderWidth) - (StartX + BorderWidth)),
                    Math.Abs((EndY - BorderWidth) - (StartY + BorderWidth)));
            }
            else
            {
                pen = new Pen(Brush, BorderWidth);
                pen.DashStyle = BorderStyle;
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                graphics.DrawRectangle(pen,
                   Math.Min(StartX, EndX),
                   Math.Min(StartY, EndY),
                   Math.Abs(EndX - StartX),
                   Math.Abs(EndY - StartY));
                graphics.FillRectangle(Brush,
                    Math.Min(StartX + BorderWidth, EndX - BorderWidth),
                    Math.Min(StartY + BorderWidth, EndY - BorderWidth),
                    Math.Abs((EndX - BorderWidth) - (StartX + BorderWidth)),
                    Math.Abs((EndY - BorderWidth) - (StartY + BorderWidth)));
            }
            pen.Dispose();
            if (Selected)
            {
                using (Pen p = new Pen(Color.Red, 3))
                {
                    graphics.DrawRectangle(p, Math.Min(StartX, EndX) - 3, Math.Min(StartY, EndY) - 3, Math.Abs(EndX - StartX) + 6, Math.Abs(EndY - StartY) + 6);
                }
            }
        }   //End the Draw() method
        public override IDrawShapes Clone()
        {
            return new Rectangle()
            {
                Brush = this.Brush,
                ForeColor = this.ForeColor,
                FillColor = this.FillColor,
                BorderStyle = this.BorderStyle,
                BorderWidth = BorderWidth
            };
        }
    }   //End the Rectangle class
}   //End the PictureEditDrawing namespace
