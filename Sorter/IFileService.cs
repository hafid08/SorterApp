using System;
using System.Collections.Generic;
using System.Text;

namespace SorterApp
{
    public interface IFileService
    {
        void Create(string fullPath, List<string> listNames);
        List<string> Read(string fullPath);
    }
}
