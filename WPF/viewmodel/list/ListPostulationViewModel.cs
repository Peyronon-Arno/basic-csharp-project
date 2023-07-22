using Bibliotheque;
using Bibliotheque.entity;
using System.Collections.ObjectModel;
using System.Linq;
using WPF.viewmodel.entity;

namespace WPF.viewmodel
{
    public class ListPostulationViewModel
    {
        public ObservableCollection<PostulationViewModel> postulationViewModels { get; set; }
        public ObservableCollection<EmployeViewModel> postulants { get; set; }
        public ListPostulationViewModel(MainManager mainManager)
        {
            postulants = new ObservableCollection<EmployeViewModel>();
            postulationViewModels = new ObservableCollection<PostulationViewModel>();
            foreach (Postulation postulation in mainManager.GetPostulations().ToArray())
            {
                postulationViewModels.Add(new PostulationViewModel(postulation));
            }
        }
    }
}
