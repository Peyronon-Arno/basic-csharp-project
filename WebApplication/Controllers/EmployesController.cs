using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Bibliotheque;
using Bibliotheque.entity;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EmployesController : Controller
    {
        private MainManager mainManager = new MainManager();

        // GET: Employes
        public ActionResult Index(string searchString)
        {
            List<Employe> employes = mainManager.GetEmployes().ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                employes = employes.Where(e => e.Nom.ToLower().Contains(searchString.ToLower()) || e.Prenom.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return View(employes);
        }

        [HttpPost]
        public void SubmitFilter(string searchString)
        {
            //return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Employes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = mainManager.GetEmployeById(id);
            List<Experience> experiences = mainManager.GetExperiencesByEmployeeId(employe.Id).ToList();
            EmployeDetailViewModel employeDetail = new EmployeDetailViewModel(employe, experiences);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employeDetail);
        }

        // GET: Employes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,DateNaissance,Anciennete,Biographie")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                mainManager.AddEmployee(employe);
                return RedirectToAction("Index");
            }

            return View(employe);
        }

        // GET: Employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = mainManager.GetEmployeById(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,DateNaissance,Anciennete,Biographie")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                mainManager.EditEmploye(employe);
                return RedirectToAction("Index");
            }
            return View(employe);
        }

        // GET: Employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = mainManager.GetEmployeById(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employe employe = mainManager.GetEmployeById(id);
            mainManager.RemoveEmploye(employe);
            return RedirectToAction("Index");
        }

    }
}
