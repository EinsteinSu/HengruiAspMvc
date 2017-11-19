using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.DataAccess.Models.Organization
{
    public class Branch
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MaxLength(5)]
        public string Acronym { get; set; }

        [ForeignKey("ContactUser")]
        public int ContactUserId { get; set; }

        public virtual EnterpriseUser ContactUser { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public Contact Contact { get; set; }
    }

    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Region
    {
        public int Id { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public City City { get; set; }

        public string Name { get; set; }
    }
}