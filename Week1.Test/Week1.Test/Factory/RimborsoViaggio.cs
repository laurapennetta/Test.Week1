using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test
{
    public class RimborsoViaggio : IRimborso
    {
        public void ValoreRimborso(Spesa spesa)
        {
            spesa.Rimborso = spesa.Importo + 50;
            Console.WriteLine($"Rimborso pari a: {spesa.Rimborso} euro");
        }
    }
}
