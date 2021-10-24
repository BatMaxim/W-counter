using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace wCounter
{
    class InputParams
    {
        string _path;
        public string Path
        {
            get { return _path; }
            set 
            {
                if(!File.Exists(value))
                    throw new ArgumentException(
                          $"'{value}' - такого файла не существует");
                _path = value; 
            }
        }
    }
}
