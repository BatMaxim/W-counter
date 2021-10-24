using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace wCounter
{
    class FileReader
    {
        static void ShowTime(Stopwatch stopWatch, string title)
        {
            var ts = stopWatch.Elapsed;
            var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"RunTime {title} {elapsedTime}");
        }
        public static Dictionary<string, int> ReadFromFile(string path)
        {
            var textInFile = "";
            using (StreamReader sr = new StreamReader(path))
            {
                textInFile = sr.ReadToEnd();
            }
            Dictionary<string, int> words;
            using (var client = new ServiceReference1.Service1Client())
            {
                words = client.GetData(textInFile);
            }
              
            return words;
        }
    }
}
