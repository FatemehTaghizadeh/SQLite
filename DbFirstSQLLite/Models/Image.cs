using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class Image
    {
        public string TileId { get; set; }
        public byte[] TileData { get; set; }
    }
}
