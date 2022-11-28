using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models.ViewModels
{
    public class MedicineFormViewModel
    {

        public Medicine Medicine { get; set; }


        //Essa classe é uma view model, que contém uma referência aos objetos/models/entidades que pretendemos usar em uma View
        public ICollection<Medicine> Medicines { get; set; }

        public Lab Lab { get; set; }

        public ICollection<Lab> Labs { get; set; }

    }
}
