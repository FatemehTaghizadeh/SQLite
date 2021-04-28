using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class Tile
    {
        public long? ZoomLevel { get; set; }
        public long? TileColumn { get; set; }
        public long? TileRow { get; set; }
        public byte[] TileData { get; set; }
    }
}
