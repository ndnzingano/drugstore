using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using drugstore.Models;

namespace drugstore.Data
{
    public class drugstoreContext : DbContext
    {
        public drugstoreContext (DbContextOptions<drugstoreContext> options)
            : base(options)
        {
        }

        public DbSet<drugstore.Models.Client> Client { get; set; }
        public DbSet<drugstore.Models.Medicine> Medicine { get; set; }
        public DbSet<drugstore.Models.Lab> Lab { get; set; }


    }
}
