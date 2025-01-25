using Applica.Presentation.Services;
using Applica.Presentation.ViewModels.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels;

public partial class CompaniesViewModel : ObservableObject
{
    private readonly CompanyService companyService;
    public MainViewModel MainViewModel { get; }

    [ObservableProperty]
    private CompanyVM? _selectedCompany;

    [ObservableProperty]
    private ObservableCollection<CompanyVM>? _companies;

    public ICommand DeleteCompanyCommand { get; }
    public ICommand NewCompanyCommand { get; }
    public ICommand OpenCommand { get; }

    public CompaniesViewModel(MainViewModel mainViewModel, CompanyService companyService)
    {
        MainViewModel = mainViewModel;

        this.companyService = companyService;

        NewCompanyCommand = new AsyncRelayCommand(NewCompany);
        DeleteCompanyCommand = new AsyncRelayCommand<CompanyVM>(DeleteCompany!, sc => sc is not null);
        OpenCommand = new RelayCommand(OpenDetailedView);
    }

    private void OpenDetailedView()
    {
        MainViewModel.SelectedViewModel = MainViewModel.CompaniesDetailedViewModel;
    }

    private async Task DeleteCompany(CompanyVM selectedCompany)
    {
        if (selectedCompany is not null)
        {
            Companies?.Remove(selectedCompany);
            await companyService.DeleteAsync(selectedCompany);
        }
    }

    private async Task NewCompany()
    {
        SelectedCompany = new CompanyVM() { Name = "New Company", Url = "www.google.com" };
        Companies?.Add(SelectedCompany);
        await companyService.AddAsync(SelectedCompany);
        MainViewModel.SelectedViewModel = MainViewModel.CompaniesDetailedViewModel;
    }

    public async Task LoadAllCompaniesAsync()
    {
        Companies = await companyService.GetAllAsync();
    }

    private async void SaveChangesAsync()
    {
        if(SelectedCompany is not null)
        {
            await companyService.UpdateAsync(SelectedCompany);
        }
    }

}
