using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        [Display(Name = "Medicine Name")]
        [Required(ErrorMessage = "Required Field")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 characters"), MaxLength(35, ErrorMessage = "Name must be less than 35 characters")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Required Field")]
        public string Description { get; set; }

        [Display(Name = "Active Ingredients")]
        [Required(ErrorMessage = "Required Field")]
        public string Formula { get; set; }

        [Display(Name = "Best By")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required Field")]

        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public double Price { get; set; }

        [Display(Name = "Lab")]
        [Required(ErrorMessage = "Required Field")]
        public int LabId { get; set; }

        public Lab Lab { get; set; }

        public Medicine()
        {
        }

        public Medicine(int id, string title, string description, string formula, DateTime expiryDate, int amount, double price)
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
