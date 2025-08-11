using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using BOSCommon;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System.Drawing.Drawing2D;
using System.Linq;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiDraw : BOSERPScreen
    {
        private byte[] _oldImage;
        public int ImgWidth { get; internal set; }
        public int ImgHeight { get; internal set; }

        private readonly int _emrImageID;

        public MEEmrImagesInfo EmrImage { get; private set; }

        public guiDraw(int emrImageID, byte[] oldImage, int width, int height)
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _oldImage = oldImage;
            ImgWidth = width;
            ImgHeight = height;
            _emrImageID = emrImageID;
            this.gleMEEmrImages.EditValue = emrImageID;
            this.gleMEEmrImages.EditValueChanged += new System.EventHandler(this.gleMEEmrImages_EditValueChanged);
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
            else if (e.Control && e.KeyCode == Keys.Oemplus)
            {
                ztbPenSize.Value = ztbPenSize.Value + 1;
            }
            else if (e.Control && e.KeyCode == Keys.OemMinus)
            {
                if (ztbPenSize.Value > 1)
                    ztbPenSize.Value = ztbPenSize.Value - 1;
            }
        }

        private void Ok()
        {
            ImgWidth = (int)txtImgWidth.EditValue;
            ImgHeight = (int)txtImgHeight.EditValue;
            EmrImage = gleMEEmrImages.Properties.GetRowByKeyValue(gleMEEmrImages.EditValue) as MEEmrImagesInfo;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            //gleMEEmrImages.DataBindings.Add("EditValue", img, "MEEmrImageID");
            gleMEEmrImages.Properties.PopupView.OptionsBehavior.AutoPopulateColumns = false;

            gleMEEmrImages.Properties.DisplayMember = "MEEmrImageName";
            gleMEEmrImages.Properties.ValueMember = "MEEmrImageID";
            var col = gleMEEmrImages.Properties.PopupView.Columns.AddField("MEEmrImageLarge");
            col.VisibleIndex = 0;
            col.Caption = "Hình";
            var edit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            edit.CustomHeight = 80;
            edit.SizeMode = PictureSizeMode.Zoom;
            col.ColumnEdit = edit;

            var col1 = gleMEEmrImages.Properties.PopupView.Columns.AddField("MEEmrImageNo");
            col1.VisibleIndex = 0;
            col1.Caption = "Mã";
            var col2 = gleMEEmrImages.Properties.PopupView.Columns.AddField("MEEmrImageName");
            col2.VisibleIndex = 1;
            col2.Caption = "Tên";
            gleMEEmrImages.Properties.PopupFormWidth = 300;

            pcePicture.Properties.SizeMode = PictureSizeMode.Zoom;
            cbtFreeHand.Checked = true;
            txtPenSize.Text = "1";
            ztbPenSize.Value = 1;

            //Populate our style ImageComboBoxEdit controls
            cboEndCap.Properties.Items.AddEnum<LineCap>();
            cboStartCap.Properties.Items.AddEnum<LineCap>();
            cboEndCap.SelectedIndex = cboStartCap.SelectedIndex = 0;
            cboForeColor.EditValue = Color.Black;
            cboFillColor.EditValue = Color.Black;
            chkChangeBrush.Checked = true;

            cboBorderStyle.Properties.Items.AddEnum<DashStyle>();
            cboBorderStyle.EditValue = DashStyle.Solid;
            InitPatternGridCols();
            GetImages();
            var entity = ((MEEmrModule)Module).CurrentModuleEntity as MEEmrEntities;
            entity.MEImageParamList.InitBOSListGridControl();
            fld_dgcMEEmrImageParams.Screen = this;
            fld_dgcMEEmrImageParams.InitializeControl();
            fld_dgcMEEmrImageParams.InitGridControlDataSource();
            entity.UpdateModuleObjectBindingSource(TableName.MEEmrImageParamsTableName);

            InitHistoryGridCols();
            this.pcePicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pcePicture_MouseUp);

            // in case edit image
            if (_oldImage != null)
            {
                using (var ms = new MemoryStream(_oldImage))
                {
                    pcePicture.Image = Image.FromStream(ms);
                }
            }

            // in case edit image
            if (ImgWidth > 0)
                txtImgWidth.EditValue = ImgWidth;
            if (ImgHeight > 0)
                txtImgHeight.EditValue = ImgHeight;

            //in case edit image
            if (_emrImageID > 0)
            {
                LoadPatternsOfImage(_emrImageID);
                lkeFK_HRDepartmentID.Enabled = false;
                lkeFK_MEEmrGroupImageID.Enabled = false;
                gleMEEmrImages.Enabled = false;
            }
        }
        private void pcePicture_MouseUp(object sender, MouseEventArgs e)
        {
            fld_dgcHistories.RefreshDataSource();
        }
        private void InitPatternGridCols()
        {
            grvPatterns.OptionsView.RowAutoHeight = true;
            grvPatterns.OptionsView.ShowColumnHeaders = false;
            grvPatterns.OptionsBehavior.Editable = true;
            grvPatterns.OptionsSelection.EnableAppearanceFocusedCell = false;
            grvPatterns.OptionsSelection.EnableAppearanceFocusedRow = true;

            var col = grvPatterns.Columns.AddField("MEEmrImagePatternImage");
            col.VisibleIndex = 0;
            col.Caption = "Hình";
            var edit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
            {
                CustomHeight = 30,
                SizeMode = PictureSizeMode.Zoom
            };
            col.ColumnEdit = edit;
            col.OptionsColumn.AllowEdit = false;

            col = grvPatterns.Columns.AddField("MEEmrImagePatternName");
            col.VisibleIndex = 1;
            col.Caption = "Mô tả";
            col.OptionsColumn.AllowEdit = false;

            grvPatterns.FocusedRowChanged += GridView_FocusedRowChanged;
        }
        private void InitHistoryGridCols()
        {
            grvHistories.OptionsView.RowAutoHeight = true;
            grvHistories.OptionsBehavior.Editable = false;
            grvHistories.OptionsSelection.EnableAppearanceFocusedCell = false;
            grvHistories.OptionsSelection.EnableAppearanceFocusedRow = true;
            var col = grvHistories.Columns.AddField("Name");
            col.VisibleIndex = 0;
            col.Caption = "Hình";
            col.OptionsColumn.AllowEdit = false;
            grvHistories.FocusedRowChanged += GridViewHistory_FocusedRowChanged;
            BindingSource bds = new BindingSource();
            bds.DataSource = pcePicture.Shapes;
            fld_dgcHistories.DataSource = bds;
        }
        private void fld_dgcHistories_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < pcePicture.Shapes.Count; i++)
                {
                    if (pcePicture.Shapes[i].Selected)
                    {
                        pcePicture.Shapes.Remove(pcePicture.Shapes[i]);
                        if (i < pcePicture.Shapes.Count - 1)
                            pcePicture.Shapes[i].Selected = true;
                        if (pcePicture.Shapes.Count == 1) pcePicture.Shapes[0].Selected = true;
                        pcePicture.Invalidate();
                        break;
                    }
                }
                fld_dgcHistories.RefreshDataSource();
            }
        }
        private void GridViewHistory_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                var shape = grvHistories.GetFocusedRow() as IDrawShapes;
                if (shape != null)
                {
                    pcePicture.UnselectedAll();
                    shape.Selected = true;
                    pcePicture.Invalidate();
                }
            }
        }
        private void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                ChangeBrush();
            }
        }
        private void ChangeBrush()
        {
            MEEmrImagePatternsInfo img;
            if (grvPatterns.FocusedRowHandle >= 0)
                img = grvPatterns.GetFocusedRow() as MEEmrImagePatternsInfo;
            else
                img = grvPatterns.GetRow(0) as MEEmrImagePatternsInfo;
            if (img != null)
            {
                var shape = pcePicture.CurrentShape;
                var ms = new MemoryStream(img.MEEmrImagePatternImage);
                shape.Brush = new TextureBrush(Image.FromStream(ms), System.Drawing.Drawing2D.WrapMode.Tile);
            }
        }
        private void GetImages()
        {
            var ds = ((MEEmrModule)Module).GetListImageByDepartmentAndGroup(
                lkeFK_HRDepartmentID.EditValue != null ? (int)lkeFK_HRDepartmentID.EditValue : 0,
            lkeFK_MEEmrGroupImageID.EditValue != null ? (int)lkeFK_MEEmrGroupImageID.EditValue : 0);
            gleMEEmrImages.Properties.DataSource = ds;
            if (ds.Count > 0 && _oldImage == null)
                gleMEEmrImages.EditValue = ds.First().MEEmrImageID;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public Image ToImage()
        {
            pcePicture.UnselectedAll();
            pcePicture.Invalidate();
            using (MemoryStream stream = new MemoryStream())
            {
                using (Bitmap imageBMP = new Bitmap(this.pcePicture.Width, this.pcePicture.Height))
                {
                    this.pcePicture.DrawToBitmap(imageBMP, this.pcePicture.DisplayRectangle);
                    imageBMP.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    return Image.FromStream(stream);
                }
            }
        }

        private void lkeFK_HRDepartmentID_EditValueChanged(object sender, EventArgs e)
        {
            GetImages();
        }

        private void lkeFK_MEEmrGroupImageID_EditValueChanged(object sender, EventArgs e)
        {
            GetImages();
        }

        private void gleMEEmrImages_EditValueChanged(object sender, EventArgs e)
        {
            var row = gleMEEmrImages.Properties.GetRowByKeyValue(gleMEEmrImages.EditValue) as MEEmrImagesInfo;
            if (row == null) return;
            using (var ms = new MemoryStream(row.MEEmrImageLarge))
            {
                pcePicture.Image = Image.FromStream(ms);
                txtImgWidth.EditValue = row.MEEmrImageWidth;
                txtImgHeight.EditValue = row.MEEmrImageHeight;
            }
            LoadPatternsOfImage(row.MEEmrImageID);
            ((MEEmrModule)Module).InvalidateImageParam(row.MEEmrImageID);
        }
        private void LoadPatternsOfImage(int MEEmrImageID)
        {
            var ds = ((MEEmrModule)Module).GetPatternByImage(MEEmrImageID);
            gdcPatterns.DataSource = ds;
        }
        private void cbt_CheckedChanged(object sender, EventArgs e)
        {
            VisibleOptions();
            ChangeOptions();
        }
        private void ChangeOptions()
        {
            var shape = pcePicture.CurrentShape;
            if (cbtLine.Checked == true)
            {
                if (!(shape is Line))
                    shape = new Line();
                var s = shape as Line;
                s.EndCap = (LineCap)cboEndCap.EditValue;
                s.StartCap = (LineCap)cboStartCap.EditValue;
                s.BorderStyle = (DashStyle)cboBorderStyle.EditValue;
                s.FillColor = cboFillColor.Color;
            }
            else if (cbtRectangle.Checked == true)
            {
                if (!(shape is Rectangle))
                    shape = new Rectangle();
                var s = shape as Rectangle;
                s.FillColor = cboFillColor.Color;
                s.BorderStyle = (DashStyle)cboBorderStyle.EditValue;

            }
            else if (cbtEllipse.Checked == true)
            {
                if (!(shape is Ellipse))
                    shape = new Ellipse();
                var s = shape as Ellipse;
                s.FillColor = cboFillColor.Color;
                s.BorderStyle = (DashStyle)cboBorderStyle.EditValue;
            }
            else if (cbtFreeHand.Checked == true)
            {
                if (!(shape is Freehand))
                    shape = new Freehand();
                var s = shape as Freehand;
                s.Points = new List<Point>(50);
                s.FillColor = cboFillColor.Color;
            }
            else if (cbtText.Checked == true)
            {
                FontStyle style = FontStyle.Regular;
                if (btnBold.Checked)
                    style = FontStyle.Bold;
                if (btnItalic.Checked)
                    style = style | FontStyle.Italic;
                if (btnUnderline.Checked)
                    style = style | FontStyle.Underline;

                if (!(shape is TextStamp))
                    shape = new TextStamp();
                var s = shape as TextStamp;
                s.FillColor = cboFillColor.Color;
                s.Text = txtText.Text;
                s.TextFont = new Font(txtFont.Text, Convert.ToSingle(txtFontSize.Value), style);
            }
            if (shape != null)
            {
                shape.BorderWidth = Convert.ToSingle(txtPenSize.Text);
                shape.ForeColor = cboForeColor.Color;
                pcePicture.CurrentShape = shape;
            }
        }
        private void VisibleOptions()
        {
            //Toggle Shape options based on the selected Shape
            chkChangeBrush.Checked = true;
            chkChangeBrush.Checked = false;
            ctrlFillColor.Visibility = ctrlChangeBrush.Visibility = LayoutVisibility.Always;
            ctrlGdcPattern.Visibility = LayoutVisibility.Always;
            ctrlLblPattern.Visibility = LayoutVisibility.Always;
            if (cbtLine.Checked == true)
            {
                ctrlBorderStyle.Visibility = LayoutVisibility.Always;
                ctrlText.Visibility = ctrlDesc.Visibility = ctrlParam.Visibility = LayoutVisibility.Never;
                //ctrlFillColor.Visibility = ctrlText.Visibility = ctrlChangeBrush.Visibility = LayoutVisibility.Never;
                ctrlEndCap.Visibility = ctrlStartCap.Visibility = LayoutVisibility.Always;
                ctrlFont.Visibility = ctrlFontSize.Visibility = LayoutVisibility.Never;
                ctrlBold.Visibility = ctrlItalic.Visibility = ctrlUnderline.Visibility = LayoutVisibility.Never;
                ctrlForeColor.Visibility = LayoutVisibility.Never;

                if (cboFillColor.Color == Color.Transparent || cboFillColor.Color == Color.White)
                    cboFillColor.Color = Color.Black;
            }
            else if (cbtRectangle.Checked == true || cbtEllipse.Checked)
            {
                ctrlBorderStyle.Visibility = LayoutVisibility.Always;
                ctrlText.Visibility = ctrlDesc.Visibility = ctrlParam.Visibility = LayoutVisibility.Never;
                //ctrlFillColor.Visibility = ctrlChangeBrush.Visibility = LayoutVisibility.Always;
                ctrlText.Visibility = LayoutVisibility.Never;
                ctrlEndCap.Visibility = ctrlStartCap.Visibility = LayoutVisibility.Never;
                ctrlFont.Visibility = ctrlFontSize.Visibility = LayoutVisibility.Never;
                ctrlBold.Visibility = ctrlItalic.Visibility = ctrlUnderline.Visibility = LayoutVisibility.Never;
                ctrlForeColor.Visibility = LayoutVisibility.Always;

                if (cboFillColor.Color == Color.Black)
                    cboFillColor.Color = Color.Transparent;
            }
            else if (cbtFreeHand.Checked == true)
            {
                ctrlText.Visibility = ctrlDesc.Visibility = ctrlParam.Visibility = LayoutVisibility.Never;
                //ctrlFillColor.Visibility = ctrlChangeBrush.Visibility = LayoutVisibility.Always;
                ctrlForeColor.Visibility = LayoutVisibility.Never;
                ctrlBorderStyle.Visibility = LayoutVisibility.Never;
                ctrlEndCap.Visibility = ctrlStartCap.Visibility = LayoutVisibility.Never;
                ctrlFont.Visibility = ctrlFontSize.Visibility = LayoutVisibility.Never;
                ctrlBold.Visibility = ctrlItalic.Visibility = ctrlUnderline.Visibility = LayoutVisibility.Never;

                if (cboFillColor.Color == Color.Transparent || cboFillColor.Color == Color.White)
                    cboFillColor.Color = Color.Black;
            }
            else if (cbtText.Checked == true)
            {
                ctrlText.Visibility = ctrlDesc.Visibility = ctrlParam.Visibility = LayoutVisibility.Always;
                ctrlFont.Visibility = ctrlFontSize.Visibility = LayoutVisibility.Always;
                ctrlBold.Visibility = ctrlItalic.Visibility = ctrlUnderline.Visibility = LayoutVisibility.Always;
                //ctrlFillColor.Visibility = ctrlChangeBrush.Visibility = LayoutVisibility.Always;
                ctrlForeColor.Visibility = LayoutVisibility.Always;
                ctrlBorderStyle.Visibility = LayoutVisibility.Never;
                ctrlEndCap.Visibility = ctrlStartCap.Visibility = LayoutVisibility.Never;
                ctrlLblPattern.Visibility = LayoutVisibility.Never;
                ctrlGdcPattern.Visibility = LayoutVisibility.Never;
                chkChangeBrush.Checked = true;
                ctrlChangeBrush.Visibility = LayoutVisibility.Never;

                if (cboFillColor.Color == Color.Transparent || cboFillColor.Color == Color.White)
                    cboFillColor.Color = Color.Black;
            }

        }
        private void cbt_Click(object sender, EventArgs e)
        {

        }

        private void cbt_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void ztbPenSize_EditValueChanged(object sender, EventArgs e)
        {
            txtPenSize.Text = ztbPenSize.Value.ToString();
            pcePicture.CurrentShape.BorderWidth = Convert.ToSingle(txtPenSize.Text);
        }

        private void txtPenSize_EditValueChanged(object sender, EventArgs e)
        {
            ztbPenSize.Value = Convert.ToInt16(txtPenSize.Text);
        }

        private void cbo_EditValueChanged(object sender, EventArgs e)
        {
            ChangeOptions();
        }

        private void checkButtonFontStyle_CheckedChanged(object sender, EventArgs e)
        {

            ChangeOptions();
        }

        private void chkChangeBrush_CheckedChanged(object sender, EventArgs e)
        {
            var shape = pcePicture.CurrentShape;
            var chk = (CheckEdit)sender;
            if (shape != null)
            {
                if (chk.Checked)
                {
                    cboFillColor.Enabled = true;
                    gdcPatterns.Enabled = false;
                    shape.BorderWidth = Convert.ToSingle(txtPenSize.Text);
                    shape.ForeColor = cboForeColor.Color;
                    shape.Brush = null;
                    pcePicture.CurrentShape = shape;
                }
                else
                {
                    cboFillColor.Enabled = false;
                    gdcPatterns.Enabled = true;
                    shape.BorderWidth = Convert.ToSingle(txtPenSize.Text);
                    ChangeBrush();
                    pcePicture.CurrentShape = shape;
                }
            }
        }

        private void txtText_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtText_Leave(object sender, EventArgs e)
        {
            var entity = (MEEmrEntities)((BaseModuleERP)this.Module).CurrentModuleEntity;
            entity.MEImageParamList.SaveObjectToList(false);
        }
    }
}
