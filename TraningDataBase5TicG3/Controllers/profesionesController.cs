using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TraningDataBase5TicG3.Infraestructure;
using TraningDataBase5TicG3.Models;
using TraningDataBase5TicG3.Services;

namespace TraningDataBase5TicG3.Controllers
{
    public class profesionesController : Controller
    {
        private TestDbMensageriaEntities db = new TestDbMensageriaEntities();
        private readonly IProfesionesService service = null;

        public profesionesController()
        {
            service = new ProfesionesServices();
        }

        // GET: profesiones
        public ActionResult Index()
        {
            var resultado = service.GetAll();
            return View(resultado);
        }

        // GET: profesiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesiones profesiones = service.GetById(id);
            if (profesiones == null)
            {
                return HttpNotFound();
            }
            return View(profesiones);
        }

        // GET: profesiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: profesiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,stValor,stDescripcion")] profesiones profesiones)
        {
            if (ModelState.IsValid)
            {
                this.service.Create(profesiones);
                return RedirectToAction("Index");
            }

            return View(profesiones);
        }

        // GET: profesiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesiones profesiones = service.GetById(id);
            if (profesiones == null)
            {
                return HttpNotFound();
            }
            return View(profesiones);
        }

        // POST: profesiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,stValor,stDescripcion")] profesiones profesiones)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(profesiones);
                return RedirectToAction("Index");
            }
            return View(profesiones);
        }

        // GET: profesiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesiones profesiones = db.profesiones.Find(id);
            if (profesiones == null)
            {
                return HttpNotFound();
            }
            return View(profesiones);
        }

        // POST: profesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            profesiones profesiones = service.GetById(id);
            this.service.detele(profesiones);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.service.Close();
            }
            base.Dispose(disposing);
        }
    }
}
