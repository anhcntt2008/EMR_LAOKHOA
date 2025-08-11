using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit;
using DevExpress.XtraBars;

namespace BOSERP.Modules.EmrAbbrev.UI
{
    /// <summary>
    /// Summary description for DMEAB100
    /// </summary>
    public partial class DMEAB100 : BOSERPScreen
    {
        public DMEAB100()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
            riPopup.PopupFormMinSize = new Size(400, 400);
            richEditControl.Document.DefaultCharacterProperties.FontName = "Times New Roman";
            richEditControl.Document.DefaultCharacterProperties.FontSize = 13;
        }
        void riPopup_QueryPopUp(object sender, CancelEventArgs e)
        {
            var str = (sender as BaseEdit).EditValue?.ToString();
            str = str ?? string.Empty;
            if (str.StartsWith("{\\rtf1"))
                richEditControl.Document.RtfText = (sender as BaseEdit).EditValue?.ToString();
            else
                richEditControl.Document.Text = str;

            richEditControl.Document.DefaultCharacterProperties.FontName = "Times New Roman";
            richEditControl.Document.DefaultCharacterProperties.FontSize = 13;
        }

        void riPopup_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            e.DisplayText = richEditControl.Document.Text;
            richEditControl.Document.DefaultCharacterProperties.FontName = "Times New Roman";
            richEditControl.Document.DefaultCharacterProperties.FontSize = 13;
        }

        void riPopup_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = richEditControl.Document.RtfText;
        }

        private void riPopup_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (!e.AcceptValue)
            {
                PopupContainerEdit pSender = sender as PopupContainerEdit;
                RichEditControl rEdit = pSender.Properties.PopupControl.Controls[0] as RichEditControl;
                if (rEdit != null)
                    rEdit.Document.RtfText = e.Value.ToString();
            }
        }

        private void standaloneBarDockControl1_Click(object sender, EventArgs e)
        {

        }

        private void popupContainerControl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
