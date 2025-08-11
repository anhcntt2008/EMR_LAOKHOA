using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using BOSLib;

namespace BOSComponent
{
    public partial class BOSPanel : System.Windows.Forms.Panel, IBOSControl
    {
        #region Variables
        protected String _BOSFieldGroup;
        protected String _BOSFieldRelation;
        protected BOSScreen _screen;
        protected String _BOSComment;
        protected String _BOSDataSource;
        protected String _BOSDataMember;
        protected String _BOSError;
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

        #region Contructor
        public BOSPanel()
        {
            InitializeComponent();
        }

        public BOSPanel(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        #endregion

        #region--Initialize--
        public void InitializeControl(STFieldsInfo objFieldsInfo)
        {
            
        }

        public void InitializeControl()
        {

        }
        #endregion

    }
}
