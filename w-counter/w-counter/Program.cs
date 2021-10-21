using System;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace w_counter
{
    static class Program
    {
        static void ShowTime(Stopwatch stopWatch)
        {
            var ts = stopWatch.Elapsed;
            var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
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
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var words = FileReader.ReadFromFile(inputFilePath.Path);
            if(FileWriter.WriteInFile(inputFilePath.Path, words)) Console.WriteLine("Запись выполнена");
            stopWatch.Stop();
            ShowTime(stopWatch);
        }
    }
}
