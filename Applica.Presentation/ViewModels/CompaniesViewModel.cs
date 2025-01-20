using Applica.Presentation.Services;
using Applica.Presentation.ViewModels.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels;

public partial class CompaniesViewModel : ObservableObject
{
    private readonly CompanyService companyService;
    public MainViewModel MainViewModel { get; }

    [ObservableProperty]
    private CompanyVM? _selectedCompany;

    [ObservableProperty]
    private List<CompanyVM> _companies = new List<CompanyVM>();

    //public ICommand OpenCompanyDetailsCommand { get; }

    public ICommand NewCompanyCommand { get; }


    public CompaniesViewModel(MainViewModel mainViewModel, CompanyService companyService)
    {
        MainViewModel = mainViewModel;

        this.companyService = companyService;

        NewCompanyCommand = new AsyncRelayCommand(NewCompany);
    }

    private async Task NewCompany()
    {
        SelectedCompany = new CompanyVM() { Name = "New Company", Url = "www.google.com" };
        Companies.Add(SelectedCompany);
        await companyService.AddAsync(SelectedCompany);
        MainViewModel.SelectedViewModel = MainViewModel.CompaniesDetailedViewModel;
    }
}
