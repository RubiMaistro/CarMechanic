using CarMechanic_Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace CarMechanic_Server.Repositories
{
    public class ClientContext : DbContext
    {
        public ClientContext([NotNull]DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
    }
}
