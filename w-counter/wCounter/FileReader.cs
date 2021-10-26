using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace wCounter
{
    static class FileReader
    {
        public static Dictionary<string, int> ReadFromFile(string path)
        {
            var textInFile = "";
            using (StreamReader sr = new StreamReader(path))
                textInFile = sr.ReadToEnd();

            Dictionary<string, int> words;
            using (var client = new ServiceReference1.Service1Client())
                words = client.GetData(textInFile);
              
            return words;
        }
    }
}
