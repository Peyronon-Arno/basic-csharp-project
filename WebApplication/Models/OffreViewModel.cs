using Bibliotheque.entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Models
{
    public class OffreViewModel
    {
        public int Id { get; set; }
        public string Intitule { get; set; }
        public DateTime Date { get; set; }
        public int Salaire { get; set; }
        public string Description { get; set; }
        public Statut Statut { get; set; }
        public int IdStatut { get; set; }
        public string Responsable { get; set; }

        public List<Postulation> Postulations { get; set; }

        public OffreViewModel() { }

        public OffreViewModel(Offre offre)
        {
            Id = offre.Id;
            Intitule = offre.Intitule;
            Date = offre.Date;
            Salaire = offre.Salaire;
            Description = offre.Description;
            Statut = offre.Statut;
            IdStatut = offre.IdStatut;
            Responsable = offre.Responsable;
            Postulations = new List<Postulation>();
        }

        public OffreViewModel(Offre offre, List<Postulation> postulations)
        {
            Id = offre.Id;
            Intitule = offre.Intitule;
            Date = offre.Date;
            Salaire = offre.Salaire;
            Description = offre.Description;
            Statut = offre.Statut;
            IdStatut = offre.IdStatut;
            Responsable = offre.Responsable;
            Postulations = postulations;
        }

        public bool EmployeAPostule(int employeID)
        {
            foreach(Postulation p in this.Postulations)
            {
                if (p.IdEmploye.Equals(employeID))
                {
                    return false;
                }
            }
            return true;
        }
    }
}