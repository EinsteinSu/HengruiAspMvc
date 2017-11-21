using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengrui.DataAccess.Models.Organization.Users
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserType Type { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        public virtual UserPhoto Photo { get; set; }

        public Contact Contact { get; set; }

        public bool Deleted { get; set; }

        [MaxLength(50)]
        public string OriginalId { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum UserType
    {
        Enterprise,
        Proficient
    }

    public class UserPhoto
    {
        [ForeignKey("User")]
        [Key]
        public int UserId { get; set; }

        public byte[] Photo { get; set; }

        public virtual User User { get; set; }
    }
}