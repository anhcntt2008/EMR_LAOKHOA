using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using System.Collections;

using System.Windows.Forms;

namespace BOSLib
{
    public class ModuleEntities
    {
        #region variables
        /// <summary>
        /// Variable define module which ModuleEntities belong to
        /// </summary>
        private BaseModule _module;

        /// <summary>
        /// Variable define Current Object
        /// </summary>
        public BusinessObject CurrentObject;

        /// <summary>
        /// Variable define module objects
        /// </summary>
        public BusinessObjectCollection CurrentModuleObjects;

        /// <summary>
        /// Variable define BindingSource of Current Object
        /// </summary>
        public BindingSource CurrentObjectBindingSource;

        /// <summary>
        /// Variable define BindingSource collection of module objects
        /// </summary>
        public BindingSourceCollection CurrentModuleObjectsBindingSource;
        /// <summary>
        /// Variable define Error Provider binding to Current Object
        /// </summary>
        public ErrorProvider CurrentObjectErrorProvider;
        /// <summary>
        /// Variable define error provider collection binding to module objects collection
        /// </summary>
        public ErrorProviderCollection CurrentModuleObjectErrorProviders;               

        #endregion

        #region Public Properties
        public BaseModule Module
        {
            get
            {
                return _module;
            }
            set
            {
                _module = value;
            }
        }
        #endregion

        public virtual void InitCurrentObject()
        {           
        }

        
        /// <summary type="Initialize">
        /// Initialize Module Objects
        /// </summary>
        public virtual void InitCurrentModuleObjects()
        {
           
        }

        /// <summary type="Initialize">
        /// Initialize Current Object Binding Source
        /// </summary>
        public virtual void InitCurrentObjectBindingSource()
        {
            CurrentObjectBindingSource.DataSource = CurrentObject.GetType();
        }

        /// <summary type="Initialize">
        /// Initialize Module Objects Binding Source
        /// </summary>
        public virtual void InitCurrentModuleObjectsBindingSource()
        {
            try
            {
                foreach (DictionaryEntry de in CurrentModuleObjects)
                {
                    BindingSource bds = new BindingSource();
                    bds.DataSource = CurrentModuleObjects[de.Key.ToString()].GetType();
                    CurrentModuleObjectsBindingSource.Add(de.Key.ToString(), bds);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this.GetType().FullName + "-InitModuleObjectsBindingSource-" + e.Message);
            }
        }

      

    }
}
