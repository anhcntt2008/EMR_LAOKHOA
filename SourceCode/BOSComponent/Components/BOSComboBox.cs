using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using BOSLib;

namespace BOSComponent
{
    public partial class BOSComboBox : DevExpress.XtraEditors.ComboBoxEdit, IBOSControl
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
        #endregion

        #region Constructor
        public BOSComboBox()
        {
            InitializeComponent();

            Size = new Size(150, 20);
        }

        public BOSComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Size = new Size(150, 20);
        }
        #endregion

        #region--Initialize--
        public void InitializeControl(STFieldsInfo objFieldInfo)
        {
            this.Properties.TextEditStyle = (DevExpress.XtraEditors.Controls.TextEditStyles)Enum.Parse(typeof(DevExpress.XtraEditors.Controls.TextEditStyles), objFieldInfo.STFieldTextEditStyle);
        }

        public void InitializeControl()
        {            
            if (!String.IsNullOrEmpty(BOSDataSource) && !String.IsNullOrEmpty(BOSDataMember))
            {
                InitObjectDataToComboBox();
                if (!BOSDataSource.Equals("ADConfigValues"))
                    ((BOSScreen)Screen).BindingDataControl(this);
            }

            //Set Edit Value of Combo Box is String.Empty if FieldTag is SC
            if (Tag != null && Tag.ToString() == BOSScreen.SearchControl)
            {
                this.EditValue = String.Empty;
            }
            this.Click += new EventHandler(((IBaseModuleERP)Screen.Module).Control_Click);
            this.KeyUp += new KeyEventHandler(((IBaseModuleERP)Screen.Module).Control_KeyUp);
        }

        private void InitObjectDataToComboBox()
        {
            //ComboBox is MatchCode
            if (BOSDataMember.Contains("MatchCode"))
            {
                InitMatchCodeValueToComboBox(BOSDataMember, Tag.ToString());
            }
            else if ((BOSDataSource.Contains("ADConfigValues")))
            {
                InitComboBoxFromADConfigValues();
            }
        }

        private void InitMatchCodeValueToComboBox(String strMatchCodeColumnName, String strFieldTag)
        {
            this.Properties.Items.Clear();
            ADMatchCodesController objADMatchCodesController = new ADMatchCodesController();
            DataSet dsMatchCodeValue = objADMatchCodesController.GetADMatchCodesByADMatchCodeColumnName(strMatchCodeColumnName);
            if (dsMatchCodeValue.Tables.Count > 0)
            {
                if (dsMatchCodeValue.Tables[0].Rows.Count > 0)
                {
                    if (strFieldTag == "SC")
                        this.Properties.Items.Add("");
                    foreach (DataRow row in dsMatchCodeValue.Tables[0].Rows)
                    {
                        ADMatchCodesInfo objADMatchCodesInfo = (ADMatchCodesInfo)objADMatchCodesController.GetObjectFromDataRow(row);
                        this.Properties.Items.Add(objADMatchCodesInfo.ADMatchCodeValue);
                    }
                    if (this.Properties.Items.Count > 0)
                        this.SelectedIndex = 0;
                }
                else
                {
                    this.Properties.Buttons.Clear();
                }
            }
            dsMatchCodeValue.Dispose();
        }

        private void InitComboBoxFromADConfigValues()
        {
            if (Tag.ToString() == "SC")
                this.Properties.Items.Add("");
            String strConfigValueGroup = String.Empty;
            if (BOSDataMember.Contains("Combo"))
                strConfigValueGroup = BOSDataMember.Substring(2, BOSDataMember.Length - 7);
            else
                strConfigValueGroup = BOSDataMember.Substring(2, BOSDataMember.Length - 2);
            if (ADConfigValueUtility.ConfigValues.Tables[strConfigValueGroup] != null)
            {
                foreach (DataRow row in ADConfigValueUtility.ConfigValues.Tables[strConfigValueGroup].Rows)
                {
                    this.Properties.Items.Add(row["Text"].ToString());
                }
            }
            if (this.Properties.Items.Count > 0)
                this.SelectedIndex = 0;
            else
                this.Text = String.Empty;
        }
        #endregion
    }
}
