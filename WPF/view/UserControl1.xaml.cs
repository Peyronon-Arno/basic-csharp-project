using System.Windows.Controls;
using WPF.viewmodel;

namespace WPF.view
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void OffreListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            OffreViewModel selectedOffre = (OffreViewModel)listView.SelectedItem;
            if(selectedOffre != null)
            {
                Manager manager = (Manager) this.DataContext;
                manager.SelectedOffreViewModel = selectedOffre;
                manager.EditedPrice = manager.SelectedOffreViewModel.Salaire;
                manager.LoadPostulants();
            }
        }
    }
}
