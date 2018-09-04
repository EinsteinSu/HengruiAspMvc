using System.Web.Mvc;
using Hengrui.Business;
using Hengrui.Commons;
using Filter = Hengrui.DataAccess.Models.Projects.Filter;

namespace Hengrui.Controllers
{
    public class FiltersController : CrudControllerBase<Filter>
    {
        // GET: Filters
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult FiltersGridViewPartial()
        {
            return GetList("FiltersGridViewPartial");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FiltersGridViewPartialAddNew(Filter item)
        {
            return AddNew(item, "FiltersGridViewPartial");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FiltersGridViewPartialUpdate(Filter item)
        {
            return Update(item, "FiltersGridViewPartial");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FiltersGridViewPartialDelete(int id)
        {
            return Delete(id, "FiltersGridViewPartial");
        }

        protected override void InitializeInterfaces()
        {
            Mgr = new FilterMgr();
        }
    }
}