using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengrui.DataAccess.Models.Projects
{
    public class OwnerLogin
    {
        [ForeignKey("Project")]
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual Project Project { get; set; }
    }
}