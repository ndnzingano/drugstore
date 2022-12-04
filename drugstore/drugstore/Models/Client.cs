using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 characters"), MaxLength(35, ErrorMessage = "Name must be less than 35 characters")]
        public string Name { get; set; }
        [Display(Name = "Telephone Number")]
        [Required(ErrorMessage = "Required Field")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Address { get; set; }
        [Display(Name = "Health Insurance")]
        [Required(ErrorMessage = "Required Field")]
        public string HealthInsurance { get; set; }

    }



}
