using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hengrui.DataAccess.Models.Organization;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.DataAccess.Models.Projects
{
    public class Project : IProject
    {
        public Project()
        {
            CreateTime = DateTime.Now;
        }

        public int Id { get; set; }

        public virtual ProjectLevel Emergency { get; set; }

        public Xmbh Xmbh { get; set; }

        public Htbh Htbh { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public Xmlb Xmlb { get; set; }

        public Tzlb Tzlb { get; set; }

        public Region Region { get; set; }

        [Required]
        [MaxLength(200)]
        public string Jsdw { get; set; }

        public ProjectInstance Instance { get; set; }

        public DateTime CreateTime { get; set; }

        //user viewmodel to edit the contact
        public Contact Lxr { get; set; }

        public Contact Wtr { get; set; }

        [ForeignKey("CreateUser")]
        public int CreateUserId { get; set; }

        public virtual User CreateUser { get; set; }

        public bool Paused { get; set; }

        public bool Deleted { get; set; }

        #region linked tables

        public virtual OwnerLogin Login { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual ICollection<PaymentAndBilling> PaymentAndBillings { get; set; }

        public virtual ICollection<Gcgk> Gcgks { get; set; }

        public virtual ICollection<Paper> Papers { get; set; }

        public virtual ICollection<Sjdw> Sjdws { get; set; }

        #endregion


        #region status

        public virtual ICollection<ProjectState> ProjectState { get; set; }
        public virtual ICollection<ContractState> ContractState { get; set; }
        public virtual ICollection<PaperState> PaperState { get; set; }
        public virtual ICollection<DocumentationState> DocumentationState { get; set; }

        public ProjectState CurrentProjectState => ProjectState.GetCurrentStatus<ProjectState, ProjectStateType>();

        public ContractState CurrentContractState => ContractState.GetCurrentStatus<ContractState, ContractStateType>();

        public PaperState CurrentPaperState => PaperState.GetCurrentStatus<PaperState, PaperStateType>();

        public DocumentationState CurrentDocumentationState =>
            DocumentationState.GetCurrentStatus<DocumentationState, DocumentationStateType>();

        #endregion
    }

    public interface IProject
    {
        string Name { get; set; }

        Xmlb Xmlb { get; set; }

        Tzlb Tzlb { get; set; }

        ProjectState CurrentProjectState { get; }

        ContractState CurrentContractState { get; }

        PaperState CurrentPaperState { get; }

        DocumentationState CurrentDocumentationState { get; }
    }


    public enum Tzlb
    {
        A,
        B
    }

    public enum Xmlb
    {
        A,
        B
    }

    public enum ProjectInstance
    {
        Hengrui,
        Weilian
    }
}