using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.ViewInfo;
using Clas.Emr.Core;
using BOSCommon;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiSelectRoom : BOSERPScreen
    {
        public string SelectedRoom;
        private List<string> _rooms;

        public guiSelectRoom(List<string> rooms)
        {
            this._rooms = rooms;
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);

        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            lbcRoomList.DataSource = this._rooms;
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }

        private void Ok()
        {
            SelectedRoom = lbcRoomList.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DSMEEMR106_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void DSMEEMR106_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lbcRoomList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Ok();
        }
    }
}
