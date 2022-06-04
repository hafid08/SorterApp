using System;
using System.Collections.Generic;
using System.Text;

namespace SorterApp
{
    public class SortingService
    {
        public Dictionary<string, string> DicListNames { get; set; }
        public List<string> LastNames { get; set; }
        public SortingService(List<string> listNames)
        {
            DicListNames = new Dictionary<string, string>();
            LastNames = new List<string>();
            foreach (string name in listNames)
            {
                string lastName = name[(name.LastIndexOf(' ') + 1)..];
                LastNames.Add(lastName);
                DicListNames.Add(lastName, name);
            }
        }
        public List<string> GetAscByLastName()
        {
            LastNames.Sort();
            List<string> sortedNames = new List<string>();
            foreach (string lastName in LastNames)
            {
                sortedNames.Add(DicListNames[lastName]);
            }
            return sortedNames;
        }

    }
}
