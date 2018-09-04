using System.Web.Mvc;
using Hengrui.Business;
using Hengrui.Commons;
using Hengrui.DataAccess.Models.Projects;

namespace Hengrui.Controllers
{
    public class CutomViewsController : CrudControllerBase<CustomView>
    {
        // GET: CutomViews
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult CustomViewGridViewPartial()
        {
            return GetList("CustomViewGridViewPartial");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CustomViewGridViewPartialAddNew(CustomView item)
        {
            return AddNew(item, "CustomViewGridViewPartial");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CustomViewGridViewPartialUpdate(CustomView item)
        {
            return Update(item, "CustomViewGridViewPartial");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CustomViewGridViewPartialDelete(int id)
        {
            return Delete(id, "CustomViewGridViewPartial");
        }

        protected override void InitializeInterfaces()
        {
            Mgr = new CustomViewMgr();
        }
    }
}