using Bibliotheque;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WPF.commandes;
using WPF.viewmodel.entity;
using WPF.viewmodel.list;

namespace WPF.viewmodel
{
    public class Manager : INotifyPropertyChanged
    {
        private readonly MainManager mainManager = new MainManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private OffreViewModel selectedOffreViewModel;
        public OffreViewModel SelectedOffreViewModel
        {
            get { return selectedOffreViewModel; }
            set
            {
                if (selectedOffreViewModel != value)
                {
                    selectedOffreViewModel = value;
                    OnPropertyChanged(nameof(SelectedOffreViewModel));
                }
            }
        }

        private string selectedComboBoxItem;
        public string SelectedComboBoxItem
        {
            get { return selectedComboBoxItem; }
            set
            {
                if (selectedComboBoxItem != value)
                {
                    selectedComboBoxItem = value;
                    OnPropertyChanged(nameof(SelectedComboBoxItem));
                    ApplyStatusFilter();
                }
            }
        }

        private ICommand modifyStatus;
        public ICommand ModifyStatus
        {
            get
            {
                return modifyStatus;
            }
            set
            {
                modifyStatus = value;
            }
        }
        private ICommand modifyPrice;
        public ICommand ModifyPrice
        {
            get
            {
                return modifyPrice;
            }
            set
            {
                modifyPrice = value;
            }
        }

        private ICommand showModifyPrice;
        public ICommand ShowModifyPrice
        {
            get
            {
                return showModifyPrice;
            }
            set
            {
                showModifyPrice = value;
            }
        }

        private ICommand showCreerOffre;
        public ICommand ShowCreerOffre
        {
            get
            {
                return showCreerOffre;
            }
            set
            {
                showCreerOffre = value;
            }
        }

        private ICommand submitCreerOffre;
        public ICommand SubmitCreerOffre
        {
            get
            {
                return submitCreerOffre;
            }
            set
            {
                submitCreerOffre = value;
            }
        }


        private bool canExecute = true;
        public bool CanExecute
        {
            get
            {
                return canExecute;
            }

            set
            {
                if (canExecute == value)
                    return;
                canExecute = value;
            }
        }
        private bool isEditPanelVisible = false;
        public bool IsEditPanelVisible
        {
            get { return isEditPanelVisible; }
            set
            {
                if (isEditPanelVisible != value)
                {
                    isEditPanelVisible = value;
                    OnPropertyChanged(nameof(IsEditPanelVisible));
                }
            }
        }
        private int editedPrice;
        public int EditedPrice
        {
            get { return editedPrice; }
            set
            {
                if (editedPrice != value)
                {
                    editedPrice = value;
                    OnPropertyChanged(nameof(EditedPrice));
                }
            }
        }
        private bool isCreateOffreVisible = false;
        public bool IsCreateOffreVisible
        {
            get { return isCreateOffreVisible; }
            set
            {
                if (isCreateOffreVisible != value)
                {
                    isCreateOffreVisible = value;
                    OnPropertyChanged(nameof(isCreateOffreVisible));
                }
            }
        }
        private string intitule;
        public string Intitule
        {
            get { return intitule; }
            set
            {
                if (intitule != value)
                {
                    intitule = value;
                    OnPropertyChanged(nameof(Intitule));
                }
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        private int salaire;
        public int Salaire
        {
            get { return salaire; }
            set
            {
                if (salaire != value)
                {
                    salaire = value;
                    OnPropertyChanged(nameof(Salaire));
                }
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }
        private string responsable;
        public string Responsable
        {
            get { return responsable; }
            set
            {
                if (responsable != value)
                {
                    responsable = value;
                    OnPropertyChanged(nameof(Responsable));
                }
            }
        }
        public ObservableCollection<OffreViewModel> BaseOffreViewModels { get; set; }
        public ObservableCollection<OffreViewModel> OffreViewModels { get; set; }
        public ObservableCollection<EmployeViewModel> EmployeViewModels { get; set; }
        public ObservableCollection<PostulationViewModel> postulationViewModels { get; set; }
        public ObservableCollection<string> listStatutViewModels { get; set; }
        public ObservableCollection<EmployeViewModel> postulants { get; set; }
        public ListOffreViewModel listOffreViewModel;
        public ListEmployeViewModel listEmployeViewMode;
        public ListPostulationViewModel listPostulationViewModel;
        public ListStatusViewModel listStatusViewModel;

        public Manager() {
            Init();
            LoadPostulants();
            InitCommands();
        }

        private void Init()
        {
            listStatutViewModels = new ListStatusViewModel(mainManager).statutViewModels;
            listStatutViewModels.Insert(0, "");
            listPostulationViewModel = new ListPostulationViewModel(mainManager);
            EmployeViewModels = new ListEmployeViewModel(mainManager).ListEmployesViewModel;
            BaseOffreViewModels = new ListOffreViewModel(mainManager).OffreViewModels;
            BaseOffreViewModels = new ObservableCollection<OffreViewModel>(BaseOffreViewModels.OrderByDescending(o => o.Salaire).ThenBy(o => o.Date));
            OffreViewModels = new ObservableCollection<OffreViewModel>(BaseOffreViewModels.OrderByDescending(o => o.Date));
            
            postulationViewModels = listPostulationViewModel.postulationViewModels;
            SelectedOffreViewModel = BaseOffreViewModels.FirstOrDefault();
            EditedPrice = SelectedOffreViewModel.Salaire;
        }

        private void InitCommands()
        {
            ShowModifyPrice = new RelayCommande(ChangeShowEditPrice, param => canExecute);
            ModifyPrice = new RelayCommande(ChangePrice, param => canExecute);
            ShowCreerOffre = new RelayCommande(ChangeShowCreateOffre, param => canExecute);
            SubmitCreerOffre = new RelayCommande(SubmitOffre, param => canExecute);
            ModifyStatus = new RelayCommande(selectedItem => ChangeStatus(selectedItem), param => canExecute);

        }

        public void ChangeStatus(object obj)
        {
            selectedComboBoxItem = obj.ToString();
        }

        public void ChangeShowEditPrice(object obj)
        {
            isEditPanelVisible = !isEditPanelVisible;
            OnPropertyChanged(nameof(isEditPanelVisible));
        }

        public void ChangePrice(object obj)
        {
            SelectedOffreViewModel.Salaire = EditedPrice;
            OnPropertyChanged(nameof(SelectedOffreViewModel));
            mainManager.ChangePrice(EditedPrice, SelectedOffreViewModel.Id);
            ChangeShowEditPrice(obj);
        }

        public void ChangeShowCreateOffre(object obj)
        {
            isCreateOffreVisible = !isCreateOffreVisible;
            OnPropertyChanged(nameof(isCreateOffreVisible));
        }

        public void SubmitOffre(object obj)
        {
            string intitule = Intitule;
            string description = Description;
            int salaire = Salaire;
            string statut = Status;
            string responsable = Responsable;

            StatutViewModel statusViewModel = new StatutViewModel();
            statusViewModel.Libelle = statut;

            OffreViewModel nouvelleOffre = CreateOffreViewModel(intitule, description, salaire, responsable, statusViewModel);
            BaseOffreViewModels.Add(nouvelleOffre);

            mainManager.PersistInBase(salaire, description, intitule,responsable, statut );

            MakeFieldsEmpty();
        }

        private OffreViewModel CreateOffreViewModel(string intitule, string  description, int salaire, string responsable, StatutViewModel status)
        {
            OffreViewModel nouvelleOffre = new OffreViewModel();
            nouvelleOffre.Intitule = intitule;
            nouvelleOffre.Description = description;
            nouvelleOffre.Salaire = salaire;
            nouvelleOffre.Statut = status;
            nouvelleOffre.Responsable = responsable;
            nouvelleOffre.Date = DateTime.Now;
            return nouvelleOffre;
        }

        private void MakeFieldsEmpty()
        {
            Intitule = string.Empty;
            Description = string.Empty;
            Salaire = 0;
            Status = string.Empty; 
            Responsable = string.Empty;
        }

        public void LoadPostulants()
        {
            postulants = new ObservableCollection<EmployeViewModel>();
            IEnumerable<PostulationViewModel> filteredPostulations = postulationViewModels.Where(p => p.IdOffre == SelectedOffreViewModel.Id);
            foreach (PostulationViewModel postulationViewModel in filteredPostulations)
            {
                int idEmploye = postulationViewModel.IdEmploye;
                EmployeViewModel employeViewModel = EmployeViewModels.FirstOrDefault(e => e.Id == idEmploye);

                if (employeViewModel != null)
                {
                    postulants.Add(employeViewModel);
                }
            }
            OnPropertyChanged(nameof(postulants));
        }

        protected void ApplyStatusFilter()
        {
            if (string.IsNullOrEmpty(SelectedComboBoxItem))
            {
                OffreViewModels = new ObservableCollection<OffreViewModel>(BaseOffreViewModels.OrderByDescending(o => o.Date).ThenBy(o => o.Salaire));
                SelectedOffreViewModel = OffreViewModels.FirstOrDefault();
            }
            else
            {
                OffreViewModels = new ObservableCollection<OffreViewModel>(BaseOffreViewModels.Where(o => o.Statut.Libelle == SelectedComboBoxItem));
                OffreViewModels = new ObservableCollection<OffreViewModel>(OffreViewModels.OrderByDescending(o => o.Date).ThenBy(o => o.Salaire));
                SelectedOffreViewModel = OffreViewModels.FirstOrDefault();

            }
            OnPropertyChanged(nameof(OffreViewModels));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
