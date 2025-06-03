using Microsoft.EntityFrameworkCore;
using Angular_App.Models;
using System.Collections.Generic;

namespace Angular_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<HireRequest> HireRequests { get; set; }

        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<CallRequest> CallRequests { get; set; }

        public DbSet<ContactForm> ContactForms { get; set; }


    }
}
