using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models.ViewModel
{
    public class LabFormViewModel
    {

        public Lab Lab { get; set; }


        //Essa classe é uma view model, que contém uma referência aos objetos/models/entidades que pretendemos usar em uma View
        public ICollection<Medicine> Medicines { get; set; }
    }
}
