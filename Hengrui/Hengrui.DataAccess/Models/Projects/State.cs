using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.DataAccess.Models.Projects
{

    public class ProjectState : StateBase<ProjectStateType>
    {
    }

    public class PaperState : StateBase<PaperStateType>
    {
    }

    public class DocumentationState : StateBase<DocumentationStateType>
    {
    }

    public class ContractState : StateBase<ContractStateType>
    {
    }

    public class StateBase<T> where T : struct
    {
        protected StateBase()
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

    public static class StateExtensions
    {
        public static T GetCurrentStatus<T, TT>(this ICollection<T> statusCollection)
            where T : StateBase<TT>
            where TT : struct
        {
            return statusCollection.OrderByDescending(d => d.Czsj).FirstOrDefault();
        }
    }

    public enum ProjectStateType
    {
        接件,
        申请项目信息复核,
        项目信息复核不通过,
        项目信息复核通过,
        收件
    }

    public enum ContractStateType
    {
    }

    public enum PaperStateType
    {
    }

    public enum DocumentationStateType
    {
    }
}