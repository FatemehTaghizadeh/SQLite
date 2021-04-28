using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class GpkgSpatialRefSy
    {
        public GpkgSpatialRefSy()
        {
            GpkgContents = new HashSet<GpkgContent>();
            GpkgGeometryColumns = new HashSet<GpkgGeometryColumn>();
            GpkgTileMatricesSet = new HashSet<GpkgTileMatrixSet>();
        }

        public string SrsName { get; set; }
        public long SrsId { get; set; }
        public string Organization { get; set; }
        public long OrganizationCoordsysId { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GpkgContent> GpkgContents { get; set; }
        public virtual ICollection<GpkgGeometryColumn> GpkgGeometryColumns { get; set; }
        public virtual ICollection<GpkgTileMatrixSet> GpkgTileMatricesSet { get; set; }
    }
}
