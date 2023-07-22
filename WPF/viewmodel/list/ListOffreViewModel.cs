using Bibliotheque;
using Bibliotheque.entity;
using System.Collections.ObjectModel;
using System.Linq;

namespace WPF.viewmodel
{
    public class ListOffreViewModel
    {
        
        public ObservableCollection<OffreViewModel> OffreViewModels { get; set; }
        public ListOffreViewModel(MainManager mainManager)
        {
            OffreViewModels = new ObservableCollection<OffreViewModel>();
            foreach (Offre offre in mainManager.GetOffres().ToArray())
            {
                OffreViewModels.Add(new OffreViewModel(offre));
            }
        }
    }
}
