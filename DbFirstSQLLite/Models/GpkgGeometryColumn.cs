using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class GpkgGeometryColumn
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string GeometryTypeName { get; set; }
        public long SrsId { get; set; }
        public long Z { get; set; }
        public long M { get; set; }

        public virtual GpkgSpatialRefSy Srs { get; set; }
        public virtual GpkgContent TableNameNavigation { get; set; }
    }
}
