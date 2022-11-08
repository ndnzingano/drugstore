using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models
{
    public class PurchaseRecord
    {

        public int Id { get; set; }
        public ShoppingList ShoppingList { get; set; }

        // conectando cliente c/ compras
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }

        public PurchaseRecord() { }

        public PurchaseRecord(int id, ShoppingList shoppingList, Client client, DateTime date, double total)
        {
            Id = id;
            ShoppingList = shoppingList;
            Client = client;
            Date = date;
            Total = total;
        }
    }
}
