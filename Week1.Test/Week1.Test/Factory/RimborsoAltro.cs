using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test
{
    public class RimborsoAltro : IRimborso
    {
        public void ValoreRimborso(Spesa spesa)
        {
            spesa.Rimborso = (spesa.Importo * 10) / 100;
            Console.WriteLine($"Rimborso pari a: {spesa.Rimborso} euro");
        }
    }
}
