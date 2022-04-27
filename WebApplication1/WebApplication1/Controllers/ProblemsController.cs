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
    public class ProblemsController : ApiController
    {
        private ProblemContext db = new ProblemContext();

        // GET: api/Problems
        public IQueryable<Problem> GetProblems()
        {
            return db.Problems;
        }

        // GET: api/Problems/5
        [ResponseType(typeof(Problem))]
        public IHttpActionResult GetProblem(int id)
        {
            Problem problem = db.Problems.Find(id);
            if (problem == null)
            {
                return NotFound();
            }

            return Ok(problem);
        }

        // PUT: api/Problems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProblem(int id, Problem problem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != problem.Id)
            {
                return BadRequest();
            }

            db.Entry(problem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProblemExists(id))
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

        // POST: api/Problems
        [ResponseType(typeof(Problem))]
        public IHttpActionResult PostProblem(Problem problem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Problems.Add(problem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = problem.Id }, problem);
        }

        // DELETE: api/Problems/5
        [ResponseType(typeof(Problem))]
        public IHttpActionResult DeleteProblem(int id)
        {
            Problem problem = db.Problems.Find(id);
            if (problem == null)
            {
                return NotFound();
            }

            db.Problems.Remove(problem);
            db.SaveChanges();

            return Ok(problem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProblemExists(int id)
        {
            return db.Problems.Count(e => e.Id == id) > 0;
        }
    }
}