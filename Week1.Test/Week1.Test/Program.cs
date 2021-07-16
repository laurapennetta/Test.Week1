using System;
using System.Collections.Generic;
using System.IO;

namespace Week1.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"C:\Users\laura.pennetta\Desktop\Academy.WEEK1";
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.LastWrite |
                NotifyFilters.LastAccess | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;
            fsw.EnableRaisingEvents = true;
            fsw.Created += GestoreEvento.HandleNewTextFile;
            Console.WriteLine("Premi z per uscire");
            while (Console.Read() != 'z') ;
            List<Spesa> spese = new List<Spesa>();
            string fileName = @"\spesa.txt";
            for(int i=0; i<4; i++)
            {
                Spesa spesa = Spesa.LoadFromFile(fileName);
                spese.Add(spesa);
            }
            //foreach(var item in spese)
            //{
            //    Console.WriteLine(item);
            //}
            var manager = new ManagerHandler();
            var opManager = new OperationalManagerHandler();
            var ceo = new CEOHandler();
            manager.SetNext(opManager).SetNext(ceo);
            foreach (var item in spese)
            {
                Console.WriteLine();
                var result = manager.Handle(item);
                if (result != null)
                {
                    Console.WriteLine($"{result}");
                    Spesa.SaveToFile(item);
                }
                else
                {
                    Console.WriteLine($"L'importo non è stato approvato");
                }
            }

        }
    }
}
