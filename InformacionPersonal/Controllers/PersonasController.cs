using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InformacionPersonal.DAL;
using InformacionPersonal.Models;
using InformacionPersonal.Models.Validations;
using FluentValidation.Results;

namespace InformacionPersonal.Controllers
{
    public class PersonasController : Controller
    {
        private PersonalContext db = new PersonalContext();

        // GET: Personas
        public ActionResult ListaPersonas()
        {
            return View(db.Personal.ToList());
        }


        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personal.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,CURP")] Persona persona)
        {
            //PersonaValidator validator = new PersonaValidator();
            //ValidationResult result = validator.Validate(persona);

            //if (result.IsValid)
            //{
            if (ModelState.IsValid)
            {
                db.Personal.Add(persona);
                db.SaveChanges();
                return RedirectToAction("ListaPersonas");
            }
            //else
            //{
            //    foreach (ValidationFailure failer in result.Errors)
            //    {
            //        ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
            //    }
            //}

            return View(persona);
        }

        public ActionResult CreatePartial()
        {
            Persona model = new Persona();
            return PartialView("_CreatePartial", model);
        }

        public ActionResult EditPartial(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personal.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return PartialView("_EditPartial", persona);
        }


        public ActionResult DetailsPartial(int? id)
        {
            //List<Persona> model = db.Personal.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personal.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsPartial", persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personal.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,CURP")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaPersonas");
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personal.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personal.Find(id);
            db.Personal.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
