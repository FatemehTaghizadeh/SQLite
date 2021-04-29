using DbFirstSQLLite.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace DbFirstSQLLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using var dbcontext = new tehranContext();

            var datas = dbcontext.Images;
            
            
            var dir = @"P:\Projects\C#Projects\DbFirstSQLLite\DbFirstSQLLite\result";

            foreach (var data in datas)
            {
                var tileIdParts = data.TileId.Split('/');
                var dir1 = Path.Combine(dir, tileIdParts[0], tileIdParts[1]);
                // If directory does not exist, create it
                if (!Directory.Exists(dir1))
                {
                    Directory.CreateDirectory(dir1);
                }

                var filePath = Path.Combine(dir1, tileIdParts[2] + ".pbf");
                File.WriteAllBytes(filePath, data.TileData);
            }
        }
    }
}
