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
    public class ContentMembersController : ApiController
    {
        private ContentMemberContext db = new ContentMemberContext();

        // GET: api/ContentMembers
        public IQueryable<ContentMember> GetContentMembers()
        {
            return db.ContentMembers;
        }

        // GET: api/ContentMembers/5
        [ResponseType(typeof(ContentMember))]
        public IHttpActionResult GetContentMember(int id)
        {
            ContentMember contentMember = db.ContentMembers.Find(id);
            if (contentMember == null)
            {
                return NotFound();
            }

            return Ok(contentMember);
        }

        // PUT: api/ContentMembers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContentMember(int id, ContentMember contentMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentMember.Id)
            {
                return BadRequest();
            }

            db.Entry(contentMember).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentMemberExists(id))
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

        // POST: api/ContentMembers
        [ResponseType(typeof(ContentMember))]
        public IHttpActionResult PostContentMember(ContentMember contentMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContentMembers.Add(contentMember);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contentMember.Id }, contentMember);
        }

        // DELETE: api/ContentMembers/5
        [ResponseType(typeof(ContentMember))]
        public IHttpActionResult DeleteContentMember(int id)
        {
            ContentMember contentMember = db.ContentMembers.Find(id);
            if (contentMember == null)
            {
                return NotFound();
            }

            db.ContentMembers.Remove(contentMember);
            db.SaveChanges();

            return Ok(contentMember);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContentMemberExists(int id)
        {
            return db.ContentMembers.Count(e => e.Id == id) > 0;
        }
    }
}