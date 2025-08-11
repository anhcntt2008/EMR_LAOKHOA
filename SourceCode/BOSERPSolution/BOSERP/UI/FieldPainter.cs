using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP
{
    public class FieldPainter : PagePainter
    {
        private readonly RichEditControl _richEditCtrl;
        private readonly bool _enable;
        private int[] _hyperlinkStarts;
        private readonly bool _drawBorder;
        private readonly bool _drawFill;

        public FieldPainter(RichEditControl _richEditCtrl, bool enable, bool border, bool fill)
        {
            this._richEditCtrl = _richEditCtrl;
            this._enable = enable;
            if (enable)
            {
                _hyperlinkStarts = _richEditCtrl.Document.Hyperlinks.Select(h => h.Range.Start.ToInt()).ToArray();
                _drawBorder = border;
                _drawFill = fill;
            }
        }

        public override void DrawFieldHighlightAreaBox(FieldHighlightAreaBox box)
        {
            if (!_enable) return;
            try
            {
                if (box.Range.Length < 2) return;
                if (_hyperlinkStarts.Contains(box.Range.Start)) return;
                DrawTextBoxs(box.GetParentByType<LayoutRow>());
            }
            catch (Exception)
            {
                /*do nothing*/
            }
        }

        private void DrawTextBox(Rectangle box)
        {
            if (_drawBorder)
            {
                if (_drawFill)
                    Canvas.FillRectangle(new RichEditBrush(Color.FromArgb(128, 225, 225, 225)), box);
                Canvas.DrawRectangle(new RichEditPen(Color.FromArgb(128, 200, 200, 200), 1), box);
            }
            else
            {
                if (_drawFill)
                    Canvas.FillRectangle(new RichEditBrush(Color.FromArgb(128, 205, 205, 205)), box);
            }
        }

        private void DrawTextBoxs(LayoutRow row)
        {
            Rectangle rectangle = new Rectangle(-1, -1, -1, -1);
            // Case thong thuong: '<begin middle end>'
            foreach (var item in row.Boxes)
            {
                if (item.Type == LayoutType.PlainTextBox)
                {
                    var textBox = item as PlainTextBox;
                    if (textBox.Text[0] == BOSCommon.EmrParam.BeginTag[0])
                    {
                        rectangle.X = textBox.Bounds.X;
                        rectangle.Y = textBox.Bounds.Y;
                        rectangle.Height = textBox.Bounds.Height;
                        rectangle.Width = 0;
                        // Case dat biet: '<begin>'
                        if (textBox.Text.Last() == BOSCommon.EmrParam.EndTag[0])
                        {
                            DrawTextBox(item.Bounds);
                            rectangle.Width = textBox.Bounds.Width;
                        }
                    }
                    else if (textBox.Text.Last() == BOSCommon.EmrParam.EndTag[0])
                    {
                        if (rectangle.Height > 0)
                        {
                            rectangle.Width = (textBox.Bounds.Right - rectangle.X);
                            DrawTextBox(rectangle);
                        }
                        else
                        {
                            // Case dat biet: ' end>'
                            rectangle.X = row.Bounds.X;
                            rectangle.Y = row.Bounds.Y;
                            rectangle.Height = row.Bounds.Height;
                            rectangle.Width = (textBox.Bounds.Right - rectangle.X);
                            DrawTextBox(rectangle);
                        }
                    }
                }
            }
            //case '<begin'
            if (rectangle.Height > 0 && rectangle.Width == 0)
            {
                //Console.WriteLine("CASE <begin ... \n ... end>");
                rectangle.Width = (row.Bounds.Right - rectangle.X);
                DrawTextBox(rectangle);
                LayoutRowCollection rows = null;
                var p = row.GetParentByType<LayoutTableCell>();
                if (p != null) rows = p.Rows;
                else
                {
                    var c = row.GetParentByType<LayoutColumn>();
                    if (c != null) rows = c.Rows;
                }
                int begin = 0;
                foreach (var nextRow in rows)
                {
                    if (row == nextRow) break;
                    begin++;
                }
                for (begin = begin + 1; begin < rows.Count; begin++)
                {
                    if (rows[begin].Boxes.Any(b => b.Type == LayoutType.PlainTextBox && (b as PlainTextBox).Text.Last() == BOSCommon.EmrParam.EndTag[0]))
                        break;
                    DrawTextBox(rows[begin].Bounds);
                }
            }
        }
    }
}
