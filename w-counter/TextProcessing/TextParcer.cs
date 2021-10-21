using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace TextProcessing
{
    class TextParcer
    {
        static Dictionary<string, int> ParceText(String text)
        {
            var pattern = @"([A-Za-zА-Яа-я\-`]+)";
            var words = new Dictionary<string, int>();
            foreach (var word in Regex.Matches(text, pattern))
            {
                if (words.ContainsKey(word.ToString().ToLower()))
                {
                    words[word.ToString().ToLower()]++;
                    continue;
                }
                words.Add(word.ToString().ToLower(), 1);
            }
            return words;
        }
        
        public static Dictionary<string, int> ParceTextMultiThread(String text)
        {
            var pattern = @"([A-Za-zА-Яа-я\-`]+)";
            var words = new Dictionary<string, int>();
            foreach (var word in Regex.Matches(text, pattern))
            {
                if (words.ContainsKey(word.ToString().ToLower()))
                {
                    words[word.ToString().ToLower()]++;
                    continue;
                }
                words.Add(word.ToString().ToLower(), 1);
            }
            return words;
        }

    }
}
