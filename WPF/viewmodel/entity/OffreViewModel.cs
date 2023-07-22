using Bibliotheque.entity;
using System;
using System.Windows;
using WPF.viewmodel.entity;

namespace WPF.viewmodel
{
    public  class OffreViewModel: BaseViewModel
    {
        public Offre offre;

        public int Id
        {
            get { return offre.Id; }
            set
            {
                offre.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Intitule
        {
            get { return offre.Intitule; }
            set
            {
                offre.Intitule = value;
                OnPropertyChanged(nameof(Intitule));
            }
        }
        public DateTime Date
        {
            get { return offre.Date; }
            set
            {
                offre.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public int Salaire
        {
            get { return offre.Salaire; }
            set
            {
                offre.Salaire = value;
                OnPropertyChanged(nameof(Salaire));
            }
        }
        public string Description
        {
            get { return offre.Description; }
            set
            {
                offre.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public StatutViewModel Statut
        {
            get { return new StatutViewModel(offre.Statut); }
            set
            {
                offre.Statut = value?.statut;
                OnPropertyChanged(nameof(Statut));
            }
        }

        public string Responsable
        {
            get { return offre.Responsable; }
            set
            {
                offre.Responsable = value;
                OnPropertyChanged(nameof(Responsable));
            }
        }

        public OffreViewModel()
        {
            this.offre = new Offre();
        }

        public OffreViewModel(Offre offre) {
            this.offre = offre;
        }

    }
}
