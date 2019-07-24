using System.Web.Mvc;
using Hengrui.Business;
using Hengrui.Commons;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.Controllers
{
    public class EnterpriseUsersController : CrudControllerBase<EnterpriseUser>
    {
        // GET: EnterpriseUsers
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
        public ActionResult GridViewPartialAddNew(EnterpriseUser item)
        {
            return AddNew(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(EnterpriseUser item)
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
            Mgr = new EnterpriseUserMgr();
        }
    }
}