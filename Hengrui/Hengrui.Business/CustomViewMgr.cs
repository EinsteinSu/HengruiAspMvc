using System.Collections.Generic;
using System.Linq;
using Hengrui.DataAccess.Models.Projects;

namespace Hengrui.Business
{
    public interface ICustomViewMgr : ICrudMgr<CustomView>
    {
    }

    public class CustomViewMgr : CrudMgrBase<CustomView>, ICustomViewMgr
    {
        protected override string EntityName => "Custom View";

        protected override IEnumerable<CustomView> GetEntries()
        {
            return Context.CustomViews.ToList();
        }

        protected override CustomView GetEntry(int id)
        {
            return Context.CustomViews.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(CustomView item)
        {
            Context.CustomViews.Add(item);
        }

        protected override void DeleteItem(CustomView item)
        {
            Context.CustomViews.Remove(item);
        }
    }
}