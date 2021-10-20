using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;


namespace w_counter
{
    class FileReader
    {
        public static Dictionary<string, int> ReadFromFile(string path)
        {
            var textInFile = "";
            using (StreamReader sr = new StreamReader(path))
            {
                textInFile = sr.ReadToEnd();
            }
            var type = Type.GetType("TextProcessing.TextParcer, TextProcessing");
            var method = type.GetMethod("ParceText", BindingFlags.NonPublic | BindingFlags.Static);
            var obj = Activator.CreateInstance(type);
            var text = new object[] { textInFile };
            var words = (Dictionary<string, int>) method.Invoke(obj, text);
            return words;
        }
    }
}
