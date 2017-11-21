using System.ComponentModel.DataAnnotations.Schema;

namespace Hengrui.DataAccess.Models.Organization.Users
{
    public class EnterpriseUser : User
    {
        public EnterpriseUser()
        {
            Type = UserType.Enterprise;
        }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}