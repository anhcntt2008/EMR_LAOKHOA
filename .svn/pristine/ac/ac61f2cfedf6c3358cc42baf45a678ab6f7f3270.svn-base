using BOSLib;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOSComponent
{
    public class MultiColCheckedComboBoxEdit : PopupContainerEdit, IBOSControl
    {
        #region Variables
        protected String _BOSFieldGroup;
        protected String _BOSFieldRelation;
        protected BOSScreen _screen;
        protected String _BOSComment;
        protected String _BOSError;
        protected String _BOSDataSource;
        protected String _BOSDataMember;
        protected String _BOSPropertyName;
        protected String _BOSPrivilege;
        protected String _BOSDescription;
        protected String _valueField;
        protected String _displayField;
        protected String _quickLookupField;
        #endregion

        #region Public Properties
        [Category("Design")]
        [Browsable(true)]
        public new String Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                base.Name = value;
            }
        }

        public BOSScreen Screen
        {
            get { return _screen; }
            set { _screen = value; }
        }

        [Category("BOS")]
        public String BOSFieldGroup
        {
            get
            {
                return _BOSFieldGroup;
            }
            set
            {
                _BOSFieldGroup = value;
            }
        }

        [Category("BOS")]
        public String BOSFieldRelation
        {
            get
            {
                return _BOSFieldRelation;
            }
            set
            {
                _BOSFieldRelation = value;
            }
        }

        [Category("BOS")]
        public String BOSComment
        {
            get
            {
                return _BOSComment;
            }
            set
            {
                _BOSComment = value;
            }
        }

        [Category("BOS")]
        public String BOSError
        {
            get
            {
                return _BOSError;
            }
            set
            {
                _BOSError = value;
            }
        }

        [Category("BOS")]
        public String BOSDataSource
        {
            get
            {
                return _BOSDataSource;
            }
            set
            {
                _BOSDataSource = value;
            }
        }

        [Category("BOS")]
        public String BOSDataMember
        {
            get
            {
                return _BOSDataMember;
            }
            set
            {
                _BOSDataMember = value;
            }
        }

        [Category("BOS")]
        public String BOSPropertyName
        {
            get
            {
                return _BOSPropertyName;
            }
            set
            {
                _BOSPropertyName = value;
            }
        }

        [Category("BOS")]
        public String BOSPrivilege
        {
            get
            {
                return _BOSPrivilege;
            }
            set
            {
                _BOSPrivilege = value;
            }
        }


        [Category("BOS")]
        public String BOSDescription
        {
            get
            {
                return _BOSDescription;
            }
            set
            {
                _BOSDescription = value;
            }
        }
        public String DisplayField
        {
            get
            {
                return _displayField;
            }
            set
            {
                _displayField = value;
            }
        }
        public String ValueField
        {
            get
            {
                return _valueField;
            }
            set
            {
                _valueField = value;
            }
        }
        /// <summary>
        /// field for lookup when typing and enter
        /// </summary>
        public String QuickLookupField
        {
            get
            {
                return _quickLookupField;
            }
            set
            {
                _quickLookupField = value;
            }
        }
        public object DataSource
        {
            get
            {
                return this._gridControl.DataSource;
            }
        }
        #endregion
        #region Constructor
        public MultiColCheckedComboBoxEdit()
        {
            InitializeComponent();
            Size = new Size(150, 20);
            KeyDown += new KeyEventHandler(Event_KeyDown);
        }

        private void Event_KeyDown(object sender, KeyEventArgs e)
        {
            var control = (PopupContainerEdit)sender;
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(control.Text))
                {
                    var tb = this._gridControl.DataSource as DataTable;
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        if (tb.Rows[i][this._quickLookupField].ToString() == control.Text)
                        {
                            this.EditValue = tb.Rows[i][this._valueField];
                            break;
                        }
                    }
                }
            }
        }

        public MultiColCheckedComboBoxEdit(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Size = new Size(150, 20);
            KeyDown += new KeyEventHandler(Event_KeyDown);
        }


        void Event_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            e.Value = this._tokenEdit.EditValue;
        }

        void Event_QueryDisplayText(object sender, DevExpress.XtraEditors.Controls.QueryDisplayTextEventArgs e)
        {
            var tb = this._gridControl.DataSource as DataTable;
            var values = this.EditValue?.ToString().Split(',');
            if (values == null) return;
            values = values.Select(t => t.Trim()).ToArray();
            var texts = new List<string>();
            foreach (DataRow row in tb.Rows)
            {
                if (values.Contains(row[this._valueField].ToString()))
                    texts.Add(row[this._displayField].ToString());
            }
            e.DisplayText = string.Join(", ", texts);
        }
        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private GridView _gridView;
        private ComboGridControl _gridControl;
        private PopupContainerControl _popupContainerControl;
        private SortedList LookupTables;
        private TokenEdit _tokenEdit;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        #region--Initialize--
        public void InitializeControl(STFieldsInfo objFieldInfo)
        {
            this.Properties.TextEditStyle = (DevExpress.XtraEditors.Controls.TextEditStyles)Enum.Parse(typeof(DevExpress.XtraEditors.Controls.TextEditStyles), objFieldInfo.STFieldTextEditStyle);

        }

        public void InitializeControl()
        {
            if (!String.IsNullOrEmpty(BOSDataSource))
            {
                this._popupContainerControl = new DevExpress.XtraEditors.PopupContainerControl
                {
                    Location = new Point(233, 87),
                    Name = this.Name + "PopupContainerControl",
                    Size = new Size(400, 500),
                    TabIndex = 1
                };
                InitGridControl();
                InitTokenEdit();

                this.Screen.Controls.Add(this._popupContainerControl);
                this.Properties.PopupControl = this._popupContainerControl;
                this.QueryDisplayText += new DevExpress.XtraEditors.Controls.QueryDisplayTextEventHandler(Event_QueryDisplayText);
                this.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(Event_QueryResultValue);
            }
        }
        private void InitGridControl()
        {
            this._gridControl = new ComboGridControl
            {
                AllowDrop = true,
                //Dock = DockStyle.Fill,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right))),
                BOSComment = _BOSComment,
                BOSDataMember = _BOSDataMember,
                BOSDataSource = _BOSDataSource,
                BOSDescription = null,
                BOSError = null,
                BOSFieldGroup = "",
                BOSFieldRelation = "",
                BOSGridType = null,
                BOSPrivilege = "",
                BOSPropertyName = "",
                Font = new System.Drawing.Font("Tahoma", 8.25F),
                Location = new Point(0, 70),
                MainView = this._gridView,
                Name = this.Name + "GridControl",
                PrintReport = false,
                Screen = this.Screen,
                Size = new System.Drawing.Size(this._popupContainerControl.Width, this._popupContainerControl.Height - 70),
                TabIndex = 1000000003,
                Tag = this.Tag
            };

            this._gridControl.SelfInitializeControl();
            this._gridView = (GridView)this._gridControl.MainView;
            this._gridView.OptionsSelection.MultiSelect = true;
            this._gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            this._gridView.OptionsView.ColumnAutoWidth = false;
            this._gridView.OptionsCustomization.AllowFilter = true;
            this._gridView.OptionsView.ShowAutoFilterRow = true;
            this._gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 5;
            this._gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(GridView_SelectionChanged);
            this._gridView.ColumnFilterChanged += new EventHandler(GridView_ColumnFilterChanged);
            if (string.IsNullOrEmpty(this._quickLookupField))
            {
                this._quickLookupField = _BOSDataSource.Substring(0, _BOSDataSource.Length - 1) + "No";
            }

            DataTable tb = GetLookupTable();
            this._gridControl.DataSource = tb;
            this._gridControl.RefreshDataSource();

            this._gridControl.Layout += GridControl_Layout;

            this._popupContainerControl.Controls.Add(this._gridControl);
        }

        private void GridView_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (this._tokenEdit.EditValue != null)
            {
                SetEditValue(this._tokenEdit.EditValue?.ToString());
            }
        }

        private DataTable GetLookupTable()
        {
            LookupTables = ((IBaseModuleERP)Screen.Module).GetLookupTableCollection();
            var ds = LookupTables[this.BOSDataSource];
            if (ds == null)
            {
                ds = ((IBaseModuleERP)Screen.Module).InitLookupByTable(this.BOSDataSource);
            }
            var tb = (ds as System.Data.DataSet).Tables[0];
            return tb;
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_gridView_SelectionChangedHandle) return;

            var values = new List<string>();
            if (e.ControllerRow < 0)
            {
                if (_gridView.SelectedRowsCount == _dataSourceRowCount)
                {
                    var tb = this._gridControl.DataSource as DataTable;
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        values.Add(tb.Rows[i][this._valueField].ToString());
                    }
                    this._tokenEdit.EditValue = string.Join(",", values);
                    return;
                }
                else if (_gridView.SelectedRowsCount == 0 && _dataSourceRowCount == _gridView.RowCount)
                {
                    this._tokenEdit.EditValue = string.Empty;
                    return;
                }
            }

            var item = _gridView.GetDataRow(e.ControllerRow) as DataRow;
            if (item == null) return;
            var valStr = this._tokenEdit.EditValue?.ToString();
            values = string.IsNullOrEmpty(valStr) ? new List<string>() : valStr.Split(',').Select(t => t.Trim()).ToList();
            var val = item[this._valueField].ToString();
            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    values.Add(val);
                    break;
                case CollectionChangeAction.Remove:
                    values.Remove(val);
                    break;
                case CollectionChangeAction.Refresh:
                    break;
                default:
                    break;
            }
            values = values.Distinct().ToList();
            this._tokenEdit.EditValue = string.Join(",", values);
        }

        private void InitTokenEdit()
        {
            this._tokenEdit = new TokenEdit
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right))),
                Location = new Point(0, 0),
                Name = this.Name + "TokenEdit",
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder,
                Size = new System.Drawing.Size(this._popupContainerControl.Width, 20),
            };
            this._tokenEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this._tokenEdit.Properties.Appearance.Options.UseBackColor = true;
            this._tokenEdit.Properties.Appearance.Options.UseTextOptions = true;
            this._tokenEdit.Properties.AutoHeightMode = DevExpress.XtraEditors.TokenEditAutoHeightMode.Default;
            this._tokenEdit.Properties.DeleteTokenOnGlyphClick = DevExpress.Utils.DefaultBoolean.True;
            this._tokenEdit.Properties.MaxExpandLines = 4;
            this._tokenEdit.Properties.Separators.AddRange(new string[] { "," });
            this._tokenEdit.Properties.TokenAdded += new DevExpress.XtraEditors.TokenEditTokenAddedEventHandler(this.TokenEdit_Properties_TokenAdded);
            this._tokenEdit.Properties.TokenRemoved += new DevExpress.XtraEditors.TokenEditTokenRemovedEventHandler(this.TokenEdit_Properties_TokenRemoved);
            this._tokenEdit.Properties.EditValueChanged += new EventHandler(this.TokenEdit_Properties_EditValueChanged);

            DataTable tb = GetLookupTable();
            _dataSourceRowCount = tb.Rows.Count;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                var val = tb.Rows[i][this._valueField].ToString();
                this._tokenEdit.Properties.Tokens.Add(new TokenEditToken(tb.Rows[i][this._displayField].ToString(), val));
            }
            this._popupContainerControl.Controls.Add(this._tokenEdit);
        }

        private void TokenEdit_Properties_EditValueChanged(object sender, EventArgs e)
        {
            //var control = (TokenEdit)sender;
            //if (control.Height > this._popupContainerControl.Height / 2)
            //    control.Height = this._popupContainerControl.Height / 2;
            //this._gridControl.Size = new Size(this._popupContainerControl.Width, this._popupContainerControl.Height - control.Height);
            //this._gridControl.Location = new Point(0, control.Height);
        }

        private void TokenEdit_Properties_TokenRemoved(object sender, TokenEditTokenRemovedEventArgs e)
        {
            for (int i = 0; i < _gridView.RowCount; i++)
            {
                var row = _gridView.GetDataRow(i);
                var val = row[this._valueField].ToString();
                if (e.Token.Value?.ToString() == val)
                {
                    this._gridView.UnselectRow(i);
                    return;
                }
            }
        }
        private void TokenEdit_Properties_TokenAdded(object sender, TokenEditTokenAddedEventArgs e)
        {
            // throw new NotImplementedException();
        }
        #endregion
        private bool _gridView_SelectionChangedHandle = true;
        private int _dataSourceRowCount;

        public void SetEditValue(string editValue)
        {
            _gridView_SelectionChangedHandle = false;
            var values = editValue?.ToString().Split(',');
            if (values == null) return;
            values = values.Select(t => t.Trim()).ToArray();
            this._gridView.ClearSelection();
            var tb = this._gridControl.DataSource as DataTable;
            var validValues = new List<string>();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                var val = tb.Rows[i][this._valueField].ToString();
                if (values.Contains(val))
                {
                    int handle = this._gridView.GetRowHandle(i);
                    //this._gridView.SelectRow(handle);
                    this._gridView.EnsureRowLoaded(handle, (arguments) => View_RowLoadedOperationCompleted(handle));
                    validValues.Add(val);
                }
            }
            this._tokenEdit.EditValue = string.Join(",", validValues);
            _gridView_SelectionChangedHandle = true;
        }
        private void View_RowLoadedOperationCompleted(int handle)
        {
            if (this._gridView != null && handle >= 0)
            {
                if (this._gridView.IsRowLoaded(handle))
                {
                    this._gridView.SelectRow(handle);
                }
            }
        }
        private void GridControl_Layout(object sender, LayoutEventArgs e)
        {
            var control = (Control)sender;
            // https://trello.com/c/dSBAjlTE
            // BUG - Tìm kiếm bệnh án theo Khoa: Khoa mặc định không được Chọn khi bấm vào danh sách Khoa lần đầu tiên
            if (control.InvokeRequired)
                BeginInvoke(new Action(() =>
                {
                    SetEditValue(this._tokenEdit.EditValue?.ToString());
                }));
            else
                SetEditValue(this._tokenEdit.EditValue?.ToString());

            this._gridControl.Layout -= GridControl_Layout;
        }
        public override object EditValue
        {
            get => base.EditValue;
            set
            {
                if (value != base.EditValue)
                {
                    SetEditValue(value?.ToString());
                    base.EditValue = value;
                }
            }
        }
    }
}
