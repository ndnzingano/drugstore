using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models
{
    public class Lab
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
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
