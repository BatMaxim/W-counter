using System;
using System.Linq;


namespace w_counter
{
    static class Program
    {
        
        static void Main(string[] args)
        {
            var inputFilePath = new InputParams();
            Console.Write("Введите путь входного файла: ");
            try
            {
                inputFilePath.Path = Console.ReadLine();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                return;
            }

            var words = FileReader.ReadFromFile(inputFilePath.Path, true);
            if(FileWriter.WriteInFile(inputFilePath.Path, words)) Console.WriteLine("Запись выполнена");
            words = FileReader.ReadFromFile(inputFilePath.Path, false);
            if(FileWriter.WriteInFile(inputFilePath.Path, words)) Console.WriteLine("Запись выполнена");
        }
    }
}
