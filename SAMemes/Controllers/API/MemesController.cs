using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using SAMemes.Models;

namespace SAMemes.Controllers.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MemesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Memes
        public List<Meme> GetMemes()
        {
            List<Meme> list = db.Memes.ToList();
            foreach (var meme in list)
            {
                meme.comments = db.Comments.Where(x => x.memeId == meme.id).ToList();
            }
            list.Reverse();
            return list;
        }

        [Route("api/AddComment")]
        [HttpGet]
        public void AddComment(int memeId, string comment)
        {
            var meme = db.Memes.Find(memeId);
            meme.comments.Add(new Comment() { memeId = memeId, comment = comment });
            db.SaveChanges();
        }
        [Route("api/AddLike")]
        [HttpGet]
        public void AddLike(int memeId)
        {
            var meme = db.Memes.Find(memeId);
            meme.likes += 1;
            db.SaveChanges();
        }

        [Route("api/RemoveLike")]
        [HttpGet]
        public void RemoveLike(int memeId)
        {
            var meme = db.Memes.Find(memeId);
            meme.likes -= 1;
            db.SaveChanges();
        }


        // GET: api/Memes/5
        [ResponseType(typeof(Meme))]
        public IHttpActionResult GetMeme(int id)
        {
            Meme meme = db.Memes.Find(id);
            if (meme == null)
            {
                return NotFound();
            }

            return Ok(meme);
        }

        // PUT: api/Memes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeme(int id, Meme meme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meme.id)
            {
                return BadRequest();
            }

            db.Entry(meme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemeExists(id))
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

        // POST: api/Memes
        [ResponseType(typeof(Meme))]
        public IHttpActionResult PostMeme(Meme meme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Memes.Add(meme);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meme.id }, meme);
        }

        // DELETE: api/Memes/5
        [ResponseType(typeof(Meme))]
        public IHttpActionResult DeleteMeme(int id)
        {
            Meme meme = db.Memes.Find(id);
            if (meme == null)
            {
                return NotFound();
            }

            db.Memes.Remove(meme);
            db.SaveChanges();

            return Ok(meme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemeExists(int id)
        {
            return db.Memes.Count(e => e.id == id) > 0;
        }
    }
}