using BOSCommon;
using BOSERP.Utilities;
using BOSLib;
using Clas.Business.Ftp;
using DevExpress.XtraPdfViewer;
using Emr.Ca.Core;
using Emr.Document.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOSERP.Modules.ME.Helpers
{
    public class EmrDocumentSortHelper
    {
        public List<MEEmrDocumentsInfo> SortDocumentTree(List<MEEmrDocumentsInfo> listDocs, MEEmrsInfo emr)
        {
            var orderedDocs = new List<MEEmrDocumentsInfo>();
            // sap sep nhom theo thu tu da cau hinh cua nhom
            var groups = listDocs.GroupBy(d => d.MEEmrDocumentGroup,
                (group, docs) => new
                {
                    Group = group,
                    Docs = docs.ToArray(),
                    Order = (docs.Sum(d => d.MEEmrDocumentOrder) / docs.Count())
                }).OrderBy(g => g.Order).ToArray();

            foreach (var group in groups)
            {
                var config = AppMemCache.GetTemplateIndexFromDictKeyName(group.Group, emr.FK_MEEmrTypeID);
                var docWithoutRefs = group.Docs.Where(d => string.IsNullOrEmpty(d.MEEmrDocumentRefNo));
                var docWithRefs = group.Docs.Where(d => !string.IsNullOrEmpty(d.MEEmrDocumentRefNo)).OrderByDescending(d => d.MEEmrDocumentRefNo.Length);

                var subGroups = docWithRefs.GroupBy(d => d.MEEmrDocumentRefNo,
                    (sub, docs) => new
                    {
                        SubGroup = sub,
                        // trong cung 1 group thi sap sep theo thu tu tang dan
                        Docs = docs.OrderBy(s => s.MEEmrDocumentCreatedDate).ToArray(),
                        MinDate = docs.Min(d => d.MEEmrDocumentCreatedDate)
                    },
                    //mot to chi dinh co the co nhieu so phieu ket qua
                    new ContainsEqualityComparer()).ToArray();
                var dateList = docWithoutRefs.Select(d => d.MEEmrDocumentCreatedDate).Union(subGroups.Select(s => s.MinDate)).Distinct();
                if (config != null && config.METemplateIndexDesc)
                {
                    dateList = dateList.OrderByDescending(d => d).ToArray();
                }
                else
                {
                    dateList = dateList.OrderBy(d => d).ToArray();
                }
                foreach (var date in dateList)
                {
                    orderedDocs.AddRange(docWithoutRefs.Where(d => d.MEEmrDocumentCreatedDate == date).ToArray());
                    foreach (var subGroup in subGroups.Where(d => d.MinDate == date))
                    {
                        orderedDocs.AddRange(subGroup.Docs);
                    }
                }
            }
            return orderedDocs;
        }
    }
}
