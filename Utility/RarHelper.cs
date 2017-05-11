using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utility
{
    public class RarHelper
    {
        /// <summary>
        /// 可以是rar、zip文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dir"></param>
        public static void Unpack(string filePath, string dir)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        reader.WriteEntryToDirectory(dir, new ExtractionOptions { ExtractFullPath = true, Overwrite = true });
                    }
                }
            }
        }
        
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="files"></param>
        /// <param name="saveFile"></param>
        public static void Pack(List<string> files,string saveFile)
        {
            using (var archive = ZipArchive.Create())
            {
                foreach (var item in files)
                {
                    FileInfo info = new FileInfo(item);
                    archive.AddEntry(info.Name, info.OpenRead(), true, info.Length, new DateTime?(info.LastWriteTime));
                }                
                archive.SaveTo(saveFile, CompressionType.Deflate);
            }
        }

        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="files"></param>
        /// <param name="saveFile"></param>
        public static void Pack(string dir,string saveFile)
        {
            using (var archive = ZipArchive.Create())
            {
                archive.AddAllFromDirectory(dir);
                archive.SaveTo(saveFile, CompressionType.Deflate);
            }
        }
    }
}
