using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace w_counter
{
    class FileWriter
    {
        public static bool WriteInFile(string path, Dictionary<string, int> words)
        {
            var newPath = GenerateFilePath(path);
            using var streamWriter = new StreamWriter(newPath);
            foreach (var item in words.OrderByDescending(item => item.Value))
            {
                streamWriter.WriteLine($"{item.Key} - {item.Value}");
            }
            return true;
        }
        static string GenerateFilePath(string path)
        {
            var mainPath = path.Remove(path.LastIndexOf("."));
            var NameMode = DateTime.Now.ToString("yyyyMMddHHmmss");
            return $"{mainPath}_{NameMode}.txt" ;
        }
    }
}
