using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hengrui.DataMigration.OriginalModels;

namespace Hengrui.DataMigration
{
    public class CommonDataContext:DbContext
    {
        public CommonDataContext() : base("name=common")
        {
            
        }

        public IDbSet<OriginalEnterpriseUser> EnterpriseUsers { get; set; }

        public IDbSet<OriginalProficient> Proficients { get; set; }

        public IDbSet<UserExtension> UserExtensions { get; set; }
    }
}
