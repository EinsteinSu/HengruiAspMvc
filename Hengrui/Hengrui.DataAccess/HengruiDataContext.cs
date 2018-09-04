using System.Data.Entity;
using Hengrui.DataAccess.Models.Organization;
using Hengrui.DataAccess.Models.Organization.Users;
using Hengrui.DataAccess.Models.Projects;

namespace Hengrui.DataAccess
{
    public class HengruiDataContext : DbContext
    {
        public HengruiDataContext()
            : base("Hengrui")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Project> Projects { get; set; }

        public IDbSet<EnterpriseUser> EnterpriseUsers { get; set; }

        public IDbSet<Department> Departments { get; set; }

        public IDbSet<Proficient> Proficients { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Region> Regions { get; set; }

        public IDbSet<Branch> Branches { get; set; }

        public IDbSet<View> Views { get; set; }

        public IDbSet<Filter> Filters { get; set; }

        public IDbSet<CustomView> CustomViews { get; set; }
    }
}