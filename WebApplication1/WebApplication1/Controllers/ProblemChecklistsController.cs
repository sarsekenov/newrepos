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
    public class ProblemChecklistsController : ApiController
    {
        private ProblemChecklistContext db = new ProblemChecklistContext();

        // GET: api/ProblemChecklists
        public IQueryable<ProblemChecklist> GetProblemChecklists()
        {
            return db.ProblemChecklists;
        }

        // GET: api/ProblemChecklists/5
        [ResponseType(typeof(ProblemChecklist))]
        public IHttpActionResult GetProblemChecklist(int id)
        {
            ProblemChecklist problemChecklist = db.ProblemChecklists.Find(id);
            if (problemChecklist == null)
            {
                return NotFound();
            }

            return Ok(problemChecklist);
        }

        // PUT: api/ProblemChecklists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProblemChecklist(int id, ProblemChecklist problemChecklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != problemChecklist.Id)
            {
                return BadRequest();
            }

            db.Entry(problemChecklist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProblemChecklistExists(id))
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

        // POST: api/ProblemChecklists
        [ResponseType(typeof(ProblemChecklist))]
        public IHttpActionResult PostProblemChecklist(ProblemChecklist problemChecklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProblemChecklists.Add(problemChecklist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = problemChecklist.Id }, problemChecklist);
        }

        // DELETE: api/ProblemChecklists/5
        [ResponseType(typeof(ProblemChecklist))]
        public IHttpActionResult DeleteProblemChecklist(int id)
        {
            ProblemChecklist problemChecklist = db.ProblemChecklists.Find(id);
            if (problemChecklist == null)
            {
                return NotFound();
            }

            db.ProblemChecklists.Remove(problemChecklist);
            db.SaveChanges();

            return Ok(problemChecklist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProblemChecklistExists(int id)
        {
            return db.ProblemChecklists.Count(e => e.Id == id) > 0;
        }
    }
}