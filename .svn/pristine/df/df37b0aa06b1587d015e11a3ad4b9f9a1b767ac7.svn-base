using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BOSBase;
using BOSCommon;
using BOSLib;
using Clas.Business.Doctor24x7;
using Clas.Model.Doctor24x7;
using Clas.Repository.HttpApi;
using Localization;
using Clas.Emr.Intergration;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using Emr.Base.Models.Abp;

namespace BOSERP
{
    public partial class guiDevide : BOSERPScreen
    {
        public string Devide;
        public guiDevide()
        {
            InitializeComponent();
        }

        private void guiDevide_Load(object sender, EventArgs e)
        {

        }

        private void fld_btnDesktop_Click(object sender, EventArgs e)
        {
            Devide = BOSCommon.Devide.Desktop;
            Dispose();
        }

        private void fld_btnTablet_Click(object sender, EventArgs e)
        {
            Devide = BOSCommon.Devide.Tablet;
            Dispose();
        }
    }
}