using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.DataAccess.Models.Projects
{
    public class ProjectLevel
    {
        [Key]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Level Level { get; set; }

        public string Description { get; set; }

        public virtual User Czy { get; set; }

        public virtual Project Project { get; set; }
    }

    public enum Level
    {
        Normal,
        Middle,
        High
    }
}