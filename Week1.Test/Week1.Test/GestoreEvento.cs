using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test
{
    public class GestoreEvento
    {
        public static void HandleNewTextFile(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Un nuovo file è stato appena creato {0}", e.Name);
            Console.WriteLine();
            try
            {
                using (StreamReader reader = File.OpenText(e.FullPath))
                {
                    Console.WriteLine($"Contenuto del file {e.Name}:");
                    Console.WriteLine();
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = reader.ReadLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Fine del file");
                    Console.WriteLine();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
