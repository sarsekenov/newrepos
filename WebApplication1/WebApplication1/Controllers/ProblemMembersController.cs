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
{
    public class ProblemMembersController : ApiController
    {
        private ProblemMemberContext db = new ProblemMemberContext();

        // GET: api/ProblemMembers
        public IQueryable<ProblemMember> GetProblemMembers()
        {
            string userId = User.Identity.GetUserId();
            return db.ProblemMembers.Where(c=>c.UserId ==userId);
        }

        // GET: api/ProblemMembers/5
        [ResponseType(typeof(ProblemMember))]
        public IHttpActionResult GetProblemMember(int id)
        {
            ProblemMember problemMember = db.ProblemMembers.Find(id);
            if (problemMember == null)
            {
                return NotFound();
            }

            return Ok(problemMember);
        }

        // PUT: api/ProblemMembers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProblemMember(int id, ProblemMember problemMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != problemMember.Id)
            {
                return BadRequest();
            }

            db.Entry(problemMember).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProblemMemberExists(id))
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

        // POST: api/ProblemMembers
        [ResponseType(typeof(ProblemMember))]
        public IHttpActionResult PostProblemMember(ProblemMember problemMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = User.Identity.GetUserId();
            problemMember.UserId = userId;
            db.ProblemMembers.Add(problemMember);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = problemMember.Id }, problemMember);
        }

        // DELETE: api/ProblemMembers/5
        [ResponseType(typeof(ProblemMember))]
        public IHttpActionResult DeleteProblemMember(int id)
        {
            ProblemMember problemMember = db.ProblemMembers.Find(id);
            if (problemMember == null)
            {
                return NotFound();
            }

            db.ProblemMembers.Remove(problemMember);
            db.SaveChanges();

            return Ok(problemMember);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProblemMemberExists(int id)
        {
            return db.ProblemMembers.Count(e => e.Id == id) > 0;
        }
    }
}