using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.DataAccess.Models.Projects
{
    public class ProjectStatus : StatusBase<ProjectStatusType>
    {
    }

    public class PaperStatus : StatusBase<PaperStatusType>
    {
    }

    public class DocumentStatus : StatusBase<DocumentStatusType>
    {
    }

    public class ContractStatus : StatusBase<ContractStatusType>
    {
    }

    public class StatusBase<T> where T : struct
    {
        protected StatusBase()
        {
            Czsj = DateTime.Now;
        }

        public int Id { get; set; }

        public T Status { get; set; }

        public DateTime? Czsj { get; set; }

        public virtual EnterpriseUser Czy { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public virtual Project Project { get; set; }
    }

    public static class StatusExtensions
    {
        public static T GetCurrentStatus<T, TT>(this ICollection<T> statusCollection)
            where T : StatusBase<TT>
            where TT : struct
        {
            return statusCollection.OrderByDescending(d => d.Czsj).FirstOrDefault();
        }
    }

    public enum ProjectStatusType
    {
        接件,
        收件
    }

    public enum ContractStatusType
    {
    }

    public enum PaperStatusType
    {
    }

    public enum DocumentStatusType
    {
    }
}