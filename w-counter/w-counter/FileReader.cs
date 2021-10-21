using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace w_counter
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
        public static Dictionary<string, int> ReadFromFile(string path, bool useMultyThread)
        {
            var textInFile = "";
            using (StreamReader sr = new StreamReader(path))
            {
                textInFile = sr.ReadToEnd();
            }
            var type = Type.GetType("TextProcessing.TextParcer, TextProcessing");
            var method = type.GetMethod("ParceText", BindingFlags.NonPublic | BindingFlags.Static);
            var methodMT = type.GetMethod("ParceTextMultiThread", BindingFlags.Public | BindingFlags.Static);
            var obj = Activator.CreateInstance(type);
            var text = new object[] { textInFile };
            var stopWatch = new Stopwatch();
            Dictionary<string, int> words;
            if (useMultyThread)
            {
                stopWatch.Start();
                words = (Dictionary<string, int>) methodMT.Invoke(obj, text);
                stopWatch.Stop();
                ShowTime(stopWatch, "MT");
                return words;
            }
                
            stopWatch.Start();
            words = (Dictionary<string, int>) method.Invoke(obj, text);
            stopWatch.Stop();
            ShowTime(stopWatch,"Common");
            return words;
        }
    }
}
