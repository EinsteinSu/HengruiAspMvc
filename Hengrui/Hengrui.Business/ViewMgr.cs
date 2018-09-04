using System.Collections.Generic;
using System.Linq;
using Hengrui.DataAccess.Models.Projects;

namespace Hengrui.Business
{
    public interface IViewMgr : ICrudMgr<View>
    {
    }

    public class ViewMgr : CrudMgrBase<View>, IViewMgr
    {
        protected override string EntityName => "View";

        protected override IEnumerable<View> GetEntries()
        {
            return Context.Views.ToList();
        }

        protected override View GetEntry(int id)
        {
            return Context.Views.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(View item)
        {
            Context.Views.Add(item);
        }

        protected override void DeleteItem(View item)
        {
            Context.Views.Remove(item);
        }
    }
}