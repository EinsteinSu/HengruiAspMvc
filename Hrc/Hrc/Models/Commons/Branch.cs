using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hrc.Models.Commons
{
    public class Branch
    {
        [Display(Name = "窗口编号")]
        [ScaffoldColumn(false)]
        public int BranchID { get; set; }

        [MaxLength(20)]
        [Required]
        [Display(Name = "窗口名称")]
        public string Name { get; set; }

        [MaxLength(3)]
        [Required]
        [Display(Name = "缩写")]
        public string Acronym { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "签订地点")]
        public string Qddd { get; set; }

        public virtual IList<Contact> Contact { get; set; }

        public virtual IList<Contact> FzrContact { get; set; }
    }
}