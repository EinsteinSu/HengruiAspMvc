using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hengrui.DataAccess.Models.Projects;
using Hengrui.Models;

namespace Hengrui.Commons
{
    public abstract class ProjectControllerBase : Controller
    {
        public abstract ProjectControllerViewModel ProjectViewModel { get; }



        protected virtual ActionResult GetList(string viewName = "_GridViewPartial")
        {
            return PartialView(viewName, ProjectViewModel);
        }


    }


}