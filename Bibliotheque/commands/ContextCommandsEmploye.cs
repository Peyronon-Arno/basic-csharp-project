using Bibliotheque.DAL;
using Bibliotheque.entity;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace Bibliotheque.commands
{
    public class ContextCommandsEmploye
    {
        private ContextDA ContextDA { get; set; }
        public ContextCommandsEmploye(ContextDA contextDA) {
            ContextDA = contextDA;
        }

        public void AddEmploye(Employe employe)
        {
            ContextDA.Employes.Add(employe);
        }

        public void EditEmploye(Employe employe)
        {
            ContextDA.Entry(employe).State = EntityState.Modified;
            ContextDA.SaveChanges();
        }

        public void RemoveEmploye(Employe employe)
        {
            ContextDA.Employes.Remove(employe);
            ContextDA.SaveChanges();
        }

        public void UpdateEmploye(Employe employe)
        {

            Employe existingEmploye = ContextDA.Employes.Find(employe.Id);
            if (existingEmploye != null)
            {
                existingEmploye.Nom = employe.Nom;
                existingEmploye.Prenom = employe.Prenom;
                existingEmploye.DateNaissance = employe.DateNaissance;
                existingEmploye.Anciennete = employe.Anciennete;
                existingEmploye.Biographie = employe.Biographie;
                existingEmploye.Diplome = employe.Diplome;
                ContextDA.SaveChanges();
            }
        }
    }
}
