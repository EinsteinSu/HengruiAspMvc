using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.DataAccess.Models.Projects
{
    public class Paper
    {
        public int Id { get; set; }

        public MajorType Zy { get; set; }

        public int Count { get; set; }

        public int BackCount { get; set; }

        public int HftCount { get; set; }

        public User Czy { get; set; }

        public virtual Project Project { get; set; }
    }
}