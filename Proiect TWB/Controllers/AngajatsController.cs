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
using Proiect_TWB;

namespace Proiect_TWB.Controllers
{
    public class AngajatsController : ApiController
    {
        private PersonDBEntities db = new PersonDBEntities();

        [HttpGet]
        public List<Angajat> GetAngajatByIdDepartament(int id)
        {
            return db.Angajats.Where(x => x.IdDep == id).ToList();
        }

        // GET: api/Angajats
        public IQueryable<Angajat> GetAngajats()
        {
            return db.Angajats;
        }

        // GET: api/Angajats/5
        [ResponseType(typeof(Angajat))]
        public IHttpActionResult GetAngajat(int id)
        {
            Angajat angajat = db.Angajats.Find(id);
            if (angajat == null)
            {
                return NotFound();
            }

            return Ok(angajat);
        }

        // PUT: api/Angajats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAngajat(int id, Angajat angajat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != angajat.Marca)
            {
                return BadRequest();
            }

            db.Entry(angajat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AngajatExists(id))
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

        // POST: api/Angajats
        [ResponseType(typeof(Angajat))]
        public IHttpActionResult PostAngajat(Angajat angajat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Angajats.Add(angajat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = angajat.Marca }, angajat);
        }

        // DELETE: api/Angajats/5
        [ResponseType(typeof(Angajat))]
        public IHttpActionResult DeleteAngajat(int id)
        {
            Angajat angajat = db.Angajats.Find(id);
            if (angajat == null)
            {
                return NotFound();
            }

            db.Angajats.Remove(angajat);
            db.SaveChanges();

            return Ok(angajat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AngajatExists(int id)
        {
            return db.Angajats.Count(e => e.Marca == id) > 0;
        }
    }
}