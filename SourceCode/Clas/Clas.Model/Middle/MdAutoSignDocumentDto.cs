using System;
using System.Collections.Generic;

namespace Clas.Model.Middle
{
    public partial class MdAutoSignDocumentDto
    {
        public MdAutoSignDocumentDto()
        {
        }
        public int ID { get; set; }
        public string STATE { get; set; }

        public string EMR_NO { get; set; }
        public string VENDOR_DOC_NO { get; set; }

        public string SIGNER { get; set; }

        public string SIGNER_PW { get; set; }

        public bool PW_ENCRYTED { get; set; }

        public string SIGNER_ROLE { get; set; }

        public DateTime SIGNED_TIME { get; set; }

        public int DOCUMENT_ID { get; set; }

        public int SIGNED_HISTORY_ID { get; set; }

        public string SIGNED_FILE { get; set; }

        public int TRY_TIMES { get; set; }

        public DateTime? LAST_TRY { get; set; }

        public string SIGNED_LOG { get; set; }
    }
}