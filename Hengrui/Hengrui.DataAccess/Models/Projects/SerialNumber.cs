using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengrui.DataAccess.Models.Projects
{
    public abstract class SerialNumber : IComparable<SerialNumber>
    {
        [ForeignKey("Project")]
        [Key]
        public int ProjectId { get; set; }

        public int Year { get; set; }

        public int Number { get; set; }

        protected abstract SerialNumberType Type { get; }

        public virtual Project Project { get; set; }

        public int CompareTo(SerialNumber other)
        {
            if (other.GetValue() > GetValue())
                return -1;
            if (other.GetValue() == GetValue())
                return 0;
            return 1;
        }

        public virtual string GetDisplayName(string acronym)
        {
            //todo:generate display number with type
            return acronym;
        }

        private int GetValue()
        {
            return Year + Number;
        }
    }

    public class Xmbh : SerialNumber
    {
        protected override SerialNumberType Type => SerialNumberType.Project;
    }

    public class Htbh : SerialNumber
    {
        protected override SerialNumberType Type => SerialNumberType.Contact;
    }

    public enum SerialNumberType
    {
        Project,
        Contact
    }
}