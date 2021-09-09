using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace w_counter
{
    class FileReader
    {
        public static Dictionary<string, int> ReadFromFile(string path)
        {
            var pattern = @"([A-Za-zА-Яа-я\-`]+)";
            using var streamReader = new StreamReader(path);
            var line = String.Empty;
            var words = new Dictionary<string, int>();
            while ((line = streamReader.ReadLine()) != null)
            {
                foreach (var word in Regex.Matches(line, pattern))
                {
                    if (words.ContainsKey(word.ToString().ToLower()))
                        words[word.ToString().ToLower()]++;
                    else
                        words.Add(word.ToString().ToLower(), 1);
                }
            }
            return words;
        }
    }
}
