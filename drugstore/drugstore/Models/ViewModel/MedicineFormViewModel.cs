using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models.ViewModels
{
    public class MedicineFormViewModel
    {

        public Medicine Medicine { get; set; }

        public ICollection<Lab> Labs { get; set; }

    }
}
