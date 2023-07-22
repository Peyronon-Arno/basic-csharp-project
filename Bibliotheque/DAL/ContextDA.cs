using Bibliotheque.entity;
using System.Data.Entity;
using System.Reflection;

namespace Bibliotheque.DAL
{
    public class ContextDA: DbContext
    {
        public ContextDA(): base("name=Database1") {
            ContextInitializer contextInitializer = new ContextInitializer();
             contextInitializer.InitializeDatabase(this);
        }

        public DbSet<Employe> Employes { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Postulation> Postulations { get; set; }
        public DbSet<Statut> Statuts{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
