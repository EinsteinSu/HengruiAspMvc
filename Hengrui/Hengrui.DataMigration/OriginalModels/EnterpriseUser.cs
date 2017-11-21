using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengrui.DataMigration.OriginalModels
{
    [Table("EnterpriseUsers")]
    public class OriginalEnterpriseUser
    {
        [Key]
        public string Guid { get; set; }

        public string Code { get; set; }


        public string UserName { get; set; }

        public string Password { get; set; }

        public string Sex { get; set; }

        public string IdCard { get; set; }

        public string Tel { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string QQ { get; set; }

        public string Fb { get; set; }

        public DateTime? BirthDate { get; set; }
    }

    [Table("Proficient")]
    public class OriginalProficient
    {
        [Key]
        public string Guid { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Sex { get; set; }

        public string IdCard { get; set; }

        public string Tel { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string QQ { get; set; }

        public string Zy { get; set; }

        public string Szdw { get; set; }

        public DateTime? BirthDate { get; set; }
    }

    [Table("UserContactExtensions")]
    public class UserExtension
    {
        [Key]
        public string UserId { get; set; }

        public string Weixin { get; set; }
    }
}
