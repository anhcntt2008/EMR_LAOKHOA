using System;
using System.Collections.Generic;
using System.Text;
using BOSLib;

namespace BOSComponent
{
    public enum RepositoryItem
    {
        RepositoryItemTextEdit,
        RepositoryItemDateEdit,
        RepositoryItemCheckEdit
    }

    public interface IBOSControl
    {
        String BOSFieldGroup { get; set;}
        String BOSFieldRelation { get; set;}
        BOSScreen Screen { get; set;}
        String BOSDataSource { get; set;}
        String BOSDataMember { get; set;}
        String BOSPropertyName { get; set;}
        String BOSComment { get; set;}
        String BOSError { get; set;}
        String BOSPrivilege { get; set;}
        String BOSDescription { get; set;}

        /// <summary>
        /// Init control's specific properties from STFieldsInfo
        /// </summary>
        void InitializeControl(STFieldsInfo objFieldInfo);

        /// <summary>
        /// Init data source, data binding and events for a control
        /// </summary>
        void InitializeControl();
    }
}
