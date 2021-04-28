using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class GpkgTileMatrix
    {
        public string TableName { get; set; }
        public long ZoomLevel { get; set; }
        public long MatrixWidth { get; set; }
        public long MatrixHeight { get; set; }
        public long TileWidth { get; set; }
        public long TileHeight { get; set; }
        public double PixelXSize { get; set; }
        public double PixelYSize { get; set; }

        public virtual GpkgContent TableNameNavigation { get; set; }
    }
}
