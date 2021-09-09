using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace w_counter
{
    static class FileWriter
    {
        public static void WriteInFile(string path, Dictionary<string, int> words)
        {
            try
            {
                System.IO.File.Delete(path);
                using var streamWriter = new StreamWriter(path);
                foreach (var item in words.OrderByDescending(item => item.Value))
                {
                    streamWriter.WriteLine($"{item.Key} - {item.Value}");
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
