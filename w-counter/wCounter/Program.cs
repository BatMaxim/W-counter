using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = new InputParams();
            Console.Write("Введите путь входного файла: ");
            try
            {
                inputFilePath.Path = Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return;
            }

            var words = FileReader.ReadFromFile(inputFilePath.Path);
            if (FileWriter.WriteInFile(inputFilePath.Path, words, "_MT")) Console.WriteLine("Запись выполнена");
        }
    }
}
