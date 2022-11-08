using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models
{
    public class Client
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }

        // conectando purchase record c/ cliente
        public ICollection<PurchaseRecord> Purchases { get; set; } = new List<PurchaseRecord>();

        public Client() { }

        public Client(int id, string name, string telephone, string address, ICollection<PurchaseRecord> purchases)
        {
            Id = id;
            Name = name;
            Telephone = telephone;
            Address = address;
            Purchases = purchases;
        }
    }
}
