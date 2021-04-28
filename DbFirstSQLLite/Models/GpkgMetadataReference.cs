using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class GpkgMetadataReference
    {
        public string ReferenceScope { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public long? RowIdValue { get; set; }
        public byte[] Timestamp { get; set; }
        public long MdFileId { get; set; }
        public long? MdParentId { get; set; }

        public virtual GpkgMetadatum MdFile { get; set; }
        public virtual GpkgMetadatum MdParent { get; set; }
    }
}
