using Bibliotheque.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.viewmodel.entity
{
    public class StatutViewModel : BaseViewModel
    {
        public Statut statut;

        public int Id
        {
            get { return statut.Id; }
            set
            {
                statut.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Libelle
        {
            get { return statut?.Libelle; }
            set
            {
                if(statut == null)
                {
                    statut = new Statut();
                    statut.Libelle = value;
                }else
                {
                    statut.Libelle = value;

                }
                OnPropertyChanged(nameof(Libelle));
            }
        }

        public StatutViewModel() { }

        public StatutViewModel(Statut statut) {
            this.statut = statut;
        }
    }
}
