using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BOSLib;

namespace BOSERP
{
    public partial class guiExcelExport : BOSERPScreen
    {
        public guiExcelExport()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fld_txtFile.Text = saveFileDialog1.FileName.ToString();
            }
        }


        private void bntExport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fld_txtFile.Text))
            {
                MessageBox.Show("Please specify the file location you want to save to.", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Delete if file exists
            try
            {
                if (File.Exists(fld_txtFile.Text))
                    File.Delete(fld_txtFile.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please close the file before exporting.", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            btnExport.Enabled = false;
            fld_prgProgressBar.Position = fld_prgProgressBar.Properties.Minimum;

            ExcelImportExportObject excelObj = new ExcelImportExportObject();
            excelObj.ProgressEvent += new ProgressEventHandler(Export_ProgressEvent);
            excelObj.OpenExcelFile(fld_txtFile.Text.ToString());

            if (((BaseModuleERP)Module).CurrentModuleEntity.MainObject != null)
                ExportBusinessObject(((BaseModuleERP)Module).CurrentModuleEntity.MainObject, excelObj);
            Application.DoEvents();
            foreach (BusinessObject moduleObject in ((BaseModuleERP)Module).CurrentModuleEntity.ModuleObjects.Values)
            {
                ExportBusinessObject(moduleObject, excelObj);
                Application.DoEvents();
            }

            excelObj.CloseExcelFile();

            btnExport.Enabled = true;
            fld_prgProgressBar.Position = fld_prgProgressBar.Properties.Maximum;
            this.Update();
            if (fld_chkOpenFile.Checked)
                OpenFile(fld_txtFile.Text);
            Cursor.Current = Cursors.Default;
        }

        private void ExportBusinessObject(BusinessObject obj, ExcelImportExportObject excelObj)
        {
            String tablename = BOSUtil.GetTableNameFromBusinessObject(obj);
            BaseBusinessController bsController = new BaseBusinessController(obj.GetType());

            DataSet ds = bsController.GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                fld_dgvData.Columns.Clear();
                fld_dgcData.DataSource = ds.Tables[0];
                fld_dgcData.RefreshDataSource();
                excelObj.ExportFromGridView(fld_dgvData, tablename);
            }
        }

        private void Export_ProgressEvent(object sender, ProgressEventArgs e)
        {
            if (fld_prgProgressBar.Position < fld_prgProgressBar.Properties.Maximum)
                fld_prgProgressBar.Position += 1;
            else
                fld_prgProgressBar.Position = fld_prgProgressBar.Properties.Minimum;
            this.Update();
            Application.DoEvents();
        }

        public void OpenFile(string fileName)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Verb = "Open";
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.Start();
            }
            catch
            {
                MessageBox.Show("Can not find an application on your system suitable for openning the file with exported data.", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}