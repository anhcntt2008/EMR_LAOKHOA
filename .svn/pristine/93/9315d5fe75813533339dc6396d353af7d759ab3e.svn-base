using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Localization;
using BOSCommon;
using DevExpress.XtraBars;
using DevExpress.XtraRichEdit;
using DevExpress.XtraPdfViewer.Bars;
using DevExpress.XtraBars.Docking;
using BOSLib;

namespace BOSERP.Modules.MEEmr.UI
{
    public partial class DMMEEMR100 : BOSERPScreen
    {
        private ComponentResourceManager _resources;

        public DMMEEMR100()
        {
            InitializeComponent();

            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseForeColor = true;
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions1 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            this.dpnDocTree.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("NỘI TRÚ", true, customHeaderButtonImageOptions1,
            DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", 0, true, null, true, true, true,
            serializableAppearanceObject1, null, -1),
            new DevExpress.XtraBars.Docking.CustomHeaderButton("CHỈ XEM", true, customHeaderButtonImageOptions1,
            DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", 1, true, null, true, true, true,
            serializableAppearanceObject1, null, -1)
            });

            _resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMEEMR100));
            BarManager BarManager = new BarManager();
            BarManager.Form = this.xtraUserControl1;
            BarManager.ForceInitialize();
            StandaloneBarDockControl DockFilter = new StandaloneBarDockControl();
            DockFilter.AutoSize = true;
            BarManager.DockControls.Add(DockFilter);
            this.panelControl1.Controls.Add(DockFilter);
            DockFilter.Dock = DockStyle.Top;
            Bar BarFilter = new Bar(BarManager, "Pdf Toolbar");
            BarManager.Bars.Add(this.pdfCommandBar4);
            //BarFilter.AddItem(this.pdfFileOpenBarItem2);
            BarFilter.AddItem(this.pdfFileSaveAsBarItem2);
            BarFilter.AddItem(this.pdfFilePrintBarItem2);
            BarFilter.AddItem(this.pdfFindTextBarItem2);
            BarFilter.AddItem(this.pdfPreviousPageBarItem2);
            BarFilter.AddItem(this.pdfNextPageBarItem2);
            BarFilter.AddItem(this.pdfSetPageNumberBarItem2);
            BarFilter.AddItem(this.pdfZoomOutBarItem2);
            BarFilter.AddItem(this.pdfZoomInBarItem2);
            BarFilter.AddItem(this.pdfExactZoomListBarSubItem2);

            if (!string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserCaIdentity))
            {
                BarFilter.AddItem(this.GetDigitalSignPdfBarButtonItem(BarManager));
            }

            BarFilter.StandaloneBarDockControl = DockFilter;
            BarFilter.CanDockStyle = BarCanDockStyle.Standalone;
            BarFilter.DockStyle = BarDockStyle.Standalone;

            var col = this.fld_trlDocumentDataView.Columns.Add();
            col.Visible = true;
            col.FieldName = col.Name = "Thẻ";

            var col2 = this.fld_trlDocumentDataView.Columns.Add();
            col2.Visible = true;
            col2.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            col2.FieldName = col2.Name = "Giá trị";

            var col3 = this.fld_trlDocumentDataView.Columns.Add();
            col3.Visible = true;
            col3.VisibleIndex = -1;
            col3.FieldName = "Dữ liệu";
            WindowState = FormWindowState.Minimized;
            richEditCtrl.PopupMenuShowing += richEditCtrl_PopupMenuShowing;

            //khong hien thi nua
            this.reviewRibbonPage1.Visible = false;
            //chuyen nut dong to benh an len thanh toolbar
            this.barBtnLockDocument.Visibility = BarItemVisibility.Never;

            this.richEditCtrl.Click += new System.EventHandler(this.richEditCtrl_Click);

            if (string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserCaIdentity))
            {
                this.barBtnDigitalSignDocument.Visibility = BarItemVisibility.Never;
            }
            fld_pdfViewer.UriOpening += fld_pdfViewer_UriOpening;

            if (Devide.Current == Devide.Tablet)
            {
                if (Screen.PrimaryScreen.Bounds.Width < 1200)
                {
                    dpnDocTree.Dock = DockingStyle.Bottom;
                    tabbedView1.DocumentGroupProperties.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
                }
                else if (Screen.PrimaryScreen.Bounds.Height < 1000)
                {
                    tabbedView1.DocumentGroupProperties.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right;
                }

                lblAskForInit.Size = new Size(lblAskForInit.Size.Width, 30);
                fld_lbl_RichEditMsg.Size = new Size(fld_lbl_RichEditMsg.Size.Width, 30);

                this.fld_dgcMEEmrs.Visible = false;
                this.fld_dgcMEEmrDocuments.Location = new System.Drawing.Point(0, 3);
                this.fld_dgcMEEmrDocuments.Size = new System.Drawing.Size(255, 354);
            }
            this.barBtnMoveUpTableRow.Visibility = BarItemVisibility.Never;
            this.barBtnMoveDownTableRow.Visibility = BarItemVisibility.Never;
        }

        private void fld_pdfViewer_UriOpening(object sender, DevExpress.XtraPdfViewer.PdfUriOpeningEventArgs e)
        {
            if (e.Uri.Scheme == "http" || e.Uri.Scheme == "https")
            {
                ((MEEmrModule)Module).OpenWebBrowser(e.Uri.AbsoluteUri);
                e.Handled = true;
                e.Cancel = true;
            }
        }
        #region Context Menu
        private void richEditCtrl_PopupMenuShowing(object sender, DevExpress.XtraRichEdit.PopupMenuShowingEventArgs e)
        {
            //if ((e.MenuType & RichEditMenuType.Field) == RichEditMenuType.Field)
            //{
            //    var richEdit = sender as RichEditControl;
            //    var isAlowEdit = ((MEEmrModule)Module).IsAllowEditField(richEdit.Document.CaretPosition);
            //    for (int i = 0; i < e.Menu.Items.Count; i++)
            //    {
            //        var item = e.Menu.Items[i];
            //        switch (item.Caption)
            //        {
            //            case "Update Field":
            //            case "Toggle Field Codes":
            //                e.Menu.Items.Remove(item);
            //                i--;
            //                break;
            //            case "Cut":
            //            case "Paste":
            //                if (!isAlowEdit)
            //                {
            //                    e.Menu.Items.Remove(item);
            //                    i--;
            //                }
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}

            for (int i = 0; i < e.Menu.Items.Count; i++)
            {
                var item = e.Menu.Items[i];
                switch (item.Caption)
                {
                    case "Update Field":
                    case "Toggle Field Codes":
                        e.Menu.Items.Remove(item);
                        i--;
                        break;
                    case "Cut":
                    case "Paste":
                    case "Copy":
                        e.Menu.Items.Remove(item);
                        i--;
                        break;
                    case "New Comment":
                        e.Menu.Items.Remove(item);
                        i--;
                        break;
                    default:
                        break;
                }
            }
            var idx = 0;
            var menuItem = new DevExpress.Utils.Menu.DXMenuItem
            {
                BeginGroup = true,
                Caption = "Chữ ký ngắn"
            };
            menuItem.Click += ctxMenuShortSignature_ItemClick;
            e.Menu.Items.Insert(idx, menuItem);
            idx++;
            menuItem = new DevExpress.Utils.Menu.DXMenuItem
            {
                Caption = "Chữ ký đầy đủ"
            };
            menuItem.Click += ctxMenuFullSignature_ItemClick;
            e.Menu.Items.Insert(idx, menuItem);
            idx++;
            menuItem = new DevExpress.Utils.Menu.DXMenuItem
            {
                Caption = "Chữ ký hình"
            };
            menuItem.Click += ctxMenuImageSignature_ItemClick;
            e.Menu.Items.Insert(idx, menuItem);
            idx++;
            menuItem = new DevExpress.Utils.Menu.DXMenuItem
            {
                BeginGroup = true,
                Caption = "Đã dùng thuốc"
            };
            menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("bbiMedicationTaken.ImageOptions.Image")));
            menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("bbiMedicationTaken.ImageOptions.LargeImage")));
            menuItem.Click += ctxMenuDoneMedical_ItemClick;
            e.Menu.Items.Insert(idx, menuItem);
            idx++;
            menuItem = new DevExpress.Utils.Menu.DXMenuItem
            {
                Caption = "Ngưng dùng thuốc"
            };
            menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("bbiMedicationStop.ImageOptions.Image")));
            menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("bbiMedicationStop.ImageOptions.LargeImage")));
            menuItem.Click += ctxMenuStopMedical_ItemClick;
            e.Menu.Items.Insert(idx, menuItem);

            idx++;
            menuItem = new DevExpress.Utils.Menu.DXMenuItem
            {
                BeginGroup = true,
                Caption = "Ghi nhận dịch truyền"
            };
            menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("bbiMedicationInfutionTaken.ImageOptions.Image")));
            menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("bbiMedicationInfutionTaken.ImageOptions.LargeImage")));
            menuItem.Click += ctxMenuMedicationInfutionTaken_ItemClick;
            e.Menu.Items.Insert(idx, menuItem);

            idx++;
            menuItem = new DevExpress.Utils.Menu.DXMenuItem
            {
                Caption = "Xóa ghi nhận dịch truyền"
            };
            menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("bbiClearMedicationInfutionTaken.ImageOptions.Image")));
            menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("bbiClearMedicationInfutionTaken.ImageOptions.LargeImage")));
            menuItem.Click += ctxMenuClearMedicationInfutionTaken_ItemClick;
            e.Menu.Items.Insert(idx, menuItem);

            idx++;
            menuItem = new DevExpress.Utils.Menu.DXMenuItem
            {
                BeginGroup = true,
                Caption = "Thêm ghi chú"
            };
            menuItem.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/comments/insertcomment_16x16.png");
            menuItem.Click += ctxMenuNewDocumentNote_ItemClick;
            e.Menu.Items.Insert(idx, menuItem);

            if ((e.MenuType & RichEditMenuType.TableCell) == RichEditMenuType.TableCell)
            {
                idx++;
                menuItem = new DevExpress.Utils.Menu.DXMenuItem
                {
                    BeginGroup = true,
                    Caption = "Nhóm và sắp xếp"
                };
                menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("barButtonItem2.ImageOptions.Image")));
                menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
                menuItem.Click += ctxMenuGroupAndOrder_ItemClick;
                e.Menu.Items.Insert(idx, menuItem);


                idx++;
                menuItem = new DevExpress.Utils.Menu.DXMenuItem
                {
                    BeginGroup = false,
                    Caption = "Copy dòng/cột"
                };
                menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("barbtnCopyFromRowCol.ImageOptions.Image")));
                menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("barbtnCopyFromRowCol.ImageOptions.LargeImage")));
                menuItem.Click += ctxCopyFromRowOrColumn_ItemClick;
                e.Menu.Items.Insert(idx, menuItem);

                idx++;
                menuItem = new DevExpress.Utils.Menu.DXMenuItem
                {
                    BeginGroup = true,
                    Caption = "Sắp xếp thứ tự dòng"
                };
                menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("barBtnSortTableRow.ImageOptions.Image")));
                menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("barBtnSortTableRow.ImageOptions.LargeImage")));
                menuItem.Click += ctxSortTableRow_ItemClick;
                e.Menu.Items.Insert(idx, menuItem);
                idx++;
                /* Ut toi uu sau nay
                menuItem = new DevExpress.Utils.Menu.DXMenuItem
                {
                    BeginGroup = false,
                    Caption = "Chuyển dòng lên trên"
                };
                menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("barBtnMoveUpTableRow.ImageOptions.Image")));
                menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("barBtnMoveUpTableRow.ImageOptions.LargeImage")));
                menuItem.Click += ctxMoveRowUp_ItemClick;
                e.Menu.Items.Insert(idx, menuItem);

                idx++;
                menuItem = new DevExpress.Utils.Menu.DXMenuItem
                {
                    BeginGroup = false,
                    Caption = "Chuyển dòng xuống dưới"
                };
                menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("barBtnMoveDownTableRow.ImageOptions.Image")));
                menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("barBtnMoveDownTableRow.ImageOptions.LargeImage")));
                menuItem.Click += ctxMoveRowDown_ItemClick;
                e.Menu.Items.Insert(idx, menuItem);
                */
            }

            if ((e.MenuType & RichEditMenuType.InlinePicture) == RichEditMenuType.InlinePicture)
            {
                idx++;
                menuItem = new DevExpress.Utils.Menu.DXMenuItem
                {
                    BeginGroup = true,
                    Caption = "Sửa hình"
                };
                menuItem.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("barBtnDraw.ImageOptions.Image")));
                menuItem.ImageOptions.LargeImage = ((System.Drawing.Image)(_resources.GetObject("barBtnDraw.ImageOptions.LargeImage")));
                menuItem.Click += ctxEditImage_ItemClick;
                e.Menu.Items.Insert(idx, menuItem);
            }

            idx++;

            if (e.Menu.Items.Count > idx)
                e.Menu.Items[idx].BeginGroup = true;
        }

        private void ctxMenuNewDocumentNote_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).AddNewDocumentNote();
        }

        private void ctxEditImage_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).EditImage();
        }

        private void ctxMenuDoneMedical_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).DoubleStrikeThroughAllParam();
        }

        private void ctxMenuStopMedical_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).InsertCircleToRound();
        }

        private void ctxMenuGroupAndOrder_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).OrderAndGroupData();
        }

        private void ctxMenuImageSignature_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).InsertParam(EmrParam.ChuKyHinh);
        }

        private void ctxMenuFullSignature_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).InsertParam(EmrParam.ChuKyHoTen);
        }

        private void ctxMenuShortSignature_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).InsertParam(EmrParam.ChuKyTen);
        }
        #endregion Context Menu
        public override void AddControlsToParentScreen()
        {
            base.AddControlsToParentScreen();
            AddCustomControls();
        }
        private void AddCustomControls()
        {
            ((MEEmrModule)Module).DockManager = this.dockManager;
            ((MEEmrModule)Module).Controls.Add("dpnRichEdit", this.dpnRichEdit);
            ((MEEmrModule)Module).Controls.Add("dpnViewPdf", this.dpnViewPdf);
            ((MEEmrModule)Module).Controls.Add("richEditCtrl", this.richEditCtrl);
            ((MEEmrModule)Module).Controls.Add("fld_lbl_RichEditMsg", this.fld_lbl_RichEditMsg);
            ((MEEmrModule)Module).Controls.Add("richEditRibbonControl", this.ribbonEmr);
            ((MEEmrModule)Module).Controls.Add("lblAskForInit", this.lblAskForInit);
            ((MEEmrModule)Module).Controls.Add("btnInitEmr", this.btnInitEmr);
            ((MEEmrModule)Module).Controls.Add("dpnMsg", this.dpnMsg);
            ((MEEmrModule)Module).Controls.Add("msgLogs", this.msgLogs);
            ((MEEmrModule)Module).Controls.Add("fld_pdfViewer", this.fld_pdfViewer);
            ((MEEmrModule)Module).Controls.Add("fld_dgcEmrDocumentsDataHistory", this.fld_dgcEmrDocumentsDataHistory);
            ((MEEmrModule)Module).Controls.Add("fld_trlDocumentDataView", this.fld_trlDocumentDataView);
            this.fld_dgcEmrDocumentsDataHistory.Screen = this;
            this.fld_dgcEmrDocumentsDataHistory.InitializeControl();

            ((MEEmrModule)Module).Controls.Add("fld_dgcMEEmrDocumentSigns", this.fld_dgcMEEmrDocumentSigns);
            this.fld_dgcMEEmrDocumentSigns.Screen = this;
            this.fld_dgcMEEmrDocumentSigns.InitializeControl();

            ((MEEmrModule)Module).InitSymbolBarButton(barSubItemSymbol, ribbonEmr);
            LoadMoveBetweenTagByTabBtnConfig();
            LoadClickThenAutoMoveToNextTagConfig();
            LoadHighlightEmrTagConfig();
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            base.InitializeControls(controls);
        }
        private void barBtnInsertParam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //// ((METemplateModule)Module).ShowInsertParams();
        }

        private void barBtnInsertAction_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            // ((METemplateModule)Module).ShowInsertActions();
        }
        private void richEditCtrl_HyperlinkClick(object sender, DevExpress.XtraRichEdit.HyperlinkClickEventArgs e)
        {
            e.Handled = true;
            if (!e.Control)
            {
                //MessageBox.Show("Ctrl + Click to get link action");
                return;
            }
            ((MEEmrModule)Module).CallEmrAction(e.Hyperlink.NavigateUri, e.Hyperlink.Range);
        }


        private void fld_btn_AddNewEmrDocument_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).ShowNewEmrDocumentDialog();
        }

        private void fld_btn_DeleteEmrDocument_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrDocuments.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn mẫu bệnh án");
                return;
            }
            var row = gridView.GetRow(gridView.FocusedRowHandle) as MEEmrDocumentsInfo;
            if (row.MEEmrDocumentStatus == EmrDocumentStatus.Signed.ToString() || row.MEEmrDocumentStatus == EmrDocumentStatus.Closed.ToString())
            {
                MessageBox.Show("Chỉ được xóa các bệnh án ở trạng thái 'Đang nhập'");
                return;
            }
            ((MEEmrModule)Module).DeleteEmrDocument(row);

        }
        //private void fld_lbc_MEEmrs_MouseClick(object sender, MouseEventArgs e)
        //{
        //    var obj = (sender as ListBoxControl).SelectedItem as MEEmrsInfo;
        //    if (obj != null)
        //        ((MEEmrModule)Module).Invalidate(obj);
        //}

        private void barBtnSignDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (((MEEmrModule)Module).IsNothingToSaveDocumentContent())
            {
                ((MEEmrModule)Module).SignEmrDocument();
            }
        }

        private void barBtnLockDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).CloseCurrentEmrDocument();


        }
        private void barBtnViewParamInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).ViewParamInfo();
        }
        private void barBtnMonitoringVitalSign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).MonitoringVitalSign();
        }

        private void barBtnEditChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).ViewChartDesigner();
        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).ViewParamValues();
        }



        private void richEditCtrl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                ((MEEmrModule)Module).ViewParamValues();

            else if (e.Alt && e.KeyCode == Keys.Up) //up
                ((MEEmrModule)Module).GotoNextParam(e.KeyCode);
            else if (e.Alt && e.KeyCode == Keys.Left) //prevous
                ((MEEmrModule)Module).GotoNextParam(e.KeyCode);
            else if (e.Alt && e.KeyCode == Keys.Right) //next
                ((MEEmrModule)Module).GotoNextParam(e.KeyCode);
            else if (e.Alt && e.KeyCode == Keys.Down) //down
                ((MEEmrModule)Module).GotoNextParam(e.KeyCode);

            //else if (e.Alt && e.Shift && e.KeyCode == Keys.P)
            //    ((MEEmrModule)Module).ShowAllParam();
            //else if (e.Alt && e.Shift && e.KeyCode == Keys.H)
            //    ((MEEmrModule)Module).HideAllParam();

            else if (e.Control && e.KeyCode == Keys.C)
                ((MEEmrModule)Module).CopyParamValue();

            //handle in Module
            //else if (e.Control && e.KeyCode == Keys.P)
            //    ((MEEmrModule)Module).PasteParamValue(e);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).OpenDrawTool();
        }

        private void fld_btnRefreshJsonView_Click(object sender, EventArgs e)
        {
            //this.fld_medJsonView.Text = ((MEEmrModule)Module).GetDocumentJsonData();
            ((MEEmrModule)Module).GetDocumentDataHistory();
        }

        private void ribbonEmr_MinimizedChanged(object sender, EventArgs e)
        {
            if (this.ribbonEmr.Minimized)
            {
                this.richEditCtrl.Height = this.richEditCtrl.Height + 90;
                this.richEditCtrl.Location = new Point(this.richEditCtrl.Location.X, this.richEditCtrl.Location.Y - 90);
            }
            else
            {
                this.richEditCtrl.Height = this.richEditCtrl.Height - 90;
                this.richEditCtrl.Location = new Point(this.richEditCtrl.Location.X, this.richEditCtrl.Location.Y + 90);
            }
        }

        private void ribbonEmr_MinimizedRibbonHiding(object sender, DevExpress.XtraBars.Ribbon.MinimizedRibbonEventArgs e)
        {
            this.richEditCtrl.Height = this.richEditCtrl.Height + 90;
            this.richEditCtrl.Location = new Point(this.richEditCtrl.Location.X, this.richEditCtrl.Location.Y - 90);
        }

        private void ribbonEmr_MinimizedRibbonShowing(object sender, DevExpress.XtraBars.Ribbon.MinimizedRibbonEventArgs e)
        {
            this.richEditCtrl.Height = this.richEditCtrl.Height - 90;
            this.richEditCtrl.Location = new Point(this.richEditCtrl.Location.X, this.richEditCtrl.Location.Y + 90);
        }

        private void barButtonItemCamera_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).OpenCameraTool();
        }

        private void fld_btnRefreshDocumentSign_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).GetDocumentSignHistory();
        }

        private void barButtonItemShortSignature_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).InsertParam("chuky_ten");
        }

        private void barButtonItemLongSignature_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).InsertParam("chuky_hoten");
        }

        private void barButtonItemImageSignture_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).InsertParam("chuky_hinh");
        }

        private void barButtonItemSubTemplate_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).InsertSubTemplate();
        }

        private void barButtonItemDataQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).QueryDocumentData();
        }
        /// <summary>
        /// Đã dùng thuốc, gạch ngang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiMedicationTaken_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).DoubleStrikeThroughAllParam();
        }
        private void ctxMenuMedicationInfutionTaken_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).MedicationInfutionTakenNote();
        }
        private void bbiMedicationInfutionTaken_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).MedicationInfutionTakenNote();
        }
        private void ctxMenuClearMedicationInfutionTaken_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).ClearMedicationInfutionTakenNote();
        }
        private void bbiClearMedicationInfutionTaken_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).ClearMedicationInfutionTakenNote();
        }

        /// <summary>
        /// Ngưng dùng thuốc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiMedicationStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).InsertCircleToRound();
        }

        private void barButtonItemOrderAndGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).OrderAndGroupData();
        }

        private void fld_btn_HidingEmrDocument_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcMEEmrDocuments.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn tờ bệnh án");
                return;
            }
            var row = gridView.GetRow(gridView.FocusedRowHandle) as MEEmrDocumentsInfo;
            ((MEEmrModule)Module).HidingEmrDocument(row);
        }

        private void richEditCtrl_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).IsRichEditInputMode = false;
            var caret = richEditCtrl.Document.CaretPosition.ToInt();
            if (((MEEmrModule)Module).IsPositionInsideEmrTag(caret))
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    ((MEEmrModule)Module).CheckEmrParam();
                    return;
                }
                else
                {
                    ((MEEmrModule)Module).ClickThenMoveToBeginTag();
                }
            }
            else
            {
                if (!ModifierKeys.HasFlag(Keys.Control) && barbtnConfigClickThenMoveNextTag.Checked)
                {
                    ((MEEmrModule)Module).ClickThenMoveNextTag();
                }
            }
        }

        private void fld_btn_AddNewPatientDocument_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).ShowNewPatientDocumentDialog();
        }

        private void fld_btn_HidingPatientDocument_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)this.fld_dgcEmrPatientDocuments.MainView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn tờ bệnh án");
                return;
            }
            var row = gridView.GetRow(gridView.FocusedRowHandle) as MEEmrDocumentsInfo;
            ((MEEmrModule)Module).HidingEmrDocument(row);
        }

        private void barButtonItemRefreshAbbrev_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).LoadUserAbbrevs();
        }

        private void btnInitEmr_Click(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).InitEmr();
        }

        private void ctxCopyFromRowOrColumn_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).CopyFromRowOrColumn();
        }

        private void barbtnCopyFromRowCol_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).CopyFromRowOrColumn();
        }
        private void barbtnConfigTabButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            BOSApp.SaveMoveBetweenTagByTabConfig();
            LoadMoveBetweenTagByTabBtnConfig();
        }
        private void LoadMoveBetweenTagByTabBtnConfig()
        {
            barbtnConfigTabButton.Checked = ((MEEmrModule)Module).LoadMoveBetweenTagByTabBtnConfig();
        }

        private void LoadClickThenAutoMoveToNextTagConfig()
        {
            barbtnConfigClickThenMoveNextTag.Checked = ((MEEmrModule)Module).LoadClickThenAutoMoveToNextTagConfig();
        }
        private void barbtnConfigClickThenMoveNextTag_ItemClick(object sender, ItemClickEventArgs e)
        {
            BOSApp.SaveClickThenAutoMoveToNextTagConfig();
            LoadClickThenAutoMoveToNextTagConfig();
        } 
        // Ký số 
        private void barBtnDigitalSignDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).DigitalSignEmrDocument();
        }
        private BarButtonItem GetDigitalSignPdfBarButtonItem(BarManager barManager)
        {
            var btn = new BarButtonItem(barManager, "Ký số");
            btn.ImageOptions.Image = ((System.Drawing.Image)(_resources.GetObject("barBtnDigitalSignDocument.ImageOptions.Img16x16")));
            btn.ItemClick += barBtnDigitalSignDocument_ItemClick;
            return btn;
        }

        private void LoadHighlightEmrTagConfig()
        {
            barbtnConfigHighlightEmrTag.Checked = ((MEEmrModule)Module).LoadHighlightEmrTagUserConfig();
        }
        private void barbtnConfigHighlightEmrTag_ItemClick(object sender, ItemClickEventArgs e)
        {
            BOSApp.SaveUserHighlightEmrTagConfig();
            LoadHighlightEmrTagConfig();
        }

        void dpnDocTree_ClosingPanel(object sender, DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
            dpnDocTree.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            dpnDocTree.HideImmediately();
        }
        #region Chuyen dong TDT len xuong
        private void ctxSortTableRow_ItemClick(object sender, EventArgs e)
        {
            ((MEEmrModule)Module).SortTableRow();
        }

        private void ctxMoveRowUp_ItemClick(object sender, EventArgs e)
        {
        }

        private void ctxMoveRowDown_ItemClick(object sender, EventArgs e)
        {
        }

        private void barBtnSortTableRow_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).SortTableRow();
        }

        private void barBtnMoveUpTableRow_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barBtnMoveDownTableRow_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion
        private void dockManager_ActivePanelChanged(object sender, ActivePanelChangedEventArgs e)
        {
            if (e.Panel == null && e.OldPanel.Visibility == DockVisibility.AutoHide)
                e.OldPanel.HideImmediately();
        }

        private void barButtonItemNewDocumentNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).AddNewDocumentNote();
        }

        private void barButtonPatientSign_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MEEmrModule)Module).PatientSign();
        }
    }
}