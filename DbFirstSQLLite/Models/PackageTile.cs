using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class PackageTile
    {
        public long? Id { get; set; }
        public long? ZoomLevel { get; set; }
        public long? TileColumn { get; set; }
        public byte[] TileRow { get; set; }
        public byte[] TileData { get; set; }
    }
}
