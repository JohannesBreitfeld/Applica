using Applica.Domain.Entities;
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

    [ObservableProperty]
    private ObservableCollection<string> _filterBy = new ObservableCollection<string> { "Filter by...", "All companies", "Application sent", "Application not sent", "Follow up date reached" };

    [ObservableProperty]
    private string _filterSelected = "Filter by...";


    [ObservableProperty]
    private ObservableCollection<string> _orderBy = new ObservableCollection<string> { "Order by...", "Alphabet", "Latest activity", "Follow up date" };

    [ObservableProperty]
    private string _orderSelected = "Order by...";

    public ICommand DeleteCompanyCommand { get; }
    public ICommand NewCompanyCommand { get; }
    public ICommand OpenCommand { get; }
    public ICommand UpdateCommand { get; }
   
    public CompaniesViewModel(MainViewModel mainViewModel, CompanyService companyService)
    {
        MainViewModel = mainViewModel;

        this.companyService = companyService;

        NewCompanyCommand = new AsyncRelayCommand(NewCompany);
        DeleteCompanyCommand = new AsyncRelayCommand<CompanyVM>(DeleteCompany!, sc => sc is not null);
        OpenCommand = new RelayCommand(OpenDetailedView);
        UpdateCommand = new AsyncRelayCommand(UpdateCompanies);
    }

    partial void OnSelectedCompanyChanged(CompanyVM? oldValue, CompanyVM? newValue)
    {
        if(oldValue is not null)
        {
            oldValue.SelectedActivityChanged -= SelectedActivityChanged;
        }

        if (newValue is not null)
        {
            newValue.SelectedActivityChanged += SelectedActivityChanged;
        }

    }

    private void SelectedActivityChanged()
    {
        MainViewModel.CompaniesDetailedViewModel.SelectedCategory = MainViewModel.CompaniesDetailedViewModel.Categories
            .FirstOrDefault(c => c.Description == SelectedCompany?.SelectedActivity?.Category)
            ?? MainViewModel.CompaniesDetailedViewModel.Categories.FirstOrDefault();
    }

    partial void OnFilterSelectedChanged(string value)
    {
        UpdateCommand.Execute(null);
    }

    partial void OnOrderSelectedChanged(string value)
    {
        OrderCompanies();
    }

    private void OrderCompanies()
    {
        if (string.IsNullOrEmpty(OrderSelected) || Companies is null)
        {
            return;
        }
        Companies = OrderSelected switch
        {
            "Alphabet" => new ObservableCollection<CompanyVM>(Companies.OrderBy(company => company.Name)),

            "Latest activity" => new ObservableCollection<CompanyVM>(new ObservableCollection<CompanyVM>(
                Companies.OrderByDescending(company => company.Activities
                    .DefaultIfEmpty(new ActivityVM() { Date = DateOnly.MinValue})
                    .Max(activity => activity?.Date ?? DateOnly.MinValue)))),

            "Follow up date" => new ObservableCollection<CompanyVM>(
                Companies.OrderBy(company => company.Activities
                    .DefaultIfEmpty(new ActivityVM() { FollowUpDate = DateOnly.MaxValue})
                    .Min(activity => activity?.FollowUpDate ?? DateOnly.MaxValue))),

            _ => Companies
        };
    }

    private async Task UpdateCompanies()
    {
        if (string.IsNullOrEmpty(FilterSelected))
        {
            return;
        }
        Companies = FilterSelected switch
        {
            "All companies" => await companyService.GetAllAsync(),

            "Application sent" => await companyService
                .FindAsync(company => company.Activities!
                .Any(activity => activity.Category == "Application")),

            "Application not sent" => await companyService
                .FindAsync(company => company.Activities!
                .All(activity => activity.Category != "Application")),

            "Follow up date reached" => await companyService
                .FindAsync(company => company.Activities!
                .Any(activity => activity.FollowUpDate <= DateOnly.FromDateTime(DateTime.Now) && activity.FollowUpDate != null)),
            _ => Companies

        };
        OrderCompanies();
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
        SelectedCompany = new CompanyVM() { Name = "New Company", Url = "www.website.com" };
        Companies?.Add(SelectedCompany);
        await companyService.AddAsync(SelectedCompany);
        MainViewModel.SelectedViewModel = MainViewModel.CompaniesDetailedViewModel;
    }

    public async Task LoadAllCompaniesAsync()
    {
        Companies = await companyService.GetAllAsync();
    }

}
