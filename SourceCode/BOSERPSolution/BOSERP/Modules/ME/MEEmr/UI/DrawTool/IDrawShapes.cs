using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.MEEmr
{
    /// <summary>
    /// Represents drawable polygons and freehand drawing
    /// </summary>
    public interface IDrawShapes
    {
        /// <summary>
        /// Gets or sets the fore color of this Shape or Drawing
        /// </summary>
        Color ForeColor
        {
            get;
            set;
        }
        Brush Brush
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the border width of this Shape or Drawing
        /// </summary>
        float BorderWidth
        {
            get;
            set;
        }

        bool Selected
        {
            get;
            set;
        }
        string Name
        {
            get;
        }
        /// <summary>
        /// Starts this drawing by registering the start location coordinates
        /// </summary>
        /// <param name="Location">Start location</param>
        void StartDrawing(Point Location);

        /// <summary>
        /// Ends this drawing by registering the end location coordinates
        /// </summary>
        /// <param name="Location">End location</param>
        void EndDrawing(Point Location);

        /// <summary>
        /// Draws this Shape
        /// </summary>
        /// <param name="graphics">Current Graphics context</param>
        void Draw(Graphics graphics);

        IDrawShapes Clone();

    }   //End the IDrawShapes interface
}   //End the PictureEditDrawing namespace
