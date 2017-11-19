using System;
using DevExpress.Web.Mvc;
using System.Web.Mvc;
using Hengrui.Business;
using Hengrui.Commons;
using Hengrui.DataAccess.Models.Organization;

namespace Hengrui.Controllers
{
    public class CitiesController : CrudControllerBase<City>
    {
        // GET: Cities
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
        public ActionResult GridViewPartialAddNew(City item)
        {
            return AddNew(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(City item)
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
            Mgr = new CityMgr();
        }

        [ValidateInput(false)]
        public ActionResult RegionGridViewPartial(int cityId)
        {
            ViewData["CityId"] = cityId;
            return PartialView("_RegionGridViewPartial", ((ICityMgr)Mgr).GetRegions(cityId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RegionGridViewPartialAddNew(Hengrui.DataAccess.Models.Organization.Region item, int cityId)
        {
            ViewData["CityId"] = cityId;
            if (ModelState.IsValid)
            {
                try
                {
                    ((ICityMgr)Mgr).AddRegion(cityId, item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RegionGridViewPartial", ((ICityMgr)Mgr).GetRegions(cityId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RegionGridViewPartialUpdate(Hengrui.DataAccess.Models.Organization.Region item, int cityId)
        {
            ViewData["CityId"] = cityId;
            if (ModelState.IsValid)
            {
                try
                {
                    ((ICityMgr)Mgr).UpdateRegion(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RegionGridViewPartial", ((ICityMgr)Mgr).GetRegions(cityId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RegionGridViewPartialDelete(int id, int cityId)
        {
            ViewData["CityId"] = cityId;
            try
            {
                ((ICityMgr)Mgr).DeleteRegion(id);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_RegionGridViewPartial", ((ICityMgr)Mgr).GetRegions(cityId));
        }
    }
}