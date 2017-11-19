using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengrui.DataAccess.Models
{
    [ComplexType]
    public class Contact
    {
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Mobile { get; set; }

        [MaxLength(50)]
        public string WeiChat { get; set; }

        [MaxLength(20)]
        public string QQ { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
    }
}