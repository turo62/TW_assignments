using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanity_Archiver
{
    class Compressor
    {
        readonly static DirectoryInfo homeDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + "Archive");
        internal SanityArchiver actArchiver = new SanityArchiver();

        internal static void CompressFile(FileInfo fileName)
        {
            DirectoryInfo actArchive = SetActArchiveDir(fileName.FullName);
            Directory.SetCurrentDirectory(actArchive.FullName);
            Console.WriteLine(actArchive.ToString());

            //int dotIndex = fileName.ToString().LastIndexOf('.');

            FileStream inStream = fileName.OpenRead();
            FileStream outStream = File.Create(fileName.ToString() + ".gz");
            GZipStream gZIP = new GZipStream(outStream, CompressionMode.Compress);

            int b = inStream.ReadByte();

            while (b != -1)
            {
                gZIP.WriteByte((byte)b);
                b = inStream.ReadByte();
            }

            gZIP.Close(); outStream.Close(); inStream.Close();
        }

        internal static void DecompressFile(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
                    }
                }
            }
        }

        private static DirectoryInfo SetActArchiveDir(string fileName)
        {
            string tempDir = Path.GetFullPath(fileName).Substring(3);
            Console.WriteLine(tempDir);
            int tempIndex = tempDir.LastIndexOf(@"\");
            Console.WriteLine(tempIndex);
            DirectoryInfo pathToFile = new DirectoryInfo(tempDir.Substring(0, tempIndex));
            Console.WriteLine(pathToFile);

            foreach (DirectoryInfo actDir in homeDir.GetDirectories())
            {
                if (actDir.Equals(pathToFile))
                {
                    Console.WriteLine(actDir.ToString());
                    return actDir;
                }
            }

            DirectoryInfo actArchive = Directory.CreateDirectory(homeDir.ToString() + @"\" + pathToFile.ToString());

            Console.WriteLine(actArchive.ToString());

            return actArchive;
        }
    }
}
