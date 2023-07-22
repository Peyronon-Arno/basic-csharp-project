using Bibliotheque.entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.viewmodel
{
    public class EmployeViewModel: BaseViewModel
    {
        Employe employe;

        public int Id
        {
            get { return employe.Id; }
            set
            {
                employe.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Nom
        {
            get { return employe.Nom; }
            set
            {
                employe.Nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }

        public string Prenom
        {
            get { return employe.Prenom; }
            set
            {
                employe.Prenom = value;
                OnPropertyChanged(nameof(Prenom));
            }
        }

        public DateTime DateNaissance
        {
            get { return employe.DateNaissance; }
            set
            {
                employe.DateNaissance = value;
                OnPropertyChanged(nameof(DateNaissance));
            }
        }

        public int Anciennete
        {
            get { return employe.Anciennete; }
            set
            {
                employe.Anciennete = value;
                OnPropertyChanged(nameof(Anciennete));
            }
        }

        public string Biographie
        {
            get { return employe.Biographie; }
            set
            {
                employe.Biographie = value;
                OnPropertyChanged(nameof(Biographie));
            }
        }

        public EmployeViewModel(Employe employe)
        {
            this.employe = employe;
        }
    }
}
