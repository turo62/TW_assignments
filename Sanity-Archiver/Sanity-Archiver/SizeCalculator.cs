﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanity_Archiver
{
    class SizeCalculator
    {
        internal long CalculateDirectorySize(DirectoryInfo actDirectory)
        {
            long bitCalc = 0;

            List<FileInfo> collectedFiles = new List<FileInfo>();

            RecursiveAlgorithm(collectedFiles, actDirectory);

            foreach (FileInfo tempFile in collectedFiles)
            {
                    
                bitCalc += tempFile.Length;
            }
            
            return bitCalc / (1024 * 1024);

        }
        private static bool IsAccessible(DirectoryInfo realPath)
        {
            try
            {
                realPath.GetDirectories();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private static void RecursiveAlgorithm(List<FileInfo> actFiles, DirectoryInfo actDirectory)
        {
            if (IsAccessible(actDirectory))
            {
                foreach (FileInfo item in actDirectory.GetFiles())
                {
                    if (actFiles.Contains(item))
                    { 
                        continue;
                    }
                    else
                    {
                        actFiles.Add(item);
                    }
                    
                }
            }

            foreach (DirectoryInfo tempDir in actDirectory.GetDirectories())
            {
                RecursiveAlgorithm(actFiles, tempDir);
            }
        }
    }

}
