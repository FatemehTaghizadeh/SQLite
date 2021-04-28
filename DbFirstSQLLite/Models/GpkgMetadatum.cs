using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class GpkgMetadatum
    {
        public long Id { get; set; }
        public string MdScope { get; set; }
        public string MdStandardUri { get; set; }
        public string MimeType { get; set; }
        public string Metadata { get; set; }
    }
}
