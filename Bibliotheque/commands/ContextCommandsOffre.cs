using Bibliotheque.DAL;
using Bibliotheque.entity;
using System.Data.Entity;

namespace Bibliotheque.commands
{
    public class ContextCommandsOffre
    {
        private ContextDA ContextDA { get; set; }
        public ContextCommandsOffre(ContextDA contextDA) {
            ContextDA = contextDA;
        }

        public void AddOffre(Offre offre)
        {
            ContextDA.Offres.Add(offre);
            ContextDA.SaveChanges();
        }

        public void EditOffre(Offre offre)
        { 
            ContextDA.Entry(offre).State = EntityState.Modified;
            ContextDA.SaveChanges();
        }

        public void DeleteOffre(Offre offre)
        {
            ContextDA.Offres.Remove(offre);
            ContextDA.SaveChanges();
        }
    }
}
