using System.ComponentModel.DataAnnotations;

namespace Hrc.Models.Commons
{
    public class Parameter
    {
        [ScaffoldColumn(true)]
        public int ParameterID { get; set; }

        [Display(Name = "键")]
        [MaxLength(20), MinLength(1), Required(ErrorMessage = "键不能为空")]
        public string Key { get; set; }

        [Display(Name = "值")]
        [Required(ErrorMessage = "值不能为空")]
        public string Value { get; set; }

        [Display(Name = "说明")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}