using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class GpkgTileMatrixSet
    {
        public string TableName { get; set; }
        public long SrsId { get; set; }
        public double MinX { get; set; }
        public double MinY { get; set; }
        public double MaxX { get; set; }
        public double MaxY { get; set; }

        public virtual GpkgSpatialRefSy Srs { get; set; }
        public virtual GpkgContent TableNameNavigation { get; set; }
    }
}
