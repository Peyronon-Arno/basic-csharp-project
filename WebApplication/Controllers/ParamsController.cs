using System.Web.Mvc;
using Bibliotheque;
using Bibliotheque.entity;

namespace WebApplication.Controllers
{
    public class ParamsController : Controller
    {
        private MainManager mainManager = new MainManager();

        // GET: Params
        public ActionResult Index()
        {
            Employe employe = mainManager.GetEmployeById(1);
            return View(employe);
        }

        [HttpPost]
        public ActionResult Save(Employe employe)
        {
            employe.Id = 1;

            if (ModelState.IsValid)
            {
                mainManager.UpdateEmploye(employe);
                return RedirectToAction("Index", new { id = employe.Id });
            }

            return RedirectToAction("Index", employe);
        }

    }
}
