using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Ca.Core
{
    public class PdfSignerPropertyBase
    {
        public PdfSignerPropertyBase()
        {
            Visible = true;
            Page = 1;
            TextColor = 0;
        }
        public bool Visible { get; set; }
        public string Contact { get; set; }
        public int CoordinateY { get; set; }
        public int CoordinateX { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Page { get; set; }
        public string Location { get; set; }
        public bool ShowReason { get; set; }
        public string Reason { get; set; }
        public string SignatureImage { get; set; }
        public int TextColor { get; set; }
        public int FontSize { get; set; }
        #region VNPT CA
        public int SignatureWidth { get; set; }
        public int SignatureHeight { get; set; }
        public string FontColor { get; set; }
        public string FontStyle { get; set; }
        public string FontName { get; set; }
        public string Layer2Text { get; set; }
        public string RenderMode { get; set; }
        public string SignatureBorderType { get; set; }
        public int CountGetTranInfo { get; set; }
        #endregion
    }
}
