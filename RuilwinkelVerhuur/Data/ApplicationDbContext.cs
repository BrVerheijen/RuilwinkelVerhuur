using Microsoft.EntityFrameworkCore;
using RuilwinkelVerhuur.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ProductNaarFactuur> ProductNaarFactuurTable { get; set; }
        public DbSet<Factuur> FactuurTable { get; set; }
    }
}
