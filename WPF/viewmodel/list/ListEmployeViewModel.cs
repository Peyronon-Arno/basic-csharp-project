using Bibliotheque;
using Bibliotheque.entity;
using System.Collections.ObjectModel;
using System.Linq;

namespace WPF.viewmodel
{
    public class ListEmployeViewModel
    {
        public ObservableCollection<EmployeViewModel> ListEmployesViewModel
        {
            get; set;
        }  

        public ListEmployeViewModel(MainManager mainManager)
        {
            ListEmployesViewModel = new ObservableCollection<EmployeViewModel>();

            foreach (Employe employe in mainManager.GetEmployes().ToArray())
            {
                ListEmployesViewModel.Add(new EmployeViewModel(employe));
            }
        }
    }
}
