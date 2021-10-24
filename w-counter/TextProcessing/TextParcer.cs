using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TextProcessing
{
    class TextParcer
    {
        static MatchCollection parcedText;
        private static ConcurrentDictionary<string, int> wordsMT = new ConcurrentDictionary<string, int>();
        static object locker = new object(); 
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

        static void ParceTextPart(Bound bound)
        {
            for (int i = bound.start; i < bound.end; i++)
            {
                wordsMT.AddOrUpdate(parcedText[i].ToString().ToLower(), 1, (key, val) => val + 1);
            }
        }
        static List<Bound> GetBounds(int size)
        {
            var bounds = new List<Bound>();
            var partSize = (int)Math.Ceiling((double)size/4);
            for (int i = 0; i < 4; i++)
            {
                bounds.Add(new Bound()
                {
                    start = i*partSize,
                    end = size > i*partSize + partSize - 1 ? i*partSize + partSize - 1 : size - 1
                });
            }
            return bounds;
        }
        
        public static Dictionary<string, int> ParceTextMultiThread(String text)
        {
           
            var pattern = @"([A-Za-zА-Яа-я\-`]+)";
            parcedText = Regex.Matches(text, pattern);
            var bounds = GetBounds(parcedText.Count);
            Parallel.Invoke(()=>ParceTextPart(bounds[0]),
                                        ()=>ParceTextPart(bounds[1]),
                                        ()=>ParceTextPart(bounds[2]),
                                        ()=>ParceTextPart(bounds[3]));
           
            var words = new Dictionary<string, int>(wordsMT);
            return words;
        }

    }
}
