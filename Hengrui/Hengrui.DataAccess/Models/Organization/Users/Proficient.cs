using System.ComponentModel.DataAnnotations;

namespace Hengrui.DataAccess.Models.Organization.Users
{
    public class Proficient : User
    {
        public Proficient()
        {
            Type = UserType.Proficient;
        }

        public MajorType Zy { get; set; }

        //todo: convert to ProficientReviewRole in viewmodel
        [MaxLength(50)]
        public string Roles { get; set; }
    }

    public enum MajorType
    {
        Jz,
        Gps,
        Dq,
        Nt
    }

    public enum ReviewRoleType
    {
        Sd,
        Sh,
        Sc
    }
}