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
    public class FolderMembersController : ApiController
    {
        private FolderMemberContext db = new FolderMemberContext();

        // GET: api/FolderMembers
        public IQueryable<FolderMember> GetFolderMembers()
        {
            return db.FolderMembers;
        }

        // GET: api/FolderMembers/5
        [ResponseType(typeof(FolderMember))]
        public IHttpActionResult GetFolderMember(int id)
        {
            FolderMember folderMember = db.FolderMembers.Find(id);
            if (folderMember == null)
            {
                return NotFound();
            }

            return Ok(folderMember);
        }

        // PUT: api/FolderMembers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFolderMember(int id, FolderMember folderMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != folderMember.Id)
            {
                return BadRequest();
            }

            db.Entry(folderMember).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FolderMemberExists(id))
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

        // POST: api/FolderMembers
        [ResponseType(typeof(FolderMember))]
        public IHttpActionResult PostFolderMember(FolderMember folderMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FolderMembers.Add(folderMember);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = folderMember.Id }, folderMember);
        }

        // DELETE: api/FolderMembers/5
        [ResponseType(typeof(FolderMember))]
        public IHttpActionResult DeleteFolderMember(int id)
        {
            FolderMember folderMember = db.FolderMembers.Find(id);
            if (folderMember == null)
            {
                return NotFound();
            }

            db.FolderMembers.Remove(folderMember);
            db.SaveChanges();

            return Ok(folderMember);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FolderMemberExists(int id)
        {
            return db.FolderMembers.Count(e => e.Id == id) > 0;
        }
    }
}