using Bibliotheque.DAL;
using Bibliotheque.entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bibliotheque.queries
{
    public class ContextQueries
    {
        protected ContextDA ContextDA { get; set; }
        public ContextQueries(ContextDA contextDA)
        {
            ContextDA = contextDA;
        }

        public DbSet<Employe> GetEmploye()
        {
            return ContextDA.Employes;
        }

        public DbSet<Offre> GetOffres()
        {
            return ContextDA.Offres;
        }

        public DbSet<Postulation> GetPostulations()
        {
            return ContextDA.Postulations;
        }

        public DbSet<Statut> GetStatuts()
        {
            return ContextDA.Statuts;
        }

        public Employe GetEmployeById(int? id)
        {
            return ContextDA.Employes.Find(id);
        }

        public Offre GetOffreById(int? id)
        {
            return ContextDA.Offres.Find(id);
        }

        public Statut GetStatutById(int? id)
        {
            return ContextDA.Statuts.Find(id);
        }

        internal IEnumerable<Postulation> GetPostulationByOffreId(int? id)
        {
            return ContextDA.Postulations.Where(p => p.IdOffre == id);
        }

        public IEnumerable<Experience> GetExperiencesByEmployeeId(int? employeId)
        {
            return ContextDA.Experiences.Where(e => e.IdEmploye ==  employeId);
        }

        public IEnumerable<Postulation> GetPostulationsByIdEmployee(int? id)
        {
            return ContextDA.Postulations.Where(p => p.IdEmploye == id);
        }
    }
}
