using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList;

namespace BOSERP.Modules.BR.BranchServer.BusinessEntities.Info
{
    public class AutoUploadChBaseModel : TreeList.IVirtualTreeListData
    {
        public int IdCommand { get; set; }
        public int IdAutoUploadChBase { get; set; }
        public string Name { get; set; }

        public bool Checked { get; set; }

        public List<AutoUploadChBaseModel> ChildrenNode = new List<AutoUploadChBaseModel>();
        public AutoUploadChBaseModel ParentNode;

        public AutoUploadChBaseModel(AutoUploadChBaseModel parent, int idCommand, string name, int idAutoUploadChBase = 0, bool check = false)
        {
            ParentNode = parent;
            IdCommand = idCommand;
            IdAutoUploadChBase = idAutoUploadChBase;
            Name = name;
            Checked = check;
            ParentNode?.ChildrenNode.Add(this);
        }

        public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            info.Children = ChildrenNode;
        }
        public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            switch (info.Column.Name)
            {
                case "Name":
                    info.CellData = Name;
                    break;
                case "IdAutoUploadCHBase":
                    info.CellData = IdAutoUploadChBase;
                    break;
                case "IdCommand":
                    info.CellData = IdCommand;
                    break;
                case "Checked":

                    info.CellData = Checked;
                    break;
            }
        }

        public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            switch (info.Column.Name)
            {
                case "Name":
                    Name = info.NewCellData.ToString();
                    break;
                case "IdAutoUploadCHBase":
                    IdAutoUploadChBase = (int)info.NewCellData;
                    break;
                case "IdCommand":
                    IdCommand = (int)info.NewCellData;
                    break;
                case "Checked":
                    Checked = (bool)info.NewCellData;
                    break;
            }

        }
    }
}
