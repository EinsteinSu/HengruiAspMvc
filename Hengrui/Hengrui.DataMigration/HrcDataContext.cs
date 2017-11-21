using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hengrui.DataMigration.OriginalModels;

namespace Hengrui.DataMigration
{
    public class HrcDataContext : DbContext
    {
        public HrcDataContext() : base("name=hrc")
        {

        }

        public IDbSet<Area> Areas { get; set; }

      
    }
}
