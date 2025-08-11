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
    public partial class BOSDateEdit : DevExpress.XtraEditors.DateEdit, IBOSControl
    {
        #region Variables
        protected String _BOSDataSource;
        protected String _BOSFieldRelation;
        protected String _BOSDataMember;
        protected String _BOSPropertyName;
        protected String _BOSFieldGroup;
        protected String _BOSComment;
        protected BOSScreen _screen;
        protected String _BOSError;
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
            get
            {
                return _screen;
            }
            set
            {
                _screen = value;
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
        public BOSDateEdit()
        {
            InitializeComponent();

            Size = new Size(150, 20);
            Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            var pattern = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            if (pattern == "M/d/yyyy" || pattern == "MM/dd/yyyy")
                Properties.Mask.EditMask = "(0?[1-9]|1[012])/([012]?[1-9]|[123]0|31)/([123][0-9])?[0-9][0-9]";
            else
                Properties.Mask.EditMask = "([012]?[1-9]|[123]0|31)/(0?[1-9]|1[012])/([123][0-9])?[0-9][0-9]";
            Properties.Mask.ShowPlaceHolders = true;
        }

        public BOSDateEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Size = new Size(150, 20);
            Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            var pattern = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            if (pattern == "M/d/yyyy" || pattern == "MM/dd/yyyy")
                Properties.Mask.EditMask = "(0?[1-9]|1[012])/([012]?[1-9]|[123]0|31)/([123][0-9])?[0-9][0-9]";
            else
                Properties.Mask.EditMask = "([012]?[1-9]|[123]0|31)/(0?[1-9]|1[012])/([123][0-9])?[0-9][0-9]";
            Properties.Mask.ShowPlaceHolders = true;

        }
        #endregion

        #region--Initialize--
        public void InitializeControl(STFieldsInfo objFieldInfo)
        {

        }

        public void InitializeControl()
        {
            if (!String.IsNullOrEmpty(this.BOSDataSource) && !String.IsNullOrEmpty(this.BOSDataMember))
            {
                ((BOSScreen)Screen).BindingDataControl(this);
            }

            if (this.Name.Contains("SearchFrom") || this.Name.Contains("SearchTo"))
            {
                if (Tag != null && Tag.ToString() == BOSScreen.SearchControl)
                {
                    if (this.Name.Contains("SearchFrom"))
                        this.EditValue = BOSUtil.GetYearBeginDate();
                    else if (this.Name.Contains("SearchTo"))
                        this.EditValue = BOSUtil.GetYearEndDate();
                }
            }

            Properties.NullDate = DateTime.MaxValue;

            this.Click += ((IBaseModuleERP)Screen.Module).Control_Click;
            this.KeyUp += new KeyEventHandler(((IBaseModuleERP)Screen.Module).Control_KeyUp);
        }
        #endregion
    }
}
