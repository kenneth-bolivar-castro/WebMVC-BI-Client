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

namespace WebMVC_BI_Client
{
    [Authorize]
    public class EntriesController : ApiController
    {
        private BIClientDBContext db = new BIClientDBContext();

        // GET: api/Entries
        public IQueryable<Entry> GetEntries()
        {
            return db.Entries;
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