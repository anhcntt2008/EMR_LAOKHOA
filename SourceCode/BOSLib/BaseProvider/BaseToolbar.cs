using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using Localization;

namespace BOSLib
{
    public class BaseToolbar
    {
        #region "Define constant toolbar"
        public const String ToolbarAction = "Action";
        public const String ToolbarUtility = "Utility";
        public const String ToolbarExtra = "Extra";
        public const String ToolbarInfo = "Info";
        public const String ToolbarWorkflow = "Workflow";
        public const String ToolbarAdmin = "Admin";
        #endregion

        #region "Define constant toolbar button"
        public const String ToolbarButtonHome = "Home";
        public const String ToolbarButtonNew = "New";
        public const String ToolbarButtonEdit = "Edit";
        public const String ToolbarButtonDelete = "Delete";
        public const String ToolbarButtonCancel = "Cancel";
        public const String ToolbarButtonSave = "Save";        
        public const String ToolbarButtonDuplicate = "Duplicate";
        public const String ToolbarButtonCopy = "Copy";
        public const String ToolbarButtonEditTemplate = "EditTemplate";
        public const String ToolbarButtonComplete = "Complete";

        public const String ToolbarButtonImport = "Import";
        public const String ToolbarButtonExport = "Export";
        public const String ToolbarButtonPrint = "Print";
        public const String ToolbarButtonError = "Error";

        public const String ToolbarButtonScreenLanguage = "ScreenLanguage";
        public const String ToolbarButtonScreenColorConfiguration = "ScreenColor";
        public const String ToolbarButtonCustomize = "Customize";

        public const String ToolbarButtonUserAudit = "UserAudit";
        public const String ToolbarButtonInformation = "Information";
        public const String ToolbarButtonHistory = "History";
        public const String ToolbarButtonPrevious = "Previous";
        public const String ToolbarButtonNext = "Next";
        public const String ToolbarButtonHide = "Hide";

        public const String ToolbarButtonPost = "Post";
        public const string ToolbarButtonAccounting = "Accounting";
        public const string ToolbarButtonTransfer = "Transfer";
        #endregion

        #region "Define constant of Modus Action for toolbar Action"
        public const String ModusNew = "New";
        public const String ModusEdit = "Edit";
        public const String ModusNone = "None";
        #endregion
        /// <summary>
        /// List of all objects 
        /// </summary>
        public DataSet ObjectCollection;
        /// <summary>
        /// Current Index in list objects
        /// </summary>
        public int CurrentIndex;
        ///// <summary>
        ///// Define action edit is New.
        ///// </summary>
        //public bool isNew;
        /// <summary>
        /// Define action modus of toolbar
        /// </summary>
        public String ModusAction;

        public BaseToolbar()
        {
            //Set modus action of toolbar to none
            ModusAction = ModusNone;
        }

        /// <summary>
        /// Set object list of toolbar,init Current Index
        /// </summary>
        /// <param name="ds"></param>
        public virtual void SetToolbar(DataSet ds)
        {
            ObjectCollection = ds;
            if (ObjectCollection.Tables.Count > 0)
            {                
                ObjectCollection.Tables[0].PrimaryKey = new DataColumn[] { ObjectCollection.Tables[0].Columns[0] };
                if (ObjectCollection.Tables[0].Rows.Count > 0)
                    CurrentIndex = 0;
            }
            CurrentIndex = 0;

        }

        /// <summary>
        /// Get Current Index base on Object ID
        /// </summary>
        /// <param name="iObjectID">Object ID</param>
        /// <returns>index of Object in the list</returns>
        public virtual int GetCurrentIndex(int iObjectID)
        {
            DataRow row = ObjectCollection.Tables[0].Rows.Find(iObjectID);
            return ObjectCollection.Tables[0].Rows.IndexOf(row);
        }

        /// <summary>
        /// Get Current Index base on current Row
        /// </summary>
        /// <param name="currentRow">Current Row</param>
        /// <returns></returns>
        public virtual int GetCurrentIndex(DataRow currentRow)
        {
            return ObjectCollection.Tables[0].Rows.IndexOf(currentRow);
        }

        /// <summary>
        /// Get Current Object ID 
        /// </summary>
        public int CurrentObjectID
        {
            get
            {
                try
                {
                    return ObjectCollection != null ? Convert.ToInt32(ObjectCollection.Tables[0].Rows[CurrentIndex][0]) : 0;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Get total objects in object list
        /// </summary>
        public int ObjectCollectionLength
        {
            get { return ObjectCollection.Tables[0].Rows.Count; }
        }

        /// <summary>
        /// Check the toolbar action is none action or null
        /// </summary>
        /// <returns>true if is none action or null, otherwise return false</returns>
        public bool IsNullOrNoneAction()
        {
            bool result = true;
            if (ModusAction == ModusEdit || ModusAction == ModusNew)
                result = false;
            return result;
        }

        public bool IsNewAction()
        {
            bool result = true;
            if (IsNullOrNoneAction())
                result = false;
            else
            {
                if (ModusAction != ModusNew)
                    return false;
            }

            return result;
        }

        public bool IsEditAction()
        {
            bool result = true;
            if (IsNullOrNoneAction())
                result = false;
            else
            {
                if (ModusAction != ModusEdit)
                    return false;
            }

            return result;
        }

        #region "Action Toolbar"
        /// <summary>
        /// Function will be called if New Event is raised
        /// </summary>
        public virtual void New()
        {
            //isNew = true;
            ModusAction = ModusNew;
            NewEvent();
        }
        
        /// <summary>
        /// Function will be called if Edit event is raised
        /// </summary>
        /// <returns></returns>
        public virtual bool Edit()
        {
            if (ObjectCollection != null)
            {
                if (ObjectCollection.Tables[0].Rows.Count > 0 && CurrentIndex >= 0)
                {
                    ModusAction = ModusEdit;
                    InvalidateEvent(CurrentObjectID);              
                    return true;
                }
                else
                {
                    MessageBox.Show(CommonLocalizedResources.ChooseObjectToEditMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(CommonLocalizedResources.ChooseObjectToEditMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        /// <summary>
        /// Function will be called if cancel event is raised
        /// </summary>
        public virtual void Cancel()
        {            
            if (ObjectCollection != null)
            {
                if(CurrentObjectID>0)
                    InvalidateEvent(CurrentObjectID);
            }
            //isNew = false;
            ModusAction = ModusNone;
        }

        /// <summary>
        /// Function will be called if Save Event is raised
        /// </summary>
        /// <returns></returns>
        public virtual int Save()
        {
            int iObjectID = SaveEvent();
            //isNew = false;
            //ModusAction = ModusNone;
            return iObjectID;
        }

        /// <summary>
        /// Function will be called if Delete event is raised
        /// </summary>
        public virtual void Delete()
        {
            if (DeleteEvent(CurrentObjectID))
            {
                if (CurrentIndex > 0)
                {
                    CurrentIndex--;
                    InvalidateEvent(CurrentObjectID);
                }


            }
            ModusAction = ModusNone;

        }

        /// <summary>
        /// Function will be called if Invalidate event is raised
        /// </summary>
        public virtual void Invalidate()
        {
            InvalidateEvent(CurrentObjectID);
        }

        /// <summary>
        /// Go next object
        /// </summary>
        public virtual void Next()
        {
            if (IsNullOrNoneAction())
            {
                if (ObjectCollectionLength > 0)
                {

                    if (CurrentIndex < ObjectCollectionLength - 1)
                        CurrentIndex++;
                    InvalidateEvent(CurrentObjectID);
                }
            }
            else
            {
                MessageBox.Show(CommonLocalizedResources.CannotMoveMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Go to previous object
        /// </summary>
        public virtual void Previous()
        {
            if (IsNullOrNoneAction())
            {
                if (ObjectCollectionLength > 0)
                {
                    if (CurrentIndex > 0)
                        CurrentIndex--;
                    InvalidateEvent(CurrentObjectID);
                }
            }
            else
            {
                MessageBox.Show(CommonLocalizedResources.CannotMoveMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Go first object
        /// </summary>
        public virtual void First()
        {
            if (IsNullOrNoneAction())
            {
                if (ObjectCollectionLength > 0)
                {
                    CurrentIndex = 0;
                    InvalidateEvent(CurrentObjectID);
                }
            }
            else
            {
                MessageBox.Show(CommonLocalizedResources.CannotMoveMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Print function.Will be called if print event is raised
        /// </summary>
        public virtual void Print()
        {
            PrintEvent();
        }

        public delegate void InvalidateHandler(int iObjectID);
        public delegate void NewHandler();
        public delegate bool DeleteHandler(int iObjectID);
        public delegate int SaveHandler();
        public delegate void PrintHandler();

        public event InvalidateHandler InvalidateEvent;
        public event NewHandler NewEvent;
        public event DeleteHandler DeleteEvent;
        public event SaveHandler SaveEvent;
        public event PrintHandler PrintEvent;

        #endregion



    }
}
