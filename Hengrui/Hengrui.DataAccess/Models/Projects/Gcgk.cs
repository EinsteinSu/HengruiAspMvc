using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Hengrui.DataAccess.Models.Projects
{
    public class Gcgk
    {
        public int Id { get; set; }
        public int Xh { get; set; }

        [MaxLength(300)]
        public string Dh { get; set; }

        public decimal Gcgm
        {
            get { return Gcgks.Sum(s => s.Gcgm); }
        }

        public string Jzgn => string.Join("、", Gcgks);

        [MaxLength(100)]
        public string Jgxs { get; set; }

        [MaxLength(20)]
        public string Jzcs { get; set; }

        [MaxLength(20)]
        public string Jzgd { get; set; }

        [MaxLength(20)]
        public string Nhdj { get; set; }

        public virtual Jzfl Jzfl { get; set; }

        public string Wxxfl { get; set; }

        public virtual ICollection<Gcgk> Gcgks { get; set; }

        public virtual Project Project { get; set; }
    }

    public class GcgkDetails
    {
        [Required]
        public decimal Gcgm { get; set; }

        [MaxLength(50)]
        [Required]
        public string Jzgn { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        public virtual Gcgk ProjectGcgk { get; set; }
    }

    public class Jzfl
    {
        [ScaffoldColumn(false)]
        [Key]
        public int Id { get; set; }

        [Required]
        public int PId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}