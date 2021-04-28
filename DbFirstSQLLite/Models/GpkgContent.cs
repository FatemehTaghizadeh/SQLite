using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class GpkgContent
    {
        public GpkgContent()
        {
            GpkgTileMatrices = new HashSet<GpkgTileMatrix>();
        }

        public string TableName { get; set; }
        public string DataType { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
        public byte[] LastChange { get; set; }
        public double? MinX { get; set; }
        public double? MinY { get; set; }
        public double? MaxX { get; set; }
        public double? MaxY { get; set; }
        public long? SrsId { get; set; }

        public virtual GpkgSpatialRefSy Srs { get; set; }
        public virtual GpkgGeometryColumn GpkgGeometryColumn { get; set; }
        public virtual GpkgTileMatrixSet GpkgTileMatrixSet { get; set; }
        public virtual ICollection<GpkgTileMatrix> GpkgTileMatrices { get; set; }
    }
}
