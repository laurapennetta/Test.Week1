using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test
{
    public class RimborsoFactory
    {
        public static IRimborso GetRimborso(Spesa spesa)
        {
            IRimborso rimborso = null;

            if (spesa.Categoria.Equals("Viaggio"))
            {
                rimborso = new RimborsoViaggio();
            }
            if (spesa.Categoria.Equals("Alloggio"))
            {
                rimborso = new RimborsoAlloggio();
            }
            if (spesa.Categoria.Equals("Vitto"))
            {
                rimborso = new RimborsoVitto();
            }
            if (spesa.Categoria.Equals("Altro"))
            {
                rimborso = new RimborsoAltro();
            }
            return rimborso;
        }
    }
}
