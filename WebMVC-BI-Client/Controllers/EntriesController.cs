using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebMVC_BI_Client.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WebMVC_BI_Client
{
    [Authorize]
    public class EntriesController : ApiController
    {
        private BIClientDBContext db = new BIClientDBContext();
        private ApplicationDbContext appDb = ApplicationDbContext.Create();
        
        // GET: api/Entries
        public IQueryable<Entry> GetEntries()
        {
            ApplicationUser currentUser = appDb.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            return db.Entries.Where(e => e.UserId == currentUser.Id);
        }

        // GET: api/Entries/5
        [ResponseType(typeof(Entry))]
        public async Task<IHttpActionResult> GetEntry(int id)
        {
            Entry entry = await db.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        // PUT: api/Entries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEntry(int id, Entry entry)
        {
            // Setup current user
            entry.UserId = appDb.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entry.Id)
            {
                return BadRequest();
            }

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entries
        [ResponseType(typeof(Entry))]
        public async Task<IHttpActionResult> PostEntry(Entry entry)
        {
            // Setup current user
            entry.UserId = appDb.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entries.Add(entry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = entry.Id }, entry);
        }

        // DELETE: api/Entries/5
        [ResponseType(typeof(Entry))]
        public async Task<IHttpActionResult> DeleteEntry(int id)
        {
            Entry entry = await db.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            db.Entries.Remove(entry);
            await db.SaveChangesAsync();

            return Ok(entry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntryExists(int id)
        {
            return db.Entries.Count(e => e.Id == id) > 0;
        }
    }
}