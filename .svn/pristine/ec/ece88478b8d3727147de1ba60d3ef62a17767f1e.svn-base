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
    public partial class BOSButton : DevExpress.XtraEditors.SimpleButton, IBOSControl
    {
        #region Variables
        protected String _BOSFieldGroup;
        protected String _BOSFieldRelation;
        protected BOSScreen _screen;
        protected String _BOSDataSource;
        protected String _BOSDataMember;
        protected String _BOSPropertyName;
        protected String _BOSComment;
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
        public BOSButton()
        {
            InitializeComponent();

            Size = new Size(75, 27);
        }

        public BOSButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Size = new Size(75, 27);
        }
        #endregion

        #region--Initialize--
        public void InitializeControl(STFieldsInfo objFieldInfo)
        {

        }

        public void InitializeControl()
        {
            this.KeyUp += new KeyEventHandler(((IBaseModuleERP)Screen.Module).Control_KeyUp);
        }
        #endregion
    }
}
