using FluentValidation.Results;
using InformacionPersonal.DAL;
using InformacionPersonal.Models;
using InformacionPersonal.Models.Validations;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace InformacionPersonal.Controllers
{
    public class PersonasController : Controller
    {
        private PersonalContext db = new PersonalContext();
        private PersonasList personaslst = new PersonasList();

        #region ***Listar....
        //Se consultan los registros correspondientes a
        //la pagina que se esta visualizando.

        //Carga el listado de personas inicialmente...
        // GET: Personas
        public ActionResult ListaPersonas()
        {
            return View(GetPersonas(1, null));
            //return PartialView("_ListPartial", GetPersonas(1, null));
        }

        //Carga el listado de personas de una pagina en especifico
        [HttpPost]
        public ActionResult ListaPersonas(int currentPageIndex, [Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,CURP")]Persona filtro)
        {
            //return View(GetPersonas(currentPageIndex, filtro));
            return PartialView("_ListPartial", GetPersonas(currentPageIndex, filtro));
        }

        //Obtiene el listado de personas de una pagina en especifico
        private PersonasList GetPersonas(int? currentPage, Persona filtro)
        {
            double pageCount;
            int maxRows = 5;
            if (filtro != null)
            {
                personaslst.Personas = db.Personal.Where(x=>String.IsNullOrEmpty(filtro.Nombre)||x.Nombre.Contains(filtro.Nombre))
                    .Where(x=>String.IsNullOrEmpty(filtro.ApellidoPaterno) || x.ApellidoPaterno.Contains(filtro.ApellidoPaterno))
                    .Where(x => String.IsNullOrEmpty(filtro.ApellidoMaterno) || x.ApellidoMaterno.Contains(filtro.ApellidoMaterno))
                    .Where(x => String.IsNullOrEmpty(filtro.CURP) || x.CURP.Contains(filtro.CURP))
                    .ToList();
                pageCount = (double)((decimal)personaslst.Personas.Count / Convert.ToDecimal(maxRows));
                personaslst.Personas = personaslst.Personas.OrderBy(persona => persona.ID)
                                         .Skip((currentPage.Value - 1) * maxRows)
                                         .Take(maxRows).ToList();
            }
            else
            {
                personaslst.Personas = (from item in db.Personal
                                        select item)
                                         .OrderBy(persona => persona.ID)
                                         .Skip((currentPage.Value - 1) * maxRows)
                                         .Take(maxRows).ToList();
                pageCount = (double)((decimal)db.Personal.Count() / Convert.ToDecimal(maxRows));
            }
            personaslst.PageCount = (int)Math.Ceiling(pageCount);

            personaslst.CurrentPageIndex = currentPage.Value;

            return personaslst;
        }
        #endregion

        #region ***Ver detalles
        //GET: Persona
        public ActionResult DetailsPartial(int? id)
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
            return PartialView("_DetailsPartial", persona);
        }
        #endregion

        #region ***Crear...
        public ActionResult CreatePartial()
        {
            Persona model = new Persona();
            return PartialView("_CreatePartial", model);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,CURP")] Persona persona)
        {
            PersonaValidator validator = new PersonaValidator();
            ValidationResult result = validator.Validate(persona);

            if (result.IsValid && ModelState.IsValid)
            {
                db.Personal.Add(persona);
                db.SaveChanges();
                return PartialView("_ListPartial", GetPersonas(1, null));
            }
            else
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
                Response.StatusCode = 412;
            }

            return PartialView("_CreatePartial", persona);
        }
        #endregion

        #region ***Editar...
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
        public ActionResult Edit([Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,CURP")] Persona persona)
        {
            PersonaValidator validator = new PersonaValidator();
            ValidationResult result = validator.Validate(persona);

            if (result.IsValid && ModelState.IsValid)
            {
                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return PartialView("_ListPartial", GetPersonas(1, null));
            }
            else
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
                Response.StatusCode = 412;
            }

            return PartialView("_EditPartial", persona);
        }
        #endregion

        #region ***Eliminar...
        // GET: Personas/Delete/5
        public ActionResult DeletePartial(int? id)
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
            return PartialView("_DeletePartial", persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personal.Find(id);
            db.Personal.Remove(persona);
            db.SaveChanges();
            return PartialView("_ListPartial", GetPersonas(1, null));
        }
        #endregion

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
