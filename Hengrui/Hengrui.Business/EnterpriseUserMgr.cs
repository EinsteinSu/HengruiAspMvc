using System.Collections.Generic;
using System.Linq;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.Business
{
    public interface IEnterpriseUserMgr : ICrudMgr<EnterpriseUser>
    {
    }

    public class EnterpriseUserMgr : CrudMgrBase<EnterpriseUser>, IEnterpriseUserMgr
    {
        protected override string EntityName => "Enterprise User";

        protected override IEnumerable<EnterpriseUser> GetEntries()
        {
            return Context.EnterpriseUsers.Where(w => !w.Deleted).ToList();
        }

        protected override EnterpriseUser GetEntry(int id)
        {
            return Context.EnterpriseUsers.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(EnterpriseUser item)
        {
            Context.EnterpriseUsers.Add(item);
        }

        protected override void DeleteItem(EnterpriseUser item)
        {
            item.Deleted = true;
            Context.Entry(item).Property(p => p.Deleted).IsModified = true;
        }
    }
}