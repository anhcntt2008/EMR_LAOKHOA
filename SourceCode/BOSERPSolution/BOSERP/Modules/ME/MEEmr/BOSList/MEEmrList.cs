using BOSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Base;
using System.Data;

namespace BOSERP.Modules.MEEmr
{
    public class MEEmrList<T> : BOSList<T> where T : BusinessObject, new()
    {
        public override void GridViewFocusRow(int iRowHandle)
        {
            if (GridView != null)
            {
                if (GridView.FocusedRowHandle == iRowHandle)
                {
                    if (CurrentIndex >= 0)
                    {
                        // Entity.InvalidateModuleObject((T)this[CurrentIndex].Clone());
                    }
                }
                else
                {
                    GridView.FocusedRowHandle = iRowHandle;
                }
            }
        }
        protected override void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!IsEndCurrentEdit)
            {
                if (this.Count > 0)
                {
                    if (CurrentIndex >= 0 && CurrentIndex < this.Count)
                    {
                        //Entity.InvalidateModuleObject((T)this[CurrentIndex].Clone());
                    }
                }
            }
            IsEndCurrentEdit = false;

            if (CurrentIndex < 0)
            {
                IsInputingNewRow = true;
            }
            else
            {
                IsInputingNewRow = false;
            }
        }
        /// <summary>
        /// Invalidate based on a table
        /// </summary>
        /// <param name="table">Table contains object list</param>
        public virtual void Invalidate(DataTable table)
        {
            this.Clear();

            BaseBusinessController objItemController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");

            foreach (DataRow row in table.Rows)
            {
                T objT = (T)objItemController.GetObjectFromDataRow(row);
                this.Add(objT);
            }

            //Invalidate original list same as itself
            OriginalList.Clear();
            foreach (T obj in this)
                OriginalList.Add((T)obj.Clone());

            //Invalidate backup list same as itself
            BackupList.Clear();
            foreach (T obj in this)
            {
                BackupList.Add((T)obj.Clone());
            }

            //Refresh Grid if Grid is not null
            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
                if (this.Count > 0)
                {
                    if (CurrentIndex >= 0 && CurrentIndex < Count)
                    {
                        GridViewFocusRow(CurrentIndex);
                    }
                    else
                    {
                        GridViewFocusRow(0);
                    }
                }
                else
                {
                    //Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
                }
            }
        }
        public override void Invalidate(IList<T> lst)
        {
            this.Clear();
            foreach (T obj in lst)
            {
                this.Add((T)obj.Clone());
            }

            //Invalidate original list same as itself
            OriginalList.Clear();
            foreach (T obj in this)
                OriginalList.Add((T)obj.Clone());

            //Invalidate backup list same as itself
            BackupList.Clear();
            foreach (T obj in this)
            {
                BackupList.Add((T)obj.Clone());
            }

            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
                if (this.Count > 0)
                {
                    if (CurrentIndex >= 0 && CurrentIndex < Count)
                    {
                        GridViewFocusRow(CurrentIndex);
                    }
                    else
                    {
                        GridViewFocusRow(0);
                    }
                }
                else
                {
                    //Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
                }
            }
        }
    }
}
