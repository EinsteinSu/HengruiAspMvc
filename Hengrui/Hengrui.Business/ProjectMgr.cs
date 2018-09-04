using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hengrui.DataAccess.Models.Organization.Users;
using Hengrui.DataAccess.Models.Projects;

namespace Hengrui.Business
{
    public interface IProjectMgr : ICrudMgr<Project>
    {
        IList<Project> GetProjects(string viewName);
    }

    public class ProjectMgr : CrudMgrBase<Project>, IProjectMgr
    {
        protected override string EntityName => "Project";
        protected override IEnumerable<Project> GetEntries()
        {
            return Context.Projects.ToList();
        }

        protected override Project GetEntry(int id)
        {
            return Context.Projects.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(Project item)
        {
            Context.Projects.Add(item);
        }

        protected override void DeleteItem(Project item)
        {
            Context.Projects.Remove(item);
        }

        public IList<Project> GetProjects(string viewName)
        {
            var item = Context.CustomViews.FirstOrDefault(f =>
                f.Name.Equals(viewName, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                return new List<Project>();
            }
            else
            {
                if (item.Filter.StoredProcedure)
                {
                    var projects = Context.Database.SqlQuery<Project>("", item.Filter.Condition).ToList();
                    return projects;
                }
                else
                {
                    return Context.Projects.Where(w => FilterProject(w, item.Filter.Condition)).ToList();
                }

            }
        }

        private bool FilterProject(Project p, string condition)
        {
            
            return true;
        }
    }
}
