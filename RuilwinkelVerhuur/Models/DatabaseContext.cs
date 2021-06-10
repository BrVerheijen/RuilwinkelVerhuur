using Microsoft.EntityFrameworkCore;
using RuilwinkelVerhuur.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Factuur> Factuur { get; set; }

        public DbSet<ProductNaarFactuur> ProductNaarFactuur { get; set; }
    }
}
