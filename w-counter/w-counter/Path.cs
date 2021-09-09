using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace w_counter
{
    class Path
    {
        string path;
        public string GetPath()
        {
            return path;
        }
        public void SetPath(string path)
        {
            this.path = path;
        }
        public void SetPathFromConsole(string message, bool check = false)
        {
            var path = String.Empty;
            while (true)
            {
                Console.Write(message);
                path = Console.ReadLine();
                if (!check || File.Exists(path))
                {
                    break;
                }
                Console.WriteLine("Нет такого файла");
            }
           
            SetPath(path);
        }
    }
}
