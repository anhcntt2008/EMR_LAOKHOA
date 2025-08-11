using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using BOSLib;
using Localization;

namespace BOSERP
{
    public partial class guiExcelImport : BOSERPScreen
    {
        public guiExcelImport()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fld_txtFile.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!File.Exists(fld_txtFile.Text))
            {
                MessageBox.Show("The file does not exist.", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            btnImport.Enabled = false;
            fld_prgProgressBar.Position = fld_prgProgressBar.Properties.Minimum;

            ExcelImportExportObject excelObject = new ExcelImportExportObject();
            excelObject.ProgressEvent += new BOSLib.ProgressEventHandler(Import_ProgressEvent);
            excelObject.OpenExcelFile(fld_txtFile.Text);
            excelObject.ImportFromExcel(fld_txtFile.Text.ToString());

            btnImport.Enabled = true;
            fld_prgProgressBar.Position = fld_prgProgressBar.Properties.Maximum;
            this.Update();
            Cursor.Current = Cursors.Default;
        }

        private void Import_ProgressEvent(object sender, ProgressEventArgs e)
        {
            if (fld_prgProgressBar.Position < fld_prgProgressBar.Properties.Maximum)
                fld_prgProgressBar.Position += 1;
            else
                fld_prgProgressBar.Position = fld_prgProgressBar.Properties.Minimum;
            this.Update();
            Application.DoEvents();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}