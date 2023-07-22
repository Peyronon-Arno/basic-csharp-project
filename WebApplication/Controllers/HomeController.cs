using Bibliotheque;
using Bibliotheque.entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private MainManager mainManager = new MainManager();
        public ActionResult Index()
        {
            Employe employe = mainManager.GetEmployeById(1);
            List<Postulation> postulations = mainManager.GetPostulationsByIdEmployee(employe.Id).ToList();
            List<Offre> offres = mainManager.GetOffres().ToList();

            foreach (var postulation in postulations)
            {
                postulation.Offre = offres.FirstOrDefault(o => o.Id == postulation.IdOffre && postulation.IdEmploye == employe.Id);
            }

            EmployeHomeViewModel employeHome = new EmployeHomeViewModel(employe, postulations);
            return View(employeHome);
        }
    }
}