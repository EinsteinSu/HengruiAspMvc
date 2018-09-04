using System.Web.Mvc;
using Hengrui.Business;
using Hengrui.Commons;
using Hengrui.DataAccess.Models.Projects;

namespace Hengrui.Controllers
{
    public class ViewsController : CrudControllerBase<View>
    {
        // GET: Views
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
        public ActionResult GridViewPartialAddNew(View item)
        {
            return AddNew(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(View item)
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
            Mgr = new ViewMgr();
        }
    }
}