using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Formula { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public int LabId { get; set; }
        public Lab Lab { get; set; }

        public Medicine()
        {
        }

        public Medicine(int id, string title, string description, string formula, DateTime expiryDate, int amount, float price)
        {
            Id = id;
            Title = title;
            Description = description;
            Formula = formula;
            ExpiryDate = expiryDate;
            Amount = amount;
            Price = price;

        }
    }
}
