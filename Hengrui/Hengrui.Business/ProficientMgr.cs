using System.Collections.Generic;
using System.Linq;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.Business
{
    public interface IProficientMgr : ICrudMgr<Proficient>
    {
    }

    public class ProficientMgr : CrudMgrBase<Proficient>, IProficientMgr
    {
        protected override string EntityName => "Proficient";

        protected override IEnumerable<Proficient> GetEntries()
        {
            return Context.Proficients.Where(w => !w.Deleted).ToList();
        }

        protected override Proficient GetEntry(int id)
        {
            return Context.Proficients.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(Proficient item)
        {
            Context.Proficients.Add(item);
        }

        protected override void DeleteItem(Proficient item)
        {
            item.Deleted = true;
            Context.Entry(item).Property(p => p.Deleted).IsModified = true;
        }
    }
}