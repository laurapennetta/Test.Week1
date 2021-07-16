using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test
{
    public class CEOHandler : AbstractHandler
    {
        public override string Handle(Spesa spesa)
        {
            if (spesa.Importo > 1000 && spesa.Importo <= 2500)
            {
                IRimborso selectedRimborso = RimborsoFactory.GetRimborso(spesa);
                if (selectedRimborso != null)
                {
                    Console.WriteLine();
                    selectedRimborso.ValoreRimborso(spesa);
                }
                spesa.LivelloApprovazione = "CEO";
                return $"Importo approvato dal CEO";
            }
            else
            {
                return base.Handle(spesa);
            }
        }
    }
}
