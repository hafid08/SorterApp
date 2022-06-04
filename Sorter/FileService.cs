using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SorterApp
{
    public class FileService : IFileService
    {
        public void Create(string fullPath, List<string> listNames)
        {
            File.WriteAllLines(fullPath, listNames.ToArray());
        }

        public List<string> Read(string fullPath)
        {
            return File.ReadLines(fullPath).ToList();
        }
    }
}
