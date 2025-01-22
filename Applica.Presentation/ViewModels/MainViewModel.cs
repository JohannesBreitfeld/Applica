using Applica.Infrastructure.Context;
using Applica.Presentation.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly CompanyService companyService;
        public CompaniesViewModel CompaniesViewModel { get; }
        public ObservableObject HomeViewModel { get; }
        public ObservableObject CompaniesDetailedViewModel { get; }
        
        [ObservableProperty]
        private ObservableObject _selectedViewModel;

        public ICommand SetVMCommand { get; }

        public MainViewModel(CompanyService companyService)
        {
            this.companyService = companyService;
            
            HomeViewModel = new HomeViewModel();
            CompaniesViewModel = new CompaniesViewModel(this, companyService);
            CompaniesDetailedViewModel = new CompanyDetailedViewModel(this, CompaniesViewModel, companyService);
            _selectedViewModel = HomeViewModel;
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
