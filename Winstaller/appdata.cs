using System;
using System.Collections.Generic;
using System.Text;

namespace Winstaller.appdata
{
    public class Appdata
    {
        public string name { get; set; }
        public string path { get; set; }

        public string version { get; set; }
        public string atname { get; set; }
        public string atdes { get; set; }
        public List<string> atalhos { get; set; } = new List<string>();
        
    };
}
