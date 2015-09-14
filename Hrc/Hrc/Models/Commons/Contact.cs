using System.ComponentModel.DataAnnotations;

namespace Hrc.Models.Commons
{
    public class Contact
    {
        [ScaffoldColumn(true)]
        public int ContactID { get; set; }

        [Display(Name = "类型")]
        [Required(ErrorMessage = "类型不能为空")]
        public ContactType Type { get; set; }

        [Display(Name = "号码")]
        [Required(ErrorMessage = "号码不能为空")]
        public string Value { get; set; }
    }

    public enum ContactType
    {
        [Display(Name = "电话号码")]
        Phone,
        [Display(Name = "手机号码")]
        Mobile,
        [Display(Name = "微信")]
        Weixin,
        QQ,
        [Display(Name = "邮箱")]
        Email
    }
}