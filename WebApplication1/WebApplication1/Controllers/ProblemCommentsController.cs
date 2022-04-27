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
    public class ProblemCommentsController : ApiController
    {
        private ProblemCommentContext db = new ProblemCommentContext();

        // GET: api/ProblemComments
        public IQueryable<ProblemComment> GetProblemComments()
        {
            return db.ProblemComments;
        }

        // GET: api/ProblemComments/5
        [ResponseType(typeof(ProblemComment))]
        public IHttpActionResult GetProblemComment(int id)
        {
            ProblemComment problemComment = db.ProblemComments.Find(id);
            if (problemComment == null)
            {
                return NotFound();
            }

            return Ok(problemComment);
        }

        // PUT: api/ProblemComments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProblemComment(int id, ProblemComment problemComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != problemComment.Id)
            {
                return BadRequest();
            }

            db.Entry(problemComment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProblemCommentExists(id))
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

        // POST: api/ProblemComments
        [ResponseType(typeof(ProblemComment))]
        public IHttpActionResult PostProblemComment(ProblemComment problemComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProblemComments.Add(problemComment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = problemComment.Id }, problemComment);
        }

        // DELETE: api/ProblemComments/5
        [ResponseType(typeof(ProblemComment))]
        public IHttpActionResult DeleteProblemComment(int id)
        {
            ProblemComment problemComment = db.ProblemComments.Find(id);
            if (problemComment == null)
            {
                return NotFound();
            }

            db.ProblemComments.Remove(problemComment);
            db.SaveChanges();

            return Ok(problemComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProblemCommentExists(int id)
        {
            return db.ProblemComments.Count(e => e.Id == id) > 0;
        }
    }
}