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
            //RarHelper.Unpack("d:/demo.rar", "d:/testRar/");
            RarHelper.Unpack("d:/demo.zip", "d:/testRar/");            
        }
    }
}
