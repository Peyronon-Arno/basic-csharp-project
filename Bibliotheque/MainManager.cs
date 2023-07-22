using Bibliotheque.commands;
using Bibliotheque.DAL;
using Bibliotheque.entity;
using Bibliotheque.queries;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bibliotheque
{
    public class MainManager
    {

        private ContextDA contextDA = Singleton.GetInstance();

        public ContextQueries ContextQueries { get; set; }
        public ContextCommandsWPF ContextCommands { get; set; }
        public ContextCommandsEmploye ContextCommandsEmploye { get; set; }
        public ContextCommandsOffre ContextCommandsOffre { get; set; }

        public ContextCommandsPostulation ContextCommandsPostulation { get; set; }

        public MainManager() {
            ContextQueries = new ContextQueries(contextDA);
            ContextCommands = new ContextCommandsWPF(contextDA);
            ContextCommandsEmploye = new ContextCommandsEmploye(contextDA);
            ContextCommandsOffre = new ContextCommandsOffre(contextDA);
            ContextCommandsPostulation = new ContextCommandsPostulation(contextDA);
        }

        public IQueryable<Employe> GetEmployes()
        {
            return ContextQueries.GetEmploye();
        }

        public IQueryable<Offre> GetOffres()
        {
            return ContextQueries.GetOffres();
        }

        public IQueryable<Postulation> GetPostulations()
        {
            return ContextQueries.GetPostulations();
        }

        public IQueryable<Statut> GetStatuts()
        {
            return ContextQueries.GetStatuts();
        }

        

        public void PersistInBase(int salaire, string description, string intitule, string responsable, string statut)
        {
            ContextCommands.PersistInBase(salaire, description, intitule, responsable, statut);
        }

        public void ChangePrice(int editedPrice, int idSelectedOffre)
        {
            ContextCommands.ChangePrice(editedPrice, idSelectedOffre);
        }

        public void AddEmployee(Employe employe)
        {
            ContextCommandsEmploye.AddEmploye(employe);
        }

        public Employe GetEmployeById(int? id)
        {
            return ContextQueries.GetEmployeById(id);
        }

        public void EditEmploye(Employe employe)
        {
            ContextCommandsEmploye.EditEmploye(employe);
        }

        public void RemoveEmploye(Employe employe)
        {
            ContextCommandsEmploye.RemoveEmploye(employe);
        }

        public Offre GetOffreById(int? id)
        {
            return ContextQueries.GetOffreById(id);
        } 

        public void AddOffre(Offre offre)
        {
            ContextCommandsOffre.AddOffre(offre);
        }

        public void EditOffre(Offre offre)
        {
            ContextCommandsOffre.EditOffre(offre);
        }

        public void DeleteOffre(Offre offre)
        {
            ContextCommandsOffre.DeleteOffre(offre);
        }

        public Statut GetStatutById(int? id)
        {
            return ContextQueries.GetStatutById(id);
        }

        public IEnumerable<Experience> GetExperiencesByEmployeeId(int? id)
        {
            return ContextQueries.GetExperiencesByEmployeeId(id);
        }
        public IEnumerable<Postulation> GetPostulationsByOffreId(int? id)
        {
            return ContextQueries.GetPostulationByOffreId(id);
        }

        public void UpdateEmploye(Employe employe)
        {
            ContextCommandsEmploye.UpdateEmploye(employe);
        }


        public IEnumerable<Postulation> GetPostulationsByIdEmployee(int? id)
        {
            return ContextQueries.GetPostulationsByIdEmployee(id);
        }
    }
}
