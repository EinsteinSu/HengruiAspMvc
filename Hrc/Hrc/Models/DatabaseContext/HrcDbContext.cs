using System.Data.Entity;
using Hrc.Models.Commons;

namespace Hrc.Models.DatabaseContext
{
    public class HrcDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Parameter> Parameters { get; set; }
    }
}