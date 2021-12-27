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
        public CustomerOrderContext([NotNull]DbContextOptions<CustomerOrderContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerOrder> Orders { get; set; }
    }
}
