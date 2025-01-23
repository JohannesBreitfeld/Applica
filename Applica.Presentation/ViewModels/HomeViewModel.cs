using Applica.Presentation.Resources;
using Applica.Presentation.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly CompanyService companyService;

        [ObservableProperty]
        private int _numberOfApplications = 0;
        
        [ObservableProperty]
        private int _numberOfOffers = 0;
        
        [ObservableProperty]
        private int _numberOfRejections = 0;

        [ObservableProperty]
        private bool _canLoadSampleData = false;

        public ICommand LoadSampleDataCommand { get; }

        public HomeViewModel(CompanyService companyService)
        {
            this.companyService = companyService;

            LoadSampleDataCommand = new AsyncRelayCommand(LoadSampleData);
        }

        private async Task LoadSampleData()
        {
            var sampleData = SampleDataGenerator.GenerateSampleData();

            await companyService.AddRangeAsync(sampleData);

            await LoadData();
        }

        public async Task LoadData()
        {
            var data = await companyService.GetAllAsync();

            if(data.Count < 5)
            {
                CanLoadSampleData = true;
            }

            NumberOfApplications = data.Where(company => company.Activities
                        .Any(activity => activity.Category == "Application"))
                        .Count();

            NumberOfOffers = data.Where(company => company.Activities
                        .Any(activity => activity.Category == "Offer"))
                        .Count();

            NumberOfRejections = data.Where(company => company.Activities
                        .Any(activity => activity.Category == "Rejection"))
                        .Count();
        }



    }
}
