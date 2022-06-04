using System;
using System.Collections.Generic;
using System.Text;

namespace SorterApp
{
    public class MockFile
    {
        private readonly string _path;
        private readonly IFileService _service;
        public MockFile(string path, IFileService service)
        {
            _path = path;
            _service = service;
        }
        public IEnumerable<string> ListNames { get; private set; }
        public double Id { get; private set; }
        public void RefreshRead()
        {
            ListNames = _service.Read(_path);
        }
    }
}
