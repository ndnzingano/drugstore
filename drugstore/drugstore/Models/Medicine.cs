using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models
{
    public class Medicine
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Formula { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Lab { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }


        // conectando purchase record c/ cliente
        //public ICollection<PurchaseRecord> Purchases { get; set; } = new List<PurchaseRecord>();

        public Medicine() { }

        public Medicine(int id, string name, string description, string formula, DateTime expiryDate, string lab, int quantity, float price)
        {
            Id = id;
            Name = name;
            Description = description;
            Formula = formula;
            ExpiryDate = expiryDate;
            Lab = lab;
            Quantity = quantity;
            Price = price;
        }
    }
}
