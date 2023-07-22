using Bibliotheque.DAL;
using Bibliotheque.entity;
using System.Data.Entity;

namespace Bibliotheque.commands
{
    public class ContextCommandsPostulation
    {
        private ContextDA ContextDA { get; set; }
        public ContextCommandsPostulation(ContextDA contextDA) {
            ContextDA = contextDA;
        }

        public void AddPostulation(Postulation postulation)
        {
            foreach(Postulation p in ContextDA.Postulations){
                if (p.IdEmploye.Equals(postulation.IdEmploye) && p.IdOffre.Equals(postulation.IdOffre))
                {
                    return;
                }
            }

            ContextDA.Postulations.Add(postulation);
            ContextDA.SaveChanges();
        }
    }
}
