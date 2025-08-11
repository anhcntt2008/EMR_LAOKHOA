using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSLib;

namespace BOSComponent
{
    public partial class BOSRadioGroup : DevExpress.XtraEditors.RadioGroup, IBOSControl
    {
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

        public BOSScreen Screen { get; set; }

        [Category("BOS")]
        public String BOSFieldGroup { get; set; }

        [Category("BOS")]
        public String BOSFieldRelation { get; set; }

        [Category("BOS")]
        public String BOSComment { get; set; }

        [Category("BOS")]
        public String BOSDataSource { get; set; }

        [Category("BOS")]
        public String BOSDataMember { get; set; }

        [Category("BOS")]
        public String BOSError { get; set; }

        [Category("BOS")]
        public String BOSPropertyName { get; set; }

        [Category("BOS")]
        public String BOSPrivilege { get; set; }

        [Category("BOS")]
        public String BOSDescription { get; set; }
        #endregion

        #region Constructor
        public BOSRadioGroup()
        {
            InitializeComponent();
        }

        public BOSRadioGroup(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region Initialize
        public void InitializeControl(STFieldsInfo objFieldsInfo)
        {

        }

        public void InitializeControl()
        {
            if (!String.IsNullOrEmpty(this.BOSDataSource) && !String.IsNullOrEmpty(this.BOSDataMember))
                ((BOSScreen)Screen).BindingDataControl(this);
            this.KeyUp += new KeyEventHandler(((IBaseModuleERP)Screen.Module).Control_KeyUp);
        }
        #endregion
    }
}
