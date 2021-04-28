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
            /*var ImgName = new Image();
            var i = dbcontext.Images.FirstOrDefault(i => i.TileId.Equals("14/10507/9917"));
            var tile_data = i.TileData;
            Console.WriteLine(tile_data);*/


            var datas = dbcontext.Images.ToList();
            string dir = @"P:\Projects\C#Projects\DbFirstSQLLite\DbFirstSQLLite\result";

            foreach (var data in datas)
            {
                string[] dir1 = data.TileId.Split('/');
                // If directory does not exist, create it
                if (!Directory.Exists(dir + "\\" + dir1[0]))
                {
                    Directory.CreateDirectory(dir + "\\" + dir1[0]);
                    CheckExit(dir + "\\" + dir1[0] + "\\" + dir1[1], dir + "\\" + dir1[0] + "\\" + dir1[1] + "\\" + dir1[2] + ".pbf", data.TileData);
                }
                else
                {
                    CheckExit(dir + "\\" + dir1[0] + "\\" + dir1[1], dir + "\\" + dir1[0] + "\\" + dir1[1] + "\\" + dir1[2] + ".pbf", data.TileData);
                }

            }
            dbcontext.SaveChanges();
        }

        private static void CheckExit(string s1, string s2, byte[] b)
        {
            if (!Directory.Exists(s1))
            {
                Directory.CreateDirectory(s1);
                WriteToFile(s2, b);
            }
            else
            {
                WriteToFile(s2, b);
            }

        }
        private static void WriteToFile(string path, byte[] data)
        {
            using (FileStream fs = File.Create(path))
            {
                fs.Write(data);
            }
        }
    }
}
