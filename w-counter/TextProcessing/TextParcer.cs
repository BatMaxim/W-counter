using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextProcessing
{
    class TextParcer
    {
        public static Dictionary<string, int> ParceText(String text)
        {
            var pattern = @"([A-Za-zА-Яа-я\-`]+)";

            var words = new Dictionary<string, int>();
            Console.Write(text);
            return words;
        }

    }
}
