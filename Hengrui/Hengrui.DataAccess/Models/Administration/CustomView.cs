using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengrui.DataAccess.Models.Projects
{
    public class CustomView
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public Filter Filter { get; set; }

        [ForeignKey("Filter")]
        public int FilterId { get; set; }

        public View View { get; set; }

        [ForeignKey("View")]
        public int ViewId { get; set; }
    }

    public class Filter
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Script { get; set; }

        [MaxLength(100)]
        public string Parameters { get; set; }
    }

    public class View
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Columns { get; set; }

        [MaxLength(100)]
        public string Groups { get; set; }
    }
}