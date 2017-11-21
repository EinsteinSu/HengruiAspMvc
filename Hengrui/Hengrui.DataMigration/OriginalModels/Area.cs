using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengrui.DataMigration.OriginalModels
{
    [Table("Area")]
    public class Area
    {
        [Key]
        public string Guid { get; set; }

        public string PGuid { get; set; }

        public string Name { get; set; }
    }
}
