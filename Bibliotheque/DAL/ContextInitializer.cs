using Bibliotheque.entity;
using Bogus;

using System;
using System.Collections.Generic;
namespace Bibliotheque.DAL
{
    internal class ContextInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<ContextDA>
    {

        protected override void Seed(ContextDA context)
        {

            Faker<Employe> employeFaker = new Faker<Employe>()
                .RuleFor(e => e.Nom, f => f.Person.LastName)
                .RuleFor(e => e.Prenom, f => f.Person.FirstName)
                .RuleFor(e => e.DateNaissance, f => f.Person.DateOfBirth)
                .RuleFor(e => e.Anciennete, f => f.Random.Int(0, 10))
                .RuleFor(e => e.Diplome, f => f.Lorem.Word())
                .RuleFor(e => e.Biographie, f => f.Lorem.Sentence());

            Faker<Formation> formationFaker = new Faker<Formation>()
                .RuleFor(f => f.Intitule, f => f.Lorem.Word())
                .RuleFor(f => f.Date, f => f.Date.Past());

            Faker<Experience> experienceFaker = new Faker<Experience>()
                .RuleFor(e => e.Intitule, f => f.Lorem.Word())
                .RuleFor(e => e.Date, f => f.Date.Past());

            Faker<Offre> offreFaker = new Faker<Offre>()
                .RuleFor(o => o.Intitule, f => f.Lorem.Word())
                .RuleFor(o => o.Date, f => f.Date.Past())
                .RuleFor(o => o.Salaire, f => f.Random.Int(1000, 5000))
                .RuleFor(o => o.Description, f => f.Lorem.Sentence())
                .RuleFor(o => o.Responsable, f => f.Person.FullName);

            Faker<Postulation> postulationFaker = new Faker<Postulation>()
                .RuleFor(p => p.Date, f => f.Date.Past())
                .RuleFor(p => p.Statut, f => f.Random.Int(1, 5));

            Faker<Statut> statutFaker = new Faker<Statut>()
                .RuleFor(s => s.Libelle, f => f.Random.Bool() ? "disponible" : "non disponible");


            List<Employe> employees = new List<Employe>();
            List<Formation> formations = new List<Formation>();
            List<Experience> experiences = new List<Experience>();
            List<Offre> offres = new List<Offre>();
            List<Postulation> postulations = new List<Postulation>();
            List<Statut> statuts = new List<Statut>();

            for (int i = 0; i < 5; i++)
            {
                Employe employe = employeFaker.Generate();
                employe.Id = i;
                employees.Add(employe);

                Formation formation = formationFaker.Generate();
                formation.Id = i;
                formations.Add(formation);

                Experience experience = experienceFaker.Generate();
                experience.Id = i;
                experiences.Add(experience);

                Offre offre = offreFaker.Generate();
                offre.Id = i;
                offres.Add(offre);

                Postulation postulation = postulationFaker.Generate();
                postulation.IdEmploye = employe.Id;
                postulation.IdOffre = offre.Id;
                postulations.Add(postulation);

                Statut statut = statutFaker.Generate();
                statut.Id = i;
                statuts.Add(statut);
            }

            for (int i = 0; i < formations.Count; i++)
            {
                Formation formation = formations[i];
                formation.IdEmploye = employees[i].Id;
            }

            for (int i = 0; i < experiences.Count; i++)
            {
                Experience experience = experiences[i];
                experience.IdEmploye = employees[i].Id;
            }

            for (int i = 0; i < offres.Count; i++)
            {
                Offre offre = offres[i];
                offre.IdStatut = statuts[i].Id;
            }

            employees.ForEach(e => context.Employes.Add(e));
            experiences.ForEach(e => context.Experiences.Add(e));
            formations.ForEach(f => context.Formations.Add(f));
            offres.ForEach(o => context.Offres.Add(o));
            postulations.ForEach(p => context.Postulations.Add(p));
            statuts.ForEach(s => context.Statuts.Add(s));

            context.SaveChanges();
        }
    }
}
