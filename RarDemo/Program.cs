using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace RarDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //解压
            //RarHelper.Unpack("d:/demo.rar", "d:/testRar/");
            RarHelper.Unpack("d:/demo.zip", "d:/testRar/");

            //压缩
            List<string> files = new List<string>() { "d:/demo.xls", "d:/demo2.xlsx" };
            RarHelper.Pack(files, "d:/abc.zip");

            //压缩
            RarHelper.Pack("d:/testRar", "d:/t.zip");
        }
    }
}
