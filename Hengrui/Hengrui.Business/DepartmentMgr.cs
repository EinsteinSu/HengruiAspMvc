using System.Collections.Generic;
using System.Linq;
using Hengrui.DataAccess.Models.Organization;

namespace Hengrui.Business
{
    public interface IDepartmentMgr : ICrudMgr<Department>
    {
    }

    public class DepartmentMgr : CrudMgrBase<Department>, IDepartmentMgr
    {
        protected override string EntityName => "Department";


        protected override IEnumerable<Department> GetEntries()
        {
            return Context.Departments.ToList();
        }

        protected override Department GetEntry(int id)
        {
            return Context.Departments.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(Department item)
        {
            Context.Departments.Add(item);
        }

        protected override void DeleteItem(Department item)
        {
            Context.Departments.Remove(item);
        }
    }
}