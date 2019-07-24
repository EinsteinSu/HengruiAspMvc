using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hengrui.Business;
using Hengrui.Commons;
using Hengrui.DataAccess.Models.Projects;
using Hengrui.Models;

namespace Hengrui.Controllers
{
    public class ProjectsController : ProjectControllerBase
    {
        // GET: Projects
        public ActionResult Index(string viewName)
        {
            ViewBag.ViewName = viewName;
            return View("");
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial(string viewName)
        {
            return GetList();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(Hengrui.DataAccess.Models.Projects.Project item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Hengrui.DataAccess.Models.Projects.Project item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 Id)
        {
            var model = new object[0];
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model);
        }


        public override ProjectControllerViewModel ProjectViewModel
        {
            get
            {
                return new ProjectControllerViewModel
                {
                    DisplayColumns = new[] { "a", "b" },
                    Projects = new ProjectMgr().GetItems()
                };
            }
        }
    }
}