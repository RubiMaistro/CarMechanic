using CarMechanic_Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace CarMechanic_Server.Repositories
{
    public class CustomerOrderContext : DbContext
    {
        public DbSet<CustomerOrder> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=CarRepairMechanicDb;Integrated Security=True;");
        } 
    }
}
