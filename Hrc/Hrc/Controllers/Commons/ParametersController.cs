using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hrc.Models.Commons;
using Hrc.Models.DatabaseContext;

namespace Hrc.Controllers.Commons
{
    public class ParametersController : Controller
    {
        private readonly HrcDbContext context = new HrcDbContext();
        // GET: Parameters
        public async Task<ActionResult> Index(string keys)
        {
            List<Parameter> list = await context.Parameters.ToListAsync();
            IEnumerable<Parameter> parameters = from data in list
                                                select data;
            ViewBag.keys = new SelectList(parameters.Select(s => s.Key).Distinct());
            if (!string.IsNullOrEmpty(keys))
            {
                parameters = parameters.Where(w => w.Key.Equals(keys, StringComparison.InvariantCultureIgnoreCase));
            }
            return View(parameters);
        }

        private async Task<ActionResult> GetParameter(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Parameter parameter = await context.Parameters.FindAsync(id);
            if (parameter == null)
                return HttpNotFound();
            return View(parameter);
        }

        public async Task<ActionResult> Details(int? id)
        {
            return await GetParameter(id);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ParameterID,Key,Value,Description")] Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                context.Parameters.Add(parameter);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parameter);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            return await GetParameter(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ParameterID,Key,Value,Description")] Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                context.Entry(parameter).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parameter);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            return await GetParameter(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var parameter = await context.Parameters.FindAsync(id);
            context.Parameters.Remove(parameter);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
