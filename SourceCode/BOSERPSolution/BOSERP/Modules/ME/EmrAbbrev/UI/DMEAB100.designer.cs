using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.EmrAbbrev.UI
{
	/// <summary>
	/// Summary description for DMEAB100
	/// </summary>
	partial class DMEAB100
	{


		/// <summary>
		/// Clean up any resources being used
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				if (components != null)
					components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMEAB100));
            this.fld_dgcMEEmrAbbrevs = new BOSERP.Modules.EmrAbbrev.MEEmrAbbrevsGridControl();
            this.fld_dgvMEEmrImages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.riPopup = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl = new DevExpress.XtraEditors.PopupContainerControl();
            this.xtraUserControl1 = new DevExpress.XtraEditors.XtraUserControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.clipboardBar1 = new DevExpress.XtraRichEdit.UI.ClipboardBar();
            this.richEditControl = new DevExpress.XtraRichEdit.RichEditControl();
            this.pasteItem1 = new DevExpress.XtraRichEdit.UI.PasteItem();
            this.cutItem1 = new DevExpress.XtraRichEdit.UI.CutItem();
            this.copyItem1 = new DevExpress.XtraRichEdit.UI.CopyItem();
            this.pasteSpecialItem1 = new DevExpress.XtraRichEdit.UI.PasteSpecialItem();
            this.fontBar1 = new DevExpress.XtraRichEdit.UI.FontBar();
            this.changeFontNameItem1 = new DevExpress.XtraRichEdit.UI.ChangeFontNameItem();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.changeFontSizeItem1 = new DevExpress.XtraRichEdit.UI.ChangeFontSizeItem();
            this.repositoryItemRichEditFontSizeEdit1 = new DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit();
            this.fontSizeIncreaseItem1 = new DevExpress.XtraRichEdit.UI.FontSizeIncreaseItem();
            this.fontSizeDecreaseItem1 = new DevExpress.XtraRichEdit.UI.FontSizeDecreaseItem();
            this.toggleFontBoldItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontBoldItem();
            this.toggleFontItalicItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontItalicItem();
            this.toggleFontUnderlineItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontUnderlineItem();
            this.toggleFontDoubleUnderlineItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontDoubleUnderlineItem();
            this.toggleFontStrikeoutItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontStrikeoutItem();
            this.toggleFontDoubleStrikeoutItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontDoubleStrikeoutItem();
            this.toggleFontSuperscriptItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontSuperscriptItem();
            this.toggleFontSubscriptItem1 = new DevExpress.XtraRichEdit.UI.ToggleFontSubscriptItem();
            this.changeFontColorItem1 = new DevExpress.XtraRichEdit.UI.ChangeFontColorItem();
            this.changeFontHighlightColorItem1 = new DevExpress.XtraRichEdit.UI.ChangeFontHighlightColorItem();
            this.changeTextCaseItem1 = new DevExpress.XtraRichEdit.UI.ChangeTextCaseItem();
            this.makeTextUpperCaseItem1 = new DevExpress.XtraRichEdit.UI.MakeTextUpperCaseItem();
            this.makeTextLowerCaseItem1 = new DevExpress.XtraRichEdit.UI.MakeTextLowerCaseItem();
            this.capitalizeEachWordCaseItem1 = new DevExpress.XtraRichEdit.UI.CapitalizeEachWordCaseItem();
            this.toggleTextCaseItem1 = new DevExpress.XtraRichEdit.UI.ToggleTextCaseItem();
            this.clearFormattingItem1 = new DevExpress.XtraRichEdit.UI.ClearFormattingItem();
            this.showFontFormItem1 = new DevExpress.XtraRichEdit.UI.ShowFontFormItem();
            this.paragraphBar1 = new DevExpress.XtraRichEdit.UI.ParagraphBar();
            this.toggleBulletedListItem1 = new DevExpress.XtraRichEdit.UI.ToggleBulletedListItem();
            this.toggleNumberingListItem1 = new DevExpress.XtraRichEdit.UI.ToggleNumberingListItem();
            this.toggleMultiLevelListItem1 = new DevExpress.XtraRichEdit.UI.ToggleMultiLevelListItem();
            this.decreaseIndentItem1 = new DevExpress.XtraRichEdit.UI.DecreaseIndentItem();
            this.increaseIndentItem1 = new DevExpress.XtraRichEdit.UI.IncreaseIndentItem();
            this.toggleParagraphAlignmentLeftItem1 = new DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentLeftItem();
            this.toggleParagraphAlignmentCenterItem1 = new DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentCenterItem();
            this.toggleParagraphAlignmentRightItem1 = new DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentRightItem();
            this.toggleParagraphAlignmentJustifyItem1 = new DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentJustifyItem();
            this.toggleShowWhitespaceItem1 = new DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem();
            this.changeParagraphLineSpacingItem1 = new DevExpress.XtraRichEdit.UI.ChangeParagraphLineSpacingItem();
            this.setSingleParagraphSpacingItem1 = new DevExpress.XtraRichEdit.UI.SetSingleParagraphSpacingItem();
            this.setSesquialteralParagraphSpacingItem1 = new DevExpress.XtraRichEdit.UI.SetSesquialteralParagraphSpacingItem();
            this.setDoubleParagraphSpacingItem1 = new DevExpress.XtraRichEdit.UI.SetDoubleParagraphSpacingItem();
            this.showLineSpacingFormItem1 = new DevExpress.XtraRichEdit.UI.ShowLineSpacingFormItem();
            this.addSpacingBeforeParagraphItem1 = new DevExpress.XtraRichEdit.UI.AddSpacingBeforeParagraphItem();
            this.removeSpacingBeforeParagraphItem1 = new DevExpress.XtraRichEdit.UI.RemoveSpacingBeforeParagraphItem();
            this.addSpacingAfterParagraphItem1 = new DevExpress.XtraRichEdit.UI.AddSpacingAfterParagraphItem();
            this.removeSpacingAfterParagraphItem1 = new DevExpress.XtraRichEdit.UI.RemoveSpacingAfterParagraphItem();
            this.changeParagraphBackColorItem1 = new DevExpress.XtraRichEdit.UI.ChangeParagraphBackColorItem();
            this.showParagraphFormItem1 = new DevExpress.XtraRichEdit.UI.ShowParagraphFormItem();
            this.changeStyleItem1 = new DevExpress.XtraRichEdit.UI.ChangeStyleItem();
            this.repositoryItemRichEditStyleEdit1 = new DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit();
            this.showEditStyleFormItem1 = new DevExpress.XtraRichEdit.UI.ShowEditStyleFormItem();
            this.editingBar1 = new DevExpress.XtraRichEdit.UI.EditingBar();
            this.findItem1 = new DevExpress.XtraRichEdit.UI.FindItem();
            this.replaceItem1 = new DevExpress.XtraRichEdit.UI.ReplaceItem();
            this.insertPageBreakItem21 = new DevExpress.XtraRichEdit.UI.InsertPageBreakItem2();
            this.tablesBar1 = new DevExpress.XtraRichEdit.UI.TablesBar();
            this.insertTableItem1 = new DevExpress.XtraRichEdit.UI.InsertTableItem();
            this.illustrationsBar1 = new DevExpress.XtraRichEdit.UI.IllustrationsBar();
            this.insertPictureItem1 = new DevExpress.XtraRichEdit.UI.InsertPictureItem();
            this.insertFloatingPictureItem1 = new DevExpress.XtraRichEdit.UI.InsertFloatingPictureItem();
            this.linksBar1 = new DevExpress.XtraRichEdit.UI.LinksBar();
            this.insertBookmarkItem1 = new DevExpress.XtraRichEdit.UI.InsertBookmarkItem();
            this.insertHyperlinkItem1 = new DevExpress.XtraRichEdit.UI.InsertHyperlinkItem();
            this.editPageHeaderItem1 = new DevExpress.XtraRichEdit.UI.EditPageHeaderItem();
            this.editPageFooterItem1 = new DevExpress.XtraRichEdit.UI.EditPageFooterItem();
            this.insertPageNumberItem1 = new DevExpress.XtraRichEdit.UI.InsertPageNumberItem();
            this.insertPageCountItem1 = new DevExpress.XtraRichEdit.UI.InsertPageCountItem();
            this.insertTextBoxItem1 = new DevExpress.XtraRichEdit.UI.InsertTextBoxItem();
            this.symbolsBar1 = new DevExpress.XtraRichEdit.UI.SymbolsBar();
            this.insertSymbolItem1 = new DevExpress.XtraRichEdit.UI.InsertSymbolItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.richEditBarController1 = new DevExpress.XtraRichEdit.UI.RichEditBarController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrAbbrevs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPopup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl)).BeginInit();
            this.popupContainerControl.SuspendLayout();
            this.xtraUserControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcMEEmrAbbrevs
            // 
            this.fld_dgcMEEmrAbbrevs.AllowDrop = true;
            this.fld_dgcMEEmrAbbrevs.BOSComment = "";
            this.fld_dgcMEEmrAbbrevs.BOSDataMember = "";
            this.fld_dgcMEEmrAbbrevs.BOSDataSource = "MEEmrAbbrevs";
            this.fld_dgcMEEmrAbbrevs.BOSDescription = null;
            this.fld_dgcMEEmrAbbrevs.BOSError = null;
            this.fld_dgcMEEmrAbbrevs.BOSFieldGroup = "";
            this.fld_dgcMEEmrAbbrevs.BOSFieldRelation = "";
            this.fld_dgcMEEmrAbbrevs.BOSGridType = null;
            this.fld_dgcMEEmrAbbrevs.BOSPrivilege = "";
            this.fld_dgcMEEmrAbbrevs.BOSPropertyName = "";
            this.fld_dgcMEEmrAbbrevs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcMEEmrAbbrevs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrAbbrevs.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcMEEmrAbbrevs.MainView = this.fld_dgvMEEmrImages;
            this.fld_dgcMEEmrAbbrevs.Name = "fld_dgcMEEmrAbbrevs";
            this.fld_dgcMEEmrAbbrevs.PrintReport = false;
            this.fld_dgcMEEmrAbbrevs.Screen = null;
            this.fld_dgcMEEmrAbbrevs.Size = new System.Drawing.Size(862, 567);
            this.fld_dgcMEEmrAbbrevs.TabIndex = 11;
            this.fld_dgcMEEmrAbbrevs.Tag = "DC";
            this.fld_dgcMEEmrAbbrevs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrImages});
            // 
            // fld_dgvMEEmrImages
            // 
            this.fld_dgvMEEmrImages.GridControl = this.fld_dgcMEEmrAbbrevs;
            this.fld_dgvMEEmrImages.Name = "fld_dgvMEEmrImages";
            this.fld_dgvMEEmrImages.PaintStyleName = "Office2003";
            // 
            // riPopup
            // 
            this.riPopup.AutoHeight = false;
            this.riPopup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riPopup.Name = "riPopup";
            this.riPopup.PopupControl = this.popupContainerControl;
            this.riPopup.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.riPopup_QueryResultValue);
            this.riPopup.QueryDisplayText += new DevExpress.XtraEditors.Controls.QueryDisplayTextEventHandler(this.riPopup_QueryDisplayText);
            this.riPopup.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.riPopup_QueryPopUp);
            this.riPopup.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.riPopup_CloseUp);
            // 
            // popupContainerControl
            // 
            this.popupContainerControl.Controls.Add(this.xtraUserControl1);
            this.popupContainerControl.Controls.Add(this.richEditControl);
            this.popupContainerControl.Location = new System.Drawing.Point(12, 313);
            this.popupContainerControl.Name = "popupContainerControl";
            this.popupContainerControl.Size = new System.Drawing.Size(850, 254);
            this.popupContainerControl.TabIndex = 1;
            this.popupContainerControl.Paint += new System.Windows.Forms.PaintEventHandler(this.popupContainerControl_Paint);
            // 
            // xtraUserControl1
            // 
            this.xtraUserControl1.Controls.Add(this.barDockControl3);
            this.xtraUserControl1.Controls.Add(this.barDockControl4);
            this.xtraUserControl1.Controls.Add(this.barDockControl2);
            this.xtraUserControl1.Controls.Add(this.barDockControl1);
            this.xtraUserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraUserControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraUserControl1.Name = "xtraUserControl1";
            this.xtraUserControl1.Size = new System.Drawing.Size(850, 68);
            this.xtraUserControl1.TabIndex = 1;
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 62);
            this.barDockControl3.Manager = this.barManager1;
            this.barDockControl3.Size = new System.Drawing.Size(0, 6);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.clipboardBar1,
            this.fontBar1,
            this.paragraphBar1,
            this.editingBar1,
            this.tablesBar1,
            this.illustrationsBar1,
            this.linksBar1,
            this.symbolsBar1});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this.xtraUserControl1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.pasteItem1,
            this.cutItem1,
            this.copyItem1,
            this.pasteSpecialItem1,
            this.changeFontNameItem1,
            this.changeFontSizeItem1,
            this.fontSizeIncreaseItem1,
            this.fontSizeDecreaseItem1,
            this.toggleFontBoldItem1,
            this.toggleFontItalicItem1,
            this.toggleFontUnderlineItem1,
            this.toggleFontDoubleUnderlineItem1,
            this.toggleFontStrikeoutItem1,
            this.toggleFontDoubleStrikeoutItem1,
            this.toggleFontSuperscriptItem1,
            this.toggleFontSubscriptItem1,
            this.changeFontColorItem1,
            this.changeFontHighlightColorItem1,
            this.changeTextCaseItem1,
            this.makeTextUpperCaseItem1,
            this.makeTextLowerCaseItem1,
            this.capitalizeEachWordCaseItem1,
            this.toggleTextCaseItem1,
            this.clearFormattingItem1,
            this.showFontFormItem1,
            this.toggleBulletedListItem1,
            this.toggleNumberingListItem1,
            this.toggleMultiLevelListItem1,
            this.decreaseIndentItem1,
            this.increaseIndentItem1,
            this.toggleParagraphAlignmentLeftItem1,
            this.toggleParagraphAlignmentCenterItem1,
            this.toggleParagraphAlignmentRightItem1,
            this.toggleParagraphAlignmentJustifyItem1,
            this.toggleShowWhitespaceItem1,
            this.changeParagraphLineSpacingItem1,
            this.setSingleParagraphSpacingItem1,
            this.setSesquialteralParagraphSpacingItem1,
            this.setDoubleParagraphSpacingItem1,
            this.showLineSpacingFormItem1,
            this.addSpacingBeforeParagraphItem1,
            this.removeSpacingBeforeParagraphItem1,
            this.addSpacingAfterParagraphItem1,
            this.removeSpacingAfterParagraphItem1,
            this.changeParagraphBackColorItem1,
            this.showParagraphFormItem1,
            this.changeStyleItem1,
            this.showEditStyleFormItem1,
            this.findItem1,
            this.replaceItem1,
            this.insertPageBreakItem21,
            this.insertTableItem1,
            this.insertPictureItem1,
            this.insertFloatingPictureItem1,
            this.insertBookmarkItem1,
            this.insertHyperlinkItem1,
            this.editPageHeaderItem1,
            this.editPageFooterItem1,
            this.insertPageNumberItem1,
            this.insertPageCountItem1,
            this.insertTextBoxItem1,
            this.insertSymbolItem1});
            this.barManager1.MaxItemId = 62;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemFontEdit1,
            this.repositoryItemRichEditFontSizeEdit1,
            this.repositoryItemRichEditStyleEdit1});
            // 
            // clipboardBar1
            // 
            this.clipboardBar1.Control = this.richEditControl;
            this.clipboardBar1.DockCol = 0;
            this.clipboardBar1.DockRow = 0;
            this.clipboardBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.clipboardBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.pasteItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "V", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.cutItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "X", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.copyItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "C", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.pasteSpecialItem1)});
            // 
            // richEditControl
            // 
            this.richEditControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richEditControl.Location = new System.Drawing.Point(3, 62);
            this.richEditControl.MenuManager = this.barManager1;
            this.richEditControl.Name = "richEditControl";
            this.richEditControl.Options.Printing.PrintPreviewFormKind = DevExpress.XtraRichEdit.PrintPreviewFormKind.Bars;
            this.richEditControl.Size = new System.Drawing.Size(844, 189);
            this.richEditControl.TabIndex = 0;
            // 
            // pasteItem1
            // 
            this.pasteItem1.Id = 0;
            this.pasteItem1.Name = "pasteItem1";
            // 
            // cutItem1
            // 
            this.cutItem1.Id = 1;
            this.cutItem1.Name = "cutItem1";
            // 
            // copyItem1
            // 
            this.copyItem1.Id = 2;
            this.copyItem1.Name = "copyItem1";
            // 
            // pasteSpecialItem1
            // 
            this.pasteSpecialItem1.Id = 3;
            this.pasteSpecialItem1.Name = "pasteSpecialItem1";
            // 
            // fontBar1
            // 
            this.fontBar1.Control = this.richEditControl;
            this.fontBar1.DockCol = 1;
            this.fontBar1.DockRow = 0;
            this.fontBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.fontBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.changeFontNameItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "FF", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.changeFontSizeItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.fontSizeIncreaseItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "FG", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.fontSizeDecreaseItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "FK", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontBoldItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontItalicItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontUnderlineItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontDoubleUnderlineItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontStrikeoutItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontDoubleStrikeoutItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontSuperscriptItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleFontSubscriptItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.changeFontColorItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "FC", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.changeFontHighlightColorItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "I", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.changeTextCaseItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.clearFormattingItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "E", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.showFontFormItem1)});
            // 
            // changeFontNameItem1
            // 
            this.changeFontNameItem1.Edit = this.repositoryItemFontEdit1;
            this.changeFontNameItem1.Id = 4;
            this.changeFontNameItem1.Name = "changeFontNameItem1";
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // changeFontSizeItem1
            // 
            this.changeFontSizeItem1.Edit = this.repositoryItemRichEditFontSizeEdit1;
            this.changeFontSizeItem1.Id = 5;
            this.changeFontSizeItem1.Name = "changeFontSizeItem1";
            // 
            // repositoryItemRichEditFontSizeEdit1
            // 
            this.repositoryItemRichEditFontSizeEdit1.AutoHeight = false;
            this.repositoryItemRichEditFontSizeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRichEditFontSizeEdit1.Control = this.richEditControl;
            this.repositoryItemRichEditFontSizeEdit1.Name = "repositoryItemRichEditFontSizeEdit1";
            // 
            // fontSizeIncreaseItem1
            // 
            this.fontSizeIncreaseItem1.Id = 6;
            this.fontSizeIncreaseItem1.Name = "fontSizeIncreaseItem1";
            // 
            // fontSizeDecreaseItem1
            // 
            this.fontSizeDecreaseItem1.Id = 7;
            this.fontSizeDecreaseItem1.Name = "fontSizeDecreaseItem1";
            // 
            // toggleFontBoldItem1
            // 
            this.toggleFontBoldItem1.Id = 8;
            this.toggleFontBoldItem1.Name = "toggleFontBoldItem1";
            // 
            // toggleFontItalicItem1
            // 
            this.toggleFontItalicItem1.Id = 9;
            this.toggleFontItalicItem1.Name = "toggleFontItalicItem1";
            // 
            // toggleFontUnderlineItem1
            // 
            this.toggleFontUnderlineItem1.Id = 10;
            this.toggleFontUnderlineItem1.Name = "toggleFontUnderlineItem1";
            // 
            // toggleFontDoubleUnderlineItem1
            // 
            this.toggleFontDoubleUnderlineItem1.Id = 11;
            this.toggleFontDoubleUnderlineItem1.Name = "toggleFontDoubleUnderlineItem1";
            // 
            // toggleFontStrikeoutItem1
            // 
            this.toggleFontStrikeoutItem1.Id = 12;
            this.toggleFontStrikeoutItem1.Name = "toggleFontStrikeoutItem1";
            // 
            // toggleFontDoubleStrikeoutItem1
            // 
            this.toggleFontDoubleStrikeoutItem1.Id = 13;
            this.toggleFontDoubleStrikeoutItem1.Name = "toggleFontDoubleStrikeoutItem1";
            // 
            // toggleFontSuperscriptItem1
            // 
            this.toggleFontSuperscriptItem1.Id = 14;
            this.toggleFontSuperscriptItem1.Name = "toggleFontSuperscriptItem1";
            // 
            // toggleFontSubscriptItem1
            // 
            this.toggleFontSubscriptItem1.Id = 15;
            this.toggleFontSubscriptItem1.Name = "toggleFontSubscriptItem1";
            // 
            // changeFontColorItem1
            // 
            this.changeFontColorItem1.Id = 16;
            this.changeFontColorItem1.Name = "changeFontColorItem1";
            // 
            // changeFontHighlightColorItem1
            // 
            this.changeFontHighlightColorItem1.Id = 17;
            this.changeFontHighlightColorItem1.Name = "changeFontHighlightColorItem1";
            // 
            // changeTextCaseItem1
            // 
            this.changeTextCaseItem1.Id = 18;
            this.changeTextCaseItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.makeTextUpperCaseItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.makeTextLowerCaseItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.capitalizeEachWordCaseItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleTextCaseItem1)});
            this.changeTextCaseItem1.Name = "changeTextCaseItem1";
            // 
            // makeTextUpperCaseItem1
            // 
            this.makeTextUpperCaseItem1.Id = 19;
            this.makeTextUpperCaseItem1.Name = "makeTextUpperCaseItem1";
            // 
            // makeTextLowerCaseItem1
            // 
            this.makeTextLowerCaseItem1.Id = 20;
            this.makeTextLowerCaseItem1.Name = "makeTextLowerCaseItem1";
            // 
            // capitalizeEachWordCaseItem1
            // 
            this.capitalizeEachWordCaseItem1.Id = 21;
            this.capitalizeEachWordCaseItem1.Name = "capitalizeEachWordCaseItem1";
            // 
            // toggleTextCaseItem1
            // 
            this.toggleTextCaseItem1.Id = 22;
            this.toggleTextCaseItem1.Name = "toggleTextCaseItem1";
            // 
            // clearFormattingItem1
            // 
            this.clearFormattingItem1.Id = 23;
            this.clearFormattingItem1.Name = "clearFormattingItem1";
            // 
            // showFontFormItem1
            // 
            this.showFontFormItem1.Id = 24;
            this.showFontFormItem1.Name = "showFontFormItem1";
            // 
            // paragraphBar1
            // 
            this.paragraphBar1.Control = this.richEditControl;
            this.paragraphBar1.DockCol = 0;
            this.paragraphBar1.DockRow = 1;
            this.paragraphBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.paragraphBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.toggleBulletedListItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "U", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.toggleNumberingListItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "N", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.toggleMultiLevelListItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "M", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.decreaseIndentItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "AO", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.increaseIndentItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "AI", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.toggleParagraphAlignmentLeftItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "AL", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.toggleParagraphAlignmentCenterItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "AC", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.toggleParagraphAlignmentRightItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "AR", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.toggleParagraphAlignmentJustifyItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "AJ", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.toggleShowWhitespaceItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.changeParagraphLineSpacingItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "K", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.changeParagraphBackColorItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "H", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.showParagraphFormItem1)});
            // 
            // toggleBulletedListItem1
            // 
            this.toggleBulletedListItem1.Id = 25;
            this.toggleBulletedListItem1.Name = "toggleBulletedListItem1";
            // 
            // toggleNumberingListItem1
            // 
            this.toggleNumberingListItem1.Id = 26;
            this.toggleNumberingListItem1.Name = "toggleNumberingListItem1";
            // 
            // toggleMultiLevelListItem1
            // 
            this.toggleMultiLevelListItem1.Id = 27;
            this.toggleMultiLevelListItem1.Name = "toggleMultiLevelListItem1";
            // 
            // decreaseIndentItem1
            // 
            this.decreaseIndentItem1.Id = 28;
            this.decreaseIndentItem1.Name = "decreaseIndentItem1";
            // 
            // increaseIndentItem1
            // 
            this.increaseIndentItem1.Id = 29;
            this.increaseIndentItem1.Name = "increaseIndentItem1";
            // 
            // toggleParagraphAlignmentLeftItem1
            // 
            this.toggleParagraphAlignmentLeftItem1.Id = 30;
            this.toggleParagraphAlignmentLeftItem1.Name = "toggleParagraphAlignmentLeftItem1";
            // 
            // toggleParagraphAlignmentCenterItem1
            // 
            this.toggleParagraphAlignmentCenterItem1.Id = 31;
            this.toggleParagraphAlignmentCenterItem1.Name = "toggleParagraphAlignmentCenterItem1";
            // 
            // toggleParagraphAlignmentRightItem1
            // 
            this.toggleParagraphAlignmentRightItem1.Id = 32;
            this.toggleParagraphAlignmentRightItem1.Name = "toggleParagraphAlignmentRightItem1";
            // 
            // toggleParagraphAlignmentJustifyItem1
            // 
            this.toggleParagraphAlignmentJustifyItem1.Id = 33;
            this.toggleParagraphAlignmentJustifyItem1.Name = "toggleParagraphAlignmentJustifyItem1";
            // 
            // toggleShowWhitespaceItem1
            // 
            this.toggleShowWhitespaceItem1.Id = 34;
            this.toggleShowWhitespaceItem1.Name = "toggleShowWhitespaceItem1";
            // 
            // changeParagraphLineSpacingItem1
            // 
            this.changeParagraphLineSpacingItem1.Id = 35;
            this.changeParagraphLineSpacingItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.setSingleParagraphSpacingItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.setSesquialteralParagraphSpacingItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.setDoubleParagraphSpacingItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.showLineSpacingFormItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.addSpacingBeforeParagraphItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "B", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.removeSpacingBeforeParagraphItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.addSpacingAfterParagraphItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.removeSpacingAfterParagraphItem1)});
            this.changeParagraphLineSpacingItem1.Name = "changeParagraphLineSpacingItem1";
            // 
            // setSingleParagraphSpacingItem1
            // 
            this.setSingleParagraphSpacingItem1.Id = 36;
            this.setSingleParagraphSpacingItem1.Name = "setSingleParagraphSpacingItem1";
            // 
            // setSesquialteralParagraphSpacingItem1
            // 
            this.setSesquialteralParagraphSpacingItem1.Id = 37;
            this.setSesquialteralParagraphSpacingItem1.Name = "setSesquialteralParagraphSpacingItem1";
            // 
            // setDoubleParagraphSpacingItem1
            // 
            this.setDoubleParagraphSpacingItem1.Id = 38;
            this.setDoubleParagraphSpacingItem1.Name = "setDoubleParagraphSpacingItem1";
            // 
            // showLineSpacingFormItem1
            // 
            this.showLineSpacingFormItem1.Id = 39;
            this.showLineSpacingFormItem1.Name = "showLineSpacingFormItem1";
            // 
            // addSpacingBeforeParagraphItem1
            // 
            this.addSpacingBeforeParagraphItem1.Id = 40;
            this.addSpacingBeforeParagraphItem1.Name = "addSpacingBeforeParagraphItem1";
            // 
            // removeSpacingBeforeParagraphItem1
            // 
            this.removeSpacingBeforeParagraphItem1.Id = 41;
            this.removeSpacingBeforeParagraphItem1.Name = "removeSpacingBeforeParagraphItem1";
            // 
            // addSpacingAfterParagraphItem1
            // 
            this.addSpacingAfterParagraphItem1.Id = 42;
            this.addSpacingAfterParagraphItem1.Name = "addSpacingAfterParagraphItem1";
            // 
            // removeSpacingAfterParagraphItem1
            // 
            this.removeSpacingAfterParagraphItem1.Id = 43;
            this.removeSpacingAfterParagraphItem1.Name = "removeSpacingAfterParagraphItem1";
            // 
            // changeParagraphBackColorItem1
            // 
            this.changeParagraphBackColorItem1.Id = 44;
            this.changeParagraphBackColorItem1.Name = "changeParagraphBackColorItem1";
            // 
            // showParagraphFormItem1
            // 
            this.showParagraphFormItem1.Id = 45;
            this.showParagraphFormItem1.Name = "showParagraphFormItem1";
            // 
            // changeStyleItem1
            // 
            this.changeStyleItem1.Edit = this.repositoryItemRichEditStyleEdit1;
            this.changeStyleItem1.Id = 46;
            this.changeStyleItem1.Name = "changeStyleItem1";
            // 
            // repositoryItemRichEditStyleEdit1
            // 
            this.repositoryItemRichEditStyleEdit1.AutoHeight = false;
            this.repositoryItemRichEditStyleEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRichEditStyleEdit1.Control = this.richEditControl;
            this.repositoryItemRichEditStyleEdit1.Name = "repositoryItemRichEditStyleEdit1";
            // 
            // showEditStyleFormItem1
            // 
            this.showEditStyleFormItem1.Id = 47;
            this.showEditStyleFormItem1.Name = "showEditStyleFormItem1";
            // 
            // editingBar1
            // 
            this.editingBar1.Control = this.richEditControl;
            this.editingBar1.DockCol = 2;
            this.editingBar1.DockRow = 0;
            this.editingBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.editingBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.findItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "FD", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.replaceItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "R", "")});
            // 
            // findItem1
            // 
            this.findItem1.Id = 48;
            this.findItem1.Name = "findItem1";
            // 
            // replaceItem1
            // 
            this.replaceItem1.Id = 49;
            this.replaceItem1.Name = "replaceItem1";
            // 
            // insertPageBreakItem21
            // 
            this.insertPageBreakItem21.Id = 50;
            this.insertPageBreakItem21.Name = "insertPageBreakItem21";
            // 
            // tablesBar1
            // 
            this.tablesBar1.Control = this.richEditControl;
            this.tablesBar1.DockCol = 1;
            this.tablesBar1.DockRow = 1;
            this.tablesBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.tablesBar1.FloatLocation = new System.Drawing.Point(856, 561);
            this.tablesBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.insertTableItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "T", "")});
            this.tablesBar1.Offset = 368;
            // 
            // insertTableItem1
            // 
            this.insertTableItem1.Id = 51;
            this.insertTableItem1.Name = "insertTableItem1";
            // 
            // illustrationsBar1
            // 
            this.illustrationsBar1.Control = this.richEditControl;
            this.illustrationsBar1.DockCol = 2;
            this.illustrationsBar1.DockRow = 1;
            this.illustrationsBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.illustrationsBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.insertPictureItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "P", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.insertFloatingPictureItem1)});
            this.illustrationsBar1.Offset = 480;
            // 
            // insertPictureItem1
            // 
            this.insertPictureItem1.Id = 52;
            this.insertPictureItem1.Name = "insertPictureItem1";
            // 
            // insertFloatingPictureItem1
            // 
            this.insertFloatingPictureItem1.Id = 53;
            this.insertFloatingPictureItem1.Name = "insertFloatingPictureItem1";
            // 
            // linksBar1
            // 
            this.linksBar1.Control = this.richEditControl;
            this.linksBar1.DockCol = 4;
            this.linksBar1.DockRow = 1;
            this.linksBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.linksBar1.FloatLocation = new System.Drawing.Point(928, 522);
            this.linksBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.insertBookmarkItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "K", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.insertHyperlinkItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "I", "")});
            this.linksBar1.Offset = 784;
            // 
            // insertBookmarkItem1
            // 
            this.insertBookmarkItem1.Id = 54;
            this.insertBookmarkItem1.Name = "insertBookmarkItem1";
            // 
            // insertHyperlinkItem1
            // 
            this.insertHyperlinkItem1.Id = 55;
            this.insertHyperlinkItem1.Name = "insertHyperlinkItem1";
            // 
            // editPageHeaderItem1
            // 
            this.editPageHeaderItem1.Id = 56;
            this.editPageHeaderItem1.Name = "editPageHeaderItem1";
            // 
            // editPageFooterItem1
            // 
            this.editPageFooterItem1.Id = 57;
            this.editPageFooterItem1.Name = "editPageFooterItem1";
            // 
            // insertPageNumberItem1
            // 
            this.insertPageNumberItem1.Id = 58;
            this.insertPageNumberItem1.Name = "insertPageNumberItem1";
            // 
            // insertPageCountItem1
            // 
            this.insertPageCountItem1.Id = 59;
            this.insertPageCountItem1.Name = "insertPageCountItem1";
            // 
            // insertTextBoxItem1
            // 
            this.insertTextBoxItem1.Id = 60;
            this.insertTextBoxItem1.Name = "insertTextBoxItem1";
            // 
            // symbolsBar1
            // 
            this.symbolsBar1.Control = this.richEditControl;
            this.symbolsBar1.DockCol = 3;
            this.symbolsBar1.DockRow = 1;
            this.symbolsBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.symbolsBar1.FloatLocation = new System.Drawing.Point(876, 561);
            this.symbolsBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.insertSymbolItem1, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "U", "")});
            this.symbolsBar1.Offset = 673;
            // 
            // insertSymbolItem1
            // 
            this.insertSymbolItem1.Id = 61;
            this.insertSymbolItem1.Name = "insertSymbolItem1";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(850, 62);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 68);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Size = new System.Drawing.Size(850, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(850, 62);
            this.barDockControl4.Manager = this.barManager1;
            this.barDockControl4.Size = new System.Drawing.Size(0, 6);
            // 
            // richEditBarController1
            // 
            this.richEditBarController1.BarItems.Add(this.pasteItem1);
            this.richEditBarController1.BarItems.Add(this.cutItem1);
            this.richEditBarController1.BarItems.Add(this.copyItem1);
            this.richEditBarController1.BarItems.Add(this.pasteSpecialItem1);
            this.richEditBarController1.BarItems.Add(this.changeFontNameItem1);
            this.richEditBarController1.BarItems.Add(this.changeFontSizeItem1);
            this.richEditBarController1.BarItems.Add(this.fontSizeIncreaseItem1);
            this.richEditBarController1.BarItems.Add(this.fontSizeDecreaseItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontBoldItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontItalicItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontUnderlineItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontDoubleUnderlineItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontStrikeoutItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontDoubleStrikeoutItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontSuperscriptItem1);
            this.richEditBarController1.BarItems.Add(this.toggleFontSubscriptItem1);
            this.richEditBarController1.BarItems.Add(this.changeFontColorItem1);
            this.richEditBarController1.BarItems.Add(this.changeFontHighlightColorItem1);
            this.richEditBarController1.BarItems.Add(this.changeTextCaseItem1);
            this.richEditBarController1.BarItems.Add(this.makeTextUpperCaseItem1);
            this.richEditBarController1.BarItems.Add(this.makeTextLowerCaseItem1);
            this.richEditBarController1.BarItems.Add(this.capitalizeEachWordCaseItem1);
            this.richEditBarController1.BarItems.Add(this.toggleTextCaseItem1);
            this.richEditBarController1.BarItems.Add(this.clearFormattingItem1);
            this.richEditBarController1.BarItems.Add(this.showFontFormItem1);
            this.richEditBarController1.BarItems.Add(this.toggleBulletedListItem1);
            this.richEditBarController1.BarItems.Add(this.toggleNumberingListItem1);
            this.richEditBarController1.BarItems.Add(this.toggleMultiLevelListItem1);
            this.richEditBarController1.BarItems.Add(this.decreaseIndentItem1);
            this.richEditBarController1.BarItems.Add(this.increaseIndentItem1);
            this.richEditBarController1.BarItems.Add(this.toggleParagraphAlignmentLeftItem1);
            this.richEditBarController1.BarItems.Add(this.toggleParagraphAlignmentCenterItem1);
            this.richEditBarController1.BarItems.Add(this.toggleParagraphAlignmentRightItem1);
            this.richEditBarController1.BarItems.Add(this.toggleParagraphAlignmentJustifyItem1);
            this.richEditBarController1.BarItems.Add(this.toggleShowWhitespaceItem1);
            this.richEditBarController1.BarItems.Add(this.changeParagraphLineSpacingItem1);
            this.richEditBarController1.BarItems.Add(this.setSingleParagraphSpacingItem1);
            this.richEditBarController1.BarItems.Add(this.setSesquialteralParagraphSpacingItem1);
            this.richEditBarController1.BarItems.Add(this.setDoubleParagraphSpacingItem1);
            this.richEditBarController1.BarItems.Add(this.showLineSpacingFormItem1);
            this.richEditBarController1.BarItems.Add(this.addSpacingBeforeParagraphItem1);
            this.richEditBarController1.BarItems.Add(this.removeSpacingBeforeParagraphItem1);
            this.richEditBarController1.BarItems.Add(this.addSpacingAfterParagraphItem1);
            this.richEditBarController1.BarItems.Add(this.removeSpacingAfterParagraphItem1);
            this.richEditBarController1.BarItems.Add(this.changeParagraphBackColorItem1);
            this.richEditBarController1.BarItems.Add(this.showParagraphFormItem1);
            this.richEditBarController1.BarItems.Add(this.changeStyleItem1);
            this.richEditBarController1.BarItems.Add(this.showEditStyleFormItem1);
            this.richEditBarController1.BarItems.Add(this.findItem1);
            this.richEditBarController1.BarItems.Add(this.replaceItem1);
            this.richEditBarController1.BarItems.Add(this.insertPageBreakItem21);
            this.richEditBarController1.BarItems.Add(this.insertTableItem1);
            this.richEditBarController1.BarItems.Add(this.insertPictureItem1);
            this.richEditBarController1.BarItems.Add(this.insertFloatingPictureItem1);
            this.richEditBarController1.BarItems.Add(this.insertBookmarkItem1);
            this.richEditBarController1.BarItems.Add(this.insertHyperlinkItem1);
            this.richEditBarController1.BarItems.Add(this.editPageHeaderItem1);
            this.richEditBarController1.BarItems.Add(this.editPageFooterItem1);
            this.richEditBarController1.BarItems.Add(this.insertPageNumberItem1);
            this.richEditBarController1.BarItems.Add(this.insertPageCountItem1);
            this.richEditBarController1.BarItems.Add(this.insertTextBoxItem1);
            this.richEditBarController1.BarItems.Add(this.insertSymbolItem1);
            this.richEditBarController1.Control = this.richEditControl;
            // 
            // DMEAB100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(862, 567);
            this.Controls.Add(this.popupContainerControl);
            this.Controls.Add(this.fld_dgcMEEmrAbbrevs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMEAB100";
            this.Text = "Danh sách từ viết tắt";
            this.Controls.SetChildIndex(this.fld_dgcMEEmrAbbrevs, 0);
            this.Controls.SetChildIndex(this.popupContainerControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrAbbrevs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPopup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl)).EndInit();
            this.popupContainerControl.ResumeLayout(false);
            this.xtraUserControl1.ResumeLayout(false);
            this.xtraUserControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion
        public DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit riPopup;
        private MEEmrAbbrevsGridControl fld_dgcMEEmrAbbrevs;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrImages;
        private IContainer components;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl;
        private DevExpress.XtraEditors.XtraUserControl xtraUserControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraRichEdit.UI.ClipboardBar clipboardBar1;
        private DevExpress.XtraRichEdit.UI.PasteItem pasteItem1;
        private DevExpress.XtraRichEdit.UI.CutItem cutItem1;
        private DevExpress.XtraRichEdit.UI.CopyItem copyItem1;
        private DevExpress.XtraRichEdit.UI.PasteSpecialItem pasteSpecialItem1;
        private DevExpress.XtraRichEdit.UI.FontBar fontBar1;
        private DevExpress.XtraRichEdit.UI.ChangeFontNameItem changeFontNameItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraRichEdit.UI.ChangeFontSizeItem changeFontSizeItem1;
        private DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit repositoryItemRichEditFontSizeEdit1;
        private DevExpress.XtraRichEdit.UI.FontSizeIncreaseItem fontSizeIncreaseItem1;
        private DevExpress.XtraRichEdit.UI.FontSizeDecreaseItem fontSizeDecreaseItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontBoldItem toggleFontBoldItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontItalicItem toggleFontItalicItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontUnderlineItem toggleFontUnderlineItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontDoubleUnderlineItem toggleFontDoubleUnderlineItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontStrikeoutItem toggleFontStrikeoutItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontDoubleStrikeoutItem toggleFontDoubleStrikeoutItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontSuperscriptItem toggleFontSuperscriptItem1;
        private DevExpress.XtraRichEdit.UI.ToggleFontSubscriptItem toggleFontSubscriptItem1;
        private DevExpress.XtraRichEdit.UI.ChangeFontColorItem changeFontColorItem1;
        private DevExpress.XtraRichEdit.UI.ChangeFontHighlightColorItem changeFontHighlightColorItem1;
        private DevExpress.XtraRichEdit.UI.ChangeTextCaseItem changeTextCaseItem1;
        private DevExpress.XtraRichEdit.UI.MakeTextUpperCaseItem makeTextUpperCaseItem1;
        private DevExpress.XtraRichEdit.UI.MakeTextLowerCaseItem makeTextLowerCaseItem1;
        private DevExpress.XtraRichEdit.UI.CapitalizeEachWordCaseItem capitalizeEachWordCaseItem1;
        private DevExpress.XtraRichEdit.UI.ToggleTextCaseItem toggleTextCaseItem1;
        private DevExpress.XtraRichEdit.UI.ClearFormattingItem clearFormattingItem1;
        private DevExpress.XtraRichEdit.UI.ShowFontFormItem showFontFormItem1;
        private DevExpress.XtraRichEdit.UI.ParagraphBar paragraphBar1;
        private DevExpress.XtraRichEdit.UI.ToggleBulletedListItem toggleBulletedListItem1;
        private DevExpress.XtraRichEdit.UI.ToggleNumberingListItem toggleNumberingListItem1;
        private DevExpress.XtraRichEdit.UI.ToggleMultiLevelListItem toggleMultiLevelListItem1;
        private DevExpress.XtraRichEdit.UI.DecreaseIndentItem decreaseIndentItem1;
        private DevExpress.XtraRichEdit.UI.IncreaseIndentItem increaseIndentItem1;
        private DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentLeftItem toggleParagraphAlignmentLeftItem1;
        private DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentCenterItem toggleParagraphAlignmentCenterItem1;
        private DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentRightItem toggleParagraphAlignmentRightItem1;
        private DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentJustifyItem toggleParagraphAlignmentJustifyItem1;
        private DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem toggleShowWhitespaceItem1;
        private DevExpress.XtraRichEdit.UI.ChangeParagraphLineSpacingItem changeParagraphLineSpacingItem1;
        private DevExpress.XtraRichEdit.UI.SetSingleParagraphSpacingItem setSingleParagraphSpacingItem1;
        private DevExpress.XtraRichEdit.UI.SetSesquialteralParagraphSpacingItem setSesquialteralParagraphSpacingItem1;
        private DevExpress.XtraRichEdit.UI.SetDoubleParagraphSpacingItem setDoubleParagraphSpacingItem1;
        private DevExpress.XtraRichEdit.UI.ShowLineSpacingFormItem showLineSpacingFormItem1;
        private DevExpress.XtraRichEdit.UI.AddSpacingBeforeParagraphItem addSpacingBeforeParagraphItem1;
        private DevExpress.XtraRichEdit.UI.RemoveSpacingBeforeParagraphItem removeSpacingBeforeParagraphItem1;
        private DevExpress.XtraRichEdit.UI.AddSpacingAfterParagraphItem addSpacingAfterParagraphItem1;
        private DevExpress.XtraRichEdit.UI.RemoveSpacingAfterParagraphItem removeSpacingAfterParagraphItem1;
        private DevExpress.XtraRichEdit.UI.ChangeParagraphBackColorItem changeParagraphBackColorItem1;
        private DevExpress.XtraRichEdit.UI.ShowParagraphFormItem showParagraphFormItem1;
        private DevExpress.XtraRichEdit.UI.ChangeStyleItem changeStyleItem1;
        private DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit repositoryItemRichEditStyleEdit1;
        private DevExpress.XtraRichEdit.UI.ShowEditStyleFormItem showEditStyleFormItem1;
        private DevExpress.XtraRichEdit.UI.EditingBar editingBar1;
        private DevExpress.XtraRichEdit.UI.FindItem findItem1;
        private DevExpress.XtraRichEdit.UI.ReplaceItem replaceItem1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraRichEdit.UI.RichEditBarController richEditBarController1;
        private DevExpress.XtraRichEdit.UI.InsertPageBreakItem2 insertPageBreakItem21;
        private DevExpress.XtraRichEdit.UI.TablesBar tablesBar1;
        private DevExpress.XtraRichEdit.UI.InsertTableItem insertTableItem1;
        private DevExpress.XtraRichEdit.UI.IllustrationsBar illustrationsBar1;
        private DevExpress.XtraRichEdit.UI.InsertPictureItem insertPictureItem1;
        private DevExpress.XtraRichEdit.UI.InsertFloatingPictureItem insertFloatingPictureItem1;
        private DevExpress.XtraRichEdit.UI.LinksBar linksBar1;
        private DevExpress.XtraRichEdit.UI.InsertBookmarkItem insertBookmarkItem1;
        private DevExpress.XtraRichEdit.UI.InsertHyperlinkItem insertHyperlinkItem1;
        private DevExpress.XtraRichEdit.UI.EditPageHeaderItem editPageHeaderItem1;
        private DevExpress.XtraRichEdit.UI.EditPageFooterItem editPageFooterItem1;
        private DevExpress.XtraRichEdit.UI.InsertPageNumberItem insertPageNumberItem1;
        private DevExpress.XtraRichEdit.UI.InsertPageCountItem insertPageCountItem1;
        private DevExpress.XtraRichEdit.UI.InsertTextBoxItem insertTextBoxItem1;
        private DevExpress.XtraRichEdit.UI.SymbolsBar symbolsBar1;
        private DevExpress.XtraRichEdit.UI.InsertSymbolItem insertSymbolItem1;
    }
}
