using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BOSERP.Modules.Report
{
    public class ExportExcelParameter
    {
        public ExportExcelParameter()
        { 
        }
        public ExportExcelParameter(int x, int y, object value)
        {
            _posX = x;
            _posY = y;
            _value = value;
            _foreColor = Color.Black;
            _font = new Font("Calibri", (float)8.25);
        }
        public ExportExcelParameter(int x, int y, object value, Color foreColor, Color backColor, Font font)
        {
            _posX = x;
            _posY = y;
            _value = value;
            _foreColor = foreColor;
            _backColor = backColor;
            _font = font;
        }
        #region Variables
        protected int _posX;
        protected int _posY;
        protected object _value;
        protected Color _foreColor;
        protected Color _backColor;
        protected Font _font;
        #endregion

        #region Public properties
        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }

        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Color ForeColor
        {
            get { return _foreColor; }
            set { _foreColor = value; }
        }

        public Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        public Font Font
        {
            get { return _font; }
            set { _font = value;}
        }

        #endregion
    }
}
