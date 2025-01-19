using Applica.Presentation.ViewModels.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels;

public partial class CompaniesViewModel : ObservableObject
{
    public MainViewModel MainViewModel { get; }
 
    [ObservableProperty]
    private CompanyVM? _selectedCompany;

    [ObservableProperty]
    private List<CompanyVM> _companies = new List<CompanyVM>();

    //public ICommand OpenCompanyDetailsCommand { get; }

    public ICommand NewCompanyCommand { get; }


    public CompaniesViewModel(MainViewModel mainViewModel)
    {
        MainViewModel = mainViewModel;

        NewCompanyCommand = new RelayCommand(NewCompany);
    }

    private void NewCompany()
    {
        SelectedCompany = new CompanyVM() { Name = "New Company", Url = "www.google.com"};
        Companies.Add(SelectedCompany);
        MainViewModel.SelectedViewModel = MainViewModel.CompaniesDetailedViewModel;
    }
}
