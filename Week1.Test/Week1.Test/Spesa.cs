using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test
{
    public enum Categoria
    {
        Viaggio,
        Vitto,
        Alloggio,
        Altro
    }
    public class Spesa
    {
        public DateTime DataS { get; set; }
        public Categoria Categoria { get; set; }
        public string Descrizione { get; set; }
        public double Importo { get; set; }
        public string LivelloApprovazione { get; set; }
        public double Rimborso { get; set; }
        public static Spesa LoadFromFile(string fileName)
        {
            try
            {
                Spesa spesa = new Spesa();
                using (StreamReader reader = File.OpenText(@"C:\Users\laura.pennetta\Desktop\Academy.WEEK1" + fileName))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string instanceData = reader.ReadLine();
                        string[] dataSpesa = instanceData.Split(";");
                        DateTime.TryParse(dataSpesa[0], out DateTime data);
                        spesa.DataS = data;
                        Categoria.TryParse(dataSpesa[1], out Categoria cat);
                        spesa.Categoria = cat;
                        spesa.Descrizione = dataSpesa[2];
                        double.TryParse(dataSpesa[3], out double importo);
                        spesa.Importo = importo;
                    }
                }
                return spesa;
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public static void SaveToFile(Spesa item)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(@"C:\Users\laura.pennetta\Desktop\Academy.WEEK1" + @"\spese_elaborate.txt"))
                {
                    writer.WriteLine($"Spesa:{item.DataS};{item.Categoria};{item.Descrizione};APPROVATA;{item.LivelloApprovazione};{item.Rimborso}") ;
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public override string ToString()
        {
            return $"Data: {DataS} - Categoria: {Categoria} - Descrizione: {Descrizione} - Importo: {Importo}";
        }
    }
}
