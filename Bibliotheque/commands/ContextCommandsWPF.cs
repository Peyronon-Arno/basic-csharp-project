using Bibliotheque.DAL;
using Bibliotheque.entity;
using System;
using System.Data.Entity;
using System.Linq;

namespace Bibliotheque.commands
{
    public class ContextCommandsWPF
    {
        protected ContextDA ContextDA { get; set; }
        public ContextCommandsWPF(ContextDA contextDA) {
            ContextDA = contextDA;
        }

        
        public void PersistInBase(int salaire, string description, string intitule, string responsable, string statut)
        {
            Statut statutOffre = new Statut();
            statutOffre.Libelle = statut;

            Offre offre = new Offre
            {
                Salaire = salaire,
                Date = DateTime.Now,
                Description = description,
                Intitule = intitule,
                Responsable = responsable,
                Statut = statutOffre
            };
            ContextDA.Offres.Add(offre);
            ContextDA.SaveChanges();
        }

        public void ChangePrice(int editedPrice, int idSelectedOffre)
        {
            Offre offreEntity = ContextDA.Offres.FirstOrDefault(o => o.Id == idSelectedOffre);
            if (offreEntity != null)
            {
                offreEntity.Salaire = editedPrice;
                ContextDA.SaveChanges();
            }
        }

       
    }
}
