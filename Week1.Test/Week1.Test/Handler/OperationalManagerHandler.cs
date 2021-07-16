using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test
{
    public class OperationalManagerHandler : AbstractHandler
    {
        public override string Handle(Spesa spesa)
        {
            if (spesa.Importo > 400 && spesa.Importo <= 1000)
            {
                IRimborso selectedRimborso = RimborsoFactory.GetRimborso(spesa);
                if (selectedRimborso != null)
                {
                    Console.WriteLine();
                    selectedRimborso.ValoreRimborso(spesa);
                }
                spesa.LivelloApprovazione = "Operational Manager";
                return $"Importo approvato dall'Operational Manager";
            }
            else
            {
                return base.Handle(spesa);
            }
        }
    }
}
