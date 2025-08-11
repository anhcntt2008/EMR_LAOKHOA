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
    /// Ký hiệu thuốc dùng ảnh không có nền
    /// </summary>
    public class PagePainterV2 : FieldPainter
    {
        private readonly RichEditControl _richEditCtrl;
        private List<FloatingObjectAnchorBox> _floatingObjectAnchorBoxes;
        public PagePainterV2(RichEditControl _richEditCtrl,
            bool highlightEmrTagUserConfig,
            bool highlightEmrTagBorder,
            bool highlightEmrTagFill)
            : base(_richEditCtrl, highlightEmrTagUserConfig, highlightEmrTagBorder, highlightEmrTagFill)
        {
            this._richEditCtrl = _richEditCtrl;
        }
        public override void DrawPage(LayoutPage page)
        {
            this._floatingObjectAnchorBoxes = new List<FloatingObjectAnchorBox>();
            base.DrawPage(page);
        }
        public override void DrawPageArea(LayoutPageArea pageArea)
        {
            base.DrawPageArea(pageArea);
            DrawMissedFloatingPicture();
        }
        public override void DrawFloatingObjectAnchorBox(FloatingObjectAnchorBox floatingObjectAnchorBox)
        {
            base.DrawFloatingObjectAnchorBox(floatingObjectAnchorBox);
            if (floatingObjectAnchorBox.FloatingObjectBox == null)
            {
                _floatingObjectAnchorBoxes.Add(floatingObjectAnchorBox);
            }
        }
        public override void DrawFloatingPicture(LayoutFloatingPicture floatingPicture)
        {
            if (floatingPicture.AnchorBox != null)
                base.DrawFloatingPicture(floatingPicture);
        }
        private void DrawMissedFloatingPicture()
        {
            foreach (var box in _floatingObjectAnchorBoxes)
            {
                foreach (var pic in this._richEditCtrl.Document.Shapes)
                {
                    if (pic.Range.Start.ToInt() == box.Range.Start)
                    {
                        var rectangle = new System.Drawing.Rectangle(
                            new Point(box.Bounds.Location.X - pic.Picture.SizeInOriginalUnits.Width / 4,
                            box.Bounds.Location.Y - (int)(pic.Picture.SizeInOriginalUnits.Height / 2.5)),
                            pic.Picture.SizeInOriginalUnits);
                        Canvas.DrawImage(pic.Picture, rectangle);
                    }
                }
            }
        }
    }
    public class PagePrintPainterBaseV2 : PagePainter
    {
        private readonly RichEditControl _richEditCtrl;
        private List<FloatingObjectAnchorBox> _floatingObjectAnchorBoxes;
        public PagePrintPainterBaseV2(RichEditControl richEditCtrl)
        {
            this._richEditCtrl = richEditCtrl;
        }
        public override void DrawPage(LayoutPage page)
        {
            this._floatingObjectAnchorBoxes = new List<FloatingObjectAnchorBox>();
            base.DrawPage(page);
        }
        public override void DrawPageArea(LayoutPageArea pageArea)
        {
            base.DrawPageArea(pageArea);
            DrawMissedFloatingPicture();
        }
        public override void DrawFloatingObjectAnchorBox(FloatingObjectAnchorBox floatingObjectAnchorBox)
        {
            base.DrawFloatingObjectAnchorBox(floatingObjectAnchorBox);
            if (floatingObjectAnchorBox.FloatingObjectBox == null)
            {
                _floatingObjectAnchorBoxes.Add(floatingObjectAnchorBox);
            }
        }
        public override void DrawFloatingPicture(LayoutFloatingPicture floatingPicture)
        {
            if (floatingPicture.AnchorBox != null)
                base.DrawFloatingPicture(floatingPicture);
        }
        private void DrawMissedFloatingPicture()
        {
            foreach (var box in _floatingObjectAnchorBoxes)
            {
                foreach (var pic in this._richEditCtrl.Document.Shapes)
                {
                    if (pic.Range.Start.ToInt() == box.Range.Start)
                    {
                        var rectangle = new System.Drawing.Rectangle(
                            new Point(box.Bounds.Location.X - (int)(pic.Picture.SizeInDocuments.Width / 3),
                            box.Bounds.Location.Y - (int)(pic.Picture.SizeInDocuments.Height / 2.5)),
                            pic.Picture.SizeInDocuments);
                        Canvas.DrawImage(pic.Picture, rectangle);
                    }
                }
            }
        }
    }
}
