using Bibliotheque.entity;
using Bibliotheque;
using System.Collections.ObjectModel;
using System.Linq;

namespace WPF.viewmodel.list
{
    public class ListStatusViewModel
    {
        public ObservableCollection<string> statutViewModels { get; set; }
        public ListStatusViewModel(MainManager mainManager)
        {
            statutViewModels = new ObservableCollection<string>();
            foreach (Statut status in mainManager.GetStatuts().ToArray())
            {
                statutViewModels.Add(status.Libelle);
            }
            statutViewModels.Distinct();

        }
    }
}
