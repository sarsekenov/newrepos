using Microsoft.AspNet.Identity;
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
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{   [Authorize]
    public class CompanyMembersController : ApiController
    {
        private CompanyMemberContext db = new CompanyMemberContext();

        // GET: api/CompanyMembers
        public IQueryable<CompanyMember> GetCompanyMembers()
        {
            return db.CompanyMembers.Where(CompanyMember => CompanyMember.UserId == User.Identity.GetUserId());

        }

        // GET: api/CompanyMembers/5
        [ResponseType(typeof(CompanyMember))]
        public IHttpActionResult GetCompanyMember(int id)
        {
            CompanyMember companyMember = db.CompanyMembers.Find(id);
            if (companyMember == null)
            {
                return NotFound();
            }

            return Ok(companyMember);
        }

        // PUT: api/CompanyMembers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyMember(int id, CompanyMember companyMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyMember.Id)
            {
                return BadRequest();
            }

            db.Entry(companyMember).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyMemberExists(id))
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

        // POST: api/CompanyMembers
        [ResponseType(typeof(CompanyMember))]
        public IHttpActionResult PostCompanyMember(CompanyMember companyMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = User.Identity.GetUserId();
            companyMember.UserId = userId;
            db.CompanyMembers.Add(companyMember);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = companyMember.Id }, companyMember);
        }

        // DELETE: api/CompanyMembers/5
        [ResponseType(typeof(CompanyMember))]
        public IHttpActionResult DeleteCompanyMember(int id)
        {
            CompanyMember companyMember = db.CompanyMembers.Find(id);
            if (companyMember == null)
            {
                return NotFound();
            }

            db.CompanyMembers.Remove(companyMember);
            db.SaveChanges();

            return Ok(companyMember);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyMemberExists(int id)
        {
            return db.CompanyMembers.Count(e => e.Id == id) > 0;
        }
    }
}