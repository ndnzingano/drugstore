using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models
{
    public class Lab
    {
        public int Id { get; set; }

        [Display(Name = "Trading Name")]
        [Required(ErrorMessage = "Required Field")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 characters"), MaxLength(35, ErrorMessage = "Name must be less than 35 characters")]
        public string Name { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Required Field")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 characters"), MaxLength(35, ErrorMessage = "Name must be less than 35 characters")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string Address { get; set; }

        [Display(Name = "Telephone Number")]
        [Required(ErrorMessage = "Required Field")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid format.")]
        public string Email { get; set; }

        public ICollection<Medicine> Medicines = new List<Medicine>();

        public Lab()
        {
        }

        public Lab(int id, string name, string companyName, string address, string telephone, string email, ICollection<Medicine> medicines)
        {
            Id = id;
            Name = name;
            CompanyName = companyName;
            Address = address;
            Telephone = telephone;
            Email = email;
            Medicines = medicines;
        }

        public void AddMedicine(Medicine Medicine)
        {
            Medicines.Add(Medicine);
        }

       
    }
}
