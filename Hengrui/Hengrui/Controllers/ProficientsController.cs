using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Hengrui.Business;
using Hengrui.Commons;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.Controllers
{
    public class ProficientsController : CrudControllerBase<Proficient>
    {
        // GET: Proficients
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
        public ActionResult GridViewPartialAddNew(Proficient item)
        {
            return AddNew(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Proficient item)
        {
            var roles = EditorExtension.GetValue<string>("checkComboBox");
            item.Roles = roles;
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
            Mgr = new ProficientMgr();
        }
    }
}