using Bibliotheque.entity;
using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class EmployeDetailViewModel
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom{ get; set; }
        public DateTime DateNaissance { get; set; }
        public int Anciennete { get; set; }
        public string Biographie { get; set; }
        public string Diplome { get; set; }
        public List<Experience> Experiences { get ; set; }


        public EmployeDetailViewModel() { }
        public EmployeDetailViewModel(Employe employe, List<Experience> experiences) {
            Id = employe.Id;
            Nom = employe.Nom;
            Prenom = employe.Prenom;
            DateNaissance = employe.DateNaissance;
            Anciennete = employe.Anciennete;
            Biographie = employe.Biographie;
            Diplome = employe.Diplome;
            Experiences = experiences;
        }
    }
}