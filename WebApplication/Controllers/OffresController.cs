using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Bibliotheque;
using Bibliotheque.entity;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OffresController : Controller
    {
        private readonly MainManager mainManager = new MainManager();

        //https://learn.microsoft.com/fr-fr/aspnet/core/tutorials/first-mvc-app/search?view=aspnetcore-7.0
        //GET: Offres
        public ActionResult Index(string searchString)
        {
            List<Offre> offres = mainManager.GetOffres().Include(o => o.Statut).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                offres = offres.Where(s => s.Intitule.ToLower().Contains(searchString.ToLower())).ToList();
            }

            List<OffreViewModel> offresDetail = new List<OffreViewModel>();
            offres.ForEach(o => offresDetail.Add(new OffreViewModel(o, new List<Postulation>())));

            return View(offresDetail);
        }

        [HttpPost]
        public void SubmitFilter(string searchString)
        {
            //return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Offres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = mainManager.GetOffreById(id);
            Statut statut = mainManager.GetStatutById(offre.IdStatut);
            offre.Statut = statut;

            List<Postulation> postulations = mainManager.GetPostulationsByOffreId(offre.Id).ToList();
            postulations.ForEach(p => p.Employe = mainManager.GetEmployeById(p.IdEmploye));

            OffreViewModel offreDetails = new OffreViewModel(offre, postulations);

            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offreDetails);
        }

        // GET: Offres/Create
        public ActionResult Create()
        {
            ViewBag.IdStatut = new SelectList(mainManager.GetStatuts(), "Id", "Libelle");
            return View();
        }

        // POST: Offres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Intitule,Date,Salaire,Description,IdStatut,Responsable")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                mainManager.AddOffre(offre);
                return RedirectToAction("Index");
            }

            ViewBag.IdStatut = new SelectList(mainManager.GetStatuts(), "Id", "Libelle", offre.IdStatut);
            return View(offre);
        }

        // GET: Offres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = mainManager.GetOffreById(id);
            OffreViewModel offreVM = new OffreViewModel(offre);
            if (offreVM == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdStatut = new SelectList(mainManager.GetStatuts(), "Id", "Libelle", offreVM.IdStatut);
            return View(offreVM);
        }

        // POST: Offres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Intitule,Date,Salaire,Description,IdStatut,Responsable")] OffreViewModel offreVM)
        {
            if (ModelState.IsValid)
            {
                Offre offre = mainManager.GetOffreById(offreVM.Id);
                offre.Intitule = offreVM.Intitule;
                offre.Date = offreVM.Date;
                offre.Salaire = offreVM.Salaire;
                offre.Description = offreVM.Description;
                offre.Id = offreVM.Id;
                offre.IdStatut = offreVM.IdStatut;
                offre.Responsable = offreVM.Responsable;

                offre.Statut = mainManager.GetStatutById(offreVM.IdStatut);

                mainManager.EditOffre(offre);
                return RedirectToAction("Index");
            }
            ViewBag.IdStatut = new SelectList(mainManager.GetStatuts(), "Id", "Libelle", offreVM.IdStatut);
            return View(offreVM);
        }

        // GET: Offres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre =mainManager.GetOffreById(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offre offre = mainManager.GetOffreById(id);
            mainManager.DeleteOffre(offre);
            return RedirectToAction("Index");
        }

        // GET: Offres/...
        public ActionResult Postuler(int id)
        {
            Offre Offre = mainManager.GetOffreById(id);
            Employe Employe = mainManager.GetEmployeById(1);

            Postulation postulation = new Postulation();
            postulation.IdOffre = id;
            postulation.Offre = Offre;
            postulation.IdEmploye = 1;
            postulation.Employe = Employe;
            postulation.Date = DateTime.Now;
            postulation.Statut = Offre.IdStatut;

            mainManager.ContextCommandsPostulation.AddPostulation(postulation);

            return RedirectToAction("Index");
        }
    }
}
