using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Hrc.Models.Commons;
using Hrc.Models.DatabaseContext;

namespace Hrc.Controllers.Commons
{
    public class ContactsController : Controller
    {
        private readonly HrcDbContext db = new HrcDbContext();

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            return View(await db.Contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int? id, int? contactid, string title, string bcontroller, string baction)
        {
            InitializeParameters(id, contactid, title, bcontroller, baction);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(contactid);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create(int? id, int? contactid, string title, string bcontroller, string baction)
        {
            InitializeParameters(id, contactid, title, bcontroller, baction);
            return View();
        }

        private void InitializeParameters(int? id, int? contactid, string title, string bcontroller, string baction)
        {
            ViewBag.ID = id;
            ViewBag.ContactID = contactid;
            ViewBag.Title = title;
            ViewBag.Controller = bcontroller;
            ViewBag.Action = baction;
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int? id, string title, string bcontroller, string baction,
            [Bind(Include = "ContactID,Type,Value")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                //todo: save by title
                Branch item = await db.Branches.FindAsync(id);
                if (item != null)
                {
                    if (title.Contains("负责人"))
                        item.FzrContact.Add(contact);
                    else
                        item.Contact.Add(contact);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction(baction, bcontroller, new { id });
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(int? id, int? contactid, string title, string bcontroller, string baction)
        {
            InitializeParameters(id, contactid, title, bcontroller, baction);
            if (contactid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(contactid);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, string title, string bcontroller, string baction, [Bind(Include = "ContactID,Type,Value")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(baction, bcontroller, new { id });
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int? id, int? contactid, string title, string bcontroller, string baction)
        {
            InitializeParameters(id, contactid, title, bcontroller, baction);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(contactid);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id, int? contactid, string title, string bcontroller, string baction)
        {
            Contact contact = await db.Contacts.FindAsync(contactid);
            db.Contacts.Remove(contact);
            await db.SaveChangesAsync();
            return RedirectToAction(baction, bcontroller, new { id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}