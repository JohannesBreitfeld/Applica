using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        public ObservableObject CompaniesViewModel { get; }
        public ObservableObject HomeViewModel { get; }
        
        [ObservableProperty]
        private ObservableObject _selectedViewModel;

        public ICommand SetVMCommand { get; }

        public MainViewModel(ObservableObject homeViewModel, ObservableObject companiesViewModel)
        {
            HomeViewModel = homeViewModel;
            CompaniesViewModel = companiesViewModel;
            _selectedViewModel = homeViewModel;
            SetVMCommand = new RelayCommand<object>(SetViewModel);
        }

        private void SetViewModel(object? parameter)
        {
            if (parameter is ObservableObject vm)
            {
                SelectedViewModel = vm;
            }
        }
    }
}
