using System.Collections.Generic;
using System.Linq;
using Hengrui.DataAccess.Models.Organization;

namespace Hengrui.Business
{
    public interface IBranchMgr : ICrudMgr<Branch>
    {
    }

    public class BranchMgr : CrudMgrBase<Branch>, IBranchMgr
    {
        protected override string EntityName => "Branch";

        protected override IEnumerable<Branch> GetEntries()
        {
            return Context.Branches.ToList();
        }

        protected override Branch GetEntry(int id)
        {
            return Context.Branches.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(Branch item)
        {
            Context.Branches.Add(item);
        }

        protected override void DeleteItem(Branch item)
        {
            Context.Branches.Remove(item);
        }
    }
}