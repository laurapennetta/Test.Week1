using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test
{
    public class ManagerHandler : AbstractHandler
    {
        public override string Handle(Spesa spesa)
        {
            if (spesa.Importo <= 400)
            {
                IRimborso selectedRimborso = RimborsoFactory.GetRimborso(spesa);
                if (selectedRimborso != null)
                {
                    Console.WriteLine();
                    selectedRimborso.ValoreRimborso(spesa);
                }
                spesa.LivelloApprovazione = "Manager";
                return $"Importo approvato dal Manager";
            }
            else
            {
                return base.Handle(spesa);
            }
        }
    }
}
