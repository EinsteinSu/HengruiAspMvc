using System.Web.Mvc;
using Hengrui.Business;
using Hengrui.Commons;
using Hengrui.DataAccess.Models.Organization;

namespace Hengrui.Controllers
{
    public class DepartmentsController : CrudControllerBase<Department>
    {
        // GET: Departments
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            return GetList();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(Department item)
        {
            return AddNew(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Department item)
        {
            return Update(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GridViewPartialDelete(int id)
        {
            return Delete(id);
        }

        protected override void InitializeInterfaces()
        {
            Mgr = new DepartmentMgr();
        }
    }
}