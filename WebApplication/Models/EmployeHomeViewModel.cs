using Bibliotheque.entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class EmployeHomeViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public int Anciennete { get; set; }
        public string Biographie { get; set; }
        public string Diplome { get; set; }
        public List<Postulation> Postulations { get; set; }
        public EmployeHomeViewModel() { }
        public EmployeHomeViewModel(Employe employe, List<Postulation> postulations)
        {
            Id = employe.Id;
            Nom = employe.Nom;
            Prenom = employe.Prenom;
            DateNaissance = employe.DateNaissance;
            Anciennete = employe.Anciennete;
            Biographie = employe.Biographie;
            Diplome = employe.Diplome;
            Postulations = postulations;
        }


    }
}