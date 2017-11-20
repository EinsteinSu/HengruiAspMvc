using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hengrui.DataAccess.Models.Projects;

namespace Hengrui.Models
{
    public class ProjectControllerViewModel
    {
        public IEnumerable<Project> Projects { get; set; }

        public string[] Actions { get; set; }

        public string[] DisplayColumns { get; set; }

        public string GroupByColumn { get; set; }
    }
}