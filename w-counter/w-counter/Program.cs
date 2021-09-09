using System;
using System.Linq;

namespace w_counter
{
    static class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = new Path();
            inputFilePath.SetPathFromConsole("Введите путь входного файла: ", true);
            var outputFilePath = new Path();
            outputFilePath.SetPathFromConsole("Введите путь выходного файла: ");
            var words = FileReader.ReadFromFile(inputFilePath.GetPath());
            FileWriter.WriteInFile(outputFilePath.GetPath(), words);
        }
    }
}
