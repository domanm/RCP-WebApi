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
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CzasPraciesController : ApiController
    {
        private RCPEntities1 db = new RCPEntities1();

        // GET: api/CzasPracies
        public IQueryable<CzasPracy> GetCzasPracy()
        {
            return db.CzasPracy;
        }

        // GET: api/CzasPracies/5
        [ResponseType(typeof(CzasPracy))]
        public IHttpActionResult GetCzasPracy(int id)
        {
            CzasPracy czasPracy = db.CzasPracy.Find(id);
            if (czasPracy == null)
            {
                return NotFound();
            }

            return Ok(czasPracy);
        }

        // PUT: api/CzasPracies/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutCzasPracy(int id, CzasPracy czasPracy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != czasPracy.id)
            {
                return BadRequest();
            }

            db.Entry(czasPracy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CzasPracyExists(id))
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

        // POST: api/CzasPracies
        
        [ResponseType(typeof(CzasPracy))]
        public IHttpActionResult PostCzasPracy(CzasPracy czasPracy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CzasPracy.Add(czasPracy);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CzasPracyExists(czasPracy.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = czasPracy.id }, czasPracy);
        }

        // DELETE: api/CzasPracies/5
        [ResponseType(typeof(CzasPracy))]
        public IHttpActionResult DeleteCzasPracy(int id)
        {
            CzasPracy czasPracy = db.CzasPracy.Find(id);
            if (czasPracy == null)
            {
                return NotFound();
            }

            db.CzasPracy.Remove(czasPracy);
            db.SaveChanges();

            return Ok(czasPracy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CzasPracyExists(int id)
        {
            return db.CzasPracy.Count(e => e.id == id) > 0;
        }
    }
}