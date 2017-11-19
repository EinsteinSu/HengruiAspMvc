using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Hengrui.DataAccess.Models.Projects
{
    public class Contract
    {
        [ForeignKey("Project")]
        [Key]
        public int ProjectId { get; set; }

        public int Qx { get; set; }

        public bool IsMultiplyPayment => Payments.Any();

        public decimal Htje { get; set; }

        [MaxLength(50)]
        public string Zk { get; set; }

        public decimal Jmje { get; set; }

        public decimal Ysje { get; set; }

        public virtual ContractDiscount Discount { get; set; }

        public virtual ICollection<ProjectContractPayment> Payments { get; set; }

        public Contact Fr { get; set; }

        public virtual Project Project { get; set; }
    }

    public class ContractDiscount
    {
        [ForeignKey("Project")]
        [Key]
        public int ProjectId { get; set; }

        public string Description { get; set; }

        public virtual Project Project { get; set; }
    }

    public class ProjectContractPayment
    {
        public int Id { get; set; }

        public int Time { get; set; }

        public decimal Percent { get; set; }

        public decimal Money { get; set; }

        public string Fksm { get; set; }
    }
}