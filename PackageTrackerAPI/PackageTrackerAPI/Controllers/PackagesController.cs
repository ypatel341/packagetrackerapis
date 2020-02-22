﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PackageTrackerAPI.Models;

namespace PackageTrackerAPI.Controllers
{
    public class PackagesController : ApiController
    {
        private PackageTrackerDBEntities db = new PackageTrackerDBEntities();
        [Authorize]
        // GET: api/Packages
        public IQueryable<Package> GetPackages()
        {
            return db.Packages;
        }

        // GET: api/Packages/5
        [ResponseType(typeof(Package))]
        public IHttpActionResult GetPackage(int id)
        {
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }

            return Ok(package);
            //return Ok(package.Package_ID);
        }

        // PUT: api/Packages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPackage(int id, Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != package.Package_ID)
            {
                return BadRequest();
            }

            db.Entry(package).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Packages
        [ResponseType(typeof(Package))]
        public IHttpActionResult PostPackage(Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Packages.Add(package);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = package.Package_ID }, package);
        }

        // DELETE: api/Packages/5
        [ResponseType(typeof(Package))]
        public IHttpActionResult DeletePackage(int id)
        {
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }

            db.Packages.Remove(package);
            db.SaveChanges();

            return Ok(package);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PackageExists(int id)
        {
            return db.Packages.Count(e => e.Package_ID == id) > 0;
        }
    }
}