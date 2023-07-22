using Bibliotheque.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.viewmodel.entity
{
    public class PostulationViewModel: BaseViewModel
    {
        public Postulation postulation;
        public int IdOffre
        {
            get { return postulation.IdOffre; }
            set
            {
                postulation.IdOffre = value;
                OnPropertyChanged(nameof(IdOffre));
            }
        }

        public int IdEmploye
        {
            get { return postulation.IdEmploye; }
            set
            {
                postulation.IdEmploye = value;
                OnPropertyChanged(nameof(IdEmploye));
            }
        }

        public DateTime Date
        {
            get { return postulation.Date; }
            set
            {
                postulation.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public int Statut
        {
            get { return postulation.Statut; }
            set
            {
                postulation.Statut = value;
                OnPropertyChanged(nameof(Statut));
            }
        }

        public PostulationViewModel(Postulation postulation)
        {
            this.postulation = postulation;
        }
    }
}
