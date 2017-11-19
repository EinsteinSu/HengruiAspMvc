using System.Web.Mvc;
using Hengrui.Business;
using Hengrui.Commons;
using Hengrui.DataAccess.Models.Organization;

namespace Hengrui.Controllers
{
    public class BranchesController : CrudControllerBase<Branch>
    {
        // GET: Branches
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
        public ActionResult GridViewPartialAddNew(Branch item)
        {
            return AddNew(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Branch item)
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
            Mgr = new BranchMgr();
        }
    }
}