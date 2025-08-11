using DevExpress.XtraRichEdit.API.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System.Drawing;

namespace BOSERP.Modules.MEEmr
{
    /// <summary>
    /// Bug 1499: Lỗi ký hiệu thuốc trên TDT => Không lỗi
    /// Ký hiệu thuốc dùng ảnh có nền màu trắng 
    /// </summary>
    public class PagePainterV1 : FieldPainter
    {
        private readonly RichEditControl _richEditCtrl;

        public PagePainterV1(RichEditControl _richEditCtrl,
            bool highlightEmrTagUserConfig,
            bool highlightEmrTagBorder,
            bool highlightEmrTagFill)
            : base(_richEditCtrl, highlightEmrTagUserConfig, highlightEmrTagBorder, highlightEmrTagFill)
        {
            this._richEditCtrl = _richEditCtrl;
        }
        public override void DrawFloatingObjectAnchorBox(FloatingObjectAnchorBox floatingObjectAnchorBox)
        {
            base.DrawFloatingObjectAnchorBox(floatingObjectAnchorBox);
            if (floatingObjectAnchorBox.FloatingObjectBox == null)
            {
                foreach (var pic in this._richEditCtrl.Document.Shapes)
                {
                    if (pic.Range.Start.ToInt() == floatingObjectAnchorBox.Range.Start)
                    {
                        var rectangle = new System.Drawing.Rectangle(
                            new Point(floatingObjectAnchorBox.Bounds.Location.X - pic.Picture.SizeInOriginalUnits.Width / 4,
                            floatingObjectAnchorBox.Bounds.Location.Y - (int)(pic.Picture.SizeInOriginalUnits.Height / 2.5)),
                            pic.Picture.SizeInOriginalUnits);
                        Canvas.DrawImage(pic.Picture, rectangle);
                    }
                }
            }
        }
        public override void DrawFloatingPicture(LayoutFloatingPicture floatingPicture)
        {
            if (floatingPicture.AnchorBox != null)
                base.DrawFloatingPicture(floatingPicture);
        }
    }
    public class PagePrintPainterBaseV1 : PagePainter
    {
        private readonly RichEditControl _richEditCtrl;

        public PagePrintPainterBaseV1(RichEditControl richEditCtrl)
        {
            this._richEditCtrl = richEditCtrl;
        }
        public override void DrawFloatingObjectAnchorBox(FloatingObjectAnchorBox floatingObjectAnchorBox)
        {
            base.DrawFloatingObjectAnchorBox(floatingObjectAnchorBox);
            if (floatingObjectAnchorBox.FloatingObjectBox == null)
            {
                foreach (var pic in this._richEditCtrl.Document.Shapes)
                {
                    if (pic.Range.Start.ToInt() == floatingObjectAnchorBox.Range.Start)
                    {
                        var rectangle = new System.Drawing.Rectangle(
                            new Point(floatingObjectAnchorBox.Bounds.Location.X - (int)(pic.Picture.SizeInDocuments.Width / 3),
                            floatingObjectAnchorBox.Bounds.Location.Y - (int)(pic.Picture.SizeInDocuments.Height / 2.5)),
                            pic.Picture.SizeInDocuments);
                        Canvas.DrawImage(pic.Picture, rectangle);
                    }
                }
            }
        }
        public override void DrawFloatingPicture(LayoutFloatingPicture floatingPicture)
        {
            if (floatingPicture.AnchorBox != null)
                base.DrawFloatingPicture(floatingPicture);
        }
    }
}
