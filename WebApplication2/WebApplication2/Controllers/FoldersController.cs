using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FoldersController : ApiController
    {
        public static FolderContext db = new FolderContext();

        // GET: api/Folders
        public IQueryable<Folder> GetFolders()
        {
            return db.Folders;
        }

        // GET: api/Folders/5
        [ResponseType(typeof(Folder))]
        public IHttpActionResult GetFolder(int id)
        {
            Folder folder = db.Folders.Find(id);
            if (folder == null)
            {
                return NotFound();
            }

            return Ok(folder);
        }

        // PUT: api/Folders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFolder(int id, Folder folder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != folder.Id)
            {
                return BadRequest();
            }

            db.Entry(folder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FolderExists(id))
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

        // POST: api/Folders
        [ResponseType(typeof(Folder))]
        public IHttpActionResult PostFolder(Folder folder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Folders.Add(folder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = folder.Id }, folder);
        }

        // DELETE: api/Folders/5
        [ResponseType(typeof(Folder))]
        public IHttpActionResult DeleteFolder(int id)
        {
            Folder folder = db.Folders.Find(id);
            if (folder == null)
            {
                return NotFound();
            }

            db.Folders.Remove(folder);
            db.SaveChanges();

            return Ok(folder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FolderExists(int id)
        {
            return db.Folders.Count(e => e.Id == id) > 0;
        }
    }
}