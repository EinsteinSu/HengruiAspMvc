using System.ComponentModel.DataAnnotations;

namespace Hengrui.DataAccess.Models.Organization
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public Contact Contact { get; set; }
    }
}