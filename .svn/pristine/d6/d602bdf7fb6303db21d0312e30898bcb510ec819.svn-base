using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using BOSLib;

namespace BOSComponent
{
    public partial class BOSButtonEdit : DevExpress.XtraEditors.ButtonEdit, IBOSControl
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
        public BOSButtonEdit()
        {
            InitializeComponent();

            Size = new Size(150, 20);
        }

        public BOSButtonEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Size = new Size(150, 20);
        }
        #endregion

        #region--Initialize--
        public void InitializeControl(STFieldsInfo objFieldInfo)
        {
            this.Properties.ReadOnly = objFieldInfo.STFieldReadOnly;
            this.Properties.Mask.EditMask = objFieldInfo.STFieldEditMask;
            this.Properties.Mask.MaskType = (DevExpress.XtraEditors.Mask.MaskType)Enum.Parse(typeof(DevExpress.XtraEditors.Mask.MaskType), objFieldInfo.STFieldMaskType);
            this.RightToLeft = (RightToLeft)Enum.Parse(typeof(RightToLeft), objFieldInfo.STFieldRightToLeft);
            this.Properties.BorderStyle = (DevExpress.XtraEditors.Controls.BorderStyles)Enum.Parse(typeof(DevExpress.XtraEditors.Controls.BorderStyles), objFieldInfo.STFieldBorderStyle);
            //Init Character casing
            if (!String.IsNullOrEmpty(objFieldInfo.STFieldCharacterCase))
                this.Properties.CharacterCasing = (CharacterCasing)Enum.Parse(typeof(CharacterCasing), objFieldInfo.STFieldCharacterCase);
        }

        public void InitializeControl()
        {
            if (!String.IsNullOrEmpty(this.BOSDataSource) && !String.IsNullOrEmpty(this.BOSDataMember))
            {
                ((BOSScreen)Screen).BindingDataControl(this);
                if (Tag != null && Tag.Equals(BOSScreen.DataControl))
                {
                    this.EditValueChanged += new EventHandler(((IBaseModuleERP)Screen.Module).Control_EditValueChanged);
                }
            }
            this.Click += new EventHandler(((IBaseModuleERP)Screen.Module).Control_Click);

            this.KeyUp += new KeyEventHandler(((IBaseModuleERP)Screen.Module).Control_KeyUp);            
        }
        #endregion
    }
}
