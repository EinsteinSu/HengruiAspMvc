using System.ComponentModel.DataAnnotations;

namespace Hengrui.DataAccess.Models.Projects
{
    public class Sjdw
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(200)]
        public string Sjzz { get; set; }

        public virtual Project Project { get; set; }
    }
}