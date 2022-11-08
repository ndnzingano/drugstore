using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Models
{
    public class ShoppingList
    {
        public string Id { get; set; }
        public Medicine Medicine { get; set; }

        public int Amount { get; set; }
    }
}
