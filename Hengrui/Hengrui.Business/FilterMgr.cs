using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hengrui.DataAccess.Models.Projects;

namespace Hengrui.Business
{
    public interface IFilterMgr : ICrudMgr<Filter>
    {

    }
    public class FilterMgr : CrudMgrBase<Filter>, IFilterMgr
    {
        protected override string EntityName => "Filter";
        protected override IEnumerable<Filter> GetEntries()
        {
            return Context.Filters.ToList();
        }

        protected override Filter GetEntry(int id)
        {
            return Context.Filters.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(Filter item)
        {
            Context.Filters.Add(item);
        }

        protected override void DeleteItem(Filter item)
        {
            Context.Filters.Remove(item);
        }
    }
}
